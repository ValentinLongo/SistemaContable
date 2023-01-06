using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

            tbCodigo.Mask = "##.##.##.##.##.##";

            tbCuenta.Text = Convert.ToString(Negocio.FPlanDeCuentas.UltimoNumeroCuenta());
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigoElegido = tbCodigo.Text;
            int tabulador = Negocio.FPlanDeCuentas.tabulador(codigoElegido);

            string[] codigo = new string[codigoElegido.Length];
            string[] nuevoCodigo = new string[codigoElegido.Length];
            bool romper = false;
            for (int i = 0; i < codigoElegido.Length; i++)
            {
                if (romper == false)
                {
                    codigo[i] = Convert.ToString(codigoElegido[i]);
                    if (codigo[i] == ",")
                    {
                        nuevoCodigo[i] = ".";
                    }
                    else if (codigo[i] == " ")
                    {
                        romper = true;
                    }
                    else
                    {
                        nuevoCodigo[i] = codigo[i];
                    }
                }
             }
            string CodigoCuenta = "";
            for (int i = 0; i < codigoElegido.Length; i++)
            {
                CodigoCuenta += nuevoCodigo[i];
            }
            int cantidadHijos = Negocio.FPlanDeCuentas.cantidadHijos(CodigoCuenta);
        }
    }
}
