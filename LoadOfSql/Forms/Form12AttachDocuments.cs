using LoadOfSql.Domain;
using LoadOfSql.Infrastructure.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using LoadOfSql.Infrastructure;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DomainModel.Entities;

namespace LoadOfSql
{
    public partial class Form12AttachDocuments : Form
    {
        CreateDocsCallback callback;
        List<Document> documents;
        DocType docsType;
        //CostType costType;
        int? editID;
        int costAfterEdit = 0;

        public Form12AttachDocuments(CreateDocsCallback callback, DocType type)
        {
            InitializeComponent();
            this.docsType = type;
            ConfigureGrid(docsType);
            ConfigureCheckBoxes(type);
            // costCB.SelectedIndexChanged -= costCB_SelectedIndexChanged;
            //costCB.Items.AddRange(new string[] { "бесплатно", "платно" });
            costCB.SelectedIndex = 0;
            //costCB.SelectedIndexChanged += costCB_SelectedIndexChanged;
            documents = new List<Document>();
            this.callback = callback;
        }
        public Form12AttachDocuments(int? fidJournal, List<Document> attachDocs, DocType type, int cost, CreateDocsCallback callback)
               : this(callback, type)
        {
            documents = attachDocs;
            //Вызывается из формы редактирования, передает ранее созданные документы
            //Запишем id той записи в журнале, которую редактируем
            editID = fidJournal;
            SetCost(cost);
            FillDocsGrid(attachDocs);
            //SetColorFastCell(docsType);
        }
        void SetCost(int cost)
        {
            if (cost > 0)
            {
                costCB.SelectedIndex = 1;
                costTB.Text = cost.ToString();
            }
            if (cost == 0)
            {
                costCB.SelectedIndex = 0;
                dgvDocs.DisableColumn(DATE_CHARGE);
            }
        }
        private void SetColorFastCell(DocType type)
        {
            if (type == DocType.Permission)
            {
                dgvDocs.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                dgvDocs.Rows[0].Cells[0].ToolTipText = "В этой ячейке можно ввести любой\nдиапазон номеров разрешений для\nавтоматической генерации строк.\nПример: \"100-105, 107, 110-115\"";
            }
            else
            {
                dgvDocs.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.White;
                dgvDocs.Rows[0].Cells[0].ToolTipText = string.Empty;
            }
        }
        public void ConfigureGrid(DocType type)
        {
            dgvDocs.Rows.Clear();
            dgvDocs.Columns.Clear();

            dgvDocs.Refresh();

            if (type == DocType.Permission)
            {
                dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                 this.NUM_RAZRESH,
                                 this.DATE_RAZRESH,
                                 this.TICKET_NUM,
                                 this.TICKET_DATE,
                                 this.DATE_CHARGE});
                NUM_RAZRESH.DisplayIndex = 0;
                DATE_RAZRESH.DisplayIndex = 1;
                TICKET_NUM.DisplayIndex = 2;
                TICKET_DATE.DisplayIndex = 3;
                DATE_CHARGE.DisplayIndex = 4;
            }
            if (type == DocType.Ticket)
            {
                dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                 this.TICKET_NUM,
                                 this.TICKET_DATE,
                                 this.DATE_CHARGE});
                TICKET_NUM.DisplayIndex = 0;
                TICKET_DATE.DisplayIndex = 1;
                DATE_CHARGE.DisplayIndex = 2;
            }
            dgvDocs.SortedOff();
            this.docsType = type;
        }
        void ConfigureCheckBoxes(DocType type)
        {
            if (type == DocType.Permission)
            {
                enterLaterCheckB.Checked = false;
                enterLaterCheckB.Visible = true;
            }
            if (type == DocType.Ticket || type == DocType.Not)
            {
                enterLaterCheckB.Checked = false;
                enterLaterCheckB.Visible = false;
            }
        }
        void FillDocsGrid(List<Document> docs)
        {
            if (docsType == DocType.Permission)
            {
                foreach (Document doc in docs)
                {
                    dgvDocs.Rows.Add(doc.NumRazresh, doc.DateRazresh, doc.TicketNumber, doc.TicketDate, doc.ChargeDate);
                }
            }
            if (docsType == DocType.Ticket)
            {
                foreach (Document doc in docs)
                {
                    dgvDocs.Rows.Add(doc.TicketNumber, doc.TicketDate, doc.ChargeDate);
                }
                //SetColorFastCell(DocType.Ticket);
            }

        }
        void ChangeDocumentsType(DocType newType)
        {
            var temp = newType;
            try
            {
                docsType = newType;
                ConfigureCheckBoxes(docsType);
                ConfigureGrid(newType);

            }
            catch { docsType = temp; }
        }
        public bool ChangeType(DocType newType, List<Document> attachDocuments)
        {
            if (attachDocuments.Count() > 0)
            {
                DialogResult dr = MessageBox.Show($"Смена типа документа приведет к потере всех ранее прикрепленных  документов ({attachDocuments.Count()} шт.)\n\nВы уверены, что хотите продолжить?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    attachDocuments.Clear();
                    // this.ClearDocsGrid();
                    this.ChangeDocumentsType(newType);
                    SetCost(0);
                    return true;
                }
                else return false;
            }
            else
            {
                //this.ClearDocsGrid();
                this.ChangeDocumentsType(newType);
                SetCost(0);
                return true;
            }
        }

        void SaveDocumentsFromGrid()
        {
            DialogResult = DialogResult.None;
            documents?.Clear();

            //Получим только полностью заполненные строки с учетом того, какую опцию заполнения выбрал пользователь
            List<DataGridViewRow> completedRows = dgvDocs.Rows.Cast<DataGridViewRow>()
                                      .Where(x => x.Cells.Cast<DataGridViewCell>().Where(cell => WhatColumnsFillUser().Contains(cell.OwningColumn)).ToList()
                                      .TrueForAll(c => c.Value != null && c.Value != null))
                                      .ToList();

            //if (completedRows.Count == 0)
            //{
            //    if (MessageBox.Show("Не внесена информация ни по одному документу.\n\nПродолжить?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            //        return;
            //    // errorLabel.Visible = true;
            //    // return;
            //}
            //TODO: Сделать проверку на ЧАСТИЧНО ЗАПОЛНЕННЫЕ СТРОКИ. Если они есть выдавать ошибку!!
            // this.FormClosing -= Form12AttachDocuments_FormClosing;
            try
            {
                switch (docsType)
                {
                    case DocType.Permission:
                        foreach (DataGridViewRow row in completedRows)
                        {
                            documents.Add(new Document(DocType.Permission)
                            {
                                FidJournal = editID,
                                NumRazresh = row.Cells["NUM_RAZRESH"].Value.ToString(),
                                DateRazresh = Convert.ToDateTime(row.Cells["DATE_RAZRESH"].Value),
                                TicketNumber = row.Cells["TICKET_NUM"].Value == null ? null : row.Cells["TICKET_NUM"].Value.ToString(),
                                TicketDate = (Nullable<DateTime>)row.Cells["TICKET_DATE"].Value,
                                ChargeDate = costCB.SelectedIndex == 1 ? (Nullable<DateTime>)row.Cells["DATE_CHARGE"].Value : null
                            });
                        }
                        DialogResult = DialogResult.OK;
                        break;

                    case DocType.Ticket:
                        foreach (DataGridViewRow docRow in completedRows)
                        {
                            documents.Add(new Document(DocType.Ticket)
                            {
                                FidJournal = editID,
                                TicketNumber = docRow.Cells[0].Value.ToString(),
                                TicketDate = Convert.ToDateTime(docRow.Cells["TICKET_DATE"].Value),
                                ChargeDate = costCB.SelectedIndex == 1 ? (Nullable<DateTime>)docRow.Cells["DATE_CHARGE"].Value : null
                            });
                        }
                        DialogResult = DialogResult.OK;
                        break;
                }
            }
            catch
            {
                DialogResult = DialogResult.Abort;
                documents = null;
            }
        }
        //ПРИКРЕПИТЬ  
        private void btnSaveDocs_Click(object sender, EventArgs e)
        {
            #region Проверки заполнения
            if (string.IsNullOrWhiteSpace(costTB.Text))
            {
                errorLabel.Text = "Для продолжения заполните поле Стоимость.";
                errorLabel.Visible = true;
                return;
            }
            #endregion

            errorLabel.Visible = false;

            SaveDocumentsFromGrid();
            Close();
            //callback(DialogResult, documents, costAfterEdit);
        }

        private void Form12AttachDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                //MessageBox.Show("Все введенные данные будут сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveDocumentsFromGrid();

            }

            int.TryParse(costTB.Text, out costAfterEdit);
            callback(DialogResult.OK, documents, costAfterEdit);
        }

        #region Helper для вписывания диапазонов

        List<int> recognizedDiapasone = new List<int>();
        private void dgvDocs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (docsType == DocType.Permission & dgvDocs.CurrentCell.OwningColumn.Name == "NUM_RAZRESH" & e.RowIndex == 0 & dgvDocs.Rows[0].Cells[0].Value != null)
            {
                recognizedDiapasone = RegexAnalys.ParseNumbersDiapasone(dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                if (recognizedDiapasone != null)
                    FillColumn(recognizedDiapasone.Distinct().ToList());
            }
        }
        void FillColumn(List<int> values)
        {
            if (dgvDocs?.Columns == null)
                return;

            if (values.Count > 1)
            {
                dgvDocs.CellValueChanged -= dgvDocs_CellValueChanged;
                //В первый столбец 
                FillDiapasoneInColumn(values, 0);
                dgvDocs.CellValueChanged += dgvDocs_CellValueChanged;
            }
        }

        private void FillDiapasoneInColumn(List<int> values, int columnNumber)
        {
            int sub = values.Count - dgvDocs.Rows.Count;

            if (sub > 50)
            {
                DialogResult dr = MessageBox.Show("По введенным данным будет сгенерировано большое количество строк (" + sub + "). Проверьте правильность введенного диапазона. \n\nПродолжить создание строк?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                    return;
            }

            if (sub < 0)
                dgvDocs.Rows.RemoveEndingItems(values.Count);

            for (int i = 0; i <= sub; i++)
            {
                dgvDocs.Rows.Add();
            }

            for (int i = 0; i < values.Count; i++)
            {
                dgvDocs.Rows[i].Cells[columnNumber].Value = values[i];
            }
        }
        #endregion

        DataGridViewColumn[] WhatColumnsFillUser()
        {
            if (docsType == DocType.Permission)
            {
                if (enterLaterCheckB.Checked)
                {
                    return new DataGridViewColumn[] { NUM_RAZRESH, DATE_RAZRESH };
                }
                else
                {
                    return new DataGridViewColumn[] { NUM_RAZRESH, DATE_RAZRESH, TICKET_NUM, TICKET_DATE };
                }
            }
            if (docsType == DocType.Ticket)
            {
                return new DataGridViewColumn[] { TICKET_NUM, TICKET_DATE };
            }

            return null;
        }
        private void enterLaterCheckB_CheckedChanged(object sender, EventArgs e)
        {
            if (enterLaterCheckB.Checked == true)
            {
                dgvDocs.DisableColumn(this.TICKET_NUM);
                dgvDocs.DisableColumn(this.TICKET_DATE);
            }
            else
            {
                dgvDocs.EnableColumn(this.TICKET_NUM);
                dgvDocs.EnableColumn(this.TICKET_DATE);
            }
        }

        private void dgvDocs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDocs.Columns[e.ColumnIndex] is DataGridViewCalendarColumn && e.Button == MouseButtons.Right && e.RowIndex < dgvDocs.RowCount && e.RowIndex >= 0)
            // if ((e.ColumnIndex == 1 || (e.ColumnIndex == 3 && !enterLaterCheckB.Checked)) && e.RowIndex < dgvDocs.RowCount && e.RowIndex >= 0)
            {
                dgvDocs.CurrentCell = dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvDocs.ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                dgvDocs.ContextMenuStrip = null;
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    dgvDocs.CurrentCell = dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void dgvDocs_MouseDown(object sender, MouseEventArgs e)
        {
            dgvDocs.ContextMenuStrip = null;
        }

        private void однаДатаДляВсехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDocs.Rows)
            {
                if (item.Cells[0].Value != null)
                    item.Cells[dgvDocs.CurrentCell.ColumnIndex].Value = dgvDocs.CurrentCell.Value;
            }
        }
        private void очиститьЗначениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDocs.CurrentCell.Value = null;
        }

        private void costCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (costCB.SelectedIndex == 0)
            {
                dgvDocs.CellValueChanged -= dgvDocs_CellValueChanged;
                dgvDocs.DisableColumn(this.DATE_CHARGE);
                costTB.Text = "0";
                costTB.Enabled = false;
                dgvDocs.CellValueChanged += dgvDocs_CellValueChanged;
            }
            if (costCB.SelectedIndex == 1)
            {
                dgvDocs.EnableColumn(this.DATE_CHARGE);
                costTB.Text = "";
                costTB.Enabled = true;
                // formCreateDocs?.ChangeCostType(CostType.Chargeable);
                costTB.Focus();
            }
        }

        private void costTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void dgvDocs_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;

            if (tb != null)
                tb.TextChanged += tb_KeyPress;
        }
        void tb_KeyPress(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentCell.OwningColumn.Name != "NUM_RAZRESH" && dgvDocs.EditingControl.Text == "/")
            {
                dgvDocs.EditingControl.Text = "12/";
                var tb = (TextBox)sender;
                tb.Select(dgvDocs.EditingControl.Text.Length, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На данной форме есть несколько механизмов для быстрого заполнения данных о документе:\n" +
                                "- Быстрое заполнение номеров разрешений: в первой ячейке первого столбца вы можете ввести любой диапазон номеров разрешений и нажмите Enter." +
                                "Например: 115,117,120-125,127.\n\n" +
                                "- Быстрое заполнение номера обращения, имеющего тип 12/xxx.\nДля этого просто введите в поле ввода номера обращения символ /. \n\n" +
                                "- Растягивание одной даты на все имеющиеся строки. Для этого нажмите правой кнопкой по введенной дате и нажмите Одна дата для всех."
                                , "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
