using Datos;
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
                MessageBox.Show("Eliminado Correctamente");
                cargarDatos("");
            }
            catch
            {
                MessageBox.Show("Ocurrio un error");
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void dataAgenda_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            cargarDatos(textBox1.Text);
        }
    }
}
