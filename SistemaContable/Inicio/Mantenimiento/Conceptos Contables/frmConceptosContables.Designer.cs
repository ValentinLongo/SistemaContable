namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    partial class frmConceptosContables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConceptosContables));
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.btnEliminar = new RJCodeAdvance.RJControls.RJButton();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.ShapeBusqueda = new Bunifu.UI.WinForms.BunifuShapes();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.dgvConceptosContables = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCantElementos = new System.Windows.Forms.Label();
            this.ControlBar = new System.Windows.Forms.Panel();
            this.lblControlBar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlBox = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosContables)).BeginInit();
            this.ControlBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(34, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Descripción:";
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
            this.btnImprimir.Size = new System.Drawing.Size(150, 40);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(899, 249);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 40);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.Color.White;
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
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(899, 178);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 40);
            this.btnModificar.TabIndex = 2;
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
            this.ShapeBusqueda.TabIndex = 53;
            this.ShapeBusqueda.TabStop = false;
            this.ShapeBusqueda.Text = "bunifuShapes1";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(120, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 1);
            this.panel2.TabIndex = 55;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescripcion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDescripcion.Location = new System.Drawing.Point(120, 67);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(759, 13);
            this.tbDescripcion.TabIndex = 0;
            this.tbDescripcion.Tag = "01010";
            // 
            // dgvConceptosContables
            // 
            this.dgvConceptosContables.AllowUserToAddRows = false;
            this.dgvConceptosContables.AllowUserToDeleteRows = false;
            this.dgvConceptosContables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvConceptosContables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConceptosContables.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvConceptosContables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConceptosContables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptosContables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvConceptosContables.ColumnHeadersHeight = 25;
            this.dgvConceptosContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvConceptosContables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConceptosContables.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvConceptosContables.EnableHeadersVisualStyles = false;
            this.dgvConceptosContables.GridColor = System.Drawing.Color.White;
            this.dgvConceptosContables.Location = new System.Drawing.Point(18, 108);
            this.dgvConceptosContables.Name = "dgvConceptosContables";
            this.dgvConceptosContables.ReadOnly = true;
            this.dgvConceptosContables.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptosContables.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvConceptosContables.RowHeadersVisible = false;
            this.dgvConceptosContables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosContables.Size = new System.Drawing.Size(874, 512);
            this.dgvConceptosContables.TabIndex = 56;
            this.dgvConceptosContables.TabStop = false;
            this.dgvConceptosContables.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConceptosContables_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
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
            this.lblCantElementos.TabIndex = 70;
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
            this.ControlBar.TabIndex = 71;
            this.ControlBar.Tag = "1";
            // 
            // lblControlBar
            // 
            this.lblControlBar.AutoSize = true;
            this.lblControlBar.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.lblControlBar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblControlBar.Location = new System.Drawing.Point(3, 1);
            this.lblControlBar.Name = "lblControlBar";
            this.lblControlBar.Size = new System.Drawing.Size(126, 17);
            this.lblControlBar.TabIndex = 59;
            this.lblControlBar.Text = "Conceptos Contables";
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
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(24, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 150;
            this.label4.Text = "Busqueda";
            // 
            // frmConceptosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1060, 650);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ControlBar);
            this.Controls.Add(this.lblCantElementos);
            this.Controls.Add(this.dgvConceptosContables);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShapeBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConceptosContables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos Contables";
            this.Resize += new System.EventHandler(this.frmConceptosContables_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosContables)).EndInit();
            this.ControlBar.ResumeLayout(false);
            this.ControlBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private RJCodeAdvance.RJControls.RJButton btnEliminar;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private Bunifu.UI.WinForms.BunifuShapes ShapeBusqueda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.DataGridView dgvConceptosContables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label lblCantElementos;
        private System.Windows.Forms.Panel ControlBar;
        private System.Windows.Forms.Label lblControlBar;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuFormControlBox ControlBox;
        private System.Windows.Forms.Label label4;
    }
}