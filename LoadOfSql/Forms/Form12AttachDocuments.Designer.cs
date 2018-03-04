namespace LoadOfSql
{
    partial class Form12AttachDocuments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12AttachDocuments));
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.btnSaveDocs = new System.Windows.Forms.Button();
            this.enterLaterCheckB = new System.Windows.Forms.CheckBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.однаДатаДляВсехToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.очиститьЗначениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BOOL_CHARGE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.costTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.costCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NUM_RAZRESH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_RAZRESH = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.TICKET_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TICKET_DATE = new System.Windows.Forms.DataGridViewCalendarColumn();
            this.DATE_CHARGE = new System.Windows.Forms.DataGridViewCalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocs
            // 
            this.dgvDocs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Location = new System.Drawing.Point(12, 34);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.Size = new System.Drawing.Size(457, 136);
            this.dgvDocs.TabIndex = 0;
            this.dgvDocs.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocs_CellMouseDown);
            this.dgvDocs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellValueChanged);
            this.dgvDocs.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDocs_EditingControlShowing);
            this.dgvDocs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDocs_MouseDown);
            // 
            // btnSaveDocs
            // 
            this.btnSaveDocs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDocs.Location = new System.Drawing.Point(357, 176);
            this.btnSaveDocs.Name = "btnSaveDocs";
            this.btnSaveDocs.Size = new System.Drawing.Size(112, 35);
            this.btnSaveDocs.TabIndex = 1;
            this.btnSaveDocs.Text = "Прикрепить";
            this.btnSaveDocs.UseVisualStyleBackColor = true;
            this.btnSaveDocs.Click += new System.EventHandler(this.btnSaveDocs_Click);
            // 
            // enterLaterCheckB
            // 
            this.enterLaterCheckB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterLaterCheckB.AutoSize = true;
            this.enterLaterCheckB.Location = new System.Drawing.Point(207, 11);
            this.enterLaterCheckB.Name = "enterLaterCheckB";
            this.enterLaterCheckB.Size = new System.Drawing.Size(215, 17);
            this.enterLaterCheckB.TabIndex = 2;
            this.enterLaterCheckB.Text = "Ввести реквизиты обращений позже";
            this.enterLaterCheckB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enterLaterCheckB.UseVisualStyleBackColor = false;
            this.enterLaterCheckB.CheckedChanged += new System.EventHandler(this.enterLaterCheckB_CheckedChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.errorLabel.Location = new System.Drawing.Point(9, 203);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(208, 15);
            this.errorLabel.TabIndex = 3;
            this.errorLabel.Text = "Заполните все необходимые поля";
            this.errorLabel.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.однаДатаДляВсехToolStripMenuItem,
            this.toolStripSeparator1,
            this.очиститьЗначениеToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 54);
            // 
            // однаДатаДляВсехToolStripMenuItem
            // 
            this.однаДатаДляВсехToolStripMenuItem.Name = "однаДатаДляВсехToolStripMenuItem";
            this.однаДатаДляВсехToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.однаДатаДляВсехToolStripMenuItem.Text = "Одна дата для всех..";
            this.однаДатаДляВсехToolStripMenuItem.Click += new System.EventHandler(this.однаДатаДляВсехToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // очиститьЗначениеToolStripMenuItem
            // 
            this.очиститьЗначениеToolStripMenuItem.Name = "очиститьЗначениеToolStripMenuItem";
            this.очиститьЗначениеToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.очиститьЗначениеToolStripMenuItem.Text = "Очистить дату..";
            this.очиститьЗначениеToolStripMenuItem.Click += new System.EventHandler(this.очиститьЗначениеToolStripMenuItem_Click);
            // 
            // BOOL_CHARGE
            // 
            this.BOOL_CHARGE.Name = "BOOL_CHARGE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Стоимость:";
            // 
            // costTB
            // 
            this.costTB.Location = new System.Drawing.Point(162, 177);
            this.costTB.MaxLength = 12;
            this.costTB.Name = "costTB";
            this.costTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.costTB.Size = new System.Drawing.Size(64, 20);
            this.costTB.TabIndex = 29;
            this.costTB.Text = "0";
            this.costTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.costTB_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "руб.";
            // 
            // costCB
            // 
            this.costCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.costCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.costCB.FormattingEnabled = true;
            this.costCB.Location = new System.Drawing.Point(77, 176);
            this.costCB.Name = "costCB";
            this.costCB.Size = new System.Drawing.Size(78, 21);
            this.costCB.TabIndex = 26;
            costCB.Items.AddRange(new string[] { "бесплатно", "платно" });
            this.costCB.SelectedIndexChanged += new System.EventHandler(this.costCB_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(444, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 30;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NUM_RAZRESH
            // 
            this.NUM_RAZRESH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NUM_RAZRESH.HeaderText = "Номер разрешения";
            this.NUM_RAZRESH.Name = "NUM_RAZRESH";
            // 
            // DATE_RAZRESH
            // 
            this.DATE_RAZRESH.HeaderText = "Дата разрешения";
            this.DATE_RAZRESH.Name = "DATE_RAZRESH";
            this.DATE_RAZRESH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TICKET_NUM
            // 
            this.TICKET_NUM.HeaderText = "Номер обращения";
            this.TICKET_NUM.Name = "TICKET_NUM";
            // 
            // TICKET_DATE
            // 
            this.TICKET_DATE.HeaderText = "Дата обращения";
            this.TICKET_DATE.Name = "TICKET_DATE";
            this.TICKET_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DATE_CHARGE
            // 
            this.DATE_CHARGE.HeaderText = "Дата оплаты";
            this.DATE_CHARGE.Name = "DATE_CHARGE";
            // 
            // Form12AttachDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enterLaterCheckB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.costTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.costCB);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.btnSaveDocs);
            this.Controls.Add(this.dgvDocs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form12AttachDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прикрепление документов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form12AttachDocuments_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.Button btnSaveDocs;
       // private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
       // private System.Windows.Forms.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
       // private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
       // private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM_RAZRESH;
        private System.Windows.Forms.DataGridViewCalendarColumn DATE_RAZRESH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TICKET_NUM;
        private System.Windows.Forms.DataGridViewCalendarColumn TICKET_DATE;
        private System.Windows.Forms.DataGridViewCalendarColumn DATE_CHARGE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BOOL_CHARGE;
        private System.Windows.Forms.CheckBox enterLaterCheckB;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem однаДатаДляВсехToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox costTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox costCB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem очиститьЗначениеToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}