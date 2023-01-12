using Datos.Modelos;
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
    public partial class frmAgregarAgenda : Form
    {
        public frmAgregarAgenda()
        {
            InitializeComponent();
            llenarCombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void llenarCombo()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaActividad();
            cbActividad.DataSource = ds.Tables[0];
            cbActividad.DisplayMember = "act_descri";
            cbActividad.ValueMember = "act_codigo";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarAgenda_Load(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text  != "" && tbTel.Text != "" && tbDireccion.Text != "")
            {
                MAgenda ag = new MAgenda
                {
                    age_codigo = Convert.ToInt32(lblAct.Text),
                    age_nombre = tbNombre.Text,
                    age_direccion = tbDireccion.Text,
                    age_codpos1 = Convert.ToInt32(tbLocalidad1.Text),
                };
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
