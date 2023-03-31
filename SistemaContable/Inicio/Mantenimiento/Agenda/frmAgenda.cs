using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Agenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Agenda
{
    public partial class frmAgenda : Form
    {
        public static int IdModificar;
        public frmAgenda()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDatos("");
        }

        private void cargarDatos(string Nombre)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaAgenda(Nombre);
            dgvAgenda.DataSource = ds.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda("Agregar");
            frmAgregarAgenda.ShowDialog();
            cargarDatos("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda("Modificar");
            frmAgregarAgenda.ShowDialog();
            cargarDatos("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                AccesoBase.InsertUpdateDatos($"DELETE FROM Agenda WHERE age_codigo = {IdModificar}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Eliminado Correctamente", false);
                MessageBox.ShowDialog();
                cargarDatos("");
            }
            catch
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Ocurrio un error", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            frmImprimirAgenda imprimirAgenda = new frmImprimirAgenda();
            imprimirAgenda.ShowDialog();
        }

        private void dgvAgenda_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                int indice = e.RowIndex;
                IdModificar = Convert.ToInt32(dgvAgenda.Rows[indice].Cells[0].Value.ToString());
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargarDatos(tbDescipcion.Text);
        }
    }
}
