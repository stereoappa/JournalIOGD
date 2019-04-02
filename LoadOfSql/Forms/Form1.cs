using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using LoadOfSql.Infrastructure.DAL;
using System.Collections;
using System.Collections.Generic;
using LoadOfSql.Domain;
using LoadOfSql.Infrastructure;
using LoadOfSql.Infrastructure.Controls;
using System.Threading;
using ApplicationJournal;
using System.IO;
using System.Threading.Tasks;
using DomainModel.Entities;
using LoadOfSql.Forms;
using DomainModel.Repositories;

namespace LoadOfSql
{
    public delegate void FormResultCallback(DialogResult dr);
    public partial class Form1 : Form
    {
        readonly string baseQuery = @"SELECT Журнал.ID AS Номер, 
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
        readonly string docQuery = @"SELECT [ID_DOCUMENT],[FID_JOURNAL],[FID_TYPE_DOC],[NUM_RAZRESH],[DATE_RAZRESH],[TICKET_NUMBER],[TICKET_DATE],[CHARGE_DATE] FROM DOCUMENTS";
        List<string> clmnNames;

        DataManager dm;
        DataTable mainTable, docTable;
        Form5SQLQuery sqlForm;
        int currentID;
        List<string> blankRows;
        bool sqlQueryIsFormed;
        IEmployeeService _employeeService;
        IUserService _userService;
        ITemplateRepository _templateRepository;

        public Form1(IUserService userService, IEmployeeService employeeService, ITemplateRepository templateRepository)
        {
            InitializeComponent();
            _userService = userService;
            _employeeService = employeeService;
            _templateRepository = templateRepository;
            //var records = _recordService.GetPageRecords();

            GlobalSettings.ReadRegistryKeys();
            dm = new DataManager();
            sqlForm = new Form5SQLQuery(new FormResultCallback(sqlFormClosed), baseQuery);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Логин
            Employee employee = _userService.TryAuthorizeFromRegister();
            if (employee == null)
                employee = GetEmployeeByLoginAndPassword();

            GlobalSettings.LoginUser = employee;

            if (GlobalSettings.LoginUser != null)
            {
                this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
                toolStripStatusLabel1.Text = "Вход выполнен: " + GlobalSettings.LoginUser.ShortName;
            }
            else
            {
                toolStripStatusLabel1.Text = "Вход не выполнен, пожалуйста авторизируйтесь.";
                this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Tomato;
                BtnCreateItem.Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                contextMenuStrip1.Items[4].Enabled = false;
                добавитьОрганизациюToolStripMenuItem.Enabled = false;
                выданныеПланшетыToolStripMenuItem.Enabled = false;
                переименоватьОрганизациюToolStripMenuItem.Enabled = false;
                сотрудникиИПодписиToolStripMenuItem.Enabled = false;
            }
            #endregion

            подписьНаДокументахToolStripMenuItem.DropDownItems.Clear();
            Task.Factory.StartNew(GetAllSignsToolStripItems);

            #region Получаем таблицы данных
            dataGridView1.CurrentCellChanged -= dataGridView1_CurrentCellChanged;

            dataGridView1.DataSource = bindingSource1;

            LoadTables(sqlForm.CurrentSqlQuery, docQuery);
            SaveColumnNames();

            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;

            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
            toolStripStatusLabel4.Text = "Все записи";

            dataGridView1.Columns[5].Visible = false;  //ClientName, делаем невидимыми столбцы с данными, которые отображаются в лейблах 
            dataGridView1.Columns[6].Visible = false;  //Memo
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            #endregion

            GoLustNumber();

            dataGridView1.SortedOff();
        }

        Employee GetEmployeeByLoginAndPassword()
        {
            Employee employee = null;
            Form7UserLogin userLogin = new Form7UserLogin(_userService, e => employee = e);
            userLogin.ShowDialog();

            return employee;
        }

        #region Подписи на документах
        private void GetAllSignsToolStripItems()
        {
            var signs = _employeeService.GetSigns();
            foreach (var s in signs)
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem(s.Owner.ShortName);
                tsm.Checked = s.IsActive;
                tsm.Tag = s;
                tsm.Click += ChangeSign_Click;
                AddToolStripSign(tsm);
                //подписьНаДокументахToolStripMenuItem.DropDownItems.Add(tsm);
            }

