using Negocio.Funciones.Mantenimiento;
using SistemaContable.General;
using System;
using System.Collections;
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

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV("");
        }

        private void CargarDGV(string Descri)
        {
            dgvConceptosContables.Rows.Clear();

            DataSet ds = new DataSet();
            ds = data.listaConceptosContables(Descri);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr["coc_codigo"].ToString();
                string descripcion = dr["coc_descri"].ToString();
                dgvConceptosContables.Rows.Add(codigo, descripcion);
            }
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvConceptosContables);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarConceptoContable frm = new frmAgregarConceptoContable("Modificar");
            frm.ShowDialog();
            CargarDGV("");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarConceptoContable frm = new frmAgregarConceptoContable("Agregar");
            frm.ShowDialog();
            CargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                data.eliminarConceptoCont(Codigo);
                CargarDGV("");
            }
        }

        private void btnIntereses_Click(object sender, EventArgs e)
        {
            frmIntereses frm = new frmIntereses(Codigo); //no es el codigo correcto por el evento del dgv (terminar)
            frm.ShowDialog();
        }

        private void dgvConceptosContables_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //btnModificar.Enabled = true;
            //btnEliminar.Enabled = true;
            //int indice = e.RowIndex;
            //Codigo = Convert.ToInt32(dgvConceptosContables.Rows[indice].Cells[0].Value.ToString());
        }

        private void dgvConceptosContables_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConceptosContables.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dgvConceptosContables.SelectedCells[0];

                if (selectedCell.Value != null)
                {
                    Codigo = Convert.ToInt32(selectedCell.Value);
                }
            }
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            CargarDGV(tbDescripcion.Text);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvConceptosContables.Rows.Count == 0)
            {
                return;
            }

            frmReporte freporte = new frmReporte("ConceptoCont", $"", $"{FConceptosContables.query}", "Lista de Conceptos Contables", "General", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }

        private void frmConceptosContables_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}
