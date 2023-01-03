using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Plan_de_Cuentas
{
    public partial class frmPlanDeCuentas : Form
    {
        public frmPlanDeCuentas()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.ListaCuentas();
            dgvCuentas.DataSource = ds.Tables[0];
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(tbDescipcion.Text != "" && tbDescipcion.Text != null)
            {
                DataSet ds = new DataSet();
                ds = Negocio.FPlanDeCuentas.BusquedaCuenta(tbDescipcion.Text);
                dgvCuentas.DataSource = ds.Tables[0];
            }
            else
            {
                CargarDGV();
            }
        }
    }
}
