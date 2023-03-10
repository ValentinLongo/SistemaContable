namespace SistemaContable.Inicio.Contabilidad.LibroMayor
{
    partial class frmLibroMayor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroMayor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.btnBuscarEjercicio = new System.Windows.Forms.Button();
            this.tbDescriEjercicio = new System.Windows.Forms.TextBox();
            this.tbIdEjercicio = new System.Windows.Forms.TextBox();
            this.Mensaje = new System.Windows.Forms.Label();
            this.btnBuscarCuenta = new System.Windows.Forms.Button();
            this.tbDescriCuenta = new System.Windows.Forms.TextBox();
            this.tbIdCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.ChechInfDet = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuCheckBox1 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuCheckBox2 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuCheckBox3 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuCheckBox4 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbCentroCosto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 21);
            this.panel1.TabIndex = 17;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Libro Mayor (Reporte)";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BunifuFormDrag = null;
            this.btnCerrar.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.CloseBoxOptions.BorderRadius = 0;
            this.btnCerrar.CloseBoxOptions.Enabled = true;
            this.btnCerrar.CloseBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnCerrar.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.CloseBoxOptions.Icon")));
            this.btnCerrar.CloseBoxOptions.IconAlt = null;
            this.btnCerrar.CloseBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconHoverColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconPressedColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.btnCerrar.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnCerrar.HelpBox = false;
            this.btnCerrar.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.HelpBoxOptions.BorderRadius = 0;
            this.btnCerrar.HelpBoxOptions.Enabled = true;
            this.btnCerrar.HelpBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.HelpBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.HelpBoxOptions.Icon")));
            this.btnCerrar.HelpBoxOptions.IconAlt = null;
            this.btnCerrar.HelpBoxOptions.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.btnCerrar.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.Location = new System.Drawing.Point(532, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.MaximizeBox = false;
            this.btnCerrar.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.MaximizeBoxOptions.BorderRadius = 0;
            this.btnCerrar.MaximizeBoxOptions.Enabled = true;
            this.btnCerrar.MaximizeBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.MaximizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MaximizeBoxOptions.Icon")));
            this.btnCerrar.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MaximizeBoxOptions.IconAlt")));
            this.btnCerrar.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.btnCerrar.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.MinimizeBox = false;
            this.btnCerrar.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.MinimizeBoxOptions.BorderRadius = 0;
            this.btnCerrar.MinimizeBoxOptions.Enabled = true;
            this.btnCerrar.MinimizeBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MinimizeBoxOptions.Icon")));
            this.btnCerrar.MinimizeBoxOptions.IconAlt = null;
            this.btnCerrar.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.btnCerrar.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.ShowDesignBorders = false;
            this.btnCerrar.Size = new System.Drawing.Size(24, 21);
            this.btnCerrar.TabIndex = 29;
            // 
            // btnBuscarEjercicio
            // 
            this.btnBuscarEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarEjercicio.FlatAppearance.BorderSize = 0;
            this.btnBuscarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEjercicio.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEjercicio.Image")));
            this.btnBuscarEjercicio.Location = new System.Drawing.Point(507, 36);
            this.btnBuscarEjercicio.Name = "btnBuscarEjercicio";
            this.btnBuscarEjercicio.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarEjercicio.TabIndex = 129;
            this.btnBuscarEjercicio.UseVisualStyleBackColor = false;
            this.btnBuscarEjercicio.Click += new System.EventHandler(this.btnBuscarEjercicio_Click);
            // 
            // tbDescriEjercicio
            // 
            this.tbDescriEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescriEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriEjercicio.Location = new System.Drawing.Point(273, 38);
            this.tbDescriEjercicio.Name = "tbDescriEjercicio";
            this.tbDescriEjercicio.Size = new System.Drawing.Size(229, 15);
            this.tbDescriEjercicio.TabIndex = 128;
            // 
            // tbIdEjercicio
            // 
            this.tbIdEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdEjercicio.Location = new System.Drawing.Point(184, 38);
            this.tbIdEjercicio.Name = "tbIdEjercicio";
            this.tbIdEjercicio.Size = new System.Drawing.Size(78, 15);
            this.tbIdEjercicio.TabIndex = 127;
            // 
            // Mensaje
            // 
            this.Mensaje.AutoSize = true;
            this.Mensaje.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mensaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Mensaje.Location = new System.Drawing.Point(125, 39);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(57, 17);
            this.Mensaje.TabIndex = 126;
            this.Mensaje.Text = "Ejercicio:";
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarCuenta.FlatAppearance.BorderSize = 0;
            this.btnBuscarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.Image")));
            this.btnBuscarCuenta.Location = new System.Drawing.Point(507, 71);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCuenta.TabIndex = 133;
            this.btnBuscarCuenta.UseVisualStyleBackColor = false;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // tbDescriCuenta
            // 
            this.tbDescriCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescriCuenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriCuenta.Location = new System.Drawing.Point(273, 73);
            this.tbDescriCuenta.Name = "tbDescriCuenta";
            this.tbDescriCuenta.Size = new System.Drawing.Size(229, 15);
            this.tbDescriCuenta.TabIndex = 132;
            // 
            // tbIdCuenta
            // 
            this.tbIdCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdCuenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdCuenta.Location = new System.Drawing.Point(184, 73);
            this.tbIdCuenta.Name = "tbIdCuenta";
            this.tbIdCuenta.Size = new System.Drawing.Size(78, 15);
            this.tbIdCuenta.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(130, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 130;
            this.label2.Text = "Cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(99, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 134;
            this.label3.Text = "Centro Costo:";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(185, 185);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(101, 20);
            this.dtHasta.TabIndex = 145;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(185, 152);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(101, 20);
            this.dtDesde.TabIndex = 144;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(161, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(254, 16);
            this.label13.TabIndex = 139;
            this.label13.Text = "Visualizar únicamente Asientos Manuales";
            // 
            // ChechInfDet
            // 
            this.ChechInfDet.AllowBindingControlAnimation = true;
            this.ChechInfDet.AllowBindingControlColorChanges = false;
            this.ChechInfDet.AllowBindingControlLocation = true;
            this.ChechInfDet.AllowCheckBoxAnimation = false;
            this.ChechInfDet.AllowCheckmarkAnimation = true;
            this.ChechInfDet.AllowOnHoverStates = true;
            this.ChechInfDet.AutoCheck = true;
            this.ChechInfDet.BackColor = System.Drawing.Color.Transparent;
            this.ChechInfDet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChechInfDet.BackgroundImage")));
            this.ChechInfDet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChechInfDet.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChechInfDet.BorderRadius = 12;
            this.ChechInfDet.Checked = false;
            this.ChechInfDet.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChechInfDet.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChechInfDet.CustomCheckmarkImage = null;
            this.ChechInfDet.Location = new System.Drawing.Point(141, 228);
            this.ChechInfDet.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChechInfDet.Name = "ChechInfDet";
            this.ChechInfDet.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChechInfDet.OnCheck.BorderRadius = 12;
            this.ChechInfDet.OnCheck.BorderThickness = 2;
            this.ChechInfDet.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChechInfDet.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChechInfDet.OnCheck.CheckmarkThickness = 2;
            this.ChechInfDet.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChechInfDet.OnDisable.BorderRadius = 12;
            this.ChechInfDet.OnDisable.BorderThickness = 2;
            this.ChechInfDet.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChechInfDet.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChechInfDet.OnDisable.CheckmarkThickness = 2;
            this.ChechInfDet.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChechInfDet.OnHoverChecked.BorderRadius = 12;
            this.ChechInfDet.OnHoverChecked.BorderThickness = 2;
            this.ChechInfDet.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChechInfDet.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChechInfDet.OnHoverChecked.CheckmarkThickness = 2;
            this.ChechInfDet.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChechInfDet.OnHoverUnchecked.BorderRadius = 12;
            this.ChechInfDet.OnHoverUnchecked.BorderThickness = 1;
            this.ChechInfDet.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChechInfDet.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChechInfDet.OnUncheck.BorderRadius = 12;
            this.ChechInfDet.OnUncheck.BorderThickness = 1;
            this.ChechInfDet.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChechInfDet.Size = new System.Drawing.Size(17, 17);
            this.ChechInfDet.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChechInfDet.TabIndex = 138;
            this.ChechInfDet.ThreeState = false;
            this.ChechInfDet.ToolTipText = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(138, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 137;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(135, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 136;
            this.label7.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(161, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 16);
            this.label4.TabIndex = 147;
            this.label4.Text = "Visualizar Informe de Centro de Costos";
            // 
            // bunifuCheckBox1
            // 
            this.bunifuCheckBox1.AllowBindingControlAnimation = true;
            this.bunifuCheckBox1.AllowBindingControlColorChanges = false;
            this.bunifuCheckBox1.AllowBindingControlLocation = true;
            this.bunifuCheckBox1.AllowCheckBoxAnimation = false;
            this.bunifuCheckBox1.AllowCheckmarkAnimation = true;
            this.bunifuCheckBox1.AllowOnHoverStates = true;
            this.bunifuCheckBox1.AutoCheck = true;
            this.bunifuCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox1.BackgroundImage")));
            this.bunifuCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuCheckBox1.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.bunifuCheckBox1.BorderRadius = 12;
            this.bunifuCheckBox1.Checked = false;
            this.bunifuCheckBox1.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.bunifuCheckBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuCheckBox1.CustomCheckmarkImage = null;
            this.bunifuCheckBox1.Location = new System.Drawing.Point(141, 255);
            this.bunifuCheckBox1.MinimumSize = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox1.Name = "bunifuCheckBox1";
            this.bunifuCheckBox1.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox1.OnCheck.BorderRadius = 12;
            this.bunifuCheckBox1.OnCheck.BorderThickness = 2;
            this.bunifuCheckBox1.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox1.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox1.OnCheck.CheckmarkThickness = 2;
            this.bunifuCheckBox1.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox1.OnDisable.BorderRadius = 12;
            this.bunifuCheckBox1.OnDisable.BorderThickness = 2;
            this.bunifuCheckBox1.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox1.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox1.OnDisable.CheckmarkThickness = 2;
            this.bunifuCheckBox1.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox1.OnHoverChecked.BorderRadius = 12;
            this.bunifuCheckBox1.OnHoverChecked.BorderThickness = 2;
            this.bunifuCheckBox1.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox1.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox1.OnHoverChecked.CheckmarkThickness = 2;
            this.bunifuCheckBox1.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox1.OnHoverUnchecked.BorderRadius = 12;
            this.bunifuCheckBox1.OnHoverUnchecked.BorderThickness = 1;
            this.bunifuCheckBox1.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox1.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuCheckBox1.OnUncheck.BorderRadius = 12;
            this.bunifuCheckBox1.OnUncheck.BorderThickness = 1;
            this.bunifuCheckBox1.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox1.Size = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox1.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.bunifuCheckBox1.TabIndex = 146;
            this.bunifuCheckBox1.ThreeState = false;
            this.bunifuCheckBox1.ToolTipText = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(161, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 16);
            this.label5.TabIndex = 149;
            this.label5.Text = "Visualizar únicamente Asientos con Importes al Debe";
            // 
            // bunifuCheckBox2
            // 
            this.bunifuCheckBox2.AllowBindingControlAnimation = true;
            this.bunifuCheckBox2.AllowBindingControlColorChanges = false;
            this.bunifuCheckBox2.AllowBindingControlLocation = true;
            this.bunifuCheckBox2.AllowCheckBoxAnimation = false;
            this.bunifuCheckBox2.AllowCheckmarkAnimation = true;
            this.bunifuCheckBox2.AllowOnHoverStates = true;
            this.bunifuCheckBox2.AutoCheck = true;
            this.bunifuCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox2.BackgroundImage")));
            this.bunifuCheckBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuCheckBox2.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.bunifuCheckBox2.BorderRadius = 12;
            this.bunifuCheckBox2.Checked = false;
            this.bunifuCheckBox2.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.bunifuCheckBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuCheckBox2.CustomCheckmarkImage = null;
            this.bunifuCheckBox2.Location = new System.Drawing.Point(141, 278);
            this.bunifuCheckBox2.MinimumSize = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox2.Name = "bunifuCheckBox2";
            this.bunifuCheckBox2.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox2.OnCheck.BorderRadius = 12;
            this.bunifuCheckBox2.OnCheck.BorderThickness = 2;
            this.bunifuCheckBox2.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox2.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox2.OnCheck.CheckmarkThickness = 2;
            this.bunifuCheckBox2.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox2.OnDisable.BorderRadius = 12;
            this.bunifuCheckBox2.OnDisable.BorderThickness = 2;
            this.bunifuCheckBox2.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox2.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox2.OnDisable.CheckmarkThickness = 2;
            this.bunifuCheckBox2.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox2.OnHoverChecked.BorderRadius = 12;
            this.bunifuCheckBox2.OnHoverChecked.BorderThickness = 2;
            this.bunifuCheckBox2.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox2.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox2.OnHoverChecked.CheckmarkThickness = 2;
            this.bunifuCheckBox2.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox2.OnHoverUnchecked.BorderRadius = 12;
            this.bunifuCheckBox2.OnHoverUnchecked.BorderThickness = 1;
            this.bunifuCheckBox2.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox2.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuCheckBox2.OnUncheck.BorderRadius = 12;
            this.bunifuCheckBox2.OnUncheck.BorderThickness = 1;
            this.bunifuCheckBox2.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox2.Size = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox2.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.bunifuCheckBox2.TabIndex = 148;
            this.bunifuCheckBox2.ThreeState = false;
            this.bunifuCheckBox2.ToolTipText = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(161, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(327, 16);
            this.label8.TabIndex = 151;
            this.label8.Text = "Visualizar únicamente Asientos con Importes al Haber";
            // 
            // bunifuCheckBox3
            // 
            this.bunifuCheckBox3.AllowBindingControlAnimation = true;
            this.bunifuCheckBox3.AllowBindingControlColorChanges = false;
            this.bunifuCheckBox3.AllowBindingControlLocation = true;
            this.bunifuCheckBox3.AllowCheckBoxAnimation = false;
            this.bunifuCheckBox3.AllowCheckmarkAnimation = true;
            this.bunifuCheckBox3.AllowOnHoverStates = true;
            this.bunifuCheckBox3.AutoCheck = true;
            this.bunifuCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox3.BackgroundImage")));
            this.bunifuCheckBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuCheckBox3.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.bunifuCheckBox3.BorderRadius = 12;
            this.bunifuCheckBox3.Checked = false;
            this.bunifuCheckBox3.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.bunifuCheckBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuCheckBox3.CustomCheckmarkImage = null;
            this.bunifuCheckBox3.Location = new System.Drawing.Point(141, 301);
            this.bunifuCheckBox3.MinimumSize = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox3.Name = "bunifuCheckBox3";
            this.bunifuCheckBox3.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox3.OnCheck.BorderRadius = 12;
            this.bunifuCheckBox3.OnCheck.BorderThickness = 2;
            this.bunifuCheckBox3.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox3.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox3.OnCheck.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox3.OnDisable.BorderRadius = 12;
            this.bunifuCheckBox3.OnDisable.BorderThickness = 2;
            this.bunifuCheckBox3.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox3.OnDisable.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverChecked.BorderRadius = 12;
            this.bunifuCheckBox3.OnHoverChecked.BorderThickness = 2;
            this.bunifuCheckBox3.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox3.OnHoverChecked.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverUnchecked.BorderRadius = 12;
            this.bunifuCheckBox3.OnHoverUnchecked.BorderThickness = 1;
            this.bunifuCheckBox3.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuCheckBox3.OnUncheck.BorderRadius = 12;
            this.bunifuCheckBox3.OnUncheck.BorderThickness = 1;
            this.bunifuCheckBox3.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.Size = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox3.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.bunifuCheckBox3.TabIndex = 150;
            this.bunifuCheckBox3.ThreeState = false;
            this.bunifuCheckBox3.ToolTipText = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(161, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 16);
            this.label9.TabIndex = 153;
            this.label9.Text = "Visualizar únicamente Comprobante";
            // 
            // bunifuCheckBox4
            // 
            this.bunifuCheckBox4.AllowBindingControlAnimation = true;
            this.bunifuCheckBox4.AllowBindingControlColorChanges = false;
            this.bunifuCheckBox4.AllowBindingControlLocation = true;
            this.bunifuCheckBox4.AllowCheckBoxAnimation = false;
            this.bunifuCheckBox4.AllowCheckmarkAnimation = true;
            this.bunifuCheckBox4.AllowOnHoverStates = true;
            this.bunifuCheckBox4.AutoCheck = true;
            this.bunifuCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox4.BackgroundImage")));
            this.bunifuCheckBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuCheckBox4.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.bunifuCheckBox4.BorderRadius = 12;
            this.bunifuCheckBox4.Checked = false;
            this.bunifuCheckBox4.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.bunifuCheckBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuCheckBox4.CustomCheckmarkImage = null;
            this.bunifuCheckBox4.Location = new System.Drawing.Point(141, 324);
            this.bunifuCheckBox4.MinimumSize = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox4.Name = "bunifuCheckBox4";
            this.bunifuCheckBox4.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox4.OnCheck.BorderRadius = 12;
            this.bunifuCheckBox4.OnCheck.BorderThickness = 2;
            this.bunifuCheckBox4.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox4.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox4.OnCheck.CheckmarkThickness = 2;
            this.bunifuCheckBox4.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox4.OnDisable.BorderRadius = 12;
            this.bunifuCheckBox4.OnDisable.BorderThickness = 2;
            this.bunifuCheckBox4.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox4.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox4.OnDisable.CheckmarkThickness = 2;
            this.bunifuCheckBox4.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox4.OnHoverChecked.BorderRadius = 12;
            this.bunifuCheckBox4.OnHoverChecked.BorderThickness = 2;
            this.bunifuCheckBox4.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox4.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox4.OnHoverChecked.CheckmarkThickness = 2;
            this.bunifuCheckBox4.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox4.OnHoverUnchecked.BorderRadius = 12;
            this.bunifuCheckBox4.OnHoverUnchecked.BorderThickness = 1;
            this.bunifuCheckBox4.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox4.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuCheckBox4.OnUncheck.BorderRadius = 12;
            this.bunifuCheckBox4.OnUncheck.BorderThickness = 1;
            this.bunifuCheckBox4.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox4.Size = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox4.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.bunifuCheckBox4.TabIndex = 152;
            this.bunifuCheckBox4.ThreeState = false;
            this.bunifuCheckBox4.ToolTipText = null;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.BorderRadius = 0;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.Location = new System.Drawing.Point(204, 360);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(148, 44);
            this.btnConfirmar.TabIndex = 154;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(273, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 1);
            this.panel4.TabIndex = 170;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(273, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 1);
            this.panel2.TabIndex = 171;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(184, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(78, 1);
            this.panel3.TabIndex = 172;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(184, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(78, 1);
            this.panel5.TabIndex = 173;
            // 
            // cbCentroCosto
            // 
            this.cbCentroCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCentroCosto.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCentroCosto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbCentroCosto.FormattingEnabled = true;
            this.cbCentroCosto.Items.AddRange(new object[] {
            "Codigo",
            "Nombre"});
            this.cbCentroCosto.Location = new System.Drawing.Point(184, 109);
            this.cbCentroCosto.Name = "cbCentroCosto";
            this.cbCentroCosto.Size = new System.Drawing.Size(250, 23);
            this.cbCentroCosto.TabIndex = 174;
            // 
            // frmLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(556, 421);
            this.Controls.Add(this.cbCentroCosto);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bunifuCheckBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bunifuCheckBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bunifuCheckBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bunifuCheckBox1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ChechInfDet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarCuenta);
            this.Controls.Add(this.tbDescriCuenta);
            this.Controls.Add(this.tbIdCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscarEjercicio);
            this.Controls.Add(this.tbDescriEjercicio);
            this.Controls.Add(this.tbIdEjercicio);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLibroMayor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private System.Windows.Forms.Button btnBuscarEjercicio;
        private System.Windows.Forms.TextBox tbDescriEjercicio;
        private System.Windows.Forms.TextBox tbIdEjercicio;
        private System.Windows.Forms.Label Mensaje;
        private System.Windows.Forms.Button btnBuscarCuenta;
        private System.Windows.Forms.TextBox tbDescriCuenta;
        private System.Windows.Forms.TextBox tbIdCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label13;
        private Bunifu.UI.WinForms.BunifuCheckBox ChechInfDet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox1;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox2;
        private System.Windows.Forms.Label label8;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox3;
        private System.Windows.Forms.Label label9;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox4;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbCentroCosto;
    }
}