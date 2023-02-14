namespace SistemaContable.Plan_de_Cuentas
{
    partial class frmPlanDeCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanDeCuentas));
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Superior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabulador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AjustaInf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDescipcion = new System.Windows.Forms.TextBox();
            this.txtDescri = new System.Windows.Forms.Label();
            this.btnBuscar = new RJCodeAdvance.RJControls.RJButton();
            this.ShapeBusqueda = new Bunifu.UI.WinForms.BunifuShapes();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.btnEliminar = new RJCodeAdvance.RJControls.RJButton();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ControlBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.AllowUserToDeleteRows = false;
            this.dgvCuentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Cuenta,
            this.Descripción,
            this.Superior,
            this.Hija,
            this.Tabulador,
            this.AjustaInf});
            this.dgvCuentas.Location = new System.Drawing.Point(12, 68);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.ReadOnly = true;
            this.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentas.Size = new System.Drawing.Size(973, 488);
            this.dgvCuentas.TabIndex = 5;
            this.dgvCuentas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Cuenta
            // 
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            // 
            // Superior
            // 
            this.Superior.HeaderText = "Superior";
            this.Superior.Name = "Superior";
            this.Superior.ReadOnly = true;
            // 
            // Hija
            // 
            this.Hija.HeaderText = "Hija";
            this.Hija.Name = "Hija";
            this.Hija.ReadOnly = true;
            // 
            // Tabulador
            // 
            this.Tabulador.HeaderText = "Tabulador";
            this.Tabulador.Name = "Tabulador";
            this.Tabulador.ReadOnly = true;
            // 
            // AjustaInf
            // 
            this.AjustaInf.HeaderText = "AjustaInf";
            this.AjustaInf.Name = "AjustaInf";
            this.AjustaInf.ReadOnly = true;
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
            this.btnImprimir.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(992, 453);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(130, 31);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnModificar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnModificar.BorderColor = System.Drawing.Color.White;
            this.btnModificar.BorderRadius = 0;
            this.btnModificar.BorderSize = 0;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(991, 120);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 31);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.Color.White;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAgregar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAgregar.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.BorderRadius = 0;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(991, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 31);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SistemaContable.Properties.Resources.LogoMakr_9CmnoW;
            this.pictureBox1.Location = new System.Drawing.Point(991, 490);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(115, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 1);
            this.panel2.TabIndex = 46;
            // 
            // tbDescipcion
            // 
            this.tbDescipcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDescipcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tbDescipcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescipcion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescipcion.Location = new System.Drawing.Point(115, 34);
            this.tbDescipcion.Name = "tbDescipcion";
            this.tbDescipcion.Size = new System.Drawing.Size(212, 13);
            this.tbDescipcion.TabIndex = 0;
            this.tbDescipcion.Tag = "00000";
            this.tbDescipcion.TextChanged += new System.EventHandler(this.tbDescipcion_TextChanged);
            // 
            // txtDescri
            // 
            this.txtDescri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescri.AutoSize = true;
            this.txtDescri.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescri.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDescri.Location = new System.Drawing.Point(21, 33);
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.Size = new System.Drawing.Size(88, 16);
            this.txtDescri.TabIndex = 44;
            this.txtDescri.Text = "Descripcion:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.BorderRadius = 0;
            this.btnBuscar.BorderSize = 0;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::SistemaContable.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(827, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 31);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ShapeBusqueda
            // 
            this.ShapeBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShapeBusqueda.Angle = 0F;
            this.ShapeBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.ShapeBusqueda.BorderColor = System.Drawing.Color.White;
            this.ShapeBusqueda.BorderThickness = 1;
            this.ShapeBusqueda.FillColor = System.Drawing.Color.Transparent;
            this.ShapeBusqueda.FillShape = true;
            this.ShapeBusqueda.Location = new System.Drawing.Point(12, 18);
            this.ShapeBusqueda.Name = "ShapeBusqueda";
            this.ShapeBusqueda.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.ShapeBusqueda.Sides = 5;
            this.ShapeBusqueda.Size = new System.Drawing.Size(973, 48);
            this.ShapeBusqueda.TabIndex = 55;
            this.ShapeBusqueda.Text = "bunifuShapes1";
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBusqueda.Location = new System.Drawing.Point(21, 9);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(72, 17);
            this.lblBusqueda.TabIndex = 56;
            this.lblBusqueda.Text = "Busqueda";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnEliminar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnEliminar.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.BorderRadius = 0;
            this.btnEliminar.BorderSize = 0;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(991, 174);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 31);
            this.btnEliminar.TabIndex = 57;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.Color.White;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ControlBar
            // 
            this.ControlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ControlBar.Controls.Add(this.lblControlBar);
            this.ControlBar.Controls.Add(this.bunifuFormControlBox1);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(0, 0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.Size = new System.Drawing.Size(1129, 21);
            this.ControlBar.TabIndex = 96;
            this.ControlBar.Tag = "1";
            this.ControlBar.Visible = false;
            this.ControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 4);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(85, 13);
            this.lblControlBar.TabIndex = 31;
            this.lblControlBar.Text = "Plan de Cuentas";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(1015, 0);
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
            // frmPlanDeCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1129, 568);
            this.Controls.Add(this.ControlBar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbDescipcion);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.ShapeBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlanDeCuentas";
            this.Text = "frmPlanDeCuentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCuentas;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJCodeAdvance.RJControls.RJButton btnBuscar;
        private System.Windows.Forms.Label txtDescri;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbDescipcion;
        private Bunifu.UI.WinForms.BunifuShapes ShapeBusqueda;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Superior;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabulador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AjustaInf;
        private RJCodeAdvance.RJControls.RJButton btnEliminar;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.Label lblControlBar;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
    }
}