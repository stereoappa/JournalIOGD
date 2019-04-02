using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoadOfSql
{
    public delegate void ResponseRow(DataGridViewRow editRow);
    public partial class Form8GetMapCases : Form
    {
        string selectCommand = @"SELECT DISTINCT Организации.Название AS Организация, Организации.ВыданоПланшетов AS Количество FROM Организации WHERE ID != 33 ORDER BY Организации.ВыданоПланшетов DESC";
        FormResultCallback callback;
        bool formIsChanged = false;
        string select_name;
        public Form8GetMapCases(FormResultCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
        }
        public Form8GetMapCases(string name, FormResultCallback callback) : this(callback)
        {
            select_name = name;
        }
        private void Form8GetMapCases_Load(object sender, EventArgs e)
        {
            GetData(selectCommand);
            dataGridView1.Columns[0].Width = 200;
            RedSelection();

            if (select_name != null)
                bindingSource1.Position = bindingSource1.Find("Организация", select_name);
        }

        private void GetData(string command)
        {
            try
            {
                dataGridView1.DataSource = bindingSource1;
                string connStr = GlobalSettings.ConnectionString;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connStr);
                DataTable table = new DataTable();

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обращения к базе данных.\n" + ex.Message + "\n" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name, "Системный сбой", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void RedSelection()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((row.Cells[1].Value != DBNull.Value) && (Convert.ToInt32(row.Cells[1].Value) >= 200))        //Если выдали больше 200 планшетов - подсеветим
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
            }
        }

        private void обнулитьКолличествоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Данное действие приведет к обнулению счетчик планшетов выбранной организации.\n\nНажмите ОК только в случае, если организация уже принесла акт об уничтожении всех выданных ей планшетов.", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(GlobalSettings.ConnectionString))
                {
                    conn.Open();
                    SqlCommand counOfNull = conn.CreateCommand();
                    SqlCommand requireActToDel = conn.CreateCommand();
                    counOfNull.CommandText = @"UPDATE Организации SET ВыданоПланшетов = 0 WHERE Название = " + "'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    requireActToDel.CommandText = @"UPDATE Журнал SET RequireConfirmAct = 0 WHERE RequireConfirmAct > 0 AND Organ_ID = (Select MIN(Организации.ID) From Организации Where Организации.Название = " + "'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";
                    try
                    {
                        counOfNull.Transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                        counOfNull.ExecuteNonQuery();
                        counOfNull.Transaction.Commit();

                        requireActToDel.Transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                        requireActToDel.ExecuteNonQuery();
                        requireActToDel.Transaction.Commit();
                    }
                    catch
                    {
                        counOfNull.Transaction.Rollback();
                        requireActToDel.Transaction.Rollback();
                        conn.Close();
                        MessageBox.Show("Не получилось сбросить счетчик количества планшетов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();
                }
                dataGridView1.CurrentRow.Cells[1].Value = 0;
                dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Empty;

                formIsChanged = true;
            }
        }
        
        private void подтвердитьАктомОбУдаленииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9AddSubMapCount form9 = new Form9AddSubMapCount(dataGridView1.CurrentRow, new ResponseRow(EditCount));
            form9.ShowDialog();
        }
        void EditCount(DataGridViewRow editRow) 
        {
            dataGridView1.Rows[editRow.Index].SetValues(new object[] {dataGridView1.CurrentRow.Cells[0].Value, editRow.Cells[1].Value, editRow.Cells[1].Value });
            RedSelection();
            formIsChanged = true;
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex < dataGridView1.ColumnCount && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.RowCount && e.RowIndex >= 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridView1.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }

        private void Form8GetMapCases_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formIsChanged == true)
                callback(DialogResult.OK);
            else
                callback(DialogResult.Ignore);
        }
    }
}
