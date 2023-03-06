namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    partial class frmAsientosContables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientosContables));
            this.dgvAsientosContables = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSeleccion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.btnAnular = new RJCodeAdvance.RJControls.RJButton();
            this.btnVisualizar = new RJCodeAdvance.RJControls.RJButton();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.lblinicio = new System.Windows.Forms.Label();
            this.LineaBusqueda = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.CheckInicio = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckModificados = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckManuales = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckDiferencia = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.dtFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.dgvAux = new System.Windows.Forms.DataGridView();
            this.timerBusqueda = new System.Windows.Forms.Timer(this.components);
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnBuscar = new RJCodeAdvance.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientosContables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAux)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAsientosContables
            // 
            this.dgvAsientosContables.AllowUserToAddRows = false;
            this.dgvAsientosContables.AllowUserToDeleteRows = false;
            this.dgvAsientosContables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAsientosContables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAsientosContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientosContables.Location = new System.Drawing.Point(12, 88);
            this.dgvAsientosContables.Name = "dgvAsientosContables";
            this.dgvAsientosContables.ReadOnly = true;
            this.dgvAsientosContables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientosContables.Size = new System.Drawing.Size(964, 478);
            this.dgvAsientosContables.TabIndex = 95;
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
            this.btnAgregar.Location = new System.Drawing.Point(985, 88);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 38);
            this.btnAgregar.TabIndex = 96;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(34, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 15);
            this.label13.TabIndex = 97;
            this.label13.Text = "Visualizar Únicamente Asientos con Diferencia";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 15);
            this.label1.TabIndex = 98;
            this.label1.Text = "Visualizar Únicamente Asientos Manuales";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 99;
            this.label2.Text = "Visualizar Únicamente Asientos Modificados";
            // 
            // cbSeleccion
            // 
            this.cbSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSeleccion.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeleccion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSeleccion.FormattingEnabled = true;
            this.cbSeleccion.Location = new System.Drawing.Point(786, 56);
            this.cbSeleccion.Name = "cbSeleccion";
            this.cbSeleccion.Size = new System.Drawing.Size(190, 25);
            this.cbSeleccion.TabIndex = 103;
            this.cbSeleccion.Tag = "0";
            this.cbSeleccion.SelectedIndexChanged += new System.EventHandler(this.cbSeleccion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(710, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 104;
            this.label3.Text = "SELECCIÓN:";
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
            this.btnModificar.Location = new System.Drawing.Point(985, 152);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(135, 38);
            this.btnModificar.TabIndex = 105;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.Color.White;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAnular.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAnular.BorderColor = System.Drawing.Color.White;
            this.btnAnular.BorderRadius = 0;
            this.btnAnular.BorderSize = 0;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnular.Location = new System.Drawing.Point(985, 216);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(135, 38);
            this.btnAnular.TabIndex = 106;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextColor = System.Drawing.Color.White;
            this.btnAnular.UseVisualStyleBackColor = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnVisualizar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnVisualizar.BorderColor = System.Drawing.Color.White;
            this.btnVisualizar.BorderRadius = 0;
            this.btnVisualizar.BorderSize = 0;
            this.btnVisualizar.FlatAppearance.BorderSize = 0;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.ForeColor = System.Drawing.Color.White;
            this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualizar.Location = new System.Drawing.Point(985, 280);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(135, 38);
            this.btnVisualizar.TabIndex = 107;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.TextColor = System.Drawing.Color.White;
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Asiento",
            "Descripción",
            "Fecha"});
            this.cbBusqueda.Location = new System.Drawing.Point(25, 587);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(154, 25);
            this.cbBusqueda.TabIndex = 113;
            this.cbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbBusqueda_SelectedIndexChanged);
            // 
            // lblinicio
            // 
            this.lblinicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblinicio.AutoSize = true;
            this.lblinicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblinicio.Location = new System.Drawing.Point(934, 593);
            this.lblinicio.Name = "lblinicio";
            this.lblinicio.Size = new System.Drawing.Size(32, 13);
            this.lblinicio.TabIndex = 112;
            this.lblinicio.Text = "Inicio";
            // 
            // LineaBusqueda
            // 
            this.LineaBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LineaBusqueda.BackColor = System.Drawing.Color.White;
            this.LineaBusqueda.Location = new System.Drawing.Point(195, 611);
            this.LineaBusqueda.Name = "LineaBusqueda";
            this.LineaBusqueda.Size = new System.Drawing.Size(700, 1);
            this.LineaBusqueda.TabIndex = 110;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBusqueda.Location = new System.Drawing.Point(198, 593);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(697, 19);
            this.txtBusqueda.TabIndex = 108;
            this.txtBusqueda.Tag = "11000";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
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
            this.bunifuShapes1.Location = new System.Drawing.Point(12, 572);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(964, 55);
            this.bunifuShapes1.TabIndex = 109;
            this.bunifuShapes1.Text = "bunifuShapes1";
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
            this.btnImprimir.Location = new System.Drawing.Point(985, 498);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(135, 38);
            this.btnImprimir.TabIndex = 115;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
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
            this.CheckInicio.Location = new System.Drawing.Point(912, 591);
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
            this.CheckInicio.TabIndex = 111;
            this.CheckInicio.ThreeState = false;
            this.CheckInicio.ToolTipText = null;
            // 
            // CheckModificados
            // 
            this.CheckModificados.AllowBindingControlAnimation = true;
            this.CheckModificados.AllowBindingControlColorChanges = false;
            this.CheckModificados.AllowBindingControlLocation = true;
            this.CheckModificados.AllowCheckBoxAnimation = false;
            this.CheckModificados.AllowCheckmarkAnimation = true;
            this.CheckModificados.AllowOnHoverStates = true;
            this.CheckModificados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckModificados.AutoCheck = true;
            this.CheckModificados.BackColor = System.Drawing.Color.Transparent;
            this.CheckModificados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckModificados.BackgroundImage")));
            this.CheckModificados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckModificados.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckModificados.BorderRadius = 12;
            this.CheckModificados.Checked = false;
            this.CheckModificados.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckModificados.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckModificados.CustomCheckmarkImage = null;
            this.CheckModificados.Location = new System.Drawing.Point(13, 65);
            this.CheckModificados.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckModificados.Name = "CheckModificados";
            this.CheckModificados.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckModificados.OnCheck.BorderRadius = 12;
            this.CheckModificados.OnCheck.BorderThickness = 2;
            this.CheckModificados.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckModificados.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckModificados.OnCheck.CheckmarkThickness = 2;
            this.CheckModificados.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckModificados.OnDisable.BorderRadius = 12;
            this.CheckModificados.OnDisable.BorderThickness = 2;
            this.CheckModificados.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckModificados.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckModificados.OnDisable.CheckmarkThickness = 2;
            this.CheckModificados.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckModificados.OnHoverChecked.BorderRadius = 12;
            this.CheckModificados.OnHoverChecked.BorderThickness = 2;
            this.CheckModificados.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckModificados.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckModificados.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckModificados.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckModificados.OnHoverUnchecked.BorderRadius = 12;
            this.CheckModificados.OnHoverUnchecked.BorderThickness = 1;
            this.CheckModificados.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckModificados.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckModificados.OnUncheck.BorderRadius = 12;
            this.CheckModificados.OnUncheck.BorderThickness = 1;
            this.CheckModificados.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckModificados.Size = new System.Drawing.Size(17, 17);
            this.CheckModificados.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckModificados.TabIndex = 102;
            this.CheckModificados.ThreeState = false;
            this.CheckModificados.ToolTipText = null;
            this.CheckModificados.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.CheckModificados_CheckedChanged);
            // 
            // CheckManuales
            // 
            this.CheckManuales.AllowBindingControlAnimation = true;
            this.CheckManuales.AllowBindingControlColorChanges = false;
            this.CheckManuales.AllowBindingControlLocation = true;
            this.CheckManuales.AllowCheckBoxAnimation = false;
            this.CheckManuales.AllowCheckmarkAnimation = true;
            this.CheckManuales.AllowOnHoverStates = true;
            this.CheckManuales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckManuales.AutoCheck = true;
            this.CheckManuales.BackColor = System.Drawing.Color.Transparent;
            this.CheckManuales.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckManuales.BackgroundImage")));
            this.CheckManuales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckManuales.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckManuales.BorderRadius = 12;
            this.CheckManuales.Checked = false;
            this.CheckManuales.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckManuales.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckManuales.CustomCheckmarkImage = null;
            this.CheckManuales.Location = new System.Drawing.Point(13, 41);
            this.CheckManuales.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckManuales.Name = "CheckManuales";
            this.CheckManuales.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckManuales.OnCheck.BorderRadius = 12;
            this.CheckManuales.OnCheck.BorderThickness = 2;
            this.CheckManuales.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckManuales.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckManuales.OnCheck.CheckmarkThickness = 2;
            this.CheckManuales.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckManuales.OnDisable.BorderRadius = 12;
            this.CheckManuales.OnDisable.BorderThickness = 2;
            this.CheckManuales.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckManuales.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckManuales.OnDisable.CheckmarkThickness = 2;
            this.CheckManuales.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckManuales.OnHoverChecked.BorderRadius = 12;
            this.CheckManuales.OnHoverChecked.BorderThickness = 2;
            this.CheckManuales.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckManuales.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckManuales.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckManuales.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckManuales.OnHoverUnchecked.BorderRadius = 12;
            this.CheckManuales.OnHoverUnchecked.BorderThickness = 1;
            this.CheckManuales.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckManuales.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckManuales.OnUncheck.BorderRadius = 12;
            this.CheckManuales.OnUncheck.BorderThickness = 1;
            this.CheckManuales.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckManuales.Size = new System.Drawing.Size(17, 17);
            this.CheckManuales.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckManuales.TabIndex = 101;
            this.CheckManuales.ThreeState = false;
            this.CheckManuales.ToolTipText = null;
            this.CheckManuales.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.CheckManuales_CheckedChanged);
            // 
            // CheckDiferencia
            // 
            this.CheckDiferencia.AllowBindingControlAnimation = true;
            this.CheckDiferencia.AllowBindingControlColorChanges = false;
            this.CheckDiferencia.AllowBindingControlLocation = true;
            this.CheckDiferencia.AllowCheckBoxAnimation = false;
            this.CheckDiferencia.AllowCheckmarkAnimation = true;
            this.CheckDiferencia.AllowOnHoverStates = true;
            this.CheckDiferencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckDiferencia.AutoCheck = true;
            this.CheckDiferencia.BackColor = System.Drawing.Color.Transparent;
            this.CheckDiferencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckDiferencia.BackgroundImage")));
            this.CheckDiferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckDiferencia.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckDiferencia.BorderRadius = 12;
            this.CheckDiferencia.Checked = false;
            this.CheckDiferencia.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.CheckDiferencia.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckDiferencia.CustomCheckmarkImage = null;
            this.CheckDiferencia.Location = new System.Drawing.Point(14, 17);
            this.CheckDiferencia.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckDiferencia.Name = "CheckDiferencia";
            this.CheckDiferencia.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckDiferencia.OnCheck.BorderRadius = 12;
            this.CheckDiferencia.OnCheck.BorderThickness = 2;
            this.CheckDiferencia.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.CheckDiferencia.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckDiferencia.OnCheck.CheckmarkThickness = 2;
            this.CheckDiferencia.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.CheckDiferencia.OnDisable.BorderRadius = 12;
            this.CheckDiferencia.OnDisable.BorderThickness = 2;
            this.CheckDiferencia.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckDiferencia.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.CheckDiferencia.OnDisable.CheckmarkThickness = 2;
            this.CheckDiferencia.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckDiferencia.OnHoverChecked.BorderRadius = 12;
            this.CheckDiferencia.OnHoverChecked.BorderThickness = 2;
            this.CheckDiferencia.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckDiferencia.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckDiferencia.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckDiferencia.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.CheckDiferencia.OnHoverUnchecked.BorderRadius = 12;
            this.CheckDiferencia.OnHoverUnchecked.BorderThickness = 1;
            this.CheckDiferencia.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckDiferencia.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.CheckDiferencia.OnUncheck.BorderRadius = 12;
            this.CheckDiferencia.OnUncheck.BorderThickness = 1;
            this.CheckDiferencia.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckDiferencia.Size = new System.Drawing.Size(17, 17);
            this.CheckDiferencia.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckDiferencia.TabIndex = 100;
            this.CheckDiferencia.ThreeState = false;
            this.CheckDiferencia.ToolTipText = null;
            this.CheckDiferencia.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.CheckDiferencia_CheckedChanged);
            // 
            // dtFechaBusqueda
            // 
            this.dtFechaBusqueda.CustomFormat = "dd/MM/yyyy";
            this.dtFechaBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaBusqueda.Location = new System.Drawing.Point(255, 589);
            this.dtFechaBusqueda.Name = "dtFechaBusqueda";
            this.dtFechaBusqueda.Size = new System.Drawing.Size(95, 20);
            this.dtFechaBusqueda.TabIndex = 116;
            this.dtFechaBusqueda.Visible = false;
            // 
            // dgvAux
            // 
            this.dgvAux.AllowUserToAddRows = false;
            this.dgvAux.AllowUserToDeleteRows = false;
            this.dgvAux.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAux.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAux.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvAux.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAux.Location = new System.Drawing.Point(1104, 623);
            this.dgvAux.Name = "dgvAux";
            this.dgvAux.ReadOnly = true;
            this.dgvAux.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAux.Size = new System.Drawing.Size(13, 15);
            this.dgvAux.TabIndex = 117;
            // 
            // timerBusqueda
            // 
            this.timerBusqueda.Interval = 1000;
            this.timerBusqueda.Tick += new System.EventHandler(this.timerBusqueda_Tick);
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDesde.Location = new System.Drawing.Point(198, 590);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(47, 17);
            this.lblDesde.TabIndex = 118;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Visible = false;
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
            this.btnBuscar.Font = new System.Drawing.Font("Dotum", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(360, 589);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 20);
            this.btnBuscar.TabIndex = 119;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmAsientosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1129, 650);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dgvAux);
            this.Controls.Add(this.dtFechaBusqueda);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.lblinicio);
            this.Controls.Add(this.CheckInicio);
            this.Controls.Add(this.LineaBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSeleccion);
            this.Controls.Add(this.CheckModificados);
            this.Controls.Add(this.CheckManuales);
            this.Controls.Add(this.CheckDiferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvAsientosContables);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsientosContables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsientosContables";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientosContables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAux)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAsientosContables;
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckDiferencia;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckManuales;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckModificados;
        private System.Windows.Forms.ComboBox cbSeleccion;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private RJCodeAdvance.RJControls.RJButton btnAnular;
        private RJCodeAdvance.RJControls.RJButton btnVisualizar;
        private System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.Label lblinicio;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInicio;
        private System.Windows.Forms.Panel LineaBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private System.Windows.Forms.DateTimePicker dtFechaBusqueda;
        private System.Windows.Forms.DataGridView dgvAux;
        private System.Windows.Forms.Timer timerBusqueda;
        private System.Windows.Forms.Label lblDesde;
        private RJCodeAdvance.RJControls.RJButton btnBuscar;
    }
}