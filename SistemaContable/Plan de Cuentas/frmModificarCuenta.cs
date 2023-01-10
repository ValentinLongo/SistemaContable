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

namespace SistemaContable.Plan_de_Cuentas
{
    public partial class frmModificarCuenta : Form
    {
        public frmModificarCuenta()
        {
            InitializeComponent();
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDatos();
        }

        private void CargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.Rubros();
            cbRubro.DataSource = ds.Tables[0];
            cbRubro.DisplayMember = "ruc_descri";
            cbRubro.ValueMember = "ruc_codigo";

            DataSet ds1 = new DataSet();
            ds1 = Negocio.FPlanDeCuentas.BusquedaCuentaPorCuenta(frmPlanDeCuentas.idCuenta);
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                tbCodigo.Text = dr["pcu_codigo"].ToString();
                tbCuenta.Text = dr["pcu_cuenta"].ToString();
                tbDescripcion.Text = dr["pcu_descri"].ToString();
                try
                {
                    string rubrocont = dr["pcu_rubrocont"].ToString();
                    cbRubro.SelectedValue = Convert.ToInt32(rubrocont);
                }
                catch
                {
                    cbRubro.Text = "";
                }
                int estado = Convert.ToInt32(dr["pcu_estado"].ToString());
                cbEstado.SelectedIndex = estado - 1;
            }
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
