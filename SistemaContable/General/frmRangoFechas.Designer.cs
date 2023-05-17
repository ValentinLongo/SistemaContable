namespace SistemaContable.General
{
    partial class frmRangoFechas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRangoFechas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.dtDesde = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.dtHasta = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 21);
            this.panel1.TabIndex = 18;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Rango Fechas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BunifuFormDrag = null;
            this.btnCerrar.CloseBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.CloseBoxOptions.BorderRadius = 0;
            this.btnCerrar.CloseBoxOptions.Enabled = true;
            this.btnCerrar.CloseBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.CloseBoxOptions.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnCerrar.CloseBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.CloseBoxOptions.Icon")));
            this.btnCerrar.CloseBoxOptions.IconAlt = null;
            this.btnCerrar.CloseBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconHoverColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconPressedColor = System.Drawing.Color.White;
            this.btnCerrar.CloseBoxOptions.IconSize = new System.Drawing.Size(18, 18);
            this.btnCerrar.CloseBoxOptions.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnCerrar.HelpBox = false;
            this.btnCerrar.HelpBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.HelpBoxOptions.BorderRadius = 0;
            this.btnCerrar.HelpBoxOptions.Enabled = true;
            this.btnCerrar.HelpBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.HelpBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.HelpBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.HelpBoxOptions.Icon")));
            this.btnCerrar.HelpBoxOptions.IconAlt = null;
            this.btnCerrar.HelpBoxOptions.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.HelpBoxOptions.IconSize = new System.Drawing.Size(22, 22);
            this.btnCerrar.HelpBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.Location = new System.Drawing.Point(292, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.MaximizeBox = false;
            this.btnCerrar.MaximizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.MaximizeBoxOptions.BorderRadius = 0;
            this.btnCerrar.MaximizeBoxOptions.Enabled = true;
            this.btnCerrar.MaximizeBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.MaximizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.MaximizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MaximizeBoxOptions.Icon")));
            this.btnCerrar.MaximizeBoxOptions.IconAlt = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MaximizeBoxOptions.IconAlt")));
            this.btnCerrar.MaximizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.MaximizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.MaximizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.MaximizeBoxOptions.IconSize = new System.Drawing.Size(16, 16);
            this.btnCerrar.MaximizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.MinimizeBox = true;
            this.btnCerrar.MinimizeBoxOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.MinimizeBoxOptions.BorderRadius = 0;
            this.btnCerrar.MinimizeBoxOptions.Enabled = true;
            this.btnCerrar.MinimizeBoxOptions.EnableDefaultAction = true;
            this.btnCerrar.MinimizeBoxOptions.HoverColor = System.Drawing.Color.LightGray;
            this.btnCerrar.MinimizeBoxOptions.Icon = ((System.Drawing.Image)(resources.GetObject("btnCerrar.MinimizeBoxOptions.Icon")));
            this.btnCerrar.MinimizeBoxOptions.IconAlt = null;
            this.btnCerrar.MinimizeBoxOptions.IconColor = System.Drawing.Color.White;
            this.btnCerrar.MinimizeBoxOptions.IconHoverColor = System.Drawing.Color.Black;
            this.btnCerrar.MinimizeBoxOptions.IconPressedColor = System.Drawing.Color.Black;
            this.btnCerrar.MinimizeBoxOptions.IconSize = new System.Drawing.Size(14, 14);
            this.btnCerrar.MinimizeBoxOptions.PressedColor = System.Drawing.Color.Silver;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.ShowDesignBorders = false;
            this.btnCerrar.Size = new System.Drawing.Size(68, 21);
            this.btnCerrar.TabIndex = 29;
            this.btnCerrar.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(41, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 116;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(44, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 117;
            this.label3.Text = "Hasta:";
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes1.BorderThickness = 1;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(6, 30);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(349, 180);
            this.bunifuShapes1.TabIndex = 118;
            this.bunifuShapes1.TabStop = false;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // dtDesde
            // 
            this.dtDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.dtDesde.BorderColor = System.Drawing.Color.White;
            this.dtDesde.BorderRadius = 1;
            this.dtDesde.Color = System.Drawing.Color.White;
            this.dtDesde.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtDesde.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtDesde.DisabledColor = System.Drawing.Color.Gray;
            this.dtDesde.DisplayWeekNumbers = false;
            this.dtDesde.DPHeight = 0;
            this.dtDesde.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtDesde.FillDatePicker = false;
            this.dtDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtDesde.ForeColor = System.Drawing.Color.White;
            this.dtDesde.Icon = ((System.Drawing.Image)(resources.GetObject("dtDesde.Icon")));
            this.dtDesde.IconColor = System.Drawing.Color.White;
            this.dtDesde.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtDesde.LeftTextMargin = 5;
            this.dtDesde.Location = new System.Drawing.Point(126, 44);
            this.dtDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDesde.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(187, 32);
            this.dtDesde.TabIndex = 119;
            // 
            // dtHasta
            // 
            this.dtHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.dtHasta.BorderColor = System.Drawing.Color.White;
            this.dtHasta.BorderRadius = 1;
            this.dtHasta.Color = System.Drawing.Color.White;
            this.dtHasta.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtHasta.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtHasta.DisabledColor = System.Drawing.Color.Gray;
            this.dtHasta.DisplayWeekNumbers = false;
            this.dtHasta.DPHeight = 0;
            this.dtHasta.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtHasta.FillDatePicker = false;
            this.dtHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtHasta.ForeColor = System.Drawing.Color.White;
            this.dtHasta.Icon = ((System.Drawing.Image)(resources.GetObject("dtHasta.Icon")));
            this.dtHasta.IconColor = System.Drawing.Color.White;
            this.dtHasta.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtHasta.LeftTextMargin = 5;
            this.dtHasta.Location = new System.Drawing.Point(126, 91);
            this.dtHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtHasta.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(187, 32);
            this.dtHasta.TabIndex = 120;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel2.Location = new System.Drawing.Point(12, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 1);
            this.panel2.TabIndex = 121;
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
            this.btnConfirmar.Font = new System.Drawing.Font("Dotum", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.Location = new System.Drawing.Point(46, 156);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(267, 39);
            this.btnConfirmar.TabIndex = 122;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmRangoFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(360, 216);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuShapes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRangoFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRangoFechas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuFormControlBox btnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
        private Bunifu.UI.WinForms.BunifuDatePicker dtDesde;
        private Bunifu.UI.WinForms.BunifuDatePicker dtHasta;
        private System.Windows.Forms.Panel panel2;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
    }
}