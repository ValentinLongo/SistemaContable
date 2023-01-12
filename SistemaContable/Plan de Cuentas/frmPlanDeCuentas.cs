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
        public static string idCuenta;
        public frmPlanDeCuentas()
        {
            InitializeComponent();

            Negocio.FGenerales.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
            btnModificar.Enabled = false;
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
                btnModificar.Enabled = false;
                DataSet ds = new DataSet();
                ds = Negocio.FPlanDeCuentas.BusquedaCuenta(tbDescipcion.Text);
                dgvCuentas.DataSource = ds.Tables[0];
            }
            else
            {
                CargarDGV();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCuenta frmAgregarCuenta = new frmAgregarCuenta();
            frmAgregarCuenta.ShowDialog();
            CargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                int indice = e.RowIndex;
                idCuenta = dgvCuentas.Rows[indice].Cells[1].Value.ToString();
            }
            catch
            {
                btnModificar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarCuenta formModificarCuenta = new frmModificarCuenta();
            formModificarCuenta.ShowDialog();
            CargarDGV();
        }

        private void frmPlanDeCuentas_Load(object sender, EventArgs e)
        {

        }

        private void tbDescipcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
