namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Informe
{
    partial class frmLibroMayorInforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroMayorInforme));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.tbDescriEjercicio = new System.Windows.Forms.TextBox();
            this.tbIdEjercicio = new System.Windows.Forms.TextBox();
            this.Mensaje = new System.Windows.Forms.Label();
            this.tbDescriModelo = new System.Windows.Forms.TextBox();
            this.tbIdModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuCheckBox4 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBuscarModelo = new System.Windows.Forms.Button();
            this.btnBuscarEjercicio = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(392, 21);
            this.panel1.TabIndex = 19;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCerrar.Location = new System.Drawing.Point(324, 0);
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
            // tbDescriEjercicio
            // 
            this.tbDescriEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriEjercicio.Location = new System.Drawing.Point(156, 77);
            this.tbDescriEjercicio.Name = "tbDescriEjercicio";
            this.tbDescriEjercicio.Size = new System.Drawing.Size(181, 13);
            this.tbDescriEjercicio.TabIndex = 4;
            this.tbDescriEjercicio.Tag = "11000";
            // 
            // tbIdEjercicio
            // 
            this.tbIdEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdEjercicio.Location = new System.Drawing.Point(91, 77);
            this.tbIdEjercicio.Name = "tbIdEjercicio";
            this.tbIdEjercicio.Size = new System.Drawing.Size(54, 13);
            this.tbIdEjercicio.TabIndex = 3;
            this.tbIdEjercicio.Tag = "10100";
            this.tbIdEjercicio.TextChanged += new System.EventHandler(this.tbIdEjercicio_TextChanged);
            // 
            // Mensaje
            // 
            this.Mensaje.AutoSize = true;
            this.Mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Mensaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Mensaje.Location = new System.Drawing.Point(27, 76);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(62, 16);
            this.Mensaje.TabIndex = 138;
            this.Mensaje.Text = "Ejercicio:";
            // 
            // tbDescriModelo
            // 
            this.tbDescriModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriModelo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriModelo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriModelo.Location = new System.Drawing.Point(155, 44);
            this.tbDescriModelo.Name = "tbDescriModelo";
            this.tbDescriModelo.Size = new System.Drawing.Size(181, 13);
            this.tbDescriModelo.TabIndex = 1;
            this.tbDescriModelo.Tag = "11000";
            // 
            // tbIdModelo
            // 
            this.tbIdModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdModelo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdModelo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdModelo.Location = new System.Drawing.Point(91, 44);
            this.tbIdModelo.Name = "tbIdModelo";
            this.tbIdModelo.Size = new System.Drawing.Size(54, 13);
            this.tbIdModelo.TabIndex = 0;
            this.tbIdModelo.Tag = "10100";
            this.tbIdModelo.TextChanged += new System.EventHandler(this.tbIdModelo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(32, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 142;
            this.label2.Text = "Modelo:";
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
            this.btnConfirmar.Location = new System.Drawing.Point(125, 250);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(142, 47);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(52, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 16);
            this.label9.TabIndex = 162;
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
            this.bunifuCheckBox4.Location = new System.Drawing.Point(32, 190);
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
            this.bunifuCheckBox4.TabIndex = 161;
            this.bunifuCheckBox4.TabStop = false;
            this.bunifuCheckBox4.ThreeState = false;
            this.bunifuCheckBox4.ToolTipText = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(40, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 158;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(36, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 157;
            this.label7.Text = "Desde:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(156, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 1);
            this.panel2.TabIndex = 164;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(155, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 1);
            this.panel3.TabIndex = 165;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(91, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(54, 1);
            this.panel4.TabIndex = 166;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(91, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(54, 1);
            this.panel5.TabIndex = 167;
            // 
            // btnBuscarModelo
            // 
            this.btnBuscarModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarModelo.FlatAppearance.BorderSize = 0;
            this.btnBuscarModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarModelo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarModelo.Image")));
            this.btnBuscarModelo.Location = new System.Drawing.Point(342, 38);
            this.btnBuscarModelo.Name = "btnBuscarModelo";
            this.btnBuscarModelo.Size = new System.Drawing.Size(22, 21);
            this.btnBuscarModelo.TabIndex = 2;
            this.btnBuscarModelo.UseVisualStyleBackColor = false;
            this.btnBuscarModelo.Click += new System.EventHandler(this.btnBuscarModelo_Click);
            // 
            // btnBuscarEjercicio
            // 
            this.btnBuscarEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscarEjercicio.FlatAppearance.BorderSize = 0;
            this.btnBuscarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEjercicio.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEjercicio.Image")));
            this.btnBuscarEjercicio.Location = new System.Drawing.Point(342, 73);
            this.btnBuscarEjercicio.Name = "btnBuscarEjercicio";
            this.btnBuscarEjercicio.Size = new System.Drawing.Size(22, 21);
            this.btnBuscarEjercicio.TabIndex = 5;
            this.btnBuscarEjercicio.UseVisualStyleBackColor = false;
            this.btnBuscarEjercicio.Click += new System.EventHandler(this.btnBuscarEjercicio_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(52, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(315, 16);
            this.label10.TabIndex = 180;
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
            this.ChSumSalEjAnt.Location = new System.Drawing.Point(32, 214);
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
            this.ChSumSalEjAnt.TabIndex = 179;
            this.ChSumSalEjAnt.TabStop = false;
            this.ChSumSalEjAnt.ThreeState = false;
            this.ChSumSalEjAnt.ToolTipText = null;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(159, 150);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(17, 20);
            this.dtpHasta.TabIndex = 188;
            this.dtpHasta.TabStop = false;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(159, 117);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(17, 20);
            this.dtpDesde.TabIndex = 187;
            this.dtpDesde.TabStop = false;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // maskHasta
            // 
            this.maskHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskHasta.ForeColor = System.Drawing.Color.White;
            this.maskHasta.Location = new System.Drawing.Point(89, 152);
            this.maskHasta.Name = "maskHasta";
            this.maskHasta.Size = new System.Drawing.Size(63, 15);
            this.maskHasta.TabIndex = 7;
            this.maskHasta.Tag = "10000";
            // 
            // maskDesde
            // 
            this.maskDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskDesde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDesde.ForeColor = System.Drawing.Color.White;
            this.maskDesde.Location = new System.Drawing.Point(90, 119);
            this.maskDesde.Name = "maskDesde";
            this.maskDesde.Size = new System.Drawing.Size(63, 15);
            this.maskDesde.TabIndex = 6;
            this.maskDesde.Tag = "10000";
            // 
            // frmLibroMayorInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(392, 318);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.maskHasta);
            this.Controls.Add(this.maskDesde);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ChSumSalEjAnt);
            this.Controls.Add(this.btnBuscarEjercicio);
            this.Controls.Add(this.btnBuscarModelo);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bunifuCheckBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDescriModelo);
            this.Controls.Add(this.tbIdModelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDescriEjercicio);
            this.Controls.Add(this.tbIdEjercicio);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLibroMayorInforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libro Mayor Informe";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private System.Windows.Forms.TextBox tbDescriEjercicio;
        private System.Windows.Forms.TextBox tbIdEjercicio;
        private System.Windows.Forms.Label Mensaje;
        private System.Windows.Forms.TextBox tbDescriModelo;
        private System.Windows.Forms.TextBox tbIdModelo;
        private System.Windows.Forms.Label label2;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Label label9;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnBuscarModelo;
        private System.Windows.Forms.Button btnBuscarEjercicio;
        private System.Windows.Forms.Label label10;
        private Bunifu.UI.WinForms.BunifuCheckBox ChSumSalEjAnt;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.MaskedTextBox maskHasta;
        private System.Windows.Forms.MaskedTextBox maskDesde;
    }
}