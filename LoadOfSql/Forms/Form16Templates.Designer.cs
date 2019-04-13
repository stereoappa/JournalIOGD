namespace LoadOfSql.Forms
{
    partial class Form16Templates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form16Templates));
            this.templateTypesCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.templateLoadedInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // templateTypesCB
            // 
            this.templateTypesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateTypesCB.FormattingEnabled = true;
            this.templateTypesCB.Location = new System.Drawing.Point(135, 17);
            this.templateTypesCB.Name = "templateTypesCB";
            this.templateTypesCB.Size = new System.Drawing.Size(287, 21);
            this.templateTypesCB.TabIndex = 0;
            this.templateTypesCB.SelectedIndexChanged += new System.EventHandler(this.actualTemplatesCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Актуальные шаблоны";
            // 
            // loadBtn
            // 
            this.loadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadBtn.Enabled = false;
            this.loadBtn.Location = new System.Drawing.Point(15, 85);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(155, 29);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Загрузить новую версию";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadBtn.Enabled = false;
            this.downloadBtn.Location = new System.Drawing.Point(335, 87);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(87, 27);
            this.downloadBtn.TabIndex = 3;
            this.downloadBtn.Text = "Скачать";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // templateLoadedInfoLabel
            // 
            this.templateLoadedInfoLabel.AutoSize = true;
            this.templateLoadedInfoLabel.Location = new System.Drawing.Point(135, 44);
            this.templateLoadedInfoLabel.Name = "templateLoadedInfoLabel";
            this.templateLoadedInfoLabel.Size = new System.Drawing.Size(19, 13);
            this.templateLoadedInfoLabel.TabIndex = 4;
            this.templateLoadedInfoLabel.Text = "<>";
            // 
            // Form16Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 126);
            this.Controls.Add(this.templateLoadedInfoLabel);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.templateTypesCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form16Templates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор шаблонов";
            this.Load += new System.EventHandler(this.Form16Templates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox templateTypesCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Label templateLoadedInfoLabel;
    }
}