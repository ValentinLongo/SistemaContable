using Datos;
using Negocio;
using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Balance_de_Sumas_y_Saldos
{
    public partial class frmBalances_Informes : Form
    {
        private static int Proceso;

        public frmBalances_Informes(int proceso)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo(proceso);
            Proceso = proceso;
        }

        private void Seteo(int proceso) 
        {
            maskDesde.Mask = "00-00-0000";
            maskHasta.Mask = "00-00-0000";
            maskHasta.Text = DateTime.Now.ToShortDateString();

            if (proceso == 1) //Balance de Sumas y Saldos
            {
                Check1.Visible = true;
                lbl1.Visible = true;
                Check1.Location = new Point(101, 158);
                lbl1.Location = new Point(124, 158);

                Check2.Visible = false;
                lbl2.Visible = false;
            }
            else if (proceso == 2) //Balance General
            {
                Check1.Visible = true;
                lbl1.Visible = true;
                Check1.Location = new Point(101, 141);
                lbl1.Location = new Point(124, 141);

                Check2.Visible = true;
                lbl2.Visible = true;
            }
            else if (proceso == 3) //Informes
            {
                Check1.Visible = false;
                lbl1.Visible = false;
                Check2.Visible = false;
                lbl2.Visible = false;

                lblModelo.Visible = true;
                lblModelo.Location = new Point(18, 74);
                txtCodModelo.Visible = true;
                txtCodModelo.Location = new Point(76, 70);
                pModelo1.Visible = true;
                pModelo1.Location = new Point(76, 89);
                txtDescriModelo.Visible = true;
                txtDescriModelo.Location = new Point(158, 71);
                pModelo2.Visible = true;
                pModelo2.Location = new Point(158, 89);
                btnModelo.Visible = true;
                btnModelo.Location = new Point(386, 69);

                label1.Location = new Point(24, 102);
                maskDesde.Location = new Point(77, 104);
                label2.Location = new Point(27, 131);
                maskHasta.Location = new Point(76, 132);

                lbl3.Visible = true;
                Check3.Visible = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodEjercicio.Text != "") //Validacion
            {
                string desde = "";
                string hasta = "";

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT eje_desde, eje hasta FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    desde = dr["eje_desde"].ToString();
                    hasta = dr["eje_hasta"].ToString();
                }

                if (maskDesde.MaskFull) //Validacion
                {
                    if (maskHasta.MaskFull) //Validacion
                    {
                        if (Convert.ToDateTime(maskDesde) >= Convert.ToDateTime(desde)) //Validacion
                        {
                            if (Convert.ToDateTime(maskHasta) <= Convert.ToDateTime(hasta)) //Validacion
                            {
                                int terminal = frmLogin.NumeroTerminal;

                                if (Proceso == 1) //Balance de Sumas y Saldos
                                {

                                    AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");

                                    if (Check1.Checked == false) // Check1 = Visualizar informe con centro de costo
                                    {
                                        
                                    }
                                    else
                                    {
                                        //AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral (bal_terminal, bal_cuenta, bal_saldo, bal_cc) SELECT {terminal}, mva_cuenta, (Sum(Case When mva_codigo = 1 Then mva_importe Else 0 End) - (Case When mva_codigo = 2 Then mva_importe Else 0 End)) as mva_Saldo, IsNull(mva_cc,0) " +
                                        //$"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                                        //$"LEFT JOIN (CentroCxPCuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo) on cxp_cuenta = mva_cuenta AND cxp_centroc = mva_cc " +
                                        //$"WHERE ast_ejercicio = {} GROUP BY mva_cuenta, IsNull (mva_cc,0)");
                                    }
                                }
                                else if (Proceso == 2) //Balance General
                                {
                                    AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");

                                    if (Check1.Checked) // Check1 = Visualizar informe con centro de costo
                                    {
                                        AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral(bal_Terminal, bal_codigo, bal_cuenta, bal_descri, bal_superior, bal_hija, bal_tabulador, bal_saldo, bal_col1, bal_col1D, bal_col2, bal_col2D, bal_col3, bal_col3D, bal_col4, bal_col4D) " +
                                        $" SELECT {terminal}, pcu_codigo, pcu_cuenta, pcu_descri, pcu_superior, pcu_hija, pcu_tabulador, 0, 0, '', 0, '', 0, '', 0, '' FROM PCuenta ORDER BY pcu_codigo");
                                    }                                   
                                }
                                else if (Proceso == 3) //Informes
                                {
                                    
                                }
                            }
                            else
                            {
                                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "La fecha superior, No se encuentra dentro del periordo habilitado del ejercicio", false, true);
                                MessageBox.ShowDialog();
                            }
                        }
                        else
                        {
                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "La fecha inferior, No se encuentra dentro del periordo habilitado del ejercicio", false, true);
                            MessageBox.ShowDialog();
                        }
                    }
                    else
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Indicar la fecha superior.", false);
                        MessageBox.ShowDialog();
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Indicar la fecha inferior.", false);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Seleccionar un Ejercicio Contable.", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnEjercicio_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("eje_codigo as Código, eje_descri as Descripción", "Ejercicio", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodEjercicio.Text = frmConsultaGeneral.codigoCG;
            txtDescriEjercicio.Text = frmConsultaGeneral.descripcionCG;
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("bal_codigo as Código, bal_descri as Descripción", "Balance", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodModelo.Text = frmConsultaGeneral.codigoCG;
            txtDescriModelo.Text = frmConsultaGeneral.descripcionCG;
        }

        private void txtCodEjercicio_TextChanged(object sender, EventArgs e)
        {
            txtDescriEjercicio.Clear();
            maskDesde.Clear();
            maskHasta.Clear();

            if (txtCodEjercicio.Text != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT eje_descri, eje_desde, eje_hasta FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtDescriEjercicio.Text = dr["eje_descri"].ToString();
                    maskDesde.Text = dr["eje_desde"].ToString();
                    maskHasta.Text = dr["eje_hasta"].ToString();
                }
            }
        }

        private void Check1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) // Check con CC
        {
            if (Check1.Checked)
            {
                Check2.Checked = false;
            }
        }

        private void Check2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) // Check Rubro Contable
        {
            if (Check2.Checked)
            {
                Check1.Checked = false;
            }
        }

        private void txtCodEjercicio_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
