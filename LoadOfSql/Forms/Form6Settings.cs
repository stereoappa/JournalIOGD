using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoadOfSql
{
    public partial class Form6Settings : Form
    {
        public Form6Settings()
        {
            InitializeComponent();
            textBox2.Text = GlobalSettings.ConnectionString;
            scanFolderTB.Text = GlobalSettings.ScanDirectory;

            GlobalSettings.GetPrinters();                               //загружаем список принтеров
            comboBox1.Items.AddRange(GlobalSettings.GetPrinters());       //в комбобокс
            try
            {
                comboBox1.SelectedIndex = GlobalSettings.SelectPrinter;  //из файла конфигурации берем индекс выбранного ранее принтера
            }
            catch { comboBox1.SelectedIndex = -1; }
        }


        private void button2_Click(object sender, EventArgs e)   //СОХРАНИТЬ
        {
            GlobalSettings.SelectPrinter = comboBox1.SelectedIndex;
            GlobalSettings.SaveRegistryKeys();
            Close();
        }

    
    }
}
