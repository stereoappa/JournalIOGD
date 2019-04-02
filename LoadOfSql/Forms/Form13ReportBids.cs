using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using LoadOfSql.Infrastructure.DAL;
using LoadOfSql.Infrastructure.Controls;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace LoadOfSql
{
    public partial class Form13ReportBids : Form
    {
        DataManager dm;
        System.Data.DataTable bidsJournal;
        Form14ReportBidsParams bidParamForm;
        struct DataParameter
        {
            public string FileName { get; set; }
            public System.Data.DataTable BidsJournal { get; set; }
        }
        DataParameter _inputParameter;

        public Form13ReportBids()
        {
            InitializeComponent();
            dm = new DataManager();
            bidParamForm = new Form14ReportBidsParams(new Action<DateTime?, int?, int>(GetBids));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook (2010)|*.xlsx|Excel Workbook (2003)|*.xls",
                FileName = "Книга_учета_заявки" + DateTime.Now.ToShortDateString()})
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    _inputParameter.FileName = sfd.FileName;
                    backgroundWorker1.RunWorkerAsync(_inputParameter);
                }
            }
        }
    

        private void SaveToExcelFile(string fileName, System.Data.DataTable bids)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            var workbooks = excel.Workbooks;
            Workbook wb = workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)excel.ActiveSheet;
            //excel.Visible = false;
            excel.Columns[1].ColumnWidth = 12;
            excel.Columns[1].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excel.Columns[2].ColumnWidth = 20;
            excel.Columns[3].ColumnWidth = 45;
            excel.Columns[4].ColumnWidth = 33;
            excel.Columns[5].ColumnWidth = 28;
           
            for (int i = 1; i <= bids.Columns.Count; i++)
            {
                excel.Cells[1, i] = bids.Columns[i - 1].Caption;
                excel.Cells[1, i].EntireRow.Font.Bold = true;
                excel.Cells[1, i].WrapText = true;
            }

            int progress = 1;
            for (int i = 0; i < bids.Rows.Count; i++)
            {
                if (!backgroundWorker1.CancellationPending)
                {
                    backgroundWorker1.ReportProgress((progress++ * 100 / bids.Rows.Count));
                    for (int j = 0; j < bids.Columns.Count; j++)
                    {
                        excel.Cells[i + 2, j + 1] = bids.Rows[i].ItemArray[j].ToString();
                    }
                }

            }
            var range = excel.Range["A1", "E3000"];
            range.Borders.ColorIndex = 0;
            range.Borders.LineStyle = XlLineStyle.xlContinuous;
            range.Borders.Weight = XlBorderWeight.xlThin;
            
            //ws.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            wb.Close(true, fileName, false);
            workbooks.Close();
            excel.Quit();

            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(excel);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = ((DataParameter)e.Argument).FileName;
            System.Data.DataTable bids = ((DataParameter)e.Argument).BidsJournal;

            SaveToExcelFile(fileName, bidsJournal);          
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
            //label1.Text = "Выполнено: "+ e.ProgressPercentage + " %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                Thread.Sleep(100);
                label1.Text = "Книга успешно сохранена в файл.";
            }
        }

        void GetBids(DateTime? date, int? id, int startNum)
        {
            bidsJournal = dm.GetBidsReportData(date, id, startNum);
            dgvReport.DataSource = bidsJournal;

            dgvReport.SortedOff();

            _inputParameter.BidsJournal = bidsJournal;
        }
        private void reportFormBtn_Click(object sender, EventArgs e)
        {
            bidParamForm.ShowDialog();
        }

        private void Form13ReportBids_FormClosing(object sender, FormClosingEventArgs e)
        {
            dm.Dispose();
        }
    }
}
