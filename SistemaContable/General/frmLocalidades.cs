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

namespace SistemaContable.General
{
    public partial class frmLocalidades : Form
    {
        public static int CodigoLocalidad;
        public static int SubCodigoLocalidad;
        public static string NombreLocalidad;
        public frmLocalidades()
        {
            InitializeComponent();
            cargarDGV("");
        }

        private void cargarDGV(string codigopostal)
        {
            btnSeleccionar.Enabled = false;
            DataSet ds = ds = AccesoBase.ListarDatos($"SELECT loc_cod1 as Código, loc_cod2 as 'Sub-Código', loc_nombre as Nombre FROM Localidad WHERE loc_cod1 LIKE'%{codigopostal}%'");
            dgvLocalidades.DataSource = ds.Tables[0];
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLocalidades_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSeleccionar.Enabled = true;
            CodigoLocalidad = (int)dgvLocalidades.Rows[e.RowIndex].Cells[0].Value;
            SubCodigoLocalidad = Convert.ToInt32(dgvLocalidades.Rows[e.RowIndex].Cells[1].Value.ToString());
            NombreLocalidad = dgvLocalidades.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargarDGV(textBox1.Text);
        }
    }
}
