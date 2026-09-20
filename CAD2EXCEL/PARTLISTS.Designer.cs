namespace CAD2EXCEL
{
    partial class Form_pl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.st_1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_crno = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nm_no = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cb_msten = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_sl = new System.Windows.Forms.TextBox();
            this.vbButton1 = new CustomButton.VBButton();
            this.cb_addmaster = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_crname = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxname = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nm_name = new System.Windows.Forms.NumericUpDown();
            this.dtb_gr1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.vbButton2 = new CustomButton.VBButton();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_no)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtb_gr1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.st_1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(597, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // st_1
            // 
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.dtb_gr1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 379);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funtion";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(587, 100);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cb_crno);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBoxno);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nm_no);
            this.panel2.Location = new System.Drawing.Point(9, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 90);
            this.panel2.TabIndex = 8;
            // 
            // cb_crno
            // 
            this.cb_crno.AutoSize = true;
            this.cb_crno.Checked = true;
            this.cb_crno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_crno.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_crno.Location = new System.Drawing.Point(7, 66);
            this.cb_crno.Name = "cb_crno";
            this.cb_crno.Size = new System.Drawing.Size(113, 19);
            this.cb_crno.TabIndex = 7;
            this.cb_crno.Text = "Auto Create No.";
            this.cb_crno.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Starting Number";
            // 
            // comboBoxno
            // 
            this.comboBoxno.FormattingEnabled = true;
            this.comboBoxno.Items.AddRange(new object[] {
            "None",
            "Master+???"});
            this.comboBoxno.Location = new System.Drawing.Point(63, 5);
            this.comboBoxno.Name = "comboBoxno";
            this.comboBoxno.Size = new System.Drawing.Size(96, 23);
            this.comboBoxno.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "No. Rule";
            // 
            // nm_no
            // 
            this.nm_no.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm_no.Location = new System.Drawing.Point(104, 36);
            this.nm_no.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nm_no.Name = "nm_no";
            this.nm_no.Size = new System.Drawing.Size(55, 22);
            this.nm_no.TabIndex = 2;
            this.nm_no.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.vbButton2);
            this.panel4.Controls.Add(this.cb_msten);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tb_sl);
            this.panel4.Controls.Add(this.vbButton1);
            this.panel4.Controls.Add(this.cb_addmaster);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(400, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(191, 90);
            this.panel4.TabIndex = 8;
            // 
            // cb_msten
            // 
            this.cb_msten.AutoSize = true;
            this.cb_msten.Checked = true;
            this.cb_msten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_msten.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_msten.Location = new System.Drawing.Point(14, 39);
            this.cb_msten.Name = "cb_msten";
            this.cb_msten.Size = new System.Drawing.Size(94, 19);
            this.cb_msten.TabIndex = 12;
            this.cb_msten.Text = "Mã số = Tên";
            this.cb_msten.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "xSL/Bộ";
            // 
            // tb_sl
            // 
            this.tb_sl.Location = new System.Drawing.Point(53, 7);
            this.tb_sl.Name = "tb_sl";
            this.tb_sl.Size = new System.Drawing.Size(28, 22);
            this.tb_sl.TabIndex = 10;
            this.tb_sl.Text = "1";
            this.tb_sl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sl_KeyPress);
            // 
            // vbButton1
            // 
            this.vbButton1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.vbButton1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.vbButton1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.vbButton1.BorderRadius = 10;
            this.vbButton1.BorderSize = 2;
            this.vbButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.vbButton1.FlatAppearance.BorderSize = 0;
            this.vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton1.ForeColor = System.Drawing.Color.Black;
            this.vbButton1.Location = new System.Drawing.Point(137, 0);
            this.vbButton1.Name = "vbButton1";
            this.vbButton1.Size = new System.Drawing.Size(50, 39);
            this.vbButton1.TabIndex = 9;
            this.vbButton1.Text = "Create";
            this.vbButton1.TextColor = System.Drawing.Color.Black;
            this.vbButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.vbButton1.UseVisualStyleBackColor = false;
            this.vbButton1.Click += new System.EventHandler(this.vbButton1_Click_1);
            // 
            // cb_addmaster
            // 
            this.cb_addmaster.AutoSize = true;
            this.cb_addmaster.Checked = true;
            this.cb_addmaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_addmaster.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_addmaster.Location = new System.Drawing.Point(14, 66);
            this.cb_addmaster.Name = "cb_addmaster";
            this.cb_addmaster.Size = new System.Drawing.Size(118, 19);
            this.cb_addmaster.TabIndex = 8;
            this.cb_addmaster.Text = "Add Master Row";
            this.cb_addmaster.UseVisualStyleBackColor = true;
            this.cb_addmaster.CheckedChanged += new System.EventHandler(this.cb_addmaster_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "SL/ĐH:";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.cb_crname);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.comboBoxname);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.nm_name);
            this.panel3.Location = new System.Drawing.Point(194, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 90);
            this.panel3.TabIndex = 9;
            // 
            // cb_crname
            // 
            this.cb_crname.AutoSize = true;
            this.cb_crname.Checked = true;
            this.cb_crname.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_crname.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_crname.Location = new System.Drawing.Point(8, 66);
            this.cb_crname.Name = "cb_crname";
            this.cb_crname.Size = new System.Drawing.Size(124, 19);
            this.cb_crname.TabIndex = 8;
            this.cb_crname.Text = "Auto Create Name";
            this.cb_crname.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Starting Number";
            // 
            // comboBoxname
            // 
            this.comboBoxname.FormattingEnabled = true;
            this.comboBoxname.Items.AddRange(new object[] {
            "None",
            "Master+???"});
            this.comboBoxname.Location = new System.Drawing.Point(77, 5);
            this.comboBoxname.Name = "comboBoxname";
            this.comboBoxname.Size = new System.Drawing.Size(103, 23);
            this.comboBoxname.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Naming Rule";
            // 
            // nm_name
            // 
            this.nm_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nm_name.Location = new System.Drawing.Point(124, 35);
            this.nm_name.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nm_name.Name = "nm_name";
            this.nm_name.Size = new System.Drawing.Size(56, 22);
            this.nm_name.TabIndex = 2;
            this.nm_name.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtb_gr1
            // 
            this.dtb_gr1.AllowUserToOrderColumns = true;
            this.dtb_gr1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtb_gr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtb_gr1.ColumnHeadersHeight = 25;
            this.dtb_gr1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.PartName,
            this.ID,
            this.Thickness,
            this.Material,
            this.Width,
            this.Length,
            this.Quantity,
            this.OD,
            this.ReMark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtb_gr1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtb_gr1.Location = new System.Drawing.Point(4, 121);
            this.dtb_gr1.Name = "dtb_gr1";
            this.dtb_gr1.RowHeadersVisible = false;
            this.dtb_gr1.RowHeadersWidth = 30;
            this.dtb_gr1.RowTemplate.Height = 23;
            this.dtb_gr1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtb_gr1.Size = new System.Drawing.Size(589, 258);
            this.dtb_gr1.TabIndex = 0;
            this.dtb_gr1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtb_gr1_CellMouseDown);
            this.dtb_gr1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtb_gr1_CellMouseUp);
            this.dtb_gr1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtb_gr1_EditingControlShowing);
            this.dtb_gr1.SelectionChanged += new System.EventHandler(this.dtb_gr1_SelectionChanged);
            this.dtb_gr1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtb_gr1_KeyDown);
            this.dtb_gr1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtb_gr1_KeyUp);
            // 
            // Number
            // 
            this.Number.HeaderText = "STT";
            this.Number.Name = "Number";
            this.Number.Width = 35;
            // 
            // PartName
            // 
            this.PartName.HeaderText = "Tên";
            this.PartName.Name = "PartName";
            this.PartName.Width = 75;
            // 
            // ID
            // 
            this.ID.HeaderText = "Mã số";
            this.ID.Name = "ID";
            this.ID.Width = 65;
            // 
            // Thickness
            // 
            this.Thickness.HeaderText = "Quy cách";
            this.Thickness.Name = "Thickness";
            this.Thickness.Width = 65;
            // 
            // Material
            // 
            this.Material.HeaderText = "Vật liệu";
            this.Material.Name = "Material";
            this.Material.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Material.Width = 60;
            // 
            // Width
            // 
            this.Width.HeaderText = "Màu sơn";
            this.Width.Name = "Width";
            this.Width.Width = 60;
            // 
            // Length
            // 
            this.Length.HeaderText = "Đơn vị";
            this.Length.Name = "Length";
            this.Length.Width = 50;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Sl/bộ";
            this.Quantity.Name = "Quantity";
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quantity.Width = 45;
            // 
            // OD
            // 
            this.OD.HeaderText = "Sl/ĐH";
            this.OD.Name = "OD";
            this.OD.Width = 45;
            // 
            // ReMark
            // 
            this.ReMark.HeaderText = "Ghi chú";
            this.ReMark.Name = "ReMark";
            this.ReMark.Width = 90;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 435);
            this.tabControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // vbButton2
            // 
            this.vbButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton2.BorderRadius = 20;
            this.vbButton2.BorderSize = 0;
            this.vbButton2.FlatAppearance.BorderSize = 0;
            this.vbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton2.ForeColor = System.Drawing.Color.White;
            this.vbButton2.Location = new System.Drawing.Point(137, 45);
            this.vbButton2.Name = "vbButton2";
            this.vbButton2.Size = new System.Drawing.Size(49, 39);
            this.vbButton2.TabIndex = 13;
            this.vbButton2.Text = "vbButton2";
            this.vbButton2.TextColor = System.Drawing.Color.White;
            this.vbButton2.UseVisualStyleBackColor = false;
            this.vbButton2.Click += new System.EventHandler(this.vbButton2_Click);
            // 
            // Form_pl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 435);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form_pl";
            this.Text = "Partlist";
            this.Load += new System.EventHandler(this.Form_pl_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_no)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtb_gr1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cb_crno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxno;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nm_no;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private CustomButton.VBButton vbButton1;
        private System.Windows.Forms.CheckBox cb_addmaster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cb_crname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxname;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown nm_name;
        public System.Windows.Forms.DataGridView dtb_gr1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel st_1;
        private System.Windows.Forms.CheckBox cb_msten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thickness;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReMark;
        private CustomButton.VBButton vbButton2;
    }
}