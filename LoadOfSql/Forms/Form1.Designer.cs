namespace LoadOfSql
{
    partial class Form1
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
                GlobalSettings.SaveRegistryKeys();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.вывестиНаПечатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиВДокументMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCreateItem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиИПодписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьОрганизациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьОрганизациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.выданныеПланшетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.полученнаяПрибыльToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.книгаУчетаЗаявкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подписьНаДокументахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.goToNumberBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.splitterLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DocNumsLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClientName = new System.Windows.Forms.Label();
            this.InfoType = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.docsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attensionInfoLabel = new System.Windows.Forms.Label();
            this.загрузитьШаблондокументаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(190, 37);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(834, 296);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вывестиНаПечатьToolStripMenuItem,
            this.вывестиВДокументMSWordToolStripMenuItem,
            this.toolStripSeparator1,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 98);
            // 
            // вывестиНаПечатьToolStripMenuItem
            // 
            this.вывестиНаПечатьToolStripMenuItem.Name = "вывестиНаПечатьToolStripMenuItem";
            this.вывестиНаПечатьToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.вывестиНаПечатьToolStripMenuItem.Text = "В до&кумент MS Word..";
            this.вывестиНаПечатьToolStripMenuItem.Click += new System.EventHandler(this.ВдокументMSWordToolStripMenuItem_Click);
            // 
            // вывестиВДокументMSWordToolStripMenuItem
            // 
            this.вывестиВДокументMSWordToolStripMenuItem.Name = "вывестиВДокументMSWordToolStripMenuItem";
            this.вывестиВДокументMSWordToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.вывестиВДокументMSWordToolStripMenuItem.Text = "П&ечать..";
            this.вывестиВДокументMSWordToolStripMenuItem.Click += new System.EventHandler(this.ПечатьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.изменитьToolStripMenuItem.Text = "&Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.удалитьToolStripMenuItem.Text = "&Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // BtnCreateItem
            // 
            this.BtnCreateItem.Location = new System.Drawing.Point(12, 37);
            this.BtnCreateItem.Name = "BtnCreateItem";
            this.BtnCreateItem.Size = new System.Drawing.Size(162, 40);
            this.BtnCreateItem.TabIndex = 1;
            this.BtnCreateItem.Text = "Добавить запись";
            this.BtnCreateItem.UseVisualStyleBackColor = true;
            this.BtnCreateItem.Click += new System.EventHandler(this.BtnCreateItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.параметрыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.добавитьОрганизациюToolStripMenuItem,
            this.переименоватьОрганизациюToolStripMenuItem,
            this.toolStripSeparator7,
            this.выданныеПланшетыToolStripMenuItem,
            this.полученнаяПрибыльToolStripMenuItem,
            this.toolStripSeparator4,
            this.сотрудникиИПодписиToolStripMenuItem,
            this.загрузитьШаблондокументаToolStripMenuItem,
            this.toolStripSeparator8,
            this.отчетыToolStripMenuItem,
            this.toolStripSeparator3,
            this.обновитьToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // сотрудникиИПодписиToolStripMenuItem
            // 
            this.сотрудникиИПодписиToolStripMenuItem.Name = "сотрудникиИПодписиToolStripMenuItem";
            this.сотрудникиИПодписиToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.сотрудникиИПодписиToolStripMenuItem.Text = "С&отрудники и подписи..";
            this.сотрудникиИПодписиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // добавитьОрганизациюToolStripMenuItem
            // 
            this.добавитьОрганизациюToolStripMenuItem.Name = "добавитьОрганизациюToolStripMenuItem";
            this.добавитьОрганизациюToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.добавитьОрганизациюToolStripMenuItem.Text = "Добавить организацию..";
            this.добавитьОрганизациюToolStripMenuItem.Click += new System.EventHandler(this.добавитьОрганизациюToolStripMenuItem_Click);
            // 
            // переименоватьОрганизациюToolStripMenuItem
            // 
            this.переименоватьОрганизациюToolStripMenuItem.Name = "переименоватьОрганизациюToolStripMenuItem";
            this.переименоватьОрганизациюToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.переименоватьОрганизациюToolStripMenuItem.Text = "Переименовать организацию..";
            this.переименоватьОрганизациюToolStripMenuItem.Click += new System.EventHandler(this.переименоватьОрганизациюToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(241, 6);
            // 
            // выданныеПланшетыToolStripMenuItem
            // 
            this.выданныеПланшетыToolStripMenuItem.Name = "выданныеПланшетыToolStripMenuItem";
            this.выданныеПланшетыToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.выданныеПланшетыToolStripMenuItem.Text = "Выданные планшеты..";
            this.выданныеПланшетыToolStripMenuItem.Click += new System.EventHandler(this.выданныеПланшетыToolStripMenuItem_Click);
            // 
            // полученнаяПрибыльToolStripMenuItem
            // 
            this.полученнаяПрибыльToolStripMenuItem.Name = "полученнаяПрибыльToolStripMenuItem";
            this.полученнаяПрибыльToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.полученнаяПрибыльToolStripMenuItem.Text = "Полученная прибыль..";
            this.полученнаяПрибыльToolStripMenuItem.Click += new System.EventHandler(this.полученнаяПрибыльToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(241, 6);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.книгаУчетаЗаявкиToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // книгаУчетаЗаявкиToolStripMenuItem
            // 
            this.книгаУчетаЗаявкиToolStripMenuItem.Name = "книгаУчетаЗаявкиToolStripMenuItem";
            this.книгаУчетаЗаявкиToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.книгаУчетаЗаявкиToolStripMenuItem.Text = "Книга учета: Заявки";
            this.книгаУчетаЗаявкиToolStripMenuItem.Click += new System.EventHandler(this.книгаУчетаЗаявкиToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("обновитьToolStripMenuItem.Image")));
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить..";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подписьНаДокументахToolStripMenuItem,
            this.toolStripSeparator6,
            this.авторизацияToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // подписьНаДокументахToolStripMenuItem
            // 
            this.подписьНаДокументахToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5});
            this.подписьНаДокументахToolStripMenuItem.Name = "подписьНаДокументахToolStripMenuItem";
            this.подписьНаДокументахToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.подписьНаДокументахToolStripMenuItem.Text = "Подпись на документах";
            this.подписьНаДокументахToolStripMenuItem.DropDownOpening += new System.EventHandler(this.подписьНаДокументахToolStripMenuItem_DropDownOpening);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(57, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(201, 6);
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.авторизацияToolStripMenuItem.Text = "Авторизация..";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(190, 337);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(834, 101);
            this.textBox1.TabIndex = 4;
            // 
            // goToNumberBtn
            // 
            this.goToNumberBtn.Location = new System.Drawing.Point(12, 129);
            this.goToNumberBtn.Name = "goToNumberBtn";
            this.goToNumberBtn.Size = new System.Drawing.Size(162, 41);
            this.goToNumberBtn.TabIndex = 8;
            this.goToNumberBtn.Text = "Перейти по номеру";
            this.goToNumberBtn.UseVisualStyleBackColor = true;
            this.goToNumberBtn.Click += new System.EventHandler(this.goToNumberBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 176);
            this.textBox2.MaxLength = 8;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Введите номер:";
            this.label5.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "Запрос";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.splitterLabel);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.DocNumsLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ClientName);
            this.groupBox1.Controls.Add(this.InfoType);
            this.groupBox1.Location = new System.Drawing.Point(0, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 206);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "О документе";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(10, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 2);
            this.label9.TabIndex = 26;
            // 
            // splitterLabel
            // 
            this.splitterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.splitterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitterLabel.Location = new System.Drawing.Point(11, 86);
            this.splitterLabel.Name = "splitterLabel";
            this.splitterLabel.Size = new System.Drawing.Size(145, 2);
            this.splitterLabel.TabIndex = 25;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(106, 184);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 13);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "??";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Стоимость: нет";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Акты об удалении: ";
            // 
            // DocNumsLabel
            // 
            this.DocNumsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DocNumsLabel.Location = new System.Drawing.Point(7, 20);
            this.DocNumsLabel.Name = "DocNumsLabel";
            this.DocNumsLabel.Size = new System.Drawing.Size(172, 45);
            this.DocNumsLabel.TabIndex = 20;
            this.DocNumsLabel.Text = "№ ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Выдано планшетов: 200";
            // 
            // ClientName
            // 
            this.ClientName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ClientName.AutoSize = true;
            this.ClientName.Location = new System.Drawing.Point(7, 93);
            this.ClientName.Name = "ClientName";
            this.ClientName.Size = new System.Drawing.Size(26, 13);
            this.ClientName.TabIndex = 17;
            this.ClientName.Text = "Нет";
            // 
            // InfoType
            // 
            this.InfoType.AllowDrop = true;
            this.InfoType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.InfoType.Location = new System.Drawing.Point(7, 110);
            this.InfoType.Name = "InfoType";
            this.InfoType.Size = new System.Drawing.Size(168, 29);
            this.InfoType.TabIndex = 18;
            this.InfoType.Text = "label2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1036, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel1.Text = "Вход не выполнен! ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel2.Text = " Отображено: ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel3.Text = " Запрос:";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel4.Text = "<статус>";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(682, 17);
            this.toolStripStatusLabel6.Spring = true;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ActiveLinkColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel5.Image = global::LoadOfSql.Properties.Resources.Attenshion;
            this.toolStripStatusLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel5.IsLink = true;
            this.toolStripStatusLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(228, 17);
            this.toolStripStatusLabel5.Text = "Есть частично заполненные записи:  ";
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel5.Visible = false;
            this.toolStripStatusLabel5.Click += new System.EventHandler(this.toolStripStatusLabel5_Click);
            // 
            // attensionInfoLabel
            // 
            this.attensionInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attensionInfoLabel.AutoSize = true;
            this.attensionInfoLabel.BackColor = System.Drawing.SystemColors.Info;
            this.attensionInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attensionInfoLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.attensionInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attensionInfoLabel.Location = new System.Drawing.Point(744, 358);
            this.attensionInfoLabel.Name = "attensionInfoLabel";
            this.attensionInfoLabel.Size = new System.Drawing.Size(90, 17);
            this.attensionInfoLabel.TabIndex = 15;
            this.attensionInfoLabel.Text = "attensionLabel";
            this.attensionInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attensionInfoLabel.Visible = false;
            // 
            // загрузитьШаблондокументаToolStripMenuItem
            // 
            this.загрузитьШаблондокументаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem});
            this.загрузитьШаблондокументаToolStripMenuItem.Name = "загрузитьШаблондокументаToolStripMenuItem";
            this.загрузитьШаблондокументаToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.загрузитьШаблондокументаToolStripMenuItem.Text = "Загрузить шаблон документа..";
            // 
            // загрузитьШаблонОВыдачеИнформацииToolStripMenuItem
            // 
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem.Name = "загрузитьШаблонОВыдачеИнформацииToolStripMenuItem";
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem.Text = "\"О выдаче информации\"";
            this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem.Click += new System.EventHandler(this.загрузитьШаблонОВыдачеИнформацииToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(241, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 464);
            this.Controls.Add(this.attensionInfoLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.goToNumberBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnCreateItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 475);
            this.Name = "Form1";
            this.Text = "Журнал выданной информации ИОГД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button BtnCreateItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьОрганизациюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button goToNumberBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вывестиНаПечатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem вывестиВДокументMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выданныеПланшетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem полученнаяПрибыльToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьОрганизациюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.BindingSource docsBindingSource;
        private System.Windows.Forms.ToolStripMenuItem книгаУчетаЗаявкиToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DocNumsLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ClientName;
        private System.Windows.Forms.Label InfoType;
        private System.Windows.Forms.Label splitterLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.Label attensionInfoLabel;
        private System.Windows.Forms.ToolStripMenuItem подписьНаДокументахToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиИПодписиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem загрузитьШаблондокументаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьШаблонОВыдачеИнформацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}

