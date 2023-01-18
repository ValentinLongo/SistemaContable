namespace SistemaContable.General
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInicio = new System.Windows.Forms.Label();
            this.CheckInicio = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bunifuFormControlBox1);
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
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Consulta General";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(707, 0);
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
            this.bunifuFormControlBox1.MinimizeBox = false;
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
            this.bunifuFormControlBox1.Size = new System.Drawing.Size(24, 21);
            this.bunifuFormControlBox1.TabIndex = 29;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 85);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(576, 353);
            this.dgvUsuarios.TabIndex = 15;
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
            this.btnSeleccionar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeleccionar.Location = new System.Drawing.Point(595, 85);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(120, 26);
            this.btnSeleccionar.TabIndex = 19;
            this.btnSeleccionar.Tag = "";
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.rjButton1.BorderColor = System.Drawing.Color.White;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rjButton1.Location = new System.Drawing.Point(595, 128);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(120, 26);
            this.rjButton1.TabIndex = 20;
            this.rjButton1.Tag = "";
            this.rjButton1.Text = "Actualizar";
            this.rjButton1.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.rjButton1.UseVisualStyleBackColor = false;
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
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBusqueda.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.cbBusqueda.Location = new System.Drawing.Point(12, 44);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(116, 24);
            this.cbBusqueda.TabIndex = 34;
            this.cbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbBusqueda_SelectedIndexChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBusqueda.Location = new System.Drawing.Point(134, 46);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(163, 19);
            this.txtBusqueda.TabIndex = 35;
            this.txtBusqueda.Tag = "";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(134, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 1);
            this.panel3.TabIndex = 36;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInicio.Location = new System.Drawing.Point(326, 51);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(32, 13);
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
            this.CheckInicio.Location = new System.Drawing.Point(303, 47);
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
            this.CheckInicio.ThreeState = false;
            this.CheckInicio.ToolTipText = null;
            this.CheckInicio.Visible = false;
            // 
            // frmConsultaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.CheckInicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsultaGeneral";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private RJCodeAdvance.RJControls.RJButton btnSeleccionar;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblInicio;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInicio;
    }
}