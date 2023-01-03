using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Usuarios
{
    public partial class frmSeleccionVendedores : Form
    {
        public static int CodigoVendedor = 0;
        public static string NombreVendedor = "";
        private int indice;
        public frmSeleccionVendedores()
        {
            InitializeComponent();
            cargarDGV();
        }

        private void cargarDGV()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FUsuarios.Vendedores();
            dgvVendedores.DataSource = ds.Tables[0];
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            indice = e.RowIndex;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CodigoVendedor = Convert.ToInt32(dgvVendedores.Rows[indice].Cells[0].Value.ToString());
            NombreVendedor = dgvVendedores.Rows[indice].Cells[1].Value.ToString();
            MessageBox.Show("Vendedor Seleccionado");
            this.Close();
        }
    }
}
