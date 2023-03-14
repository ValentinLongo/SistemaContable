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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendario));
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.btnAgregar = new RJCodeAdvance.RJControls.RJButton();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.btnPosponer = new RJCodeAdvance.RJControls.RJButton();
            this.btnEliminar = new RJCodeAdvance.RJControls.RJButton();
            this.btnModificar = new RJCodeAdvance.RJControls.RJButton();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.CheckInicio = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaSeleccionada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendario
            // 
            this.Calendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendario.Location = new System.Drawing.Point(857, 11);
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 16;
            this.Calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendario_DateSelected);
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
            this.btnAgregar.Location = new System.Drawing.Point(841, 202);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(192, 43);
            this.btnAgregar.TabIndex = 38;
            this.btnAgregar.Tag = "";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.rjButton1.BorderColor = System.Drawing.Color.White;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Dotum", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rjButton1.Location = new System.Drawing.Point(841, 586);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(192, 43);
            this.rjButton1.TabIndex = 39;
            this.rjButton1.Tag = "";
            this.rjButton1.Text = "Imprimir";
            this.rjButton1.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.rjButton1.UseVisualStyleBackColor = false;
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
            this.btnPosponer.Location = new System.Drawing.Point(841, 387);
            this.btnPosponer.Name = "btnPosponer";
            this.btnPosponer.Size = new System.Drawing.Size(192, 43);
            this.btnPosponer.TabIndex = 40;
            this.btnPosponer.Tag = "";
            this.btnPosponer.Text = "Posponer";
            this.btnPosponer.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPosponer.UseVisualStyleBackColor = false;
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
            this.btnEliminar.Location = new System.Drawing.Point(841, 327);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(192, 43);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Tag = "";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.UseVisualStyleBackColor = false;
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
            this.btnModificar.Location = new System.Drawing.Point(841, 265);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(192, 43);
            this.btnModificar.TabIndex = 42;
            this.btnModificar.Tag = "";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendedores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.dgvVendedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvVendedores.ColumnHeadersHeight = 25;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Dotum", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendedores.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvVendedores.EnableHeadersVisualStyles = false;
            this.dgvVendedores.GridColor = System.Drawing.Color.White;
            this.dgvVendedores.Location = new System.Drawing.Point(18, 89);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendedores.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvVendedores.RowHeadersVisible = false;
            this.dgvVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.Size = new System.Drawing.Size(811, 540);
            this.dgvVendedores.TabIndex = 53;
            this.dgvVendedores.TabStop = false;
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
            this.bunifuShapes1.Location = new System.Drawing.Point(18, 14);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(811, 69);
            this.bunifuShapes1.TabIndex = 54;
            this.bunifuShapes1.Text = "bunifuShapes1";
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
            this.CheckInicio.Location = new System.Drawing.Point(562, 42);
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
            this.CheckInicio.TabIndex = 64;
            this.CheckInicio.ThreeState = false;
            this.CheckInicio.ToolTipText = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(585, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Visualizar las tareas No Finalizadas";
            // 
            // lblFechaSeleccionada
            // 
            this.lblFechaSeleccionada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFechaSeleccionada.AutoSize = true;
            this.lblFechaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSeleccionada.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFechaSeleccionada.Location = new System.Drawing.Point(35, 37);
            this.lblFechaSeleccionada.Name = "lblFechaSeleccionada";
            this.lblFechaSeleccionada.Size = new System.Drawing.Size(184, 24);
            this.lblFechaSeleccionada.TabIndex = 66;
            this.lblFechaSeleccionada.Text = "Fecha Seleccionada";
            // 
            // frmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1060, 650);
            this.Controls.Add(this.lblFechaSeleccionada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckInicio);
            this.Controls.Add(this.dgvVendedores);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnPosponer);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.Calendario);
            this.Controls.Add(this.bunifuShapes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCalendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCalendario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar Calendario;
        private RJCodeAdvance.RJControls.RJButton btnAgregar;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private RJCodeAdvance.RJControls.RJButton btnPosponer;
        private RJCodeAdvance.RJControls.RJButton btnEliminar;
        private RJCodeAdvance.RJControls.RJButton btnModificar;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaSeleccionada;
    }
}