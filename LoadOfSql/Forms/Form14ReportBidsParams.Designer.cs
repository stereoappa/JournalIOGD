namespace LoadOfSql
{
    partial class Form14ReportBidsParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14ReportBidsParams));
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.datePeriod = new System.Windows.Forms.DateTimePicker();
            this.idPeriod = new System.Windows.Forms.NumericUpDown();
            this.startNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.idPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(90, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(105, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Начиная с даты";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(118, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Начиная с номера";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // datePeriod
            // 
            this.datePeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePeriod.Location = new System.Drawing.Point(134, 22);
            this.datePeriod.MinDate = new System.DateTime(2017, 3, 12, 0, 0, 0, 0);
            this.datePeriod.Name = "datePeriod";
            this.datePeriod.Size = new System.Drawing.Size(121, 20);
            this.datePeriod.TabIndex = 3;
            this.datePeriod.Value = new System.DateTime(2017, 3, 12, 0, 0, 0, 0);
            // 
            // idPeriod
            // 
            this.idPeriod.Location = new System.Drawing.Point(134, 54);
            this.idPeriod.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.idPeriod.Minimum = new decimal(new int[] {
            16786,
            0,
            0,
            0});
            this.idPeriod.Name = "idPeriod";
            this.idPeriod.Size = new System.Drawing.Size(121, 20);
            this.idPeriod.TabIndex = 4;
            this.idPeriod.Value = new decimal(new int[] {
            16786,
            0,
            0,
            0});
            // 
            // startNumber
            // 
            this.startNumber.Location = new System.Drawing.Point(146, 112);
            this.startNumber.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.startNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNumber.Name = "startNumber";
            this.startNumber.Size = new System.Drawing.Size(121, 20);
            this.startNumber.TabIndex = 5;
            this.startNumber.Value = new decimal(new int[] {
            15238,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Нумерация начнется с";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.datePeriod);
            this.groupBox1.Controls.Add(this.idPeriod);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 86);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период формирования отчета";
            // 
            // Form14ReportBidsParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 188);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startNumber);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form14ReportBidsParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры запроса";
            ((System.ComponentModel.ISupportInitialize)(this.idPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DateTimePicker datePeriod;
        private System.Windows.Forms.NumericUpDown idPeriod;
        private System.Windows.Forms.NumericUpDown startNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}