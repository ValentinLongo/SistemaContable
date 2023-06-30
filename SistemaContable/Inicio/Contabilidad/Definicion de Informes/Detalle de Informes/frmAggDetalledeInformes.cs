using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;
using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.DetalledeInformes
{
    public partial class frmAggDetalledeInformes : Form
    {
        private static int Proceso;
        private static int Codigo;

        private static int Orden;
        private static int Cuenta;

        public frmAggDetalledeInformes(int proceso, int orden, [Optional] int cuenta, [Optional] int codigo)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Proceso = proceso;
            Codigo = codigo;
            txtOrden.Text = orden.ToString();

            if(proceso == 0)
            {
                lblControlBar.Text = "Agregar Detalle de Informes";
            }
            else if(proceso == 1) 
            {
                lblControlBar.Text = "Modificar Detalle de Informes";
                txtCuenta.Text = cuenta.ToString();

                Orden = orden;
                Cuenta = cuenta;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                if (Proceso == 0)
                {
                    string cc = cbCentroCostos.SelectedValue.ToString();
                    if (cc == "NINGUNO")
                    {
                        cc = "0";
                    }

                    AccesoBase.InsertUpdateDatos($"INSERT INTO BalanceDet (det_codigo, det_ctacont, det_orden, det_cc) VALUES ({Codigo}, {txtCuenta.Text}, {txtOrden.Text}, {cc})");

                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente!", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                else if(Proceso == 1)
                {
                    string cc = cbCentroCostos.SelectedValue.ToString();
                    if (cc == "NINGUNO")
                    {
                        cc = "0";
                    }

                    AccesoBase.InsertUpdateDatos($"UPDATE BalanceDet SET det_ctacont = {txtCuenta.Text}, det_orden = {txtOrden.Text}, det_cc = {cc} WHERE det_codigo = {Codigo} AND det_ctacont = {Cuenta} AND det_orden = {Orden}");

                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente!", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Cuenta");
            frmBuscarCuenta.ShowDialog();

            int Cuenta = frmBuscarCuenta.IdCuenta;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {Cuenta}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtDescri.Text = dr["pcu_descri"].ToString();
                txtCuenta.Text = Cuenta.ToString();
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            timerCuenta.Start();
        }

        //CONTROLBAR
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void timerCuenta_Tick(object sender, EventArgs e)
        {
            timerCuenta.Stop();

            if (txtCuenta.Text != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT pcu_hija, pcu_descri FROM PCuenta WHERE pcu_cuenta = {txtCuenta.Text}");

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["pcu_hija"]) != 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                    MessageBox.ShowDialog();
                    return;
                }

                txtDescri.Text = ds.Tables[0].Rows[0]["pcu_descri"].ToString();
            }
            else
            {
                txtDescri.Text = "";
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta LEFT JOIN CentroCxPCuenta on pcu_cuenta = cxp_cuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo WHERE pcu_cuenta = '{txtCuenta.Text}' AND cec_codigo is not null");
            if (ds2.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    cbCentroCostos.DataSource = ds2.Tables[0];
                    cbCentroCostos.ValueMember = "cec_codigo";
                    cbCentroCostos.DisplayMember = "cec_descri";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NINGUNO");
                dt.Rows.Add("NINGUNO");
                cbCentroCostos.DataSource = dt;
                cbCentroCostos.ValueMember = "NINGUNO";
                cbCentroCostos.DisplayMember = "NINGUNO";
            }
        }
    }
}
