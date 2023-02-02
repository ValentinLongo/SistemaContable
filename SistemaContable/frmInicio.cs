﻿using SistemaContable.Plan_de_Cuentas;
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

namespace SistemaContable
{
    public partial class frmInicio : Form
    {
        public static bool permiso;
        public static string frm;

        //
        public frmInicio()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            Negocio.FFormatoSistema.FondoMDI(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }
        private void controlboxInicio_CloseClicked(object sender, EventArgs e)
        {
            List<Form> formlist = new List<Form>();
            int cant = Application.OpenForms.Count;

            DialogResult boton = MessageBox.Show("¿Realmente desea salir?", "Alerta!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
            else
            {
                frmInicio frmInicio = new frmInicio();
                frmInicio.ShowDialog();
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
        //FUNCION RECALCULA PERMISOS - TIENE QUE ESTAR EN EL INICIO SI O SI
        public void RecalculaPermisos()
        {
            List<MRecalcularPermisos> lista = new List<MRecalcularPermisos>();
            foreach (ToolStripMenuItem item in MenuArchivos.Items)
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
            foreach (ToolStripMenuItem item in MenuVer.Items)
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
            foreach (ToolStripMenuItem item in MenuContabilidad.Items)
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
            foreach (ToolStripMenuItem item in MenuMantenimiento.Items)
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
            foreach (ToolStripMenuItem item in MenuAyuda.Items)
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
            frmEmpresa empresa = new frmEmpresa();
            permiso = Negocio.FGenerales.Permiso(empresaToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                empresa.ShowDialog();
            }

        }
        private void definicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permiso = Negocio.FGenerales.Permiso(definicionToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                Negocio.FGenerales.ManejarFormularios(usuarios, this, pbLogo);
            }
        }
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarContra frmModificar = new frmModificarContra();
            permiso = Negocio.FGenerales.Permiso(modificaToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                frmModificar.ShowDialog();
            }
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
            frmRubrosContables rubroContables = new frmRubrosContables();
            permiso = Negocio.FGenerales.Permiso(rubrosContablesToolStripMenuItem.Tag.ToString());
            if (permiso)
            {
                rubroContables.ShowDialog();
            }

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
        public void parametrizacionDePermisosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void recalcularToolStripMenuItem_Click(object sender, EventArgs e)
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
                DialogResult boton = MessageBox.Show("Atención: ¿desea recalcular los permisos del menu?", "Contable", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    frmEstandar.proceso = 1;
                    frmEstandar.mensaje1 = "Mensaje";
                    frmEstandar.mensaje2 = "Se estan Revisando los Permisos de Menu asignados para los Usuarios. Porfavor espere...";
                    frmEstandar estandar = new frmEstandar();
                    estandar.Show();
                    Application.DoEvents();
                    RecalculaPermisos();
                    estandar.Close();
                }
            }
        }
    }
}
