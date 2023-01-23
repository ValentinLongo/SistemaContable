using SistemaContable.Plan_de_Cuentas;
using SistemaContable.Usuarios;
using SistemaContable.Agenda;

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
using SistemaContable.Conceptos_Contables;
using SistemaContable.Parametrizacion_Permisos;
using SistemaContable.General;
using SistemaContable.Empresa;

namespace SistemaContable
{
    public partial class frmInicio : Form
    {
        public static bool permiso;

        //
        public frmInicio()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            Negocio.FFormatoSistema.FondoMDI(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
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
        private void frmInicio_Load(object sender, EventArgs e)
        {
            MenuArchivos.IsMainMenu = false;
            MenuVer.IsMainMenu = false;
            MenuContabilidad.IsMainMenu = false;
            MenuMantenimiento.IsMainMenu = false;
            MenuAyuda.IsMainMenu = false;
        }
        //

        //
        frmUsuarios usuarios = new frmUsuarios();
        frmPlanDeCuentas planDeCuentas = new frmPlanDeCuentas();
        frmConceptosContables conceptoscontables = new frmConceptosContables();
        frmAgenda agenda = new frmAgenda();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(usuarios, this, pbLogo);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(planDeCuentas, this, pbLogo);
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(conceptoscontables, this, pbLogo);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.ManejarFormularios(agenda, this, pbLogo);
        }
        //

