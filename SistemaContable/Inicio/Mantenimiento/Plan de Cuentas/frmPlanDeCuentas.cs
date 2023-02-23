using Datos;
using Negocio;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Plan_de_Cuentas
{
    public partial class frmPlanDeCuentas : Form
    {
        public static string idCuenta;
        public static bool MostrarControlBar = false;
        public frmPlanDeCuentas()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            if (MostrarControlBar)
            {
                frmConControlBar();
            }

            CargarDGV("");
        }

        private void CargarDGV(string descri)
        {
            dgvCuentas.Rows.Clear();
            string codigo = "";
            int cuenta = 0;
            string descripcion = "";
            string superior = "";
            int hija = 0;
            int tabulador = 0;
            bool ajusta = false;
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.BusquedaCuenta(descri);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                codigo = dr["pcu_codigo"].ToString();
                cuenta = Convert.ToInt32(dr["pcu_cuenta"].ToString());
                descripcion = dr["pcu_descri"].ToString();
                superior = dr["pcu_superior"].ToString();
                hija = Convert.ToInt32(dr["pcu_hija"].ToString());
                tabulador = Convert.ToInt32(dr["pcu_tabulador"].ToString());
                try
                {
                    if (Convert.ToInt32(dr["pcu_ajustainf"].ToString()) == 1)
                    {
                        ajusta = true;
                    }
                }
                catch
                {
                }
                dgvCuentas.Rows.Add(codigo, cuenta, descripcion, superior, hija, tabulador, ajusta);
            }
        }

        private void frmConControlBar()
        {
            ControlBar.Visible = true;
            dgvCuentas.Size = new Size(973, 464);
            dgvCuentas.Location = new Point(12, 92);
            btnAgregar.Location = new Point(992, 92);
            btnModificar.Location = new Point(992, 143);
            btnEliminar.Location = new Point(992, 193);
            btnImprimir.Location = new Point(992, 453);
            btnBuscar.Location = new Point(827, 47);
            ShapeBusqueda.Location = new Point(12, 38);
            lblBusqueda.Location = new Point(21, 29);
            txtDescri.Location = new Point(21, 57);
            tbDescipcion.Location = new Point(212, 13);
            panel2.Location = new Point(115, 72);
            MostrarControlBar = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarDGV(tbDescipcion.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCuenta frmAgregarCuenta = new frmAgregarCuenta();
            frmAgregarCuenta.ShowDialog();
            CargarDGV("");
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                int indice = e.RowIndex;
                idCuenta = dgvCuentas.Rows[indice].Cells[1].Value.ToString();
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarCuenta formModificarCuenta = new frmModificarCuenta();
            formModificarCuenta.ShowDialog();
            CargarDGV("");
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FPlanDeCuentas.eliminarCuenta(idCuenta);
            MessageBox.Show("Eliminado Correctamente");
            CargarDGV("");
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte freporte = new frmReporte("PCuenta", $"{FPlanDeCuentas.query}","", "Plan de Cuentas", "Activos", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }
    }
}