            //add below separator
            MethodInvoker addSeparatorMethod = () => { подписьНаДокументахToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator()); };
            if (menuStrip1.InvokeRequired)
            {
                BeginInvoke(addSeparatorMethod);
            }
            else
            {
                addSeparatorMethod.Invoke();
            }


               // подписьНаДокументахToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

        }

        void AddToolStripSign(ToolStripItem tsm)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ToolStripItem>(AddToolStripSign), new object[] { tsm });
                return;
            }
            подписьНаДокументахToolStripMenuItem.DropDownItems.Add(tsm);
        }

        private void подписьНаДокументахToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            подписьНаДокументахToolStripMenuItem.DropDownItems.Clear();
            AddToolStripSign(new ToolStripSeparator());
            Task.Factory.StartNew(GetAllSignsToolStripItems);
            //Sign sign = _employeeService.GetActiveSign();

            //var tsmItem = (sender as ToolStripMenuItem);
            //var toolStripSigns = tsmItem.DropDownItems;
            //foreach (var s in toolStripSigns)
            //{
            //    var signTool = ((s as ToolStripMenuItem).Tag as Sign);
            //    if (sign.Id == signTool.Id)
            //    {
            //        (s as ToolStripMenuItem).Checked = sign.IsActive;
            //        return;
            //    }
            //    else
            //    {
            //        (s as ToolStripMenuItem).Checked = false;
            //    }
            //}
        }

        private void ChangeSign_Click(object sender, EventArgs e)
        {
            //foreach (var s in подписьНаДокументахToolStripMenuItem.DropDownItems)
            //{
            //    var signItem = (s as ToolStripMenuItem);
            //    if (signItem != null && signItem.Tag is Sign)
            //        signItem.Checked = false;
            //}
            var tsm = (sender as ToolStripMenuItem);
            var activeSign = tsm.Tag as Sign;
            if (activeSign == null)
                MessageBox.Show("Ошибка смены подписи. Обратитесь к администратору", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            activeSign.IsActive = true;

            _employeeService.SetActiveSign(activeSign);
        }
        #endregion

        void LoadTables(string mainQuery, string documentsQuery)
        {
            mainTable = dm.GetData(mainQuery);
            bindingSource1.DataSource = mainTable;

            docTable = dm.GetData(documentsQuery);
            docsBindingSource.DataSource = docTable;

            DisplayRowCount();

            blankRows = dm.GetBlankRows();
            toolStripStatusLabel5.ShowAttention(blankRows, attensionInfoLabel);
        }
        void SaveColumnNames()
        {
            clmnNames = new List<string>();
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                clmnNames.Add(item.Name);
            }
        }
        void DisplayRowCount()
        {
            toolStripStatusLabel2.Text = "Отображено: " + dataGridView1?.Rows?.Count.ToString();
        }
        private void BtnCreateItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 addForm = new Form2(new FormResultCallback(FormClosedCallback), _employeeService);
                if (addForm.ShowDialog() == DialogResult.OK)
                    GoLustNumber();
            }
            catch (Exception ex) { MessageBox.Show("Форма вернула недопустимое значение. " + ex.Message, "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            LabelFiling();
        }
        private void LabelFiling()
        {
            DisplayRowCount();

            if (dataGridView1.CurrentRow != null)
            {
                currentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                DocsLabelFilling();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "")
                    ClientName.Text = "Нет данных";
                else
                    ClientName.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                InfoType.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                if (dataGridView1.CurrentRow.Cells[clmnNames[8]].Value.ToString() != "0")
                {
                    label6.Visible = true;
                    label6.Text = "Стоимость: " + dataGridView1.CurrentRow.Cells[clmnNames[8]].Value.ToString() + " руб.";
                }
                if (dataGridView1.CurrentRow.Cells[clmnNames[8]].Value.ToString() == "0")
                {
                    label6.Visible = true;
                    label6.Text = "Стоимость: бесплатно";
                }
                if (dataGridView1.CurrentRow.Cells[clmnNames[8]].Value == DBNull.Value)
                {
                    label6.Text = "";
                    label6.Visible = false;
                }

                if ((dataGridView1.CurrentRow.Cells[clmnNames[9]].Value.ToString() != "") ||
                            (dataGridView1.CurrentRow.Cells[clmnNames[9]].Value != DBNull.Value))
                    label7.Text = "Выдано планшетов: " + dataGridView1.CurrentRow.Cells[clmnNames[9]].Value.ToString();
                else
                    label7.Text = "Выдано планшетов: нет\nданных";

                if ((dataGridView1.CurrentRow.Cells[clmnNames[9]].Value != DBNull.Value)
                    && (dataGridView1.CurrentRow.Cells[clmnNames[10]].Value != DBNull.Value)
                    && (dataGridView1.CurrentRow.Cells[3].Value.ToString() != "Частное лицо")
                    && (Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[9]].Value)) != 0)
                {
                    linkLabel1.Visible = true;
                    label8.Visible = true;
                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[10]].Value) == 0)
                        linkLabel1.Text = "Сданы";
                    else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[10]].Value) == Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[9]].Value))
                        linkLabel1.Text = "Не сданы";
                    else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[9]].Value) - Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[10]].Value) > 0)
                        linkLabel1.Text = String.Format("{0} из {1}", Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[9]].Value) - Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[10]].Value),
                                                                      dataGridView1.CurrentRow.Cells[clmnNames[9]].Value);
                }
                else
                {
                    label8.Visible = false;
                    linkLabel1.Visible = false;
                }
            }
        }
        private List<Document> GetDocsById(int id)
        {
            if (dataGridView1.CurrentRow == null)
                return null;

            docsBindingSource.Filter = "FID_JOURNAL = " + id;

            List<Document> docs = new List<Document>();
            DataView dataView = (DataView)docsBindingSource.List.SyncRoot;
            foreach (DataRowView rowView in dataView)
            {
                var clmns = rowView.Row.ItemArray;

                docs.Add(new Document((DocType)clmns[2])
                {
                    FidJournal = (int)clmns[1],
                    //Type = (DocType)clmns[2],
                    NumRazresh = clmns[3] == DBNull.Value ? null : clmns[3].ToString(),
                    DateRazresh = clmns[4] == DBNull.Value ? null : (Nullable<DateTime>)Convert.ToDateTime(clmns[4]),
                    TicketNumber = clmns[5] == DBNull.Value ? null : clmns[5].ToString(),
                    TicketDate = clmns[6] == DBNull.Value ? null : (Nullable<DateTime>)Convert.ToDateTime(clmns[6]),
                    ChargeDate = clmns[7] == DBNull.Value ? null : (Nullable<DateTime>)Convert.ToDateTime(clmns[7])
                });
            }
            return docs;
        }
        private void DocsLabelFilling()
        {
            DocNumsLabel.Text = "";
            //DocNumsLabel.Visible = false;

            List<Document> docs = GetDocsById(currentID);

            if (docs == null)
                return;
            if (docs.Count == 0)
            {
                DocNumsLabel.Text = "/Нет документов/";
                //DocNumsLabel.Visible = true;
                return;
            }

            DocNumsLabel.Text = "№ ";
            foreach (Document doc in docs)
            {
                if (doc.NumRazresh != null & doc.NumRazresh != ""
                    & doc.Type == DocType.Permission)
                {
                    DocNumsLabel.Text += doc.NumRazresh + "; ";
                    // DocNumsLabel.Visible = true;
                }

                if (doc.TicketNumber != null & doc.TicketNumber != ""
                    & doc.Type == DocType.Ticket)
                {
                    string ticketDate = doc.TicketDate.HasValue ? doc.TicketDate.Value.ToShortDateString() : "/Без даты/";
                    DocNumsLabel.Text += doc.TicketNumber + " от " + ticketDate + ";" + Environment.NewLine;
                    // DocNumsLabel.Visible = true;
                }

                if (doc.Type == DocType.Not)
                    DocNumsLabel.Text = "Ошибка: неверный тип документа";
            }
        }

        #region====================Перейти по номеру=======================
        private void goToNumberBtn_Click(object sender, EventArgs e)
        {
            if ((textBox2.Visible == true) && ((textBox2.Text == null) || (textBox2.Text == "")))
            {
                // MessageBox.Show("Ничего не найдено. Введите номер строки в поле для поиска.");
                textBox2.Visible = false;
                label5.Visible = false;
            }
            else
            {
                textBox2.Visible = true;
                label5.Visible = true;
            }

            if ((textBox2.Text != null) && (textBox2.Text != ""))
                goToNumber(Convert.ToInt32(textBox2.Text));
            //goToNumber((int)dataGridView1.CurrentRow.Cells[0].Value);       //todo: при нажатии на кнопку должно переходить по введенному в полю значению
        }

        private void GoLustNumber()
        {
            try
            {
                goToNumber((int)dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value);
            }
            catch
            {
                textBox1.Text = ""; ClientName.Text = ""; InfoType.Text = ""; DocNumsLabel.Text = ""; label6.Text = "";
                label7.Text = ""; label8.Visible = false; linkLabel1.Text = "";
                MessageBox.Show("Не найдено ни одной записи", "Информация", MessageBoxButtons.OK);
            }
        }
        public void goToNumber(int strNumber)                             //Функция, ищущая строку в таблице
        {
            bindingSource1.Position = bindingSource1.Find("Номер", strNumber);
        }

        int strNumber;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int lastId;
                    int.TryParse(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value.ToString(), out lastId);

                    if ((textBox2.Text == null) || (textBox2.Text == "") || (Convert.ToInt32(textBox2.Text) >= (int)dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value))
                        strNumber = (int)dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value; //Если в строке пусто или слишком большое число, то выбираем последнюю запись.
                    else
                        strNumber = Convert.ToInt32(textBox2.Text);

                    goToNumber(strNumber);
                }
            }
            catch { }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  // В поле поиска вводятся только цифры
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }
        #endregion

        #region ============== Контекстное меню dataGridView ================
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)     //выпадание контекстного меню
        {
            if (e.ColumnIndex < dataGridView1.ColumnCount && e.ColumnIndex >= 0 && e.RowIndex < dataGridView1.RowCount && e.RowIndex >= 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var attachDocs = GetDocsById(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                var editDialog = new Form3Editing((dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row, attachDocs, new FormResultCallback(FormClosedCallback));
                editDialog.FormClosed += new FormClosedEventHandler(editDialog_FormClosed);
                editDialog.ShowDialog();
            }
        }
        void editDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            LabelFiling();
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if ((dataGridView1.CurrentRow.Cells[clmnNames[10]].Value != DBNull.Value)/* && (itAct == false)*/)
                {
                    int minus = Convert.ToInt32(dataGridView1.CurrentRow.Cells[clmnNames[10]].Value);
                    MapCasesManager.SetDBMapCasesSumm(dataGridView1.CurrentRow.Cells[3].Value.ToString(), (-minus));
                }

                // И удаляем строку
                bool deleteDocsSucseed = dm.DeleteDocsForId(currentID);
                if (deleteDocsSucseed)
                {
                    DataRow rowToDelete = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                    RowEdit.DeleteRow(rowToDelete);
                    rowToDelete.Delete();
                    LoadTables(sqlForm.CurrentSqlQuery, docQuery);
                }
            }
        }

        #endregion

        #region====================ЗАПРОС======================

        private void button1_Click(object sender, EventArgs e)
        {
            sqlForm.ShowDialog();
        }
        void sqlFormClosed(DialogResult dr)
        {
            if (dr == DialogResult.OK)
            {
                this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Tomato;
                toolStripStatusLabel4.Text = "Сформирован";
                sqlQueryIsFormed = true;
            }
            else
            {
                this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Black;
                toolStripStatusLabel4.Text = "Все записи";
                sqlQueryIsFormed = false;
            }

            dataGridView1.CurrentCellChanged -= dataGridView1_CurrentCellChanged;        //метод get класса Form5SQLQuery Возвращает значение  свойства SqlQueryForForm1            
            LoadTables(sqlForm.CurrentSqlQuery, docQuery);
            GoLustNumber();
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;        //Вызваем из Form1 метод GetData с новой строкой запроса

            LabelFiling();
        }
        #endregion

        #region ======================МЕНЮ=========================
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6Settings f6 = new Form6Settings();
            f6.ShowDialog();
        }
        private void выданныеПланшетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8GetMapCases form8getMapsCases = new Form8GetMapCases(new FormResultCallback(FormClosedCallback));
            form8getMapsCases.ShowDialog();
        }
        private void полученнаяПрибыльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10GotProfit form10profit = new Form10GotProfit();
            form10profit.Show();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15EmployeesAndSigns emplForm = new Form15EmployeesAndSigns(_employeeService);
            emplForm.ShowDialog();
        }

        private void загрузитьШаблонОВыдачеИнформацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            
            //fileDialog.FileName
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7UserLogin f7 = new Form7UserLogin(_userService, em => GlobalSettings.LoginUser = em);
            if (f7.ShowDialog() == DialogResult.OK)
            {
                this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
                toolStripStatusLabel1.Text = "Вход выполнен: " + GlobalSettings.LoginUser.ShortName;
                BtnCreateItem.Enabled = true;
                // contextMenuStrip1.Enabled = true;
                contextMenuStrip1.Items[3].Enabled = true;
                contextMenuStrip1.Items[4].Enabled = true;
                добавитьОрганизациюToolStripMenuItem.Enabled = true;
                выданныеПланшетыToolStripMenuItem.Enabled = true;
                переименоватьОрганизациюToolStripMenuItem.Enabled = true;
                сотрудникиИПодписиToolStripMenuItem.Enabled = true;
            }
        }
        private void добавитьОрганизациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4NewOrgOrClient newOrgForm = new Form4NewOrgOrClient();
            newOrgForm.ShowDialog();
        }
        private void переименоватьОрганизациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11RenameOrganization formRenameOrg = new Form11RenameOrganization(new FormResultCallback(FormClosedCallback));
            formRenameOrg.ShowDialog();
        }
        void FormClosedCallback(DialogResult dr)
        {
            if (dr == DialogResult.OK)
            {
                try
                {
                    dataGridView1.CurrentCellChanged -= dataGridView1_CurrentCellChanged;
                    LoadTables(sqlForm.CurrentSqlQuery, docQuery);
                    LabelFiling();
                    dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Системная ошибка", "Невозможно обновить таблицу.\nОшибка в callback-функции " + e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region==========ВЫВЕСТИ В WORD И НА ПЕЧАТЬ===============

        private void ВдокументMSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintingManager.ExportToWord(currentID,
                                      Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value),
                                      GetDocsById(currentID),
                                      dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                                      ClientName.Text,
                                      dm.GetIdentityClientName(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Client_ID"].Value)) ?? ClientName.Text,
                                      label6.Text.Replace("Стоимость: ", "").Replace("руб.", "").Trim(),
                                      textBox1.Text,
                                      InfoType.Text,
                                      dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                                      _employeeService.GetActiveSign(),
                                      entryType: dataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintingManager.Print(currentID,
                                Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value),
                                GetDocsById(currentID),
                                dataGridView1.CurrentRow?.Cells[3].Value.ToString(),
                                ClientName.Text,
                                dm.GetIdentityClientName(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Client_ID"].Value)) ?? ClientName.Text,
                                label6.Text.Replace("Стоимость: ", "").Replace("руб.", "").Trim(),
                                textBox1.Text,
                                InfoType.Text,
                                dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                                _employeeService.GetActiveSign(),
                                entryType: dataGridView1.CurrentRow?.Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form8GetMapCases form8nameSelect = new Form8GetMapCases(dataGridView1.CurrentRow.Cells[3].Value.ToString(), new FormResultCallback(FormClosedCallback));
            form8nameSelect.ShowDialog();
        }

        //ПЕРЕСЧЕТ ВСЕЙ ТАБЛИЦЫ через REGEXanalys
        private void button2_Click(object sender, EventArgs e)
        {
            int cur_row_count;
            foreach (DataGridViewRow dgrow in dataGridView1.Rows)
            {
                cur_row_count = RegexAnalys.MapCasesCount(dgrow.Cells[6].Value.ToString());
                using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectionString))
                {
                    cn.Open();
                    SqlCommand insertMapCases = cn.CreateCommand();
                    insertMapCases.CommandText = @"UPDATE Журнал SET MapCasesCount = " + cur_row_count + " WHERE ID =" + (dgrow.Cells[0].Value);
                    insertMapCases.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }


        #region ===========ОТЧЕТЫ=============
        private void книгаУчетаЗаявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13ReportBids bidsForm = new Form13ReportBids();
            bidsForm.Show();
        }
        #endregion

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int underRefreshPosDGV = dataGridView1.FirstDisplayedScrollingRowIndex;

            LoadTables(sqlForm.CurrentSqlQuery, docQuery);
            if (underRefreshPosDGV != -1)
                dataGridView1.FirstDisplayedScrollingRowIndex = underRefreshPosDGV;
        }

        #region Attension Status
        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            //Клик по Аттеншену           
            if (attensionInfoLabel.Visible == false)
                attensionInfoLabel.Visible = true;
            else
                attensionInfoLabel.Visible = false;
        }




        #endregion

       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dm.Dispose();
        }
    }
}
