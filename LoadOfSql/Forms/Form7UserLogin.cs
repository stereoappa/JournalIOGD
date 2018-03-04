using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using ApplicationJournal;
using DomainModel.Entities;

namespace LoadOfSql
{
    public partial class Form7UserLogin : Form
    {
        IUserService _userService;
        Action<Employee> _employeeCallback;

        public Form7UserLogin(IUserService userService, Action<Employee> employeeCallback)
        {
            _userService = userService;
            _employeeCallback = employeeCallback;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            var employee = _userService.SignIn(textBox1.Text, textBox2.Text);
            if (employee == null)
            {
                MessageBox.Show("Неверно введено имя пользователя или пароль. \nПовторите ввод.", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                return;
            }

            if (checkBox1.Checked == true)
            {
                GlobalSettings.SetLoginPassRegistryKeys(textBox1.Text, textBox2.Text);
            }
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;

            _employeeCallback(employee);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
