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

        // Primer numero = Validacion Vacio
        // Segundo numero = Convierte en Mayuscula
        // Tercer numero = Solo Numero/s
        // Cuarto numero = Solo Letra/s
        // Quinto numero = Numero/s y Coma

        public static void agregarValidacionesyEventos(TextBox txt, Form formulario)
        {
            //evento para usar el espacio como el tab
            txt.KeyDown += TextBox_KeyDown;

            string Tag2 = "";
            string Tag3 = "";
            string Tag4 = "";
            string Tag5 = "";

            //txt en mayuscula
            Tag2 = Tags(txt.Tag.ToString(), 2);
            if (Tag2 == "1")
            {
                txt.CharacterCasing = CharacterCasing.Upper;
                txt.KeyPress -= TextBox_KeyPress_numeros;
            }

            //txt solo numeros
            Tag3 = Tags(txt.Tag.ToString(), 3);
            if (Tag3 == "1") 
            {
                txt.KeyPress += TextBox_KeyPress_numeros;
                txt.KeyPress -= TextBox_KeyPress_letras;
            }

            //txt solo letras
            Tag4 = Tags(txt.Tag.ToString(), 4);
            if (Tag4 == "1") 
            {
                txt.KeyPress += TextBox_KeyPress_letras;
                txt.KeyPress -= TextBox_KeyPress_numeros;
            }

            //txt numeros y coma
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
            string Tag1 = "";

            foreach (Control Ctrl in formulario.Controls)
            {
                if (Ctrl is TextBox || Ctrl is MaskedTextBox)
                {
                    Tag1 = Tags(Ctrl.Tag.ToString(), 1);

                    if (Tag1 == "1")
                    {
                        if (Ctrl is MaskedTextBox)
                        {
                            if (((MaskedTextBox)Ctrl).MaskFull == false)
                            {
                                return 1;
                            }
                        }
                        if (Ctrl.Text == "" || Ctrl.Text == null)
                        {
                            return 1;
                        }
                    }
                }
                else if(Ctrl is Panel) 
                {
                    foreach (Control Ctrl2 in Ctrl.Controls)
                    {
                        if (Ctrl2 is TextBox || Ctrl2 is MaskedTextBox)
                        {
                            Tag1 = Tags(Ctrl2.Tag.ToString(), 1);

                            if (Tag1 == "1")
                            {
                                if (Ctrl2 is MaskedTextBox)
                                {
                                    if (((MaskedTextBox)Ctrl2).MaskFull == false)
                                    {
                                        return 1;
                                    }
                                }
                                if (Ctrl2.Text == "" || Ctrl2.Text == null)
                                {
                                    return 1;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public static string Tags(string Cadena, int TagNro) 
        {
            string Valor = "";

            if (TagNro == 1)
            {
                Valor = Cadena.Substring(0, 1); //Validacion Vacio
            }
            if (TagNro == 2)
            {
                Valor = Cadena.Substring(1, 1); //Convierte en Mayuscula
            }
            if (TagNro == 3)
            {
                Valor = Cadena.Substring(2, 1);  //Solo Numero/s
            }
            if(TagNro == 4) 
            {
                Valor = Cadena.Substring(3, 1); //Solo Letra/s
            }
            if (TagNro == 5)
            {
                Valor = Cadena.Substring(4, 1); //Numero/s y Coma
            }
            return Valor;
        }
    }
}
