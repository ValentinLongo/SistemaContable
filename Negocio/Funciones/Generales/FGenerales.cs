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
using System.Security.Cryptography;
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
            int UltimoID = 0;

            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"SELECT TOP 1 {campo} FROM {tabla} ORDER BY {campo} DESC");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }

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

        //para abrir formularios dentro del Menu Principal
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

        //para verificar si el usuario tiene permisos para acceder
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

        public static bool Mostrarfrm(Form Formulario, string tag)
        {
            if (Permiso(tag))
            {
                Formulario.Show();
                return false;
            }
            return true;
        }

        //para realizar una busqueda en un datagridview
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

        //Para verificar si el ejercicio contable tiene asiento de cierre o apertura
        public static bool EstadoEjercicio(int ejercicio, int tipo)
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

        //para sincronizar el footer con el datagridview requerido
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

        //para validar si la fecha ingresada por el usuario se encuentra dentro de los valores permitidos por el ejercicio
        public static bool DesdeHastaEjercicio(int NroEjer, string DESDE, string HASTA)
        {
            string desde = "";
            string hasta = "";

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_desde, eje_hasta FROM Ejercicio WHERE eje_codigo = {NroEjer}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                desde = dr["eje_desde"].ToString();
                hasta = dr["eje_hasta"].ToString();
            }

            if (Convert.ToDateTime(DESDE) >= Convert.ToDateTime(desde)) 
            {
                if (Convert.ToDateTime(HASTA) <= Convert.ToDateTime(hasta)) 
                {
                    return true;
                }
            }
            return false;
        }

        //para obtener la cantidad de dias de un mes
        public static string DiasDelMes(int mes, int año) 
        {
            string dia = "";
            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dia = "31";
                    break;

                case 2:
                    if ((año % 4 == 0 && año % 100 != 0) || año % 400 == 0)
                    {
                        dia = "29";
                    }
                    else
                    {
                        dia = "28";
                    }
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dia = "30";
                    break;

                default:
                    break;
            }
            return dia;
        }

        //para mostrar en un lbl la cantidad de elementos que tiene un dgv
        public static void CantElementos(Label lbl,DataGridView dgv)
        {
            lbl.Text = "Elementos: " + dgv.RowCount;
            lbl.BringToFront();
        }

        //para verificar que la hora ingresada se encuentre entre los valores correspondientes
        public static bool ValidacionHoraFecha(int proceso,MaskedTextBox mask) //proceso 1 = Validacion Hora y proceso 2 = Validacion Fecha
        {
            if (proceso == 1)
            {
                if (DateTime.TryParseExact(mask.Text, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (DateTime.TryParseExact(mask.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //para minimizar en la barra de herramientas de windows un frmMDIchild
        public static void MinimizarMDIchild(Form frm)
        {
            if (frm.WindowState == FormWindowState.Minimized)
            {
                if (frm.IsMdiChild)
                {
                    frm.MdiParent = null;  // Desvincula el formulario secundario del formulario principal MDI
                }
            }
            else
            {
                if (!frm.IsMdiChild)
                {
                    Form formularioPadre = Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.IsMdiContainer);

                    if (formularioPadre != null)
                    {
                        frm.MdiParent = formularioPadre; // Vincula el formulario secundario nuevamente al formulario principal MDI
                        frm.TopLevel = false;
                        frm.Dock = DockStyle.Fill;
                        frm.BringToFront();
                        frm.Show();
                    }
                }
            }
        }

        public static string NombreEjercicio(int nroEjercicio)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select eje_descri from Ejercicio where eje_codigo = {nroEjercicio}");
            return ds.Tables[0].Rows[0]["eje_descri"].ToString();
        }

    }
}
