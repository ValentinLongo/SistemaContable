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

        public static void agregarEventoKeyDown(TextBox txt, Form formulario)
        {

            txt.KeyDown += TextBox1_KeyDown;         

            void TextBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    formulario.SelectNextControl((Control)txt, true, true, true, true);
                    //SendKeys.Send("{TAB}");
                }
            }
        }

        public static void EventosFormulario(Form formulario)
        {

            foreach (Control Ctrl in formulario.Controls)
            {
                if (Ctrl is Panel)
                {
                    foreach (Control Ctrl1 in Ctrl.Controls)
                    {

                        if (Ctrl1 is TextBox)
                        {
                            agregarEventoKeyDown(Ctrl1 as TextBox, formulario);
                        }

                    }
                }

                if (Ctrl is TextBox)
                {
                    agregarEventoKeyDown(Ctrl as TextBox, formulario);
                }

            }
        }

        public static int ValidacionVacio(Form formulario) 
        {
            bool error = false;

            foreach (Control Ctrl in formulario.Controls)
            {
                if (Ctrl.Tag == "5")
                {
                    if (Ctrl.Text == "")
                    {
                        error = true;
                    }
                }              
            }
            if (error) 
            {
                MessageBox.Show("Atención: Falta completar campos.");
                return 1;
            }
            return 0;
        }
    }
}
