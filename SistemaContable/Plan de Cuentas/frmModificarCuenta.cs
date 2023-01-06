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
    public partial class frmModificarCuenta : Form
    {
        public frmModificarCuenta()
        {
            InitializeComponent();
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDatos();
        }

        private void CargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.Rubros();
            cbRubro.DataSource = ds.Tables[0];
            cbRubro.DisplayMember = "ruc_descri";
            cbRubro.ValueMember = "ruc_codigo";

            DataSet ds1 = new DataSet();
            ds1 = Negocio.FPlanDeCuentas.BusquedaCuentaPorCuenta(frmPlanDeCuentas.idCuenta);
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                tbCodigo.Text = dr["pcu_codigo"].ToString();
                tbCuenta.Text = dr["pcu_cuenta"].ToString();
                tbDescripcion.Text = dr["pcu_descri"].ToString();
                try
                {
                    string rubrocont = dr["pcu_rubrocont"].ToString();
                    cbRubro.SelectedItem = Convert.ToInt32(rubrocont);
                }
                catch
                {
                    cbRubro.Text = "";
                }
            }
        }
    }
}
