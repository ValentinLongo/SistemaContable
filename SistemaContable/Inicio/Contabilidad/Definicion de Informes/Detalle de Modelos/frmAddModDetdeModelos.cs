using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
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

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos
{
    public partial class frmAddModDetdeModelos : Form
    {
        public static int agg_o_mod;
        public static DataGridView DGV1;
        public static DataGridView DGV2;
        public static string codigo;
        public frmAddModDetdeModelos()
        {
            InitializeComponent();

            txtDebe.Text = "0,00";
            txtHaber.Text = "0,00";

            if (agg_o_mod == 0)
            {
                lblControlBar.Text = "Agregar Definición de Informe";
            }
            if (agg_o_mod == 1)
            {
                lblControlBar.Text = "Modificar Definición de Informe";
                //int seleccionado = DGV.CurrentCell.RowIndex;
                //txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                //txtDescripcion.Text = DGV.Rows[seleccionado].Cells[1].Value.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (agg_o_mod == 0)
            {
                int seleccionado = DGV1.CurrentCell.RowIndex;
                string asiento = DGV1.Rows[seleccionado].Cells[0].Value.ToString();

                Negocio.Funciones.Contabilidad.FDetalledeModelos.Agregar(this,asiento,txtCuenta.Text,codigo,txtDebe.Text,txtHaber.Text,txtConcepto.Text,cbCentrodeCosto.SelectedText);
            }
            else if (agg_o_mod == 1)
            {
                //string debe = DGV2.Rows[seleccionado].Cells[2].Value.ToString();
                //string haber = DGV2.Rows[seleccionado].Cells[3].Value.ToString();

                //int seleccionado = DGV.CurrentCell.RowIndex;
                //txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                //Negocio.Funciones.Contabilidad.FActualizacionDDI.Modificar(this, txtmsg.Text, txtDescripcion.Text);
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarcuenta = new frmBuscarCuenta("Cuenta");
            buscarcuenta.ShowDialog();
            txtCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
        }
    }
}
