namespace SistemaContable.Agenda
{
    partial class frmAgregarAgenda
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblWeb = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbCel = new System.Windows.Forms.TextBox();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tbLocalidad3 = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbWeb = new System.Windows.Forms.TextBox();
            this.tbObserv = new System.Windows.Forms.TextBox();
            this.tbLocalidad1 = new System.Windows.Forms.TextBox();
            this.tbLocalidad2 = new System.Windows.Forms.TextBox();
            this.btnBusLoc = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbActividad = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAct = new System.Windows.Forms.Label();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(48, 30);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(48, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(48, 82);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(48, 108);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 3;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(48, 134);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(48, 160);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(39, 13);
            this.lblCelular.TabIndex = 5;
            this.lblCelular.Text = "Celular";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(48, 186);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(36, 13);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "E-Mail";
            this.lblMail.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(48, 212);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(30, 13);
            this.lblWeb.TabIndex = 7;
            this.lblWeb.Text = "Web";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(48, 238);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(128, 27);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(237, 20);
            this.tbCodigo.TabIndex = 9;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(128, 53);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(237, 20);
            this.tbNombre.TabIndex = 10;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(128, 183);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(237, 20);
            this.tbMail.TabIndex = 11;
            // 
            // tbCel
            // 
            this.tbCel.Location = new System.Drawing.Point(128, 157);
            this.tbCel.Name = "tbCel";
            this.tbCel.Size = new System.Drawing.Size(237, 20);
            this.tbCel.TabIndex = 12;
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(128, 131);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(237, 20);
            this.tbTel.TabIndex = 13;
            // 
            // tbLocalidad3
            // 
            this.tbLocalidad3.Location = new System.Drawing.Point(204, 105);
            this.tbLocalidad3.Name = "tbLocalidad3";
            this.tbLocalidad3.Size = new System.Drawing.Size(134, 20);
            this.tbLocalidad3.TabIndex = 14;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(128, 79);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(237, 20);
            this.tbDireccion.TabIndex = 15;
            // 
            // tbWeb
            // 
            this.tbWeb.Location = new System.Drawing.Point(128, 209);
            this.tbWeb.Name = "tbWeb";
            this.tbWeb.Size = new System.Drawing.Size(237, 20);
            this.tbWeb.TabIndex = 16;
            // 
            // tbObserv
            // 
            this.tbObserv.Location = new System.Drawing.Point(128, 235);
            this.tbObserv.Name = "tbObserv";
            this.tbObserv.Size = new System.Drawing.Size(237, 20);
            this.tbObserv.TabIndex = 17;
            // 
            // tbLocalidad1
            // 
            this.tbLocalidad1.Location = new System.Drawing.Point(127, 105);
            this.tbLocalidad1.Name = "tbLocalidad1";
            this.tbLocalidad1.Size = new System.Drawing.Size(41, 20);
            this.tbLocalidad1.TabIndex = 18;
            // 
            // tbLocalidad2
            // 
            this.tbLocalidad2.Location = new System.Drawing.Point(174, 105);
            this.tbLocalidad2.Name = "tbLocalidad2";
            this.tbLocalidad2.Size = new System.Drawing.Size(24, 20);
            this.tbLocalidad2.TabIndex = 19;
            this.tbLocalidad2.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // btnBusLoc
            // 
            this.btnBusLoc.Image = global::SistemaContable.Properties.Resources.lupa;
            this.btnBusLoc.Location = new System.Drawing.Point(344, 104);
            this.btnBusLoc.Name = "btnBusLoc";
            this.btnBusLoc.Size = new System.Drawing.Size(21, 21);
            this.btnBusLoc.TabIndex = 20;
            this.btnBusLoc.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbActividad);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblAct);
            this.splitContainer1.Panel1.Controls.Add(this.lblFecNac);
            this.splitContainer1.Panel1.Controls.Add(this.tbNombre);
            this.splitContainer1.Panel1.Controls.Add(this.btnBusLoc);
            this.splitContainer1.Panel1.Controls.Add(this.lblCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.tbLocalidad2);
            this.splitContainer1.Panel1.Controls.Add(this.lblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.tbLocalidad1);
            this.splitContainer1.Panel1.Controls.Add(this.lblDireccion);
            this.splitContainer1.Panel1.Controls.Add(this.tbObserv);
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalidad);
            this.splitContainer1.Panel1.Controls.Add(this.tbWeb);
            this.splitContainer1.Panel1.Controls.Add(this.lblTelefono);
            this.splitContainer1.Panel1.Controls.Add(this.tbDireccion);
            this.splitContainer1.Panel1.Controls.Add(this.lblCelular);
            this.splitContainer1.Panel1.Controls.Add(this.tbLocalidad3);
            this.splitContainer1.Panel1.Controls.Add(this.lblMail);
            this.splitContainer1.Panel1.Controls.Add(this.tbTel);
            this.splitContainer1.Panel1.Controls.Add(this.lblWeb);
            this.splitContainer1.Panel1.Controls.Add(this.tbCel);
            this.splitContainer1.Panel1.Controls.Add(this.lblObservaciones);
            this.splitContainer1.Panel1.Controls.Add(this.tbMail);
            this.splitContainer1.Panel1.Controls.Add(this.tbCodigo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirmar);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(685, 376);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 21;
            // 
            // cbActividad
            // 
            this.cbActividad.FormattingEnabled = true;
            this.cbActividad.Location = new System.Drawing.Point(128, 337);
            this.cbActividad.Name = "cbActividad";
            this.cbActividad.Size = new System.Drawing.Size(237, 21);
            this.cbActividad.TabIndex = 26;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(147, 307);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(218, 20);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(366, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "----------------------------------------------- pone una linea mejor ------------" +
    "--------------------------";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblAct
            // 
            this.lblAct.AutoSize = true;
            this.lblAct.Location = new System.Drawing.Point(52, 340);
            this.lblAct.Name = "lblAct";
            this.lblAct.Size = new System.Drawing.Size(51, 13);
            this.lblAct.TabIndex = 22;
            this.lblAct.Text = "Actividad";
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.Location = new System.Drawing.Point(48, 311);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(93, 13);
            this.lblFecNac.TabIndex = 21;
            this.lblFecNac.Text = "Fecha Nacimiento";
            this.lblFecNac.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(30, 12);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 22;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(30, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAgregarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAgregarAgenda";
            this.Text = "frmAgregarAgenda";
            this.Load += new System.EventHandler(this.frmAgregarAgenda_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbCel;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbLocalidad3;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.TextBox tbWeb;
        private System.Windows.Forms.TextBox tbObserv;
        private System.Windows.Forms.TextBox tbLocalidad1;
        private System.Windows.Forms.TextBox tbLocalidad2;
        private System.Windows.Forms.Button btnBusLoc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAct;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.ComboBox cbActividad;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}