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

        private static int RGB(string Cadena, int parte)
        {
            int Valor = 0;
            if (parte == 1)
            {
                Valor = Convert.ToInt32(Cadena.Substring(0, 3));
            }
            if (parte == 2)
            {
                Valor = Convert.ToInt32(Cadena.Substring(4, 3));
            }
            if (parte == 3)
            {
                Valor = Convert.ToInt32(Cadena.Substring(8, 3));
            }
            return Valor;
        }

        public static void SetearFormato(Form Formulario)
        {
            
            Font font = new Font("Franklin Gothic Medium", 20.0f);

            Formulario.BackColor = Color.FromArgb(RGB("250,036,089", 1), RGB("250,036,089", 2), RGB("250,036,089", 3));

            foreach (Control Ctrl in Formulario.Controls)
            {
                //Ctrl = sobre formulario
                //Ctrl1 = sobre contenedor
                //Ctrl2 = sobre contenedor dentro de contenedor

                //1 = Panel Barra Control
                //2 = Panel Principal
                //3 = Panel Secundario

                if (Ctrl is Panel)
                {
                    if (Ctrl.Tag == "1")
                    {
                        Ctrl.BackColor = Color.Red;
                    }

                    if (Ctrl.Tag == "2")
                    {
                        Ctrl.BackColor = Color.Yellow;
                    }

                    if (Ctrl.Tag == "3")
                    {
                        Ctrl.BackColor = Color.Orange;
                    }

                    //controles dentro de contenedor
                    foreach (Control Ctrl1 in Ctrl.Controls)
                    {
                        if (Ctrl1.Tag == "1")
                        {
                            Ctrl1.BackColor = Color.Red;
                        }

                        if (Ctrl1.Tag == "2")
                        {
                            Ctrl1.BackColor = Color.Yellow;
                        }

                        if (Ctrl1.Tag == "3")
                        {
                            Ctrl1.BackColor = Color.Orange;
                        }

                        //
                        if (Ctrl1 is Label)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is Button)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is TextBox)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is ToolStrip)
                        {
                            Ctrl1.BackColor = Color.Black;
                        }
                        //

                        //contenedor dentro de contenedor
                        if (Ctrl1 is GroupBox)
                        {
                            foreach (Control Ctrl2 in Ctrl1.Controls)
                            {

                                if (Ctrl2 is Label)
                                {
                                    Ctrl2.BackColor = Color.Black;
                                    Ctrl2.ForeColor = Color.White;
                                    Ctrl2.Font = font;
                                }

                                if (Ctrl2 is Button)
                                {
                                    Ctrl2.BackColor = Color.Black;
                                    Ctrl2.ForeColor = Color.White;
                                    Ctrl2.Font = font;
                                }

                                if (Ctrl2 is TextBox)
                                {
                                    Ctrl2.BackColor = Color.Black;
                                    Ctrl2.ForeColor = Color.White;
                                    Ctrl2.Font = font;
                                }

                                if (Ctrl2 is ToolStrip)
                                {
                                    Ctrl2.BackColor = Color.Black;
                                }
                            }
                        }
                    }
                }

                if (Ctrl is GroupBox)
                {
                    foreach (Control Ctrl1 in Ctrl.Controls)
                    {

                        if (Ctrl1 is Label)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is Button)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is TextBox)
                        {
                            Ctrl1.BackColor = Color.Black;
                            Ctrl1.ForeColor = Color.White;
                            Ctrl1.Font = font;
                        }

                        if (Ctrl1 is ToolStrip)
                        {
                            Ctrl1.BackColor = Color.Black;
                        }
                    }
                }

                if (Ctrl is Label)
                {
                    Ctrl.BackColor = Color.Black;
                    Ctrl.ForeColor = Color.White;
                    Ctrl.Font = font;
                }

                if (Ctrl is Button)
                {
                    Ctrl.BackColor = Color.Black;
                    Ctrl.ForeColor = Color.White;
                    Ctrl.Font = font;
                }

                if (Ctrl is TextBox)
                {
                    Ctrl.BackColor = Color.Black;
                    Ctrl.ForeColor = Color.White;
                    Ctrl.Font = font;
                }

                if (Ctrl is ToolStrip)
                {
                    Ctrl.BackColor = Color.Black;
                }
            }
        }
    }
}
