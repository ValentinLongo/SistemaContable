using Datos;
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

        public static string Codigo;

        public static bool flag = true; //para repetir la carga de detalles y que se valla actualizando el dgv

        public frmDetalledeModelos()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV1("");
            cbBusqueda.SelectedIndex = 0;
        }

        public void CargarDGV1(string busqueda) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mod_codigo as Codigo, mod_descri as Descripción FROM ModeloEncab {busqueda} ORDER BY mod_codigo");
            dgvDetDeMod1.DataSource = ds.Tables[0];
        }

        public void CargarDGV2() 
        {
            int seleccion = dgvDetDeMod1.CurrentCell.RowIndex;
            string asiento;

            if (seleccion > -1)
            {
                asiento = dgvDetDeMod1.Rows[seleccion].Cells[0].Value.ToString();
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT det_cuenta as Cuenta, pcu_descri as Descripción, det_importe as Debe, det_importe as Haber, det_comenta as Concepto, det_codigo, det_fecha FROM ModeloEncab " +
                    $"LEFT JOIN ModeloDet on ModeloEncab.mod_codigo = ModeloDet.det_asiento " +
                    $"LEFT JOIN PCuenta on Modelodet.det_cuenta = PCuenta.pcu_cuenta WHERE det_asiento = '{asiento}'");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string debe = "0,0000";
                    string haber = "0,0000";
                    string cuenta = dr["Cuenta"].ToString();
                    string descripcion = dr["Descripción"].ToString();
                    string concepto = dr["Concepto"].ToString();

                    string centrodecosto = "";

                    DataSet ds2 = new DataSet();
                    ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta LEFT JOIN CentroCxPCuenta on pcu_cuenta = cxp_cuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo WHERE pcu_cuenta = '{cuenta}'");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        centrodecosto = dr2["cec_descri"].ToString();
                    }

                    if (Convert.ToInt32(dr["det_codigo"]) == 1)
                    {
                        debe = dr["Debe"].ToString();
                        dgvDetDeMod2.Rows.Add(cuenta, descripcion, debe, haber, concepto, centrodecosto,"1", asiento);
                    }
                    else if (Convert.ToInt32(dr["det_codigo"]) == 2)
                    {
                        haber = dr["Haber"].ToString();
                        dgvDetDeMod2.Rows.Add(cuenta, descripcion, debe, haber, concepto, centrodecosto,"2", asiento);
                    }
                }
            }

            Negocio.FGenerales.CantElementos(lblCantElementos,dgvDetDeMod2);
        }

        private void dgvDetDeMod1_SelectionChanged_1(object sender, EventArgs e)
        {
            dgvDetDeMod2.Rows.Clear();
            CargarDGV2();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = "";
            if (cbBusqueda.Text == "Codigo")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "mod_codigo");
            }
            else if (cbBusqueda.Text == "Descripcion")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "mod_descri");
            }
            CargarDGV1(busqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            while (flag)
            {
                frmAddModDetdeModelos frmAddModDetdeModelos = new frmAddModDetdeModelos(0, "", "", "", "", "", "");

                frmAddModDetdeModelos.DGV1 = dgvDetDeMod1;
                frmAddModDetdeModelos.DGV2 = dgvDetDeMod2;
                frmAddModDetdeModelos.ShowDialog();
                dgvDetDeMod2.Rows.Clear();
                CargarDGV2();
            }
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
            int seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Eliminar el concepto para este modelo?", true);
                MessageBox.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    int cuenta = Convert.ToInt32(dgvDetDeMod2.Rows[seleccionado].Cells[0].Value);
                    string concepto = dgvDetDeMod2.Rows[seleccionado].Cells[4].Value.ToString();
                    int codigo = Convert.ToInt32(dgvDetDeMod2.Rows[seleccionado].Cells[6].Value);
                    int asiento = Convert.ToInt32(dgvDetDeMod2.Rows[seleccionado].Cells[7].Value);

                    string importe = "";
                    if (codigo == 1)
                    {
                        importe = dgvDetDeMod2.Rows[seleccionado].Cells[2].Value.ToString();
                    }
                    else if (codigo == 2) 
                    {
                        importe = dgvDetDeMod2.Rows[seleccionado].Cells[3].Value.ToString();
                    }

                    AccesoBase.InsertUpdateDatosMoney($"DELETE FROM ModeloDet WHERE det_asiento = {asiento} AND det_cuenta = {cuenta} AND det_codigo = {codigo} AND det_importe = {"*"} AND det_comenta = '{concepto}'", importe);
                    dgvDetDeMod2.Rows.Clear();
                    CargarDGV2();
                }
            }
        }

        private void dgvDetDeMod2_SelectionChanged_1(object sender, EventArgs e)
        {
            int seleccionado = dgvDetDeMod2.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                cuenta = dgvDetDeMod2.Rows[seleccionado].Cells[0].Value.ToString();
                descri = dgvDetDeMod2.Rows[seleccionado].Cells[1].Value.ToString();
                debe = dgvDetDeMod2.Rows[seleccionado].Cells[2].Value.ToString();
                haber = dgvDetDeMod2.Rows[seleccionado].Cells[3].Value.ToString();
                concepto = dgvDetDeMod2.Rows[seleccionado].Cells[4].Value.ToString();
                centrodecosto = dgvDetDeMod2.Rows[seleccionado].Cells[5].Value.ToString();
                Codigo = dgvDetDeMod2.Rows[seleccionado].Cells[6].Value.ToString();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int seleccionadoDGV2 = dgvDetDeMod2.CurrentCell.RowIndex;
            if (seleccionadoDGV2 != -1) 
            {
                int seleccionadoDGV1 = dgvDetDeMod1.CurrentCell.RowIndex;
                string mod_descri = dgvDetDeMod1.Rows[seleccionadoDGV1].Cells[1].Value.ToString();

                string query = "Select *, Case When det_codigo = 1 Then det_importe Else 0 End as det_debe, Case When det_codigo = 2 Then det_importe Else 0 End as det_haber From ModeloDet Left Join Pcuenta on det_cuenta = pcu_cuenta Left Join ModeloEncab on mod_codigo = det_asiento Order By mod_codigo, det_codigo";

                frmReporte freporte = new frmReporte("ModeloDet", $"{query}", "", "Informe de Detalle de Modelos", mod_descri, DateTime.Now.ToString("d"));
                freporte.ShowDialog();
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
