using DomainModel.Entities;
using LoadOfSql.Domain;
using LoadOfSql.Infrastructure.Controls;
using LoadOfSql.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LoadOfSql
{
    public partial class Form3Editing : Form
    {
        DataRow rowToEdit;
        DataManager dm = new DataManager();
        Form12AttachDocuments formCreateDocs;
        int editId;
        List<Document> attachDocuments = new List<Document>();
        DocType docsType;
        //List<Document> tickets = new List<Document>();
        //string ValueOrganizationCB = "Начните вводить имя организации";          //Резервные переменные для корректной работы радиобаттонов без потери значения
        //string ValueComboBox4;
        //string ValueComboBox4forOrg;
        DateTime dateRazresh = new DateTime(2000, 01, 01);
        int selectIndexComBox2;
        BindingSource bs = new BindingSource();
        FormResultCallback callback;

        public Form3Editing(DataRow rowToEdit, List<Document> attachDocsBefore, FormResultCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.rowToEdit = rowToEdit;
            editId = (int)rowToEdit["Номер"];

            attachDocuments = attachDocsBefore;
            docsType = attachDocuments.FirstOrDefault() != null ? attachDocuments.First().Type : TypeRecognizeHelper();

            int cost;
            int.TryParse(rowToEdit["Cost"].ToString(), out cost);

            formCreateDocs = new Form12AttachDocuments(editId, attachDocsBefore, docsType, cost, new CreateDocsCallback(ReadDocsCallback));
        }

        private void Form3Editing_Load(object sender, EventArgs e)
        {
            #region Заполненение всех данных из строки на Форму
            if (rowToEdit["in_type"].ToString() == "В электронном виде")                 //ставим Чекбоксы
                checkBox1.Checked = true;

            if (rowToEdit["in_type"].ToString() == "На бумажном носителе")
                checkBox2.Checked = true;

            if (rowToEdit["in_type"].ToString() == "На электронном и бумажном носителе")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }

            organizationsCB.SelectedIndexChanged -= organizationCB_SelectedIndexChanged;
            if (organizationsCB.FillOrganizations(bs))
            {
                organizationsCB.SelectedIndex = -1;
                organizationsCB.SelectedIndexChanged += organizationCB_SelectedIndexChanged;
                SelectOrganization(rowToEdit["Организация"].ToString());
            }


            //organizationsCB.SelectedIndex = -1;
            typeDocCB.FillTypeDocs();
            comboBox3.FillEmployes();

            organizationsCB.GotFocus += new EventHandler(comboBox1_GotFocus);
            organizationsCB.LostFocus += new EventHandler(comboBox1_LostFocus);
            // 

            templateCB.Items.Add("Выкопировка 1:500..");
            templateCB.Items.Add("Ситуационный план 1:2000..");
            templateCB.Items.Add("Выкопировка 1:500.. и ситуац. план 1:2000..");
            templateCB.Items.Add("Возврат исполнительной съемки");
            templateCB.Items.Add("Зарегистрированные материлы");
            templateCB.Items.Add("Возврат инженерно-геодезических изысканий");

            comboBox3.Text = rowToEdit["Выдал"].ToString();
            organizationsCB.Text = rowToEdit["Организация"].ToString();

            typeDocCB.Text = rowToEdit["Документ"].ToString();

            ShowStatusLabels(true);

            //clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue);
            var client_id = -1;
            int.TryParse(rowToEdit["Client_ID"].ToString(), out client_id);

            if (client_id > 0)
            {
                clientsCB.SelectedValue = client_id;
                if (clientsCB.SelectedValue == null)
                {
                    int unidentifyClientId = 0;
                    int.TryParse(rowToEdit["Client_ID"].ToString(), out unidentifyClientId);
                    clientsCB.FillUnidentifiedClient(unidentifyClientId);
                    clientsCB.Enabled = false;
                    editClientBtn.Enabled = false;
                    button1.Enabled = false;
                }
            }
            memoTB.Text = rowToEdit["Memo"].ToString();
            textBox3.Text = rowToEdit["Дата"].ToString();

            #endregion

            //linkLabel1.ShowDefinition(docsBefore);
            // linkLabel1.Visible = true;
            //label1.Visible = true;

            //if (radioButton2.Checked == true)        //Если при загрузке формы выбрано Частное лицо, то запишем значение в переменную                                                                               
            //    ValueComboBox4 = clientsCB.Text;     //тогда при переходе к Организации и обратно значение не будет теряться.
            //if (radioButton1.Checked == true)                    //Аналогично и для Организаций
            //    ValueComboBox4forOrg = clientsCB.Text;
            //numRazresh = textBox1.Text;                            //и для полей дата и номер разрешения
            //dateRazresh = dateTimePicker1.Value;
            selectIndexComBox2 = typeDocCB.SelectedIndex;

            if (rowToEdit["Cost"] == DBNull.Value)       //Заполняем стоимость
            {
                costTBox.Text = "0";
                costTBox.Visible = false;
                label7.Visible = false;
                label6.Visible = false;
                goto BreakLoad;
            }
            if (Convert.ToInt32(rowToEdit["Cost"]) == 0)       //Заполняем стоимость
            {
                //costCB.SelectedIndex = 1;
                costTBox.Text = rowToEdit["Cost"].ToString();
            }
            if (Convert.ToInt32(rowToEdit["Cost"]) > 0)       //Заполняем стоимость
            {
                //costCB.SelectedIndex = 0;
                costTBox.Text = rowToEdit["Cost"].ToString();
            }

            typeDocCB.SelectedIndexChanged += new EventHandler(this.typeDocCB_SelectedIndexChanged);
            BreakLoad:;
        }

        private void SelectOrganization(string organizationName)
        {
            int selectOrgId = dm.FindFirstOrganizationId(organizationName);

            if (selectOrgId != -1 & organizationsCB.Items.Count > 0)
            {
                bs.Filter = string.Empty;
                //ValueOrganizationCB = organizationName;              

                if ((organizationName != "Частное лицо") && (organizationName != null))
                {
                    radioButton1.Checked = true;
                }
                if (organizationName == "Частное лицо")
                {
                    radioButton2.Checked = true;
                }
                organizationsCB.SelectedValue = selectOrgId;
            }
        }

        DocType TypeRecognizeHelper()
        {
            string nameType = rowToEdit["Документ"].ToString();
            if (nameType != null)
            {
                switch (nameType)
                {
                    case "Разрешение": return DocType.Permission;
                    case "Обращение": return DocType.Ticket;
                    default: return DocType.Not;
                }
            }
            else return DocType.Not;
        }
        void comboBox1_LostFocus(object sender, EventArgs e)
        {
            organizationsCB.DroppedDown = false;
        }
        void comboBox1_GotFocus(object sender, EventArgs e)
        {
            organizationsCB.DroppedDown = true;
        }

        private void SaveEditingBtn_Click(object sender, EventArgs e)
        {
            string in_type = null;
            if (checkBox1.Checked == true)
                in_type = "В электронном виде";
            if (checkBox2.Checked == true)
                in_type = "На бумажном носителе";
            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
                in_type = "На электронном и бумажном носителе";
            #region Проверки заполнения
            if (clientsCB.SelectedValue == null)
            {
                MessageBox.Show("Не выбран клиент или организация. Повторите ввод.", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (((organizationsCB.Text == "") || organizationsCB.Text == "Начните вводить имя организации") || (in_type == null) || (clientsCB.Text == "") || (costTBox.Text == ""))
            {
                MessageBox.Show("Не все поля формы заполнены. \nВнесите всю необходимую информацию и повторите попытку.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (((organizationsCB.SelectedIndex == -1) && (organizationsCB.Text != "Частное лицо")) || (clientsCB.SelectedIndex == -1))
            {
                MessageBox.Show("Выбран несуществующий клиент или организация. Проверьте правильность ввода.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (dateTimePicker1.Value > DateTime.Now)
            //{
            //    MessageBox.Show("Дата документа задана не верно", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    goto RepeatEnter;
            //}
            if (memoTB.Text.Length > 4000)
            {
                if (MessageBox.Show("Слишком большой объем поля описания.\n\nСохранить введенное значение?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;
            }
            #endregion

            //Если пользователь изменил колличество лпаншетов в списке. Вызовем метод пересчета планшетов.
            //И запишем, сколько планшетов было ДО редактирования 
            //А также запишем организацию которая была в начале редактирования. Потомучто если пользователь изменить организацию, приплюсоваь планшеты уже нужно будет ей
            string organization_before = rowToEdit["Организация"].ToString();
            int mapCasesBeforeEdit = 0;
            int requireConfirmActBeforeEdit = 0;
            if (rowToEdit["MapCasesCount"] != DBNull.Value)
                mapCasesBeforeEdit = Convert.ToInt32(rowToEdit["MapCasesCount"]);
            if (rowToEdit["RequireConfirmAct"] != DBNull.Value)
                requireConfirmActBeforeEdit = Convert.ToInt32(rowToEdit["RequireConfirmAct"]);
            int mapCasesCount = RegexAnalys.MapCasesCount(memoTB.Text);

            try
            {
                // if (textBox1.Text != "")
                // rowToEdit["NumRazresh"] = textBox1.Text;
                // else rowToEdit["NumRazresh"] = DBNull.Value;
                rowToEdit["Memo"] = memoTB.Text;
                rowToEdit["Выдал"] = comboBox3.Text;
                rowToEdit["Организация"] = organizationsCB.SelectedValue;
                rowToEdit["Документ"] = typeDocCB.Text;
                //if (dateTimePicker1.Value != new DateTime(2000, 01, 01))
                //  rowToEdit["DateRazresh"] = dateTimePicker1.Value;
                // else rowToEdit["DateRazresh"] = DBNull.Value;
                rowToEdit["Дата"] = Convert.ToDateTime(textBox3.Text);
                rowToEdit["in_type"] = in_type;
                rowToEdit["ClientName"] = clientsCB.Text;
                rowToEdit["Cost"] = costTBox.Text;
                rowToEdit["MapCasesCount"] = mapCasesCount;
                rowToEdit["Client_ID"] = clientsCB.SelectedValue.ToString();
                // В сумму планшетов прибавим разностьтого что стало после редактирования и до
                int actual_RequestToDel = MapCasesManager.GetActualRequireAct(Convert.ToInt32(rowToEdit["Номер"]));

                if ((organization_before != rowToEdit["Организация"].ToString()))
                {
                    MapCasesManager.SetDBMapCasesSumm(organization_before, -requireConfirmActBeforeEdit); //у старой организации удаляем все ее планшеты из этой записи 
                    MapCasesManager.SetDBMapCasesSumm(organizationsCB.Text, mapCasesCount);                     //а новой прибавляем то что введено 
                    rowToEdit["RequireConfirmAct"] = mapCasesCount;
                }
                else
                {
                    MapCasesManager.SetDBMapCasesSumm(organizationsCB.Text, mapCasesCount - mapCasesBeforeEdit);
                    rowToEdit["RequireConfirmAct"] = (requireConfirmActBeforeEdit + (mapCasesCount - mapCasesBeforeEdit) >= 0) ?
                                                      requireConfirmActBeforeEdit + (mapCasesCount - mapCasesBeforeEdit) : 0;
                }


                var docsForChange = GetDocsAfterEdit();

                bool insertSucsedeed = false, deleteSucsedeed = false;
                deleteSucsedeed = dm.DeleteDocsForId(editId);
                if (deleteSucsedeed)
                    insertSucsedeed = dm.InsertDocuments(docsForChange);

                if (deleteSucsedeed & insertSucsedeed)
                    RowEdit.ChangeRow(rowToEdit);
                else
                    throw new Exception("Не удалось записать документы в базу данных. Изменение записи отменено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
            callback(DialogResult.OK);
        }

        //int GetActualRequireAct(int id) 
        //{
        //    using (SqlConnection cn = new SqlConnection(GlobalSettings.ConnectString))
        //    {
        //        int result = 0;
        //        cn.Open();
        //        using (SqlCommand command = cn.CreateCommand())
        //        {
        //            SqlCommand requireActToDel = cn.CreateCommand();
        //            requireActToDel.CommandText = "Select TOP 1 Журнал.RequireConfirmAct From Журнал Where ID = " + id;
        //            try
        //            {
        //                result = (int)requireActToDel.ExecuteScalar();
        //            }
        //            catch
        //            {
        //                cn.Close();
        //            }
        //        }
        //        cn.Close();
        //        return result;
        //    }
        //}

        List<Document> GetDocsAfterEdit()
        {
            //var type = GetCurrentType();
            if (docsType == DocType.Permission || docsType == DocType.Ticket)
                return attachDocuments;

            if (docsType == DocType.Not)
                return new List<Document>();

            return null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                organizationsCB.Enabled = true;
                // organizationsCB.Text = ValueOrganizationCB;
                clientsCB.DropDownStyle = ComboBoxStyle.DropDownList;
                // if (organizationsCB.SelectedValue != null)
                // clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue);
                // clientsCB.Text = ValueComboBox4forOrg;

                clientsCB.Enabled = true;
                button1.Enabled = true;
                if (organizationsCB.Text == "Начните вводить имя организации")
                {
                    clientsCB.Enabled = false;
                    button1.Enabled = false;
                }
            }
        }
        BindingSource bsClient = new BindingSource();
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                organizationsCB.Enabled = false;
                bs.Filter = string.Empty;
                int idPrivatePerson = dm.FindFirstOrganizationId("Частное лицо");
                organizationsCB.SelectedValue = idPrivatePerson;

                clientsCB.DropDownStyle = ComboBoxStyle.DropDown;
                clientsCB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                clientsCB.AutoCompleteSource = AutoCompleteSource.ListItems;
                //clientsCB.Text = ValueComboBox4;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clientsCB.SelectedIndex == -1)
            {
                Form4NewOrgOrClient newClientForm = new Form4NewOrgOrClient((int)organizationsCB.SelectedValue, clientsCB.Text);
                newClientForm.FormClosed += new FormClosedEventHandler(newClientForm_FormClosed);   //Прикрепляем событие 
                newClientForm.ShowDialog();
            }
            else
            {
                Form4NewOrgOrClient newClientForm = new Form4NewOrgOrClient((int)organizationsCB.SelectedValue, "");
                newClientForm.FormClosed += new FormClosedEventHandler(newClientForm_FormClosed);
                newClientForm.ShowDialog();
            }
        }
        private void editClientBtn_Click(object sender, EventArgs e)
        {
            if (clientsCB.SelectedIndex == -1 | clientsCB.SelectedValue == null | organizationsCB.SelectedValue == null)
                return;
            Form4NewOrgOrClient editClientForm = new Form4NewOrgOrClient((int)clientsCB.SelectedValue);
            editClientForm.FormClosed += new FormClosedEventHandler(editClientForm_FormClosed);
            tempClientIndex = clientsCB.SelectedIndex;
            editClientForm.ShowDialog();
        }
        int tempClientIndex;
        private void editClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, false);
            clientsCB.SelectedIndex = tempClientIndex > clientsCB.Items.Count - 1 ? -1 : tempClientIndex;
        }
        void newClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // dataGridView1.CurrentCellChanged -= dataGridView1_CurrentCellChanged;
            clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, false);
            clientsCB.SelectedIndex = clientsCB.Items.Count - 1;  //Выбираем в комбобоксе добавленного клиента
        }
        private void organizationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (organizationsCB.SelectedIndex == -1)
            {
                clientsCB.DataSource = null;
                organizationsCB.Text = "Начните вводить имя организации";
                return;
            }
            if ((organizationsCB.SelectedIndex != -1) && (organizationsCB.Text != "Частное лицо"))
            {
                clientsCB.Enabled = true;
                button1.Enabled = true;
            }
            if (organizationsCB.SelectedValue != null)
            {
                clientsCB.FillClients(bsClient, (int)organizationsCB.SelectedValue, false);
                clientsCB.SelectedIndex = -1;
            }
        }

        private void organizationCB_TextChanged(object sender, EventArgs e)
        {
            if ((organizationsCB.SelectedIndex != -1) && (organizationsCB.Text != "Частное лицо"))   //тут что то нужно исправлять для корректной анимации
            {                                                                            //Вроде заработало. Убрать всю повтоярющуюся логику
                clientsCB.Enabled = true;
                button1.Enabled = true;
            }

            if ((organizationsCB.SelectedIndex == -1) && (organizationsCB.Text != "Частное лицо"))
            {
                clientsCB.Enabled = false;
                clientsCB.SelectedIndex = -1;
                button1.Enabled = false;
            }
            else
            {
                clientsCB.Enabled = true;
                button1.Enabled = true;
            }
        }
        void ShowStatusLabels(bool isFirstLoad)
        {
            if ((typeDocCB.Text == "Разрешение") || (typeDocCB.SelectedIndex == 0))
            {
                if (!isFirstLoad)
                    if (formCreateDocs.ChangeType(DocType.Permission, attachDocuments))
                        costTBox.Text = "0";

                ShowAttachDefinition();
            }
            if ((typeDocCB.Text == "Обращение") || (typeDocCB.SelectedIndex == 1))
            {
                if (!isFirstLoad)
                    if (formCreateDocs.ChangeType(DocType.Ticket, attachDocuments))
                        costTBox.Text = "0";

                ShowAttachDefinition();
            }
            else if ((typeDocCB.Text == "Нет") || (typeDocCB.SelectedIndex == 2))
            {
                if (!isFirstLoad)
                   if(formCreateDocs.ChangeType(DocType.Not, attachDocuments))
                        costTBox.Text = "0";
                HideAttachDefinition();
            }
        }

        void ShowAttachDefinition()
        {
            linkLabel1.SetLingvaDefinitionFor(attachDocuments);
            label1.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            costTBox.Visible = true;
        }
        void HideAttachDefinition()
        {
            linkLabel1.HideDefinition();
            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            costTBox.Visible = false;
        }
        private void typeDocCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStatusLabels(false);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
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


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void ReadDocsCallback(DialogResult dr, List<Document> docs, int cost)
        {
            if (dr == DialogResult.OK && docs != null)
            {
                attachDocuments = docs;

                linkLabel1.SetLingvaDefinitionFor(attachDocuments);

                costTBox.Text = cost.ToString();
                costTBox.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
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

        private void Form3Editing_FormClosing(object sender, FormClosingEventArgs e)
        {
            dm.Dispose();
        }
    }
}

