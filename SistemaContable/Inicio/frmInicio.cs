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
using SistemaContable.Parametrizacion_Permisos;
using SistemaContable.General;
using System.Collections;
using System.Web.Services.Description;
using SistemaContable.Empresa;
using Negocio;
using RJCodeAdvance.RJControls;
using System.Runtime.CompilerServices;
using Bunifu.UI.WinForms.Helpers.Transitions;
using Datos;
using Datos.Modelos;
using SistemaContable.Rubos_Contables;
using Negocio.Funciones;
using SistemaContable.Inicio.Mantenimiento.Ejercicio_Contable;
using SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste;
using SistemaContable.Inicio.Mantenimiento;
using SistemaContable.Inicio.Contabilidad.Modelos_de_Asientos.Actualizacion;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Actualizacion;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.DetalledeInformes;
using SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos;
using SistemaContable.Inicio.Ver.Comunicacion_Interna;
using SistemaContable.Inicio.Mantenimiento.Parametros_Contables;
using Negocio.Funciones.Mantenimiento;
using System.Drawing.Printing;
using SistemaContable.Inicio.Contabilidad.Libro_Diario;
using SistemaContable.Inicio.Contabilidad.LibroMayor;

namespace SistemaContable
{
    public partial class frmInicio : Form
    {
        public static bool permiso;
        public static string frm;

        public frmInicio()
        {
            InitializeComponent();
            DatosUsuEmp();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            Negocio.FFormatoSistema.FondoMDI(this, borde1, borde2, borde3, pbLogo);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void frmInicio_MdiChildActivate(object sender, EventArgs e)
        {
            //cambiar
            borde1.BackColor = Color.FromArgb(255, 45, 45, 45);
            borde2.BackColor = Color.FromArgb(255, 45, 45, 45);
            borde3.BackColor = Color.FromArgb(255, 45, 45, 45);
        }

        private void DatosUsuEmp() 
        {
            lblUsu.Text = "Usuario: " + FLogin.NombreUsuario;
        }

        //CONTROLBAR
        public void controlbarCerrar_Click(object sender, EventArgs e)
        {
            List<Form> formlist = new List<Form>();
            int cant = Application.OpenForms.Count;
            DialogResult boton = MessageBox.Show("¿Realmente desea salir?", "Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (boton == DialogResult.OK)
            {
                if (cant > 0)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm != this)
                        {
                            formlist.Add(frm);
                        }
                    }
                    foreach (Form frm in formlist)
                    {
                        frm.Close();
                    }
                    Application.Exit();
                }
            }
        }

        private void controlbarCerrar_MouseEnter(object sender, EventArgs e)
        {
            controlbarCerrar.BackColor = Color.Red;
        }

        private void controlbarCerrar_MouseLeave(object sender, EventArgs e)
        {
            controlbarCerrar.BackColor = Color.Transparent;
        }
        //

        //
        private void frmInicio_Load(object sender, EventArgs e)
        {
            Menu_Archivos.IsMainMenu = true;
            Menu_Ver.IsMainMenu = true;
            Menu_Contabilidad.IsMainMenu = true;
            Menu_Mantenimiento.IsMainMenu = true;
            Menu_Ayuda.IsMainMenu = true;

            if (Negocio.Funciones.Ver.FComunicacionInterna.NuevosMSGs())
            {
                lblnuevomensaje.Visible = true;
            }

        }

        private void tsbMensajesInternos_MouseEnter(object sender, EventArgs e)
        {
            lblnuevomensaje.BackColor = Color.FromArgb(255, 179, 215, 243);
        }

        private void tsbMensajesInternos_MouseLeave(object sender, EventArgs e)
        {
            lblnuevomensaje.BackColor = Color.FromArgb(255, 40, 40, 40);
        }

        //

