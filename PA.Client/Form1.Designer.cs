namespace PA.Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tpPayouts = new System.Windows.Forms.TabControl();
            this.tpEmps = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvEmps = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAssignPayout = new System.Windows.Forms.Button();
            this.cbPayoutType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPositions = new System.Windows.Forms.ComboBox();
            this.btnGetEmpsFromServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFireEmp = new System.Windows.Forms.Button();
            this.btnUpdateEmp = new System.Windows.Forms.Button();
            this.btnRegisterEmp = new System.Windows.Forms.Button();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnGetPayoutsForEmp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDeletePayout = new System.Windows.Forms.Button();
            this.btnUpdatePayout = new System.Windows.Forms.Button();
            this.nudEditPayoutSum = new System.Windows.Forms.NumericUpDown();
            this.gbPayouts = new System.Windows.Forms.GroupBox();
            this.dgvPayouts = new System.Windows.Forms.DataGridView();
            this.PayoutId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayoutType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDeps = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnCreateDep = new System.Windows.Forms.Button();
            this.btnDeleteDep = new System.Windows.Forms.Button();
            this.btnUpdateDep = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDepName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvDeps = new System.Windows.Forms.DataGridView();
            this.DepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnCreatePosition = new System.Windows.Forms.Button();
            this.btnRemovePosition = new System.Windows.Forms.Button();
            this.btnSavePosition = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbPositionName = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.PositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnCreatePayoutType = new System.Windows.Forms.Button();
            this.btnRemovePayoutType = new System.Windows.Forms.Button();
            this.btnSavePayoutType = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPayoutTypeName = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dgvPayoutTypes = new System.Windows.Forms.DataGridView();
            this.PayoutTypeIdCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayoutTypeNameCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpPayouts.SuspendLayout();
            this.tpEmps.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmps)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditPayoutSum)).BeginInit();
            this.gbPayouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayouts)).BeginInit();
            this.tpDeps.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeps)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayoutTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbPort);
            this.groupBox3.Controls.Add(this.tbIp);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Location = new System.Drawing.Point(12, 437);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(869, 51);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(284, 20);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "11000";
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(34, 20);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(204, 20);
            this.tbIp.TabIndex = 1;
            this.tbIp.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(390, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(188, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tpPayouts);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 426);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tpPayouts
            // 
            this.tpPayouts.Controls.Add(this.tpEmps);
            this.tpPayouts.Controls.Add(this.tabPage2);
            this.tpPayouts.Controls.Add(this.tpDeps);
            this.tpPayouts.Controls.Add(this.tabPage1);
            this.tpPayouts.Controls.Add(this.tabPage3);
            this.tpPayouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpPayouts.Location = new System.Drawing.Point(3, 16);
            this.tpPayouts.Name = "tpPayouts";
            this.tpPayouts.SelectedIndex = 0;
            this.tpPayouts.Size = new System.Drawing.Size(863, 407);
            this.tpPayouts.TabIndex = 0;
            // 
            // tpEmps
            // 
            this.tpEmps.Controls.Add(this.groupBox5);
            this.tpEmps.Controls.Add(this.groupBox4);
            this.tpEmps.Location = new System.Drawing.Point(4, 22);
            this.tpEmps.Name = "tpEmps";
            this.tpEmps.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmps.Size = new System.Drawing.Size(855, 381);
            this.tpEmps.TabIndex = 0;
            this.tpEmps.Text = "Сотрудники";
            this.tpEmps.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvEmps);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(533, 369);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // dgvEmps
            // 
            this.dgvEmps.AllowUserToAddRows = false;
            this.dgvEmps.AllowUserToDeleteRows = false;
            this.dgvEmps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FullName,
            this.Position,
            this.Department});
            this.dgvEmps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmps.Location = new System.Drawing.Point(3, 16);
            this.dgvEmps.Name = "dgvEmps";
            this.dgvEmps.ReadOnly = true;
            this.dgvEmps.Size = new System.Drawing.Size(527, 350);
            this.dgvEmps.TabIndex = 0;
            this.dgvEmps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmps_CellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "ФИО";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Должность";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // Department
            // 
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cbDepartments);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cbPositions);
            this.groupBox4.Controls.Add(this.btnGetEmpsFromServer);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnFireEmp);
            this.groupBox4.Controls.Add(this.btnUpdateEmp);
            this.groupBox4.Controls.Add(this.btnRegisterEmp);
            this.groupBox4.Controls.Add(this.tbMiddleName);
            this.groupBox4.Controls.Add(this.tbFirstName);
            this.groupBox4.Controls.Add(this.tbLastName);
            this.groupBox4.Location = new System.Drawing.Point(545, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 369);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSum);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnAssignPayout);
            this.groupBox1.Controls.Add(this.cbPayoutType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(6, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 124);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // nudSum
            // 
            this.nudSum.Location = new System.Drawing.Point(113, 45);
            this.nudSum.Maximum = new decimal(new int[] {
            -1304428544,
            434162106,
            542,
            0});
            this.nudSum.Name = "nudSum";
            this.nudSum.Size = new System.Drawing.Size(161, 20);
            this.nudSum.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Сумма выплаты";
            // 
            // btnAssignPayout
            // 
            this.btnAssignPayout.Location = new System.Drawing.Point(6, 95);
            this.btnAssignPayout.Name = "btnAssignPayout";
            this.btnAssignPayout.Size = new System.Drawing.Size(268, 23);
            this.btnAssignPayout.TabIndex = 16;
            this.btnAssignPayout.Text = "Назначить выплату";
            this.btnAssignPayout.UseVisualStyleBackColor = true;
            this.btnAssignPayout.Click += new System.EventHandler(this.btnAssignPayout_Click);
            // 
            // cbPayoutType
            // 
            this.cbPayoutType.Location = new System.Drawing.Point(113, 13);
            this.cbPayoutType.Name = "cbPayoutType";
            this.cbPayoutType.Size = new System.Drawing.Size(161, 21);
            this.cbPayoutType.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Тип выплаты";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Отдел";
            // 
            // cbDepartments
            // 
            this.cbDepartments.Location = new System.Drawing.Point(131, 125);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(161, 21);
            this.cbDepartments.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Должность";
            // 
            // cbPositions
            // 
            this.cbPositions.Location = new System.Drawing.Point(131, 98);
            this.cbPositions.Name = "cbPositions";
            this.cbPositions.Size = new System.Drawing.Size(161, 21);
            this.cbPositions.TabIndex = 10;
            // 
            // btnGetEmpsFromServer
            // 
            this.btnGetEmpsFromServer.Location = new System.Drawing.Point(6, 340);
            this.btnGetEmpsFromServer.Name = "btnGetEmpsFromServer";
            this.btnGetEmpsFromServer.Size = new System.Drawing.Size(286, 23);
            this.btnGetEmpsFromServer.TabIndex = 9;
            this.btnGetEmpsFromServer.Text = "Загрузить сотрудников с сервера";
            this.btnGetEmpsFromServer.UseVisualStyleBackColor = true;
            this.btnGetEmpsFromServer.Click += new System.EventHandler(this.btnGetEmpsFromServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Фамилия";
            // 
            // btnFireEmp
            // 
            this.btnFireEmp.Location = new System.Drawing.Point(6, 311);
            this.btnFireEmp.Name = "btnFireEmp";
            this.btnFireEmp.Size = new System.Drawing.Size(286, 23);
            this.btnFireEmp.TabIndex = 5;
            this.btnFireEmp.Text = "Уволить";
            this.btnFireEmp.UseVisualStyleBackColor = true;
            this.btnFireEmp.Click += new System.EventHandler(this.btnFireEmp_Click);
            // 
            // btnUpdateEmp
            // 
            this.btnUpdateEmp.Location = new System.Drawing.Point(6, 282);
            this.btnUpdateEmp.Name = "btnUpdateEmp";
            this.btnUpdateEmp.Size = new System.Drawing.Size(119, 23);
            this.btnUpdateEmp.TabIndex = 4;
            this.btnUpdateEmp.Text = "Применить изменения";
            this.btnUpdateEmp.UseVisualStyleBackColor = true;
            this.btnUpdateEmp.Click += new System.EventHandler(this.btnUpdateEmp_Click);
            // 
            // btnRegisterEmp
            // 
            this.btnRegisterEmp.Location = new System.Drawing.Point(131, 282);
            this.btnRegisterEmp.Name = "btnRegisterEmp";
            this.btnRegisterEmp.Size = new System.Drawing.Size(161, 23);
            this.btnRegisterEmp.TabIndex = 3;
            this.btnRegisterEmp.Text = "Зарегистрировать";
            this.btnRegisterEmp.UseVisualStyleBackColor = true;
            this.btnRegisterEmp.Click += new System.EventHandler(this.btnRegisterEmp_Click);
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(131, 70);
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(161, 20);
            this.tbMiddleName.TabIndex = 2;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(131, 43);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(161, 20);
            this.tbFirstName.TabIndex = 1;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(131, 16);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(161, 20);
            this.tbLastName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.gbPayouts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Выплаты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnGetPayoutsForEmp);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.btnDeletePayout);
            this.groupBox7.Controls.Add(this.btnUpdatePayout);
            this.groupBox7.Controls.Add(this.nudEditPayoutSum);
            this.groupBox7.Location = new System.Drawing.Point(526, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(329, 107);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // btnGetPayoutsForEmp
            // 
            this.btnGetPayoutsForEmp.Location = new System.Drawing.Point(6, 77);
            this.btnGetPayoutsForEmp.Name = "btnGetPayoutsForEmp";
            this.btnGetPayoutsForEmp.Size = new System.Drawing.Size(317, 23);
            this.btnGetPayoutsForEmp.TabIndex = 4;
            this.btnGetPayoutsForEmp.Text = "Загрузить выплаты сотрудника с сервера";
            this.btnGetPayoutsForEmp.UseVisualStyleBackColor = true;
            this.btnGetPayoutsForEmp.Click += new System.EventHandler(this.btnGetPayoutsForEmp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Размер выплаты";
            // 
            // btnDeletePayout
            // 
            this.btnDeletePayout.Location = new System.Drawing.Point(170, 47);
            this.btnDeletePayout.Name = "btnDeletePayout";
            this.btnDeletePayout.Size = new System.Drawing.Size(153, 23);
            this.btnDeletePayout.TabIndex = 2;
            this.btnDeletePayout.Text = "Удалить";
            this.btnDeletePayout.UseVisualStyleBackColor = true;
            this.btnDeletePayout.Click += new System.EventHandler(this.btnDeletePayout_Click);
            // 
            // btnUpdatePayout
            // 
            this.btnUpdatePayout.Location = new System.Drawing.Point(6, 47);
            this.btnUpdatePayout.Name = "btnUpdatePayout";
            this.btnUpdatePayout.Size = new System.Drawing.Size(158, 23);
            this.btnUpdatePayout.TabIndex = 1;
            this.btnUpdatePayout.Text = "Сохранить";
            this.btnUpdatePayout.UseVisualStyleBackColor = true;
            this.btnUpdatePayout.Click += new System.EventHandler(this.btnUpdatePayout_Click);
            // 
            // nudEditPayoutSum
            // 
            this.nudEditPayoutSum.Location = new System.Drawing.Point(203, 19);
            this.nudEditPayoutSum.Maximum = new decimal(new int[] {
            -1304428544,
            434162106,
            542,
            0});
            this.nudEditPayoutSum.Name = "nudEditPayoutSum";
            this.nudEditPayoutSum.Size = new System.Drawing.Size(120, 20);
            this.nudEditPayoutSum.TabIndex = 0;
            // 
            // gbPayouts
            // 
            this.gbPayouts.Controls.Add(this.dgvPayouts);
            this.gbPayouts.Location = new System.Drawing.Point(9, 6);
            this.gbPayouts.Name = "gbPayouts";
            this.gbPayouts.Size = new System.Drawing.Size(511, 369);
            this.gbPayouts.TabIndex = 0;
            this.gbPayouts.TabStop = false;
            // 
            // dgvPayouts
            // 
            this.dgvPayouts.AllowUserToAddRows = false;
            this.dgvPayouts.AllowUserToDeleteRows = false;
            this.dgvPayouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayouts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PayoutId,
            this.PayoutType,
            this.Sum});
            this.dgvPayouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayouts.Location = new System.Drawing.Point(3, 16);
            this.dgvPayouts.Name = "dgvPayouts";
            this.dgvPayouts.ReadOnly = true;
            this.dgvPayouts.Size = new System.Drawing.Size(505, 350);
            this.dgvPayouts.TabIndex = 0;
            this.dgvPayouts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayouts_CellClick);
            // 
            // PayoutId
            // 
            this.PayoutId.HeaderText = "Id";
            this.PayoutId.Name = "PayoutId";
            this.PayoutId.ReadOnly = true;
            // 
            // PayoutType
            // 
            this.PayoutType.HeaderText = "Тип выплаты";
            this.PayoutType.Name = "PayoutType";
            this.PayoutType.ReadOnly = true;
            // 
            // Sum
            // 
            this.Sum.HeaderText = "Сумма";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            // 
            // tpDeps
            // 
            this.tpDeps.Controls.Add(this.groupBox8);
            this.tpDeps.Controls.Add(this.groupBox6);
            this.tpDeps.Location = new System.Drawing.Point(4, 22);
            this.tpDeps.Name = "tpDeps";
            this.tpDeps.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeps.Size = new System.Drawing.Size(855, 381);
            this.tpDeps.TabIndex = 2;
            this.tpDeps.Text = "Отделы";
            this.tpDeps.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnCreateDep);
            this.groupBox8.Controls.Add(this.btnDeleteDep);
            this.groupBox8.Controls.Add(this.btnUpdateDep);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.tbDepName);
            this.groupBox8.Location = new System.Drawing.Point(470, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(379, 96);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            // 
            // btnCreateDep
            // 
            this.btnCreateDep.Location = new System.Drawing.Point(9, 38);
            this.btnCreateDep.Name = "btnCreateDep";
            this.btnCreateDep.Size = new System.Drawing.Size(364, 23);
            this.btnCreateDep.TabIndex = 4;
            this.btnCreateDep.Text = "Создать";
            this.btnCreateDep.UseVisualStyleBackColor = true;
            this.btnCreateDep.Click += new System.EventHandler(this.btnCreateDep_Click);
            // 
            // btnDeleteDep
            // 
            this.btnDeleteDep.Location = new System.Drawing.Point(190, 67);
            this.btnDeleteDep.Name = "btnDeleteDep";
            this.btnDeleteDep.Size = new System.Drawing.Size(183, 23);
            this.btnDeleteDep.TabIndex = 3;
            this.btnDeleteDep.Text = "Удалить";
            this.btnDeleteDep.UseVisualStyleBackColor = true;
            this.btnDeleteDep.Click += new System.EventHandler(this.btnDeleteDep_Click);
            // 
            // btnUpdateDep
            // 
            this.btnUpdateDep.Location = new System.Drawing.Point(6, 67);
            this.btnUpdateDep.Name = "btnUpdateDep";
            this.btnUpdateDep.Size = new System.Drawing.Size(183, 23);
            this.btnUpdateDep.TabIndex = 2;
            this.btnUpdateDep.Text = "Сохранить";
            this.btnUpdateDep.UseVisualStyleBackColor = true;
            this.btnUpdateDep.Click += new System.EventHandler(this.btnUpdateDep_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Название отдела";
            // 
            // tbDepName
            // 
            this.tbDepName.Location = new System.Drawing.Point(171, 16);
            this.tbDepName.Name = "tbDepName";
            this.tbDepName.Size = new System.Drawing.Size(202, 20);
            this.tbDepName.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvDeps);
            this.groupBox6.Location = new System.Drawing.Point(9, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 369);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // dgvDeps
            // 
            this.dgvDeps.AllowUserToAddRows = false;
            this.dgvDeps.AllowUserToDeleteRows = false;
            this.dgvDeps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepId,
            this.DepName});
            this.dgvDeps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeps.Location = new System.Drawing.Point(3, 16);
            this.dgvDeps.Name = "dgvDeps";
            this.dgvDeps.ReadOnly = true;
            this.dgvDeps.Size = new System.Drawing.Size(452, 350);
            this.dgvDeps.TabIndex = 0;
            this.dgvDeps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeps_CellClick);
            // 
            // DepId
            // 
            this.DepId.HeaderText = "Id";
            this.DepId.Name = "DepId";
            this.DepId.ReadOnly = true;
            // 
            // DepName
            // 
            this.DepName.HeaderText = "Название отдела";
            this.DepName.Name = "DepName";
            this.DepName.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 381);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Должности";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnCreatePosition);
            this.groupBox9.Controls.Add(this.btnRemovePosition);
            this.groupBox9.Controls.Add(this.btnSavePosition);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.tbPositionName);
            this.groupBox9.Location = new System.Drawing.Point(468, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(379, 101);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            // 
            // btnCreatePosition
            // 
            this.btnCreatePosition.Location = new System.Drawing.Point(9, 42);
            this.btnCreatePosition.Name = "btnCreatePosition";
            this.btnCreatePosition.Size = new System.Drawing.Size(364, 23);
            this.btnCreatePosition.TabIndex = 4;
            this.btnCreatePosition.Text = "Создать";
            this.btnCreatePosition.UseVisualStyleBackColor = true;
            this.btnCreatePosition.Click += new System.EventHandler(this.btnCreatePosition_Click);
            // 
            // btnRemovePosition
            // 
            this.btnRemovePosition.Location = new System.Drawing.Point(190, 71);
            this.btnRemovePosition.Name = "btnRemovePosition";
            this.btnRemovePosition.Size = new System.Drawing.Size(183, 23);
            this.btnRemovePosition.TabIndex = 3;
            this.btnRemovePosition.Text = "Удалить";
            this.btnRemovePosition.UseVisualStyleBackColor = true;
            this.btnRemovePosition.Click += new System.EventHandler(this.btnRemovePosition_Click);
            // 
            // btnSavePosition
            // 
            this.btnSavePosition.Location = new System.Drawing.Point(6, 71);
            this.btnSavePosition.Name = "btnSavePosition";
            this.btnSavePosition.Size = new System.Drawing.Size(183, 23);
            this.btnSavePosition.TabIndex = 2;
            this.btnSavePosition.Text = "Сохранить";
            this.btnSavePosition.UseVisualStyleBackColor = true;
            this.btnSavePosition.Click += new System.EventHandler(this.btnSavePosition_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Должность";
            // 
            // tbPositionName
            // 
            this.tbPositionName.Location = new System.Drawing.Point(171, 16);
            this.tbPositionName.Name = "tbPositionName";
            this.tbPositionName.Size = new System.Drawing.Size(202, 20);
            this.tbPositionName.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dgvPositions);
            this.groupBox10.Location = new System.Drawing.Point(7, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(458, 369);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            // 
            // dgvPositions
            // 
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PositionId,
            this.PositionName});
            this.dgvPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPositions.Location = new System.Drawing.Point(3, 16);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.Size = new System.Drawing.Size(452, 350);
            this.dgvPositions.TabIndex = 0;
            this.dgvPositions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPositions_CellClick);
            // 
            // PositionId
            // 
            this.PositionId.HeaderText = "Id";
            this.PositionId.Name = "PositionId";
            this.PositionId.ReadOnly = true;
            // 
            // PositionName
            // 
            this.PositionName.HeaderText = "Должнотсь";
            this.PositionName.Name = "PositionName";
            this.PositionName.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox11);
            this.tabPage3.Controls.Add(this.groupBox12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(855, 381);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Типы выплат";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnCreatePayoutType);
            this.groupBox11.Controls.Add(this.btnRemovePayoutType);
            this.groupBox11.Controls.Add(this.btnSavePayoutType);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.tbPayoutTypeName);
            this.groupBox11.Location = new System.Drawing.Point(468, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(379, 101);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            // 
            // btnCreatePayoutType
            // 
            this.btnCreatePayoutType.Location = new System.Drawing.Point(9, 42);
            this.btnCreatePayoutType.Name = "btnCreatePayoutType";
            this.btnCreatePayoutType.Size = new System.Drawing.Size(364, 23);
            this.btnCreatePayoutType.TabIndex = 4;
            this.btnCreatePayoutType.Text = "Создать";
            this.btnCreatePayoutType.UseVisualStyleBackColor = true;
            this.btnCreatePayoutType.Click += new System.EventHandler(this.btnCreatePayoutType_Click);
            // 
            // btnRemovePayoutType
            // 
            this.btnRemovePayoutType.Location = new System.Drawing.Point(190, 71);
            this.btnRemovePayoutType.Name = "btnRemovePayoutType";
            this.btnRemovePayoutType.Size = new System.Drawing.Size(183, 23);
            this.btnRemovePayoutType.TabIndex = 3;
            this.btnRemovePayoutType.Text = "Удалить";
            this.btnRemovePayoutType.UseVisualStyleBackColor = true;
            this.btnRemovePayoutType.Click += new System.EventHandler(this.btnRemovePayoutType_Click);
            // 
            // btnSavePayoutType
            // 
            this.btnSavePayoutType.Location = new System.Drawing.Point(6, 71);
            this.btnSavePayoutType.Name = "btnSavePayoutType";
            this.btnSavePayoutType.Size = new System.Drawing.Size(183, 23);
            this.btnSavePayoutType.TabIndex = 2;
            this.btnSavePayoutType.Text = "Сохранить";
            this.btnSavePayoutType.UseVisualStyleBackColor = true;
            this.btnSavePayoutType.Click += new System.EventHandler(this.btnSavePayoutType_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Тип выплаты";
            // 
            // tbPayoutTypeName
            // 
            this.tbPayoutTypeName.Location = new System.Drawing.Point(171, 16);
            this.tbPayoutTypeName.Name = "tbPayoutTypeName";
            this.tbPayoutTypeName.Size = new System.Drawing.Size(202, 20);
            this.tbPayoutTypeName.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dgvPayoutTypes);
            this.groupBox12.Location = new System.Drawing.Point(7, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(458, 369);
            this.groupBox12.TabIndex = 5;
            this.groupBox12.TabStop = false;
            // 
            // dgvPayoutTypes
            // 
            this.dgvPayoutTypes.AllowUserToAddRows = false;
            this.dgvPayoutTypes.AllowUserToDeleteRows = false;
            this.dgvPayoutTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayoutTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PayoutTypeIdCell,
            this.PayoutTypeNameCell});
            this.dgvPayoutTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayoutTypes.Location = new System.Drawing.Point(3, 16);
            this.dgvPayoutTypes.Name = "dgvPayoutTypes";
            this.dgvPayoutTypes.ReadOnly = true;
            this.dgvPayoutTypes.Size = new System.Drawing.Size(452, 350);
            this.dgvPayoutTypes.TabIndex = 0;
            this.dgvPayoutTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayoutTypes_CellClick);
            // 
            // PayoutTypeIdCell
            // 
            this.PayoutTypeIdCell.HeaderText = "Id";
            this.PayoutTypeIdCell.Name = "PayoutTypeIdCell";
            this.PayoutTypeIdCell.ReadOnly = true;
            // 
            // PayoutTypeNameCell
            // 
            this.PayoutTypeNameCell.HeaderText = "Тип выплаты";
            this.PayoutTypeNameCell.Name = "PayoutTypeNameCell";
            this.PayoutTypeNameCell.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 500);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Кадровый учет";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tpPayouts.ResumeLayout(false);
            this.tpEmps.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmps)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSum)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditPayoutSum)).EndInit();
            this.gbPayouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayouts)).EndInit();
            this.tpDeps.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeps)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayoutTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tpPayouts;
        private System.Windows.Forms.TabPage tpEmps;
        private System.Windows.Forms.DataGridView dgvEmps;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tpDeps;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFireEmp;
        private System.Windows.Forms.Button btnUpdateEmp;
        private System.Windows.Forms.Button btnRegisterEmp;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnGetEmpsFromServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.ComboBox cbPositions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPayoutType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAssignPayout;
        private System.Windows.Forms.NumericUpDown nudSum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDeletePayout;
        private System.Windows.Forms.Button btnUpdatePayout;
        private System.Windows.Forms.NumericUpDown nudEditPayoutSum;
        private System.Windows.Forms.GroupBox gbPayouts;
        private System.Windows.Forms.DataGridView dgvPayouts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayoutId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayoutType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Button btnGetPayoutsForEmp;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnDeleteDep;
        private System.Windows.Forms.Button btnUpdateDep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbDepName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepName;
        private System.Windows.Forms.Button btnCreateDep;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnRemovePosition;
        private System.Windows.Forms.Button btnSavePosition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbPositionName;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Button btnCreatePosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionName;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnCreatePayoutType;
        private System.Windows.Forms.Button btnRemovePayoutType;
        private System.Windows.Forms.Button btnSavePayoutType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPayoutTypeName;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dgvPayoutTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayoutTypeIdCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayoutTypeNameCell;
    }
}

