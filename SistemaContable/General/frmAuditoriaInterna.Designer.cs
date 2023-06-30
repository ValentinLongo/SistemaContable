namespace SistemaContable.General
{
    partial class frmAuditoriaInterna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditoriaInterna));
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.maskHasta = new System.Windows.Forms.MaskedTextBox();
            this.maskDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConteo = new System.Windows.Forms.Label();
            this.ProgressBar = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.checkCpa = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkLiqTC = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkMovIntCaja = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkTrans = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkVta = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkDCBan = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkExtraccion = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkCaucion = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkTraban = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkDep = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCtaCont = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescriCuenta = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNroCuenta = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnProcesar = new RJCodeAdvance.RJControls.RJButton();
            this.timerCuenta = new System.Windows.Forms.Timer(this.components);
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel7.Controls.Add(this.lblControlBar);
            this.panel7.Controls.Add(this.bunifuFormControlBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(392, 21);
            this.panel7.TabIndex = 105;
            this.panel7.Tag = "1";
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 4);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(84, 13);
            this.lblControlBar.TabIndex = 31;
            this.lblControlBar.Text = "Auditoria Interna";
            // 
            // bunifuFormControlBox1
            // 
            this.bunifuFormControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuFormControlBox1.BunifuFormDrag = null;
            this.bunifuFormControlBox1.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.CloseBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.CloseBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.CloseBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.bunifuFormControlBox1.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.CloseBoxOptions.Icon")));
            this.bunifuFormControlBox1.CloseBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.CloseBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.CloseBoxOptions.IconHoverColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.CloseBoxOptions.IconPressedColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.bunifuFormControlBox1.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.bunifuFormControlBox1.HelpBox = false;
            this.bunifuFormControlBox1.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.HelpBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.HelpBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.HelpBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.HelpBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormControlBox1.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.HelpBoxOptions.Icon")));
            this.bunifuFormControlBox1.HelpBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.HelpBoxOptions.IconColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.bunifuFormControlBox1.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(324, 0);
            this.bunifuFormControlBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuFormControlBox1.MaximizeBox = false;
            this.bunifuFormControlBox1.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.MaximizeBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.MaximizeBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.MaximizeBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.MaximizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormControlBox1.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MaximizeBoxOptions.Icon")));
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MaximizeBoxOptions.IconAlt")));
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.bunifuFormControlBox1.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.MinimizeBox = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFormControlBox1.MinimizeBoxOptions.BorderRadius = 0;
            this.bunifuFormControlBox1.MinimizeBoxOptions.Enabled = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.EnableDefaultAction = true;
            this.bunifuFormControlBox1.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.bunifuFormControlBox1.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuFormControlBox1.MinimizeBoxOptions.Icon")));
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconAlt = null;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.bunifuFormControlBox1.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.bunifuFormControlBox1.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.bunifuFormControlBox1.Name = "bunifuFormControlBox1";
            this.bunifuFormControlBox1.ShowDesignBorders = false;
            this.bunifuFormControlBox1.Size = new System.Drawing.Size(68, 21);
            this.bunifuFormControlBox1.TabIndex = 29;
            this.bunifuFormControlBox1.TabStop = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(191, 66);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(17, 20);
            this.dtpHasta.TabIndex = 150;
            this.dtpHasta.TabStop = false;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(191, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(17, 20);
            this.dtpDesde.TabIndex = 149;
            this.dtpDesde.TabStop = false;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // maskHasta
            // 
            this.maskHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskHasta.ForeColor = System.Drawing.Color.White;
            this.maskHasta.Location = new System.Drawing.Point(121, 69);
            this.maskHasta.Name = "maskHasta";
            this.maskHasta.Size = new System.Drawing.Size(63, 15);
            this.maskHasta.TabIndex = 1;
            this.maskHasta.Tag = "10000";
            // 
            // maskDesde
            // 
            this.maskDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maskDesde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDesde.ForeColor = System.Drawing.Color.White;
            this.maskDesde.Location = new System.Drawing.Point(122, 36);
            this.maskDesde.Name = "maskDesde";
            this.maskDesde.Size = new System.Drawing.Size(63, 15);
            this.maskDesde.TabIndex = 0;
            this.maskDesde.Tag = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(71, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 148;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(68, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 147;
            this.label1.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(65, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 151;
            this.label3.Text = "Cuenta:";
            // 
            // lblConteo
            // 
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblConteo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblConteo.Location = new System.Drawing.Point(123, 379);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(161, 16);
            this.lblConteo.TabIndex = 153;
            this.lblConteo.Text = "Conteo de Comprobantes";
            // 
            // ProgressBar
            // 
            this.ProgressBar.AllowAnimations = false;
            this.ProgressBar.Animation = 0;
            this.ProgressBar.AnimationSpeed = 220;
            this.ProgressBar.AnimationStep = 10;
            this.ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.ProgressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBar.BackgroundImage")));
            this.ProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.ProgressBar.BorderRadius = 9;
            this.ProgressBar.BorderThickness = 1;
            this.ProgressBar.Location = new System.Drawing.Point(58, 401);
            this.ProgressBar.Maximum = 100;
            this.ProgressBar.MaximumValue = 100;
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.MinimumValue = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ProgressBar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.ProgressBar.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ProgressBar.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ProgressBar.Size = new System.Drawing.Size(285, 13);
            this.ProgressBar.TabIndex = 154;
            this.ProgressBar.TabStop = false;
            this.ProgressBar.Value = 0;
            this.ProgressBar.ValueByTransition = 0;
            // 
            // checkCpa
            // 
            this.checkCpa.AllowBindingControlAnimation = true;
            this.checkCpa.AllowBindingControlColorChanges = false;
            this.checkCpa.AllowBindingControlLocation = true;
            this.checkCpa.AllowCheckBoxAnimation = false;
            this.checkCpa.AllowCheckmarkAnimation = true;
            this.checkCpa.AllowOnHoverStates = true;
            this.checkCpa.AutoCheck = true;
            this.checkCpa.BackColor = System.Drawing.Color.Transparent;
            this.checkCpa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkCpa.BackgroundImage")));
            this.checkCpa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkCpa.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkCpa.BorderRadius = 12;
            this.checkCpa.Checked = false;
            this.checkCpa.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkCpa.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkCpa.CustomCheckmarkImage = null;
            this.checkCpa.Location = new System.Drawing.Point(93, 162);
            this.checkCpa.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkCpa.Name = "checkCpa";
            this.checkCpa.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkCpa.OnCheck.BorderRadius = 12;
            this.checkCpa.OnCheck.BorderThickness = 2;
            this.checkCpa.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkCpa.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkCpa.OnCheck.CheckmarkThickness = 2;
            this.checkCpa.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkCpa.OnDisable.BorderRadius = 12;
            this.checkCpa.OnDisable.BorderThickness = 2;
            this.checkCpa.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCpa.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkCpa.OnDisable.CheckmarkThickness = 2;
            this.checkCpa.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCpa.OnHoverChecked.BorderRadius = 12;
            this.checkCpa.OnHoverChecked.BorderThickness = 2;
            this.checkCpa.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCpa.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkCpa.OnHoverChecked.CheckmarkThickness = 2;
            this.checkCpa.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCpa.OnHoverUnchecked.BorderRadius = 12;
            this.checkCpa.OnHoverUnchecked.BorderThickness = 1;
            this.checkCpa.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCpa.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkCpa.OnUncheck.BorderRadius = 12;
            this.checkCpa.OnUncheck.BorderThickness = 1;
            this.checkCpa.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCpa.Size = new System.Drawing.Size(17, 17);
            this.checkCpa.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkCpa.TabIndex = 155;
            this.checkCpa.TabStop = false;
            this.checkCpa.ThreeState = false;
            this.checkCpa.ToolTipText = null;
            // 
            // checkLiqTC
            // 
            this.checkLiqTC.AllowBindingControlAnimation = true;
            this.checkLiqTC.AllowBindingControlColorChanges = false;
            this.checkLiqTC.AllowBindingControlLocation = true;
            this.checkLiqTC.AllowCheckBoxAnimation = false;
            this.checkLiqTC.AllowCheckmarkAnimation = true;
            this.checkLiqTC.AllowOnHoverStates = true;
            this.checkLiqTC.AutoCheck = true;
            this.checkLiqTC.BackColor = System.Drawing.Color.Transparent;
            this.checkLiqTC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkLiqTC.BackgroundImage")));
            this.checkLiqTC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkLiqTC.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkLiqTC.BorderRadius = 12;
            this.checkLiqTC.Checked = false;
            this.checkLiqTC.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkLiqTC.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkLiqTC.CustomCheckmarkImage = null;
            this.checkLiqTC.Location = new System.Drawing.Point(93, 185);
            this.checkLiqTC.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkLiqTC.Name = "checkLiqTC";
            this.checkLiqTC.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkLiqTC.OnCheck.BorderRadius = 12;
            this.checkLiqTC.OnCheck.BorderThickness = 2;
            this.checkLiqTC.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkLiqTC.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkLiqTC.OnCheck.CheckmarkThickness = 2;
            this.checkLiqTC.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkLiqTC.OnDisable.BorderRadius = 12;
            this.checkLiqTC.OnDisable.BorderThickness = 2;
            this.checkLiqTC.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkLiqTC.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkLiqTC.OnDisable.CheckmarkThickness = 2;
            this.checkLiqTC.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkLiqTC.OnHoverChecked.BorderRadius = 12;
            this.checkLiqTC.OnHoverChecked.BorderThickness = 2;
            this.checkLiqTC.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkLiqTC.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkLiqTC.OnHoverChecked.CheckmarkThickness = 2;
            this.checkLiqTC.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkLiqTC.OnHoverUnchecked.BorderRadius = 12;
            this.checkLiqTC.OnHoverUnchecked.BorderThickness = 1;
            this.checkLiqTC.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkLiqTC.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkLiqTC.OnUncheck.BorderRadius = 12;
            this.checkLiqTC.OnUncheck.BorderThickness = 1;
            this.checkLiqTC.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkLiqTC.Size = new System.Drawing.Size(17, 17);
            this.checkLiqTC.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkLiqTC.TabIndex = 156;
            this.checkLiqTC.TabStop = false;
            this.checkLiqTC.ThreeState = false;
            this.checkLiqTC.ToolTipText = null;
            // 
            // checkMovIntCaja
            // 
            this.checkMovIntCaja.AllowBindingControlAnimation = true;
            this.checkMovIntCaja.AllowBindingControlColorChanges = false;
            this.checkMovIntCaja.AllowBindingControlLocation = true;
            this.checkMovIntCaja.AllowCheckBoxAnimation = false;
            this.checkMovIntCaja.AllowCheckmarkAnimation = true;
            this.checkMovIntCaja.AllowOnHoverStates = true;
            this.checkMovIntCaja.AutoCheck = true;
            this.checkMovIntCaja.BackColor = System.Drawing.Color.Transparent;
            this.checkMovIntCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkMovIntCaja.BackgroundImage")));
            this.checkMovIntCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkMovIntCaja.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkMovIntCaja.BorderRadius = 12;
            this.checkMovIntCaja.Checked = false;
            this.checkMovIntCaja.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkMovIntCaja.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkMovIntCaja.CustomCheckmarkImage = null;
            this.checkMovIntCaja.Location = new System.Drawing.Point(93, 208);
            this.checkMovIntCaja.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkMovIntCaja.Name = "checkMovIntCaja";
            this.checkMovIntCaja.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkMovIntCaja.OnCheck.BorderRadius = 12;
            this.checkMovIntCaja.OnCheck.BorderThickness = 2;
            this.checkMovIntCaja.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkMovIntCaja.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkMovIntCaja.OnCheck.CheckmarkThickness = 2;
            this.checkMovIntCaja.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkMovIntCaja.OnDisable.BorderRadius = 12;
            this.checkMovIntCaja.OnDisable.BorderThickness = 2;
            this.checkMovIntCaja.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkMovIntCaja.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkMovIntCaja.OnDisable.CheckmarkThickness = 2;
            this.checkMovIntCaja.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkMovIntCaja.OnHoverChecked.BorderRadius = 12;
            this.checkMovIntCaja.OnHoverChecked.BorderThickness = 2;
            this.checkMovIntCaja.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkMovIntCaja.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkMovIntCaja.OnHoverChecked.CheckmarkThickness = 2;
            this.checkMovIntCaja.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkMovIntCaja.OnHoverUnchecked.BorderRadius = 12;
            this.checkMovIntCaja.OnHoverUnchecked.BorderThickness = 1;
            this.checkMovIntCaja.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkMovIntCaja.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkMovIntCaja.OnUncheck.BorderRadius = 12;
            this.checkMovIntCaja.OnUncheck.BorderThickness = 1;
            this.checkMovIntCaja.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkMovIntCaja.Size = new System.Drawing.Size(17, 17);
            this.checkMovIntCaja.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkMovIntCaja.TabIndex = 157;
            this.checkMovIntCaja.TabStop = false;
            this.checkMovIntCaja.ThreeState = false;
            this.checkMovIntCaja.ToolTipText = null;
            // 
            // checkTrans
            // 
            this.checkTrans.AllowBindingControlAnimation = true;
            this.checkTrans.AllowBindingControlColorChanges = false;
            this.checkTrans.AllowBindingControlLocation = true;
            this.checkTrans.AllowCheckBoxAnimation = false;
            this.checkTrans.AllowCheckmarkAnimation = true;
            this.checkTrans.AllowOnHoverStates = true;
            this.checkTrans.AutoCheck = true;
            this.checkTrans.BackColor = System.Drawing.Color.Transparent;
            this.checkTrans.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkTrans.BackgroundImage")));
            this.checkTrans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkTrans.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkTrans.BorderRadius = 12;
            this.checkTrans.Checked = false;
            this.checkTrans.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkTrans.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkTrans.CustomCheckmarkImage = null;
            this.checkTrans.Location = new System.Drawing.Point(93, 231);
            this.checkTrans.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkTrans.Name = "checkTrans";
            this.checkTrans.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkTrans.OnCheck.BorderRadius = 12;
            this.checkTrans.OnCheck.BorderThickness = 2;
            this.checkTrans.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkTrans.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkTrans.OnCheck.CheckmarkThickness = 2;
            this.checkTrans.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkTrans.OnDisable.BorderRadius = 12;
            this.checkTrans.OnDisable.BorderThickness = 2;
            this.checkTrans.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTrans.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkTrans.OnDisable.CheckmarkThickness = 2;
            this.checkTrans.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTrans.OnHoverChecked.BorderRadius = 12;
            this.checkTrans.OnHoverChecked.BorderThickness = 2;
            this.checkTrans.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTrans.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkTrans.OnHoverChecked.CheckmarkThickness = 2;
            this.checkTrans.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTrans.OnHoverUnchecked.BorderRadius = 12;
            this.checkTrans.OnHoverUnchecked.BorderThickness = 1;
            this.checkTrans.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTrans.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkTrans.OnUncheck.BorderRadius = 12;
            this.checkTrans.OnUncheck.BorderThickness = 1;
            this.checkTrans.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTrans.Size = new System.Drawing.Size(17, 17);
            this.checkTrans.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkTrans.TabIndex = 158;
            this.checkTrans.TabStop = false;
            this.checkTrans.ThreeState = false;
            this.checkTrans.ToolTipText = null;
            // 
            // checkVta
            // 
            this.checkVta.AllowBindingControlAnimation = true;
            this.checkVta.AllowBindingControlColorChanges = false;
            this.checkVta.AllowBindingControlLocation = true;
            this.checkVta.AllowCheckBoxAnimation = false;
            this.checkVta.AllowCheckmarkAnimation = true;
            this.checkVta.AllowOnHoverStates = true;
            this.checkVta.AutoCheck = true;
            this.checkVta.BackColor = System.Drawing.Color.Transparent;
            this.checkVta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkVta.BackgroundImage")));
            this.checkVta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkVta.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkVta.BorderRadius = 12;
            this.checkVta.Checked = false;
            this.checkVta.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkVta.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkVta.CustomCheckmarkImage = null;
            this.checkVta.Location = new System.Drawing.Point(93, 139);
            this.checkVta.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkVta.Name = "checkVta";
            this.checkVta.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkVta.OnCheck.BorderRadius = 12;
            this.checkVta.OnCheck.BorderThickness = 2;
            this.checkVta.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkVta.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkVta.OnCheck.CheckmarkThickness = 2;
            this.checkVta.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkVta.OnDisable.BorderRadius = 12;
            this.checkVta.OnDisable.BorderThickness = 2;
            this.checkVta.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkVta.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkVta.OnDisable.CheckmarkThickness = 2;
            this.checkVta.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkVta.OnHoverChecked.BorderRadius = 12;
            this.checkVta.OnHoverChecked.BorderThickness = 2;
            this.checkVta.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkVta.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkVta.OnHoverChecked.CheckmarkThickness = 2;
            this.checkVta.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkVta.OnHoverUnchecked.BorderRadius = 12;
            this.checkVta.OnHoverUnchecked.BorderThickness = 1;
            this.checkVta.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkVta.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkVta.OnUncheck.BorderRadius = 12;
            this.checkVta.OnUncheck.BorderThickness = 1;
            this.checkVta.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkVta.Size = new System.Drawing.Size(17, 17);
            this.checkVta.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkVta.TabIndex = 159;
            this.checkVta.TabStop = false;
            this.checkVta.ThreeState = false;
            this.checkVta.ToolTipText = null;
            // 
            // checkDCBan
            // 
            this.checkDCBan.AllowBindingControlAnimation = true;
            this.checkDCBan.AllowBindingControlColorChanges = false;
            this.checkDCBan.AllowBindingControlLocation = true;
            this.checkDCBan.AllowCheckBoxAnimation = false;
            this.checkDCBan.AllowCheckmarkAnimation = true;
            this.checkDCBan.AllowOnHoverStates = true;
            this.checkDCBan.AutoCheck = true;
            this.checkDCBan.BackColor = System.Drawing.Color.Transparent;
            this.checkDCBan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkDCBan.BackgroundImage")));
            this.checkDCBan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkDCBan.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkDCBan.BorderRadius = 12;
            this.checkDCBan.Checked = false;
            this.checkDCBan.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkDCBan.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkDCBan.CustomCheckmarkImage = null;
            this.checkDCBan.Location = new System.Drawing.Point(93, 277);
            this.checkDCBan.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkDCBan.Name = "checkDCBan";
            this.checkDCBan.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkDCBan.OnCheck.BorderRadius = 12;
            this.checkDCBan.OnCheck.BorderThickness = 2;
            this.checkDCBan.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkDCBan.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkDCBan.OnCheck.CheckmarkThickness = 2;
            this.checkDCBan.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkDCBan.OnDisable.BorderRadius = 12;
            this.checkDCBan.OnDisable.BorderThickness = 2;
            this.checkDCBan.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDCBan.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkDCBan.OnDisable.CheckmarkThickness = 2;
            this.checkDCBan.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDCBan.OnHoverChecked.BorderRadius = 12;
            this.checkDCBan.OnHoverChecked.BorderThickness = 2;
            this.checkDCBan.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDCBan.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkDCBan.OnHoverChecked.CheckmarkThickness = 2;
            this.checkDCBan.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDCBan.OnHoverUnchecked.BorderRadius = 12;
            this.checkDCBan.OnHoverUnchecked.BorderThickness = 1;
            this.checkDCBan.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDCBan.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkDCBan.OnUncheck.BorderRadius = 12;
            this.checkDCBan.OnUncheck.BorderThickness = 1;
            this.checkDCBan.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDCBan.Size = new System.Drawing.Size(17, 17);
            this.checkDCBan.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkDCBan.TabIndex = 160;
            this.checkDCBan.TabStop = false;
            this.checkDCBan.ThreeState = false;
            this.checkDCBan.ToolTipText = null;
            // 
            // checkExtraccion
            // 
            this.checkExtraccion.AllowBindingControlAnimation = true;
            this.checkExtraccion.AllowBindingControlColorChanges = false;
            this.checkExtraccion.AllowBindingControlLocation = true;
            this.checkExtraccion.AllowCheckBoxAnimation = false;
            this.checkExtraccion.AllowCheckmarkAnimation = true;
            this.checkExtraccion.AllowOnHoverStates = true;
            this.checkExtraccion.AutoCheck = true;
            this.checkExtraccion.BackColor = System.Drawing.Color.Transparent;
            this.checkExtraccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkExtraccion.BackgroundImage")));
            this.checkExtraccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkExtraccion.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkExtraccion.BorderRadius = 12;
            this.checkExtraccion.Checked = false;
            this.checkExtraccion.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkExtraccion.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkExtraccion.CustomCheckmarkImage = null;
            this.checkExtraccion.Location = new System.Drawing.Point(93, 300);
            this.checkExtraccion.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkExtraccion.Name = "checkExtraccion";
            this.checkExtraccion.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkExtraccion.OnCheck.BorderRadius = 12;
            this.checkExtraccion.OnCheck.BorderThickness = 2;
            this.checkExtraccion.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkExtraccion.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkExtraccion.OnCheck.CheckmarkThickness = 2;
            this.checkExtraccion.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkExtraccion.OnDisable.BorderRadius = 12;
            this.checkExtraccion.OnDisable.BorderThickness = 2;
            this.checkExtraccion.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkExtraccion.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkExtraccion.OnDisable.CheckmarkThickness = 2;
            this.checkExtraccion.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkExtraccion.OnHoverChecked.BorderRadius = 12;
            this.checkExtraccion.OnHoverChecked.BorderThickness = 2;
            this.checkExtraccion.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkExtraccion.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkExtraccion.OnHoverChecked.CheckmarkThickness = 2;
            this.checkExtraccion.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkExtraccion.OnHoverUnchecked.BorderRadius = 12;
            this.checkExtraccion.OnHoverUnchecked.BorderThickness = 1;
            this.checkExtraccion.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkExtraccion.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkExtraccion.OnUncheck.BorderRadius = 12;
            this.checkExtraccion.OnUncheck.BorderThickness = 1;
            this.checkExtraccion.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkExtraccion.Size = new System.Drawing.Size(17, 17);
            this.checkExtraccion.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkExtraccion.TabIndex = 161;
            this.checkExtraccion.TabStop = false;
            this.checkExtraccion.ThreeState = false;
            this.checkExtraccion.ToolTipText = null;
            // 
            // checkCaucion
            // 
            this.checkCaucion.AllowBindingControlAnimation = true;
            this.checkCaucion.AllowBindingControlColorChanges = false;
            this.checkCaucion.AllowBindingControlLocation = true;
            this.checkCaucion.AllowCheckBoxAnimation = false;
            this.checkCaucion.AllowCheckmarkAnimation = true;
            this.checkCaucion.AllowOnHoverStates = true;
            this.checkCaucion.AutoCheck = true;
            this.checkCaucion.BackColor = System.Drawing.Color.Transparent;
            this.checkCaucion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkCaucion.BackgroundImage")));
            this.checkCaucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkCaucion.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkCaucion.BorderRadius = 12;
            this.checkCaucion.Checked = false;
            this.checkCaucion.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkCaucion.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkCaucion.CustomCheckmarkImage = null;
            this.checkCaucion.Location = new System.Drawing.Point(93, 323);
            this.checkCaucion.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkCaucion.Name = "checkCaucion";
            this.checkCaucion.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkCaucion.OnCheck.BorderRadius = 12;
            this.checkCaucion.OnCheck.BorderThickness = 2;
            this.checkCaucion.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkCaucion.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkCaucion.OnCheck.CheckmarkThickness = 2;
            this.checkCaucion.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkCaucion.OnDisable.BorderRadius = 12;
            this.checkCaucion.OnDisable.BorderThickness = 2;
            this.checkCaucion.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCaucion.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkCaucion.OnDisable.CheckmarkThickness = 2;
            this.checkCaucion.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCaucion.OnHoverChecked.BorderRadius = 12;
            this.checkCaucion.OnHoverChecked.BorderThickness = 2;
            this.checkCaucion.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCaucion.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkCaucion.OnHoverChecked.CheckmarkThickness = 2;
            this.checkCaucion.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkCaucion.OnHoverUnchecked.BorderRadius = 12;
            this.checkCaucion.OnHoverUnchecked.BorderThickness = 1;
            this.checkCaucion.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCaucion.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkCaucion.OnUncheck.BorderRadius = 12;
            this.checkCaucion.OnUncheck.BorderThickness = 1;
            this.checkCaucion.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkCaucion.Size = new System.Drawing.Size(17, 17);
            this.checkCaucion.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkCaucion.TabIndex = 162;
            this.checkCaucion.TabStop = false;
            this.checkCaucion.ThreeState = false;
            this.checkCaucion.ToolTipText = null;
            // 
            // checkTraban
            // 
            this.checkTraban.AllowBindingControlAnimation = true;
            this.checkTraban.AllowBindingControlColorChanges = false;
            this.checkTraban.AllowBindingControlLocation = true;
            this.checkTraban.AllowCheckBoxAnimation = false;
            this.checkTraban.AllowCheckmarkAnimation = true;
            this.checkTraban.AllowOnHoverStates = true;
            this.checkTraban.AutoCheck = true;
            this.checkTraban.BackColor = System.Drawing.Color.Transparent;
            this.checkTraban.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkTraban.BackgroundImage")));
            this.checkTraban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkTraban.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkTraban.BorderRadius = 12;
            this.checkTraban.Checked = false;
            this.checkTraban.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkTraban.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkTraban.CustomCheckmarkImage = null;
            this.checkTraban.Location = new System.Drawing.Point(93, 346);
            this.checkTraban.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkTraban.Name = "checkTraban";
            this.checkTraban.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkTraban.OnCheck.BorderRadius = 12;
            this.checkTraban.OnCheck.BorderThickness = 2;
            this.checkTraban.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkTraban.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkTraban.OnCheck.CheckmarkThickness = 2;
            this.checkTraban.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkTraban.OnDisable.BorderRadius = 12;
            this.checkTraban.OnDisable.BorderThickness = 2;
            this.checkTraban.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTraban.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkTraban.OnDisable.CheckmarkThickness = 2;
            this.checkTraban.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTraban.OnHoverChecked.BorderRadius = 12;
            this.checkTraban.OnHoverChecked.BorderThickness = 2;
            this.checkTraban.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTraban.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkTraban.OnHoverChecked.CheckmarkThickness = 2;
            this.checkTraban.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkTraban.OnHoverUnchecked.BorderRadius = 12;
            this.checkTraban.OnHoverUnchecked.BorderThickness = 1;
            this.checkTraban.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTraban.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkTraban.OnUncheck.BorderRadius = 12;
            this.checkTraban.OnUncheck.BorderThickness = 1;
            this.checkTraban.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkTraban.Size = new System.Drawing.Size(17, 17);
            this.checkTraban.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkTraban.TabIndex = 163;
            this.checkTraban.TabStop = false;
            this.checkTraban.ThreeState = false;
            this.checkTraban.ToolTipText = null;
            // 
            // checkDep
            // 
            this.checkDep.AllowBindingControlAnimation = true;
            this.checkDep.AllowBindingControlColorChanges = false;
            this.checkDep.AllowBindingControlLocation = true;
            this.checkDep.AllowCheckBoxAnimation = false;
            this.checkDep.AllowCheckmarkAnimation = true;
            this.checkDep.AllowOnHoverStates = true;
            this.checkDep.AutoCheck = true;
            this.checkDep.BackColor = System.Drawing.Color.Transparent;
            this.checkDep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkDep.BackgroundImage")));
            this.checkDep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkDep.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkDep.BorderRadius = 12;
            this.checkDep.Checked = false;
            this.checkDep.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkDep.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkDep.CustomCheckmarkImage = null;
            this.checkDep.Location = new System.Drawing.Point(93, 254);
            this.checkDep.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkDep.Name = "checkDep";
            this.checkDep.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkDep.OnCheck.BorderRadius = 12;
            this.checkDep.OnCheck.BorderThickness = 2;
            this.checkDep.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkDep.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkDep.OnCheck.CheckmarkThickness = 2;
            this.checkDep.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkDep.OnDisable.BorderRadius = 12;
            this.checkDep.OnDisable.BorderThickness = 2;
            this.checkDep.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDep.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkDep.OnDisable.CheckmarkThickness = 2;
            this.checkDep.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDep.OnHoverChecked.BorderRadius = 12;
            this.checkDep.OnHoverChecked.BorderThickness = 2;
            this.checkDep.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDep.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkDep.OnHoverChecked.CheckmarkThickness = 2;
            this.checkDep.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkDep.OnHoverUnchecked.BorderRadius = 12;
            this.checkDep.OnHoverUnchecked.BorderThickness = 1;
            this.checkDep.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDep.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkDep.OnUncheck.BorderRadius = 12;
            this.checkDep.OnUncheck.BorderThickness = 1;
            this.checkDep.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkDep.Size = new System.Drawing.Size(17, 17);
            this.checkDep.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkDep.TabIndex = 164;
            this.checkDep.TabStop = false;
            this.checkDep.ThreeState = false;
            this.checkDep.ToolTipText = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(119, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 165;
            this.label6.Text = "Módulo Compras.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(119, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 166;
            this.label7.Text = "Módulo Ventas.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(119, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 16);
            this.label8.TabIndex = 167;
            this.label8.Text = "Liquidaciones de Tarjeta.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(119, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 16);
            this.label9.TabIndex = 168;
            this.label9.Text = "Transferencias de Caja.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(119, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 16);
            this.label10.TabIndex = 169;
            this.label10.Text = "Movimientos Varios de Caja.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(119, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 170;
            this.label11.Text = "Depósitos Bancarios.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(119, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 16);
            this.label12.TabIndex = 171;
            this.label12.Text = "Débitos/Créditos Bancarios.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(119, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 16);
            this.label13.TabIndex = 172;
            this.label13.Text = "Extracciones Bancarias.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(119, 323);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 16);
            this.label14.TabIndex = 173;
            this.label14.Text = "Depósitos en Caución.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(116, 346);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 16);
            this.label15.TabIndex = 174;
            this.label15.Text = "Transferencias Bancarias.";
            // 
            // btnCtaCont
            // 
            this.btnCtaCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnCtaCont.FlatAppearance.BorderSize = 0;
            this.btnCtaCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCtaCont.Image = ((System.Drawing.Image)(resources.GetObject("btnCtaCont.Image")));
            this.btnCtaCont.Location = new System.Drawing.Point(336, 93);
            this.btnCtaCont.Name = "btnCtaCont";
            this.btnCtaCont.Size = new System.Drawing.Size(23, 23);
            this.btnCtaCont.TabIndex = 4;
            this.btnCtaCont.UseVisualStyleBackColor = false;
            this.btnCtaCont.Click += new System.EventHandler(this.btnCtaCont_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(169, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 1);
            this.panel1.TabIndex = 179;
            // 
            // txtDescriCuenta
            // 
            this.txtDescriCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDescriCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescriCuenta.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriCuenta.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDescriCuenta.Location = new System.Drawing.Point(169, 96);
            this.txtDescriCuenta.Name = "txtDescriCuenta";
            this.txtDescriCuenta.Size = new System.Drawing.Size(163, 19);
            this.txtDescriCuenta.TabIndex = 3;
            this.txtDescriCuenta.Tag = "11000";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(122, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(41, 1);
            this.panel3.TabIndex = 178;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNroCuenta.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCuenta.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNroCuenta.Location = new System.Drawing.Point(122, 95);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(41, 19);
            this.txtNroCuenta.TabIndex = 2;
            this.txtNroCuenta.Tag = "10100";
            this.txtNroCuenta.TextChanged += new System.EventHandler(this.txtNroCuenta_TextChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel8.Location = new System.Drawing.Point(12, 128);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(368, 1);
            this.panel8.TabIndex = 180;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel2.Location = new System.Drawing.Point(15, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 1);
            this.panel2.TabIndex = 181;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel4.Location = new System.Drawing.Point(15, 423);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(368, 1);
            this.panel4.TabIndex = 182;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnProcesar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnProcesar.BorderColor = System.Drawing.Color.White;
            this.btnProcesar.BorderRadius = 0;
            this.btnProcesar.BorderSize = 0;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProcesar.Location = new System.Drawing.Point(109, 441);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(175, 44);
            this.btnProcesar.TabIndex = 183;
            this.btnProcesar.Tag = "";
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // timerCuenta
            // 
            this.timerCuenta.Tick += new System.EventHandler(this.timerCuenta_Tick);
            // 
            // frmAuditoriaInterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(392, 500);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.btnCtaCont);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDescriCuenta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtNroCuenta);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkDep);
            this.Controls.Add(this.checkTraban);
            this.Controls.Add(this.checkCaucion);
            this.Controls.Add(this.checkExtraccion);
            this.Controls.Add(this.checkDCBan);
            this.Controls.Add(this.checkVta);
            this.Controls.Add(this.checkTrans);
            this.Controls.Add(this.checkMovIntCaja);
            this.Controls.Add(this.checkLiqTC);
            this.Controls.Add(this.checkCpa);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.lblConteo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.maskHasta);
            this.Controls.Add(this.maskDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuditoriaInterna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria Interna";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblControlBar;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.MaskedTextBox maskHasta;
        private System.Windows.Forms.MaskedTextBox maskDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConteo;
        private Bunifu.UI.WinForms.BunifuProgressBar ProgressBar;
        private Bunifu.UI.WinForms.BunifuCheckBox checkCpa;
        private Bunifu.UI.WinForms.BunifuCheckBox checkLiqTC;
        private Bunifu.UI.WinForms.BunifuCheckBox checkMovIntCaja;
        private Bunifu.UI.WinForms.BunifuCheckBox checkTrans;
        private Bunifu.UI.WinForms.BunifuCheckBox checkVta;
        private Bunifu.UI.WinForms.BunifuCheckBox checkDCBan;
        private Bunifu.UI.WinForms.BunifuCheckBox checkExtraccion;
        private Bunifu.UI.WinForms.BunifuCheckBox checkCaucion;
        private Bunifu.UI.WinForms.BunifuCheckBox checkTraban;
        private Bunifu.UI.WinForms.BunifuCheckBox checkDep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCtaCont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescriCuenta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNroCuenta;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private RJCodeAdvance.RJControls.RJButton btnProcesar;
        private System.Windows.Forms.Timer timerCuenta;
    }
}