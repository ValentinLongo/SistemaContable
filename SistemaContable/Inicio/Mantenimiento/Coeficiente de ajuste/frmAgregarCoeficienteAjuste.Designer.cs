namespace SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste
{
    partial class frmAgregarCoeficienteAjuste
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
            this.label1 = new System.Windows.Forms.Label();
            this.maskPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCoeficiente = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Período:";
            // 
            // maskPeriodo
            // 
            this.maskPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.maskPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskPeriodo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.maskPeriodo.Location = new System.Drawing.Point(79, 31);
            this.maskPeriodo.Name = "maskPeriodo";
            this.maskPeriodo.Size = new System.Drawing.Size(182, 13);
            this.maskPeriodo.TabIndex = 1;
            this.maskPeriodo.Tag = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Coeficiente:";
            // 
            // tbCoeficiente
            // 
            this.tbCoeficiente.Location = new System.Drawing.Point(79, 73);
            this.tbCoeficiente.Name = "tbCoeficiente";
            this.tbCoeficiente.Size = new System.Drawing.Size(181, 20);
            this.tbCoeficiente.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(108, 119);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(106, 23);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAgregarCoeficienteAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tbCoeficiente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskPeriodo);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarCoeficienteAjuste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarCoeficienteAjuste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCoeficiente;
        private System.Windows.Forms.Button btnConfirmar;
    }
}