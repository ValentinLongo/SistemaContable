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
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmComprarR : Form
    {
        public static bool confirmó = false;

        private int Codigo;

        public frmComprarR(string msgControlBar, int[] Cuentas, double[] Importes, int cod)
        {
            InitializeComponent();

            lblControlBar.Text = msgControlBar;
            Codigo = cod;

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo(Cuentas, Importes);
        }

        private void Seteo(int[] Cuentas, double[] Importes)
        {
            txtNeto.Text = Importes[0].ToString("0.00");
            txtExento.Text = Importes[1].ToString("0.00");
            txtIVA21.Text = Importes[2].ToString("0.00");
            txtIVA27.Text = Importes[3].ToString("0.00");
            txtIVA10.Text = Importes[4].ToString("0.00");
            txtImpInt.Text = Importes[5].ToString("0.00");
            txtRetIVA.Text = Importes[6].ToString("0.00");
            txtRetIIBB.Text = Importes[7].ToString("0.00");
            txtRetGan.Text = Importes[8].ToString("0.00");
            txtPerIVA.Text = Importes[9].ToString("0.00");
            txtPerIIBB.Text = Importes[10].ToString("0.00");
            txtPerGan.Text = Importes[11].ToString("0.00");
            txtMonotributista.Text = Importes[12].ToString("0.00");
            txtOtros.Text = Importes[13].ToString("0.00");
            txtTotal.Text = Importes[14].ToString("0.00");

            txtCtaNeto.Text = Cuentas[0].ToString() == "0" ? "" : Cuentas[0].ToString();
            txtCtaExento.Text = Cuentas[1].ToString() == "0" ? "" : Cuentas[1].ToString();
            txtCtaIVA21.Text = Cuentas[2].ToString() == "0" ? "" : Cuentas[2].ToString();
            txtCtaIVA27.Text = Cuentas[3].ToString() == "0" ? "" : Cuentas[3].ToString();
            txtCtaIVA10.Text = Cuentas[4].ToString() == "0" ? "" : Cuentas[4].ToString();
            txtCtaImpInt.Text = Cuentas[5].ToString() == "0" ? "" : Cuentas[5].ToString();
            txtCtaRetIVA.Text = Cuentas[6].ToString() == "0" ? "" : Cuentas[6].ToString();
            txtCtaRetIIBB.Text = Cuentas[7].ToString() == "0" ? "" : Cuentas[7].ToString();
            txtCtaRetGan.Text = Cuentas[8].ToString() == "0" ? "" : Cuentas[8].ToString();
            txtCtaPerIVA.Text = Cuentas[9].ToString() == "0" ? "" : Cuentas[9].ToString();
            txtCtaPerIIBB.Text = Cuentas[10].ToString() == "0" ? "" : Cuentas[10].ToString();
            txtCtaPerGan.Text = Cuentas[11].ToString() == "0" ? "" : Cuentas[11].ToString();
            txtCtaMonotributista.Text = Cuentas[12].ToString() == "0" ? "" : Cuentas[12].ToString();
            txtCtaOtros.Text = Cuentas[13].ToString() == "0" ? "" : Cuentas[13].ToString();
            txtCtaTotal.Text = Cuentas[14].ToString() == "0" ? "" : Cuentas[14].ToString();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirmó = true;

            //falta una parte (preguntar jp)

            AccesoBase.InsertUpdateDatos($"UPDATE MovCpa set cpa_ctaneto = '{txtCtaNeto.Text}', cpa_ctaexento = '{txtCtaExento.Text}', cpa_ctaiva21 = '{txtCtaIVA21.Text}', cpa_ctaiva27 = '{txtCtaIVA27.Text}', cpa_ctaiva10 = '{txtCtaIVA10.Text}', cpa_ctaimpint = '{txtCtaImpInt.Text}', cpa_ctaretiva = '{txtCtaRetIVA.Text}', cpa_ctaretiibb = '{txtCtaRetIIBB.Text}', cpa_ctaretgan = '{txtCtaRetGan.Text}', cpa_ctaperiva = '{txtCtaPerIVA.Text}', cpa_ctaperiibb = '{txtCtaPerIIBB.Text}', cpa_ctapergan = '{txtCtaPerGan.Text}', cpa_ctamonotributo = '{txtCtaMonotributista.Text}', cpa_ctaotros = '{txtCtaOtros.Text}', cpa_ctacpbte = '{txtCtaTotal.Text}'  Where cpa_codigo = {Codigo}");

            this.Close();
        }

        private void TextChangedCuentas(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text == "")
            {
                txt.Text = "";
                DescriCuenta(txt, "");
                return;
            }

            DataSet ds = new DataSet();
            if (frmBuscarCuenta.ValidacionMovimientos(Convert.ToInt32(txt.Text)))
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {txt.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DescriCuenta(txt, dr["pcu_descri"].ToString());
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No existe.", false);
                    MessageBox.ShowDialog();
                    return;
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                MessageBox.ShowDialog();
                return;
            }
        }

        private void DescriCuenta(TextBox txt, string descri) //para asignarle la descri de la cuenta en el txt correspodiente
        {
            foreach (Control Ctrl in this.Controls)
            {
                if (Ctrl is TextBox)
                {
                    if (Ctrl.Tag.ToString() == "01000")
                    {
                        if (Ctrl.Name == txt.Name + "D")
                        {
                            Ctrl.Text = descri;
                        }
                    }
                }
            }
        }

        private void BtnsBuscarCuenta(object sender, EventArgs e) //para saber en cuales txt guardar la info de frmBuscarCuenta
        {
            Button btn = sender as Button;

            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                switch (btn.Tag.ToString())
                {
                    case "txtCtaNeto":
                        txtCtaNeto.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaExento":
                        txtCtaExento.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaIVA21":
                        txtCtaIVA21.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaIVA27":
                        txtCtaIVA27.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaIVA10":
                        txtCtaIVA10.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaImpInt":
                        txtCtaImpInt.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaRetIVA":
                        txtCtaRetIVA.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaRetIIBB":
                        txtCtaRetIIBB.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaRetGan":
                        txtCtaRetGan.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaPerIVA":
                        txtCtaPerIVA.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaPerIIBB":
                        txtCtaPerIIBB.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaPerGan":
                        txtCtaPerGan.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaMonotributista":
                        txtCtaMonotributista.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaOtros":
                        txtCtaOtros.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    case "txtCtaTotal":
                        txtCtaTotal.Text = frmBuscarCuenta.IdCuenta.ToString();
                        break;
                    default:
                        break;
                }
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