        //
        private void btnArchivos_Click(object sender, EventArgs e)
        {
            MenuArchivos.Show(btnArchivos, btnArchivos.Width, 0);
            btnArchivos.Visible = false;
            btnArchivos2.Visible = true;
            btnArchivos2.BringToFront();
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            MenuVer.Show(btnArchivos, btnArchivos.Width, 0);
            btnVer.Visible = false;
            btnVer2.Visible = true;
            btnVer2.BringToFront();
        }
        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            MenuContabilidad.Show(btnArchivos, btnArchivos.Width, 0);
            btnContabilidad.Visible = false;
            btnContabilidad2.Visible = true;
            btnContabilidad2.BringToFront();

        }
        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            MenuMantenimiento.Show(btnArchivos, btnArchivos.Width, 0);
            btnMantenimiento.Visible = false;
            btnMantenimiento2.Visible = true;
            btnMantenimiento2.BringToFront();
        }
        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MenuAyuda.Show(btnAyuda, btnAyuda.Width, 0);
            btnAyuda.Visible = false;
            btnAyuda2.Visible = true;
            btnAyuda2.BringToFront();
        }
        //

        //
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width == 212)
            {
                //PanelMenu.Width = 20;
                //btnArchivos.Visible = false;
                //btnVer.Visible = false;
                //btnContabilidad.Visible = false;
                //btnMantenimiento.Visible = false;
                //btnAyuda.Visible = false;
                //pbMaser.Visible = false;
                //btnAbrir.Visible = true;
                //pbLogo.Location = new Point(350, 300);

            }
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width != 212)
            {
                //PanelMenu.Width = 212;
                //btnArchivos.Visible = true;
                //btnVer.Visible = true;
                //btnContabilidad.Visible = true;
                //btnMantenimiento.Visible = true;
                //btnAyuda.Visible = true;
                //pbMaser.Visible = true;
                //btnAbrir.Visible = false;
                //pbLogo.Location = new Point(400, 300);
            }
        }
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        private void MenuArchivos_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnArchivos.Visible = true;
            btnArchivos.BringToFront();
            btnArchivos2.Visible = false;
        }
        private void MenuVer_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnVer.Visible = true;
            btnVer.BringToFront();
            btnVer2.Visible = false;
        }
        private void MenuContabilidad_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnContabilidad.Visible = true;
            btnContabilidad.BringToFront();
            btnContabilidad2.Visible = false;
        }
        private void MenuMantenimiento_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnMantenimiento.Visible = true;
            btnMantenimiento.BringToFront();
            btnMantenimiento2.Visible = false;
        }
        private void MenuAyuda_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnAyuda.Visible = true;
            btnAyuda.BringToFront();
            btnAyuda2.Visible = false;
        }
        //

        //
        //PERMISOS PARA CADA BOTON
        //10
        private void respaldoDeInformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(respaldoDeInformacionToolStripMenuItem.Tag.ToString());
        }
        private void restauracionDeInformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(restauracionDeInformacionToolStripMenuItem.Tag.ToString());
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(salirToolStripMenuItem.Tag.ToString());
        }
        //20
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(calculadoraToolStripMenuItem.Tag.ToString());
        }
        private void comunicacionInternaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(comunicacionInternaToolStripMenuItem.Tag.ToString());
        }
        private void notasYObservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(notasYObservacionesToolStripMenuItem.Tag.ToString());
        }
        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(calendarioToolStripMenuItem.Tag.ToString());
        }
        //30
        private void movimientoDeAsientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(movimientoDeAsientosToolStripMenuItem.Tag.ToString());
        }
        private void actualizaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(actualizaciónToolStripMenuItem1.Tag.ToString());
        }
        private void detalleDeModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(detalleDeModelosToolStripMenuItem.Tag.ToString());
        }
        private void renumeraciónDeAsientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(renumeraciónDeAsientosToolStripMenuItem.Tag.ToString());
        }
        private void libroDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(libroDiarioToolStripMenuItem.Tag.ToString());
        }
        private void libroMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(libroMayorToolStripMenuItem.Tag.ToString());
        }
        private void libroMayorGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(libroMayorGrupoToolStripMenuItem.Tag.ToString());
        }
        private void libroMayorInformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(libroMayorInformeToolStripMenuItem.Tag.ToString());
        }
        private void balanceDeSumasYSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(balanceDeSumasYSaldosToolStripMenuItem.Tag.ToString());
        }
        private void balanceGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(balanceGeneralToolStripMenuItem.Tag.ToString());
        }
        private void definiciónDeInformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(definiciónDeInformesToolStripMenuItem.Tag.ToString());
        }
        private void actualizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(actualizacionToolStripMenuItem.Tag.ToString());
        }
        private void detalleInformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(detalleInformeToolStripMenuItem.Tag.ToString());
        }
        private void inforrmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(inforrmeToolStripMenuItem.Tag.ToString());
        }
        private void auditoriaInternaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(auditoriaInternaToolStripMenuItem1.Tag.ToString());
        }
        //40
        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresa frmEmpresa = new frmEmpresa();
            permiso = Negocio.FGenerales.Permiso(empresaToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                frmEmpresa.ShowDialog();
            }
        }
        private void definicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(definicionToolStripMenuItem.Tag.ToString());
        }
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(modificaToolStripMenuItem.Tag.ToString());
        }
        private void ejercicioContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(ejercicioContableToolStripMenuItem.Tag.ToString());
        }
        private void planDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas plandecuenta = new frmPlanDeCuentas();
            permiso = Negocio.FGenerales.Permiso(planDeCuentasToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                Negocio.FGenerales.ManejarFormularios(planDeCuentas, this, pbLogo);
            }
        }
        private void conceptosContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(conceptosContablesToolStripMenuItem.Tag.ToString());
        }
        private void rubrosContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(rubrosContablesToolStripMenuItem.Tag.ToString());
        }
        private void coeficienteDeAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(coeficienteDeAjusteToolStripMenuItem.Tag.ToString());
        }
        private void centroDeCosteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(centroDeCosteToolStripMenuItem.Tag.ToString());
        }
        private void rubricacionDeSubDiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(rubricacionDeSubDiariosToolStripMenuItem.Tag.ToString());
        }
        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(agendaToolStripMenuItem.Tag.ToString());
        }
        private void parametrosContablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(parametrosContablesToolStripMenuItem.Tag.ToString());
        }
        private void configurarImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(configurarImpresorasToolStripMenuItem.Tag.ToString());
        }
        //50
        private void soporteInteractivoDeContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negocio.FGenerales.Permiso(soporteInteractivoDeContableToolStripMenuItem.Tag.ToString());
        }

        //SIN CODIGO
        private void parametrizacionDePermisosPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisosUsuarios permisosusuarios = new frmPermisosUsuarios();
            permisosusuarios.ShowDialog();
        }
        //
    }
}