        //ACCESOS DIRECTOS
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbUsuario.Tag.ToString());
        }

        private void tsbPlandeCuenta_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbPlandeCuenta.Tag.ToString());
        }

        private void tsbConceptoContable_Click(object sender, EventArgs e)
        {
            frmConceptosContables frm = new frmConceptosContables();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbConceptoContable.Tag.ToString());
        }

        private void tsbAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda frm = new frmAgenda();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbAgenda.Tag.ToString());
        }

        private void tsbMovimientodeAsientos_Click(object sender, EventArgs e)
        {
            frmAsientosContables frm = new frmAsientosContables();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbMovimientodeAsientos.Tag.ToString());
        }

        private void tsbBlockdeNotas_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process notepad = new System.Diagnostics.Process { StartInfo = { FileName = @"notepad.exe" } };
            notepad.Start();
        }

        private void tsbMensajesInternos_Click(object sender, EventArgs e)
        {
            frmComunicacionInterna frm = new frmComunicacionInterna(lblnuevomensaje);
            Negocio.FGenerales.Mostrarfrm(frm, tsbMensajesInternos.Tag.ToString());
        }

        private void tsbCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void tsbCerrarSesion_Click(object sender, EventArgs e)
        {
            tsbCerrarSesion.Visible = false;
            Negocio.FGenerales.Sesion(this, toolStripADs, 1);
            tsbAbrirSesion.Visible = true;
            lblUsu.Text = "Sesión Cerrada";
        }

        private void tsbAbrirSesion_Click(object sender, EventArgs e)
        {
            tsbAbrirSesion.Visible = false;
            Negocio.FGenerales.Sesion(this, toolStripADs, 2);
            tsbCerrarSesion.Visible = true;
            tsbAbrirSesion.Visible = false;
            lblUsu.Text = "Usuario: " + FLogin.NombreUsuario;
            //terminar
        }

        private void tsbConfigImpresora_Click(object sender, EventArgs e)
        {

        }
        //

        //BOTONES INICIO (ABREN LOS MENUS)
        private void btnArchivos_Click(object sender, EventArgs e)
        {
            Menu_Archivos.Show(btnArchivos, btnArchivos.Width, 0);
            btnArchivos.Visible = false;
            btnArchivos2.Location = btnArchivos.Location;
            btnArchivos2.Size = btnArchivos.Size;
            btnArchivos2.Visible = true;
            pArchivos2.Visible = true;
            btnArchivos2.BringToFront();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Menu_Ver.Show(btnArchivos, btnArchivos.Width, 0);
            btnVer.Visible = false;
            btnVer2.Location = btnVer.Location;
            btnVer2.Size = btnVer.Size;
            btnVer2.Visible = true;
            pVer2.Visible = true;
            btnVer2.BringToFront();
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            Menu_Contabilidad.Show(btnArchivos, btnArchivos.Width, 0);
            btnContabilidad.Visible = false;
            btnContabilidad2.Location = btnContabilidad.Location;
            btnContabilidad2.Size = btnContabilidad.Size;
            btnContabilidad2.Visible = true;
            pContabilidad2.Visible = true;
            btnContabilidad2.BringToFront();

        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            Menu_Mantenimiento.Show(btnArchivos, btnArchivos.Width, 0);
            btnMantenimiento.Visible = false;
            btnMantenimiento2.Location = btnMantenimiento.Location;
            btnMantenimiento2.Size = btnMantenimiento.Size;
            btnMantenimiento2.Visible = true;
            pMantenimiento2.Visible = true;
            btnMantenimiento2.BringToFront();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Menu_Ayuda.Show(btnAyuda, btnAyuda.Width, 0);
            btnAyuda.Visible = false;
            btnAyuda2.Location = btnAyuda.Location;
            btnAyuda2.Size = btnAyuda.Size;
            btnAyuda2.Visible = true;
            pAyuda2.Visible = true;
            btnAyuda2.BringToFront();
        }

        private void btnArchivos_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnArchivos);
            pArchivos.Visible = true;
            
        }
        private void btnArchivos_MouseLeave(object sender, EventArgs e)
        {
            btnArchivos.BackColor = Color.FromArgb(40,40,40);
            pArchivos.Visible = false;
        }
        private void btnVer_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnVer);
            pVer.Visible = true;
        }
        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            btnVer.BackColor = Color.FromArgb(40, 40, 40);
            pVer.Visible = false;
        }
        private void btnContabilidad_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnContabilidad);
            pContabilidad.Visible = true;
        }
        private void btnContabilidad_MouseLeave(object sender, EventArgs e)
        {
            btnContabilidad.BackColor = Color.FromArgb(40, 40, 40);
            pContabilidad.Visible = false;
        }
        private void btnMantenimiento_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnMantenimiento);
            pMantenimiento.Visible = true;
        }
        private void btnMantenimiento_MouseLeave(object sender, EventArgs e)
        {
            btnMantenimiento.BackColor = Color.FromArgb(40, 40, 40);
            pMantenimiento.Visible = false;
        }
        private void btnAyuda_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnAyuda);
            pAyuda.Visible = true;
        }
        private void btnAyuda_MouseLeave(object sender, EventArgs e)
        {
            btnAyuda.BackColor = Color.FromArgb(40, 40, 40);
            pAyuda.Visible = false;
        }
        //

        //
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void Menu_Archivos_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnArchivos.Visible = true;
            btnArchivos.BringToFront();
            btnArchivos2.Visible = false;
            pArchivos2.Visible = false;
        }

        private void Menu_Ver_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnVer.Visible = true;
            btnVer.BringToFront();
            btnVer2.Visible = false;
            pVer2.Visible = false;
        }

        private void Menu_Contabilidad_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnContabilidad.Visible = true;
            btnContabilidad.BringToFront();
            btnContabilidad2.Visible = false;
            pContabilidad2.Visible = false;
        }

        private void Menu_Mantenimiento_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnMantenimiento.Visible = true;
            btnMantenimiento.BringToFront();
            btnMantenimiento2.Visible = false;
            pMantenimiento2.Visible = false;
        }

        private void Menu_Ayuda_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            btnAyuda.Visible = true;
            btnAyuda.BringToFront();
            btnAyuda2.Visible = false;
            pAyuda2.Visible = false;
        }
        //

        //
        //FUNCION RECALCULA PERMISOS - TIENE QUE ESTAR EN EL INICIO SI O SI
        public void RecalculaPermisos()
        {
            List<MRecalcularPermisos> lista = new List<MRecalcularPermisos>();
            foreach (ToolStripMenuItem item in Menu_Archivos.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in Menu_Ver.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in Menu_Contabilidad.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in Menu_Mantenimiento.Items)
            {
                if (item.Tag != null)
                {
                    MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular1);
                }
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    if (item2.Tag != null)
                    {
                        MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                        {
                            mnu_codigo = item.Tag.ToString(),
                            mnu_descri = item.Text,
                        };
                        lista.Add(mrecalcular2);
                    }
                }
            }
            foreach (ToolStripMenuItem item in Menu_Ayuda.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
            }

            int resultado;
            int codigo;
            int perfil;
            bool bandera;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_permiso FROM Parametro");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int permiso = Convert.ToInt32(dr["par_permiso"]);
            }
            foreach (var i in lista)
            {
                resultado = 0;
                resultado = AccesoBase.ValidarDatos($"SELECT mnu_codigo FROM Menu WHERE mnu_codigo = '{i.mnu_codigo}' and mnu_sistema = 'CO'");

                if (resultado == 1)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Menu SET mnu_descri = '{i.mnu_descri}' WHERE mnu_codigo = '{i.mnu_codigo}' AND mnu_sistema = 'CO'");
                }
                else
                {
                    AccesoBase.InsertUpdateDatos($"INSERT INTO Menu ( mnu_codigo, mnu_descri, mnu_sistema ) VALUES ( '{i.mnu_codigo}', '{i.mnu_descri}', 'CO' )");
                }

                ds = AccesoBase.ListarDatos($"SELECT usu_codigo FROM Usuario");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    codigo = Convert.ToInt32(dr["usu_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT mxu_usuario,mxu_codigo,mxu_sistema FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxUsu ( mxu_usuario,mxu_codigo,mxu_activo,mxu_sistema ) VALUES ( {codigo}, '{i.mnu_codigo}', {permiso}, 'CO' )");
                    }
                }

                ds = AccesoBase.ListarDatos($"SELECT per_codigo FROM Perfil");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    perfil = Convert.ToInt32(dr["per_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT mxp_perfil,mxp_codigo,mxp_sistema FROM MenuxPerfil WHERE mxp_perfil = {perfil} AND mxp_codigo = '{i.mnu_codigo}' AND mxp_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxPerfil ( mxp_perfil,mxp_codigo,mxp_activo,mxp_sistema ) VALUES ( {perfil}, '{i.mnu_codigo}', {permiso}, 'CO' )");
                    }
                }

                bandera = true;

                ds = AccesoBase.ListarDatos($"SELECT mnu_codigo FROM menu WHERE mnu_sistema = 'CO'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int tag = Convert.ToInt32(dr["mnu_codigo"]);

                    if (tag == Convert.ToInt32(i.mnu_codigo))
                    {
                        bandera = false;
                    }
                    if (bandera)
                    {
                        //terminar deletes
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM Menu WHERE mnu_codigo = '{i.mnu_codigo}' AND mnu_descri = '{i.mnu_descri}' AND mnu_sistema = 'CO'");
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_activo = {permiso} AND mxu_sistema = 'CO'");
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxPerfil WHERE mxup_perfil = {perfil} AND mxp_codigo = '{i.mnu_codigo}' AND mxp_activo = {permiso} AND mxp_sistema = 'CO'");
                    }
                }
            }
        }

        //

        //PERMISOS PARA CADA BOTON
        //10
        private void respaldoDeInformación_Click(object sender, EventArgs e)
        {

        }
        private void restauraciónDeInformación_Click(object sender, EventArgs e)
        {

        }
        private void salir_Click(object sender, EventArgs e)
        {
            controlbarCerrar_Click(sender, e);
        }
        //20
        private void calculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }
        private void comunicaciónInterna_Click(object sender, EventArgs e)
        {
            frmComunicacionInterna frm = new frmComunicacionInterna(lblnuevomensaje);
            Negocio.FGenerales.Mostrarfrm(frm, comunicaciónInterna.Tag.ToString());
        }
        private void notasYObservaciones_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process notepad = new System.Diagnostics.Process { StartInfo = { FileName = @"notepad.exe" } };
            notepad.Start();
        }
        private void calendario_Click(object sender, EventArgs e)
        {

        }
        //30
        private void movimientoDeAsientos_Click(object sender, EventArgs e)
        {
            frmAsientosContables frm = new frmAsientosContables();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, movimientoDeAsientos.Tag.ToString());
        }
        private void actualizaciónMA_Click(object sender, EventArgs e)
        {
            frmEncabezadodeModelos frm = new frmEncabezadodeModelos();
            Negocio.FGenerales.Mostrarfrm(frm, actualizaciónMA.Tag.ToString());
        }
        private void detalleDeModelos_Click(object sender, EventArgs e)
        {
            frmDetalledeModelos frm = new frmDetalledeModelos();
            Negocio.FGenerales.Mostrarfrm(frm, detalleDeModelos.Tag.ToString());
        }
        private void renumeraciónDeAsientos_Click(object sender, EventArgs e)
        {

        }
        private void libroDiario_Click(object sender, EventArgs e)
        {
            frmLibroDiario frm = new frmLibroDiario();
            Negocio.FGenerales.Mostrarfrm(frm, libroDiario.Tag.ToString());
        }
        private void libroMayor_Click(object sender, EventArgs e)
        {
            frmLibroMayor frm = new frmLibroMayor();
            Negocio.FGenerales.Mostrarfrm(frm, libroMayor.Tag.ToString());
        }
        private void libroMayorGrupo_Click(object sender, EventArgs e)
        {

        }
        private void libroMayorInforme_Click(object sender, EventArgs e)
        {

        }
        private void saldosYAjustados_Click(object sender, EventArgs e)
        {

        }
        private void balanceDeSumasYSaldos_Click(object sender, EventArgs e)
        {

        }
        private void balanceGeneral_Click(object sender, EventArgs e)
        {

        }
        private void actualizaciónDI_Click(object sender, EventArgs e)
        {
            frmDefiniciondeInformes frm = new frmDefiniciondeInformes();
            Negocio.FGenerales.Mostrarfrm(frm, actualizaciónDI.Tag.ToString());
        }
        private void detalleInforme_Click(object sender, EventArgs e)
        {
            frmDetalledeInformes frm = new frmDetalledeInformes();
            Negocio.FGenerales.Mostrarfrm(frm, detalleInforme.Tag.ToString());
        }
        private void informe_Click(object sender, EventArgs e)
        {

        }
        private void auditoriaInterna_Click(object sender, EventArgs e)
        {

        }
        //40
        private void empresa_Click(object sender, EventArgs e)
        {
            frmEmpresa frm = new frmEmpresa();
            Negocio.FGenerales.Mostrarfrm(frm, empresa.Tag.ToString());
        }
        private void definición_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, definición.Tag.ToString());
        }
        private void modificaciónDeContraseña_Click(object sender, EventArgs e)
        {
            frmModificarContra frm = new frmModificarContra();
            Negocio.FGenerales.Mostrarfrm(frm, modificaciónDeContraseña.Tag.ToString());
        }
        private void ejercicioContable_Click(object sender, EventArgs e)
        {
            frmEjercicioContable frm = new frmEjercicioContable();
            Negocio.FGenerales.Mostrarfrm(frm, ejercicioContable.Tag.ToString());
        }
        private void planDeCuentas_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, planDeCuentas.Tag.ToString());
        }
        private void conceptosContables_Click(object sender, EventArgs e)
        {
            frmConceptosContables frm = new frmConceptosContables();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, conceptosContables.Tag.ToString());
        }
        private void rubrosContables_Click(object sender, EventArgs e)
        {
            frmRubrosContables frm = new frmRubrosContables();
            Negocio.FGenerales.Mostrarfrm(frm, rubrosContables.Tag.ToString());
        }
        private void coeficienteDeAjuste_Click(object sender, EventArgs e)
        {
            frmCoeficienteDeAjuste frm = new frmCoeficienteDeAjuste();
            Negocio.FGenerales.Mostrarfrm(frm, coeficienteDeAjuste.Tag.ToString());
        }
        private void centroDeCosto_Click(object sender, EventArgs e)
        {
            frmCentrodeCostos frm = new frmCentrodeCostos();
            Negocio.FGenerales.Mostrarfrm(frm, centroDeCosto.Tag.ToString());
        }
        private void rubricaciónDeSubDiarios_Click(object sender, EventArgs e)
        {
            
        }
        private void agenda_Click(object sender, EventArgs e)
        {
            frmAgenda frm = new frmAgenda();
            Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, agenda.Tag.ToString());
        }
        private void parametrosContables_Click(object sender, EventArgs e)
        {
            frmParametrosContables frm = new frmParametrosContables();
            Negocio.FGenerales.Mostrarfrm(frm, parametrosContables.Tag.ToString());
        }
        private void configurarImpresora_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
        }
        //50
        private void soporteInteractivoDeContable_Click(object sender, EventArgs e)
        {

        }
        //SIN CODIGO
        private void parametrizacionDePermisosPerfiles_Click(object sender, EventArgs e)
        {
            frm = "perfiles";
            frmAutorización frmSA = new frmAutorización();
            bool autorizado = frmAutorización.Autoriza(1, false); //cambiar
            frmSA.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmSA.SendToBack();
            }
            if (autorizado)
            {
                frmPermisosPerfil permisosperfil = new frmPermisosPerfil();
                permisosperfil.Show();
                frmSA.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";
            }
        }

        private void parametrizacionDePermisosUsuarios_Click(object sender, EventArgs e)
        {
            frm = "usuarios";
            frmAutorización frmSA = new frmAutorización();
            bool autorizado = frmAutorización.Autoriza(1, false); //cambiar
            frmSA.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmSA.SendToBack();
            }
            if (autorizado)
            {
                frmPermisosUsu permisosusuario = new frmPermisosUsu();
                permisosusuario.Show();
                frmSA.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";
            }
        }

        private void recalcularPermisos_Click(object sender, EventArgs e)
        {
            frm = "estandar";
            frmAutorización frmSA = new frmAutorización();
            bool autorizado = frmAutorización.Autoriza(1, false); //cambiar
            frmSA.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmSA.SendToBack();
            }
            if (autorizado)
            {
                frmSA.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";
                DialogResult boton1 = MessageBox.Show("Atención: ¿desea recalcular los permisos del menu?", "Contable", MessageBoxButtons.OKCancel);
                if (boton1 == DialogResult.OK)
                {
                    frmEstandar.proceso = 1;
                    frmEstandar.mensaje = "Se estan Revisando los Permisos de Menu asignados para los Usuarios. Porfavor espere...";
                    frmEstandar estandar = new frmEstandar();
                    estandar.Show();
                    Application.DoEvents();
                    RecalculaPermisos();
                    estandar.Close();
                }
                DialogResult boton2 = MessageBox.Show("Atención: ¿desea recalcular los permisos especiales?", "Contable", MessageBoxButtons.OKCancel);
                if (boton2 == DialogResult.OK)
                {
                    frmEstandar.proceso = 2;
                    frmEstandar.mensaje = "Se estan Revisando los Permisos para los Usuarios. Porfavor espere...";
                    frmEstandar estandar = new frmEstandar();
                    estandar.Show();
                    Application.DoEvents();
                    Negocio.Funciones.FRecalcularPermisos.RecalculaPermisosEspeciales();
                    estandar.Close();
                }
            }
        }
    }
}
