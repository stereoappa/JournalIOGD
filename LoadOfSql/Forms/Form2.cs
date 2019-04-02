using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Linq;
using LoadOfSql.Domain;
using LoadOfSql.Infrastructure.DAL;
using LoadOfSql.Infrastructure;
using LoadOfSql.Infrastructure.Controls;
using ApplicationJournal;

namespace LoadOfSql
{
    public delegate void CreateDocsCallback(DialogResult dr, List<Document> docs, int cost);
    public partial class Form2 : Form
    {
        FormResultCallback callback;
        Form12AttachDocuments formCreateDocs;
        List<Document> docsForInsert;
        //CostType costType;
        int lastID;
        int topClientForCurrenOrg;
        DataManager dm = new DataManager();
        BindingSource bs = new BindingSource();
        BindingSource bsClient = new BindingSource();
        IEmployeeService _employeeService;

        public Form2(FormResultCallback callback, IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            this.callback = callback;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            clientsCB.SelectedIndexChanged -= clientsCB_SelectedIndexChanged;
            organizationsCB.SelectedIndexChanged -= organizationsCB_SelectedIndexChanged;  //открепляем обработчик события                              
            organizationsCB.TextChanged -= organizationsCB_TextChanged;
            typeDocCB.SelectedValueChanged -= comboBox2_SelectedValueChanged;

            organizationsCB.FillOrganizations(bs);
            organizationsCB.SelectedIndex = -1;
            typeDocCB.FillTypeDocs();
            typeDocCB.SelectedIndex = -1;
            employCB.FillEmployes();
            employCB.Text = GlobalSettings.LoginUser.SecondName;
            textBox3.Text = DateTime.Now.ToString();

            organizationsCB.GotFocus += new EventHandler(comboBox1_GotFocus);
            organizationsCB.LostFocus += new EventHandler(comboBox1_LostFocus);

            organizationsCB.SelectedIndexChanged += organizationsCB_SelectedIndexChanged;     //снова прикрепляем обработчик                       
            clientsCB.SelectedIndexChanged += clientsCB_SelectedIndexChanged;
            organizationsCB.TextChanged += organizationsCB_TextChanged;
            typeDocCB.SelectedValueChanged += comboBox2_SelectedValueChanged;

            radioButton1.Checked = true;
            //typeDocCB.SelectedIndex = -1;
            //Заполнение Шаблонов
            templateCB.Items.Add("Выкопировка 1:500..");
            templateCB.Items.Add("Ситуационный план 1:2000..");
            templateCB.Items.Add("Выкопировка 1:500.. и ситуац. план 1:2000..");
            templateCB.Items.Add("Возврат исполнительной съемки");
            templateCB.Items.Add("Зарегистрированные материлы");
            templateCB.Items.Add("Возврат инженерно-геодезических изысканий");

        }

        #region Живой поиск в combobox1
        void comboBox1_LostFocus(object sender, EventArgs e)
        {
            organizationsCB.DroppedDown = false;
        }
        void comboBox1_GotFocus(object sender, EventArgs e)
        {
            // comboBox1.Text = "";
            organizationsCB.DroppedDown = true;
        }
        private void organizationsCB_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string filter = organizationsCB.Text;
                bs.Filter = "Название LIKE '%" + filter + "%'";
                organizationsCB.Text = filter;

