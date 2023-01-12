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
<<<<<<< HEAD
=======
            cargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda();
            frmAgregarAgenda.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaAgenda();
            dataAgenda.DataSource = ds.Tables[0];
>>>>>>> franco
        }
    }
}
