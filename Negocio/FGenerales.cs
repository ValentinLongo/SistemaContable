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

        public static void AbrirFormulario(Form Formulario, Panel PanelPrincipal)
        {
            Formulario.TopLevel = false;
            PanelPrincipal.Controls.Add(Formulario);
            Formulario.Dock = DockStyle.Fill;
            Formulario.BringToFront();
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Show();
        }

        public static void ManejarFormularios(Form Formulario, Panel PanelPrincipal)
        {
            if (Formulario.ActiveControl == null)
            {
                AbrirFormulario(Formulario, PanelPrincipal);
            }
            else
            {
                Formulario.BringToFront();
            }
        }
    }
}
