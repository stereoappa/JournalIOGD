using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql
{
    public partial class Form14ReportBidsParams : Form
    {
        Action<DateTime?, int?, int> callback;
        public Form14ReportBidsParams(Action<DateTime?, int?, int> callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                callback(datePeriod.Value, null, Convert.ToInt32(startNumber.Value));
            if(radioButton2.Checked == true)
                callback(null, Convert.ToInt32(idPeriod.Value), Convert.ToInt32(startNumber.Value));

            Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                datePeriod.Enabled = true;
                idPeriod.Enabled = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                datePeriod.Enabled = false;
                idPeriod.Enabled = true;
            }
        }

    }
}
