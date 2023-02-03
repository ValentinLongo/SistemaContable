namespace SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste
{
    partial class frmCoeficienteDeAjuste
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
            this.dgvEjercicios = new System.Windows.Forms.DataGridView();
            this.checkEjercicio = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCoeficientes = new System.Windows.Forms.DataGridView();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.Ejercicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cerrado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoeficientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEjercicios
            // 
            this.dgvEjercicios.AllowUserToAddRows = false;
            this.dgvEjercicios.AllowUserToDeleteRows = false;
            this.dgvEjercicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjercicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ejercicio,
            this.Descripción,
            this.Desde,
            this.Hasta,
            this.Cerrado});
            this.dgvEjercicios.Location = new System.Drawing.Point(12, 36);
            this.dgvEjercicios.Name = "dgvEjercicios";
            this.dgvEjercicios.ReadOnly = true;
            this.dgvEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEjercicios.Size = new System.Drawing.Size(637, 164);
            this.dgvEjercicios.TabIndex = 0;
            this.dgvEjercicios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Click);
            // 
            // checkEjercicio
            // 
            this.checkEjercicio.AutoSize = true;
            this.checkEjercicio.Checked = true;
            this.checkEjercicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEjercicio.Location = new System.Drawing.Point(571, 12);
            this.checkEjercicio.Name = "checkEjercicio";
            this.checkEjercicio.Size = new System.Drawing.Size(217, 17);
            this.checkEjercicio.TabIndex = 1;
            this.checkEjercicio.Text = "Visualizar únicamente Ejercicios Abiertos";
            this.checkEjercicio.UseVisualStyleBackColor = true;
            this.checkEjercicio.CheckedChanged += new System.EventHandler(this.cambioEjercicioAbierto);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coeficientes mensuales";
            // 
            // dgvCoeficientes
            // 
            this.dgvCoeficientes.AllowUserToAddRows = false;
            this.dgvCoeficientes.AllowUserToDeleteRows = false;
            this.dgvCoeficientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoeficientes.Location = new System.Drawing.Point(12, 219);
            this.dgvCoeficientes.Name = "dgvCoeficientes";
            this.dgvCoeficientes.ReadOnly = true;
            this.dgvCoeficientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCoeficientes.Size = new System.Drawing.Size(637, 301);
            this.dgvCoeficientes.TabIndex = 3;
            this.dgvCoeficientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ClickCoeficientes);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(85, 10);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(360, 20);
            this.tbDescripcion.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(451, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 20);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripción:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(659, 219);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(129, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(660, 259);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(128, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(660, 302);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Ejercicio
            // 
            this.Ejercicio.HeaderText = "Ejercicio";
            this.Ejercicio.Name = "Ejercicio";
            this.Ejercicio.ReadOnly = true;
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            // 
            // Desde
            // 
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            this.Desde.ReadOnly = true;
            // 
            // Hasta
            // 
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            this.Hasta.ReadOnly = true;
            // 
            // Cerrado
            // 
            this.Cerrado.HeaderText = "Cerrado";
            this.Cerrado.Name = "Cerrado";
            this.Cerrado.ReadOnly = true;
            // 
            // frmCoeficienteDeAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.dgvCoeficientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkEjercicio);
            this.Controls.Add(this.dgvEjercicios);
            this.Name = "frmCoeficienteDeAjuste";
            this.Text = "frmCoeficienteDeAjuste";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoeficientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEjercicios;
        private System.Windows.Forms.CheckBox checkEjercicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCoeficientes;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ejercicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cerrado;
    }
}