using Datos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class FFormatoSistema
    {
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

        public static List<MFormatoSistema> lista = new List<MFormatoSistema>();

        private static void BuscarFormato()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM FormatoSistema");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MFormatoSistema mFormato = new MFormatoSistema()
                {
                    fmt_control = dr["fmt_control"].ToString(),
                    fmt_rgbBack = dr["fmt_rgbBack"].ToString(),
                    fmt_rgbFore = dr["fmt_rgbFore"].ToString(),
                    fmt_fuenteName = dr["fmt_fuenteName"].ToString(),
                    fmt_fuenteSize = dr["fmt_fuenteSize"].ToString()
                };
                lista.Add(mFormato);
            }
        }

        //RGBback
        public static string RGBbackFormulario;
        public static string RGBbackFormulariomdi;
        public static string RGBbackPanel1;
        public static string RGBbackPanel2;
        public static string RGBbackPanel3;
        public static string RGBbackLabel;
        public static string RGBbackButtom;
        public static string RGBbackTextbox;
        public static string RGBbackToolstrip;

        //RGBfore
        public static string RGBforeLabel;
        public static string RGBforeButtom;
        public static string RGBforeTextbox;

        //Fuentename
        public static string FuentenameLabel;
        public static string FuentenameButtom;
        public static string FuentenameTextbox;

        //Fuentesize
        public static int FuentesizeLabel;
        public static int FuentesizeButtom;
        public static int FuentesizeTextbox;

        public static void SetearFormato(Form Formulario)
        {
            BuscarFormato();

            foreach (MFormatoSistema MFormato in lista)
            {

                //Formulario
                if (MFormato.fmt_control == "formulario")
                {
                    RGBbackFormulario = MFormato.fmt_rgbBack.ToString();
                    Formulario.BackColor = Color.FromArgb(RGB(RGBbackFormulario, 1), RGB(RGBbackFormulario, 2), RGB(RGBbackFormulario, 3));
                }

                //Paneles
                if (MFormato.fmt_control == "panel1")
                {
                    RGBbackPanel1 = MFormato.fmt_rgbBack.ToString();
                }
                if (MFormato.fmt_control == "panel2")
                {
                    RGBbackPanel2 = MFormato.fmt_rgbBack.ToString();
                }
                if (MFormato.fmt_control == "panel3")
                {
                    RGBbackPanel3 = MFormato.fmt_rgbBack.ToString();
                }

                //Label
                if (MFormato.fmt_control == "label")
                {
                    RGBbackLabel = MFormato.fmt_rgbBack.ToString();
                    RGBforeLabel = MFormato.fmt_rgbFore.ToString();
                    FuentenameLabel = MFormato.fmt_fuenteName.ToString();
                    FuentesizeLabel = Convert.ToInt32(MFormato.fmt_fuenteSize);
                }

                //Buttom
                if (MFormato.fmt_control == "boton")
                {
                    RGBbackButtom = MFormato.fmt_rgbBack.ToString();
                    RGBforeButtom = MFormato.fmt_rgbFore.ToString();
                    FuentenameButtom = MFormato.fmt_fuenteName.ToString();
                    FuentesizeButtom = Convert.ToInt32(MFormato.fmt_fuenteSize);
                }

                //TextBox
                if (MFormato.fmt_control == "textbox")
                {
                    RGBbackTextbox = MFormato.fmt_rgbBack.ToString();
                    RGBforeTextbox = MFormato.fmt_rgbFore.ToString();
                    FuentenameTextbox = MFormato.fmt_fuenteName.ToString();
                    FuentesizeTextbox =Convert.ToInt32(MFormato.fmt_fuenteSize);
                }

                //Toolstrip
                if (MFormato.fmt_control == "toolstrip")
                {
                    RGBbackToolstrip = MFormato.fmt_rgbBack.ToString();
                }
            }
            
            foreach (Control Ctrl in Formulario.Controls)
            {
                //Ctrl = sobre formulario
                //Ctrl1 = sobre contenedor

                //1 = Panel Barra Control
                //2 = Panel Principal
                //3 = Panel Secundario

                if (Ctrl is Panel)
                {
                    if (Ctrl.Tag.ToString() == "1")
                    {
                        Ctrl.BackColor = Color.FromArgb(RGB(RGBbackPanel1, 1), RGB(RGBbackPanel1, 2), RGB(RGBbackPanel1, 3));
                    }

                    if (Ctrl.Tag.ToString() == "2")
                    {
                        Ctrl.BackColor = Color.FromArgb(RGB(RGBbackPanel2, 1), RGB(RGBbackPanel2, 2), RGB(RGBbackPanel2, 3));
                    }

                    if (Ctrl.Tag.ToString() == "3")
                    {
                        Ctrl.BackColor = Color.FromArgb(RGB(RGBbackPanel3, 1), RGB(RGBbackPanel3, 2), RGB(RGBbackPanel3, 3));
                    }

                    //controles dentro de contenedor
                    foreach (Control Ctrl1 in Ctrl.Controls)
                    {
                        if (Ctrl1.Tag.ToString() == "1")
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackPanel1, 1), RGB(RGBbackPanel1, 2), RGB(RGBbackPanel1, 3));
                        }

                        if (Ctrl1.Tag.ToString() == "2")
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackPanel2, 1), RGB(RGBbackPanel2, 2), RGB(RGBbackPanel2, 3));
                        }

                        if (Ctrl1.Tag.ToString() == "3")
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackPanel3, 1), RGB(RGBbackPanel3, 2), RGB(RGBbackPanel3, 3));
                        }

                        //
                        if (Ctrl1 is Label)
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackLabel, 1), RGB(RGBbackLabel, 2), RGB(RGBbackLabel, 3));
                            Ctrl1.ForeColor = Color.FromArgb(RGB(RGBforeLabel, 1), RGB(RGBforeLabel, 2), RGB(RGBforeLabel, 3));
                            Ctrl1.Font = new Font(FuentenameLabel,FuentesizeLabel);
                        }

                        if (Ctrl1 is Button)
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackButtom, 1), RGB(RGBbackButtom, 2), RGB(RGBbackButtom, 3));
                            Ctrl1.ForeColor = Color.FromArgb(RGB(RGBforeButtom, 1), RGB(RGBforeButtom, 2), RGB(RGBforeButtom, 3));
                            Ctrl1.Font = new Font(FuentenameButtom, FuentesizeButtom);
                        }

                        if (Ctrl1 is TextBox)
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackTextbox, 1), RGB(RGBbackTextbox, 2), RGB(RGBbackTextbox, 3));
                            Ctrl1.ForeColor = Color.FromArgb(RGB(RGBforeTextbox, 1), RGB(RGBforeTextbox, 2), RGB(RGBforeTextbox, 3));
                            Ctrl1.Font = new Font(FuentenameTextbox, FuentesizeTextbox);
                        }

                        if (Ctrl1 is ToolStrip)
                        {
                            Ctrl1.BackColor = Color.FromArgb(RGB(RGBbackToolstrip, 1), RGB(RGBbackToolstrip, 2), RGB(RGBbackToolstrip, 3));
                        }
                        //
                    }
                }

                if (Ctrl is Label)
                {
                    Ctrl.BackColor = Color.FromArgb(RGB(RGBbackLabel, 1), RGB(RGBbackLabel, 2), RGB(RGBbackLabel, 3));
                    Ctrl.ForeColor = Color.FromArgb(RGB(RGBforeLabel, 1), RGB(RGBforeLabel, 2), RGB(RGBforeLabel, 3));
                    Ctrl.Font = new Font(FuentenameLabel, FuentesizeLabel);
                }

                if (Ctrl is Button)
                {
                    Ctrl.BackColor = Color.FromArgb(RGB(RGBbackButtom, 1), RGB(RGBbackButtom, 2), RGB(RGBbackButtom, 3));
                    Ctrl.ForeColor = Color.FromArgb(RGB(RGBforeButtom, 1), RGB(RGBforeButtom, 2), RGB(RGBforeButtom, 3));
                    Ctrl.Font = new Font(FuentenameButtom, FuentesizeButtom);
                }

                if (Ctrl is TextBox)
                {
                    Ctrl.BackColor = Color.FromArgb(RGB(RGBbackTextbox, 1), RGB(RGBbackTextbox, 2), RGB(RGBbackTextbox, 3));
                    Ctrl.ForeColor = Color.FromArgb(RGB(RGBforeTextbox, 1), RGB(RGBforeTextbox, 2), RGB(RGBforeTextbox, 3));
                    Ctrl.Font = new Font(FuentenameTextbox, FuentesizeTextbox);
                }

                if (Ctrl is ToolStrip)
                {
                    Ctrl.BackColor = Color.FromArgb(RGB(RGBbackToolstrip, 1), RGB(RGBbackToolstrip, 2), RGB(RGBbackToolstrip, 3));
                }
            }

        }

        public static void FondoMDI(Form Formulario, Panel borde1, Panel borde2, Panel borde3, Panel borde4, PictureBox logo)
        {
            BuscarFormato();
            foreach (MFormatoSistema MFormato in lista)
            {
                if (MFormato.fmt_control == "formulariomdi")
                {
                    RGBbackFormulariomdi = MFormato.fmt_rgbBack.ToString();                 
                }
            }

            MdiClient oMDI;
            foreach (Control ctl in Formulario.Controls)
            {
                try
                {
                    oMDI = (MdiClient)ctl;
                    oMDI.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                    borde1.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                    borde2.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                    borde3.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                    borde4.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                    logo.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
                }
                catch (Exception)
                {
                }
            }
        }

        public static void ColorMDI(Control ctrl) 
        {
            BuscarFormato();
            foreach (MFormatoSistema MFormato in lista)
            {
                if (MFormato.fmt_control == "formulariomdi")
                {
                    RGBbackFormulariomdi = MFormato.fmt_rgbBack.ToString();
                }
            }
            ctrl.BackColor = Color.FromArgb(RGB(RGBbackFormulariomdi, 1), RGB(RGBbackFormulariomdi, 2), RGB(RGBbackFormulariomdi, 3));
        }

        public static void ColorBorde(Control ctrl) 
        {
            BuscarFormato();
            foreach (MFormatoSistema MFormato in lista)
            {
                if (MFormato.fmt_control == "formulario")
                {
                    RGBbackFormulario = MFormato.fmt_rgbBack.ToString();
                }
            }
            ctrl.BackColor = Color.FromArgb(RGB(RGBbackFormulario, 1), RGB(RGBbackFormulario, 2), RGB(RGBbackFormulario, 3));
        }
    }
}
