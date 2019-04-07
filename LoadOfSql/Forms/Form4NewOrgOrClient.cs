using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using LoadOfSql.Infrastructure;
using LoadOfSql.Infrastructure.DAL;
using LoadOfSql.Domain;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Security.AccessControl;
using DomainModel.Entities;

namespace LoadOfSql
{
    enum FormOpenMode
    {
        ForCreateOrganization = 1,
        ForAddClient = 2,
        ForEditClient = 3
    }
    public partial class Form4NewOrgOrClient : Form
    {
        FormOpenMode formMode = FormOpenMode.ForCreateOrganization;
        DataManager dm;
        ClientInfo clientInfo = new ClientInfo();

        int currentClientId;

        /// <summary>
        /// Вызывается при добавлении организации
        /// </summary>
        public Form4NewOrgOrClient()
        {
            //Вызывается при создании новой организации
            InitializeComponent();
            dm = new DataManager();
        }
        /// <summary>
        /// Создание нового клиента
        /// </summary>
        public Form4NewOrgOrClient(int orgId, string currentClient) : this()
        {
            //this.currentOrgId = orgId;
            clientInfo.Org_Id = orgId;
            clientInfo.ClientName = currentClient;
            formMode = FormOpenMode.ForAddClient;
        }
        /// <summary>
        ///  Конструктор для редактирования существующего клиента. Заполняет поля формы реквизитами клиента.
        /// </summary>
        /// <param name="selectedValue">ID существующего клиента</param>
        public Form4NewOrgOrClient(int clientId) : this()
        {
            formMode = FormOpenMode.ForEditClient;
            this.currentClientId = clientId;

            //var firstIdentDoc = identityDocs.First();
            //fidCurrentClient = (int)firstIdentDoc.IdentityDocType - 1;
            //currentReq = firstIdentDoc.Requisites;

            //userMachineScanUrl = firstIdentDoc.ScanLink;
            //serverScanUrl = firstIdentDoc.ScanLink;
            //currentScanName = Path.GetFileName(serverScanUrl);
        }

        private void Form4NewOrgOrClient_Load(object sender, EventArgs e)
        {
            ConfigureFormControls(formMode);
        }

        private void ConfigureFormControls(FormOpenMode formMode)
        {
            if (formMode == FormOpenMode.ForCreateOrganization)
            {
                button1.Text = "Создать";
                this.Text = "Создать новую организацию";
                IdentityDocTypeCB.SelectedIndex = 0;
                orgNameTB.Enabled = true;
                return;
            }

            if (formMode == FormOpenMode.ForEditClient)
            {
                button1.Text = "Изменить";
                this.Text = "Изменить реквизиты клиента";
                IdentityDocTypeCB.SelectedIndex = 0;
                orgNameTB.Enabled = false;

                clientInfo = dm.GetClientInfo(currentClientId);
                orgNameTB.Text = dm.GetOrganizationName(clientInfo.Org_Id);
                clientNameTB.Text = clientInfo.ClientName;
                IdentityDocTypeCB.SelectedIndex = (int)clientInfo.FidDocType - 1;
                maskedTextBox1.Text = clientInfo.Requisites;
                if (!string.IsNullOrWhiteSpace(clientInfo.ServerScanLink))
                {
                    linkLabel1.Text = Path.GetFileName(clientInfo.ServerScanLink);
                    linkLabel1.Visible = true;
                }
                return;
            }
            if (formMode == FormOpenMode.ForAddClient)
            {
                button1.Text = "Добавить";
                this.Text = "Добавить клиента";
                IdentityDocTypeCB.SelectedIndex = 0;
                orgNameTB.Enabled = false;
                orgNameTB.Text = dm.GetOrganizationName(clientInfo.Org_Id);
                clientNameTB.Text = clientInfo.ClientName;
                return;
            }
        }

        IdentityDocType GetIdentityType()
        {
            if (IdentityDocTypeCB.SelectedIndex == 0)
                return IdentityDocType.PassportRF;
            if (IdentityDocTypeCB.SelectedIndex == 1)
                return IdentityDocType.DriverLicense;
            if (IdentityDocTypeCB.SelectedIndex == 2)
                return IdentityDocType.ForeignPassport;
            else
                return IdentityDocType.NULL;
        }

