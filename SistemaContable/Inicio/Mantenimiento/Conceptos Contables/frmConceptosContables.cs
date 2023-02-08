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
    public partial class frmConceptosContables : Form
    {
        public static int Codigo;
        FConceptosContables data = new FConceptosContables();
        public frmConceptosContables()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            DataSet ds = new DataSet();
            ds = data.listaConceptosContables();
            dgvConceptosContables.DataSource = ds.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarConceptoContable frm = new frmAgregarConceptoContable("Agregar");
            frm.ShowDialog();
            CargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            Codigo = (int)dgvConceptosContables.Rows[e.RowIndex].Cells[0].Value;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarConceptoContable frm = new frmAgregarConceptoContable("Modificar");
            frm.ShowDialog();
            CargarDGV();
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = data.busquedaConceptosContables(tbDescripcion.Text);
            dgvConceptosContables.DataSource = ds.Tables[0];
        }
    }
}
