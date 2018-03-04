namespace LoadOfSql
{
    partial class Form5SQLQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5SQLQuery));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.costCheckB = new System.Windows.Forms.CheckBox();
            this.costSign = new System.Windows.Forms.ComboBox();
            this.costTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.costRBcharge = new System.Windows.Forms.RadioButton();
            this.costRBfree = new System.Windows.Forms.RadioButton();
            this.dateChargeCheckB = new System.Windows.Forms.CheckBox();
            this.groupBoxCharge = new System.Windows.Forms.GroupBox();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateChargeIntervalDateRadio = new System.Windows.Forms.RadioButton();
            this.dateChargeExactDateRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(112, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(317, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Новый запрос";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(112, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Сотрудник";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 82);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(93, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Организация";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(14, 115);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 17);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Клиент";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(114, 367);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(317, 49);
            this.textBox1.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(112, 113);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(317, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(13, 382);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(92, 17);
            this.checkBox4.TabIndex = 10;
            this.checkBox4.Text = "Информация";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(113, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата выдачи";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(218, 39);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker3.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(101, 39);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "---";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(89, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Промежуток";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Точная дата";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(13, 319);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(92, 17);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "Дата выдачи";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(14, 48);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(77, 17);
            this.checkBox6.TabIndex = 16;
            this.checkBox6.Text = "Документ";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(112, 47);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(157, 21);
            this.comboBox4.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(221, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 34);
            this.button2.TabIndex = 18;
            this.button2.Text = "Показать все";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // costCheckB
            // 
            this.costCheckB.AutoSize = true;
            this.costCheckB.Location = new System.Drawing.Point(13, 243);
            this.costCheckB.Name = "costCheckB";
            this.costCheckB.Size = new System.Drawing.Size(81, 17);
            this.costCheckB.TabIndex = 19;
            this.costCheckB.Text = "Стоимость";
            this.costCheckB.UseVisualStyleBackColor = true;
            this.costCheckB.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // costSign
            // 
            this.costSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.costSign.Enabled = false;
            this.costSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.costSign.FormattingEnabled = true;
            this.costSign.Location = new System.Drawing.Point(101, 17);
            this.costSign.Name = "costSign";
            this.costSign.Size = new System.Drawing.Size(57, 21);
            this.costSign.TabIndex = 20;
            // 
            // costTB
            // 
            this.costTB.Enabled = false;
            this.costTB.Location = new System.Drawing.Point(164, 17);
            this.costTB.Name = "costTB";
            this.costTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.costTB.Size = new System.Drawing.Size(100, 20);
            this.costTB.TabIndex = 21;
            this.costTB.Text = "0";
            this.costTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(268, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "рублей";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.costRBcharge);
            this.groupBox2.Controls.Add(this.costRBfree);
            this.groupBox2.Controls.Add(this.costSign);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.costTB);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(113, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 69);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Стоимость";
            // 
            // costRBcharge
            // 
            this.costRBcharge.AutoSize = true;
            this.costRBcharge.Location = new System.Drawing.Point(6, 18);
            this.costRBcharge.Name = "costRBcharge";
            this.costRBcharge.Size = new System.Drawing.Size(62, 17);
            this.costRBcharge.TabIndex = 24;
            this.costRBcharge.TabStop = true;
            this.costRBcharge.Text = "Платно";
            this.costRBcharge.UseVisualStyleBackColor = true;
            this.costRBcharge.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // costRBfree
            // 
            this.costRBfree.AutoSize = true;
            this.costRBfree.Location = new System.Drawing.Point(6, 41);
            this.costRBfree.Name = "costRBfree";
            this.costRBfree.Size = new System.Drawing.Size(79, 17);
            this.costRBfree.TabIndex = 23;
            this.costRBfree.TabStop = true;
            this.costRBfree.Text = "Бесплатно";
            this.costRBfree.UseVisualStyleBackColor = true;
            this.costRBfree.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // dateChargeCheckB
            // 
            this.dateChargeCheckB.AutoSize = true;
            this.dateChargeCheckB.Location = new System.Drawing.Point(12, 169);
            this.dateChargeCheckB.Name = "dateChargeCheckB";
            this.dateChargeCheckB.Size = new System.Drawing.Size(92, 17);
            this.dateChargeCheckB.TabIndex = 24;
            this.dateChargeCheckB.Text = "Дата оплаты";
            this.dateChargeCheckB.UseVisualStyleBackColor = true;
            this.dateChargeCheckB.CheckedChanged += new System.EventHandler(this.dateChargeCheckB_CheckedChanged);
            // 
            // groupBoxCharge
            // 
            this.groupBoxCharge.Controls.Add(this.dateTimePicker6);
            this.groupBoxCharge.Controls.Add(this.label3);
            this.groupBoxCharge.Controls.Add(this.dateTimePicker5);
            this.groupBoxCharge.Controls.Add(this.dateTimePicker4);
            this.groupBoxCharge.Controls.Add(this.dateChargeIntervalDateRadio);
            this.groupBoxCharge.Controls.Add(this.dateChargeExactDateRadio);
            this.groupBoxCharge.Enabled = false;
            this.groupBoxCharge.Location = new System.Drawing.Point(114, 140);
            this.groupBoxCharge.Name = "groupBoxCharge";
            this.groupBoxCharge.Size = new System.Drawing.Size(318, 69);
            this.groupBoxCharge.TabIndex = 25;
            this.groupBoxCharge.TabStop = false;
            this.groupBoxCharge.Text = "Дата оплаты";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker6.Location = new System.Drawing.Point(218, 43);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker6.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "---";
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker5.Location = new System.Drawing.Point(100, 43);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker5.TabIndex = 3;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(100, 19);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker4.TabIndex = 2;
            // 
            // dateChargeIntervalDateRadio
            // 
            this.dateChargeIntervalDateRadio.AutoSize = true;
            this.dateChargeIntervalDateRadio.Location = new System.Drawing.Point(7, 43);
            this.dateChargeIntervalDateRadio.Name = "dateChargeIntervalDateRadio";
            this.dateChargeIntervalDateRadio.Size = new System.Drawing.Size(89, 17);
            this.dateChargeIntervalDateRadio.TabIndex = 1;
            this.dateChargeIntervalDateRadio.TabStop = true;
            this.dateChargeIntervalDateRadio.Text = "Промежуток";
            this.dateChargeIntervalDateRadio.UseVisualStyleBackColor = true;
            this.dateChargeIntervalDateRadio.CheckedChanged += new System.EventHandler(this.dateChargeIntervalDateRadio_CheckedChanged);
            // 
            // dateChargeExactDateRadio
            // 
            this.dateChargeExactDateRadio.AutoSize = true;
            this.dateChargeExactDateRadio.Location = new System.Drawing.Point(7, 19);
            this.dateChargeExactDateRadio.Name = "dateChargeExactDateRadio";
            this.dateChargeExactDateRadio.Size = new System.Drawing.Size(87, 17);
            this.dateChargeExactDateRadio.TabIndex = 0;
            this.dateChargeExactDateRadio.TabStop = true;
            this.dateChargeExactDateRadio.Text = "Точная дата";
            this.dateChargeExactDateRadio.UseVisualStyleBackColor = true;
            this.dateChargeExactDateRadio.CheckedChanged += new System.EventHandler(this.dateChargeExactDateRadio_CheckedChanged);
            // 
            // Form5SQLQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 465);
            this.Controls.Add(this.groupBoxCharge);
            this.Controls.Add(this.dateChargeCheckB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.costCheckB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5SQLQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Формирование запроса";
            this.Load += new System.EventHandler(this.Form5SQLQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxCharge.ResumeLayout(false);
            this.groupBoxCharge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox costCheckB;
        private System.Windows.Forms.ComboBox costSign;
        private System.Windows.Forms.TextBox costTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton costRBcharge;
        private System.Windows.Forms.RadioButton costRBfree;
        private System.Windows.Forms.CheckBox dateChargeCheckB;
        private System.Windows.Forms.GroupBox groupBoxCharge;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.RadioButton dateChargeIntervalDateRadio;
        private System.Windows.Forms.RadioButton dateChargeExactDateRadio;
    }
}