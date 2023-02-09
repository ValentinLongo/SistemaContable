using Datos.Modelos;
using Negocio;
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

        private void llenarCombo()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaActividad();
            cbActividad.DataSource = ds.Tables[0];
            cbActividad.DisplayMember = "act_descri";
            cbActividad.ValueMember = "act_codigo";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBusLoc_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MAgenda mAgenda = new MAgenda()
            {
                age_codigo = FGenerales.ultimoNumeroID("age_codigi", "Agenda"),
                age_nombre = tbNombre.Text,
                age_direccion = tbDireccion.Text
            };
        }
    }
}
