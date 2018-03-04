using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql
{
    public partial class Form9AddSubMapCount : Form
    {
        ResponseRow response;
        DataGridViewRow row;
        int beforeCount;
        //int confirmActs;
        public Form9AddSubMapCount(DataGridViewRow row, ResponseRow d)
        {
            InitializeComponent();
            this.response = d;
            this.row = row;
            int.TryParse(row.Cells[1].Value.ToString(), out beforeCount);
        }

        private void Form9AddSubMapCount_Load(object sender, EventArgs e)
        {
            label1.Text = row.Cells[0].Value.ToString();
            numericUpDown1.Maximum = beforeCount;
            if (row.Cells[1].Value.ToString() != "")
            {
                label5.Text = row.Cells[1].Value.ToString();
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                label5.Text = "Нет выданных планшетов";
                numericUpDown1.Enabled = false;
                button1.Enabled = false;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericUpDown1.Value) > 0)
            { 
                DialogResult res = MessageBox.Show(string.Format("Данное действие приведет к уменьшению количества выданных планшетов выбранной организации.\n\nНажмите ОК только в случае, если организация уже принесла акт об уничтожении {0} планшетов.", numericUpDown1.Value.ToString()),
                    "Предупреждение!",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    Cursor = Cursors.AppStarting;
                    button1.Enabled = false;
                    int confirmActs = Convert.ToInt32(numericUpDown1.Value);         //подтвержденные планшеты
                    if (confirmActs == 0) Cursor = Cursors.Default; Close();
                    if (confirmActs > beforeCount)
                    {
                        MessageBox.Show("Невозможно списать больше планшетов, чем было выдано", "Ошибка логики", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        goto NextFormWork;
                    }

                    if ((confirmActs <= beforeCount) && (confirmActs != 0))
                    {
                        SetSummCounter(Convert.ToInt32(beforeCount - numericUpDown1.Value), row.Cells[0].Value.ToString());
                        ComputeRequiredAct(confirmActs, row.Cells[0].Value.ToString());
                        row.Cells[1].Value = (beforeCount - numericUpDown1.Value).ToString();
                    }
                    response.Invoke(row);
                    Close();
                    NextFormWork: Cursor = Cursors.Default;
                }
            }
        }

        void ComputeRequiredAct(int conf_acts, string organization)
        {
            if (conf_acts != 0)
                using (SqlConnection conn = new SqlConnection(GlobalSettings.ConnectionString))
                {
                    conn.Open();
                    string requireActToDel = @"select Журнал.ID, Организации.Название, MapCasesCount, RequireConfirmAct from (Журнал LEFT OUTER JOIN Организации ON Журнал.Organ_ID = Организации.ID) " +
                                               "where Organ_ID = " +
                                               "(Select MIN(Организации.ID) From Организации Where Организации.Название =" + "'" + organization + "') " +
                                               "and MapCasesCount > 0" +
                                               " and RequireConfirmAct > 0" +
                                               " order by Журнал.ID";
                    SqlDataAdapter da = new SqlDataAdapter(requireActToDel, conn);
                    DataSet ds = new DataSet("ReqiredStrings");
                    da.FillSchema(ds, SchemaType.Source, "RequiredStrings");
                    da.Fill(ds, "RequiredStrings");
                    DataTable tblRequredStrings;
                    tblRequredStrings = ds.Tables["RequiredStrings"];

                    //Теперь на выгруженной таблице необходимо вычесть из поля RequireConfirmAct значение requiredAct
                    //единожды, и если это значение слишком большое то перейти к следующей строке 

                    foreach (DataRow drCurrent in tblRequredStrings.Rows)
                    {
                        int currentVal = Convert.ToInt32(drCurrent["RequireConfirmAct"]);
                        int currentID = Convert.ToInt32(drCurrent["ID"]);

                        int difference = currentVal - conf_acts;
                        if (difference >= 0)
                        {
                            SetJournalRequereCounter(currentID, difference);
                            break;
                        }
                        else
                        {
                            SetJournalRequereCounter(currentID, 0);
                            conf_acts -= currentVal;
                            continue;
                        }
                    }
                    conn.Close();
                }
        }

        private bool SetJournalRequereCounter(int id, int difference)
        {
            using (SqlConnection conn = new SqlConnection(GlobalSettings.ConnectionString))
            {
                conn.Open();
                SqlCommand editCasesCount = conn.CreateCommand();
                editCasesCount.CommandText = @"UPDATE Журнал SET RequireConfirmAct = " + "'" + difference + "'" + " WHERE ID = " + id;
                try
                {
                    editCasesCount.Transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                    editCasesCount.ExecuteNonQuery();
                    editCasesCount.Transaction.Commit();
                }
                catch
                {
                    editCasesCount.Transaction.Rollback();
                    conn.Close();
                    MessageBox.Show("Не получилось изменить значение счетчика требуемых планшетов", "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                conn.Close();
                return true;

            }

        }

        void SetSummCounter(int newCount, string organization)
        {
            if ((newCount >= 0) && (organization != null))
                using (SqlConnection conn = new SqlConnection(GlobalSettings.ConnectionString))
                {
                    conn.Open();
                    SqlCommand editCasesCount = conn.CreateCommand();
                    editCasesCount.CommandText = @"UPDATE Организации SET ВыданоПланшетов = " + "'" + newCount + "'" + " WHERE Название = " + "'" + organization + "'";
                    try
                    {
                        editCasesCount.Transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                        editCasesCount.ExecuteNonQuery();
                        editCasesCount.Transaction.Commit();
                    }
                    catch
                    {
                        editCasesCount.Transaction.Rollback();
                        conn.Close();
                        MessageBox.Show("Не получилось изменить значение счетчика планшетов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();
                }
        }
    }
}
