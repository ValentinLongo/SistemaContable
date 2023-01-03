using SistemaContable.Plan_de_Cuentas;
using SistemaContable.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }


        private void frmInicio_Load(object sender, EventArgs e)
        {
            MenuArchivos.IsMainMenu = false;
            MenuVer.IsMainMenu = false;
            MenuContabilidad.IsMainMenu = false;
            MenuMantenimiento.IsMainMenu = false;
            MenuAyuda.IsMainMenu = false;
        }

        private void AbrirFormulario(Form Formulario)
        {
            Formulario.TopLevel = false;
            PanelPrincipal.Controls.Add(Formulario);
            Formulario.Dock = DockStyle.Fill;
            Formulario.BringToFront();
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Show();
        }

        private void ManejarFormularios(Form Formulario)
        {
            if (Formulario.ActiveControl == null)
            {
                AbrirFormulario(Formulario);
            }
            else
            {
                Formulario.BringToFront();
            }
        }

        frmPlanDeCuentas planDeCuentas = new frmPlanDeCuentas();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ManejarFormularios(planDeCuentas);
        }

        private void btnArchivos_Click(object sender, EventArgs e)
        {
            MenuArchivos.Show(btnArchivos, btnArchivos.Width, 0);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            MenuVer.Show(btnArchivos, btnArchivos.Width, 0);
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            MenuContabilidad.Show(btnArchivos, btnArchivos.Width, 0);
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            MenuMantenimiento.Show(btnArchivos, btnArchivos.Width, 0);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MenuAyuda.Show(btnAyuda, btnAyuda.Width, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width == 212)
            {
                PanelMenu.Width = 20;
                PanelLinea.Visible = false;
                btnArchivos.Visible = false;
                btnVer.Visible = false;
                btnContabilidad.Visible = false;
                btnMantenimiento.Visible = false;
                btnAyuda.Visible = false;
                pbMaser.Visible = false;
                btnAbrir.Visible = true;
                pbLogo.Location = new Point(500, 330);

            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width != 212)
            {
                PanelMenu.Width = 212;
                PanelLinea.Visible = true;
                btnArchivos.Visible = true;
                btnVer.Visible = true;
                btnContabilidad.Visible = true;
                btnMantenimiento.Visible = true;
                btnAyuda.Visible = true;
                pbMaser.Visible = true;
                btnAbrir.Visible = false;
                pbLogo.Location = new Point(586, 330);
            }
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
