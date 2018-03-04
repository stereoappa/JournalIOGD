namespace LoadOfSql
{
    partial class Form3Editing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3Editing));
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.memoTB = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.typeDocCB = new System.Windows.Forms.ComboBox();
            this.organizationsCB = new System.Windows.Forms.ComboBox();
            this.SaveEditingBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clientsCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.costTBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editClientBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.templateCheckB = new System.Windows.Forms.CheckBox();
            this.templateCB = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Исполнитель";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(18, 23);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(158, 21);
            this.comboBox3.TabIndex = 31;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(237, 163);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(146, 17);
            this.checkBox2.TabIndex = 28;
            this.checkBox2.Text = "На бумажном носителе";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 163);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "В электронном виде";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Дата выдачи материала";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(236, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 25;
            // 
            // memoTB
            // 
            this.memoTB.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memoTB.Location = new System.Drawing.Point(10, 45);
            this.memoTB.Multiline = true;
            this.memoTB.Name = "memoTB";
            this.memoTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoTB.Size = new System.Drawing.Size(370, 112);
            this.memoTB.TabIndex = 24;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(227, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.Text = "Частное лицо";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.Text = "Организация";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // typeDocCB
            // 
            this.typeDocCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDocCB.FormattingEnabled = true;
            this.typeDocCB.Location = new System.Drawing.Point(197, 17);
            this.typeDocCB.Name = "typeDocCB";
            this.typeDocCB.Size = new System.Drawing.Size(183, 21);
            this.typeDocCB.TabIndex = 18;
            // 
            // organizationsCB
            // 
            this.organizationsCB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.organizationsCB.FormattingEnabled = true;
            this.organizationsCB.IntegralHeight = false;
            this.organizationsCB.Location = new System.Drawing.Point(6, 42);
            this.organizationsCB.Name = "organizationsCB";
            this.organizationsCB.Size = new System.Drawing.Size(377, 21);
            this.organizationsCB.TabIndex = 17;
            this.organizationsCB.SelectedIndexChanged += new System.EventHandler(this.organizationCB_SelectedIndexChanged);
            this.organizationsCB.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            this.organizationsCB.TextChanged += new System.EventHandler(this.organizationCB_TextChanged);
            // 
            // SaveEditingBtn
            // 
            this.SaveEditingBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveEditingBtn.Location = new System.Drawing.Point(249, 449);
            this.SaveEditingBtn.Name = "SaveEditingBtn";
            this.SaveEditingBtn.Size = new System.Drawing.Size(152, 40);
            this.SaveEditingBtn.TabIndex = 33;
            this.SaveEditingBtn.Text = "Изменить";
            this.SaveEditingBtn.UseVisualStyleBackColor = true;
            this.SaveEditingBtn.Click += new System.EventHandler(this.SaveEditingBtn_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LoadOfSql.Properties.Resources.edit_add_3186;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(313, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 35;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clientsCB
            // 
            this.clientsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientsCB.FormattingEnabled = true;
            this.clientsCB.Location = new System.Drawing.Point(6, 69);
            this.clientsCB.Name = "clientsCB";
            this.clientsCB.Size = new System.Drawing.Size(272, 21);
            this.clientsCB.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.typeDocCB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.costTBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 88);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Документы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "На сумму:";
            this.label7.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Тип прикрепляемых документов:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(271, 43);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 32;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Прикреплено:";
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "руб.";
            this.label6.Visible = false;
            // 
            // costTBox
            // 
            this.costTBox.Enabled = false;
            this.costTBox.Location = new System.Drawing.Point(274, 61);
            this.costTBox.MaxLength = 12;
            this.costTBox.Name = "costTBox";
            this.costTBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.costTBox.Size = new System.Drawing.Size(58, 20);
            this.costTBox.TabIndex = 28;
            this.costTBox.Visible = false;
            this.costTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editClientBtn);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.organizationsCB);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.clientsCB);
            this.groupBox2.Location = new System.Drawing.Point(12, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 100);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сведения о клиенте";
            // 
            // editClientBtn
            // 
            this.editClientBtn.BackgroundImage = global::LoadOfSql.Properties.Resources.edit_9968;
            this.editClientBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editClientBtn.Location = new System.Drawing.Point(284, 66);
            this.editClientBtn.Name = "editClientBtn";
            this.editClientBtn.Size = new System.Drawing.Size(26, 26);
            this.editClientBtn.TabIndex = 39;
            this.editClientBtn.UseVisualStyleBackColor = true;
            this.editClientBtn.Click += new System.EventHandler(this.editClientBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.templateCheckB);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.templateCB);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.memoTB);
            this.groupBox3.Location = new System.Drawing.Point(12, 251);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 187);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подробно";
            // 
            // templateCheckB
            // 
            this.templateCheckB.AutoSize = true;
            this.templateCheckB.Location = new System.Drawing.Point(10, 20);
            this.templateCheckB.Name = "templateCheckB";
            this.templateCheckB.Size = new System.Drawing.Size(141, 17);
            this.templateCheckB.TabIndex = 30;
            this.templateCheckB.Text = "Изменить по шаблону:";
            this.templateCheckB.UseVisualStyleBackColor = true;
            this.templateCheckB.CheckedChanged += new System.EventHandler(this.templateCheckB_CheckedChanged);
            // 
            // templateCB
            // 
            this.templateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateCB.Enabled = false;
            this.templateCB.FormattingEnabled = true;
            this.templateCB.Location = new System.Drawing.Point(157, 18);
            this.templateCB.Name = "templateCB";
            this.templateCB.Size = new System.Drawing.Size(223, 21);
            this.templateCB.TabIndex = 25;
            this.templateCB.SelectedIndexChanged += new System.EventHandler(this.templateCB_SelectedIndexChanged);
            // 
            // Form3Editing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveEditingBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3Editing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование записи";
            this.Load += new System.EventHandler(this.Form3Editing_Load);
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

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox memoTB;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox typeDocCB;
        private System.Windows.Forms.ComboBox organizationsCB;
        private System.Windows.Forms.Button SaveEditingBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox clientsCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox templateCheckB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox costTBox;
        private System.Windows.Forms.ComboBox templateCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editClientBtn;
    }
}