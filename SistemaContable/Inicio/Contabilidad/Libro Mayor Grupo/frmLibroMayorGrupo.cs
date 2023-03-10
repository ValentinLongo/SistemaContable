using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Grupo
{
    public partial class frmLibroMayorGrupo : Form
    {
        public frmLibroMayorGrupo()
        {
            InitializeComponent();
        }

        private void btnBuscarEjercicio_Click(object sender, EventArgs e)
        {
            frmBuscarEjercicioContable buscarEjercicioContable = new frmBuscarEjercicioContable();
            buscarEjercicioContable.ShowDialog();
            if (frmBuscarEjercicioContable.idEjercicioSelec > 0)
            {
                tbIdEjercicio.Text = frmBuscarEjercicioContable.idEjercicioSelec.ToString();
                tbDescriEjercicio.Text = frmBuscarEjercicioContable.descriEjercicioSelec;
            }
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                tbIdCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = frmBuscarCuenta.DescriCuenta;
            }
        }

        private void btnBuscarCuenta2_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                tbIdCuenta2.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta2.Text = frmBuscarCuenta.DescriCuenta;
            }
        }
    }
}
