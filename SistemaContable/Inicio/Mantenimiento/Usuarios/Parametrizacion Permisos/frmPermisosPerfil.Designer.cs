namespace SistemaContable.Parametrizacion_Permisos
{
    partial class frmPermisosPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisosPerfil));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuFormControlBox1 = new Bunifu.UI.WinForms.BunifuFormControlBox();
            this.Tpermisos = new System.Windows.Forms.TreeView();
            this.btnCerrarArbol = new RJCodeAdvance.RJControls.RJButton();
            this.btnImprimir = new RJCodeAdvance.RJControls.RJButton();
            this.btnEspeciales = new RJCodeAdvance.RJControls.RJButton();
            this.btnAbrirArbol = new RJCodeAdvance.RJControls.RJButton();
            this.btnConfirmar = new RJCodeAdvance.RJControls.RJButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDescriPerfil = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNroPerfil = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuShapes1 = new Bunifu.UI.WinForms.BunifuShapes();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bunifuFormControlBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 21);
            this.panel1.TabIndex = 15;
            this.panel1.Tag = "1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Configuración de Permisos por Perfil";
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
            this.bunifuFormControlBox1.Location = new System.Drawing.Point(466, 0);
            this.bunifuFormControlBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuFormControlBox1.MaximizeBox = false;
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
            this.bunifuFormControlBox1.Size = new System.Drawing.Size(68, 21);
            this.bunifuFormControlBox1.TabIndex = 29;
            this.bunifuFormControlBox1.TabStop = false;
            // 
            // Tpermisos
            // 
            this.Tpermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Tpermisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tpermisos.CheckBoxes = true;
            this.Tpermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tpermisos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Tpermisos.LineColor = System.Drawing.Color.White;
            this.Tpermisos.Location = new System.Drawing.Point(12, 100);
            this.Tpermisos.Name = "Tpermisos";
            this.Tpermisos.Size = new System.Drawing.Size(388, 393);
            this.Tpermisos.TabIndex = 25;
            this.Tpermisos.TabStop = false;
            this.Tpermisos.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tpermisos_AfterCheck);
            // 
            // btnCerrarArbol
            // 
            this.btnCerrarArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnCerrarArbol.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnCerrarArbol.BorderColor = System.Drawing.Color.White;
            this.btnCerrarArbol.BorderRadius = 0;
            this.btnCerrarArbol.BorderSize = 0;
            this.btnCerrarArbol.FlatAppearance.BorderSize = 0;
            this.btnCerrarArbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarArbol.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarArbol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarArbol.Location = new System.Drawing.Point(406, 182);
            this.btnCerrarArbol.Name = "btnCerrarArbol";
            this.btnCerrarArbol.Size = new System.Drawing.Size(120, 26);
            this.btnCerrarArbol.TabIndex = 5;
            this.btnCerrarArbol.Tag = "";
            this.btnCerrarArbol.Text = "Cerrar Todo";
            this.btnCerrarArbol.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarArbol.UseVisualStyleBackColor = false;
            this.btnCerrarArbol.Click += new System.EventHandler(this.btnCerrarArbol_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnImprimir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnImprimir.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.BorderRadius = 0;
            this.btnImprimir.BorderSize = 0;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir.Location = new System.Drawing.Point(406, 467);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 26);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Tag = "";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEspeciales
            // 
            this.btnEspeciales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnEspeciales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnEspeciales.BorderColor = System.Drawing.Color.White;
            this.btnEspeciales.BorderRadius = 0;
            this.btnEspeciales.BorderSize = 0;
            this.btnEspeciales.FlatAppearance.BorderSize = 0;
            this.btnEspeciales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspeciales.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspeciales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEspeciales.Location = new System.Drawing.Point(406, 223);
            this.btnEspeciales.Name = "btnEspeciales";
            this.btnEspeciales.Size = new System.Drawing.Size(120, 26);
            this.btnEspeciales.TabIndex = 6;
            this.btnEspeciales.Tag = "";
            this.btnEspeciales.Text = "Especiales";
            this.btnEspeciales.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEspeciales.UseVisualStyleBackColor = false;
            this.btnEspeciales.Click += new System.EventHandler(this.btnEspeciales_Click);
            // 
            // btnAbrirArbol
            // 
            this.btnAbrirArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAbrirArbol.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnAbrirArbol.BorderColor = System.Drawing.Color.White;
            this.btnAbrirArbol.BorderRadius = 0;
            this.btnAbrirArbol.BorderSize = 0;
            this.btnAbrirArbol.FlatAppearance.BorderSize = 0;
            this.btnAbrirArbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirArbol.Font = new System.Drawing.Font("Dotum", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArbol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAbrirArbol.Location = new System.Drawing.Point(406, 141);
            this.btnAbrirArbol.Name = "btnAbrirArbol";
            this.btnAbrirArbol.Size = new System.Drawing.Size(120, 26);
            this.btnAbrirArbol.TabIndex = 4;
            this.btnAbrirArbol.Tag = "";
            this.btnAbrirArbol.Text = "Abrir Todo";
            this.btnAbrirArbol.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAbrirArbol.UseVisualStyleBackColor = false;
            this.btnAbrirArbol.Click += new System.EventHandler(this.btnAbrirArbol_Click);
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
            this.btnConfirmar.Location = new System.Drawing.Point(406, 100);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 26);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Tag = "";
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(141, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Numero:";
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(162)))));
            this.btnConsulta.FlatAppearance.BorderSize = 0;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConsulta.Image = global::SistemaContable.Properties.Resources.binocular2;
            this.btnConsulta.Location = new System.Drawing.Point(362, 59);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(23, 23);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(202, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(147, 1);
            this.panel3.TabIndex = 47;
            // 
            // txtDescriPerfil
            // 
            this.txtDescriPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDescriPerfil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescriPerfil.Enabled = false;
            this.txtDescriPerfil.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriPerfil.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDescriPerfil.Location = new System.Drawing.Point(202, 62);
            this.txtDescriPerfil.Name = "txtDescriPerfil";
            this.txtDescriPerfil.ReadOnly = true;
            this.txtDescriPerfil.Size = new System.Drawing.Size(147, 19);
            this.txtDescriPerfil.TabIndex = 1;
            this.txtDescriPerfil.Tag = "00000";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(79, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(59, 1);
            this.panel4.TabIndex = 45;
            // 
            // txtNroPerfil
            // 
            this.txtNroPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNroPerfil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNroPerfil.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroPerfil.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNroPerfil.Location = new System.Drawing.Point(79, 63);
            this.txtNroPerfil.Name = "txtNroPerfil";
            this.txtNroPerfil.Size = new System.Drawing.Size(56, 15);
            this.txtNroPerfil.TabIndex = 0;
            this.txtNroPerfil.Tag = "10100";
            this.txtNroPerfil.TextChanged += new System.EventHandler(this.txtNroPerfil_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Perfil";
            // 
            // bunifuShapes1
            // 
            this.bunifuShapes1.Angle = 0F;
            this.bunifuShapes1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes1.BorderThickness = 1;
            this.bunifuShapes1.FillColor = System.Drawing.Color.Transparent;
            this.bunifuShapes1.FillShape = true;
            this.bunifuShapes1.Location = new System.Drawing.Point(12, 43);
            this.bunifuShapes1.Name = "bunifuShapes1";
            this.bunifuShapes1.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Rectangle;
            this.bunifuShapes1.Sides = 5;
            this.bunifuShapes1.Size = new System.Drawing.Size(387, 51);
            this.bunifuShapes1.TabIndex = 42;
            this.bunifuShapes1.TabStop = false;
            this.bunifuShapes1.Text = "bunifuShapes1";
            // 
            // frmPermisosPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(534, 505);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtDescriPerfil);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtNroPerfil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuShapes1);
            this.Controls.Add(this.btnCerrarArbol);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnEspeciales);
            this.Controls.Add(this.btnAbrirArbol);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.Tpermisos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPermisosPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos Perfil";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuFormControlBox bunifuFormControlBox1;
        private System.Windows.Forms.TreeView Tpermisos;
        private RJCodeAdvance.RJControls.RJButton btnCerrarArbol;
        private RJCodeAdvance.RJControls.RJButton btnImprimir;
        private RJCodeAdvance.RJControls.RJButton btnEspeciales;
        private RJCodeAdvance.RJControls.RJButton btnAbrirArbol;
        private RJCodeAdvance.RJControls.RJButton btnConfirmar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDescriPerfil;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNroPerfil;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes1;
    }
}