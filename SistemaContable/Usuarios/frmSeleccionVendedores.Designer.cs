namespace SistemaContable.Usuarios
{
    partial class frmSeleccionVendedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionVendedores));
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new RJCodeAdvance.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Location = new System.Drawing.Point(12, 12);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.Size = new System.Drawing.Size(627, 426);
            this.dgvVendedores.TabIndex = 0;
            this.dgvVendedores.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnSeleccionar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnSeleccionar.BorderColor = System.Drawing.Color.White;
            this.btnSeleccionar.BorderRadius = 10;
            this.btnSeleccionar.BorderSize = 1;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(645, 12);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(143, 41);
            this.btnSeleccionar.TabIndex = 44;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextColor = System.Drawing.Color.White;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // frmSeleccionVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvVendedores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeleccionVendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionVendedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendedores;
        private RJCodeAdvance.RJControls.RJButton btnSeleccionar;
    }
}