using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDGV("");
        }

        private void cargarDGV(string codigopostal)
        {
            btnSeleccionar.Enabled = false;
            DataSet ds = ds = AccesoBase.ListarDatos($"SELECT loc_cod1 as Código, loc_cod2 as 'Sub-Código', loc_nombre as Nombre FROM Localidad WHERE loc_cod1 LIKE'%{codigopostal}%'");
            dgvLocalidades.DataSource = ds.Tables[0];

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvLocalidades);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLocalidades_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
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

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
