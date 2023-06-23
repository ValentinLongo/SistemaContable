namespace SistemaContable.Inicio.Ver.Comunicacion_Interna
{
    partial class frmComunicacionInterna
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComunicacionInterna));
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.btnEliminar = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.cbSeleccionar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMensajes = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCantElementos = new System.Windows.Forms.Label();
            this.btnFiltrar = new RJCodeAdvance.RJControls.RJButton();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlBox = new Bunifu.UI.WinForms.BunifuFormControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).BeginInit();
            this.ControlBar.SuspendLayout();
            this.SuspendLayout();
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
            this.btnAgregar.Font = new System.Drawing.Font("Dotum", 17.25F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(898, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 40);
            this.btnAgregar.TabIndex = 123;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.btnEliminar.Font = new System.Drawing.Font("Dotum", 17.25F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(899, 178);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 40);
            this.btnEliminar.TabIndex = 125;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.Color.White;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnImprimir.Font = new System.Drawing.Font("Dotum", 17.25F);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(898, 580);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(150, 40);
            this.btnImprimir.TabIndex = 126;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComentario.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtComentario.Location = new System.Drawing.Point(13, 404);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(879, 216);
            this.txtComentario.TabIndex = 127;
            this.txtComentario.TextChanged += new System.EventHandler(this.txtComentario_TextChanged);
            // 
            // cbSeleccionar
            // 
            this.cbSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSeleccionar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeleccionar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSeleccionar.FormattingEnabled = true;
            this.cbSeleccionar.Items.AddRange(new object[] {
            "Bandeja de Entrada",
            "Bandeja de Salida"});
            this.cbSeleccionar.Location = new System.Drawing.Point(119, 60);
            this.cbSeleccionar.Name = "cbSeleccionar";
            this.cbSeleccionar.Size = new System.Drawing.Size(214, 25);
            this.cbSeleccionar.TabIndex = 129;
            this.cbSeleccionar.SelectedIndexChanged += new System.EventHandler(this.cbSeleccionar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "Seleccionar:";
            // 
            // dgvMensajes
            // 
            this.dgvMensajes.AllowUserToAddRows = false;
            this.dgvMensajes.AllowUserToDeleteRows = false;
            this.dgvMensajes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMensajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMensajes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMensajes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMensajes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMensajes.ColumnHeadersHeight = 25;
            this.dgvMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMensajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Comentario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMensajes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMensajes.EnableHeadersVisualStyles = false;
            this.dgvMensajes.GridColor = System.Drawing.Color.White;
            this.dgvMensajes.Location = new System.Drawing.Point(13, 104);
            this.dgvMensajes.MultiSelect = false;
            this.dgvMensajes.Name = "dgvMensajes";
            this.dgvMensajes.ReadOnly = true;
            this.dgvMensajes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMensajes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMensajes.RowHeadersVisible = false;
            this.dgvMensajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMensajes.Size = new System.Drawing.Size(880, 294);
            this.dgvMensajes.TabIndex = 130;
            this.dgvMensajes.TabStop = false;
            this.dgvMensajes.SelectionChanged += new System.EventHandler(this.dgvMensajes_SelectionChanged);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Fecha";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Hora";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Origen";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Destino";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Fecha Lectura";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Hora Lectura";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Comentario
            // 
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.Name = "Comentario";
            this.Comentario.ReadOnly = true;
            this.Comentario.Visible = false;
            // 
            // lblCantElementos
            // 
            this.lblCantElementos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCantElementos.AutoSize = true;
            this.lblCantElementos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCantElementos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCantElementos.Location = new System.Drawing.Point(10, 623);
            this.lblCantElementos.Name = "lblCantElementos";
            this.lblCantElementos.Size = new System.Drawing.Size(56, 13);
            this.lblCantElementos.TabIndex = 145;
            this.lblCantElementos.Text = "Elementos";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnFiltrar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnFiltrar.BorderColor = System.Drawing.Color.White;
            this.btnFiltrar.BorderRadius = 0;
            this.btnFiltrar.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Dotum", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(451, 59);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(147, 26);
            this.btnFiltrar.TabIndex = 146;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextColor = System.Drawing.Color.White;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDesde.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDesde.Location = new System.Drawing.Point(615, 64);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 16);
            this.lblDesde.TabIndex = 147;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblHasta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHasta.Location = new System.Drawing.Point(763, 64);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(46, 16);
            this.lblHasta.TabIndex = 148;
            this.lblHasta.Text = "Hasta:";
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes1.BorderThickness = 1;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(14, 45);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(879, 53);
            this.bunifuShapes1.TabIndex = 149;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // ControlBar
            // 
            this.ControlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.ControlBar.Controls.Add(this.lblControlBar);
            this.ControlBar.Controls.Add(this.label2);
            this.ControlBar.Controls.Add(this.ControlBox);
            this.ControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBar.Location = new System.Drawing.Point(0, 0);
            this.ControlBar.Name = "ControlBar";
            this.ControlBar.Size = new System.Drawing.Size(1060, 20);
            this.ControlBar.TabIndex = 150;
            this.ControlBar.Tag = "1";
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 1);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(129, 17);
            this.lblControlBar.TabIndex = 59;
            this.lblControlBar.Text = "Comunicación Interna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 11.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 19);
            this.label2.TabIndex = 58;
            // 
            // ControlBox
            // 
            this.ControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBox.BunifuFormDrag = null;
            this.ControlBox.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.ControlBox.CloseBoxOptions.BorderRadius = 0;
            this.ControlBox.CloseBoxOptions.Enabled = true;
            this.ControlBox.CloseBoxOptions.EnableDefaultAction = true;
            this.ControlBox.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.ControlBox.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("ControlBox.CloseBoxOptions.Icon")));
            this.ControlBox.CloseBoxOptions.IconAlt = null;
            this.ControlBox.CloseBoxOptions.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ControlBox.CloseBoxOptions.IconHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ControlBox.CloseBoxOptions.IconPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ControlBox.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.ControlBox.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.ControlBox.HelpBox = false;
            this.ControlBox.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.ControlBox.HelpBoxOptions.BorderRadius = 0;
            this.ControlBox.HelpBoxOptions.Enabled = true;
            this.ControlBox.HelpBoxOptions.EnableDefaultAction = true;
            this.ControlBox.HelpBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ControlBox.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("ControlBox.HelpBoxOptions.Icon")));
            this.ControlBox.HelpBoxOptions.IconAlt = null;
            this.ControlBox.HelpBoxOptions.IconColor = System.Drawing.Color.Black;
            this.ControlBox.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.ControlBox.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.ControlBox.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.ControlBox.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.ControlBox.Location = new System.Drawing.Point(984, 0);
            this.ControlBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlBox.MaximizeBox = false;
            this.ControlBox.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeBoxOptions.BorderRadius = 0;
            this.ControlBox.MaximizeBoxOptions.Enabled = true;
            this.ControlBox.MaximizeBoxOptions.EnableDefaultAction = true;
            this.ControlBox.MaximizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.ControlBox.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("ControlBox.MaximizeBoxOptions.Icon")));
            this.ControlBox.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("ControlBox.MaximizeBoxOptions.IconAlt")));
            this.ControlBox.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.ControlBox.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.ControlBox.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.ControlBox.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.ControlBox.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.ControlBox.MinimizeBox = true;
            this.ControlBox.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeBoxOptions.BorderRadius = 0;
            this.ControlBox.MinimizeBoxOptions.Enabled = true;
            this.ControlBox.MinimizeBoxOptions.EnableDefaultAction = true;
            this.ControlBox.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.ControlBox.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("ControlBox.MinimizeBoxOptions.Icon")));
            this.ControlBox.MinimizeBoxOptions.IconAlt = null;
            this.ControlBox.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.ControlBox.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.ControlBox.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.ControlBox.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.ControlBox.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.ControlBox.Name = "ControlBox";
            this.ControlBox.ShowDesignBorders = false;
            this.ControlBox.Size = new System.Drawing.Size(76, 21);
            this.ControlBox.TabIndex = 33;
            this.ControlBox.TabStop = false;
            this.ControlBox.Tag = "12345";
            // 
            // frmComunicacionInterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1060, 650);
            this.Controls.Add(this.ControlBar);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblCantElementos);
            this.Controls.Add(this.dgvMensajes);
            this.Controls.Add(this.cbSeleccionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.bunifuShapes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmComunicacionInterna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicacion Interna";
            this.Resize += new System.EventHandler(this.frmComunicacionInterna_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).EndInit();
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private RJCodeAdvance.RJControls.RJButton btnEliminar;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.ComboBox cbSeleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMensajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.Label lblCantElementos;
        private RJCodeAdvance.RJControls.RJButton btnFiltrar;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.Label lblControlBar;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuFormControlBox ControlBox;
    }
}