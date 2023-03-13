namespace SistemaContable.Inicio.Contabilidad.Libro_Diario
{
    partial class frmLibroDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroDiario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.Mensaje = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ChechInfDet = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckInfAgDi = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckInfAgMen = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CheckImpSinEnNF = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CheckImpSinEnc = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckImpStandar = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbIdEjercicio = new System.Windows.Forms.TextBox();
            this.tbDescriEjercicio = new System.Windows.Forms.TextBox();
            this.tbLibroN = new System.Windows.Forms.TextBox();
            this.tbFolioInicial = new System.Windows.Forms.TextBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
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
            this.panel1.Size = new System.Drawing.Size(547, 21);
            this.panel1.TabIndex = 16;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Libro Diario (Reporte)";
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
            this.btnCerrar.Location = new System.Drawing.Point(523, 0);
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
            // Mensaje
            // 
            this.Mensaje.AutoSize = true;
            this.Mensaje.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mensaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Mensaje.Location = new System.Drawing.Point(124, 37);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(57, 17);
            this.Mensaje.TabIndex = 18;
            this.Mensaje.Text = "Ejercicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(134, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(138, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Hasta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(158, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 16);
            this.label13.TabIndex = 105;
            this.label13.Text = "Informe Detallado";
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
            this.ChechInfDet.Location = new System.Drawing.Point(138, 140);
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
            this.ChechInfDet.TabIndex = 104;
            this.ChechInfDet.ThreeState = false;
            this.ChechInfDet.ToolTipText = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(158, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 107;
            this.label4.Text = "Informe Agrupado Diario";
            // 
            // CheckInfAgDi
            // 
            this.CheckInfAgDi.AllowBindingControlAnimation = true;
            this.CheckInfAgDi.AllowBindingControlColorChanges = false;
            this.CheckInfAgDi.AllowBindingControlLocation = true;
            this.CheckInfAgDi.AllowCheckBoxAnimation = false;
            this.CheckInfAgDi.AllowCheckmarkAnimation = true;
            this.CheckInfAgDi.AllowOnHoverStates = true;
            this.CheckInfAgDi.AutoCheck = true;
            this.CheckInfAgDi.BackColor = System.Drawing.Color.Transparent;
            this.CheckInfAgDi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckInfAgDi.BackgroundImage")));
            this.CheckInfAgDi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckInfAgDi.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckInfAgDi.BorderRadius = 12;
            this.CheckInfAgDi.Checked = false;
            this.CheckInfAgDi.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckInfAgDi.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckInfAgDi.CustomCheckmarkImage = null;
            this.CheckInfAgDi.Location = new System.Drawing.Point(138, 163);
            this.CheckInfAgDi.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckInfAgDi.Name = "CheckInfAgDi";
            this.CheckInfAgDi.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInfAgDi.OnCheck.BorderRadius = 12;
            this.CheckInfAgDi.OnCheck.BorderThickness = 2;
            this.CheckInfAgDi.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInfAgDi.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInfAgDi.OnCheck.CheckmarkThickness = 2;
            this.CheckInfAgDi.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckInfAgDi.OnDisable.BorderRadius = 12;
            this.CheckInfAgDi.OnDisable.BorderThickness = 2;
            this.CheckInfAgDi.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgDi.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckInfAgDi.OnDisable.CheckmarkThickness = 2;
            this.CheckInfAgDi.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgDi.OnHoverChecked.BorderRadius = 12;
            this.CheckInfAgDi.OnHoverChecked.BorderThickness = 2;
            this.CheckInfAgDi.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgDi.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInfAgDi.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckInfAgDi.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgDi.OnHoverUnchecked.BorderRadius = 12;
            this.CheckInfAgDi.OnHoverUnchecked.BorderThickness = 1;
            this.CheckInfAgDi.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgDi.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckInfAgDi.OnUncheck.BorderRadius = 12;
            this.CheckInfAgDi.OnUncheck.BorderThickness = 1;
            this.CheckInfAgDi.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgDi.Size = new System.Drawing.Size(17, 17);
            this.CheckInfAgDi.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckInfAgDi.TabIndex = 106;
            this.CheckInfAgDi.ThreeState = false;
            this.CheckInfAgDi.ToolTipText = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(158, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 109;
            this.label5.Text = "Informe Agrupado Mensual";
            // 
            // CheckInfAgMen
            // 
            this.CheckInfAgMen.AllowBindingControlAnimation = true;
            this.CheckInfAgMen.AllowBindingControlColorChanges = false;
            this.CheckInfAgMen.AllowBindingControlLocation = true;
            this.CheckInfAgMen.AllowCheckBoxAnimation = false;
            this.CheckInfAgMen.AllowCheckmarkAnimation = true;
            this.CheckInfAgMen.AllowOnHoverStates = true;
            this.CheckInfAgMen.AutoCheck = true;
            this.CheckInfAgMen.BackColor = System.Drawing.Color.Transparent;
            this.CheckInfAgMen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckInfAgMen.BackgroundImage")));
            this.CheckInfAgMen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckInfAgMen.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckInfAgMen.BorderRadius = 12;
            this.CheckInfAgMen.Checked = false;
            this.CheckInfAgMen.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckInfAgMen.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckInfAgMen.CustomCheckmarkImage = null;
            this.CheckInfAgMen.Location = new System.Drawing.Point(138, 186);
            this.CheckInfAgMen.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckInfAgMen.Name = "CheckInfAgMen";
            this.CheckInfAgMen.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInfAgMen.OnCheck.BorderRadius = 12;
            this.CheckInfAgMen.OnCheck.BorderThickness = 2;
            this.CheckInfAgMen.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInfAgMen.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInfAgMen.OnCheck.CheckmarkThickness = 2;
            this.CheckInfAgMen.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckInfAgMen.OnDisable.BorderRadius = 12;
            this.CheckInfAgMen.OnDisable.BorderThickness = 2;
            this.CheckInfAgMen.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgMen.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckInfAgMen.OnDisable.CheckmarkThickness = 2;
            this.CheckInfAgMen.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgMen.OnHoverChecked.BorderRadius = 12;
            this.CheckInfAgMen.OnHoverChecked.BorderThickness = 2;
            this.CheckInfAgMen.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgMen.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInfAgMen.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckInfAgMen.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInfAgMen.OnHoverUnchecked.BorderRadius = 12;
            this.CheckInfAgMen.OnHoverUnchecked.BorderThickness = 1;
            this.CheckInfAgMen.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgMen.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckInfAgMen.OnUncheck.BorderRadius = 12;
            this.CheckInfAgMen.OnUncheck.BorderThickness = 1;
            this.CheckInfAgMen.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInfAgMen.Size = new System.Drawing.Size(17, 17);
            this.CheckInfAgMen.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckInfAgMen.TabIndex = 108;
            this.CheckInfAgMen.ThreeState = false;
            this.CheckInfAgMen.ToolTipText = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(157, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 16);
            this.label6.TabIndex = 118;
            this.label6.Text = "Impresion Sin Encabezado (Con Nº de folio)";
            // 
            // CheckImpSinEnNF
            // 
            this.CheckImpSinEnNF.AllowBindingControlAnimation = true;
            this.CheckImpSinEnNF.AllowBindingControlColorChanges = false;
            this.CheckImpSinEnNF.AllowBindingControlLocation = true;
            this.CheckImpSinEnNF.AllowCheckBoxAnimation = false;
            this.CheckImpSinEnNF.AllowCheckmarkAnimation = true;
            this.CheckImpSinEnNF.AllowOnHoverStates = true;
            this.CheckImpSinEnNF.AutoCheck = true;
            this.CheckImpSinEnNF.BackColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnNF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckImpSinEnNF.BackgroundImage")));
            this.CheckImpSinEnNF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckImpSinEnNF.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckImpSinEnNF.BorderRadius = 12;
            this.CheckImpSinEnNF.Checked = false;
            this.CheckImpSinEnNF.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckImpSinEnNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckImpSinEnNF.CustomCheckmarkImage = null;
            this.CheckImpSinEnNF.Location = new System.Drawing.Point(137, 341);
            this.CheckImpSinEnNF.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckImpSinEnNF.Name = "CheckImpSinEnNF";
            this.CheckImpSinEnNF.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpSinEnNF.OnCheck.BorderRadius = 12;
            this.CheckImpSinEnNF.OnCheck.BorderThickness = 2;
            this.CheckImpSinEnNF.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpSinEnNF.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpSinEnNF.OnCheck.CheckmarkThickness = 2;
            this.CheckImpSinEnNF.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckImpSinEnNF.OnDisable.BorderRadius = 12;
            this.CheckImpSinEnNF.OnDisable.BorderThickness = 2;
            this.CheckImpSinEnNF.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnNF.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckImpSinEnNF.OnDisable.CheckmarkThickness = 2;
            this.CheckImpSinEnNF.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnNF.OnHoverChecked.BorderRadius = 12;
            this.CheckImpSinEnNF.OnHoverChecked.BorderThickness = 2;
            this.CheckImpSinEnNF.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnNF.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpSinEnNF.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckImpSinEnNF.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnNF.OnHoverUnchecked.BorderRadius = 12;
            this.CheckImpSinEnNF.OnHoverUnchecked.BorderThickness = 1;
            this.CheckImpSinEnNF.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnNF.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckImpSinEnNF.OnUncheck.BorderRadius = 12;
            this.CheckImpSinEnNF.OnUncheck.BorderThickness = 1;
            this.CheckImpSinEnNF.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnNF.Size = new System.Drawing.Size(17, 17);
            this.CheckImpSinEnNF.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckImpSinEnNF.TabIndex = 117;
            this.CheckImpSinEnNF.ThreeState = false;
            this.CheckImpSinEnNF.ToolTipText = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(157, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 16);
            this.label7.TabIndex = 116;
            this.label7.Text = "Impresion Sin Encabezado";
            // 
            // CheckImpSinEnc
            // 
            this.CheckImpSinEnc.AllowBindingControlAnimation = true;
            this.CheckImpSinEnc.AllowBindingControlColorChanges = false;
            this.CheckImpSinEnc.AllowBindingControlLocation = true;
            this.CheckImpSinEnc.AllowCheckBoxAnimation = false;
            this.CheckImpSinEnc.AllowCheckmarkAnimation = true;
            this.CheckImpSinEnc.AllowOnHoverStates = true;
            this.CheckImpSinEnc.AutoCheck = true;
            this.CheckImpSinEnc.BackColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckImpSinEnc.BackgroundImage")));
            this.CheckImpSinEnc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckImpSinEnc.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckImpSinEnc.BorderRadius = 12;
            this.CheckImpSinEnc.Checked = false;
            this.CheckImpSinEnc.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckImpSinEnc.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckImpSinEnc.CustomCheckmarkImage = null;
            this.CheckImpSinEnc.Location = new System.Drawing.Point(137, 318);
            this.CheckImpSinEnc.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckImpSinEnc.Name = "CheckImpSinEnc";
            this.CheckImpSinEnc.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpSinEnc.OnCheck.BorderRadius = 12;
            this.CheckImpSinEnc.OnCheck.BorderThickness = 2;
            this.CheckImpSinEnc.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpSinEnc.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpSinEnc.OnCheck.CheckmarkThickness = 2;
            this.CheckImpSinEnc.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckImpSinEnc.OnDisable.BorderRadius = 12;
            this.CheckImpSinEnc.OnDisable.BorderThickness = 2;
            this.CheckImpSinEnc.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnc.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckImpSinEnc.OnDisable.CheckmarkThickness = 2;
            this.CheckImpSinEnc.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnc.OnHoverChecked.BorderRadius = 12;
            this.CheckImpSinEnc.OnHoverChecked.BorderThickness = 2;
            this.CheckImpSinEnc.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnc.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpSinEnc.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckImpSinEnc.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpSinEnc.OnHoverUnchecked.BorderRadius = 12;
            this.CheckImpSinEnc.OnHoverUnchecked.BorderThickness = 1;
            this.CheckImpSinEnc.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnc.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckImpSinEnc.OnUncheck.BorderRadius = 12;
            this.CheckImpSinEnc.OnUncheck.BorderThickness = 1;
            this.CheckImpSinEnc.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpSinEnc.Size = new System.Drawing.Size(17, 17);
            this.CheckImpSinEnc.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckImpSinEnc.TabIndex = 115;
            this.CheckImpSinEnc.ThreeState = false;
            this.CheckImpSinEnc.ToolTipText = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(157, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 114;
            this.label8.Text = "Impresion Standar";
            // 
            // CheckImpStandar
            // 
            this.CheckImpStandar.AllowBindingControlAnimation = true;
            this.CheckImpStandar.AllowBindingControlColorChanges = false;
            this.CheckImpStandar.AllowBindingControlLocation = true;
            this.CheckImpStandar.AllowCheckBoxAnimation = false;
            this.CheckImpStandar.AllowCheckmarkAnimation = true;
            this.CheckImpStandar.AllowOnHoverStates = true;
            this.CheckImpStandar.AutoCheck = true;
            this.CheckImpStandar.BackColor = System.Drawing.Color.Transparent;
            this.CheckImpStandar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckImpStandar.BackgroundImage")));
            this.CheckImpStandar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckImpStandar.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckImpStandar.BorderRadius = 12;
            this.CheckImpStandar.Checked = false;
            this.CheckImpStandar.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckImpStandar.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckImpStandar.CustomCheckmarkImage = null;
            this.CheckImpStandar.Location = new System.Drawing.Point(137, 295);
            this.CheckImpStandar.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckImpStandar.Name = "CheckImpStandar";
            this.CheckImpStandar.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpStandar.OnCheck.BorderRadius = 12;
            this.CheckImpStandar.OnCheck.BorderThickness = 2;
            this.CheckImpStandar.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckImpStandar.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpStandar.OnCheck.CheckmarkThickness = 2;
            this.CheckImpStandar.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckImpStandar.OnDisable.BorderRadius = 12;
            this.CheckImpStandar.OnDisable.BorderThickness = 2;
            this.CheckImpStandar.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpStandar.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckImpStandar.OnDisable.CheckmarkThickness = 2;
            this.CheckImpStandar.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpStandar.OnHoverChecked.BorderRadius = 12;
            this.CheckImpStandar.OnHoverChecked.BorderThickness = 2;
            this.CheckImpStandar.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpStandar.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckImpStandar.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckImpStandar.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckImpStandar.OnHoverUnchecked.BorderRadius = 12;
            this.CheckImpStandar.OnHoverUnchecked.BorderThickness = 1;
            this.CheckImpStandar.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpStandar.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckImpStandar.OnUncheck.BorderRadius = 12;
            this.CheckImpStandar.OnUncheck.BorderThickness = 1;
            this.CheckImpStandar.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckImpStandar.Size = new System.Drawing.Size(17, 17);
            this.CheckImpStandar.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckImpStandar.TabIndex = 113;
            this.CheckImpStandar.ThreeState = false;
            this.CheckImpStandar.ToolTipText = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(105, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 112;
            this.label9.Text = "Folio Inicial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(124, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 111;
            this.label10.Text = "Libro Nº:";
            // 
            // tbIdEjercicio
            // 
            this.tbIdEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbIdEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIdEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIdEjercicio.Location = new System.Drawing.Point(181, 36);
            this.tbIdEjercicio.Name = "tbIdEjercicio";
            this.tbIdEjercicio.Size = new System.Drawing.Size(78, 15);
            this.tbIdEjercicio.TabIndex = 119;
            // 
            // tbDescriEjercicio
            // 
            this.tbDescriEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescriEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescriEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescriEjercicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescriEjercicio.Location = new System.Drawing.Point(265, 36);
            this.tbDescriEjercicio.Name = "tbDescriEjercicio";
            this.tbDescriEjercicio.Size = new System.Drawing.Size(208, 15);
            this.tbDescriEjercicio.TabIndex = 120;
            // 
            // tbLibroN
            // 
            this.tbLibroN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbLibroN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLibroN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLibroN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLibroN.Location = new System.Drawing.Point(177, 225);
            this.tbLibroN.Name = "tbLibroN";
            this.tbLibroN.Size = new System.Drawing.Size(65, 15);
            this.tbLibroN.TabIndex = 121;
            // 
            // tbFolioInicial
            // 
            this.tbFolioInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbFolioInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFolioInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFolioInicial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbFolioInicial.Location = new System.Drawing.Point(177, 257);
            this.tbFolioInicial.Name = "tbFolioInicial";
            this.tbFolioInicial.Size = new System.Drawing.Size(65, 15);
            this.tbFolioInicial.TabIndex = 122;
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(181, 67);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(101, 20);
            this.dtDesde.TabIndex = 123;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(181, 100);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(101, 20);
            this.dtHasta.TabIndex = 124;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::SistemaContable.Properties.Resources.binocular2;
            this.btnBuscar.Location = new System.Drawing.Point(477, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 125;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.btnConfirmar.Location = new System.Drawing.Point(198, 376);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(151, 38);
            this.btnConfirmar.TabIndex = 126;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(177, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(65, 1);
            this.panel3.TabIndex = 167;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(177, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 1);
            this.panel2.TabIndex = 168;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(265, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 1);
            this.panel4.TabIndex = 169;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(181, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(78, 1);
            this.panel5.TabIndex = 170;
            // 
            // frmLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(547, 425);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.tbFolioInicial);
            this.Controls.Add(this.tbLibroN);
            this.Controls.Add(this.tbDescriEjercicio);
            this.Controls.Add(this.tbIdEjercicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CheckImpSinEnNF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CheckImpSinEnc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CheckImpStandar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CheckInfAgMen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckInfAgDi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ChechInfDet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLibroDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLibroDiario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private System.Windows.Forms.Label Mensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private Bunifu.UI.WinForms.BunifuCheckBox ChechInfDet;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInfAgDi;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInfAgMen;
        private System.Windows.Forms.Label label6;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckImpSinEnNF;
        private System.Windows.Forms.Label label7;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckImpSinEnc;
        private System.Windows.Forms.Label label8;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckImpStandar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbIdEjercicio;
        private System.Windows.Forms.TextBox tbDescriEjercicio;
        private System.Windows.Forms.TextBox tbLibroN;
        private System.Windows.Forms.TextBox tbFolioInicial;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Button btnBuscar;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}