using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoadOfSql
{
    public partial class Form5SQLQuery : Form
    {
        //TODO: Нужно записывать в темп значения параметра Стоимости
        string newGetDataString;
        string finalAddString = "";      
        bool button2Shower;
        ///
        string cb2;
        bool checkB1;

        int cb4 = -1;
        bool checkB6;

        string cb1;
        bool checkB2;

        string cb3;
        bool checkB3;

        bool checkB4;
        bool costCheckBoxTemp;
        bool costRBchargeTemp;
        bool costRBfreeTemp;
        int costSignTempIndex;
        string costTBTemp;
        bool chargeCheck;

        FormResultCallback callback;
        public Form5SQLQuery(FormResultCallback callback, string mainFormQuery)
        {
            InitializeComponent();
            this.callback = callback;
            CurrentSqlQuery = mainFormQuery;
            DateTime nowDT = DateTime.Now;  //первое значение в полях диапазонов это первое января Текущего года
            DateTime dateLeftDefaultInterval = new DateTime(nowDT.Year, 01, 01);
            dateTimePicker2.Value = dateLeftDefaultInterval;
            dateTimePicker5.Value = dateLeftDefaultInterval;
            costSign.Items.AddRange(new string[5] { "     =", "     >", "     >=", "     <", "     <=" });
        }
        BindingSource bs;

        private void Form5SQLQuery_Load(object sender, EventArgs e)
        {
            button2.Enabled = button2Shower;

            string connStr = GlobalSettings.ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                string fillOrg = "Select Название from Организации";
                string fillEmploy = "Select Фамилия from Сотрудники";
                // string fillClient = "Select ClientName from Клиенты";
                string fillDocType = "Select Name from ТипДокумента";

                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                //  DataTable table3 = new DataTable();
                DataTable table4 = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(fillOrg, cn);
                SqlDataAdapter da2 = new SqlDataAdapter(fillEmploy, cn);
                //  SqlDataAdapter da3 = new SqlDataAdapter(fillClient, cn);
                SqlDataAdapter da4 = new SqlDataAdapter(fillDocType, cn);

                da.Fill(table);
                da2.Fill(table2);
                // da3.Fill(table3);
                da4.Fill(table4);
                bs = new BindingSource();
                bs.DataSource = table;
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "Название";
                comboBox1.SelectedIndex = -1;

                comboBox1.GotFocus += new EventHandler(comboBox1_GotFocus);
                comboBox1.LostFocus += new EventHandler(comboBox1_LostFocus);

                comboBox2.DataSource = table2;
                comboBox2.DisplayMember = "Фамилия";
                comboBox2.SelectedIndex = -1;

                comboBox3_FullLoad();

                comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;   //для сотрудников
                comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

                // comboBox3.DataSource = table3;
                // comboBox3.DisplayMember = "ClientName";
                // comboBox3.SelectedIndex = -1;
                comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;

                comboBox4.DataSource = table4;
                comboBox4.DisplayMember = "Name";
                comboBox4.SelectedIndex = -1;
            }
            GetTempData();
        }
        void GetTempData()
        {
            comboBox2.Text = cb2;
            checkBox1.Checked = checkB1;

            comboBox4.SelectedIndex = cb4;
            checkBox6.Checked = checkB6;

            comboBox1.Text = cb1;
            checkBox2.Checked = checkB2;

            comboBox3.Text = cb3;
            checkBox3.Checked = checkB3;

            checkBox4.Checked = checkB4;

            costCheckB.Checked = costCheckBoxTemp;
            costRBcharge.Checked = costRBchargeTemp;
            costRBfree.Checked = costRBfreeTemp;
            costSign.SelectedIndex = costSignTempIndex;
            costTB.Text = costTBTemp;

            dateChargeCheckB.Checked = chargeCheck;
        }
        void SetTempData()
        {
            cb2 = comboBox2.Text;
            checkB1 = checkBox1.Checked;

            cb4 = comboBox4.SelectedIndex;
            checkB6 = checkBox6.Checked;

            cb1 = comboBox1.Text;
            checkB2 = checkBox2.Checked;

            cb3 = comboBox3.Text;
            checkB3 = checkBox3.Checked;

            checkB4 = checkBox4.Checked;

            costCheckBoxTemp = costCheckB.Checked;
            costRBchargeTemp = costRBcharge.Checked;
            costRBfreeTemp = costRBfree.Checked;
            costSignTempIndex = costSign.SelectedIndex;
            costTBTemp = costTB.Text;

            chargeCheck = dateChargeCheckB.Checked;
        }
        void ClearTempData()
        {
            cb2 = string.Empty;
            checkB1 = false;

            cb4 = -1;
            checkB6 = false;

            cb1 = string.Empty;
            checkB2 = false;

            cb3 = string.Empty;
            checkB3 = false;

            checkB4 = false;

            checkBox5.Checked = false;
            DateTime nowDT = DateTime.Now;
            dateTimePicker1.Value = nowDT;
            dateTimePicker2.Value = new DateTime(nowDT.Year, 01, 01);
            dateTimePicker3.Value = nowDT;
            dateTimePicker4.Value = nowDT;
            dateTimePicker5.Value = new DateTime(nowDT.Year, 01, 01);
            dateTimePicker6.Value = nowDT;
            costCheckB.Checked = false;
            chargeCheck = false;
            costCheckBoxTemp = false;
            dateChargeCheckB.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)                   //Кнопка Сформировать
        {
            finalAddString = "";
            SetTempData();

            #region Проверки даты и заполнения
            if (((dateTimePicker2.Value > dateTimePicker3.Value) &&
                (checkBox5.Checked == true)) || (dateTimePicker3.Value > DateTime.Now) || dateTimePicker1.Value > DateTime.Now
                || ((dateTimePicker5.Value > dateTimePicker6.Value) && dateChargeCheckB.Checked))
            {
                MessageBox.Show("Неверно заданы границы диапазона даты", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (((comboBox1.SelectedIndex == -1) && (checkBox2.Checked == true)) ||
                ((comboBox2.SelectedIndex == -1) && (checkBox1.Checked == true)) ||
                 ((comboBox3.SelectedIndex == -1) && (checkBox3.Checked == true)) ||
                  ((comboBox4.SelectedIndex == -1) && (checkBox6.Checked == true)) ||
                   ((textBox1.Text == "") && (checkBox4.Checked == true)) ||
                   ((costCheckB.Checked == true) && (costTB.Text == "")) ||
                   (checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == false) && (checkBox4.Checked == false) && (checkBox5.Checked == false) && (checkBox6.Checked == false) && (costCheckB.Checked == false) && (dateChargeCheckB.Checked == false))

            {
                MessageBox.Show("Выбранные поля не заполнены или заполнены неверно", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region //Алгоритм любимой Валюши
            int iterator = 0;

            string _where = " WHERE ";
            string and_ = " AND ";

            CheckBox[] checkBoxsMass = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, costCheckB, dateChargeCheckB };   //Массив чек боксов

            string cp0 = "Сотрудники.Фамилия = " + "'" + (comboBox2.Text) + "'";
            string cp1 = "Организации.Название = " + "'" + (comboBox1.Text) + "'";
            string cp2 = "Клиенты.ClientName = " + "'" + (comboBox3.Text) + "'";
            string cp3 = "Журнал.Memo LIKE " + "'%" + (textBox1.Text) + "%'";
            string cp4;
            if (radioButton1.Checked == true)
                cp4 = "CAST(Журнал.Date as Date) = " + "'" + (dateTimePicker1.Value.ToString("yyyy-MM-dd")) + "'";
            else
                cp4 = "Журнал.Date > " + "'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'" + " AND Журнал.Date < DATEADD(day, 1," + "'" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "')";
            string cp5 = "ТипДокумента.Name = " + "'" + (comboBox4.Text) + "'";
            string cp6 = "Журнал.Cost " + costSign.Text.Trim() + " " + costTB.Text;
            string cp7;
            if (dateChargeExactDateRadio.Checked)
                cp7 = "DOCUMENTS.CHARGE_DATE = " + "'" + (dateTimePicker4.Value.ToString("yyyy-MM-dd")) + "'";
            else
                cp7 = "DOCUMENTS.CHARGE_DATE > " + "'" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "'" + " AND DOCUMENTS.CHARGE_DATE < DATEADD(day, 1," + "'" + dateTimePicker6.Value.ToString("yyyy-MM-dd") + "')";

            string[] commandPartMass = { cp0, cp1, cp2, cp3, cp4, cp5, cp6, cp7 };

            for (int i = 0; i < commandPartMass.Length; i++)
            {
                if (checkBoxsMass[i].Checked == true)
                {
                    if (iterator == 0)
                    {
                        finalAddString += _where + commandPartMass[i];
                    }
                    if ((iterator > 0) && (iterator < 7))
                    {
                        finalAddString += and_ + commandPartMass[i];
                    }
                    if (iterator == 7)
                        finalAddString += and_ + commandPartMass[i];

                    iterator++;
                }
            }
            #endregion  

            try
            {
                this.newGetDataString = @"SELECT DISTINCT Журнал.ID AS Номер, 
                                            ТипДокумента.Name AS Документ, 
                                            Журнал.Date AS Дата,
                                            Организации.Название As Организация, 
                                            Сотрудники.Фамилия AS Выдал, 
                                            Клиенты.ClientName,
                                            Memo, 
                                            Info_type.in_type,
                                            Cost, 
                                            MapCasesCount, 
                                            RequireConfirmAct,
                                            Журнал.Client_ID
                                      FROM Журнал 
                                            LEFT JOIN DOCUMENTS ON Журнал.ID = DOCUMENTS.FID_JOURNAL
                                            LEFT JOIN Организации ON Журнал.Organ_ID = Организации.ID
                                            LEFT JOIN ТипДокумента ON Журнал.TypeDoc = ТипДокумента.ID
                                            LEFT JOIN Сотрудники ON Журнал.Empl_ID = Сотрудники.ID
                                            LEFT JOIN Клиенты ON Журнал.Client_ID = Клиенты.ID
                                            LEFT JOIN Info_type ON Журнал.in_id = Info_type.ID " + finalAddString +
                                      "ORDER BY Журнал.ID";
                button2Shower = true;
                //DialogResult = DialogResult.OK;
                callback.Invoke(DialogResult.OK);
                // this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректно сформирован запрос. Повторите попытку", "Ошибка формирования запроса");
                // DialogResult = DialogResult.OK;
                goto RepeatEnter;
            }
            Close();
            RepeatEnter:;
        }
        public string CurrentSqlQuery //Это свойство будет доступно из первой Формы
        {
            get { return newGetDataString; }
            set { newGetDataString = value; }
        }

        #region Живой поиск в CB1
        void comboBox1_LostFocus(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = false;
        }
        void comboBox1_GotFocus(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            // comboBox1.DroppedDown = true;
            try
            {
                string filter = comboBox1.Text;
                bs.Filter = "Название LIKE '%" + filter + "%'";
                comboBox1.Text = filter;

                comboBox1.Select(filter.Length, 0);
            }
            catch
            {
                bs.Filter = string.Empty;
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)   //Отобразить полную БД
        {
            finalAddString = "";
            this.newGetDataString = @"SELECT Журнал.ID AS Номер, 
                                            ТипДокумента.Name AS Документ, 
                                            Журнал.Date AS Дата,
                                            Организации.Название As Организация, 
                                            Сотрудники.Фамилия AS Выдал, 
                                            Клиенты.ClientName,
                                            Memo, 
                                            Info_type.in_type,
                                            Cost, 
                                            MapCasesCount, 
                                            RequireConfirmAct,
                                            Журнал.Client_ID 
                                      FROM Журнал 
                                            LEFT JOIN Организации ON Журнал.Organ_ID = Организации.ID
                                            LEFT JOIN ТипДокумента ON Журнал.TypeDoc = ТипДокумента.ID
                                            LEFT JOIN Сотрудники ON Журнал.Empl_ID = Сотрудники.ID
                                            LEFT JOIN Клиенты ON Журнал.Client_ID = Клиенты.ID
                                            LEFT JOIN Info_type ON Журнал.in_id = Info_type.ID
                                      ORDER BY Журнал.ID";
            ClearTempData();
            button2Shower = false;
            callback.Invoke(DialogResult.Ignore);
            this.Close();
        }

        private void comboBox3_Fill()
        {
            string connStr = GlobalSettings.ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                string selectClient = "SELECT ClientName FROM Клиенты WHERE Org_ID = (SELECT MIN(ID) FROM Организации WHERE Организации.Название ='" + comboBox1.Text + "') ORDER BY ID ";

                DataTable ClientNameOfOrg = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(selectClient, cn);

                da.Fill(ClientNameOfOrg);
                comboBox3.DataSource = ClientNameOfOrg;
                comboBox3.DisplayMember = "ClientName";
                comboBox3.SelectedIndex = -1;
            }
        }
        private void comboBox3_FullLoad()
        {
            string reservTextCB3 = comboBox3.Text;  //чтобы не терять значение при отключении Галочки Организации
            string connStr = GlobalSettings.ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                string selectClient = "Select ClientName from Клиенты";

                DataTable ClientNameOfOrg = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(selectClient, cn);

                da.Fill(ClientNameOfOrg);
                comboBox3.DataSource = ClientNameOfOrg;
                comboBox3.DisplayMember = "ClientName";
                comboBox3.SelectedIndex = -1;
                comboBox3.Text = reservTextCB3;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3_Fill();
        }

        #region Вся анимация формы
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                comboBox2.Enabled = true;
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                comboBox1.Enabled = true;
            else
            {
                comboBox3_FullLoad();                  //При выключении галки у Организации загружаются все клиенты.
                comboBox1.Enabled = false;
                comboBox1.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                comboBox3.Enabled = true;
            else
            {
                comboBox3.Enabled = false;
                comboBox3.Text = "";
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                textBox1.Enabled = true;
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                groupBox1.Enabled = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                radioButton1.Checked = true;
            }

            else
            {
                groupBox1.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                // dateTimePicker1.Text = "";
                //dateTimePicker2.Text = "";
                //dateTimePicker3.Text = "";
                radioButton1.Checked = false;
                DateTime nowDT = DateTime.Now;  //первое значение в полях диапазонов это первое января Текущего года
                dateTimePicker1.Value = nowDT;
                DateTime dateTP2 = new DateTime(nowDT.Year, 01, 01);
                dateTimePicker2.Value = dateTP2;
                dateTimePicker3.Value = nowDT;
            }
        }

        private void dateChargeCheckB_CheckedChanged(object sender, EventArgs e)
        {
            if (dateChargeCheckB.Checked == true)
            {
                groupBoxCharge.Enabled = true;
                dateTimePicker4.Enabled = false;
                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
                dateChargeExactDateRadio.Checked = true;
            }
            else
            {
                groupBoxCharge.Enabled = false;
                dateChargeExactDateRadio.Checked = false;
                dateChargeIntervalDateRadio.Checked = false;
                // dateTimePicker1.Text = "";
                //dateTimePicker2.Text = "";
                //dateTimePicker3.Text = "";
                dateChargeExactDateRadio.Checked = false;
                DateTime nowDT = DateTime.Now;  //первое значение в полях диапазонов это первое января Текущего года
                dateTimePicker4.Value = nowDT;
                DateTime dateTP2 = new DateTime(nowDT.Year, 01, 01);
                dateTimePicker5.Value = dateTP2;
                dateTimePicker6.Value = nowDT;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                //dateTimePicker2.Text = "";
                //dateTimePicker3.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                // dateTimePicker1.Text = "";
            }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                comboBox4.Enabled = true;
            else
            {
                comboBox4.SelectedIndex = -1;
                comboBox4.Enabled = false;
            }
        }
        #region Стоимость
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (costCheckB.Checked == true)
            {
                groupBox2.Enabled = true;
                costRBcharge.Checked = true;
                costSign.Enabled = true;
                costTB.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
                costRBcharge.Checked = false;
                costRBfree.Checked = false;
                costSign.SelectedIndex = -1;
                costTB.Text = "";
                //  comboBox5.SelectedIndex = -1;
                costSign.Enabled = false;
                costTB.Enabled = false;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) //платно
        {
            if (costRBcharge.Checked == true)
            {
                costSign.Enabled = true;
                costSign.SelectedIndex = 0;
                costTB.Enabled = true;
                costTB.Text = "";
                costTB.Focus();
                label2.Enabled = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) //бесплатно
        {
            if (costRBfree.Checked == true)
            {
                costSign.Enabled = false;
                costTB.Enabled = false;
                costSign.SelectedIndex = 0;
                costTB.Text = "0";
                label2.Enabled = false;
            }
        }

        #endregion

        #endregion

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void dateChargeExactDateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (dateChargeExactDateRadio.Checked == true)
            {
                dateTimePicker4.Enabled = true;
                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
                //dateTimePicker2.Text = "";
                //dateTimePicker3.Text = "";
            }
        }

        private void dateChargeIntervalDateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (dateChargeIntervalDateRadio.Checked == true)
            {
                dateTimePicker4.Enabled = false;
                dateTimePicker5.Enabled = true;
                dateTimePicker6.Enabled = true;
                // dateTimePicker1.Text = "";
            }
        }
    }
}