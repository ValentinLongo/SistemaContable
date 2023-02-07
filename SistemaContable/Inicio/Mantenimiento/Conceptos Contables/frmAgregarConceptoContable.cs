using Negocio;
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
    public partial class frmAgregarConceptoContable : Form
    {
        private string Accion;
        FConceptosContables data = new FConceptosContables();
        public frmAgregarConceptoContable(string accion)
        {
            InitializeComponent();
            Accion = accion;
            cargarDatos();
        }

        private void cargarDatos()
        {
            if(Accion == "Agregar")
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
            }
            if(Accion == "Modificar")
            {
                tbCodigo.Text = frmConceptosContables.Codigo.ToString();
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Cuenta");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdCuenta);
            if(descripcion != "")
            {
                tbNroCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = descripcion;
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Contrapartida");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdContrapartida);
            if (descripcion != "")
            {
                tbNumContrapartida.Text = frmBuscarCuenta.IdContrapartida.ToString();
                tbDescriContrapartida.Text = descripcion;
            }
        }
    }
}
