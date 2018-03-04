using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoadOfSql.Domain;
using LoadOfSql.Infrastructure;
using LoadOfSql.Infrastructure.Controls;

namespace LoadOfSql
{
    public partial class Form10GotProfit : Form
    {
        List<CostFillingModel> costFillingModels;
        List<CostFillingModel> customFillingModels;
        public Form10GotProfit()
        {
            InitializeComponent();

            costFillingModels = new List<CostFillingModel>
            {
                new CostFillingModel(tBoxYearMC, SummingType.MapCases, new DateTime(DateTime.Today.Year, 1, 1), DateTime.Now),
                new CostFillingModel(tBoxYearOther, SummingType.OtherInformation, new DateTime(DateTime.Today.Year, 1, 1), DateTime.Now),
                new CostFillingModel(tBoxMonthMC, SummingType.MapCases, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Now),
                new CostFillingModel(tBoxMonthOther, SummingType.OtherInformation, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Now)
            };
        }

        private void Form10GotProfit_Load(object sender, EventArgs e)
        {          
            costFillingModels.FillSumsOfTextBoxes();
        }

        private void btnFillCustom_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            customFillingModels = new List<CostFillingModel>
            {
                new CostFillingModel(tBoxCustomMC, SummingType.MapCases, dateTimePicker1.Value, dateTimePicker2.Value),
                new CostFillingModel(tBoxCustomOther, SummingType.OtherInformation, dateTimePicker1.Value, dateTimePicker2.Value)
            };

            customFillingModels.FillSumsOfTextBoxes();
            Cursor.Current = Cursors.Default;
        }
    }
}
