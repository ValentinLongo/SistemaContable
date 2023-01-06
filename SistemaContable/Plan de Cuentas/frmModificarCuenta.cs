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
            ds = Negocio.FPlanDeCuentas.BusquedaCuentaPorCodigo(frmPlanDeCuentas.idCuenta);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
            }
        }
    }
}
