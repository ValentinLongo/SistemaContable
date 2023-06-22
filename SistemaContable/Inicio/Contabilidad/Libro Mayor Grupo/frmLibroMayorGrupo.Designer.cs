namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Grupo
{
    partial class frmLibroMayorGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroMayorGrupo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.btnBuscarCuenta = new System.Windows.Forms.Button();
            this.tbDescriCuenta = new System.Windows.Forms.TextBox();
            this.tbIdCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarEjercicio = new System.Windows.Forms.Button();
            this.tbDescriEjercicio = new System.Windows.Forms.TextBox();
            this.tbIdEjercicio = new System.Windows.Forms.TextBox();
            this.Mensaje = new System.Windows.Forms.Label();
            this.btnBuscarCuenta2 = new System.Windows.Forms.Button();
            this.tbDescriCuenta2 = new System.Windows.Forms.TextBox();
            this.tbIdCuenta2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuCheckBox4 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.ChSumSalEjAnt = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.maskHasta = new System.Windows.Forms.MaskedTextBox();
            this.maskDesde = new System.Windows.Forms.MaskedTextBox();
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
            this.panel1.Size = new System.Drawing.Size(429, 21);
            this.panel1.TabIndex = 18;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
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
            this.btnCerrar.Location = new System.Drawing.Point(361, 0);
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
            this.btnCerrar.MinimizeBox = true;
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
            this.btnCerrar.Size = new System.Drawing.Size(68, 21);
            this.btnCerrar.TabIndex = 29;
            this.btnCerrar.TabStop = false;
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarCuenta.FlatAppearance.BorderSize = 0;
            this.btnBuscarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.Image")));
            this.btnBuscarCuenta.Location = new System.Drawing.Point(379, 71);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarCuenta.TabIndex = 5;
            this.btnBuscarCuenta.UseVisualStyleBackColor = false;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // tbDescriCuenta
            // 
            this.tbDescriCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriCuenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriCuenta.Location = new System.Drawing.Point(189, 77);
            this.tbDescriCuenta.Name = "tbDescriCuenta";
            this.tbDescriCuenta.Size = new System.Drawing.Size(184, 13);
            this.tbDescriCuenta.TabIndex = 4;
            this.tbDescriCuenta.Tag = "11000";
            // 
            // tbIdCuenta
            // 
            this.tbIdCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdCuenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdCuenta.Location = new System.Drawing.Point(85, 77);
            this.tbIdCuenta.Name = "tbIdCuenta";
            this.tbIdCuenta.Size = new System.Drawing.Size(98, 13);
            this.tbIdCuenta.TabIndex = 3;
            this.tbIdCuenta.Tag = "10100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "Cuenta:";
            // 
            // btnBuscarEjercicio
            // 
            this.btnBuscarEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarEjercicio.FlatAppearance.BorderSize = 0;
            this.btnBuscarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEjercicio.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEjercicio.Image")));
            this.btnBuscarEjercicio.Location = new System.Drawing.Point(379, 36);
            this.btnBuscarEjercicio.Name = "btnBuscarEjercicio";
            this.btnBuscarEjercicio.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarEjercicio.TabIndex = 2;
            this.btnBuscarEjercicio.UseVisualStyleBackColor = false;
            this.btnBuscarEjercicio.Click += new System.EventHandler(this.btnBuscarEjercicio_Click);
            // 
            // tbDescriEjercicio
            // 
            this.tbDescriEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriEjercicio.Location = new System.Drawing.Point(189, 42);
            this.tbDescriEjercicio.Name = "tbDescriEjercicio";
            this.tbDescriEjercicio.Size = new System.Drawing.Size(184, 13);
            this.tbDescriEjercicio.TabIndex = 1;
            this.tbDescriEjercicio.Tag = "11000";
            // 
            // tbIdEjercicio
            // 
            this.tbIdEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdEjercicio.Location = new System.Drawing.Point(85, 42);
            this.tbIdEjercicio.Name = "tbIdEjercicio";
            this.tbIdEjercicio.Size = new System.Drawing.Size(98, 13);
            this.tbIdEjercicio.TabIndex = 0;
            this.tbIdEjercicio.Tag = "10100";
            this.tbIdEjercicio.TextChanged += new System.EventHandler(this.tbIdEjercicio_TextChanged);
            // 
            // Mensaje
            // 
            this.Mensaje.AutoSize = true;
            this.Mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Mensaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Mensaje.Location = new System.Drawing.Point(22, 40);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(62, 16);
            this.Mensaje.TabIndex = 134;
            this.Mensaje.Text = "Ejercicio:";
            // 
            // btnBuscarCuenta2
            // 
            this.btnBuscarCuenta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarCuenta2.FlatAppearance.BorderSize = 0;
            this.btnBuscarCuenta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCuenta2.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta2.Image")));
            this.btnBuscarCuenta2.Location = new System.Drawing.Point(379, 106);
            this.btnBuscarCuenta2.Name = "btnBuscarCuenta2";
            this.btnBuscarCuenta2.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarCuenta2.TabIndex = 8;
            this.btnBuscarCuenta2.UseVisualStyleBackColor = false;
            this.btnBuscarCuenta2.Click += new System.EventHandler(this.btnBuscarCuenta2_Click);
            // 
            // tbDescriCuenta2
            // 
            this.tbDescriCuenta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriCuenta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriCuenta2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriCuenta2.Location = new System.Drawing.Point(189, 112);
            this.tbDescriCuenta2.Name = "tbDescriCuenta2";
            this.tbDescriCuenta2.Size = new System.Drawing.Size(184, 13);
            this.tbDescriCuenta2.TabIndex = 7;
            this.tbDescriCuenta2.Tag = "11000";
            // 
            // tbIdCuenta2
            // 
            this.tbIdCuenta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdCuenta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdCuenta2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdCuenta2.Location = new System.Drawing.Point(85, 112);
            this.tbIdCuenta2.Name = "tbIdCuenta2";
            this.tbIdCuenta2.Size = new System.Drawing.Size(98, 13);
            this.tbIdCuenta2.TabIndex = 6;
            this.tbIdCuenta2.Tag = "10100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(28, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Cuenta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(35, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 147;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(32, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 146;
            this.label7.Text = "Desde:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(68, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 16);
            this.label9.TabIndex = 155;
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
            this.bunifuCheckBox4.Location = new System.Drawing.Point(48, 225);
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
            this.bunifuCheckBox4.TabIndex = 154;
            this.bunifuCheckBox4.TabStop = false;
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
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.Location = new System.Drawing.Point(142, 287);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(144, 43);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(189, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 1);
            this.panel3.TabIndex = 166;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(189, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 1);
            this.panel2.TabIndex = 167;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(189, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(184, 1);
            this.panel4.TabIndex = 168;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(86, 127);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(98, 1);
            this.panel5.TabIndex = 169;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(85, 57);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(98, 1);
            this.panel6.TabIndex = 170;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(85, 92);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(98, 1);
            this.panel7.TabIndex = 171;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(68, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(315, 16);
            this.label10.TabIndex = 178;
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
            this.ChSumSalEjAnt.Location = new System.Drawing.Point(48, 250);
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
            this.ChSumSalEjAnt.TabIndex = 177;
            this.ChSumSalEjAnt.TabStop = false;
            this.ChSumSalEjAnt.ThreeState = false;
            this.ChSumSalEjAnt.ToolTipText = null;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(154, 186);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(17, 20);
            this.dtpHasta.TabIndex = 184;
            this.dtpHasta.TabStop = false;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(154, 153);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(17, 20);
            this.dtpDesde.TabIndex = 183;
            this.dtpDesde.TabStop = false;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // maskHasta
            // 
            this.maskHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskHasta.ForeColor = System.Drawing.Color.White;
            this.maskHasta.Location = new System.Drawing.Point(84, 188);
            this.maskHasta.Name = "maskHasta";
            this.maskHasta.Size = new System.Drawing.Size(63, 15);
            this.maskHasta.TabIndex = 10;
            this.maskHasta.Tag = "10000";
            // 
            // maskDesde
            // 
            this.maskDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskDesde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDesde.ForeColor = System.Drawing.Color.White;
            this.maskDesde.Location = new System.Drawing.Point(85, 155);
            this.maskDesde.Name = "maskDesde";
            this.maskDesde.Size = new System.Drawing.Size(63, 15);
            this.maskDesde.TabIndex = 9;
            this.maskDesde.Tag = "10000";
            // 
            // frmLibroMayorGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(429, 350);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.maskHasta);
            this.Controls.Add(this.maskDesde);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ChSumSalEjAnt);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bunifuCheckBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBuscarCuenta2);
            this.Controls.Add(this.tbDescriCuenta2);
            this.Controls.Add(this.tbIdCuenta2);
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
            this.Name = "frmLibroMayorGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro Mayor Grupo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private System.Windows.Forms.Button btnBuscarCuenta;
        private System.Windows.Forms.TextBox tbDescriCuenta;
        private System.Windows.Forms.TextBox tbIdCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarEjercicio;
        private System.Windows.Forms.TextBox tbDescriEjercicio;
        private System.Windows.Forms.TextBox tbIdEjercicio;
        private System.Windows.Forms.Label Mensaje;
        private System.Windows.Forms.Button btnBuscarCuenta2;
        private System.Windows.Forms.TextBox tbDescriCuenta2;
        private System.Windows.Forms.TextBox tbIdCuenta2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox4;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private Bunifu.UI.WinForms.BunifuCheckBox ChSumSalEjAnt;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.MaskedTextBox maskHasta;
        private System.Windows.Forms.MaskedTextBox maskDesde;
    }
}