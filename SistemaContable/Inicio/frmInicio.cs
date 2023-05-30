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
using SistemaContable.Inicio.Contabilidad.Libro_Mayor_Grupo;
using SistemaContable.Inicio.Contabilidad.Libro_Mayor_Informe;
using SistemaContable.Properties;
using SistemaContable.Inicio.Ver.Calendario;
using SistemaContable.Inicio.Contabilidad.Renumeración_de_Asientos;
using SistemaContable.Inicio.Contabilidad.Balance_de_Sumas_y_Saldos;
using SistemaContable.Inicio.Mantenimiento.Rubricación_de_SubDiarios;
using SistemaContable.Inicio.Contabilidad.Saldos_Ajustados;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;

namespace SistemaContable
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            Negocio.FInicio.DatosUsuEmp(lblUsu, lblEmpresa, lblPerfil);

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            Negocio.FFormatoSistema.FondoMDI(this, borde1, borde2, borde3, pbLogo);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        string UsuAnterior = FLogin.NombreUsuario;

        private void btnSesion_Click(object sender, EventArgs e) //CAMBIAR SESIÓN
        {
            if (lblSesion.Text == "Cerrar Sesión")
            {
                Negocio.FInicio.Sesion(this, toolStripADs, 1);

                lblUsu.Text = "Sesión Cerrada";
                lblPerfil.Text = "Perfil: NINGUNO";
                lblEmpresa.Text = "Empresa: NINGUNA";

                lblSesion.Text = "Abrir Sesión";
                btnSesion.Image = Resources.candado_abierto;
            }
            else
            {
                frmSesion frm = new frmSesion();
                frm.ShowDialog();
                if (frmSesion.autorizado)
                {
                    Negocio.FInicio.Sesion(this, toolStripADs, 2);
                    Negocio.FInicio.DatosUsuEmp(lblUsu, lblEmpresa, lblPerfil);

                    if (UsuAnterior != FLogin.NombreUsuario)
                    {
                        int cant = Application.OpenForms.Count;
                        if (cant > 0)
                        {
                            Negocio.FInicio.CerrarPestañas();
                            Negocio.FInicio.CerrarMDIhijos(this);
                            //this.Close();
                        }
                    }
                    UsuAnterior = FLogin.NombreUsuario;

                    lblSesion.Text = "Cerrar Sesión";
                    btnSesion.Image = Resources.candado_cerrado;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) //CONTROLBAR
        {
            int cant = Application.OpenForms.Count;
            frmMessageBox MessageBox = new frmMessageBox("Atención!", "¿Realmente Desea Salir?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                if (cant > 0)
                {
                    Negocio.FInicio.CerrarPestañas();
                    Application.Exit();
                }
            }
        }

        private void btnAudInt_Click(object sender, EventArgs e)
        {
            if (Negocio.FInicio.ValidacionSupervisor())
            {
                frmAuditoriaInterna frm = new frmAuditoriaInterna();
                frm.Show();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado! Solo Supervisores pueden Acceder.", false);
                MessageBox.ShowDialog();
            }
        }

        //VARIOS
        private void frmInicio_Load(object sender, EventArgs e)
        {
            DisparadorInicio(sender, e);
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void frmInicio_MdiChildActivate(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorBorde(borde1);
            Negocio.FFormatoSistema.ColorBorde(borde2);
            Negocio.FFormatoSistema.ColorBorde(borde3);
        }

        private void tsbMensajesInternos_MouseEnter(object sender, EventArgs e)
        {
            lblnuevomensaje.BackColor = Color.FromArgb(255, 179, 215, 243);
        }

        private void tsbMensajesInternos_MouseLeave(object sender, EventArgs e)
        {
            lblnuevomensaje.BackColor = Color.FromArgb(255, 40, 40, 40);
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private int UltimoUsuarioAnterior = Negocio.FGenerales.ultimoNumeroID("usu_codigo", "Usuario");
        private void DisparadorInicio(object sender, EventArgs e)
        {
            int UltimoUsuarioNuevo = Negocio.FGenerales.ultimoNumeroID("usu_codigo", "Usuario");

            if (UltimoUsuarioAnterior != UltimoUsuarioNuevo)
            {
                m1 = Menu_Archivos;
                m2 = Menu_Ver;
                m3 = Menu_Contabilidad;
                m4 = Menu_Mantenimiento;
                m5 = Menu_Ayuda;

                Negocio.FUsuarios.AgregarPermisos(m1, m2, m3, m4, m5, this);

                UltimoUsuarioAnterior = UltimoUsuarioNuevo;
            }

            string tiempo = Negocio.FInicio.DisparadorInicio(lblnuevomensaje);

            if (tiempo == "" || tiempo != "expiro")
            {
                return;
            }

            if (tiempo == "expiro")
            {
                frmMessageBox MessageBox1 = new frmMessageBox("Atención!", "Una Tarea Expiro, ¿Desea Posponerla?", true);
                MessageBox1.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    frmCalendario frm = new frmCalendario();
                    if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbNotas.Tag.ToString()))
                    {
                        frmMessageBox MessageBox2 = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                        MessageBox2.ShowDialog();
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", tiempo + " para que una tarea expire!, ¿Desea Posponerla?", true);
                MessageBox.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    frmCalendario frm = new frmCalendario();
                    if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbNotas.Tag.ToString()))
                    {
                        frmMessageBox MessageBox3 = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                        MessageBox3.ShowDialog();
                    }
                }
            }
        }
        //

        //ACCESOS DIRECTOS
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbUsuario.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
            DisparadorInicio(sender, e);
        }

        private void tsbPlandeCuenta_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbPlandeCuenta.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
            DisparadorInicio(sender, e);
        }

        private void tsbConceptoContable_Click(object sender, EventArgs e)
        {
            frmConceptosContables frm = new frmConceptosContables();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbConceptoContable.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
            DisparadorInicio(sender, e);
        }

        private void tsbAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda frm = new frmAgenda();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbAgenda.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
            DisparadorInicio(sender, e);
        }

        private void tsbMovimientodeAsientos_Click(object sender, EventArgs e)
        {
            frmAsientosContables frm = new frmAsientosContables();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbConceptoContable.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
            DisparadorInicio(sender, e);
        }

        private void tsbLibroDiario_Click(object sender, EventArgs e)
        {
            frmLibroDiario frm = new frmLibroDiario();
            Negocio.FGenerales.Mostrarfrm(frm, tsbLibroDiario.Tag.ToString());
            DisparadorInicio(sender, e);
        }

        private void tsbLibroMayor_Click(object sender, EventArgs e)
        {
            frmLibroMayor frm = new frmLibroMayor();
            Negocio.FGenerales.Mostrarfrm(frm, tsbLibroMayor.Tag.ToString());
            DisparadorInicio(sender, e);
        }

        private void tsbBalanceDeSumasySaldos_Click(object sender, EventArgs e)
        {
            frmBalances_Informes frm = new frmBalances_Informes(1);
            Negocio.FGenerales.Mostrarfrm(frm, tsbBalanceDeSumasySaldos.Tag.ToString());
            DisparadorInicio(sender, e);
        }

        private void tsbBlockdeNotas_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process notepad = new System.Diagnostics.Process { StartInfo = { FileName = @"notepad.exe" } };
            notepad.Start();
        }

        private void tsbMensajesInternos_Click(object sender, EventArgs e)
        {
            frmComunicacionInterna frm = new frmComunicacionInterna(lblnuevomensaje);
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbMensajesInternos.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        private void tsbCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void tsbNotas_Click(object sender, EventArgs e)
        {
            frmCalendario frm = new frmCalendario();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbNotas.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        private void tsbConfigImpresora_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
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
            DisparadorInicio(sender, e);
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
            DisparadorInicio(sender, e);
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
            DisparadorInicio(sender, e);
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
            DisparadorInicio(sender, e);
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
            DisparadorInicio(sender, e);
        }

        private void btnArchivos_MouseEnter(object sender, EventArgs e)
        {
            Negocio.FFormatoSistema.ColorMDI(btnArchivos);
            pArchivos.Visible = true;

        }

        private void btnArchivos_MouseLeave(object sender, EventArgs e)
        {
            btnArchivos.BackColor = Color.FromArgb(40, 40, 40);
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
            btnCerrar_Click(sender, e);
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
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, tsbMensajesInternos.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        private void notasYObservaciones_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process notepad = new System.Diagnostics.Process { StartInfo = { FileName = @"notepad.exe" } };
            notepad.Start();
        }

        private void calendario_Click(object sender, EventArgs e)
        {
            frmCalendario frm = new frmCalendario();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, calendario.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        //30
        private void movimientoDeAsientos_Click(object sender, EventArgs e)
        {
            frmAsientosContables frm = new frmAsientosContables();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, movimientoDeAsientos.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
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
            frmRenumeraciónDeAsientos frm = new frmRenumeraciónDeAsientos();
            Negocio.FGenerales.Mostrarfrm(frm, renumeraciónDeAsientos.Tag.ToString());
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
            frmLibroMayorGrupo frm = new frmLibroMayorGrupo();
            Negocio.FGenerales.Mostrarfrm(frm, libroMayorGrupo.Tag.ToString());

        }

        private void libroMayorInforme_Click(object sender, EventArgs e)
        {
            frmLibroMayorInforme frm = new frmLibroMayorInforme();
            Negocio.FGenerales.Mostrarfrm(frm, libroMayorInforme.Tag.ToString());
        }

        private void saldosYAjustados_Click(object sender, EventArgs e)
        {
            frmSaldosAjustados frm = new frmSaldosAjustados();
            Negocio.FGenerales.Mostrarfrm(frm, saldosYAjustados.Tag.ToString());
        }

        private void balanceDeSumasYSaldos_Click(object sender, EventArgs e)
        {
            frmBalances_Informes frm = new frmBalances_Informes(1);
            Negocio.FGenerales.Mostrarfrm(frm, balanceDeSumasYSaldos.Tag.ToString());
        }

        private void balanceGeneral_Click(object sender, EventArgs e)
        {
            frmBalances_Informes frm = new frmBalances_Informes(2);
            Negocio.FGenerales.Mostrarfrm(frm, balanceGeneral.Tag.ToString());
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
            frmBalances_Informes frm = new frmBalances_Informes(3);
            Negocio.FGenerales.Mostrarfrm(frm, informe.Tag.ToString());
        }

        private void auditoriaInterna_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox1 = new frmMessageBox("Atención!", "Atención: El Proceso de Auditoria Interna Contable puede tardar algunos minutos, y NO podra ser cancelado. ¿Desea Continuar?", true, true);
            MessageBox1.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                frmRangoFechas frm = new frmRangoFechas(2,Convert.ToDateTime("01/01/2000"), DateTime.Now);
                frm.Show();
            }
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
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, definición.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        private void modificaciónDeContraseña_Click(object sender, EventArgs e)
        {
            frmModificarContra frm = new frmModificarContra();
            //Negocio.FGenerales.Mostrarfrm(frm, modificaciónDeContraseña.Tag.ToString());
            frm.Show();
        }

        private void ejercicioContable_Click(object sender, EventArgs e)
        {
            frmEjercicioContable frm = new frmEjercicioContable();
            Negocio.FGenerales.Mostrarfrm(frm, ejercicioContable.Tag.ToString());
        }

        private void planDeCuentas_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, planDeCuentas.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
        }

        private void conceptosContables_Click(object sender, EventArgs e)
        {
            frmConceptosContables frm = new frmConceptosContables();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, conceptosContables.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
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
            frmRubricacionDeSubDiarios frm = new frmRubricacionDeSubDiarios();
            frm.ShowDialog();
        }

        private void agenda_Click(object sender, EventArgs e)
        {
            frmAgenda frm = new frmAgenda();
            if (Negocio.FGenerales.ManejarFormularios(frm, this, pbLogo, agenda.Tag.ToString()))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Acceso Denegado.", false);
                MessageBox.ShowDialog();
            }
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
            string chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            string whatsappUrl = "https://wa.me/3534289818";

            Process.Start(chromePath, whatsappUrl);
        }


        //SIN CODIGO
        private void parametrizacionDePermisosPerfiles_Click(object sender, EventArgs e)
        {
            frmPermisosPerfil permisosperfil = new frmPermisosPerfil();
            frmAutorización frmAutorizacion = new frmAutorización(permisosperfil);

            bool autorizado = frmAutorización.Autoriza(4, false);
            frmAutorizacion.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmAutorizacion.SendToBack();
            }

            if (autorizado)
            {
                permisosperfil.Show();
                frmAutorizacion.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";
            }
        }

        private void parametrizacionDePermisosUsuarios_Click(object sender, EventArgs e)
        {
            frmPermisosUsu permisosusuario = new frmPermisosUsu();
            frmAutorización frmAutorizacion = new frmAutorización(permisosusuario);

            bool autorizado = frmAutorización.Autoriza(4, false);
            frmAutorizacion.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmAutorizacion.SendToBack();
            }

            if (autorizado)
            {
                permisosusuario.Show();
                frmAutorizacion.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";
            }
        }

        public static MenuDropDown m1;
        public static MenuDropDown m2;
        public static MenuDropDown m3;
        public static MenuDropDown m4;
        public static MenuDropDown m5;

        private void recalcularPermisos_Click(object sender, EventArgs e)
        {
            m1 = Menu_Archivos;
            m2 = Menu_Ver;
            m3 = Menu_Contabilidad;
            m4 = Menu_Mantenimiento;
            m5 = Menu_Ayuda;

            frmAutorización frmAutorizacion = new frmAutorización(this);

            bool autorizado = frmAutorización.Autoriza(1, false);
            frmAutorizacion.Show();
            if (frmAutorización.visibilidad == true)
            {
                frmAutorizacion.SendToBack();
            }

            if (autorizado)
            {
                frmAutorizacion.Close();
                frmAutorización.usuario = "";
                frmAutorización.contraseña = "";

                frmMessageBox MessageBox1 = new frmMessageBox("Atención!", "Atención: ¿desea recalcular los permisos del menu?", true);
                MessageBox1.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    frmEstandar estandar = new frmEstandar(1, "Se estan Revisando los Permisos de Menu asignados para los Usuarios. Porfavor espere...");
                    estandar.Show();
                    Application.DoEvents();
                    Negocio.Funciones.FRecalcularPermisos.RecalcularPermisos(Menu_Archivos, Menu_Ver, Menu_Contabilidad, Menu_Mantenimiento, Menu_Ayuda, this);
                    estandar.Close();
                }

                frmMessageBox MessageBox2 = new frmMessageBox("Atención!", "Atención: ¿desea recalcular los permisos especiales?", true);
                MessageBox2.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    frmEstandar estandar = new frmEstandar(1, "Se estan Revisando los Permisos para los Usuarios. Porfavor espere...");
                    estandar.Show();
                    Application.DoEvents();
                    Negocio.Funciones.FRecalcularPermisos.RecalcularPermisosEspeciales();
                    estandar.Close();
                }
            }
        }
    }
}
