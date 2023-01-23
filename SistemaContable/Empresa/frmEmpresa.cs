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
        public frmEmpresa()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FEmpresa.listaEmpresa();
            dgvEmpresa.DataSource = ds.Tables[0];

            ds = Negocio.FEmpresa.listaSucursales();
            dgvSucursales.DataSource = ds.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarSucursal frmAgregarSucursal = new frmAgregarSucursal();
            frmAgregarSucursal.ShowDialog();
            CargarDGV();
        }
    }
}
