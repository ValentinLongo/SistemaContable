using Bunifu.UI.WinForms.Helpers.Transitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{

    public class FTabEnter
    {
        public static object TabEnter(Form Formulario)
        {
            ArrayList controles = new ArrayList();

            foreach (Control Ctrl in Formulario.Controls)
            {
                if (Ctrl is TextBox)
                {
                    controles.Add(Ctrl);
                }

                if (Ctrl is Button)
                {
                    controles.Add(Ctrl);
                }

                if (Ctrl is Panel)
                {
                    foreach (Control Ctrl1 in Ctrl.Controls)
                    {
                        if (Ctrl1 is TextBox)
                        {
                            controles.Add(Ctrl1);
                        }

                        if (Ctrl1 is Button)
                        {
                            controles.Add(Ctrl1);
                        }
                    }
                }
            }

            return controles;
        }
    }
}
