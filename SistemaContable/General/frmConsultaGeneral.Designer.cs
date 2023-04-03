﻿namespace SistemaContable.General
{
    partial class frmConsultaGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaGeneral));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.btnSeleccionar = new RJCodeAdvance.RJControls.RJButton();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInicio = new System.Windows.Forms.Label();
            this.CheckInicio = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 21);
            this.panel1.TabIndex = 14;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Consulta General";
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
            this.btnCerrar.Location = new System.Drawing.Point(707, 0);
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
            this.btnCerrar.TabStop = false;
            this.btnCerrar.CloseClicked += new System.EventHandler(this.btnCerrar_CloseClicked);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnSeleccionar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnSeleccionar.BorderColor = System.Drawing.Color.White;
            this.btnSeleccionar.BorderRadius = 0;
            this.btnSeleccionar.BorderSize = 0;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeleccionar.Location = new System.Drawing.Point(585, 85);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(143, 43);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Tag = "";
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes1.BorderThickness = 1;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(6, 28);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(576, 51);
            this.bunifuShapes1.TabIndex = 21;
            this.bunifuShapes1.TabStop = false;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBusqueda.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.cbBusqueda.Location = new System.Drawing.Point(25, 42);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(116, 24);
            this.cbBusqueda.TabIndex = 34;
            this.cbBusqueda.TabStop = false;
            this.cbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbBusqueda_SelectedIndexChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBusqueda.Location = new System.Drawing.Point(159, 46);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(325, 19);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.Tag = "01000";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(159, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 1);
            this.panel3.TabIndex = 36;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInicio.Location = new System.Drawing.Point(525, 49);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(38, 16);
            this.lblInicio.TabIndex = 64;
            this.lblInicio.Text = "Inicio";
            this.lblInicio.Visible = false;
            // 
            // CheckInicio
            // 
            this.CheckInicio.AllowBindingControlAnimation = true;
            this.CheckInicio.AllowBindingControlColorChanges = false;
            this.CheckInicio.AllowBindingControlLocation = true;
            this.CheckInicio.AllowCheckBoxAnimation = false;
            this.CheckInicio.AllowCheckmarkAnimation = true;
            this.CheckInicio.AllowOnHoverStates = true;
            this.CheckInicio.AutoCheck = true;
            this.CheckInicio.BackColor = System.Drawing.Color.Transparent;
            this.CheckInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckInicio.BackgroundImage")));
            this.CheckInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckInicio.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckInicio.BorderRadius = 12;
            this.CheckInicio.Checked = false;
            this.CheckInicio.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckInicio.CustomCheckmarkImage = null;
            this.CheckInicio.Location = new System.Drawing.Point(502, 48);
            this.CheckInicio.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckInicio.Name = "CheckInicio";
            this.CheckInicio.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInicio.OnCheck.BorderRadius = 12;
            this.CheckInicio.OnCheck.BorderThickness = 2;
            this.CheckInicio.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckInicio.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInicio.OnCheck.CheckmarkThickness = 2;
            this.CheckInicio.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckInicio.OnDisable.BorderRadius = 12;
            this.CheckInicio.OnDisable.BorderThickness = 2;
            this.CheckInicio.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInicio.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckInicio.OnDisable.CheckmarkThickness = 2;
            this.CheckInicio.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInicio.OnHoverChecked.BorderRadius = 12;
            this.CheckInicio.OnHoverChecked.BorderThickness = 2;
            this.CheckInicio.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInicio.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckInicio.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckInicio.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckInicio.OnHoverUnchecked.BorderRadius = 12;
            this.CheckInicio.OnHoverUnchecked.BorderThickness = 1;
            this.CheckInicio.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInicio.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckInicio.OnUncheck.BorderRadius = 12;
            this.CheckInicio.OnUncheck.BorderThickness = 1;
            this.CheckInicio.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckInicio.Size = new System.Drawing.Size(17, 17);
            this.CheckInicio.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckInicio.TabIndex = 63;
            this.CheckInicio.TabStop = false;
            this.CheckInicio.ThreeState = false;
            this.CheckInicio.ToolTipText = null;
            this.CheckInicio.Visible = false;
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            this.dgvConsulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsulta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsulta.ColumnHeadersHeight = 25;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsulta.EnableHeadersVisualStyles = false;
            this.dgvConsulta.GridColor = System.Drawing.Color.White;
            this.dgvConsulta.Location = new System.Drawing.Point(6, 85);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.ReadOnly = true;
            this.dgvConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsulta.RowHeadersVisible = false;
            this.dgvConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsulta.Size = new System.Drawing.Size(576, 353);
            this.dgvConsulta.TabIndex = 65;
            this.dgvConsulta.TabStop = false;
            // 
            // frmConsultaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.CheckInicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsultaGeneral";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private RJCodeAdvance.RJControls.RJButton btnSeleccionar;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblInicio;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInicio;
        private System.Windows.Forms.DataGridView dgvConsulta;
    }
}