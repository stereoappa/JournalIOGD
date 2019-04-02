namespace LoadOfSql
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.SaveItem = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.employCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.memoTB = new System.Windows.Forms.TextBox();
            this.organizationsCB = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.clientsCB = new System.Windows.Forms.ComboBox();
            this.typeDocCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.costTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editClientBtn = new System.Windows.Forms.Button();
            this.topClientCheckB = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.templateCheckB = new System.Windows.Forms.CheckBox();
            this.templateCB = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveItem
            // 
            this.SaveItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveItem.Location = new System.Drawing.Point(249, 468);
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(152, 40);
            this.SaveItem.TabIndex = 2;
            this.SaveItem.Text = "Создать запись";
            this.SaveItem.UseVisualStyleBackColor = true;
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox3.Location = new System.Drawing.Point(239, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дата выдачи материалов";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "В электронном виде";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(240, 154);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(146, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "На бумажном носителе";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // employCB
            // 
            this.employCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.employCB.Enabled = false;
            this.employCB.FormattingEnabled = true;
            this.employCB.Location = new System.Drawing.Point(21, 26);
            this.employCB.Name = "employCB";
            this.employCB.Size = new System.Drawing.Size(158, 21);
            this.employCB.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Исполнитель";
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(18, 468);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(122, 17);
            this.checkBox3.TabIndex = 19;
            this.checkBox3.Text = "Вывести на печать";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // memoTB
            // 
            this.memoTB.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memoTB.Location = new System.Drawing.Point(6, 42);
            this.memoTB.Multiline = true;
            this.memoTB.Name = "memoTB";
            this.memoTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoTB.Size = new System.Drawing.Size(377, 106);
            this.memoTB.TabIndex = 8;
            // 
            // organizationsCB
            // 
            this.organizationsCB.Enabled = false;
            this.organizationsCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organizationsCB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.organizationsCB.FormattingEnabled = true;
            this.organizationsCB.IntegralHeight = false;
            this.organizationsCB.Location = new System.Drawing.Point(9, 42);
            this.organizationsCB.Name = "organizationsCB";
            this.organizationsCB.Size = new System.Drawing.Size(374, 21);
            this.organizationsCB.TabIndex = 0;
            this.organizationsCB.SelectedIndexChanged += new System.EventHandler(this.organizationsCB_SelectedIndexChanged);
            this.organizationsCB.TextUpdate += new System.EventHandler(this.organizationsCB_TextUpdate);
            this.organizationsCB.TextChanged += new System.EventHandler(this.organizationsCB_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "Организация";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(227, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Частное лицо";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // clientsCB
            // 
            this.clientsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientsCB.Enabled = false;
            this.clientsCB.FormattingEnabled = true;
            this.clientsCB.Location = new System.Drawing.Point(9, 70);
            this.clientsCB.Name = "clientsCB";
            this.clientsCB.Size = new System.Drawing.Size(272, 21);
            this.clientsCB.TabIndex = 17;
            this.clientsCB.SelectedIndexChanged += new System.EventHandler(this.clientsCB_SelectedIndexChanged);
            // 
            // typeDocCB
            // 
            this.typeDocCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDocCB.FormattingEnabled = true;
            this.typeDocCB.Location = new System.Drawing.Point(203, 17);
            this.typeDocCB.Name = "typeDocCB";
            this.typeDocCB.Size = new System.Drawing.Size(180, 21);
            this.typeDocCB.TabIndex = 1;
            this.typeDocCB.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.costTB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.typeDocCB);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 91);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Документы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Тип прикрепляемых документов:";
            // 
            // costTB
            // 
            this.costTB.Enabled = false;
            this.costTB.Location = new System.Drawing.Point(281, 62);
            this.costTB.MaxLength = 12;
            this.costTB.Name = "costTB";
            this.costTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.costTB.Size = new System.Drawing.Size(52, 20);
            this.costTB.TabIndex = 20;
            this.costTB.Text = "0";
            this.costTB.Visible = false;
            this.costTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "руб.";
            this.label9.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(278, 44);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "На сумму:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Прикреплено:";
            this.label6.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.editClientBtn);
            this.groupBox2.Controls.Add(this.topClientCheckB);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.organizationsCB);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.clientsCB);
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 122);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сведения о клиенте";
            // 
            // editClientBtn
            // 
            this.editClientBtn.BackgroundImage = global::LoadOfSql.Properties.Resources.edit_9968;
            this.editClientBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editClientBtn.Location = new System.Drawing.Point(289, 67);
            this.editClientBtn.Name = "editClientBtn";
            this.editClientBtn.Size = new System.Drawing.Size(26, 26);
            this.editClientBtn.TabIndex = 23;
            this.editClientBtn.UseVisualStyleBackColor = true;
            this.editClientBtn.Click += new System.EventHandler(this.editClientBtn_Click);
            // 
            // topClientCheckB
            // 
            this.topClientCheckB.AutoSize = true;
            this.topClientCheckB.Location = new System.Drawing.Point(9, 98);
            this.topClientCheckB.Name = "topClientCheckB";
            this.topClientCheckB.Size = new System.Drawing.Size(167, 17);
            this.topClientCheckB.TabIndex = 19;
            this.topClientCheckB.Text = "Клиент является основным";
            this.topClientCheckB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LoadOfSql.Properties.Resources.edit_add_3186;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(317, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.templateCheckB);
            this.groupBox3.Controls.Add(this.templateCB);
            this.groupBox3.Controls.Add(this.memoTB);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 179);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подробно";
            // 
            // templateCheckB
            // 
            this.templateCheckB.AutoSize = true;
            this.templateCheckB.Location = new System.Drawing.Point(9, 17);
            this.templateCheckB.Name = "templateCheckB";
            this.templateCheckB.Size = new System.Drawing.Size(132, 17);
            this.templateCheckB.TabIndex = 23;
            this.templateCheckB.Text = "Создать по шаблону:";
            this.templateCheckB.UseVisualStyleBackColor = true;
            this.templateCheckB.CheckedChanged += new System.EventHandler(this.templateCheckB_CheckedChanged);
            // 
            // templateCB
            // 
            this.templateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateCB.Enabled = false;
            this.templateCB.FormattingEnabled = true;
            this.templateCB.Location = new System.Drawing.Point(147, 15);
            this.templateCB.Name = "templateCB";
            this.templateCB.Size = new System.Drawing.Size(236, 21);
            this.templateCB.TabIndex = 13;
            this.templateCB.SelectedIndexChanged += new System.EventHandler(this.templateCB_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 516);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.employCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.SaveItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание новой записи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox employCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox memoTB;
        private System.Windows.Forms.ComboBox organizationsCB;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox clientsCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox typeDocCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox templateCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox costTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox templateCheckB;
        private System.Windows.Forms.CheckBox topClientCheckB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editClientBtn;
    }
}