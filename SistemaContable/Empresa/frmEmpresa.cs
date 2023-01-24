using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            dgvSucursales.DataSource = ds.Tables[0];
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
    }
}
