using Bunifu.UI.WinForms;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmAuditoriaInterna : Form
    {
        int AsientoInicial;
        int AsientoFinal;
        int ParConceptoUnico;

        public frmAuditoriaInterna()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo();
        }

        private void Seteo() 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Paramrtro");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["par_conceptounico"] is DBNull)
                {
                    ParConceptoUnico = 0;
                }
                else
                {
                    if (Convert.ToInt32(dr["par_conceptounico"]) == 1)
                    {
                        ParConceptoUnico = 1;
                    }
                    else if (Convert.ToInt32(dr["par_conceptounico"]) == 0)
                    {
                        ParConceptoUnico = 0;
                    }
                }
            }

            maskDesde.Mask = "00/00/0000";
            maskHasta.Mask = "00/00/0000";

            maskHasta.Text = DateTime.Now.ToString();

            ProgressBar.Value = 0;

            foreach (Control Ctrl in this.Controls)
            {
                if (Ctrl is BunifuCheckBox)
                {
                    BunifuCheckBox chk = (BunifuCheckBox)Ctrl;
                    chk.Checked = true;
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int CodOpe = 0;

            int contador = 0;
            foreach (Control Ctrl in this.Controls)
            {
                if (Ctrl is BunifuCheckBox)
                {
                    BunifuCheckBox chk = (BunifuCheckBox)Ctrl;
                    if (chk.Checked == false)
                    {
                        contador++;
                    }
                }
            }

            if (contador == 10)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá indicar al menos un Módulo para Procesar.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (maskDesde.MaskFull == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá indicar una Fecha Inferior.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (maskHasta.MaskFull == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá indicar una Fecha Superior.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Convert.ToDateTime(maskDesde.Text) > Convert.ToDateTime(maskHasta.Text))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Fecha superior del Rango indicado No puede ser menor a la Fecha inferior del Rango.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (txtNroCuenta.Text == "")
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá indicar la Cuenta Contable.", false);
                MessageBox.ShowDialog();
                //Cursor.Current = Cursors.Default;
                return;
            }

            //Cursor.Current = Cursors.WaitCursor;
            //Application.DoEvents();

            //(FALTA UNA PARTE QUE LLAMA A UNA FUNCION)

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AsientoInicial = dr["maximo"] is DBNull ? 1 : Convert.ToInt32(dr["maximo"]);
                break;
            }

            if (checkVta.Checked)
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {txtNroCuenta.Text}");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta Contable ingresada No existe", false, true);
                    MessageBox.ShowDialog();
                    //Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    foreach (DataRow dr2 in ds.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr2["pcu_hija"]) != 0)
                        {
                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta Contable No puede recibir movimientos", false, true);
                            MessageBox.ShowDialog();
                            //Cursor.Current = Cursors.Default;
                            return;
                        }
                    }
                }

                ds = AccesoBase.ListarDatos($"Select * From MovVta Left Join TipMov on vta_tipmov = tmo_codigo Left Join Asiento on vta_tipmov = ast_tipocbte And vta_cpbte = ast_cbte Left Join ConceptoCont on vta_conceptocont = coc_codigo Where LEFT(vta_cliente,7) <> 'ANULADO' And ast_asiento is NULL And (vta_fecpro >= '{maskDesde.Text}' And vta_fecpro <= '{maskHasta.Text}')");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Comprobante de Venta " + i + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["vta_tipmov"]))
                        {
                            case 1: // 1 = factura
                            case 2: // 2 = Nota de Credito 
                            case 3: // 3 = Nota de Debito
                                Proc_CpbteVta();
                                break;

                            case 4: // credito interno
                            case 5: // debito interno
                                Proc_MovIntVta();
                                break;

                            case 9: // liquido producto
                                Proc_LiquiP();
                                break;

                            case 10: // ticket z
                                Proc_CpbteTKVta();
                                break;

                            case 31: // recibo
                                Proc_Recibo();
                                break;

                            case 53: // liquidacion vta
                                Proc_liquiVta();
                                break;

                            default:
                                break;
                        }
                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkCpa.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From MovCpa Left Join Asiento on cpa_tipmov = ast_tipocbte And cpa_nrocomp = ast_cbte And ast_ctapro = cpa_ctapro Where cpa_tipmov <> 16 And LEFT(cpa_nombre,7) <> 'ANULADO' And ast_asiento is NULL And (cpa_feccont >= '{maskDesde.Text}' And cpa_feccont <= '{maskHasta.Text}')");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Comprobante de Compra " + i + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["cpa_tipmov"]))
                        {
                            case 11: // 1 = factura
                            case 12: // 2 = Nota de Credito 
                            case 13: // 3 = Nota de Debito
                                Proc_CPBTECpa();
                                break;

                            case 14: // credito interno
                            case 15: // debito interno
                                Proc_MovIntCpa();
                                break;

                            case 16: // liquidaciones de tc
                                //Proc_LIQTC();
                                break;

                            case 21: // op
                                Proc_OP();
                                break;

                            case 54: // liquidacion cpa
                                Proc_LiquiCpa();
                                break;

                            default:
                                break;
                        }
                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkLiqTC.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join Tarjeta on tcc_tarjeta = tar_codigo Left Join Asiento on ast_tipocbte = 16 And tcc_cpbte = ast_cbte And ast_ctapro = tar_ctapro Left Join MovCpa on tcc_cpbte = cpa_nrocomp And cpa_tipmov = 16 And cpa_ctapro = tar_ctapro Where tcc_tipmov = 2 And ast_asiento is NULL And (tcc_fecha >= '{maskDesde.Text}' And tcc_fecha <= '{maskHasta.Text}')");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Comprobante de Liquidaci�n de Tarjeta " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_LIQTC();

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkMovIntCaja.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From MovimientoCaja Left Join Asiento on (Case When moc_tipmov = 6 Then 42 Else 43 End) = ast_tipocbte And moc_cpbte = ast_cbte Where (moc_tipmov = 54 or moc_tipmov = 6) And moc_total <> 0 And moc_cont = 1 And ast_asiento is NULL And (moc_fecpro >= '{maskDesde.Text}' And moc_fecpro <= '{maskHasta.Text}')");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Movimiento de Caja " + i + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["moc_TIPMOV"]))
                        {
                            case 6: //ING
                                Proc_IngVar();
                                break;

                            case 54: //EGR
                                Proc_EgrVar();
                                break;

                            default:
                                break;
                        }
                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkTrans .Checked)
            {
                ds = AccesoBase.ListarDatos($"Select tra_cajaO, tra_cajaD, tra_tipo, moc_total, moc_caja, moc_tipmov, moc_fecpro, moc_cpbte, moc_cotizacion From TransfCajaV Left Join MovimientoCaja on tra_codigo = moc_codigo And moc_tipmov = 57 Left Join Asiento on ast_tipocbte = moc_tipmov And ast_cbte = moc_cpbte Where ast_asiento is NULL And (moc_fecpro >= '{maskDesde.Text}' And moc_fecpro <= '{maskHasta.Text}') Group By tra_cajaO, tra_cajaD, tra_tipo, moc_total, moc_caja, moc_tipmov, moc_fecpro, moc_cpbte, moc_cotizacion");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Movimiento de Caja " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_Transf();

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkDep.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = ast_cbte Where ast_asiento is NULL And mba_importe <> 0");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Depósito Bancario " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_Dep();

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkDCBan.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select *, Case When dcb_tipo = 1 Then 47 Else 48 End as dcb_tipmov From DebCredBan Left Join Asiento on (Case When dcb_tipo = 1 Then 47 Else 48 End) = ast_tipocbte And dcb_cpbte = ast_cbte Where ast_asiento is NULL ");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Movimiento Bancario " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_DCBan();

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkExtraccion.Checked)
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["par_codExtr"] is DBNull)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No ha sido Definido el C�digo de la Extracci�n Bancaria en los Par�metros.", false, true);
                        MessageBox.ShowDialog();
                        goto salto;
                    }
                    CodOpe = Convert.ToInt32(dr["par_codExtr"]);
                    break;
                }

                ds = AccesoBase.ListarDatos($"Select * From TipMovBan Where tba_codigo = {CodOpe}");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Código de la Extracción Bancaria indicado en los Parámetros No Existe.", false, true);
                    MessageBox.ShowDialog();
                    goto salto;
                }

                ds = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpe} And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpe} And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And mba_cpbte = ast_cbte Where ast_asiento is NULL and mba_importe <> 0");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Extracción Bancaria " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_Extraccion();

                        i += 1;
                    }
                }
            }
            salto:

            ProgressBar.Value = 0;

            if (checkCaucion.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 19 And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 19 And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = RIGHT(('00000000' + ast_cbte),8) Where ast_asiento is NULL And mba_importe <> 0");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Depósito en Caución  " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_Caucion();

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkCaucion.Checked)
            {
                ds = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 19 And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 19 And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = RIGHT(('00000000' + ast_cbte),8) Where ast_asiento is NULL And mba_importe <> 0");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProgressBar.Value = i;

                        lblConteo.Text = "Depósito en Caución  " + i + " de " + ds.Tables[0].Rows.Count;

                        Proc_Caucion();

                        i += 1;
                    }
                }
            }

        }

        private void Proc_LIQTC() 
        {
            //terminar
        }

        private void Proc_Caucion()
        {
            //terminar
        }

        private void Proc_Extraccion()
        {
            //terminar
        }

        private void Proc_DCBan()
        {
            //terminar
        }

        private void Proc_Transf()
        {
            //terminar
        }

        private void Proc_MovIntCpa()
        {
            //terminar
        }

        private void Proc_MovIntCpaBCKP()
        {
            //terminar
        }

        private void Proc_TraB()
        {
            //terminar
        }

        private void Proc_Dep()
        {
            //terminar
        }

        private void Proc_IngVar()
        {
            //terminar
        }

        private void Proc_EgrVar()
        {
            //terminar
        }

        private void Proc_Recibo()
        {
            //terminar
        }

        private void Proc_OP()
        {
            //terminar
        }

        private void Proc_liquiVta()
        {
            //terminar
        }

        private void Proc_CpbteVtaServ()
        {
            //terminar
        }

        private void Proc_CpbteTKVta()
        {
            //terminar
        }

        private void Proc_LiquiPAdm()
        {
            //terminar
        }

        private void Proc_LiquiP()
        {
            //terminar
        }

        //private string CtaIvaD()
        //{
        //terminar
        //}

        private void Proc_CpbteVta()
        {
            //terminar
        }

        private void FormPagVta1()
        {
            //terminar
        }

        private void FormPagVta2()
        {
            //terminar
        }

        private void Proc_MovIntVta()
        {
            //terminar
        }

        private void CtrlDetTot()
        {
            //terminar
        }

        private void Proc_CPBTECpa()
        {
            //terminar
        }

        private void Proc_LiquiCpa()
        {
            //terminar
        }

        private void FormPagCpa()
        {
            //terminar
        }

        //private bool Ctrl()
        //{
            //terminar
        //}

        private void btnCtaCont_Click(object sender, EventArgs e) //para traer la cuenta con su descripción.
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("pcu_cuenta as Cuenta, pcu_descri as Descripción","PCuenta","","","frmAuditoriaInterna");
            frm.ShowDialog();
            txtNroCuenta.Text = frmConsultaGeneral.codigoCG;
            txtDescriCuenta.Text = frmConsultaGeneral.descripcionCG;
        }

        private void txtNroCuenta_TextChanged(object sender, EventArgs e) //para actualizar los txt cuando se ingresa un nro de cuenta.
        {
            if (txtNroCuenta.Text != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {txtNroCuenta.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtDescriCuenta.Text = dr["pcu_descri"].ToString();
                    }
                }
            }
            else
            {
                txtNroCuenta.Text = "";
                txtDescriCuenta.Text = "";
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
