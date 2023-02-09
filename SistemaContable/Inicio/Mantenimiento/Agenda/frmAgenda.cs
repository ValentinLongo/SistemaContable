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
        public frmAgenda()
        {
            InitializeComponent();
            cargarDatos();
        }


        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaAgenda();
            dataAgenda.DataSource = ds.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda();
            frmAgregarAgenda.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {

        }
    }
}
