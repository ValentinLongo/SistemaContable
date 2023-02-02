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
using System.Text;
using System.Threading.Tasks;
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

            foreach(DataRow dr in ds.Tables[0].Rows)
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
    }
}