        void ReadClientInfo()
        {
            clientInfo.ClientName = clientNameTB.Text;
            //clientInfo.Org_Id = currentOrgId;
            clientInfo.FidDocType = (IdentityDocType)IdentityDocTypeCB.SelectedIndex + 1;
            clientInfo.Requisites = maskedTextBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(orgNameTB.Text) || (string.IsNullOrWhiteSpace(clientNameTB.Text)
                // || (string.IsNullOrWhiteSpace(clientInfo.ServerScanLink))
                || IdentityDocTypeCB.SelectedIndex == -1 || string.IsNullOrWhiteSpace(maskedTextBox1.Text))))
            {
                MessageBox.Show("Не все поля формы заполнены. \nВнесите всю необходимую информацию и повторите попытку.", "Ошибка заполнения формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region Действия с Данными         
            int orgsCount = dm.OrganizationCount(orgNameTB.Text);
            if (orgsCount > 1)
            {
                MessageBox.Show("Есть несколько одноименных организаций. Обратитесь к администратору.", "Ошибка создания организации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (orgsCount == 1 & formMode == FormOpenMode.ForCreateOrganization)
            {
                MessageBox.Show("Организация с таким именем уже существует.", "Ошибка создания организации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                ReadClientInfo();
                if (orgsCount == 0 & formMode == FormOpenMode.ForCreateOrganization)
                    if (dm.NewOrganization(orgNameTB.Text))
                    {
                        clientInfo.Org_Id = dm.FindFirstOrganizationId(orgNameTB.Text);
                        dm.CreateClient(clientInfo);
                    }

                if (orgsCount == 1 & formMode == FormOpenMode.ForAddClient)
                    if (!dm.CreateClient(clientInfo))
                    {
                        MessageBox.Show("Не удалось создать клиента. Действие отменено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                if (orgsCount == 1 & formMode == FormOpenMode.ForEditClient)
                {
                    if (!dm.UpdateClient(clientInfo))
                    {
                        MessageBox.Show("Не удалось обновить данные клиента. Возможно в полях ввода присутствуют некорректные значения. Действие отменено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с данными при создании или изменении клиента или организации.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            this.Close();
        }

        string GetTargetScanLink(string scanLink)
        {
            string targetLink = string.Empty;

            //string ext = Path.GetExtension(scanLink);
            targetLink = Path.Combine(GlobalSettings.ScanDirectory, Path.GetFileName(clientInfo.LocalScanLink).Replace(" ", "_"));
            return GetUnicPath(targetLink);
        }

        private string GetUnicPath(string path)
        {
            string retPath = path;
            int i = 1;
            while (File.Exists(retPath))
            {
                retPath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "_" + i + Path.GetExtension(path));
                i++;
            }

            return retPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void attachScanBtn_Click(object send, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GlobalSettings.LastUserDirectory) & Directory.Exists(GlobalSettings.LastUserDirectory))
                openFileDialog1.InitialDirectory = GlobalSettings.LastUserDirectory;

            openFileDialog1.FileName = "";
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DereferenceLinks = true;
            openFileDialog1.Filter = "Все файлы (*.*)|*.*";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //DeleteScan(clientInfo.ServerScanLink);
                clientInfo.LocalScanLink = openFileDialog1.FileName;
                clientInfo.ServerScanLink = GetTargetScanLink(openFileDialog1.FileName);

                linkLabel1.Text = openFileDialog1.SafeFileName;
                linkLabel1.Visible = true;

                string userScanDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                GlobalSettings.SetLastUserDirectoryRegKey(userScanDirectory);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(clientInfo.ServerScanLink))
                try
                {
                    Process.Start(clientInfo.ServerScanLink);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        void DeleteScan(string path)
        {
            if (File.Exists(path))
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form4NewOrgOrClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            dm.Dispose();
        }
    }
}
