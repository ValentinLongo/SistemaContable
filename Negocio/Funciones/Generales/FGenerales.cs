using Bunifu.UI.WinForms;
using Datos;
using Datos.Modelos;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace Negocio
{
    public class FGenerales
    {
        public static int ultimoNumeroID(string campo, string tabla)
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"SELECT TOP 1 {campo} FROM {tabla} ORDER BY {campo} DESC");
            int UltimoID = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                UltimoID = Convert.ToInt32(dr[$"{campo}"]);
            }
            UltimoID++;
            return UltimoID;
        }

        public static void AbrirEnfrmPadre(Form Formulario, Form FormPadre, PictureBox logo)
        {
            Formulario.MdiParent = FormPadre;
            Formulario.TopLevel = false;
            Formulario.Dock = DockStyle.Fill;
            logo.SendToBack();
            Formulario.BringToFront();
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Show();
        }

        public static void ManejarFormularios(Form Formulario, Form FormPadre, PictureBox logo, string tag)
        {
            if (Permiso(tag))
            {
                if (Formulario.ActiveControl == null)
                {
                    AbrirEnfrmPadre(Formulario, FormPadre, logo);
                }
                else
                {
                    Formulario.BringToFront();
                }
            }
        }

        private static bool Permiso(string tag)
        {
            DataSet ds = new DataSet();
            int usuario = FLogin.IdUsuario;
            int resultado = 0;
            if (tag != "")
            {
                ds = AccesoBase.ListarDatos($"SELECT mxu_activo FROM MenuxUsu WHERE mxu_sistema = 'CO' AND mxu_usuario = {usuario} AND mxu_codigo = '{tag}'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resultado = Convert.ToInt32(dr["mxu_activo"]);
                }
                if (resultado == 1)
                {
                    return true;
                }
                else if (resultado == 0)
                {
                    MessageBox.Show("Atención: Acceso denegado.");
                    return false;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static void Mostrarfrm(Form Formulario, string tag)
        {
            bool permiso = Permiso(tag);
            if (permiso)
            {
                Formulario.Show();
            }
        }

        public static void Sesion(Form Inicio, ToolStrip tsAccesosDirectos, int proceso) //proceso 1 = cierra sesion, 2 = abre sesion
        {
            if (proceso == 1)
            {
                foreach (Control Ctrl in Inicio.Controls)
                {
                    if (Ctrl is BunifuGradientPanel)
                    {
                        foreach (Control Ctrl2 in Ctrl.Controls)
                        {
                            if (Ctrl2 is RJButton)
                            {
                                Ctrl2.Enabled = false;
                            }
                        }
                    }
                    if (Ctrl is ToolStrip)
                    {
                        foreach (ToolStripItem botones in tsAccesosDirectos.Items)
                        {
                            if (botones is ToolStripButton)
                            {
                                if (botones.Tag.ToString() != "12345")
                                {
                                    botones.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            else if (proceso == 2)
            {
                foreach (Control Ctrl in Inicio.Controls)
                {
                    if (Ctrl is BunifuGradientPanel)
                    {
                        foreach (Control Ctrl2 in Ctrl.Controls)
                        {
                            if (Ctrl2 is RJButton)
                            {
                                Ctrl2.Enabled = true;
                            }
                        }
                    }
                    if (Ctrl is ToolStrip)
                    {
                        foreach (ToolStripItem botones in tsAccesosDirectos.Items)
                        {
                            if (botones is ToolStripButton)
                            {
                                if (botones.Tag.ToString() != "12345")
                                {
                                    botones.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string Busqueda([Optional] DataGridView dgv,string txtbusqueda,BunifuCheckBox inicio,int where_o_and, string columna) //where = 1 / and = 2
        {
            string retorno = "";

            if (txtbusqueda != "")
            {
                if (where_o_and == 1)
                {
                    if (inicio.Checked)
                    {
                        retorno = "WHERE " + columna + " LIKE " + "'" + txtbusqueda + "%'";
                    }
                    else
                    {
                        retorno = "WHERE " + columna + " LIKE " + "'%" + txtbusqueda + "%'";
                    }

                    dgv.Rows.Clear();
                    return retorno;

                }
                else if (where_o_and == 2)
                {
                    if (inicio.Checked)
                    {
                        retorno = "AND " + columna + " LIKE " + "'" + txtbusqueda + "%'";
                    }
                    else
                    {
                        retorno = "AND " + columna + " LIKE " + "'%" + txtbusqueda + "%'";
                    }

                    dgv.Rows.Clear();
                    return retorno;


                }

                dgv.Rows.Clear();
                return retorno;

            }

            dgv.Rows.Clear();
            return retorno;

        }



    }
}
