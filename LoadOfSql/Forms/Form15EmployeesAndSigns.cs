using ApplicationJournal;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Forms
{
    public partial class Form15EmployeesAndSigns : Form
    {
        IEmployeeService _employeeService;
        public Form15EmployeesAndSigns(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }
        private void Form15EmployeesAndSigns_Load(object sender, EventArgs e)
        {
            FillEmployeesCb();
            cbEmployees.SelectedIndex = cbEmployees.FindStringExact(GlobalSettings.LoginUser.ShortName);
        }
        
        class EmployeeCbItem
        {
            public Employee Employee { get; set; }

            public override string ToString()
            {
                return string.IsNullOrWhiteSpace(Employee.ShortName) ? Employee.SecondName : Employee.ShortName;
            }
        }

        Employee _selectedEmployee;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите изображение подписи";
            ofd.Multiselect = false;
            ofd.Filter = "Image Files(*.BMP;*.JPG;)|*.BMP;*.JPG;";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var signBitmap = new Bitmap(Bitmap.FromFile(ofd.FileName));
            if (signBitmap?.Size.Width > 150 || signBitmap?.Height > 120)
                MessageBox.Show("Это изображение имеет слишком большой размер.\r\nРазмер не должен превышать 150x120 пикселей.", "Невозможно загрузить это изображение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            try
            {
                _employeeService.SetEmployeeSign(_selectedEmployee, signBitmap);
                FillSignImage(_selectedEmployee);
            }
            catch
            {
                MessageBox.Show("Не удалось установить подпись сотруднику. Обратитесь к администратору");
            }         
        }

        private void cbEmployees_SelectedValueChanged(object sender, EventArgs e)
        {
            var empl = (cbEmployees.SelectedItem as EmployeeCbItem).Employee;
            if (empl == null)
                return;

            _selectedEmployee = empl;
            FillEmployeeCard(empl);
        }

        private void FillEmployeesCb()
        {
            var employees = _employeeService.GetEmployees();
            foreach (var empl in employees)
            {
                EmployeeCbItem item = new EmployeeCbItem() { Employee = empl };
                cbEmployees.Items.Add(item);
            }
        }

        private void FillEmployeeCard(Employee empl)
        {
            tbPostName.Text = empl.Post;
            tbSecondName.Text = empl.SecondName;
            tbFirstName.Text = empl.FirstName;
            tbThirdName.Text = empl.ThirdName;
            FillSignImage(empl);
        }

        void FillSignImage(Employee empl)
        {
            var sign = _employeeService.GetEmployeeSign(empl);
            if (sign == null)
                return;

            pictureBox1.Image = sign.GetBitmapSign();
        }

        #region ФИО и Должность
        private void btnSecondNameEdit_Click(object sender, EventArgs e)
        {
            tbSecondName.ReadOnly = !tbSecondName.ReadOnly;
            btnSecondNameEdit.BackgroundImage = tbSecondName.ReadOnly ? Properties.Resources.pencil : Properties.Resources.save;
            if (!tbSecondName.ReadOnly)
                btnSecondNameEdit.Click += BtnEdit_Click;
            else
                btnSecondNameEdit.Click -= BtnEdit_Click;
        }

        private void btnPostEdit_Click(object sender, EventArgs e)
        {
            tbPostName.ReadOnly = !tbPostName.ReadOnly;
            btnPostEdit.BackgroundImage = tbPostName.ReadOnly ? Properties.Resources.pencil : Properties.Resources.save;
            if(!tbPostName.ReadOnly)
                btnPostEdit.Click += BtnEdit_Click;
            else
                btnPostEdit.Click -= BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
                return;
            _selectedEmployee.FirstName = tbFirstName.Text;
            _selectedEmployee.SecondName = tbSecondName.Text;
            _selectedEmployee.ThirdName = tbThirdName.Text;
            _selectedEmployee.Post = tbPostName.Text;
            _selectedEmployee.ShortName = GetShortName(_selectedEmployee);

            _employeeService.Save(_selectedEmployee);
            cbEmployees.Items[cbEmployees.SelectedIndex] = new EmployeeCbItem() { Employee = _selectedEmployee };
            cbEmployees.Refresh();
        }

        private string GetShortName(Employee employee)
        {
            if (employee == null)
                return string.Empty;

            return $"{employee?.SecondName} {employee.FirstName.FirstOrDefault().ToString().ToUpper()}.{employee.ThirdName.FirstOrDefault().ToString().ToUpper()}.";
        }

        private void btnFirstNameEdit_Click(object sender, EventArgs e)
        {
            tbFirstName.ReadOnly = !tbFirstName.ReadOnly;
            btnFirstNameEdit.BackgroundImage = tbFirstName.ReadOnly ? Properties.Resources.pencil : Properties.Resources.save;

            if (!tbFirstName.ReadOnly)
                btnFirstNameEdit.Click += BtnEdit_Click;
            else
                btnFirstNameEdit.Click -= BtnEdit_Click;
        }

        private void btnThirdNameEdit_Click(object sender, EventArgs e)
        {
            tbThirdName.ReadOnly = !tbThirdName.ReadOnly;
            btnThirdNameEdit.BackgroundImage = tbThirdName.ReadOnly ? Properties.Resources.pencil : Properties.Resources.save; ;
            if (!tbThirdName.ReadOnly)
                btnThirdNameEdit.Click += BtnEdit_Click;
            else
                btnThirdNameEdit.Click -= BtnEdit_Click;
        }

        #endregion
    }
}
