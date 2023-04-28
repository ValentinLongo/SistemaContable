using Bunifu.UI.WinForms;
using Datos;
using Negocio;
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
using System.Web.Caching;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmAuditoriaInterna : Form
    {
        int terminal = frmLogin.NumeroTerminal;

        long AsientoInicial;
        long AsientoFinal;
        long ParConceptoUnico;

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
                                Proc_MovIntCpa(ds);
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

                        Proc_LIQTC(ds);

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

            if (checkTrans.Checked)
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

                        Proc_Transf(ds);

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

                        Proc_Dep(ds);

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

                        Proc_DCBan(ds);

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

                        Proc_Extraccion(ds);

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

                        Proc_Caucion(ds);

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

                        Proc_Caucion(ds);

                        i += 1;
                    }
                }
            }

            ProgressBar.Value = 0;

            if (checkTraban.Checked)
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["par_TranBanExt"] is DBNull)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No ha sido Definido el Código de la Transferencia Bancaria en los Parámetros.", false, true);
                        MessageBox.ShowDialog();
                        goto salto2;
                    }
                    CodOpe = Convert.ToInt32(dr["par_TranBanExt"]);
                    break;
                }
            }

            ds = AccesoBase.ListarDatos($"Select * From TipMovBan Where tba_codigo = {CodOpe}");
            if (ds.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Código de la Transferencia Bancaria indicado en los Parámetros No Existe.", false, true);
                MessageBox.ShowDialog();
                goto salto2;
            }

            ds = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpe} And mba_referencia = '' And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpe} And mba_referencia = '' And (mba_fecemi >= '{maskDesde.Text}' And mba_fecemi <= '{maskHasta.Text}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And mba_cpbte = ast_cbte Where ast_asiento is NULL And mba_importe <> 0");
            if (ds.Tables[0].Rows.Count != 0)
            {
                ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ProgressBar.Value = i;

                    lblConteo.Text = "Transferencia Bancaria " + i + " de " + ds.Tables[0].Rows.Count;

                    Proc_TraB(ds);

                    i += 1;
                }
            }
        salto2:

            ProgressBar.Value = 0;

            AccesoBase.InsertUpdateDatos($"Update Asiento Set ast_ejercicio = eje_codigo From Asiento Left Join Ejercicio on eje_desde <= ast_fecha And eje_hasta >= ast_fecha ");

            AccesoBase.InsertUpdateDatos($"Delete From MovAsto Where mva_importe = 0");

            Cursor.Current = Cursors.Default;

            frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: El Proceso finalizó con Exito. Se Generaron los Asientos correspondientes a la numeración desde " + AsientoInicial + " hasta " + AsientoFinal, false, true);
            MessageBox2.ShowDialog();
        }

        private void Proc_LIQTC(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["cpa_cotiz"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_cotiz"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {ds.Tables[0].Rows[0]["tar_ctapro"]} And ast_tipocbte = 16 And ast_cbte = '{ds.Tables[0].Rows[0]["tcc_cpbte"]}'");

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join Tarjeta on tcc_tarjeta = tar_codigo Left Join Caja on tcc_caja = caj_codigo Where tcc_tipmov = 2 And tcc_cpbte = '{ds.Tables[0].Rows[0]["tcc_cpbte"]}' And tar_ctapro = {ds.Tables[0].Rows[0]["tar_ctapro"]}");

                if (ds2.Tables[0].Rows.Count == 0 && ds3.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                int n = 0;
                int d = 1; //debe
                int h = 2; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select * From Tarjeta Left Join CtaBan on tar_banco = cta_banco And tar_sucursal = cta_sucursal And tar_tipcta = cta_tipcta And tar_nrocta = cta_nrocta Left Join (Proveedor Left Join CondIva on prv_iva = iva_codigo) on tar_ctapro = prv_codigo Where tar_codigo = {ds3.Tables[0].Rows[0]["tar_codigo"]}");

                long CtaBan = ds4.Tables[0].Rows[0]["cta_ctacont"] is DBNull ? 0 : Convert.ToInt64(ds4.Tables[0].Rows[0]["cta_ctacont"]);
                long CtaTar = Convert.ToInt64(ds4.Tables[0].Rows[0]["tar_ctacont"]);
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaCheT = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                double total1 = (ds3.Tables[0].Rows[0]["tcc_dto"] is DBNull ? 0 : Convert.ToInt64(ds3.Tables[0].Rows[0]["tcc_dto"])) * cotizacion;

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = ds.Tables[0].Rows[0]["tcc_fecha"].ToString();

                if (Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_formpag"]) == 1) //caja
                {
                    if ((ds3.Tables[0].Rows[0]["tcc_efectivo"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_dto"])) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, {d}, {"*"}, '', 18)", ds3.Tables[0].Rows[0]["tcc_efectivo"] is DBNull ? "0" : ds3.Tables[0].Rows[0]["tcc_efectivo"].ToString());
                    }

                    if ((ds3.Tables[0].Rows[0]["tcc_chet"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_chet"])) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCheT}, {d}, {"*"}, '', 19)", ds3.Tables[0].Rows[0]["tcc_chet"] is DBNull ? "0" : ds3.Tables[0].Rows[0]["tcc_chet"].ToString());
                    }

                    if ((ds3.Tables[0].Rows[0]["tcc_dep"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_dep"])) != 0)
                    {
                        DataSet ds5 = new DataSet();
                        ds5 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And mba_tipmovref = 16 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["pcu_cuenta"]}, {d}, {"*"}, '', 20)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["tot"]) * cotizacion).ToString());
                        }

                        ds5 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And mba_tipmovref = 16 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["pcu_cuenta"]}, {d}, {"*"}, '', 21)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["tot"]) * cotizacion).ToString());
                        }
                    }
                }
                else if (Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_formpag"]) == 2) //banco
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaBan}, {d}, {"*"}, '', 18)", total1.ToString());

                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaTar}, {h}, {"*"}, '', 25)", ds3.Tables[0].Rows[0]["tcc_importe"] is DBNull ? "0" : (Convert.ToDouble(ds3.Tables[0].Rows[0]["tcc_importe"]) * cotizacion).ToString());

                if (ds.Tables[0].Rows[0]["tcc_dto"].ToString() != ds.Tables[0].Rows[0]["tcc_importe"].ToString())
                {
                    if (ds.Tables[0].Rows[0]["cpa_cpaneto"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaneto"] is DBNull) == false) //neto
                    {
                        if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaneto"]}, {d}, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_neto"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaexento"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaexento"] is DBNull) == false) //exento
                    {
                        if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaexento"]}, {d}, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_exento"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaiva21"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva21"] is DBNull) == false) //iva21
                    {
                        if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva21"]}, {d}, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva21"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaiva27"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva27"] is DBNull) == false) //iva27
                    {
                        if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva27"]}, {d}, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva27"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaiva10"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva10"] is DBNull) == false) //iva10
                    {
                        if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva10"]}, {d}, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva10"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaiva4"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva4"] is DBNull) == false) //iva4
                    {
                        if (CtrlDetTot(16, d, fecha, 6, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva4"]}, {d}, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva4"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaiva5"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva5"] is DBNull) == false) //iva5
                    {
                        if (CtrlDetTot(17, d, fecha, 7, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva5"]}, {d}, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva5"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaimpint"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimpint"] is DBNull) == false) //impint
                    {
                        if (CtrlDetTot(14, d, fecha, 8, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaimpint"]}, {d}, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_impint"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaretiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiva"] is DBNull) == false) //retiva
                    {
                        if (CtrlDetTot(7, d, fecha, 9, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretiva"]}, {d}, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiva"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaretiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                    {
                        if (CtrlDetTot(8, d, fecha, 10, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretiibb"]}, {d}, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiibb"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaretgan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretgan"] is DBNull) == false) //retgan
                    {
                        if (CtrlDetTot(9, d, fecha, 11, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretgan"]}, {d}, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaperiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiva"] is DBNull) == false) //periva
                    {
                        if (CtrlDetTot(10, d, fecha, 12, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaperiva"]}, {d}, {"*"}, '', 12)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periva"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaperiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiibb"] is DBNull) == false) //periibb
                    {
                        if (CtrlDetTot(11, d, fecha, 13, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaperiibb"]}, {d}, {"*"}, '', 13)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periibb"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctapergan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctapergan"] is DBNull) == false) //pergan
                    {
                        if (CtrlDetTot(12, d, fecha, 14, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctapergan"]}, {d}, {"*"}, '', 14)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_pergan"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctamonotributo"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                    {
                        if (CtrlDetTot(13, d, fecha, 15, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctamonotributo"]}, {d}, {"*"}, '', 15)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_monotributo"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaotros"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaotros"] is DBNull) == false) //otros
                    {
                        if (CtrlDetTot(15, d, fecha, 16, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaotros"]}, {d}, {"*"}, '', 16)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_otros"]) * cotizacion).ToString());
                        }
                    }

                    if (ds.Tables[0].Rows[0]["cpa_ctaimportacion"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimportacion"] is DBNull) == false) //importacion
                    {
                        if (CtrlDetTot(6, d, fecha, 17, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaimportacion"]}, {d}, {"*"}, '', 17)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_importacion"]) * cotizacion).ToString());
                        }
                    }
                }

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A, B = 0;

                DataSet ds6 = new DataSet();
                ds6 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds6.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds6.Tables[0].Rows[0]["A"]);
                }

                ds6 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds6.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds6.Tables[0].Rows[0]["B"]);
                }

                ds2 = AccesoBase.ListarDatos($"Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt32(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = 16");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'COBRANZA DE TARJETAS {Abreviado} {ds.Tables[0].Rows[0]["tcc_cpbte"]}', 0, 0, 16, '{ds.Tables[0].Rows[0]["tcc_cpbte"]}', {ds.Tables[0].Rows[0]["tar_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asto, '{fecha}' as Fec, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente la Liquidacion de TC " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }                
        }

        private void Proc_Caucion(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["mba_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {ds.Tables[0].Rows[0]["mba_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["mba_caja"]}");

                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds.Tables[0].Rows[0]["mba_banco"]} And cta_sucursal = {ds.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds.Tables[0].Rows[0]["mba_nrocta"]}'");

                long CtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                if ((ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["mba_efectivo"])) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCaja}, 2, {"*"}, '', 1)", ((ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_efectivo"])) * cotizacion).ToString());
                }

                if ((ds.Tables[0].Rows[0]["mba_chet"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["mba_chet"])) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaChet}, 2, {"*"}, '', 1)", ((ds.Tables[0].Rows[0]["mba_chet"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_chet"])) * cotizacion).ToString());
                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaBan}, 1, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_importe"]) * cotizacion).ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', 'DEPOSITO BANCARIO (CAUCION) {ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["mba_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_Extraccion(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["mba_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {ds.Tables[0].Rows[0]["mba_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["mba_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds.Tables[0].Rows[0]["mba_banco"]} And cta_sucursal = {ds.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds.Tables[0].Rows[0]["mba_nrocta"]}'");
                long CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCaja}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_importe"]) * cotizacion).ToString());
                
                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCtaBan}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_importe"]) * cotizacion).ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', 'EXT. BANCARIA {ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["mba_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_DCBan(DataSet ds)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {ds.Tables[0].Rows[0]["dcb_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["dcb_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                long CtaPro = 0;

                ds2 = AccesoBase.ListarDatos($"Select * From MovCpa Where cpa_tipmov = {ds.Tables[0].Rows[0]["dcb_tipmov"]} And cpa_nrocomp = '{ds.Tables[0].Rows[0]["dcb_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    CtaPro = 0;
                }
                else
                {
                    CtaPro = Convert.ToInt64(ds2.Tables[0].Rows[0]["cpa_ctapro"]);
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["dcb_tipmov"]) == 47) //debito
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["dcb_feccont"]}', {ds.Tables[0].Rows[0]["dcb_ctacont"]}, 2, {"*"}, '', 1)", ds.Tables[0].Rows[0]["dcb_total"].ToString());
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Select {terminal}, 1, '{ds.Tables[0].Rows[0]["dcb_feccont"]}', det_ctacont, 1, det_importe, '', 2 From DetDebCredBan Where det_tipo = {ds.Tables[0].Rows[0]["dcb_tipo"]} And det_cpbte = '{ds.Tables[0].Rows[0]["dcb_cpbte"]}'");
                }
                else //credito
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["dcb_feccont"]}', {ds.Tables[0].Rows[0]["dcb_ctacont"]}, 1, {"*"}, '', 1)", ds.Tables[0].Rows[0]["dcb_total"].ToString());
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Select {terminal}, 1, '{ds.Tables[0].Rows[0]["dcb_feccont"]}', det_ctacont, 2, det_importe, '', 2 From DetDebCredBan Where det_tipo = {ds.Tables[0].Rows[0]["dcb_tipo"]} And det_cpbte = '{ds.Tables[0].Rows[0]["dcb_cpbte"]}'");
                }

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds3.Tables[0].Rows[0]["A"]);
                }
                ds3 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds3.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["dcb_feccont"]}', '{(Convert.ToInt32(ds.Tables[0].Rows[0]["dcb_tipo"]) == 1 ? "DEBITO BANCARIO" : "CREDITO BANCARIO")} {ds.Tables[0].Rows[0]["dcb_cpbte"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', {CtaPro}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["dcb_feccont"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["dcb_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }          
        }

        private void Proc_Transf(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["moc_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {ds.Tables[0].Rows[0]["moc_tipmov"]} And RIGHT(('00000000' + ast_cbte),8) = '{ds.Tables[0].Rows[0]["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["tra_cajaO"]}");
                long CtaCajaO = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["tra_cajaD"]}");
                long CtaCajaD = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber
                long Asiento = 0;

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["tra_tipo"]) == 1) // transferencia de valores
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', {CtaCajaD}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_total"]) * cotizacion).ToString());

                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', {CtaCajaO}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_TOTAL"]) * cotizacion).ToString());
                
                    AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                    DataSet ds4 = new DataSet();
                    ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                    }
                    ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                    }
                    if (A != B)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                        MessageBox.ShowDialog();
                    }

                    ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                    Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                    AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', 'TRANSF VALORES {ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, 0, 57, '{ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                    AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["moc_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                }
                else //transferencia de efectivo
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', {CtaCajaD}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_total"]) * cotizacion).ToString());

                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', {CtaCajaO}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_total"]) * cotizacion).ToString());

                    AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                    DataSet ds4 = new DataSet();
                    ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                    }
                    ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                    }
                    if (A != B)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                        MessageBox.ShowDialog();
                    }

                    ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                    Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                    AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', 'TRANSF EFECTIVO {ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, 0, 57, '{ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                    AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["moc_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                }
                
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_MovIntCpa(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["cpa_cotiz"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_cotiz"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And ast_tipocbte = {ds.Tables[0].Rows[0]["cpa_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 14)
                {
                    h = 1;
                    d = 2;
                }
                else
                {
                    h = 2;
                    d = 1;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

                string fecha = ds.Tables[0].Rows[0]["cpa_feccont"].ToString();

                if (ds.Tables[0].Rows[0]["cpa_ctaneto"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaneto"]}, {d}, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_neto"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaexento"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaexento"]}, {d}, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_exento"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva21"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva21"]}, {d}, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva21"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva27"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva27"]}, {d}, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva27"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva10"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaiva10"]}, {d}, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva10"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaimpint"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    if (CtrlDetTot(14, d, fecha, 8, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaimpint"]}, {d}, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_impint"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    if (CtrlDetTot(7, d, fecha, 9, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretiva"]}, {d}, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiva"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    if (CtrlDetTot(8, d, fecha, 10, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretiibb"]}, {d}, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiibb"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretgan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    if (CtrlDetTot(9, d, fecha, 11, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaretgan"]}, {d}, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    if (CtrlDetTot(10, d, fecha, 12, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaperiva"]}, {d}, {"*"}, '', 12)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periva"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    if (CtrlDetTot(11, d, fecha, 13, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaperiibb"]}, {d}, {"*"}, '', 13)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periibb"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctapergan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    if (CtrlDetTot(12, d, fecha, 14, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctapergan"]}, {d}, {"*"}, '', 14)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_pergan"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctamonotributo"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    if (CtrlDetTot(13, d, fecha, 15, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctamonotributo"]}, {d}, {"*"}, '', 15)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_monotributo"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaotros"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    if (CtrlDetTot(15, d, fecha, 16, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaotros"]}, {d}, {"*"}, '', 16)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_otros"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaimportacion"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimportacion"] is DBNull) == false) //importacion
                {
                    if (CtrlDetTot(6, d, fecha, 17, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, {fecha}, {ds.Tables[0].Rows[0]["cpa_ctaimportacion"]}, {d}, {"*"}, '', 17)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_importacion"]) * cotizacion).ToString());
                    }
                }

                //total
                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaProv}, {h}, {"*"}, '', 16)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["cpa_tipmov"]}");
                string Abreviado = ds.Tables[0].Rows[0]["tmo_abrev"].ToString();


                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. CPA. {Abreviado.ToUpper()} {ds.Tables[0].Rows[0]["cpa_nrocomp"]}  -  {ds.Tables[0].Rows[0]["cpa_nombre"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}', {ds.Tables[0].Rows[0]["cpa_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_MovIntCpaBCKP(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["cpa_cotiz"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_cotiz"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And ast_tipocbte = {ds.Tables[0].Rows[0]["cpa_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int n = 1;
                double total = 0;

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 14)
                {
                    h = 1;
                    d = 2;
                }
                else
                {
                    h = 2;
                    d = 1;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', {txtNroCuenta.Text}, {d}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());

                n =+ 1;

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', {CtaProv}, {h}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                ds3 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

                ds3 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["cpa_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', 'REG. CPA. {Abreviado.ToUpper()} {ds.Tables[0].Rows[0]["cpa_nrocomp"]} {ds.Tables[0].Rows[0]["cpa_nombre"]}', 0, 0, {ds.Tables[0].Rows[0]["cpa_tipmov"]}, '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}', {ds.Tables[0].Rows[0]["cpa_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["cpa_feccont"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_TraB(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["mba_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Parametro");
                int CodOpeO = Convert.ToInt32(ds2.Tables[0].Rows[0]["par_TranBanExt"]);
                int CodOpeD = Convert.ToInt32(ds2.Tables[0].Rows[0]["par_TranBanDep"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                ds2 = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpeO} And mba_referencia = '' And mba_cpbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}' UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpeO} And mba_referencia = '' And mba_cpbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}' ) as X Where mba_importe <> 0");

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds2.Tables[0].Rows[0]["mba_banco"]} And cta_sucursal = {ds2.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds2.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds2.Tables[0].Rows[0]["mba_nrocta"]}'");
                long CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds2.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCtaBan}, 1, {"*"}, '', 1)", ds2.Tables[0].Rows[0]["mba_importe"].ToString());

                ds2 = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpeD} And mba_referencia = '' And mba_cpbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}' UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpeD} And mba_referencia = '' And mba_cpbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}' ) as X Where mba_importe <> 0");

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds2.Tables[0].Rows[0]["mba_banco"]}  And cta_sucursal = {ds2.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds2.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds2.Tables[0].Rows[0]["mba_nrocta"]}'");
                CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds2.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCtaBan}, 2, {"*"}, '', 2)", ds2.Tables[0].Rows[0]["mba_importe"].ToString());

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', 'TRANF. BANCARIA {ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, 0, 100, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["mba_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["mba_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_Dep(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["mba_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 1 And ast_cbte = '{ds.Tables[0].Rows[0]["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["mba_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctacont"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds.Tables[0].Rows[0]["mba_banco"]} And cta_sucursal = {ds.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds.Tables[0].Rows[0]["mba_nrocta"]}'");
                long CtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                //pag 1707
                //de aca para abajo
                if ((ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_efectivo"])) != 0)
                {
                    //AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCaja}, 2, {"*"}, '', 1)", );
                }

                if ((ds.Tables[0].Rows[0]["mba_chet"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_chet"])) != 0)
                {

                }

                //AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCaja}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_importe"]) * cotizacion).ToString());

                //AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCtaBan}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_importe"]) * cotizacion).ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
                }
                ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds4.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', 'EXT. BANCARIA {ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["mba_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
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

        private bool CtrlDetTot(int tipo, int debe, string fecha, int orden, long codigo, double cotD)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select * From DetTotCpa Where dcp_tipo = {tipo} And dcp_codigo = {codigo}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["dcp_ctacont"]}, {debe}, {"*"}, '{ds.Tables[0].Rows[0]["dcp_descri"]}', {orden})", (Convert.ToDouble(ds.Tables[0].Rows[0]["dcp_descri"]) * cotD).ToString());
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }       
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
            frmConsultaGeneral frm = new frmConsultaGeneral("pcu_cuenta as Cuenta, pcu_descri as Descripción", "PCuenta", "", "", "frmAuditoriaInterna");
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
