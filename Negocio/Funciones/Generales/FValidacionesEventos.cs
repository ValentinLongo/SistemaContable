using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class FValidacionesEventos
    {
        // 1 = true / 0 = false

        //primer numero = Validacion vacio
        //segundo numero = convierte en mayuscula
        //tercer numero = solo numero/s
        //cuarto numero = solo letra/s
        //quinto numero = numers/s y coma

        public static void agregarValidacionesyEventos(TextBox txt, Form formulario)
        {
            //evento para usar el espacio como el tab
            txt.KeyDown += TextBox_KeyDown;

            string Tag2 = "";
            string Tag3 = "";
            string Tag4 = "";
            string Tag5 = "";

            //Convierte todos los tb en mayuscula
            Tag2 = Tags(txt.Tag.ToString(), 2);
            if (Tag2 == "1")
            {
                txt.CharacterCasing = CharacterCasing.Upper;
                txt.KeyPress -= TextBox_KeyPress_numeros;
            }

            //tb solo numeros
            Tag3 = Tags(txt.Tag.ToString(), 3);
            if (Tag3 == "1") 
            {
                txt.KeyPress += TextBox_KeyPress_numeros;
                txt.KeyPress -= TextBox_KeyPress_letras;
            }

            //tb solo letras
            Tag4 = Tags(txt.Tag.ToString(), 4);
            if (Tag4 == "1") 
            {
                txt.KeyPress += TextBox_KeyPress_letras;
                txt.KeyPress -= TextBox_KeyPress_numeros;
            }

            //tb numeros y coma
            Tag5 = Tags(txt.Tag.ToString(), 5);
            if (Tag5 == "1")
            {
                txt.KeyPress += TextBox_KeyPress_numerosycoma;
            }

            void TextBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    formulario.SelectNextControl((Control)txt, true, true, true, true);
                    //SendKeys.Send("{TAB}");
                }
            }

            void TextBox_KeyPress_numeros(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            void TextBox_KeyPress_letras(object sender, KeyPressEventArgs e) 
            {
                if (!(char.IsControl(e.KeyChar)) && !char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            void TextBox_KeyPress_numerosycoma(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;                    
                }
                // solo 1 coma decimal
                //if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                //{
                //    e.Handled = true;
                //}
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
                            agregarValidacionesyEventos(Ctrl1 as TextBox, formulario);
                        }
                    }
                }
                if (Ctrl is TextBox)
                {
                    agregarValidacionesyEventos(Ctrl as TextBox, formulario);
                }
            }
        }

        public static int ValidacionVacio(Form formulario)
        {
            bool error = false;
            string Tag1 = "";

            foreach (Control Ctrl in formulario.Controls)
            {
                if (Ctrl is TextBox)
                {
                    Tag1 = Tags(Ctrl.Tag.ToString(), 1);

                    if (Tag1 == "1")
                    {
                        if (Ctrl.Text == "" || Ctrl.Text == null)
                        {
                            error = true;
                        }
                    }
                }
            }
            if (error)
            {
                return 1;
            }
            return 0;
        }

        public static string Tags(string Cadena, int TagNro) 
        {
            string Valor = "";

            if (TagNro == 1)
            {
                Valor = Cadena.Substring(0, 1);
            }
            if (TagNro == 2)
            {
                Valor = Cadena.Substring(1, 1);
            }
            if (TagNro == 3)
            {
                Valor = Cadena.Substring(2, 1);
            }
            if(TagNro == 4) 
            {
                Valor = Cadena.Substring(3, 1);
            }
            if (TagNro == 5)
            {
                Valor = Cadena.Substring(4, 1);
            }
            return Valor;
        }
    }
}
