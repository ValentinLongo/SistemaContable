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
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos
{
    public partial class frmDetalledeModelos : Form
    {
        private static string cuenta;
        private static string descri;
        private static string debe;
        private static string haber;
        private static string concepto;
        private static string centrodecosto;
        public frmDetalledeModelos()
        {
            InitializeComponent();

            CargarDGV1("");
            cbBusqueda.SelectedIndex = 0;
        }

        public void CargarDGV1(string txt) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mod_codigo as Codigo, mod_descri as Descripción FROM ModeloEncab {txt} ORDER BY mod_codigo");
            dgvDetDeMod1.DataSource = ds.Tables[0];
        }
        public void CargarDGV2() 
        {
            int seleccion = dgvDetDeMod1.CurrentCell.RowIndex;
            string codigo;
            if (seleccion > -1)
            {
                codigo = dgvDetDeMod1.Rows[seleccion].Cells[0].Value.ToString();
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT det_cuenta as Cuenta,pcu_descri as Descripción,det_importe as Debe,det_importe as Haber,det_comenta as Concepto,det_codigo FROM ModeloEncab " +
                    $"LEFT JOIN ModeloDet on ModeloEncab.mod_codigo = ModeloDet.det_asiento " +
                    $"LEFT JOIN PCuenta on Modelodet.det_cuenta = PCuenta.pcu_cuenta WHERE det_asiento = '{codigo}'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string debe = "0,00"; 
                    string haber = "0,00"; 
                    string cuenta = dr[0].ToString();
                    string descripcion = dr[1].ToString();
                    string concepto = dr[4].ToString();
                    string centrodecosto = ""; //falta
                    if (Convert.ToInt32(dr[5]) == 1)
                    {
                        debe = dr[2].ToString();
                        dgvDetDeMod2.Rows.Add(cuenta, descripcion, debe, haber, concepto, centrodecosto);
                    }
                    else if (Convert.ToInt32(dr[5]) == 2)
                    {
                        haber = dr[3].ToString();
                        dgvDetDeMod2.Rows.Add(cuenta, descripcion, debe, haber, concepto, centrodecosto);
                    }
                    frmAddModDetdeModelos.codigo = dr[5].ToString();
                }
            }
        }

        private void dgvDetDeMod1_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetDeMod2.Rows.Clear();
            CargarDGV2();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string txtbusqueda = Negocio.Funciones.Contabilidad.FDetalledeModelos.Busqueda(dgvDetDeMod1,txtBusqueda,cbBusqueda,CheckInicio);
            CargarDGV1(txtbusqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAddModDetdeModelos frmAddModDetdeModelos = new frmAddModDetdeModelos(0,"","","","","","");

            frmAddModDetdeModelos.DGV1 = dgvDetDeMod1;
            frmAddModDetdeModelos.DGV2 = dgvDetDeMod2; 
            frmAddModDetdeModelos.ShowDialog();
            dgvDetDeMod2.Rows.Clear();
            CargarDGV2();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAddModDetdeModelos frmAddModDetdeModelos = new frmAddModDetdeModelos(1,cuenta,descri,debe,haber,concepto,centrodecosto);

            frmAddModDetdeModelos.DGV1 = dgvDetDeMod1;
            frmAddModDetdeModelos.DGV2 = dgvDetDeMod2;
            frmAddModDetdeModelos.ShowDialog();
            dgvDetDeMod2.Rows.Clear();
            CargarDGV2();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

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

        private void dgvDetDeMod2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                frmAddModDetdeModelos.seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
            }
        }

        private void dgvDetDeMod2_SelectionChanged(object sender, EventArgs e)
        {
            int seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                frmAddModDetdeModelos.seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
                cuenta = dgvDetDeMod2.Rows[seleccionado].Cells[0].Value.ToString();
                descri = dgvDetDeMod2.Rows[seleccionado].Cells[1].Value.ToString();
                debe = dgvDetDeMod2.Rows[seleccionado].Cells[2].Value.ToString();
                haber = dgvDetDeMod2.Rows[seleccionado].Cells[3].Value.ToString();
                concepto = dgvDetDeMod2.Rows[seleccionado].Cells[4].Value.ToString();
                centrodecosto = "NINGUNO"; //falta
            }
        }
    }
}
