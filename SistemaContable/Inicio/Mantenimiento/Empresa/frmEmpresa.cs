using Negocio;
using SistemaContable.General;
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

namespace SistemaContable.Empresa
{
    public partial class frmEmpresa : Form
    {
        public static int codigoSucursal;
        public static string descripcionSucursal;
        public frmEmpresa()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            btnModificar.Enabled = false;

            DataSet ds = new DataSet();
            ds = Negocio.FEmpresa.listaEmpresa();
            dgvEmpresa.DataSource = ds.Tables[0];

            ds = Negocio.FEmpresa.listaSucursales();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr["suc_codigo"].ToString();
                string descripcion = dr["suc_descri"].ToString();
                dgvSucursales.Rows.Add(codigo, descripcion);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarSucursal frmAgregarSucursal = new frmAgregarSucursal("Agregar");
            frmAgregarSucursal.ShowDialog();
            CargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarSucursal frmAgregarSucursal = new frmAgregarSucursal("Modificar");
            frmAgregarSucursal.ShowDialog();
            CargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                int indice = e.RowIndex;
                codigoSucursal = Convert.ToInt32(dgvSucursales.Rows[indice].Cells[0].Value.ToString());
                descripcionSucursal = dgvSucursales.Rows[indice].Cells[1].Value.ToString();
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.FEmpresa.eliminarSucursal(codigoSucursal);
            MessageBox.Show("Eliminado Correctamente");
            CargarDGV();
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte reporte = new frmReporte("Sucursal", FEmpresa.querySucursales, "", "Sucursales", "Todas",DateTime.Now.ToString("d"));
            reporte.ShowDialog();
        }
    }
}
