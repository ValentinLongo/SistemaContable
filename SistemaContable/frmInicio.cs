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
            Negocio.FGenerales.SetearFormato(this);

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

        frmUsuarios usuarios = new frmUsuarios();
        frmPlanDeCuentas planDeCuentas = new frmPlanDeCuentas();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(usuarios, PanelPrincipal);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(planDeCuentas, PanelPrincipal);
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {
            MenuArchivos.IsMainMenu = false;
            MenuVer.IsMainMenu = false;
            MenuContabilidad.IsMainMenu = false;
            MenuMantenimiento.IsMainMenu = false;
            MenuAyuda.IsMainMenu = false;
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
                btnArchivos.Visible = false;
                btnVer.Visible = false;
                btnContabilidad.Visible = false;
                btnMantenimiento.Visible = false;
                btnAyuda.Visible = false;
                pbMaser.Visible = false;
                btnAbrir.Visible = true;
                //pbLogo.Location = new Point(350, 300);

            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width != 212)
            {
                PanelMenu.Width = 212;
                btnArchivos.Visible = true;
                btnVer.Visible = true;
                btnContabilidad.Visible = true;
                btnMantenimiento.Visible = true;
                btnAyuda.Visible = true;
                pbMaser.Visible = true;
                btnAbrir.Visible = false;
                //pbLogo.Location = new Point(400, 300);
            }
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
    }
}
