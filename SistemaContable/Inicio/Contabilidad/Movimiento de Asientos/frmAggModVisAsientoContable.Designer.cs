﻿namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    partial class frmAggModVisAsientoContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAggModVisAsientoContable));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.dgvAddModVisASIENTO = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCodEjercicio = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescriEjercicio = new System.Windows.Forms.TextBox();
            this.cbTipoAsiento = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNroAsiento = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCancelar = new RJCodeAdvance.RJControls.RJButton();
            this.btnGenerar = new RJCodeAdvance.RJControls.RJButton();
            this.btnPlandeCta = new RJCodeAdvance.RJControls.RJButton();
            this.btnModelo = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddModVisASIENTO)).BeginInit();
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
            this.panel7.Size = new System.Drawing.Size(800, 21);
            this.panel7.TabIndex = 95;
            this.panel7.Tag = "1";
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 2);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(95, 17);
            this.lblControlBar.TabIndex = 31;
            this.lblControlBar.Text = "MSG ControlBar";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(686, 0);
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
            // dgvAddModVisASIENTO
            // 
            this.dgvAddModVisASIENTO.AllowUserToAddRows = false;
            this.dgvAddModVisASIENTO.AllowUserToDeleteRows = false;
            this.dgvAddModVisASIENTO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddModVisASIENTO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddModVisASIENTO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvAddModVisASIENTO.Location = new System.Drawing.Point(12, 213);
            this.dgvAddModVisASIENTO.Name = "dgvAddModVisASIENTO";
            this.dgvAddModVisASIENTO.ReadOnly = true;
            this.dgvAddModVisASIENTO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddModVisASIENTO.Size = new System.Drawing.Size(624, 267);
            this.dgvAddModVisASIENTO.TabIndex = 96;
            this.dgvAddModVisASIENTO.DoubleClick += new System.EventHandler(this.dgvAddModVisASIENTO_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cuenta";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Debe";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Haber";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Concepto";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CentrodeCostos";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Codigo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 105;
            this.label3.Text = "Ejercicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 106;
            this.label1.Text = "Tipo Asiento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(13, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 107;
            this.label2.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 108;
            this.label4.Text = "Comentario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 109;
            this.label5.Text = "Nº Asiento:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(74, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(58, 1);
            this.panel3.TabIndex = 112;
            // 
            // txtCodEjercicio
            // 
            this.txtCodEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtCodEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodEjercicio.Enabled = false;
            this.txtCodEjercicio.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodEjercicio.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCodEjercicio.Location = new System.Drawing.Point(74, 32);
            this.txtCodEjercicio.Name = "txtCodEjercicio";
            this.txtCodEjercicio.Size = new System.Drawing.Size(58, 19);
            this.txtCodEjercicio.TabIndex = 111;
            this.txtCodEjercicio.Tag = "11000";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(150, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 1);
            this.panel1.TabIndex = 114;
            // 
            // txtDescriEjercicio
            // 
            this.txtDescriEjercicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDescriEjercicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescriEjercicio.Enabled = false;
            this.txtDescriEjercicio.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriEjercicio.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDescriEjercicio.Location = new System.Drawing.Point(150, 32);
            this.txtDescriEjercicio.Name = "txtDescriEjercicio";
            this.txtDescriEjercicio.Size = new System.Drawing.Size(486, 19);
            this.txtDescriEjercicio.TabIndex = 113;
            this.txtDescriEjercicio.Tag = "11000";
            // 
            // cbTipoAsiento
            // 
            this.cbTipoAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbTipoAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoAsiento.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoAsiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbTipoAsiento.FormattingEnabled = true;
            this.cbTipoAsiento.Location = new System.Drawing.Point(94, 73);
            this.cbTipoAsiento.Name = "cbTipoAsiento";
            this.cbTipoAsiento.Size = new System.Drawing.Size(134, 25);
            this.cbTipoAsiento.TabIndex = 115;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(94, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 1);
            this.panel2.TabIndex = 117;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComentario.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.ForeColor = System.Drawing.SystemColors.Window;
            this.txtComentario.Location = new System.Drawing.Point(94, 181);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(542, 19);
            this.txtComentario.TabIndex = 116;
            this.txtComentario.Tag = "11000";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(88, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(140, 1);
            this.panel4.TabIndex = 119;
            // 
            // txtNroAsiento
            // 
            this.txtNroAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtNroAsiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNroAsiento.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroAsiento.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNroAsiento.Location = new System.Drawing.Point(88, 114);
            this.txtNroAsiento.Name = "txtNroAsiento";
            this.txtNroAsiento.Size = new System.Drawing.Size(140, 19);
            this.txtNroAsiento.TabIndex = 118;
            this.txtNroAsiento.Tag = "11000";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.BorderRadius = 0;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(665, 34);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(124, 30);
            this.btnConfirmar.TabIndex = 122;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.Color.White;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel6.Location = new System.Drawing.Point(650, 22);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 473);
            this.panel6.TabIndex = 123;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.BorderRadius = 0;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(665, 76);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 30);
            this.btnCancelar.TabIndex = 124;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnGenerar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnGenerar.BorderColor = System.Drawing.Color.White;
            this.btnGenerar.BorderRadius = 0;
            this.btnGenerar.BorderSize = 0;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(665, 213);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(124, 30);
            this.btnGenerar.TabIndex = 125;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextColor = System.Drawing.Color.White;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnPlandeCta
            // 
            this.btnPlandeCta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlandeCta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnPlandeCta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnPlandeCta.BorderColor = System.Drawing.Color.White;
            this.btnPlandeCta.BorderRadius = 0;
            this.btnPlandeCta.BorderSize = 0;
            this.btnPlandeCta.FlatAppearance.BorderSize = 0;
            this.btnPlandeCta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlandeCta.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlandeCta.ForeColor = System.Drawing.Color.White;
            this.btnPlandeCta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlandeCta.Location = new System.Drawing.Point(665, 258);
            this.btnPlandeCta.Name = "btnPlandeCta";
            this.btnPlandeCta.Size = new System.Drawing.Size(124, 30);
            this.btnPlandeCta.TabIndex = 126;
            this.btnPlandeCta.Text = "Plan de Cta";
            this.btnPlandeCta.TextColor = System.Drawing.Color.White;
            this.btnPlandeCta.UseVisualStyleBackColor = false;
            this.btnPlandeCta.Click += new System.EventHandler(this.btnPlandeCta_Click);
            // 
            // btnModelo
            // 
            this.btnModelo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnModelo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnModelo.BorderColor = System.Drawing.Color.White;
            this.btnModelo.BorderRadius = 0;
            this.btnModelo.BorderSize = 0;
            this.btnModelo.FlatAppearance.BorderSize = 0;
            this.btnModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelo.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModelo.ForeColor = System.Drawing.Color.White;
            this.btnModelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModelo.Location = new System.Drawing.Point(665, 304);
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Size = new System.Drawing.Size(124, 30);
            this.btnModelo.TabIndex = 127;
            this.btnModelo.Text = "Modelo";
            this.btnModelo.TextColor = System.Drawing.Color.White;
            this.btnModelo.UseVisualStyleBackColor = false;
            this.btnModelo.Click += new System.EventHandler(this.btnModelo_Click);
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
            this.btnImprimir.Font = new System.Drawing.Font("Dotum", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(665, 450);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(124, 30);
            this.btnImprimir.TabIndex = 128;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(64, 152);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(97, 20);
            this.dtFecha.TabIndex = 129;
            this.dtFecha.TabStop = false;
            // 
            // frmAggModVisAsientoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnModelo);
            this.Controls.Add(this.btnPlandeCta);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtNroAsiento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.cbTipoAsiento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDescriEjercicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtCodEjercicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAddModVisASIENTO);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAggModVisAsientoContable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAggModVisAsientoContable";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddModVisASIENTO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblControlBar;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private System.Windows.Forms.DataGridView dgvAddModVisASIENTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCodEjercicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescriEjercicio;
        private System.Windows.Forms.ComboBox cbTipoAsiento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNroAsiento;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel6;
        private RJCodeAdvance.RJControls.RJButton btnCancelar;
        private RJCodeAdvance.RJControls.RJButton btnGenerar;
        private RJCodeAdvance.RJControls.RJButton btnPlandeCta;
        private RJCodeAdvance.RJControls.RJButton btnModelo;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}