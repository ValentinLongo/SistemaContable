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
        private int agg_o_mod;
        public static DataGridView DGV1;
        public static DataGridView DGV2;
        public static string codigo;
        public static int seleccionado;

        public frmAddModDetdeModelos(int algo,string cuenta,string descri,string debe,string haber,string concepto,string centrodecosto)
        {
            InitializeComponent();
            agg_o_mod = algo;
            txtDebe.Text = "0,00";
            txtHaber.Text = "0,00";

            if (agg_o_mod == 0)
            {
                lblControlBar.Text = "Agregar Detalle de Modelo";
            }
            else if (agg_o_mod == 1)
            {
                lblControlBar.Text = "Modificar Detalle de Modelo";
                txtCuenta.Text = cuenta;
                txtDescri.Text = descri;
                txtDebe.Text = debe;
                txtHaber.Text = haber;
                txtConcepto.Text = concepto;
                cbCentrodeCosto.Text = "NINGUNO"; //falta
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string asiento;
            int seleccionado;
            if (agg_o_mod == 0)
            {
                seleccionado = DGV1.CurrentCell.RowIndex;
                asiento = DGV1.Rows[seleccionado].Cells[0].Value.ToString();

                Negocio.Funciones.Contabilidad.FDetalledeModelos.Agregar(this, asiento, txtCuenta.Text, codigo, txtDebe.Text, txtHaber.Text, txtConcepto.Text, cbCentrodeCosto.SelectedText);
            }
            else if (agg_o_mod == 1)
            {
                seleccionado = DGV1.CurrentCell.RowIndex;
                asiento = DGV1.Rows[seleccionado].Cells[0].Value.ToString();

                Negocio.Funciones.Contabilidad.FDetalledeModelos.Modificar(this, asiento, txtCuenta.Text, codigo, txtDebe.Text, txtHaber.Text, txtConcepto.Text, cbCentrodeCosto.SelectedText);
            }
        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarcuenta = new frmBuscarCuenta("Cuenta");
            buscarcuenta.ShowDialog();
            int cuenta = frmBuscarCuenta.IdCuenta;
            if (cuenta != 0)
            {
                txtCuenta.Text = cuenta.ToString();
            }
            frmBuscarCuenta.IdCuenta = 0;
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
    }
}
