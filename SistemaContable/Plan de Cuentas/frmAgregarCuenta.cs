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
    public partial class frmAgregarCuenta : Form
    {
        public frmAgregarCuenta()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.Rubros();
            cbRubro.DataSource = ds.Tables[0];
            cbRubro.DisplayMember = "ruc_descri";
            cbRubro.ValueMember = "ruc_codigo";

            tbCodigo.Mask = "##.##.##.##.##";

            tbCuenta.Text = Convert.ToString(Negocio.FPlanDeCuentas.UltimoNumeroCuenta());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigoElegido = tbCodigo.Text;
            string[] cod = new string[codigoElegido.Length];

            for(int i = 0; i < codigoElegido.Length; i++)
            {
                cod[i] = Convert.ToString(codigoElegido[i]);
            }
        }
    }
}
