using Datos;
using Negocio;
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

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvCuentas.Rows.Clear();
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.ListaCuentas();
            string codigo = "";
            int cuenta = 0;
            string descripcion = "";
            string superior = "";
            int hija = 0;
            int tabulador = 0;
            bool ajusta = false;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                codigo = dr["pcu_codigo"].ToString();
                cuenta = Convert.ToInt32(dr["pcu_cuenta"].ToString());
                descripcion = dr["pcu_descri"].ToString();
                superior = dr["pcu_superior"].ToString();
                hija = Convert.ToInt32(dr["pcu_hija"].ToString());
                tabulador = Convert.ToInt32(dr["pcu_tabulador"].ToString());
                try
                {
                    if (Convert.ToInt32(dr["pcu_ajustainf"].ToString()) == 1)
                    {
                        ajusta = true;
                    }
                }
                catch
                {

                }
                dgvCuentas.Rows.Add(codigo, cuenta, descripcion, superior, hija, tabulador, ajusta);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbDescipcion.Text != "" && tbDescipcion.Text != null)
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
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
                btnEliminar.Enabled = true;
                int indice = e.RowIndex;
                idCuenta = dgvCuentas.Rows[indice].Cells[1].Value.ToString();
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarCuenta formModificarCuenta = new frmModificarCuenta();
            formModificarCuenta.ShowDialog();
            CargarDGV();
        }

        private void tbDescipcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FPlanDeCuentas.eliminarCuenta(idCuenta);
            MessageBox.Show("Eliminado Correctamente");
            CargarDGV();
        }
    }
}
