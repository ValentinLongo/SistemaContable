using Datos;
using Negocio;
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
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.DetalledeInformes
{
    public partial class frmDetalledeInformes : Form
    {
        public frmDetalledeInformes()
        {
            InitializeComponent();
            Cargar("");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void Cargar(string txt)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT bal_codigo AS Código, bal_descri AS Descripción FROM Balance {txt} ORDER BY bal_codigo");
            dgvDetalleDeInformes.DataSource = ds.Tables[0];
        }

        private void dgvDetalleDeInformes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            codigo = dgvDetalleDeInformes.Rows[dgvDetalleDeInformes.CurrentRow.Index].Cells[0].Value.ToString();

            if(codigo == string.Empty)
            {
                codigo = "0";
            }
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT det_ctacont as Cuenta, pcu_descri AS Descripción, pcu_centroC AS 'Centro Costos', det_orden AS Orden FROM BalanceDet LEFT JOIN PCuenta ON pcu_cuenta = det_ctacont WHERE det_codigo = {codigo}");
            dgvDetalledeInformesAux.DataSource = ds.Tables[0];
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string txtbusqueda;
            if (CheckInicio.Checked)
            {
                txtbusqueda = "WHERE bal_descri LIKE " + "'" + txtBusqueda.Text + "%'";
            }
            else
            {
                txtbusqueda = "WHERE bal_descri LIKE " + "'%" + txtBusqueda.Text + "%'";
            }
            Cargar(txtbusqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggDetalledeInformes frmAggDetalledeInformes = new frmAggDetalledeInformes(0);
            frmAggDetalledeInformes.ShowDialog();
            Cargar("");
        }
    }
}
