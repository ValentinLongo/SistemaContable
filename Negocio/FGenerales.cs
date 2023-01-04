using System;
using System.Collections.Generic;
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

        public static void SetearFormato(Form Formulario)
        {
            Font font = new Font("Franklin Gothic Medium", 20.0f);

            //Formulario.BackColor = Color.FromArgb(0, 255, 255);

            foreach (Control Ctrl in Formulario.Controls)
            {
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

                    //contenedor dentro de contenedor (fix error)
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

                        if (Ctrl1 is GroupBox)
                        {
                            foreach (Control Ctrl2 in Ctrl1.Controls)
                            {
                                if (Ctrl2 is TextBox)
                                {
                                    Ctrl2.BackColor = Color.Black;
                                    Ctrl2.ForeColor = Color.White;
                                    Ctrl2.Font = font;
                                }
                            }
                        }
                    }
                }

                //control dentro de contenedor (fix error)
                foreach (Control Ctrl2 in Ctrl.Controls)
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
}
