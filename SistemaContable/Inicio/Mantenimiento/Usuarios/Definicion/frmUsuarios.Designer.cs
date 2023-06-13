namespace SistemaContable.Usuarios
{
    partial class frmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.btnDefinirCajas = new RJCodeAdvance.RJControls.RJButton();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckUsuario = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.CheckInicio = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShapeBusqueda = new Bunifu.UI.WinForms.BunifuShapes();
            this.lblCantElementos = new System.Windows.Forms.Label();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlBox = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.lblControlBar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.ControlBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUsuarios.ColumnHeadersHeight = 25;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Login,
            this.Perfil,
            this.Telefono});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.White;
            this.dgvUsuarios.Location = new System.Drawing.Point(18, 108);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(874, 512);
            this.dgvUsuarios.TabIndex = 7;
            this.dgvUsuarios.TabStop = false;
            this.dgvUsuarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // Perfil
            // 
            this.Perfil.HeaderText = "Perfil";
            this.Perfil.Name = "Perfil";
            this.Perfil.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
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
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(898, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 40);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
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
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(899, 580);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(149, 40);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnDefinirCajas
            // 
            this.btnDefinirCajas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDefinirCajas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnDefinirCajas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnDefinirCajas.BorderColor = System.Drawing.Color.White;
            this.btnDefinirCajas.BorderRadius = 0;
            this.btnDefinirCajas.BorderSize = 0;
            this.btnDefinirCajas.FlatAppearance.BorderSize = 0;
            this.btnDefinirCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirCajas.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinirCajas.ForeColor = System.Drawing.Color.White;
            this.btnDefinirCajas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefinirCajas.Location = new System.Drawing.Point(899, 249);
            this.btnDefinirCajas.Name = "btnDefinirCajas";
            this.btnDefinirCajas.Size = new System.Drawing.Size(149, 40);
            this.btnDefinirCajas.TabIndex = 3;
            this.btnDefinirCajas.Text = "Definir Cajas";
            this.btnDefinirCajas.TextColor = System.Drawing.Color.White;
            this.btnDefinirCajas.UseVisualStyleBackColor = false;
            this.btnDefinirCajas.Click += new System.EventHandler(this.btnDefinirCajas_Click);
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
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(899, 178);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(149, 40);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.Color.White;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(25, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Busqueda";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(719, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 62;
            this.label5.Text = "Visualizar usuarios Activos";
            // 
            // CheckUsuario
            // 
            this.CheckUsuario.AllowBindingControlAnimation = true;
            this.CheckUsuario.AllowBindingControlColorChanges = false;
            this.CheckUsuario.AllowBindingControlLocation = true;
            this.CheckUsuario.AllowCheckBoxAnimation = false;
            this.CheckUsuario.AllowCheckmarkAnimation = true;
            this.CheckUsuario.AllowOnHoverStates = true;
            this.CheckUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckUsuario.AutoCheck = true;
            this.CheckUsuario.BackColor = System.Drawing.Color.Transparent;
            this.CheckUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckUsuario.BackgroundImage")));
            this.CheckUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckUsuario.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckUsuario.BorderRadius = 12;
            this.CheckUsuario.Checked = false;
            this.CheckUsuario.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckUsuario.CustomCheckmarkImage = null;
            this.CheckUsuario.Location = new System.Drawing.Point(699, 66);
            this.CheckUsuario.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckUsuario.Name = "CheckUsuario";
            this.CheckUsuario.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckUsuario.OnCheck.BorderRadius = 12;
            this.CheckUsuario.OnCheck.BorderThickness = 2;
            this.CheckUsuario.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckUsuario.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckUsuario.OnCheck.CheckmarkThickness = 2;
            this.CheckUsuario.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckUsuario.OnDisable.BorderRadius = 12;
            this.CheckUsuario.OnDisable.BorderThickness = 2;
            this.CheckUsuario.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckUsuario.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckUsuario.OnDisable.CheckmarkThickness = 2;
            this.CheckUsuario.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckUsuario.OnHoverChecked.BorderRadius = 12;
            this.CheckUsuario.OnHoverChecked.BorderThickness = 2;
            this.CheckUsuario.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckUsuario.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckUsuario.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckUsuario.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckUsuario.OnHoverUnchecked.BorderRadius = 12;
            this.CheckUsuario.OnHoverUnchecked.BorderThickness = 1;
            this.CheckUsuario.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckUsuario.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckUsuario.OnUncheck.BorderRadius = 12;
            this.CheckUsuario.OnUncheck.BorderThickness = 1;
            this.CheckUsuario.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckUsuario.Size = new System.Drawing.Size(17, 17);
            this.CheckUsuario.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckUsuario.TabIndex = 61;
            this.CheckUsuario.TabStop = false;
            this.CheckUsuario.ThreeState = false;
            this.CheckUsuario.ToolTipText = null;
            this.CheckUsuario.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.CheckUsuario_CheckedChanged);
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cbBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Codigo",
            "Nombre"});
            this.cbBusqueda.Location = new System.Drawing.Point(56, 62);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(169, 25);
            this.cbBusqueda.TabIndex = 63;
            this.cbBusqueda.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(236, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 1);
            this.panel2.TabIndex = 65;
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtbusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbusqueda.Location = new System.Drawing.Point(236, 68);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(228, 15);
            this.txtbusqueda.TabIndex = 0;
            this.txtbusqueda.Tag = "01000";
            this.txtbusqueda.TextChanged += new System.EventHandler(this.txtbusqueda_TextChanged);
            // 
            // CheckInicio
            // 
            this.CheckInicio.AllowBindingControlAnimation = true;
            this.CheckInicio.AllowBindingControlColorChanges = false;
            this.CheckInicio.AllowBindingControlLocation = true;
            this.CheckInicio.AllowCheckBoxAnimation = false;
            this.CheckInicio.AllowCheckmarkAnimation = true;
            this.CheckInicio.AllowOnHoverStates = true;
            this.CheckInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.CheckInicio.Location = new System.Drawing.Point(471, 68);
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
            this.CheckInicio.TabIndex = 66;
            this.CheckInicio.TabStop = false;
            this.CheckInicio.ThreeState = false;
            this.CheckInicio.ToolTipText = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(491, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "Inicio";
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
            this.ShapeBusqueda.Location = new System.Drawing.Point(18, 45);
            this.ShapeBusqueda.Name = "ShapeBusqueda";
            this.ShapeBusqueda.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.ShapeBusqueda.Sides = 5;
            this.ShapeBusqueda.Size = new System.Drawing.Size(874, 59);
            this.ShapeBusqueda.TabIndex = 68;
            this.ShapeBusqueda.TabStop = false;
            this.ShapeBusqueda.Text = "bunifuShapes1";
            // 
            // lblCantElementos
            // 
            this.lblCantElementos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCantElementos.AutoSize = true;
            this.lblCantElementos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantElementos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCantElementos.Location = new System.Drawing.Point(15, 623);
            this.lblCantElementos.Name = "lblCantElementos";
            this.lblCantElementos.Size = new System.Drawing.Size(56, 13);
            this.lblCantElementos.TabIndex = 69;
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
            this.ControlBar.TabIndex = 70;
            this.ControlBar.Tag = "1";
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
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 1);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(56, 17);
            this.lblControlBar.TabIndex = 59;
            this.lblControlBar.Text = "Usuarios";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1060, 650);
            this.Controls.Add(this.ControlBar);
            this.Controls.Add(this.lblCantElementos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckInicio);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CheckUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnDefinirCajas);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.ShapeBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Resize += new System.EventHandler(this.frmUsuarios_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private RJCodeAdvance.RJControls.RJButton btnDefinirCajas;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckUsuario;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtbusqueda;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInicio;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuShapes ShapeBusqueda;
        private System.Windows.Forms.Label lblCantElementos;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuFormControlBox ControlBox;
        private System.Windows.Forms.Label lblControlBar;
    }
}