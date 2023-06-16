namespace SistemaContable.Inicio.Ver.Calendario
{
    partial class frmCalendario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendario));
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.btnPosponer = new RJCodeAdvance.RJControls.RJButton();
            this.btnEliminar = new RJCodeAdvance.RJControls.RJButton();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.dgvCalendario = new System.Windows.Forms.DataGridView();
            this.ColumnaFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckFinalizadas = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.dtFecha = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.lblCantElementos = new System.Windows.Forms.Label();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlBox = new Bunifu.UI.WinForms.BunifuFormControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).BeginInit();
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
            this.btnAgregar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.Location = new System.Drawing.Point(898, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 40);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Tag = "";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir.Location = new System.Drawing.Point(898, 580);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(150, 40);
            this.btnImprimir.TabIndex = 39;
            this.btnImprimir.Tag = "";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPosponer
            // 
            this.btnPosponer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosponer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnPosponer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnPosponer.BorderColor = System.Drawing.Color.White;
            this.btnPosponer.BorderRadius = 0;
            this.btnPosponer.BorderSize = 0;
            this.btnPosponer.FlatAppearance.BorderSize = 0;
            this.btnPosponer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosponer.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosponer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPosponer.Location = new System.Drawing.Point(898, 292);
            this.btnPosponer.Name = "btnPosponer";
            this.btnPosponer.Size = new System.Drawing.Size(150, 40);
            this.btnPosponer.TabIndex = 40;
            this.btnPosponer.Tag = "";
            this.btnPosponer.Text = "Posponer";
            this.btnPosponer.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPosponer.UseVisualStyleBackColor = false;
            this.btnPosponer.Click += new System.EventHandler(this.btnPosponer_Click);
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
            this.btnEliminar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(898, 233);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 40);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Tag = "";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnModificar.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(898, 170);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 40);
            this.btnModificar.TabIndex = 42;
            this.btnModificar.Tag = "";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvCalendario
            // 
            this.dgvCalendario.AllowUserToAddRows = false;
            this.dgvCalendario.AllowUserToDeleteRows = false;
            this.dgvCalendario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCalendario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalendario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvCalendario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCalendario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCalendario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalendario.ColumnHeadersHeight = 25;
            this.dgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCalendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaFecha,
            this.ColumnaHora,
            this.ColumnaComentario,
            this.ColumnaCheck,
            this.ColumnaUsuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCalendario.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCalendario.EnableHeadersVisualStyles = false;
            this.dgvCalendario.GridColor = System.Drawing.Color.White;
            this.dgvCalendario.Location = new System.Drawing.Point(18, 108);
            this.dgvCalendario.Name = "dgvCalendario";
            this.dgvCalendario.ReadOnly = true;
            this.dgvCalendario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCalendario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCalendario.RowHeadersVisible = false;
            this.dgvCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalendario.Size = new System.Drawing.Size(874, 512);
            this.dgvCalendario.TabIndex = 53;
            this.dgvCalendario.TabStop = false;
            this.dgvCalendario.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendario_CellContentDoubleClick);
            // 
            // ColumnaFecha
            // 
            this.ColumnaFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnaFecha.FillWeight = 98.13875F;
            this.ColumnaFecha.HeaderText = "Fecha";
            this.ColumnaFecha.Name = "ColumnaFecha";
            this.ColumnaFecha.ReadOnly = true;
            this.ColumnaFecha.Width = 150;
            // 
            // ColumnaHora
            // 
            this.ColumnaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnaHora.FillWeight = 98.13875F;
            this.ColumnaHora.HeaderText = "Hora";
            this.ColumnaHora.Name = "ColumnaHora";
            this.ColumnaHora.ReadOnly = true;
            this.ColumnaHora.Width = 150;
            // 
            // ColumnaComentario
            // 
            this.ColumnaComentario.FillWeight = 98.13875F;
            this.ColumnaComentario.HeaderText = "Comentario";
            this.ColumnaComentario.Name = "ColumnaComentario";
            this.ColumnaComentario.ReadOnly = true;
            // 
            // ColumnaCheck
            // 
            this.ColumnaCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnaCheck.FillWeight = 105.5838F;
            this.ColumnaCheck.HeaderText = "Fin";
            this.ColumnaCheck.Name = "ColumnaCheck";
            this.ColumnaCheck.ReadOnly = true;
            this.ColumnaCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnaCheck.Width = 75;
            // 
            // ColumnaUsuario
            // 
            this.ColumnaUsuario.HeaderText = "Usuario";
            this.ColumnaUsuario.Name = "ColumnaUsuario";
            this.ColumnaUsuario.ReadOnly = true;
            this.ColumnaUsuario.Visible = false;
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
            this.bunifuShapes1.Location = new System.Drawing.Point(18, 43);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(874, 59);
            this.bunifuShapes1.TabIndex = 54;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(667, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Visualizar las tareas Finalizadas";
            // 
            // CheckFinalizadas
            // 
            this.CheckFinalizadas.AllowBindingControlAnimation = true;
            this.CheckFinalizadas.AllowBindingControlColorChanges = false;
            this.CheckFinalizadas.AllowBindingControlLocation = true;
            this.CheckFinalizadas.AllowCheckBoxAnimation = false;
            this.CheckFinalizadas.AllowCheckmarkAnimation = true;
            this.CheckFinalizadas.AllowOnHoverStates = true;
            this.CheckFinalizadas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckFinalizadas.AutoCheck = true;
            this.CheckFinalizadas.BackColor = System.Drawing.Color.Transparent;
            this.CheckFinalizadas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckFinalizadas.BackgroundImage")));
            this.CheckFinalizadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckFinalizadas.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckFinalizadas.BorderRadius = 12;
            this.CheckFinalizadas.Checked = false;
            this.CheckFinalizadas.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckFinalizadas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckFinalizadas.CustomCheckmarkImage = null;
            this.CheckFinalizadas.Location = new System.Drawing.Point(644, 63);
            this.CheckFinalizadas.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckFinalizadas.Name = "CheckFinalizadas";
            this.CheckFinalizadas.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckFinalizadas.OnCheck.BorderRadius = 12;
            this.CheckFinalizadas.OnCheck.BorderThickness = 2;
            this.CheckFinalizadas.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckFinalizadas.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckFinalizadas.OnCheck.CheckmarkThickness = 2;
            this.CheckFinalizadas.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckFinalizadas.OnDisable.BorderRadius = 12;
            this.CheckFinalizadas.OnDisable.BorderThickness = 2;
            this.CheckFinalizadas.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckFinalizadas.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckFinalizadas.OnDisable.CheckmarkThickness = 2;
            this.CheckFinalizadas.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckFinalizadas.OnHoverChecked.BorderRadius = 12;
            this.CheckFinalizadas.OnHoverChecked.BorderThickness = 2;
            this.CheckFinalizadas.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckFinalizadas.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckFinalizadas.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckFinalizadas.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckFinalizadas.OnHoverUnchecked.BorderRadius = 12;
            this.CheckFinalizadas.OnHoverUnchecked.BorderThickness = 1;
            this.CheckFinalizadas.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckFinalizadas.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckFinalizadas.OnUncheck.BorderRadius = 12;
            this.CheckFinalizadas.OnUncheck.BorderThickness = 1;
            this.CheckFinalizadas.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckFinalizadas.Size = new System.Drawing.Size(17, 17);
            this.CheckFinalizadas.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckFinalizadas.TabIndex = 64;
            this.CheckFinalizadas.ThreeState = false;
            this.CheckFinalizadas.ToolTipText = null;
            this.CheckFinalizadas.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.CheckFinalizadas_CheckedChanged);
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.dtFecha.BorderColor = System.Drawing.Color.White;
            this.dtFecha.BorderRadius = 1;
            this.dtFecha.Color = System.Drawing.Color.White;
            this.dtFecha.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtFecha.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtFecha.DisabledColor = System.Drawing.Color.Gray;
            this.dtFecha.DisplayWeekNumbers = false;
            this.dtFecha.DPHeight = 0;
            this.dtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtFecha.FillDatePicker = false;
            this.dtFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFecha.ForeColor = System.Drawing.Color.White;
            this.dtFecha.Icon = ((System.Drawing.Image)(resources.GetObject("dtFecha.Icon")));
            this.dtFecha.IconColor = System.Drawing.Color.White;
            this.dtFecha.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtFecha.LeftTextMargin = 5;
            this.dtFecha.Location = new System.Drawing.Point(49, 57);
            this.dtFecha.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(236, 32);
            this.dtFecha.TabIndex = 68;
            // 
            // lblCantElementos
            // 
            this.lblCantElementos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCantElementos.AutoSize = true;
            this.lblCantElementos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCantElementos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCantElementos.Location = new System.Drawing.Point(15, 623);
            this.lblCantElementos.Name = "lblCantElementos";
            this.lblCantElementos.Size = new System.Drawing.Size(56, 13);
            this.lblCantElementos.TabIndex = 146;
            this.lblCantElementos.Text = "Elementos";
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
            this.ControlBar.TabIndex = 147;
            this.ControlBar.Tag = "1";
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 1);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(68, 17);
            this.lblControlBar.TabIndex = 59;
            this.lblControlBar.Text = "Calendario";
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
            // frmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1060, 650);
            this.Controls.Add(this.ControlBar);
            this.Controls.Add(this.lblCantElementos);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckFinalizadas);
            this.Controls.Add(this.dgvCalendario);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnPosponer);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.bunifuShapes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCalendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario";
            this.Resize += new System.EventHandler(this.frmCalendario_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).EndInit();
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private RJCodeAdvance.RJControls.RJButton btnPosponer;
        private RJCodeAdvance.RJControls.RJButton btnEliminar;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private System.Windows.Forms.DataGridView dgvCalendario;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckFinalizadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaComentario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaUsuario;
        private Bunifu.UI.WinForms.BunifuDatePicker dtFecha;
        private System.Windows.Forms.Label lblCantElementos;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.Label lblControlBar;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuFormControlBox ControlBox;
    }
}