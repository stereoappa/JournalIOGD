using DomainModel.Entities;
using DomainModel.Helpers;
using DomainModel.Repositories;
using LoadOfSql.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace LoadOfSql.Forms
{
    public partial class Form16Templates : Form
    {
        ITemplateRepository _templateRepository;
        public Form16Templates(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            InitializeComponent();
        }

        private void Form16Templates_Load(object sender, EventArgs e)
        {
            RefreshTemplateData();
        }

        void RefreshTemplateData()
        {
            var types = _templateRepository.GetTemplateTypes();
            if (types == null)
                return;

            templateTypesCB.Items.Clear();
            foreach (var t in types)
            {
                templateTypesCB.Items.Add(t);
            }
            if (templateTypesCB.Items.Count > 0)
            {
                templateTypesCB.SelectedIndex = 0;
            }
            else
            {
                downloadBtn.Enabled = false;
                loadBtn.Enabled = false;
                templateLoadedInfoLabel.Visible = false;
            }
        }

        private void actualTemplatesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var type = cb.SelectedItem as TemplateType;
            var template = _templateRepository.GetActualTemplate(type.TypeId, false);

            templateLoadedInfoLabel.Visible = true;
            if (template != null)
            {
                templateLoadedInfoLabel.Text = $"Загружен {template.LoadedDate.ToString("yyyy.MM.dd в HH:mm:ss")}\r\nПользователем {template.WhoUpload.ShortName}";
                downloadBtn.Enabled = true;
                loadBtn.Enabled = true;
            }
            else
            {
                templateLoadedInfoLabel.Text = "Ожидает загрузки..";
                downloadBtn.Enabled = false;
                loadBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Загрузить новую версию шаблона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".docx | *.docx";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            ofd.Multiselect = false;

            if (File.Exists(ofd.FileName) && templateTypesCB.SelectedItem is TemplateType)
            {
                byte[] fileBytes;
                try
                {
                    fileBytes = File.ReadAllBytes(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла: {ex.Message}");
                    return;
                }

                TemplateFile file = new TemplateFile
                {
                    FileData = fileBytes,
                    HashMd5 = Md5Helper.GetMd5Hash(fileBytes),
                    TemplateType = (templateTypesCB.SelectedItem as TemplateType),
                    WhoUpload = GlobalSettings.LoginUser
                };

                _templateRepository.Add(file);
                RefreshTemplateData();
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (templateTypesCB.SelectedItem == null)
                MessageBox.Show("Шаблон не выбран. Скачивание невозможно.");

            var type = templateTypesCB.SelectedItem as TemplateType;
            var templateFile = _templateRepository.GetActualTemplate(type.TypeId, true);

            if (templateFile == null)
                MessageBox.Show("Ошибка скачивания файла");

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var targetPath = Path.Combine(fbd.SelectedPath, templateFile.TemplateType.Name + ".docx");
                if (File.Exists(targetPath))
                {
                    var overwriteRes = MessageBox.Show("Файл с этим именем уже существует. Перезаписать?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (overwriteRes == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(targetPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                using (FileStream targetFileStream = new FileStream(targetPath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    targetFileStream.Write(templateFile.FileData, 0, templateFile.FileData.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При скачивании шаблона возникли ошибки.\r\n" + ex.Message);
            }

            MessageBox.Show("Файл успешно скопирован", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
