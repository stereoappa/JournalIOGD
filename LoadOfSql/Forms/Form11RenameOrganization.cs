using LoadOfSql.Infrastructure.Controls;
using LoadOfSql.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql
{
    public partial class Form11RenameOrganization : Form
    {
        FormResultCallback callback;
        public Form11RenameOrganization(FormResultCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void Form11RenameOrganization_Load(object sender, EventArgs e)
        {
            comboBox1.FillOrganizations();
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void btnSaveNameOrg_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите сменить имя организации\nс {comboBox1.Text}\nна {textBox1.Text} ?", "Подтвердите переименование", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataManager dbManager = new DataManager();
                bool result = dbManager.RenameOrganization(comboBox1.Text, textBox1.Text);

                if (!result)
                {
                    MessageBox.Show("Ошибка переименования организации.\nВозможно, организация с таким именем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    callback(DialogResult.Cancel);
                    return;
                }

                callback(DialogResult.OK);
                Close();
            }           
        }
    }
}
