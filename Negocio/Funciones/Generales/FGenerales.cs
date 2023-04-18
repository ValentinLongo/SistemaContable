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

        public static bool ManejarFormularios(Form Formulario, Form FormPadre, PictureBox logo, string tag)
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
            else
            {
                return true;
            }
            return false;
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

        public static bool EstadoEjercicio(int ejercicio, int tipo) //Para verificar si el ejercicio contable tiene asiento de cierre o apertura
        {

            if (tipo == 1) //CIERRE
            {
                DataSet ds = new DataSet();
                int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {ejercicio} AND ast_tipo = 4");
                if (resultado == 1)
                {
                    return true;
                }
            }
            else if (tipo == 2) //APERTURA
            {
                DataSet ds = new DataSet();
                int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {ejercicio} AND ast_tipo = 1");
                if (resultado == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SincronizarFooter(DataGridView dgv) 
        {
            //la posición actual del scrollbar vertical
            int verticalOffset = dgv.VerticalScrollingOffset;

            //el tamaño del contenido del DataGridView
            int contentHeight = dgv.RowCount * dgv.Rows[0].Height;

            //el tamaño del área visible del DataGridView
            int visibleHeight = dgv.ClientSize.Height - dgv.ColumnHeadersHeight;

            //Compara la posición actual con el tamaño del contenido menos el tamaño del área visible
            if (verticalOffset >= contentHeight - visibleHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
