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
            this.ChAsiMan = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChInCentroCosto = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChImpDebe = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ChImpHaber = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ChUnicComp = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbCentroCosto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ChSumSalEjAnt = new Bunifu.UI.WinForms.BunifuCheckBox();
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
            this.tbIdEjercicio.TextChanged += new System.EventHandler(this.tbIdEjercicio_TextChanged);
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
            // ChAsiMan
            // 
            this.ChAsiMan.AllowBindingControlAnimation = true;
            this.ChAsiMan.AllowBindingControlColorChanges = false;
            this.ChAsiMan.AllowBindingControlLocation = true;
            this.ChAsiMan.AllowCheckBoxAnimation = false;
            this.ChAsiMan.AllowCheckmarkAnimation = true;
            this.ChAsiMan.AllowOnHoverStates = true;
            this.ChAsiMan.AutoCheck = true;
            this.ChAsiMan.BackColor = System.Drawing.Color.Transparent;
            this.ChAsiMan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChAsiMan.BackgroundImage")));
            this.ChAsiMan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChAsiMan.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChAsiMan.BorderRadius = 12;
            this.ChAsiMan.Checked = false;
            this.ChAsiMan.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChAsiMan.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChAsiMan.CustomCheckmarkImage = null;
            this.ChAsiMan.Location = new System.Drawing.Point(141, 228);
            this.ChAsiMan.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChAsiMan.Name = "ChAsiMan";
            this.ChAsiMan.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChAsiMan.OnCheck.BorderRadius = 12;
            this.ChAsiMan.OnCheck.BorderThickness = 2;
            this.ChAsiMan.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChAsiMan.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChAsiMan.OnCheck.CheckmarkThickness = 2;
            this.ChAsiMan.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChAsiMan.OnDisable.BorderRadius = 12;
            this.ChAsiMan.OnDisable.BorderThickness = 2;
            this.ChAsiMan.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChAsiMan.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChAsiMan.OnDisable.CheckmarkThickness = 2;
            this.ChAsiMan.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChAsiMan.OnHoverChecked.BorderRadius = 12;
            this.ChAsiMan.OnHoverChecked.BorderThickness = 2;
            this.ChAsiMan.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChAsiMan.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChAsiMan.OnHoverChecked.CheckmarkThickness = 2;
            this.ChAsiMan.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChAsiMan.OnHoverUnchecked.BorderRadius = 12;
            this.ChAsiMan.OnHoverUnchecked.BorderThickness = 1;
            this.ChAsiMan.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChAsiMan.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChAsiMan.OnUncheck.BorderRadius = 12;
            this.ChAsiMan.OnUncheck.BorderThickness = 1;
            this.ChAsiMan.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChAsiMan.Size = new System.Drawing.Size(17, 17);
            this.ChAsiMan.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChAsiMan.TabIndex = 138;
            this.ChAsiMan.ThreeState = false;
            this.ChAsiMan.ToolTipText = null;
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
            // ChInCentroCosto
            // 
            this.ChInCentroCosto.AllowBindingControlAnimation = true;
            this.ChInCentroCosto.AllowBindingControlColorChanges = false;
            this.ChInCentroCosto.AllowBindingControlLocation = true;
            this.ChInCentroCosto.AllowCheckBoxAnimation = false;
            this.ChInCentroCosto.AllowCheckmarkAnimation = true;
            this.ChInCentroCosto.AllowOnHoverStates = true;
            this.ChInCentroCosto.AutoCheck = true;
            this.ChInCentroCosto.BackColor = System.Drawing.Color.Transparent;
            this.ChInCentroCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChInCentroCosto.BackgroundImage")));
            this.ChInCentroCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChInCentroCosto.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChInCentroCosto.BorderRadius = 12;
            this.ChInCentroCosto.Checked = false;
            this.ChInCentroCosto.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChInCentroCosto.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChInCentroCosto.CustomCheckmarkImage = null;
            this.ChInCentroCosto.Location = new System.Drawing.Point(141, 255);
            this.ChInCentroCosto.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChInCentroCosto.Name = "ChInCentroCosto";
            this.ChInCentroCosto.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChInCentroCosto.OnCheck.BorderRadius = 12;
            this.ChInCentroCosto.OnCheck.BorderThickness = 2;
            this.ChInCentroCosto.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChInCentroCosto.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChInCentroCosto.OnCheck.CheckmarkThickness = 2;
            this.ChInCentroCosto.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChInCentroCosto.OnDisable.BorderRadius = 12;
            this.ChInCentroCosto.OnDisable.BorderThickness = 2;
            this.ChInCentroCosto.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChInCentroCosto.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChInCentroCosto.OnDisable.CheckmarkThickness = 2;
            this.ChInCentroCosto.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChInCentroCosto.OnHoverChecked.BorderRadius = 12;
            this.ChInCentroCosto.OnHoverChecked.BorderThickness = 2;
            this.ChInCentroCosto.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChInCentroCosto.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChInCentroCosto.OnHoverChecked.CheckmarkThickness = 2;
            this.ChInCentroCosto.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChInCentroCosto.OnHoverUnchecked.BorderRadius = 12;
            this.ChInCentroCosto.OnHoverUnchecked.BorderThickness = 1;
            this.ChInCentroCosto.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChInCentroCosto.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChInCentroCosto.OnUncheck.BorderRadius = 12;
            this.ChInCentroCosto.OnUncheck.BorderThickness = 1;
            this.ChInCentroCosto.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChInCentroCosto.Size = new System.Drawing.Size(17, 17);
            this.ChInCentroCosto.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChInCentroCosto.TabIndex = 146;
            this.ChInCentroCosto.ThreeState = false;
            this.ChInCentroCosto.ToolTipText = null;
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
            // ChImpDebe
            // 
            this.ChImpDebe.AllowBindingControlAnimation = true;
            this.ChImpDebe.AllowBindingControlColorChanges = false;
            this.ChImpDebe.AllowBindingControlLocation = true;
            this.ChImpDebe.AllowCheckBoxAnimation = false;
            this.ChImpDebe.AllowCheckmarkAnimation = true;
            this.ChImpDebe.AllowOnHoverStates = true;
            this.ChImpDebe.AutoCheck = true;
            this.ChImpDebe.BackColor = System.Drawing.Color.Transparent;
            this.ChImpDebe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChImpDebe.BackgroundImage")));
            this.ChImpDebe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChImpDebe.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChImpDebe.BorderRadius = 12;
            this.ChImpDebe.Checked = false;
            this.ChImpDebe.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChImpDebe.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChImpDebe.CustomCheckmarkImage = null;
            this.ChImpDebe.Location = new System.Drawing.Point(141, 278);
            this.ChImpDebe.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChImpDebe.Name = "ChImpDebe";
            this.ChImpDebe.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChImpDebe.OnCheck.BorderRadius = 12;
            this.ChImpDebe.OnCheck.BorderThickness = 2;
            this.ChImpDebe.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChImpDebe.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChImpDebe.OnCheck.CheckmarkThickness = 2;
            this.ChImpDebe.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChImpDebe.OnDisable.BorderRadius = 12;
            this.ChImpDebe.OnDisable.BorderThickness = 2;
            this.ChImpDebe.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpDebe.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChImpDebe.OnDisable.CheckmarkThickness = 2;
            this.ChImpDebe.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpDebe.OnHoverChecked.BorderRadius = 12;
            this.ChImpDebe.OnHoverChecked.BorderThickness = 2;
            this.ChImpDebe.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpDebe.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChImpDebe.OnHoverChecked.CheckmarkThickness = 2;
            this.ChImpDebe.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpDebe.OnHoverUnchecked.BorderRadius = 12;
            this.ChImpDebe.OnHoverUnchecked.BorderThickness = 1;
            this.ChImpDebe.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpDebe.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChImpDebe.OnUncheck.BorderRadius = 12;
            this.ChImpDebe.OnUncheck.BorderThickness = 1;
            this.ChImpDebe.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpDebe.Size = new System.Drawing.Size(17, 17);
            this.ChImpDebe.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChImpDebe.TabIndex = 148;
            this.ChImpDebe.ThreeState = false;
            this.ChImpDebe.ToolTipText = null;
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
            // ChImpHaber
            // 
            this.ChImpHaber.AllowBindingControlAnimation = true;
            this.ChImpHaber.AllowBindingControlColorChanges = false;
            this.ChImpHaber.AllowBindingControlLocation = true;
            this.ChImpHaber.AllowCheckBoxAnimation = false;
            this.ChImpHaber.AllowCheckmarkAnimation = true;
            this.ChImpHaber.AllowOnHoverStates = true;
            this.ChImpHaber.AutoCheck = true;
            this.ChImpHaber.BackColor = System.Drawing.Color.Transparent;
            this.ChImpHaber.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChImpHaber.BackgroundImage")));
            this.ChImpHaber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChImpHaber.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChImpHaber.BorderRadius = 12;
            this.ChImpHaber.Checked = false;
            this.ChImpHaber.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChImpHaber.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChImpHaber.CustomCheckmarkImage = null;
            this.ChImpHaber.Location = new System.Drawing.Point(141, 301);
            this.ChImpHaber.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChImpHaber.Name = "ChImpHaber";
            this.ChImpHaber.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChImpHaber.OnCheck.BorderRadius = 12;
            this.ChImpHaber.OnCheck.BorderThickness = 2;
            this.ChImpHaber.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChImpHaber.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChImpHaber.OnCheck.CheckmarkThickness = 2;
            this.ChImpHaber.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChImpHaber.OnDisable.BorderRadius = 12;
            this.ChImpHaber.OnDisable.BorderThickness = 2;
            this.ChImpHaber.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpHaber.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChImpHaber.OnDisable.CheckmarkThickness = 2;
            this.ChImpHaber.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpHaber.OnHoverChecked.BorderRadius = 12;
            this.ChImpHaber.OnHoverChecked.BorderThickness = 2;
            this.ChImpHaber.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpHaber.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChImpHaber.OnHoverChecked.CheckmarkThickness = 2;
            this.ChImpHaber.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChImpHaber.OnHoverUnchecked.BorderRadius = 12;
            this.ChImpHaber.OnHoverUnchecked.BorderThickness = 1;
            this.ChImpHaber.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpHaber.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChImpHaber.OnUncheck.BorderRadius = 12;
            this.ChImpHaber.OnUncheck.BorderThickness = 1;
            this.ChImpHaber.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChImpHaber.Size = new System.Drawing.Size(17, 17);
            this.ChImpHaber.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChImpHaber.TabIndex = 150;
            this.ChImpHaber.ThreeState = false;
            this.ChImpHaber.ToolTipText = null;
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
            // ChUnicComp
            // 
            this.ChUnicComp.AllowBindingControlAnimation = true;
            this.ChUnicComp.AllowBindingControlColorChanges = false;
            this.ChUnicComp.AllowBindingControlLocation = true;
            this.ChUnicComp.AllowCheckBoxAnimation = false;
            this.ChUnicComp.AllowCheckmarkAnimation = true;
            this.ChUnicComp.AllowOnHoverStates = true;
            this.ChUnicComp.AutoCheck = true;
            this.ChUnicComp.BackColor = System.Drawing.Color.Transparent;
            this.ChUnicComp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChUnicComp.BackgroundImage")));
            this.ChUnicComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChUnicComp.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChUnicComp.BorderRadius = 12;
            this.ChUnicComp.Checked = false;
            this.ChUnicComp.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChUnicComp.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChUnicComp.CustomCheckmarkImage = null;
            this.ChUnicComp.Location = new System.Drawing.Point(141, 324);
            this.ChUnicComp.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChUnicComp.Name = "ChUnicComp";
            this.ChUnicComp.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChUnicComp.OnCheck.BorderRadius = 12;
            this.ChUnicComp.OnCheck.BorderThickness = 2;
            this.ChUnicComp.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChUnicComp.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChUnicComp.OnCheck.CheckmarkThickness = 2;
            this.ChUnicComp.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChUnicComp.OnDisable.BorderRadius = 12;
            this.ChUnicComp.OnDisable.BorderThickness = 2;
            this.ChUnicComp.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChUnicComp.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChUnicComp.OnDisable.CheckmarkThickness = 2;
            this.ChUnicComp.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChUnicComp.OnHoverChecked.BorderRadius = 12;
            this.ChUnicComp.OnHoverChecked.BorderThickness = 2;
            this.ChUnicComp.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChUnicComp.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChUnicComp.OnHoverChecked.CheckmarkThickness = 2;
            this.ChUnicComp.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChUnicComp.OnHoverUnchecked.BorderRadius = 12;
            this.ChUnicComp.OnHoverUnchecked.BorderThickness = 1;
            this.ChUnicComp.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChUnicComp.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChUnicComp.OnUncheck.BorderRadius = 12;
            this.ChUnicComp.OnUncheck.BorderThickness = 1;
            this.ChUnicComp.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChUnicComp.Size = new System.Drawing.Size(17, 17);
            this.ChUnicComp.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChUnicComp.TabIndex = 152;
            this.ChUnicComp.ThreeState = false;
            this.ChUnicComp.ToolTipText = null;
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
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.Location = new System.Drawing.Point(204, 386);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(148, 44);
            this.btnConfirmar.TabIndex = 154;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
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
            this.cbCentroCosto.Location = new System.Drawing.Point(184, 109);
            this.cbCentroCosto.Name = "cbCentroCosto";
            this.cbCentroCosto.Size = new System.Drawing.Size(250, 23);
            this.cbCentroCosto.TabIndex = 174;
            this.cbCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cbCentroCosto_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(161, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(315, 16);
            this.label10.TabIndex = 176;
            this.label10.Text = "Sumar al Saldo inicial el Saldo del Ejercicio Anterior";
            // 
            // ChSumSalEjAnt
            // 
            this.ChSumSalEjAnt.AllowBindingControlAnimation = true;
            this.ChSumSalEjAnt.AllowBindingControlColorChanges = false;
            this.ChSumSalEjAnt.AllowBindingControlLocation = true;
            this.ChSumSalEjAnt.AllowCheckBoxAnimation = false;
            this.ChSumSalEjAnt.AllowCheckmarkAnimation = true;
            this.ChSumSalEjAnt.AllowOnHoverStates = true;
            this.ChSumSalEjAnt.AutoCheck = true;
            this.ChSumSalEjAnt.BackColor = System.Drawing.Color.Transparent;
            this.ChSumSalEjAnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChSumSalEjAnt.BackgroundImage")));
            this.ChSumSalEjAnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChSumSalEjAnt.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.ChSumSalEjAnt.BorderRadius = 12;
            this.ChSumSalEjAnt.Checked = false;
            this.ChSumSalEjAnt.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.ChSumSalEjAnt.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChSumSalEjAnt.CustomCheckmarkImage = null;
            this.ChSumSalEjAnt.Location = new System.Drawing.Point(141, 347);
            this.ChSumSalEjAnt.MinimumSize = new System.Drawing.Size(17, 17);
            this.ChSumSalEjAnt.Name = "ChSumSalEjAnt";
            this.ChSumSalEjAnt.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChSumSalEjAnt.OnCheck.BorderRadius = 12;
            this.ChSumSalEjAnt.OnCheck.BorderThickness = 2;
            this.ChSumSalEjAnt.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ChSumSalEjAnt.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.ChSumSalEjAnt.OnCheck.CheckmarkThickness = 2;
            this.ChSumSalEjAnt.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.ChSumSalEjAnt.OnDisable.BorderRadius = 12;
            this.ChSumSalEjAnt.OnDisable.BorderThickness = 2;
            this.ChSumSalEjAnt.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChSumSalEjAnt.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.ChSumSalEjAnt.OnDisable.CheckmarkThickness = 2;
            this.ChSumSalEjAnt.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChSumSalEjAnt.OnHoverChecked.BorderRadius = 12;
            this.ChSumSalEjAnt.OnHoverChecked.BorderThickness = 2;
            this.ChSumSalEjAnt.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChSumSalEjAnt.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.ChSumSalEjAnt.OnHoverChecked.CheckmarkThickness = 2;
            this.ChSumSalEjAnt.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.ChSumSalEjAnt.OnHoverUnchecked.BorderRadius = 12;
            this.ChSumSalEjAnt.OnHoverUnchecked.BorderThickness = 1;
            this.ChSumSalEjAnt.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChSumSalEjAnt.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.ChSumSalEjAnt.OnUncheck.BorderRadius = 12;
            this.ChSumSalEjAnt.OnUncheck.BorderThickness = 1;
            this.ChSumSalEjAnt.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.ChSumSalEjAnt.Size = new System.Drawing.Size(17, 17);
            this.ChSumSalEjAnt.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.ChSumSalEjAnt.TabIndex = 175;
            this.ChSumSalEjAnt.ThreeState = false;
            this.ChSumSalEjAnt.ToolTipText = null;
            // 
            // frmLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(556, 451);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ChSumSalEjAnt);
            this.Controls.Add(this.cbCentroCosto);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ChUnicComp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ChImpHaber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChImpDebe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChInCentroCosto);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ChAsiMan);
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
        private Bunifu.UI.WinForms.BunifuCheckBox ChAsiMan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuCheckBox ChInCentroCosto;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCheckBox ChImpDebe;
        private System.Windows.Forms.Label label8;
        private Bunifu.UI.WinForms.BunifuCheckBox ChImpHaber;
        private System.Windows.Forms.Label label9;
        private Bunifu.UI.WinForms.BunifuCheckBox ChUnicComp;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbCentroCosto;
        private System.Windows.Forms.Label label10;
        private Bunifu.UI.WinForms.BunifuCheckBox ChSumSalEjAnt;
    }
}