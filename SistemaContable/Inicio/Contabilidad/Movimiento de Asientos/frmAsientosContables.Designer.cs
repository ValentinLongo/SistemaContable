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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientosContables));
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCheckBox3 = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckModificados = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckManuales = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckDiferencia = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientosContables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.bunifuFormControlBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(848, 21);
            this.panel7.TabIndex = 94;
            this.panel7.Tag = "1";
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Asientos Contables";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(734, 0);
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
            // dgvAsientosContables
            // 
            this.dgvAsientosContables.AllowUserToAddRows = false;
            this.dgvAsientosContables.AllowUserToDeleteRows = false;
            this.dgvAsientosContables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAsientosContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientosContables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvAsientosContables.Location = new System.Drawing.Point(12, 101);
            this.dgvAsientosContables.Name = "dgvAsientosContables";
            this.dgvAsientosContables.ReadOnly = true;
            this.dgvAsientosContables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientosContables.Size = new System.Drawing.Size(696, 337);
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
            this.btnAgregar.Location = new System.Drawing.Point(716, 102);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(124, 30);
            this.btnAgregar.TabIndex = 96;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(35, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 15);
            this.label13.TabIndex = 97;
            this.label13.Text = "Visualizar Únicamente Asientos con Diferencia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 15);
            this.label1.TabIndex = 98;
            this.label1.Text = "Visualizar Únicamente Asientos Manuales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(34, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 99;
            this.label2.Text = "Visualizar Únicamente Asientos Modificados";
            // 
            // cbSeleccion
            // 
            this.cbSeleccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSeleccion.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSeleccion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSeleccion.FormattingEnabled = true;
            this.cbSeleccion.Location = new System.Drawing.Point(518, 69);
            this.cbSeleccion.Name = "cbSeleccion";
            this.cbSeleccion.Size = new System.Drawing.Size(190, 25);
            this.cbSeleccion.TabIndex = 103;
            this.cbSeleccion.Tag = "0";
            this.cbSeleccion.SelectedIndexChanged += new System.EventHandler(this.cbSeleccion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(442, 74);
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
            this.btnModificar.Location = new System.Drawing.Point(714, 148);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(124, 30);
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
            this.btnAnular.Location = new System.Drawing.Point(716, 194);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(124, 30);
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
            this.btnVisualizar.Location = new System.Drawing.Point(716, 242);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(124, 30);
            this.btnVisualizar.TabIndex = 107;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.TextColor = System.Drawing.Color.White;
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cbBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Codigo",
            "Descripcion"});
            this.cbBusqueda.Location = new System.Drawing.Point(25, 460);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(154, 25);
            this.cbBusqueda.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(657, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "Inicio";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(193, 483);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 1);
            this.panel3.TabIndex = 110;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusqueda.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBusqueda.Location = new System.Drawing.Point(196, 465);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(421, 19);
            this.txtBusqueda.TabIndex = 108;
            this.txtBusqueda.Tag = "11000";
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes1.BorderThickness = 1;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(12, 447);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(696, 51);
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
            this.btnImprimir.Location = new System.Drawing.Point(716, 408);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(124, 30);
            this.btnImprimir.TabIndex = 115;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SistemaContable.Properties.Resources.LogoMakr_9CmnoW;
            this.pictureBox1.Location = new System.Drawing.Point(712, 445);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCheckBox3
            // 
            this.bunifuCheckBox3.AllowBindingControlAnimation = true;
            this.bunifuCheckBox3.AllowBindingControlColorChanges = false;
            this.bunifuCheckBox3.AllowBindingControlLocation = true;
            this.bunifuCheckBox3.AllowCheckBoxAnimation = false;
            this.bunifuCheckBox3.AllowCheckmarkAnimation = true;
            this.bunifuCheckBox3.AllowOnHoverStates = true;
            this.bunifuCheckBox3.AutoCheck = true;
            this.bunifuCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox3.BackgroundImage")));
            this.bunifuCheckBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuCheckBox3.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.bunifuCheckBox3.BorderRadius = 12;
            this.bunifuCheckBox3.Checked = false;
            this.bunifuCheckBox3.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.bunifuCheckBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuCheckBox3.CustomCheckmarkImage = null;
            this.bunifuCheckBox3.Location = new System.Drawing.Point(635, 466);
            this.bunifuCheckBox3.MinimumSize = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox3.Name = "bunifuCheckBox3";
            this.bunifuCheckBox3.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox3.OnCheck.BorderRadius = 12;
            this.bunifuCheckBox3.OnCheck.BorderThickness = 2;
            this.bunifuCheckBox3.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.bunifuCheckBox3.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox3.OnCheck.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox3.OnDisable.BorderRadius = 12;
            this.bunifuCheckBox3.OnDisable.BorderThickness = 2;
            this.bunifuCheckBox3.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.bunifuCheckBox3.OnDisable.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverChecked.BorderRadius = 12;
            this.bunifuCheckBox3.OnHoverChecked.BorderThickness = 2;
            this.bunifuCheckBox3.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.bunifuCheckBox3.OnHoverChecked.CheckmarkThickness = 2;
            this.bunifuCheckBox3.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuCheckBox3.OnHoverUnchecked.BorderRadius = 12;
            this.bunifuCheckBox3.OnHoverUnchecked.BorderThickness = 1;
            this.bunifuCheckBox3.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuCheckBox3.OnUncheck.BorderRadius = 12;
            this.bunifuCheckBox3.OnUncheck.BorderThickness = 1;
            this.bunifuCheckBox3.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.bunifuCheckBox3.Size = new System.Drawing.Size(17, 17);
            this.bunifuCheckBox3.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.bunifuCheckBox3.TabIndex = 111;
            this.bunifuCheckBox3.ThreeState = false;
            this.bunifuCheckBox3.ToolTipText = null;
            // 
            // CheckModificados
            // 
            this.CheckModificados.AllowBindingControlAnimation = true;
            this.CheckModificados.AllowBindingControlColorChanges = false;
            this.CheckModificados.AllowBindingControlLocation = true;
            this.CheckModificados.AllowCheckBoxAnimation = false;
            this.CheckModificados.AllowCheckmarkAnimation = true;
            this.CheckModificados.AllowOnHoverStates = true;
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
            this.CheckModificados.Location = new System.Drawing.Point(14, 78);
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
            // 
            // CheckManuales
            // 
            this.CheckManuales.AllowBindingControlAnimation = true;
            this.CheckManuales.AllowBindingControlColorChanges = false;
            this.CheckManuales.AllowBindingControlLocation = true;
            this.CheckManuales.AllowCheckBoxAnimation = false;
            this.CheckManuales.AllowCheckmarkAnimation = true;
            this.CheckManuales.AllowOnHoverStates = true;
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
            this.CheckManuales.Location = new System.Drawing.Point(14, 54);
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
            // 
            // CheckDiferencia
            // 
            this.CheckDiferencia.AllowBindingControlAnimation = true;
            this.CheckDiferencia.AllowBindingControlColorChanges = false;
            this.CheckDiferencia.AllowBindingControlLocation = true;
            this.CheckDiferencia.AllowCheckBoxAnimation = false;
            this.CheckDiferencia.AllowCheckmarkAnimation = true;
            this.CheckDiferencia.AllowOnHoverStates = true;
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
            this.CheckDiferencia.Location = new System.Drawing.Point(15, 30);
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
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Asiento";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 67;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 62;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Comentario";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 85;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Debe";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 58;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Haber";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 61;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Creó";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 54;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Fecha";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 62;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Hora";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 55;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Modificó";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 72;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Fecha";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 62;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Hora";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 55;
            // 
            // frmAsientosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(848, 507);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbBusqueda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bunifuCheckBox3);
            this.Controls.Add(this.panel3);
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
            this.Controls.Add(this.panel7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsientosContables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsientosContables";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientosContables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
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
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuCheckBox bunifuCheckBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBusqueda;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}