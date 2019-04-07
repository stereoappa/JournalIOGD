namespace LoadOfSql.Forms
{
    partial class Form15EmployeesAndSigns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15EmployeesAndSigns));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPostEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThirdNameEdit = new System.Windows.Forms.Button();
            this.btnFirstNameEdit = new System.Windows.Forms.Button();
            this.btnSecondNameEdit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmployees = new System.Windows.Forms.ComboBox();
            this.tbPostName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbThirdName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 308);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPostEdit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnThirdNameEdit);
            this.groupBox1.Controls.Add(this.btnFirstNameEdit);
            this.groupBox1.Controls.Add(this.btnSecondNameEdit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnAddEmployee);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbEmployees);
            this.groupBox1.Controls.Add(this.tbPostName);
            this.groupBox1.Controls.Add(this.tbSecondName);
            this.groupBox1.Controls.Add(this.tbThirdName);
            this.groupBox1.Controls.Add(this.tbFirstName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 308);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Персональные данные";
            // 
            // btnPostEdit
            // 
            this.btnPostEdit.BackgroundImage = global::LoadOfSql.Properties.Resources.pencil;
            this.btnPostEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPostEdit.Location = new System.Drawing.Point(288, 79);
            this.btnPostEdit.Name = "btnPostEdit";
            this.btnPostEdit.Size = new System.Drawing.Size(22, 22);
            this.btnPostEdit.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnPostEdit, "Редактировать должность");
            this.btnPostEdit.UseVisualStyleBackColor = true;
            this.btnPostEdit.Click += new System.EventHandler(this.btnPostEdit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Подпись";
            // 
            // btnThirdNameEdit
            // 
            this.btnThirdNameEdit.BackgroundImage = global::LoadOfSql.Properties.Resources.pencil;
            this.btnThirdNameEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnThirdNameEdit.Location = new System.Drawing.Point(153, 202);
            this.btnThirdNameEdit.Name = "btnThirdNameEdit";
            this.btnThirdNameEdit.Size = new System.Drawing.Size(22, 22);
            this.btnThirdNameEdit.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnThirdNameEdit, "Редактировать отчество");
            this.btnThirdNameEdit.UseVisualStyleBackColor = true;
            this.btnThirdNameEdit.Click += new System.EventHandler(this.btnThirdNameEdit_Click);
            // 
            // btnFirstNameEdit
            // 
            this.btnFirstNameEdit.BackgroundImage = global::LoadOfSql.Properties.Resources.pencil;
            this.btnFirstNameEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFirstNameEdit.Location = new System.Drawing.Point(153, 161);
            this.btnFirstNameEdit.Name = "btnFirstNameEdit";
            this.btnFirstNameEdit.Size = new System.Drawing.Size(22, 22);
            this.btnFirstNameEdit.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnFirstNameEdit, "Редактировать имя");
            this.btnFirstNameEdit.UseVisualStyleBackColor = true;
            this.btnFirstNameEdit.Click += new System.EventHandler(this.btnFirstNameEdit_Click);
            // 
            // btnSecondNameEdit
            // 
            this.btnSecondNameEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnSecondNameEdit.BackgroundImage = global::LoadOfSql.Properties.Resources.pencil;
            this.btnSecondNameEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSecondNameEdit.FlatAppearance.BorderSize = 0;
            this.btnSecondNameEdit.Location = new System.Drawing.Point(153, 121);
            this.btnSecondNameEdit.Name = "btnSecondNameEdit";
            this.btnSecondNameEdit.Size = new System.Drawing.Size(22, 22);
            this.btnSecondNameEdit.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnSecondNameEdit, "Редактировать фамилию");
            this.btnSecondNameEdit.UseVisualStyleBackColor = false;
            this.btnSecondNameEdit.Click += new System.EventHandler(this.btnSecondNameEdit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Должность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Отчество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Фамилия";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::LoadOfSql.Properties.Resources.image__1_;
            this.pictureBox1.Location = new System.Drawing.Point(200, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Добавить изображение подписи");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(228, 35);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(82, 23);
            this.btnAddEmployee.TabIndex = 7;
            this.btnAddEmployee.Text = "Добавить";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователь:";
            // 
            // cbEmployees
            // 
            this.cbEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployees.FormattingEnabled = true;
            this.cbEmployees.Location = new System.Drawing.Point(12, 36);
            this.cbEmployees.Name = "cbEmployees";
            this.cbEmployees.Size = new System.Drawing.Size(210, 21);
            this.cbEmployees.TabIndex = 0;
            this.cbEmployees.SelectedValueChanged += new System.EventHandler(this.cbEmployees_SelectedValueChanged);
            // 
            // tbPostName
            // 
            this.tbPostName.Location = new System.Drawing.Point(12, 80);
            this.tbPostName.Name = "tbPostName";
            this.tbPostName.ReadOnly = true;
            this.tbPostName.Size = new System.Drawing.Size(298, 20);
            this.tbPostName.TabIndex = 5;
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(12, 122);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.ReadOnly = true;
            this.tbSecondName.Size = new System.Drawing.Size(163, 20);
            this.tbSecondName.TabIndex = 2;
            // 
            // tbThirdName
            // 
            this.tbThirdName.Location = new System.Drawing.Point(12, 203);
            this.tbThirdName.Name = "tbThirdName";
            this.tbThirdName.ReadOnly = true;
            this.tbThirdName.Size = new System.Drawing.Size(163, 20);
            this.tbThirdName.TabIndex = 4;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(12, 162);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(163, 20);
            this.tbFirstName.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 61);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Учетные данные";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(200, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 26);
            this.button5.TabIndex = 0;
            this.button5.Text = "Сменить пароль";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form15EmployeesAndSigns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 308);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form15EmployeesAndSigns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор сотрудников";
            this.Load += new System.EventHandler(this.Form15EmployeesAndSigns_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEmployees;
        private System.Windows.Forms.TextBox tbPostName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.TextBox tbThirdName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Button btnPostEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThirdNameEdit;
        private System.Windows.Forms.Button btnFirstNameEdit;
        private System.Windows.Forms.Button btnSecondNameEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}