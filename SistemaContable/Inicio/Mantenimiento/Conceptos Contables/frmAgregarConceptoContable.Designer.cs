namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    partial class frmAgregarConceptoContable
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbDescripción = new System.Windows.Forms.TextBox();
            this.tbNroCuenta = new System.Windows.Forms.TextBox();
            this.tbDescriCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar1 = new System.Windows.Forms.Button();
            this.cbCentroCostos1 = new System.Windows.Forms.ComboBox();
            this.btnBuscar2 = new System.Windows.Forms.Button();
            this.tbDescriContrapartida = new System.Windows.Forms.TextBox();
            this.tbNumContrapartida = new System.Windows.Forms.TextBox();
            this.cbCentroCostos2 = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.checkVentas = new System.Windows.Forms.RadioButton();
            this.checkCompras = new System.Windows.Forms.RadioButton();
            this.checkTesoreria = new System.Windows.Forms.RadioButton();
            this.checkBancos = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cuenta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Centro Costos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contrapartida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Centro Costos:";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Enabled = false;
            this.tbCodigo.Location = new System.Drawing.Point(84, 26);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(145, 20);
            this.tbCodigo.TabIndex = 6;
            // 
            // tbDescripción
            // 
            this.tbDescripción.Location = new System.Drawing.Point(84, 56);
            this.tbDescripción.Name = "tbDescripción";
            this.tbDescripción.Size = new System.Drawing.Size(339, 20);
            this.tbDescripción.TabIndex = 7;
            // 
            // tbNroCuenta
            // 
            this.tbNroCuenta.Location = new System.Drawing.Point(84, 88);
            this.tbNroCuenta.Name = "tbNroCuenta";
            this.tbNroCuenta.ReadOnly = true;
            this.tbNroCuenta.Size = new System.Drawing.Size(68, 20);
            this.tbNroCuenta.TabIndex = 8;
            // 
            // tbDescriCuenta
            // 
            this.tbDescriCuenta.Location = new System.Drawing.Point(158, 88);
            this.tbDescriCuenta.Name = "tbDescriCuenta";
            this.tbDescriCuenta.ReadOnly = true;
            this.tbDescriCuenta.Size = new System.Drawing.Size(231, 20);
            this.tbDescriCuenta.TabIndex = 9;
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.Location = new System.Drawing.Point(396, 88);
            this.btnBuscar1.Name = "btnBuscar1";
            this.btnBuscar1.Size = new System.Drawing.Size(27, 20);
            this.btnBuscar1.TabIndex = 10;
            this.btnBuscar1.Text = "button1";
            this.btnBuscar1.UseVisualStyleBackColor = true;
            this.btnBuscar1.Click += new System.EventHandler(this.btnBuscar1_Click);
            // 
            // cbCentroCostos1
            // 
            this.cbCentroCostos1.FormattingEnabled = true;
            this.cbCentroCostos1.Location = new System.Drawing.Point(84, 116);
            this.cbCentroCostos1.Name = "cbCentroCostos1";
            this.cbCentroCostos1.Size = new System.Drawing.Size(339, 21);
            this.cbCentroCostos1.TabIndex = 11;
            // 
            // btnBuscar2
            // 
            this.btnBuscar2.Location = new System.Drawing.Point(396, 145);
            this.btnBuscar2.Name = "btnBuscar2";
            this.btnBuscar2.Size = new System.Drawing.Size(27, 20);
            this.btnBuscar2.TabIndex = 14;
            this.btnBuscar2.Text = "button2";
            this.btnBuscar2.UseVisualStyleBackColor = true;
            this.btnBuscar2.Click += new System.EventHandler(this.btnBuscar2_Click);
            // 
            // tbDescriContrapartida
            // 
            this.tbDescriContrapartida.Location = new System.Drawing.Point(158, 145);
            this.tbDescriContrapartida.Name = "tbDescriContrapartida";
            this.tbDescriContrapartida.ReadOnly = true;
            this.tbDescriContrapartida.Size = new System.Drawing.Size(231, 20);
            this.tbDescriContrapartida.TabIndex = 13;
            // 
            // tbNumContrapartida
            // 
            this.tbNumContrapartida.Location = new System.Drawing.Point(84, 145);
            this.tbNumContrapartida.Name = "tbNumContrapartida";
            this.tbNumContrapartida.ReadOnly = true;
            this.tbNumContrapartida.Size = new System.Drawing.Size(68, 20);
            this.tbNumContrapartida.TabIndex = 12;
            // 
            // cbCentroCostos2
            // 
            this.cbCentroCostos2.FormattingEnabled = true;
            this.cbCentroCostos2.Location = new System.Drawing.Point(84, 179);
            this.cbCentroCostos2.Name = "cbCentroCostos2";
            this.cbCentroCostos2.Size = new System.Drawing.Size(339, 21);
            this.cbCentroCostos2.TabIndex = 15;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(193, 362);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(105, 23);
            this.btnConfirmar.TabIndex = 20;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // checkVentas
            // 
            this.checkVentas.AutoSize = true;
            this.checkVentas.Location = new System.Drawing.Point(84, 221);
            this.checkVentas.Name = "checkVentas";
            this.checkVentas.Size = new System.Drawing.Size(190, 17);
            this.checkVentas.TabIndex = 21;
            this.checkVentas.TabStop = true;
            this.checkVentas.Text = "Se utiliza para el módulo de Ventas";
            this.checkVentas.UseVisualStyleBackColor = true;
            // 
            // checkCompras
            // 
            this.checkCompras.AutoSize = true;
            this.checkCompras.Location = new System.Drawing.Point(84, 254);
            this.checkCompras.Name = "checkCompras";
            this.checkCompras.Size = new System.Drawing.Size(198, 17);
            this.checkCompras.TabIndex = 22;
            this.checkCompras.TabStop = true;
            this.checkCompras.Text = "Se utiliza para el módulo de Compras";
            this.checkCompras.UseVisualStyleBackColor = true;
            // 
            // checkTesoreria
            // 
            this.checkTesoreria.AutoSize = true;
            this.checkTesoreria.Location = new System.Drawing.Point(84, 286);
            this.checkTesoreria.Name = "checkTesoreria";
            this.checkTesoreria.Size = new System.Drawing.Size(203, 17);
            this.checkTesoreria.TabIndex = 23;
            this.checkTesoreria.TabStop = true;
            this.checkTesoreria.Text = "Se utiliza para el módulo de Tesorería";
            this.checkTesoreria.UseVisualStyleBackColor = true;
            // 
            // checkBancos
            // 
            this.checkBancos.AutoSize = true;
            this.checkBancos.Location = new System.Drawing.Point(84, 322);
            this.checkBancos.Name = "checkBancos";
            this.checkBancos.Size = new System.Drawing.Size(193, 17);
            this.checkBancos.TabIndex = 24;
            this.checkBancos.TabStop = true;
            this.checkBancos.Text = "Se utiliza para el módulo de Bancos";
            this.checkBancos.UseVisualStyleBackColor = true;
            // 
            // frmAgregarConceptoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 411);
            this.Controls.Add(this.checkBancos);
            this.Controls.Add(this.checkTesoreria);
            this.Controls.Add(this.checkCompras);
            this.Controls.Add(this.checkVentas);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbCentroCostos2);
            this.Controls.Add(this.btnBuscar2);
            this.Controls.Add(this.tbDescriContrapartida);
            this.Controls.Add(this.tbNumContrapartida);
            this.Controls.Add(this.cbCentroCostos1);
            this.Controls.Add(this.btnBuscar1);
            this.Controls.Add(this.tbDescriCuenta);
            this.Controls.Add(this.tbNroCuenta);
            this.Controls.Add(this.tbDescripción);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarConceptoContable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarConceptoContable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbDescripción;
        private System.Windows.Forms.TextBox tbNroCuenta;
        private System.Windows.Forms.TextBox tbDescriCuenta;
        private System.Windows.Forms.Button btnBuscar1;
        private System.Windows.Forms.ComboBox cbCentroCostos1;
        private System.Windows.Forms.Button btnBuscar2;
        private System.Windows.Forms.TextBox tbDescriContrapartida;
        private System.Windows.Forms.TextBox tbNumContrapartida;
        private System.Windows.Forms.ComboBox cbCentroCostos2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.RadioButton checkVentas;
        private System.Windows.Forms.RadioButton checkCompras;
        private System.Windows.Forms.RadioButton checkTesoreria;
        private System.Windows.Forms.RadioButton checkBancos;
    }
}