using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
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

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmDetMovVarioCajaR : Form
    {
        private static int terminal = frmLogin.NumeroTerminal;

        public static bool confirmó = false;

        private static int Orden;
        public frmDetMovVarioCajaR(Form frm, string cuenta, string descri, string importe, string comentario, string orden, string msgControlBar)
        {
            InitializeComponent();

            lblControlBar.Text = msgControlBar;
            Orden = Convert.ToInt32(orden);

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo(frm, cuenta, descri, importe, comentario);
        }

        private static int CuentaAnterior;
        private static string DescriAnterior;
        private void Seteo(Form frm,string cuenta, string descri, string importe, string comentario)
        {
            if (frm.Name == "frmMovVarioCajaR")
            {
                CuentaAnterior = Convert.ToInt32(cuenta);
                DescriAnterior = descri;

                txtCuenta.Text = cuenta;
                txtDescri.Text = descri;
                txtImporte.Text = importe;
                txtComentario.Text = comentario;

                txtDescri.Enabled = false;
                txtImporte.Enabled = false;
                txtComentario.Enabled = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCuenta.Text == "")
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Cuenta Invalida!", false);
                MessageBox.ShowDialog();
                return;
            }

            if (txtImporte.Text == "" || Convert.ToDouble(txtImporte.Text) == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Importe Invalido!", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Negocio.FPlanDeCuentas.Ctrl_Ctas(txtCuenta.Text,"PROVEEDOR", true) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", Negocio.FPlanDeCuentas.msgRetorno, false, true);
                MessageBox.ShowDialog();
                return;
            }

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from PCuenta where pcu_cuenta = {txtCuenta.Text}");
            if (ds.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta Contable no Existe.", false);
                MessageBox.ShowDialog();
                return;
            }
            else
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["pcu_hija"]) > 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false, true);
                    MessageBox.ShowDialog();
                    return;
                }
            }

            AccesoBase.InsertUpdateDatosMoney($"Update Aux_MovVarioCaja Set aux_cta = {txtCuenta.Text}, aux_descri = '{txtDescri.Text}' where aux_terminal = {terminal} and aux_cta = {CuentaAnterior} and aux_importe = '{"*"}' and aux_comentario = '{txtComentario.Text}' and aux_orden = {Orden}", txtImporte.Text);

            confirmó = true;

            this.Close();
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            timerCuenta.Start();
        }

        private void timerCuenta_Tick(object sender, EventArgs e)
        {
            timerCuenta.Stop();

            if (txtCuenta.Text == "")
            {
                txtCuenta.Text = "";
                txtDescri.Text = "";
                return;
            }

            DataSet ds = new DataSet();
            if (frmBuscarCuenta.ValidacionMovimientos(Convert.ToInt32(txtCuenta.Text)))
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {txtCuenta.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtDescri.Text = dr["pcu_descri"].ToString();
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                MessageBox.ShowDialog();
                return;
            }
        }

        private void btnBuscarEjercicio_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                txtCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                txtDescri.Text = frmBuscarCuenta.DescriCuenta;
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
