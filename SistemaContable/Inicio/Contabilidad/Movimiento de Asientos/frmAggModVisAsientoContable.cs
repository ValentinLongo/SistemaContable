using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmAggModVisAsientoContable : Form
    {
        private static int add_mod_vis; // tipo de proceso que realizara el formulario

        public frmAggModVisAsientoContable(int addmodvis, ComboBox cbSeleccion)
        {
            InitializeComponent();
            Setear(add_mod_vis,cbSeleccion.SelectedValue.ToString(),cbSeleccion.SelectedText);
        }

        private void Setear(int addmodvis,string codejercicio, string descriejercicio) 
        {
            txtCodEjercicio.Text = codejercicio;
            txtDescriEjercicio.Text = descriejercicio; //no lo trae (ver)

            if (addmodvis == 1) // agregar
            {

            }
            else if(addmodvis == 2) // modificar
            {

            }
            else if(addmodvis == 3) // visualizar
            {

            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
