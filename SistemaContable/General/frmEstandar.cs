using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmEstandar : Form
    {
        public static int proceso; //indica la parte del codigo que se va a ejecutar.
        public static string mensaje;
        public frmEstandar()
        {
            InitializeComponent();
            if (proceso == 1)
            {
                Mensaje.Text = mensaje;
            }
            if (proceso == 2)
            {
                Mensaje.Text = mensaje;
            }

        }
    }
}
