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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCoeficienteAjuste));
            this.label1 = new System.Windows.Forms.Label();
            this.maskPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.controlboxInicio = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbCoeficiente = new System.Windows.Forms.TextBox();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(29, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Período:";
            // 
            // maskPeriodo
            // 
            this.maskPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.maskPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskPeriodo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.maskPeriodo.Location = new System.Drawing.Point(90, 48);
            this.maskPeriodo.Name = "maskPeriodo";
            this.maskPeriodo.Size = new System.Drawing.Size(182, 13);
            this.maskPeriodo.TabIndex = 1;
            this.maskPeriodo.Tag = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Coeficiente:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConfirmar.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.BorderRadius = 0;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.Location = new System.Drawing.Point(91, 117);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(149, 26);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.controlboxInicio);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(327, 21);
            this.panel5.TabIndex = 33;
            this.panel5.Tag = "1";
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel5_MouseDown);
            // 
            // controlboxInicio
            // 
            this.controlboxInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlboxInicio.BunifuFormDrag = null;
            this.controlboxInicio.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.controlboxInicio.CloseBoxOptions.BorderRadius = 0;
            this.controlboxInicio.CloseBoxOptions.Enabled = true;
            this.controlboxInicio.CloseBoxOptions.EnableDefaultAction = true;
            this.controlboxInicio.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.controlboxInicio.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("controlboxInicio.CloseBoxOptions.Icon")));
            this.controlboxInicio.CloseBoxOptions.IconAlt = null;
            this.controlboxInicio.CloseBoxOptions.IconColor = System.Drawing.Color.White;
            this.controlboxInicio.CloseBoxOptions.IconHoverColor = System.Drawing.Color.White;
            this.controlboxInicio.CloseBoxOptions.IconPressedColor = System.Drawing.Color.White;
            this.controlboxInicio.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.controlboxInicio.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.controlboxInicio.HelpBox = false;
            this.controlboxInicio.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.controlboxInicio.HelpBoxOptions.BorderRadius = 0;
            this.controlboxInicio.HelpBoxOptions.Enabled = true;
            this.controlboxInicio.HelpBoxOptions.EnableDefaultAction = true;
            this.controlboxInicio.HelpBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.controlboxInicio.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("controlboxInicio.HelpBoxOptions.Icon")));
            this.controlboxInicio.HelpBoxOptions.IconAlt = null;
            this.controlboxInicio.HelpBoxOptions.IconColor = System.Drawing.Color.Black;
            this.controlboxInicio.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.controlboxInicio.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.controlboxInicio.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.controlboxInicio.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.controlboxInicio.Location = new System.Drawing.Point(272, 0);
            this.controlboxInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlboxInicio.MaximizeBox = false;
            this.controlboxInicio.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.controlboxInicio.MaximizeBoxOptions.BorderRadius = 0;
            this.controlboxInicio.MaximizeBoxOptions.Enabled = true;
            this.controlboxInicio.MaximizeBoxOptions.EnableDefaultAction = true;
            this.controlboxInicio.MaximizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.controlboxInicio.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("controlboxInicio.MaximizeBoxOptions.Icon")));
            this.controlboxInicio.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("controlboxInicio.MaximizeBoxOptions.IconAlt")));
            this.controlboxInicio.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.controlboxInicio.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.controlboxInicio.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.controlboxInicio.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.controlboxInicio.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.controlboxInicio.MinimizeBox = true;
            this.controlboxInicio.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.controlboxInicio.MinimizeBoxOptions.BorderRadius = 0;
            this.controlboxInicio.MinimizeBoxOptions.Enabled = true;
            this.controlboxInicio.MinimizeBoxOptions.EnableDefaultAction = true;
            this.controlboxInicio.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.controlboxInicio.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("controlboxInicio.MinimizeBoxOptions.Icon")));
            this.controlboxInicio.MinimizeBoxOptions.IconAlt = null;
            this.controlboxInicio.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.controlboxInicio.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.controlboxInicio.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.controlboxInicio.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.controlboxInicio.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.controlboxInicio.Name = "controlboxInicio";
            this.controlboxInicio.ShowDesignBorders = false;
            this.controlboxInicio.Size = new System.Drawing.Size(55, 21);
            this.controlboxInicio.TabIndex = 32;
            this.controlboxInicio.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Agregar Coeficiente de Ajuste";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(91, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 1);
            this.panel3.TabIndex = 41;
            // 
            // tbCoeficiente
            // 
            this.tbCoeficiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tbCoeficiente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCoeficiente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCoeficiente.Location = new System.Drawing.Point(91, 83);
            this.tbCoeficiente.Name = "tbCoeficiente";
            this.tbCoeficiente.Size = new System.Drawing.Size(182, 13);
            this.tbCoeficiente.TabIndex = 40;
            this.tbCoeficiente.Tag = "00000";
            // 
            // frmAgregarCoeficienteAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbCoeficiente);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskPeriodo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarCoeficienteAjuste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarCoeficienteAjuste";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskPeriodo;
        private System.Windows.Forms.Label label2;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.UI.WinForms.BunifuFormControlBox controlboxInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbCoeficiente;
    }
}