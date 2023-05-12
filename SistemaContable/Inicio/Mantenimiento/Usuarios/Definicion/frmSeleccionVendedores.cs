using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDGV();
        }

        private void cargarDGV()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FUsuarios.Vendedores();
            dgvVendedores.DataSource = ds.Tables[0];

            Negocio.FGenerales.CantElementos(lblCantElementos,dgvVendedores);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CodigoVendedor = Convert.ToInt32(dgvVendedores.Rows[indice].Cells[0].Value.ToString());
            NombreVendedor = dgvVendedores.Rows[indice].Cells[1].Value.ToString();
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Vendedor Seleccionado", false);
            MessageBox.ShowDialog();
            this.Close();
        }

        private void dgvVendedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = e.RowIndex;
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
