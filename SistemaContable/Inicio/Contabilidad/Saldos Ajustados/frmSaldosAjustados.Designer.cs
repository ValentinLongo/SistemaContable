﻿namespace SistemaContable.Inicio.Contabilidad.Saldos_Ajustados
{
    partial class frmSaldosAjustados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldosAjustados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.checkSaldosSinAjuste = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkSaldosConAjuste = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.checkValoresdeAjuste = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSeleccion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCC = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new RJCodeAdvance.RJControls.RJButton();
            this.btnAsiento = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
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
            this.panel7.Size = new System.Drawing.Size(960, 21);
            this.panel7.TabIndex = 106;
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
            this.lblControlBar.Size = new System.Drawing.Size(88, 13);
            this.lblControlBar.TabIndex = 31;
            this.lblControlBar.Text = "Saldos Ajustados";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(846, 0);
            this.bunifuFormControlBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuFormControlBox1.MaximizeBox = true;
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
            this.bunifuFormControlBox1.Size = new System.Drawing.Size(114, 21);
            this.bunifuFormControlBox1.TabIndex = 29;
            // 
            // checkSaldosSinAjuste
            // 
            this.checkSaldosSinAjuste.AllowBindingControlAnimation = true;
            this.checkSaldosSinAjuste.AllowBindingControlColorChanges = false;
            this.checkSaldosSinAjuste.AllowBindingControlLocation = true;
            this.checkSaldosSinAjuste.AllowCheckBoxAnimation = false;
            this.checkSaldosSinAjuste.AllowCheckmarkAnimation = true;
            this.checkSaldosSinAjuste.AllowOnHoverStates = true;
            this.checkSaldosSinAjuste.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkSaldosSinAjuste.AutoCheck = true;
            this.checkSaldosSinAjuste.BackColor = System.Drawing.Color.Transparent;
            this.checkSaldosSinAjuste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkSaldosSinAjuste.BackgroundImage")));
            this.checkSaldosSinAjuste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkSaldosSinAjuste.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkSaldosSinAjuste.BorderRadius = 12;
            this.checkSaldosSinAjuste.Checked = false;
            this.checkSaldosSinAjuste.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkSaldosSinAjuste.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkSaldosSinAjuste.CustomCheckmarkImage = null;
            this.checkSaldosSinAjuste.Location = new System.Drawing.Point(8, 82);
            this.checkSaldosSinAjuste.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkSaldosSinAjuste.Name = "checkSaldosSinAjuste";
            this.checkSaldosSinAjuste.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkSaldosSinAjuste.OnCheck.BorderRadius = 12;
            this.checkSaldosSinAjuste.OnCheck.BorderThickness = 2;
            this.checkSaldosSinAjuste.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkSaldosSinAjuste.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkSaldosSinAjuste.OnCheck.CheckmarkThickness = 2;
            this.checkSaldosSinAjuste.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkSaldosSinAjuste.OnDisable.BorderRadius = 12;
            this.checkSaldosSinAjuste.OnDisable.BorderThickness = 2;
            this.checkSaldosSinAjuste.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosSinAjuste.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkSaldosSinAjuste.OnDisable.CheckmarkThickness = 2;
            this.checkSaldosSinAjuste.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosSinAjuste.OnHoverChecked.BorderRadius = 12;
            this.checkSaldosSinAjuste.OnHoverChecked.BorderThickness = 2;
            this.checkSaldosSinAjuste.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosSinAjuste.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkSaldosSinAjuste.OnHoverChecked.CheckmarkThickness = 2;
            this.checkSaldosSinAjuste.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosSinAjuste.OnHoverUnchecked.BorderRadius = 12;
            this.checkSaldosSinAjuste.OnHoverUnchecked.BorderThickness = 1;
            this.checkSaldosSinAjuste.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosSinAjuste.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkSaldosSinAjuste.OnUncheck.BorderRadius = 12;
            this.checkSaldosSinAjuste.OnUncheck.BorderThickness = 1;
            this.checkSaldosSinAjuste.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosSinAjuste.Size = new System.Drawing.Size(17, 17);
            this.checkSaldosSinAjuste.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkSaldosSinAjuste.TabIndex = 112;
            this.checkSaldosSinAjuste.ThreeState = false;
            this.checkSaldosSinAjuste.ToolTipText = null;
            this.checkSaldosSinAjuste.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.checkSSA);
            // 
            // checkSaldosConAjuste
            // 
            this.checkSaldosConAjuste.AllowBindingControlAnimation = true;
            this.checkSaldosConAjuste.AllowBindingControlColorChanges = false;
            this.checkSaldosConAjuste.AllowBindingControlLocation = true;
            this.checkSaldosConAjuste.AllowCheckBoxAnimation = false;
            this.checkSaldosConAjuste.AllowCheckmarkAnimation = true;
            this.checkSaldosConAjuste.AllowOnHoverStates = true;
            this.checkSaldosConAjuste.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkSaldosConAjuste.AutoCheck = true;
            this.checkSaldosConAjuste.BackColor = System.Drawing.Color.Transparent;
            this.checkSaldosConAjuste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkSaldosConAjuste.BackgroundImage")));
            this.checkSaldosConAjuste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkSaldosConAjuste.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkSaldosConAjuste.BorderRadius = 12;
            this.checkSaldosConAjuste.Checked = false;
            this.checkSaldosConAjuste.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkSaldosConAjuste.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkSaldosConAjuste.CustomCheckmarkImage = null;
            this.checkSaldosConAjuste.Location = new System.Drawing.Point(8, 58);
            this.checkSaldosConAjuste.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkSaldosConAjuste.Name = "checkSaldosConAjuste";
            this.checkSaldosConAjuste.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkSaldosConAjuste.OnCheck.BorderRadius = 12;
            this.checkSaldosConAjuste.OnCheck.BorderThickness = 2;
            this.checkSaldosConAjuste.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkSaldosConAjuste.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkSaldosConAjuste.OnCheck.CheckmarkThickness = 2;
            this.checkSaldosConAjuste.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkSaldosConAjuste.OnDisable.BorderRadius = 12;
            this.checkSaldosConAjuste.OnDisable.BorderThickness = 2;
            this.checkSaldosConAjuste.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosConAjuste.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkSaldosConAjuste.OnDisable.CheckmarkThickness = 2;
            this.checkSaldosConAjuste.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosConAjuste.OnHoverChecked.BorderRadius = 12;
            this.checkSaldosConAjuste.OnHoverChecked.BorderThickness = 2;
            this.checkSaldosConAjuste.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosConAjuste.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkSaldosConAjuste.OnHoverChecked.CheckmarkThickness = 2;
            this.checkSaldosConAjuste.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkSaldosConAjuste.OnHoverUnchecked.BorderRadius = 12;
            this.checkSaldosConAjuste.OnHoverUnchecked.BorderThickness = 1;
            this.checkSaldosConAjuste.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosConAjuste.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkSaldosConAjuste.OnUncheck.BorderRadius = 12;
            this.checkSaldosConAjuste.OnUncheck.BorderThickness = 1;
            this.checkSaldosConAjuste.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkSaldosConAjuste.Size = new System.Drawing.Size(17, 17);
            this.checkSaldosConAjuste.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkSaldosConAjuste.TabIndex = 111;
            this.checkSaldosConAjuste.ThreeState = false;
            this.checkSaldosConAjuste.ToolTipText = null;
            this.checkSaldosConAjuste.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.checkSCA);
            // 
            // checkValoresdeAjuste
            // 
            this.checkValoresdeAjuste.AllowBindingControlAnimation = true;
            this.checkValoresdeAjuste.AllowBindingControlColorChanges = false;
            this.checkValoresdeAjuste.AllowBindingControlLocation = true;
            this.checkValoresdeAjuste.AllowCheckBoxAnimation = false;
            this.checkValoresdeAjuste.AllowCheckmarkAnimation = true;
            this.checkValoresdeAjuste.AllowOnHoverStates = true;
            this.checkValoresdeAjuste.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkValoresdeAjuste.AutoCheck = true;
            this.checkValoresdeAjuste.BackColor = System.Drawing.Color.Transparent;
            this.checkValoresdeAjuste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkValoresdeAjuste.BackgroundImage")));
            this.checkValoresdeAjuste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkValoresdeAjuste.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.checkValoresdeAjuste.BorderRadius = 12;
            this.checkValoresdeAjuste.Checked = false;
            this.checkValoresdeAjuste.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.checkValoresdeAjuste.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkValoresdeAjuste.CustomCheckmarkImage = null;
            this.checkValoresdeAjuste.Location = new System.Drawing.Point(9, 34);
            this.checkValoresdeAjuste.MinimumSize = new System.Drawing.Size(17, 17);
            this.checkValoresdeAjuste.Name = "checkValoresdeAjuste";
            this.checkValoresdeAjuste.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkValoresdeAjuste.OnCheck.BorderRadius = 12;
            this.checkValoresdeAjuste.OnCheck.BorderThickness = 2;
            this.checkValoresdeAjuste.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.checkValoresdeAjuste.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.checkValoresdeAjuste.OnCheck.CheckmarkThickness = 2;
            this.checkValoresdeAjuste.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.checkValoresdeAjuste.OnDisable.BorderRadius = 12;
            this.checkValoresdeAjuste.OnDisable.BorderThickness = 2;
            this.checkValoresdeAjuste.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkValoresdeAjuste.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.checkValoresdeAjuste.OnDisable.CheckmarkThickness = 2;
            this.checkValoresdeAjuste.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkValoresdeAjuste.OnHoverChecked.BorderRadius = 12;
            this.checkValoresdeAjuste.OnHoverChecked.BorderThickness = 2;
            this.checkValoresdeAjuste.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkValoresdeAjuste.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.checkValoresdeAjuste.OnHoverChecked.CheckmarkThickness = 2;
            this.checkValoresdeAjuste.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.checkValoresdeAjuste.OnHoverUnchecked.BorderRadius = 12;
            this.checkValoresdeAjuste.OnHoverUnchecked.BorderThickness = 1;
            this.checkValoresdeAjuste.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkValoresdeAjuste.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.checkValoresdeAjuste.OnUncheck.BorderRadius = 12;
            this.checkValoresdeAjuste.OnUncheck.BorderThickness = 1;
            this.checkValoresdeAjuste.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.checkValoresdeAjuste.Size = new System.Drawing.Size(17, 17);
            this.checkValoresdeAjuste.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.checkValoresdeAjuste.TabIndex = 110;
            this.checkValoresdeAjuste.ThreeState = false;
            this.checkValoresdeAjuste.ToolTipText = null;
            this.checkValoresdeAjuste.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.checkVDA);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(28, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 17);
            this.label2.TabIndex = 109;
            this.label2.Text = "Visualizar Únicamente Saldos sin Ajuste.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(28, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 17);
            this.label1.TabIndex = 108;
            this.label1.Text = "Visualizar Únicamente Saldos con Ajuste.";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(29, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 17);
            this.label13.TabIndex = 107;
            this.label13.Text = "Visualizar Únicamente Valores de Ajuste.";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(479, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 114;
            this.label3.Text = "Selección:";
            // 
            // cbSeleccion
            // 
            this.cbSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSeleccion.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeleccion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSeleccion.FormattingEnabled = true;
            this.cbSeleccion.Location = new System.Drawing.Point(563, 36);
            this.cbSeleccion.Name = "cbSeleccion";
            this.cbSeleccion.Size = new System.Drawing.Size(214, 25);
            this.cbSeleccion.TabIndex = 113;
            this.cbSeleccion.Tag = "0";
            this.cbSeleccion.SelectedIndexChanged += new System.EventHandler(this.cbSeleccion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(437, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 116;
            this.label4.Text = "Centro de Costo:";
            // 
            // cbCC
            // 
            this.cbCC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCC.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbCC.FormattingEnabled = true;
            this.cbCC.Location = new System.Drawing.Point(563, 75);
            this.cbCC.Name = "cbCC";
            this.cbCC.Size = new System.Drawing.Size(214, 25);
            this.cbCC.TabIndex = 115;
            this.cbCC.Tag = "0";
            this.cbCC.SelectedIndexChanged += new System.EventHandler(this.cbCC_SelectedIndexChanged);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnProcesar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnProcesar.BorderColor = System.Drawing.Color.White;
            this.btnProcesar.BorderRadius = 0;
            this.btnProcesar.BorderSize = 0;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesar.Location = new System.Drawing.Point(798, 36);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(153, 46);
            this.btnProcesar.TabIndex = 117;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextColor = System.Drawing.Color.White;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnAsiento
            // 
            this.btnAsiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAsiento.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAsiento.BorderColor = System.Drawing.Color.White;
            this.btnAsiento.BorderRadius = 0;
            this.btnAsiento.BorderSize = 0;
            this.btnAsiento.FlatAppearance.BorderSize = 0;
            this.btnAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsiento.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsiento.ForeColor = System.Drawing.Color.White;
            this.btnAsiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsiento.Location = new System.Drawing.Point(798, 97);
            this.btnAsiento.Name = "btnAsiento";
            this.btnAsiento.Size = new System.Drawing.Size(153, 46);
            this.btnAsiento.TabIndex = 118;
            this.btnAsiento.Text = "Gen. Asiento";
            this.btnAsiento.TextColor = System.Drawing.Color.White;
            this.btnAsiento.UseVisualStyleBackColor = false;
            this.btnAsiento.Click += new System.EventHandler(this.btnAsiento_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnImprimir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnImprimir.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.BorderRadius = 0;
            this.btnImprimir.BorderSize = 0;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(798, 461);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(153, 46);
            this.btnImprimir.TabIndex = 119;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel4.Location = new System.Drawing.Point(787, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 504);
            this.panel4.TabIndex = 125;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv1.ColumnHeadersHeight = 25;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.Color.White;
            this.dgv1.Location = new System.Drawing.Point(9, 115);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(548, 392);
            this.dgv1.TabIndex = 126;
            this.dgv1.TabStop = false;
            this.dgv1.SelectionChanged += new System.EventHandler(this.dgv1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cuenta";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 108;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Centro de Costo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 136;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv2.ColumnHeadersHeight = 25;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv2.EnableHeadersVisualStyles = false;
            this.dgv2.GridColor = System.Drawing.Color.White;
            this.dgv2.Location = new System.Drawing.Point(563, 115);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(214, 392);
            this.dgv2.TabIndex = 127;
            this.dgv2.TabStop = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Periodo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Coeficiente";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // frmSaldosAjustados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(960, 520);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAsiento);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSeleccion);
            this.Controls.Add(this.checkSaldosSinAjuste);
            this.Controls.Add(this.checkSaldosConAjuste);
            this.Controls.Add(this.checkValoresdeAjuste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaldosAjustados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSaldosAjustados";
            this.Load += new System.EventHandler(this.frmSaldosAjustados_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblControlBar;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private Bunifu.UI.WinForms.BunifuCheckBox checkSaldosSinAjuste;
        private Bunifu.UI.WinForms.BunifuCheckBox checkSaldosConAjuste;
        private Bunifu.UI.WinForms.BunifuCheckBox checkValoresdeAjuste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSeleccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCC;
        private RJCodeAdvance.RJControls.RJButton btnProcesar;
        private RJCodeAdvance.RJControls.RJButton btnAsiento;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}