                organizationsCB.Select(filter.Length, 0);
            }
            catch
            {
                bs.Filter = string.Empty;

            }
        }
        #endregion
        private void SaveItem_Click(object sender, EventArgs e)
        {
            #region Проверки заполнения
            if (((radioButton1.Checked == false) && (radioButton2.Checked == false)) || ((organizationsCB.Text == "") || organizationsCB.Text == "Начните вводить имя организации") || ((checkBox1.Checked == false) && (checkBox2.Checked == false)) || (clientsCB.Text == "") || (costTB.Text == "") || (memoTB.Text == ""))
            {
                MessageBox.Show("Не все поля формы заполнены. \nВнесите всю необходимую информацию и повторите попытку.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
                return;
            }

            if (((organizationsCB.SelectedIndex == -1) && (organizationsCB.Text != "Частное лицо")) || (clientsCB.SelectedIndex == -1))
            {
                MessageBox.Show("Выбран несуществующий клиент или организация. Проверьте правильность ввода.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
                return;
            }

            //if (dateTimePicker1.Value > DateTime.Now)
            //{
            //    MessageBox.Show("Дата документа задана не верно.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (typeDocCB.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран тип документа.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int chBoxIndx = 1;

            if ((checkBox1.Checked == true) && (checkBox2.Checked == false))
                chBoxIndx = 2;
            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
                chBoxIndx = 3;
            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
                chBoxIndx = 4;
            string chBoxIndxStr = Convert.ToString(chBoxIndx);
            if (memoTB.Text.Length > 4000)
            {
                if (MessageBox.Show("Слишком большой объем поля описания.\n\nСохранить введенное значение?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
            }
            #endregion
            SaveItem.Enabled = false;
            Cursor = Cursors.AppStarting;
            //Подготавливаем переменые даты для передачи на sql server
            DateTime dateNow = Convert.ToDateTime(textBox3.Text);

            //Отправляем текст на Regex-анализ, чтобы узнать количество выданных планшетов
            int mapCasesCount = RegexAnalys.MapCasesCount(memoTB.Text);

            var cn = dm.DBConnection;
            SqlCommand command = cn.CreateCommand();

            //Добавление новой строки со случайными значениями. 
            //Подготавливаем значения
            //'04-02-2017' формат передаваемой в sql даты
            //SqlCommand orgIndex = cn.CreateCommand();

            int orgId = dm.FindFirstOrganizationId(organizationsCB.Text);
            int clientId = (int)clientsCB.SelectedValue;
            //MessageBox.Show(clientsCB.SelectedValue.ToString());
            command.CommandText = "INSERT INTO Журнал (TypeDoc, Date, Memo, Organ_ID, Empl_ID, Client_ID, in_id, Cost, mapCasesCount, RequireConfirmAct) VALUES ('" + (typeDocCB.SelectedIndex + 1) + "', '" + dateNow.ToString("yyyy - MM - dd HH:mm:ss") + "' , '" + memoTB.Text + "', '" + orgId + "', '" + (employCB.SelectedIndex + 1) + "', '" + clientId + "', '" + chBoxIndxStr + "', '" + Convert.ToInt32(costTB.Text) + "', '" + mapCasesCount + "', '" + mapCasesCount + "')";

            #region ==========СОЗДАЕМ БАЗОВОГО КЛИЕНТА============
            SqlCommand baseClient = cn.CreateCommand();
            if (topClientCheckB.Checked == true)
            {
                baseClient.CommandText = "UPDATE Организации SET ОсновнойКлиент =" + clientId + " WHERE Организации.ID = " + orgId;
                try
                {
                    baseClient.Transaction = cn.BeginTransaction(IsolationLevel.Serializable);
                    baseClient.ExecuteNonQuery();
                    baseClient.Transaction.Commit();
                }
                catch
                {
                    baseClient.Transaction.Rollback();
                    MessageBox.Show("Данный клиент не был назначен основным", "Ошибка при изменении статуса клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            //========================COMMIT==============================
            try
            {
                command.Transaction = cn.BeginTransaction(IsolationLevel.Serializable);
                command.ExecuteNonQuery();
                command.Transaction.Commit();

                lastID = Convert.ToInt32(SqlQueryBuilder.LastId(cn).ExecuteScalar());

                // Вставка документов в БД  
                if (docsForInsert != null)
                {
                    docsForInsert.ForEach(x => x.FidJournal = lastID);
                    //docsForInsert.ForEach(x => x.Type = (DocType)comboBox2.SelectedIndex + 1);
                }
                //else if (comboBox2.Text == "Обращение")
                //{
                //    docsForInsert = new List<Document>();
                //    docsForInsert.Add(new Document((DocType)comboBox2.SelectedIndex + 1)
                //    {
                //        FidJournal = lastID,
                //        TicketNumber = textBox1.Text,
                //        TicketDate = dateTimePicker1.Value,
                //        NumRazresh = null,
                //        DateRazresh = null,
                //        //Type = (DocType)comboBox2.SelectedIndex + 1
                //    });
                //}
                bool isAdded = dm.CreateDocuments(docsForInsert);
                DialogResult = DialogResult.OK;
            }
            catch
            {
                command.Transaction.Rollback();

                DialogResult = DialogResult.Abort;
                MessageBox.Show("Транзакция отменена. Данные не добавлены в базу данных. \nОбратитесь к администратору.", "Системный сбой", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }


            //В таблицу Организации в поле количество прибавляем выданные планшеты
            if (mapCasesCount > 0)
            {
                MapCasesManager.SetDBMapCasesSumm(organizationsCB.Text, mapCasesCount);
            }

            int allMapCases = MapCasesManager.GetMapCasesSum(organizationsCB.Text);
            if (allMapCases >= 200)
            {
                MessageBox.Show(String.Format("Количество планшетов, выданных организации {0} составляет {1}.\nНеобходимо получить от организации акты об удалении, после чего изменить сумму в таблице Выданные планшеты\n(Данные - Выданные планшеты).", organizationsCB.Text, allMapCases), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (checkBox3.Checked == true)
            {
                try
                {
                    PrintingManager.Print(lastID,
                                          Convert.ToDateTime(textBox3.Text),
                                          docsForInsert ?? new List<Document> (),
                                          organizationsCB.Text,
                                          dm.GetClientName(Convert.ToInt32(clientsCB.SelectedValue)),
                                          clientsCB.Text,
                                          costTB.Text,
                                          memoTB.Text,
                                          GetInfoType(),                                          
                                          employCB.Text,
                                          _employeeService.GetActiveSign(),
                                          entryType: typeDocCB.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            Close();
            callback.Invoke(DialogResult);
            RepeatEnter: Cursor = Cursors.Default; SaveItem.Enabled = true;
        }
        string GetInfoType()
        {
            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
                return "На электронном и бумажном носителе";
            if ((checkBox1.Checked == true) && (checkBox2.Checked == false))
                return "В электронном виде";
            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
                return "На бумажном носителе";

            return "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                organizationsCB.SelectedIndexChanged -= organizationsCB_SelectedIndexChanged;
                clientsCB.SelectedIndexChanged -= clientsCB_SelectedIndexChanged;
                bs.Filter = string.Empty;
                organizationsCB.SelectedIndex = -1;
                organizationsCB.SelectedIndexChanged += organizationsCB_SelectedIndexChanged;

                organizationsCB.Text = "Начните вводить имя организации";

                if (organizationsCB.SelectedIndex == -1)
                {
                    clientsCB.Enabled = false;
                    //clientsCB.DataSource = null;
                    clientsCB.SelectedIndex = -1;
                    clientsCB.DataSource = null;
                    //clientsCB.Text = "";
                    topClientCheckB.Enabled = false;
                }
                clientsCB.DropDownStyle = ComboBoxStyle.DropDownList;
                clientsCB.SelectedIndexChanged += clientsCB_SelectedIndexChanged;
                organizationsCB.Enabled = true;
                button1.Enabled = false;

                // comboBox1.SelectedIndex = -1;                                                                                           
                // comboBox1.Font = new Font (comboBox1.Font, comboBox1.Font.Style | FontStyle.Italic); 
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // organizationsCB.SelectedIndexChanged -= organizationsCB_SelectedIndexChanged;
                // organizationsCB.Text = "Частное лицо";
                try
                {
                    int idPrivatePerson = dm.FindFirstOrganizationId("Частное лицо");
                    clientsCB.SelectedIndexChanged -= clientsCB_SelectedIndexChanged;
                    organizationsCB.SelectedIndexChanged -= organizationsCB_SelectedIndexChanged;

                    //clientsCB.SelectedIndex = -1;

                    clientsCB.DropDownStyle = ComboBoxStyle.DropDown;
                    clientsCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    clientsCB.AutoCompleteSource = AutoCompleteSource.ListItems;
                    clientsCB.FillClients(bsClient, idPrivatePerson, false);
                    clientsCB.SelectedIndex = -1;

                    bs.Filter = string.Empty;
                    organizationsCB.SelectedValue = idPrivatePerson;
                    clientsCB.SelectedIndexChanged += clientsCB_SelectedIndexChanged;
                    organizationsCB.SelectedIndexChanged += organizationsCB_SelectedIndexChanged;


                    organizationsCB.Enabled = false;
                    clientsCB.Enabled = true;
                    button1.Enabled = true;
                    topClientForCurrenOrg = -1;
                    topClientCheckB.Checked = false;
                    topClientCheckB.Enabled = false;
                    //clientsCB.GetTopClient(organizationsCB.Text, topClientCheckB);                    
                }
                catch (Exception ex) { throw ex; }
            }
        }
        void AttachDocuments(DocType type)
        {
            //TODO: Тут должен быть проверка на смену ранее прикрепленных документов
            if (docsForInsert != null)
                docsForInsert.Clear();
            formCreateDocs = new Form12AttachDocuments(new CreateDocsCallback(ReadAttachDocsCallback), type);
            try
            {
                formCreateDocs.ShowDialog();
                //linkLabel1.Sho
                //label6.Visible = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Форма не смогла создать документы, возможно были введены некорректные данные" + exc.Message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        DocType curDocType;
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((typeDocCB.Text == "Разрешение") || (typeDocCB.SelectedIndex == 0))
            {
                curDocType = DocType.Permission;
                AttachDocuments(curDocType);
            }

            if ((typeDocCB.Text == "Обращение") || (typeDocCB.SelectedIndex == 1))
            {
                curDocType = DocType.Ticket;
                AttachDocuments(curDocType);
            }

            else if ((typeDocCB.Text == "Нет") || (typeDocCB.SelectedIndex == 2))
            {
                docsForInsert = null;
                linkLabel1.HideDefinition();
                linkLabel1.Text = "";
                label6.Visible = false;

                label7.Visible = false;
                label9.Visible = false;
                costTB.Visible = false;
                costTB.Text = "0";
                curDocType = DocType.Not;

                //costCB.SelectedIndex = 1; //При типе "Нет" никогда нет Стоимости
                //costCB.Enabled = false;
                // textBox1.Text = null;
                // textBox1.Enabled = false;
                // dateTimePicker1.Value = new DateTime(2000, 01, 01);
                // dateTimePicker1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flagEntryCombobox = false;
            for (int i = 0; i < clientsCB.Items.Count; i++)
            {
                flagEntryCombobox = (clientsCB.Text == clientsCB.Items[i].ToString()) ? true : false;
                if (flagEntryCombobox == true)
                { break; }
            }

            if ((flagEntryCombobox == true) || (clientsCB.SelectedIndex == -1))
            {
                Form4NewOrgOrClient newClientForm = new Form4NewOrgOrClient((int)organizationsCB.SelectedValue, clientsCB.Text);
                newClientForm.FormClosed += new FormClosedEventHandler(newClientForm_FormClosed);   //Прикрепляем событие 
                newClientForm.ShowDialog();
            }
            else
            {
                Form4NewOrgOrClient newClientForm = new Form4NewOrgOrClient((int)organizationsCB.SelectedValue, "");
                newClientForm.FormClosed += new FormClosedEventHandler(newClientForm_FormClosed);   //Прикрепляем событие 
                newClientForm.ShowDialog();
            }
        }
        void newClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, false);
            clientsCB.SelectedIndex = clientsCB.Items.Count - 1;     //Выбираем в комбобоксе добавленного клиента TODO Есть сомнения что эта строка всегда будет отрабатывать верно        
        }

        int tempClientIndex;
        private void editClientBtn_Click(object sender, EventArgs e)
        {
            if (clientsCB.SelectedIndex == -1 | clientsCB.SelectedValue == null | organizationsCB.SelectedValue == null)
                return;
            Form4NewOrgOrClient editClientForm = new Form4NewOrgOrClient((int)clientsCB.SelectedValue);
            editClientForm.FormClosed += new FormClosedEventHandler(editClientForm_FormClosed);
            tempClientIndex = clientsCB.SelectedIndex;
            editClientForm.ShowDialog();
        }
        private void editClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, false);
            clientsCB.SelectedIndex = tempClientIndex;
        }


        private void organizationsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (organizationsCB.SelectedIndex == -1)
            //{
            //    clientsCB.Enabled = false;
            //    button1.Enabled = false;
            //    topClientCheckB.Enabled = false;
            //    return;
            //}

            clientsCB.Enabled = true;     // отключение кнопки и списка клиентов при введении некорректной организации
            button1.Enabled = true;

            topClientForCurrenOrg = clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, true);
            if (topClientForCurrenOrg != -1)
                clientsCB.SelectedValue = topClientForCurrenOrg;

            if (clientsCB.SelectedIndex != -1)
                CheckBoxTopClientVisualise(topClientForCurrenOrg);
            else
            {
                topClientCheckB.Checked = false;
                topClientCheckB.Enabled = false;
            }
        }
        void CheckBoxTopClientVisualise(int clientId)
        {
            if (clientId == -1)
            {
                topClientCheckB.Checked = false;
                topClientCheckB.Enabled = true;
                return;
            }
            //if (organizationsCB.Text == "Частное лицо" || string.IsNullOrEmpty(organizationsCB.Text))
            //{
            //    topClientForCurrenOrg = -1;
            //    topClientCheckB.Checked = false;
            //    topClientCheckB.Enabled = false;
            //    return;
            //}
            if (clientId == topClientForCurrenOrg)
            {
                //clientsCB.SelectedValue = topClientForCurrenOrg;
                topClientCheckB.Checked = true;
                topClientCheckB.Enabled = false;
            }
            else
            {
                topClientCheckB.Checked = false;
                topClientCheckB.Enabled = true;
            }
        }

        private void organizationsCB_TextChanged(object sender, EventArgs e)       //Здесь анимация кнопки добавить и активация              
        {
            if (organizationsCB.Text == "")
            {
                clientsCB.SelectedIndex = -1;
                clientsCB.Enabled = false;
                button1.Enabled = false;
            }
        }

        #region ========Логика отображения контролов===============
        private void templateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (templateCB.SelectedIndex == 0)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Выкопировка топографической съемки масштаба 1:500" + Environment.NewLine + "формата А4-1 лист" + Environment.NewLine + "по адресу: ";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
            if (templateCB.SelectedIndex == 1)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Ситуационный план масштаба 1:2000" + Environment.NewLine + "формата А4-1лист" + Environment.NewLine + "по адресу: ";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
            if (templateCB.SelectedIndex == 2)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Выкопировка топографической съемки масштаба 1:500" + Environment.NewLine + "формата А4-1 лист и ситуационный план масштаба 1:2000" + Environment.NewLine + "формата А4-1лист" + Environment.NewLine + "по адресу: ";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
            //Статусы
            if (templateCB.SelectedIndex == 3)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Возврат исполнительной съемки" + Environment.NewLine + "по адресу: ";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
            if (templateCB.SelectedIndex == 4)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Зарегистрированные материалы инженерно-геодезических изысканий, выданных по разрешению-заявлению №";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
            if (templateCB.SelectedIndex == 5)
            {
                if (memoTB.Text != string.Empty)
                    memoTB.Text += Environment.NewLine;
                memoTB.Text += "Возврат материалов инженерно-геодезических изысканий, выданных по разрешению-заявлению №";
                memoTB.Focus();
                memoTB.SelectionStart = memoTB.Text.Length;
            }
        }

        private void templateCheckB_CheckedChanged(object sender, EventArgs e)
        {
            if (templateCheckB.Checked == false)
            {
                templateCB.Enabled = false;
                templateCB.SelectedIndex = -1;
            }
            else
                templateCB.Enabled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        //При изменении имени клиента будем проверять является ли он основным или нет
        private void clientsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                CheckBoxTopClientVisualise((int)clientsCB.SelectedValue);
        }
        #endregion

        #region ==============Форма CreateDocuments================
        private void ReadAttachDocsCallback(DialogResult dr, List<Document> docs, int cost)
        {
            if (dr == DialogResult.OK && docs != null)
            {
                docsForInsert = docs;

                linkLabel1.SetLingvaDefinitionFor(docs);
                label6.Visible = true;
                costTB.Text = cost.ToString();
                label7.Visible = true;
                label9.Visible = true;
                costTB.Visible = true;
            }
            else
                docs = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                formCreateDocs.ShowDialog();
            }
            catch (Exception exc) { MessageBox.Show("Форма не смогла создать документы, возможно были введены некорректные данные" + exc.Message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
        #endregion

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            dm.Dispose();
        }
    }
}
