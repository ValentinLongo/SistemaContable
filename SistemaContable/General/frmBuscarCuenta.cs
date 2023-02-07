using Negocio.Funciones.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    public partial class frmBuscarCuenta : Form
    {
        FConceptosContables data = new FConceptosContables();
        private string Accion;
        public static int IdCuenta;
        public static int IdContrapartida;
        public frmBuscarCuenta(string accion)
        {
            InitializeComponent();
            cargarDGV();
            Accion = accion;
        }

        private void cargarDGV()
        {
            DataSet ds = new DataSet();
            if (checkActivas.Checked == true)
            {
                ds = data.listaCuentasActivas();
                dgvCuentas.DataSource = ds.Tables[0];
            }
            else
            {
                ds = data.listaCuentas();
                dgvCuentas.DataSource = ds.Tables[0];
            }

        }

        private void CambioCheck(object sender, EventArgs e)
        {
            cargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Accion == "Cuenta")
            {
                IdCuenta = (int)dgvCuentas.Rows[e.RowIndex].Cells[1].Value;
            }
            else if(Accion == "Contrapartida")
            {
                IdContrapartida = (int)dgvCuentas.Rows[e.RowIndex].Cells[1].Value;
            }
            
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(IdCuenta > -1)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una cuenta");
            }
        }
    }
}
