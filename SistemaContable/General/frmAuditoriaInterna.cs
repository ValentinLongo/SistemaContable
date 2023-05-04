﻿using Bunifu.UI.WinForms;
using Datos;
using Negocio;
using SistemaContable.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();

            if (Ctrl() == false)
            {
                Cursor.Current = Cursors.Default;
                return;
            }

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
                    Cursor.Current = Cursors.Default;
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
                            Cursor.Current = Cursors.Default;
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
                                Proc_CpbteVta(ds);
                                break;

                            case 4: // credito interno
                            case 5: // debito interno
                                Proc_MovIntVta(ds);
                                break;

                            case 9: // liquido producto
                                Proc_LiquiP(ds);
                                break;

                            case 10: // ticket z
                                Proc_CpbteTKVta(ds);
                                break;

                            case 31: // recibo
                                Proc_Recibo(ds);
                                break;

                            case 53: // liquidacion vta
                                Proc_liquiVta(ds);
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
                                Proc_CPBTECpa(ds);
                                break;

                            case 14: // credito interno
                            case 15: // debito interno
                                Proc_MovIntCpa(ds);
                                break;

                            case 16: // liquidaciones de tc
                                //Proc_LIQTC();
                                break;

                            case 21: // op
                                Proc_OP(ds);
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
                                Proc_IngVar(ds);
                                break;

                            case 54: //EGR
                                Proc_EgrVar(ds);
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

                n = +1;

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

                if ((ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_efectivo"])) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaCaja}, 2, {"*"}, '', 1)", ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? "0" : (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_efectivo"]) * cotizacion).ToString());
                }

                if ((ds.Tables[0].Rows[0]["mba_chet"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["mba_chet"])) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', {CtaChet}, 2, {"*"}, '', 1)", ds.Tables[0].Rows[0]["mba_efectivo"] is DBNull ? "0" : (Convert.ToDouble(ds.Tables[0].Rows[0]["mba_chet"]) * cotizacion).ToString());
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

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["mba_fecemi"]}', 'DEPOSITO BANCARIO {ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, 0, 1, '{ds.Tables[0].Rows[0]["mba_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["mba_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Depòsito " + ds.Tables[0].Rows[0]["mba_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_IngVar(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["moc_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 42 And ast_cbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["moc_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetBF"]);
                long CtaDeud = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                long CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                if (!(ds.Tables[0].Rows[0]["moc_valores"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_valores"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaChet}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_valores"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["moc_tc"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_tc"]) != 0))
                {
                    ds3 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, Sum(tcc_importe) as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = 42 And tcc_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' Group By tcc_tarjeta, pcu_cuenta");

                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 2)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }

                }

                if (!(ds.Tables[0].Rows[0]["moc_gasto"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_gasto"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 1, {"*"}, '', 3)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["moc_gasto"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["moc_efectivo"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_efectivo"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 1, {"*"}, '', 4)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["moc_efectivo"]) * cotizacion).ToString());
                }

                DataSet ds4 = new DataSet();
                if (!(ds.Tables[0].Rows[0]["moc_retgan"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retgan"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 3 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(ds4.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetGan}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetGan}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["moc_retgan"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retiibb"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retiibb"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 2 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(ds4.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetIIBB}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetIIBB}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retiibb"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retiva"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retiva"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as Tot From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 1 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(ds4.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetIVA}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetIVA}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retiva"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retsuss"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retsuss"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 4 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(ds4.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetSuss}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetSuss}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retsuss"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retBF"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retBF"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 2 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(ds4.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetBF}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaRetBF}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retBF"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_ticket"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_ticket"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 1, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_ticket"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["moc_dep"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_dep"]) != 0))
                {
                    ds4 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 42 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }

                    ds4 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (MovBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 42 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds4.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_vlte"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_vlte"]) != 0 || (ds.Tables[0].Rows[0]["moc_vltc"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_vltc"]) != 0)))
                {
                    double suma = (ds.Tables[0].Rows[0]["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vltc"])) + (ds.Tables[0].Rows[0]["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vlte"]));

                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 2, {"*"}, '', 12)", (suma * cotizacion).ToString());
                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_CC) SELECT {terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', va1_cta, 2, va1_importe * {"*"}, va1_comentario, 12, va1_cc From MovVario Where va1_tipmov = 42 And va1_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' ", cotizacion.ToString());

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds5.Tables[0].Rows[0]["A"]);
                }
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds5.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["moc_TIPMOV"]}");
                string abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["moc_feccont"]}', 'ING. VAR. {ds.Tables[0].Rows[0]["moc_cpbte"]} - {ds.Tables[0].Rows[0]["moc_descri"]}, 0, 0, 42, '{ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["moc_feccont"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Ingreso Vario " + ds.Tables[0].Rows[0]["moc_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_EgrVar(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["moc_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 43 And ast_cbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["moc_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                if (!(ds.Tables[0].Rows[0]["moc_valores"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_valores"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaChet}, 2, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_valores"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_chep"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_chep"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And chp_tipmov = 43 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                    }

                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_efectivo"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_efectivo"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 2, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_efectivo"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retgan"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 2, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retgan"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_dep"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_dep"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());

                        }

                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());

                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_devtc"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_devtc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_refanula = '43 {ds.Tables[0].Rows[0]["moc_cpbte"]}'");

                        if (ds3.Tables[0].Rows.Count != 0)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["tar_ctacont"]}, 2, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_devtc"]) * cotizacion).ToString());
                        }

                    }
                }

                if (((ds.Tables[0].Rows[0]["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vlte"])) + (ds.Tables[0].Rows[0]["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vlte"]))) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {CtaCaja}, 2, {"*"}, '', 6)", ((ds.Tables[0].Rows[0]["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vltc"])) + (ds.Tables[0].Rows[0]["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vlte"]) * cotizacion)).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["moc_tc"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_tc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select tap_nombre, pcu_cuenta, Sum(txo_importe) as total From TarjetaxOP Left Join (TarjetaP Left Join PCuenta on tap_ctacont = pcu_cuenta) on tap_codigo = txo_marca Where txo_ctapro = 0 And txo_nrocomp = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And txo_tipmov = 43 Group By tap_nombre, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                        }
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) SELECT {terminal}, 1, '{ds.Tables[0].Rows[0]["moc_feccont"]}', va1_cta, 1, va1_imrpote * {"*"}, va1_comentario, 7, va1_cc From MovVario Where va1_tipmov = 43 And va1_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' ", cotizacion.ToString());

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
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', 'EGR. VAR. {ds.Tables[0].Rows[0]["moc_cpbte"]} - {ds.Tables[0].Rows[0]["moc_descri"]}', 0, 0, 43, '{ds.Tables[0].Rows[0]["moc_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["moc_feccont"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Egreso Vario " + ds.Tables[0].Rows[0]["moc_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_Recibo(DataSet ds)
        {
            try
            {
                double cotizacion = 0;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_moneda"]) == 1)
                {
                    cotizacion = 1;
                }
                else
                {
                    cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                DataSet ds4 = new DataSet();
                if (Negocio.FGenerales.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {ds.Tables[0].Rows[0]["vta_seccion"]}");
                }

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetBF"]);

                long CtaDeud = 0;
                long CtaAnticipo = 0;
                if (Negocio.FGenerales.FiltroSeccion())
                {
                    if ((ds4.Tables[0].Rows[0]["sec_ctaDeud"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaDeud"])) == 0)
                    {
                        CtaDeud = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        CtaDeud = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaDeud"]);
                    }

                    if ((ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"])) == 0)
                    {
                        CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);
                    }
                    else
                    {
                        CtaAnticipo = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"]);
                    }
                }
                else
                {
                    CtaDeud = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = (Negocio.FGenerales.FechaCont() == false) ? ds.Tables[0].Rows[0]["vta_fecpro"].ToString() : ds.Tables[0].Rows[0]["vta_fecemi"].ToString();

                if (!(ds.Tables[0].Rows[0]["vta_valores"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaChet}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_tc"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_tc"]) != 0))
                {
                    ds3 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, tcc_importe as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = 31 And tcc_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, 'TARJETA DE CREDITO', 2)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_gasto"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 1, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_efectivo"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 1, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) * cotizacion).ToString());
                }

                DataSet ds5 = new DataSet();
                if (!(ds.Tables[0].Rows[0]["vta_retiibb"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["vta_retiibb"]) != 0))
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 2 Group By ret_ctacont");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, 'RETENCION DE IIBB', 6)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetIIBB}, 1, {"*"}, 'RETENCION DE IIBB', 6)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetIIBB}, 1, {"*"}, 'RETENCION DE IIBB', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retiva"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["vta_retiva"]) != 0))
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 1");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, 'RETENCION DE IVA', 7)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetIVA}, 1, {"*"}, 'RETENCION DE IVA', 7)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetIVA}, 1, {"*"}, 'RETENCION DE IVA', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retgan"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["vta_retgan"]) != 0))
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 3");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, 'RETENCION DE GANANCIAS', 22)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetGan}, 1, {"*"}, 'RETENCION DE GANANCIAS', 22)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetGan}, 1, {"*"}, 'RETENCION DE GANANCIAS', 22)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retsuss"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["vta_retsuss"]) != 0))
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 4");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, 'RETENCION SUSS', 8)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetSuss}, 1, {"*"}, 'RETENCION SUSS', 8)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetSuss}, 1, {"*"}, 'RETENCION SUSS', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retBF"] is DBNull && Convert.ToInt32(ds.Tables[0].Rows[0]["vta_retBF"]) != 0))
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 5");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds5.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, 'BONO FISCAL', 9)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetBF}, 1, {"*"}, 'BONO FISCAL', 9)", (Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetBF}, 1, {"*"}, 'BONO FISCAL', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_ticket"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) != 0))
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 1, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_dep"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dep"]) != 0))
                {
                    ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = 31 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 11)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }

                    ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = 31 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 11)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_vlte"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]) != 0 || ds.Tables[0].Rows[0]["vta_vltc"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vltc"]) != 0))
                {
                    double Vuelto = 0;

                    ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And chp_tipmov = 31 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 12)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                        Vuelto += (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion);
                    }

                    double suma = (ds.Tables[0].Rows[0]["vta_vltc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vltc"])) + (ds.Tables[0].Rows[0]["vta_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]));
                    suma += (-Vuelto);

                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 2, {"*"}, '', 13)", (suma * cotizacion).ToString());
                }

                double Anticipo = 0;
                int n = 12;

                DataSet ds6 = new DataSet();
                if (ParConceptoUnico == 0)
                {
                    ds6 = AccesoBase.ListarDatos($"Select Sum(cta_total) as cta_total From MovCtaCteVta Where (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                    if (ds6.Tables[0].Rows.Count != 0)
                    {
                        if ((ds.Tables[0].Rows[0]["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_moneda2"])) == 1)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAnticipo}, 2, {"*"}, '', {n})", (ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"])).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]);
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAnticipo}, 2, {"*"}, '', {n})", (ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                        }
                    }

                    n += 1;

                    ds6 = AccesoBase.ListarDatos($"Select (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End) as rbo_contrap, Sum(cta_total) as pago From MovCtaCteVta Left Join (MovVta Left Join Seccion on vta_seccion = sec_codigo) on (CONVERT(VARCHAR,vta_tipmov) + vta_cpbte) = left(cta_referencia,14) And cta_ctacli = vta_ctacli Where Not (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End)");
                    foreach (DataRow dr6 in ds.Tables[0].Rows)
                    {
                        long contrap = Convert.ToInt64(ds6.Tables[0].Rows[0]["rbo_contrap"]) == 0 ? CtaDeud : Convert.ToInt64(ds6.Tables[0].Rows[0]["rbo_contrap"]);
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {contrap}, 2, {" * "}, '', {n})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"])).ToString());
                        n += 1;
                    }
                }
                else
                {
                    int cc = 0;

                    ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join MovVta on LEFT(cta_referencia,1) = vta_tipmov And SUBSTRING(cta_referencia,2,14) = vta_cpbte And cta_ctacli = vta_ctacli Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on vta_conceptocont = coc_codigo Where cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And not (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                    foreach (DataRow dr6 in ds6.Tables[0].Rows)
                    {
                        cc = dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"]);
                        if ((ds.Tables[0].Rows[0]["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_moneda2"])) == 1)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {ds6.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', {n}, {cc})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"])).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]);
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {ds6.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', {n}, {cc})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"]) * cotizacion).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                        }
                        n += 1;
                    }

                    long CtaAUsar = 0;

                    ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on cta_conceptocont = coc_codigo Where cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                    foreach (DataRow dr6 in ds6.Tables[0].Rows)
                    {
                        cc = dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"]);
                        if (Negocio.FGenerales.ConceptoACuenta() == false)
                        {
                            CtaAUsar = CtaAnticipo;
                        }
                        else
                        {
                            CtaAUsar = ds6.Tables[0].Rows[0]["pcu_cuenta"] is DBNull ? CtaAnticipo : Convert.ToInt64(ds6.Tables[0].Rows[0]["pcu_cuenta"]);
                        }

                        if ((ds.Tables[0].Rows[0]["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_moneda2"])) == 1)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {CtaAUsar}, 2, {"*"}, '', {n}, {cc})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"])).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]);
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {CtaAUsar}, 2, {"*"}, '', {n}, {cc})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"]) * cotizacion).ToString());
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                        }
                        n += 1;
                    }
                }

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds7 = new DataSet();
                ds7 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds7.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds7.Tables[0].Rows[0]["A"]);
                }
                ds7 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds7.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds7.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 's/RE {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Recibo " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_OP(DataSet ds)
        {
            try
            {
                double cotizacion = 0;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_moneda"]) == 1)
                {
                    cotizacion = 1;
                }
                else
                {
                    cotizacion = ds.Tables[0].Rows[0]["cpa_cotiz"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_cotiz"]);
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And ast_tipocbte = '{ds.Tables[0].Rows[0]["cpa_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaBF = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretBFP"]);
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);
                long CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoCpa"]);

                AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_Asiento WHERE aux_terminal = {terminal}");

                string fecha = Negocio.FGenerales.FechaCont() == false ? ds.Tables[0].Rows[0]["cpa_feccont"].ToString() : ds.Tables[0].Rows[0]["cpa_feccpbte"].ToString();

                if (!(ds.Tables[0].Rows[0]["cpa_feccont"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottercero"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaChet}, 2, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottercero"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottc"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select tap_nombre, pcu_cuenta, Sum(txo_importe) as total From TarjetaxOP Left Join (TarjetaP Left Join PCuenta on tap_ctacont = pcu_cuenta) on tap_codigo = txo_marca Where txo_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And txo_nrocomp = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And txo_tipmov = 21 ");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 20)", ds3.Tables[0].Rows[0]["total"].ToString());
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_totpropio"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totpropio"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And chp_tipmov = 21 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_totefectivo"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totefectivo"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 2, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totefectivo"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaRetGan}, 2, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_retBF"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retBF"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaBF}, 2, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retBF"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottransf"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottransf"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And mba_tipmovref = 21 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                        }

                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And mba_tipmovref = 21 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                        }
                    }
                }

                if (((ds.Tables[0].Rows[0]["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvuelto"])) + (ds.Tables[0].Rows[0]["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvueltoC"]))) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 1, {"*"}, '', 6)", ((ds.Tables[0].Rows[0]["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvuelto"])) + (ds.Tables[0].Rows[0]["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvueltoC"])) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottickets"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottickets"]) != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaCaja}, 2, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottickets"]) * cotizacion).ToString());
                    }
                }

                double Anticipo = 0;

                ds3 = AccesoBase.ListarDatos($"Select * From MovCtaCte Where cta_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And cta_tipmov = 21 And cta_nrocomp = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And (IsNull(cta_referencia,'') = '' or IsNull(cta_referencia,'') = 'A CUENTA')");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    Anticipo = Convert.ToDouble(ds3.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAnticipo}, 1, {"*"}, '', 6)", Anticipo.ToString());
                }

                ds3 = AccesoBase.ListarDatos("Select par_AstoCtaProvOP From Parametro");
                if ((ds3.Tables[0].Rows[0]["par_AstoCtaProvOP"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["par_AstoCtaProvOP"])) == 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaProv}, 1, {"*"}, '', 6)", ((Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) - Anticipo) * cotizacion).ToString());
                }
                else
                {
                    long CtaAux = 0;

                    ds3 = AccesoBase.ListarDatos($"Select cpa_ctacpbte, Sum(cta_total) as total From MovCtaCte Left Join MovCpa on cpa_ctapro = cta_ctapro And CONVERT(VARCHAR,cpa_tipmov) = left(cta_referencia,2) And cpa_nrocomp = SUBSTRING(cta_referencia,3,14) Where cta_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And cta_tipmov = 21 And cta_nrocomp = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And not (IsNull(cta_referencia,'') = '' or IsNull(cta_referencia,'') = 'A CUENTA') Group By cpa_ctacpbte");
                    foreach (DataRow dr3 in ds.Tables[0].Rows)
                    {
                        if ((ds3.Tables[0].Rows[0]["cpa_ctacpbte"] is DBNull ? "" : ds3.Tables[0].Rows[0]["cpa_ctacpbte"].ToString()) == "")
                        {
                            CtaAux = CtaProv;
                        }
                        else
                        {
                            if (Convert.ToDouble(ds3.Tables[0].Rows[0]["cpa_ctacpbte"]) == 0)
                            {
                                CtaAux = CtaProv;
                            }
                            else
                            {
                                CtaAux = Convert.ToInt64(ds3.Tables[0].Rows[0]["cpa_ctacpbte"]);
                            }
                        }
                    }
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAux}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                }

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

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["tmo_codigo"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 's/OP {ds.Tables[0].Rows[0]["cpa_nrocomp"]} - {ds.Tables[0].Rows[0]["cpa_nombre"]}', 0, 0, {ds.Tables[0].Rows[0]["cpa_tipmov"]} , '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}', {ds.Tables[0].Rows[0]["cpa_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente a la Orden de Pago " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_liquiVta(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0 || Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) == 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["tmo_ctrl"]) == 1)
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
                ds3 = AccesoBase.ListarDatos($"Select * From DetCtaContVta Where dcc_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]}");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = Negocio.FGenerales.FechaCont() == false ? ds.Tables[0].Rows[0]["vta_fecpro"].ToString() : ds.Tables[0].Rows[0]["vta_fecemi"].ToString();

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto21"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto1"]}, {d}, {"*"}, '', 1)", ds.Tables[0].Rows[0]["vta_neto21"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto27"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto3"]}, {d}, {"*"}, '', 16)", ds.Tables[0].Rows[0]["vta_neto27"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto10"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto2"]}, {d}, {"*"}, '', 17)", ds.Tables[0].Rows[0]["vta_neto10"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) > 0) //exento mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaexento"]}, {d}, {"*"}, '', 2)", ds.Tables[0].Rows[0]["vta_exento"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) < 0) //exento menor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaexento"]}, {h}, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva27"]) > 0) //iva27 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva3"]}, {d}, {"*"}, '', 18)", ds.Tables[0].Rows[0]["vta_iva27"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva21"]) > 0) //iva21 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva1"]}, {d}, {"*"}, '', 3)", ds.Tables[0].Rows[0]["vta_iva21"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva10"]) > 0) //iva10 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva2"]}, {d}, {"*"}, '', 4)", ds.Tables[0].Rows[0]["vta_iva10"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaimpint"]}, {d}, {"*"}, '', 5)", ds.Tables[0].Rows[0]["vta_impint"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaimpint"]}, {h}, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva10"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretIVA"]}, {d}, {"*"}, '', 6)", ds.Tables[0].Rows[0]["vta_retiva"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretIVA"]}, {h}, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretIIBB"]}, {d}, {"*"}, '', 7)", ds.Tables[0].Rows[0]["vta_retiibb"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretIIBB"]}, {h}, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretGan"]}, {d}, {"*"}, '', 8)", ds.Tables[0].Rows[0]["vta_retgan"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretGan"]}, {h}, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretSUSS"]}, {d}, {"*"}, '', 9)", ds.Tables[0].Rows[0]["vta_retsuss"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretSUSS"]}, {h}, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretBF"]}, {d}, {"*"}, '', 13)", ds.Tables[0].Rows[0]["vta_retBF"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["dcc_ctaretBF"]}, {h}, {"*"}, '', 13)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) > 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctatotal"]}, {h}, {"*"}, '', 15)", ds.Tables[0].Rows[0]["vta_total"].ToString());
                    }
                }
                else
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["tmo_ctrl"]) == 1) //FACTURA y NOTA DE DEBITO
                    {
                        FormPagVta1(ds);
                    }
                    else //NOTA DE CREDITO
                    {
                        FormPagVta1(ds);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds5.Tables[0].Rows[0]["A"]);
                }
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds5.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_CpbteVtaServ(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"Select * From SysObjects Where SysObjects.name = 'SE_HistoNovedad'");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) == 2)
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
                //falta una parte(3352)
                ds3 = AccesoBase.ListarDatos($"Select cli_codigo, ser_ctacont, coc_cccta, Sum(hin_calculo) as total From SE_HistoNovedad Left Join Cliente on hin_ctacli = cli_codigo Left Join (SE_Servicio Left Join ConceptoCont on ser_conceptocont = coc_codigo) on hin_servicio = ser_codigo Where hin_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And hin_ctacli = {ds.Tables[0].Rows[0]["vta_ctacli"]} And hin_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By cli_codigo, ser_ctacont, coc_cccta");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    Proc_CpbteTKVta(ds);
                    return;
                }

                double total = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {ds3.Tables[0].Rows[0]["con_ctacont"]}, {h}, {"*"}, '', 2)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());

                //falta una parte(3352)
                ds3 = AccesoBase.ListarDatos($"Select cli_codigo, con_ctacont, Sum(hin_calculo) as total From SE_HistoNovedad Left Join Cliente on hin_ctacli = cli_codigo Left Join SE_ConceptoF on hin_concepto = con_codigo And con_servicio = hin_servicio Left Join SE_Servicio on hin_servicio = ser_codigo Where hin_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And hin_ctacli = {ds.Tables[0].Rows[0]["vta_ctacli"]} And hin_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By cli_codigo, con_ctacont");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {ds3.Tables[0].Rows[0]["con_ctacont"]}, {h}, {"*"}, '', 2)", (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                }

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds5.Tables[0].Rows[0]["A"]);
                }
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds5.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["vta_fecemi"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Servicios " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_CpbteTKVta(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0 || Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) == 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) != 2 || Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) == 10)
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
                ds3 = AccesoBase.ListarDatos($"Select * From DetCtaContVta Where dcc_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]}");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = Negocio.FGenerales.FechaCont() == false ? ds.Tables[0].Rows[0]["vta_fecpro"].ToString() : ds.Tables[0].Rows[0]["vta_fecemi"].ToString();

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto21"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto1"]}, {d}, {"*"}, '', 1)", ds.Tables[0].Rows[0]["vta_neto21"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto27"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto3"]}, {d}, {"*"}, '', 16)", ds.Tables[0].Rows[0]["vta_neto27"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_neto10"]) > 0) //monto mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaneto2"]}, {d}, {"*"}, '', 17)", ds.Tables[0].Rows[0]["vta_neto10"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) > 0) //exento mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaexento"]}, {d}, {"*"}, '', 2)", ds.Tables[0].Rows[0]["vta_exento"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) < 0) //exento menor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaexento"]}, {h}, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_exento"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva27"]) > 0) //iva27 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva3"]}, {d}, {"*"}, '', 18)", ds.Tables[0].Rows[0]["vta_iva27"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva21"]) > 0) //iva21 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva1"]}, {d}, {"*"}, '', 3)", ds.Tables[0].Rows[0]["vta_iva21"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva10"]) > 0) //iva10 mayor que cero
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaiva2"]}, {d}, {"*"}, '', 4)", ds.Tables[0].Rows[0]["vta_iva10"].ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]) > 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaimpint"]}, {d}, {"*"}, '', 5)", ds.Tables[0].Rows[0]["vta_impint"].ToString());
                }
                else if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]) < 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctaimpint"]}, {h}, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_iva10"]) * -1).ToString());
                }

                if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) > 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["dcc_ctatotal"]}, {h}, {"*"}, '', 15)", ds.Tables[0].Rows[0]["vta_total"].ToString());
                    }
                }
                else
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["tmo_ctrl"]) == 1) //FACTURA y NOTA DE DEBITO
                    {
                        FormPagVta1(ds);
                    }
                    else //NOTA DE CREDITO
                    {
                        FormPagVta1(ds);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds5.Tables[0].Rows[0]["A"]);
                }
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds5.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_LiquiPAdm(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                double iva1 = 0;
                double neto1 = 0;
                double ImpInt = 0;
                double dto = 0;

                int d = 2;
                int h = 1;

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaIVA10D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva10D"]);
                long CtaIVA21D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva21D"]);
                long CtaIVA27D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva27D"]);
                long CtaNetoVta = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_NetoVtaArti"]);
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaImpIntVta = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaImpIntVta"]);

                long CtaDeuda = 0;
                if (ParConceptoUnico == 0)
                {
                    CtaDeuda = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                }
                else
                {
                    CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                }

                long Contrapartida = 0;
                if (ds.Tables[0].Rows[0]["vta_contrap"] is DBNull || Convert.ToInt32(ds.Tables[0].Rows[0]["vta_contrap"]) == 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                    {
                        Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        Contrapartida = CtaCaja;
                    }
                }

                long CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = Negocio.FGenerales.FechaCont() == false ? ds.Tables[0].Rows[0]["vta_fecpro"].ToString() : ds.Tables[0].Rows[0]["vta_fecemi"].ToString();

                int n = 1;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_iva"]) < 3) //se calcula de los importes neto
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total) As total From MovArticLP Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {(Convert.ToInt32(ds3.Tables[0].Rows[0]["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToDouble(ds3.Tables[0].Rows[0]["his_ctacont"]))}, {h}, {"*"}, '', {n})", Math.Round((neto1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArticLP Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {(Convert.ToInt32(ds3.Tables[0].Rows[0]["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToDouble(ds3.Tables[0].Rows[0]["his_ctacont"]))}, {h}, {"*"}, '', {n})", Math.Round((neto1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select * From CondIva Where iva_codigo = {ds.Tables[0].Rows[0]["vta_iva"]}");

                ds3 = AccesoBase.ListarDatos($"Select his_aliva, Sum(his_total) As Tot From MovArticLP Left Join AliIva on ali_porc = his_aliva Where ali_ctacont is null And his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_aliva");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No han sido Definidas la Cuentas Contables de D�bito Fiscal.", false);
                    MessageBox.ShowDialog();
                    return;
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_iva"]) < 3) //se calcula los importes de iva debito
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_aliva, ali_ctacont, Sum(his_total) As Total From MovArticLP Left Join AliIva on ali_porc = his_aliva Where his_aliva <> 0 And his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_aliva, ali_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2) * (Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]) / 100),2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {Convert.ToInt32(ds3.Tables[0].Rows[0]["ali_ctacont"])}, {h}, {"*"}, '', {n})", Math.Round((iva1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArticLP Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2) * (Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]) / 100),2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {Convert.ToInt32(ds3.Tables[0].Rows[0]["ali_ctacont"])}, {h}, {"*"}, '', {n})", Math.Round((iva1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }

                n += 1;

                ImpInt = ds.Tables[0].Rows[0]["vta_impint"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]);
                if (ImpInt != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaImpIntVta}, {h}, {"*"}, '', {n})", Math.Round((ImpInt * cotizacion), 2).ToString());
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAnticipo}, {d}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                }
                else
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["tmo_ctrl"]) == 1) //factura y nota de debito
                    {
                        FormPagVta1(ds);
                    }
                    else //nota de credito
                    {
                        FormPagVta2(ds);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds5.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]);

                ds5 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds5.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                double A = 0; //debe
                double B = 0; //haber

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
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente Liquido Producto " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_LiquiP(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"Select * From MovArticLP Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]}");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    Proc_LiquiPAdm(ds);
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"Select par_NoAstoLPServ From Parametro");
                if ((ds2.Tables[0].Rows[0]["par_NoAstoLPServ"] is DBNull ? 0 : Convert.ToDouble(ds2.Tables[0].Rows[0]["par_NoAstoLPServ"])) == 1)
                {
                    return;
                }

                int d = 2;
                int h = 1;

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                DataSet ds4 = new DataSet();
                if (Negocio.FGenerales.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {ds.Tables[0].Rows[0]["vta_seccion"]}");
                }


                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaIVA10D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva10D"]);
                long CtaIVA21D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva21D"]);
                long CtaIVA27D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva27D"]);

                long CtaDeuda = 0;
                if (ParConceptoUnico == 0)
                {
                    CtaDeuda = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                }
                else
                {
                    CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                }

                long Contrapartida = 0;
                if (ds.Tables[0].Rows[0]["vta_contrap"] is DBNull || Convert.ToInt32(ds.Tables[0].Rows[0]["vta_contrap"]) == 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                    {
                        Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        Contrapartida = CtaCaja;
                    }
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                int n = 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds.Tables[0].Rows[0]["coc_ctacont"]}, {h}, sum(cel_importe), '', {n} FROM SE_Celular WHERE cel_LP = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");

                n += 1;

                ds3 = AccesoBase.ListarDatos($"Select cel_aliva as Aliva, ali_ctacont, Sum(cel_iva) as iva From SE_Celular Left Join CondIva on iva_codigo = cel_condiva Left Join AliIva on cel_aliva = ali_porc Where cel_LP = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By cel_aliva, ali_ctacont ");
                foreach (DataRow dr3 in ds3.Tables[0].Rows) //se calcula los importes de iva debito
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds.Tables[0].Rows[0]["ali_ctacont"]}, {h}, {"*"}, '', {n})", Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["iva"]),2).ToString());
                    n += 1;
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaDeuda}, {d}, sum(cel_importe + cel_iva), '', {n} FROM SE_Celular WHERE cel_LP = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                }
                else
                {
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, {d}, sum(cel_importe + cel_iva), '', {n} FROM SE_Celular WHERE cel_LP = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                }

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds5.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]);

                ds5 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds5.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds5.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                double A = 0; //debe
                double B = 0; //haber

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
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["vta_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private long CtaIvaD(double Alicuota, long Cuenta, int seccion)
        {
            if (Negocio.FGenerales.FiltroSeccion() == false)
            {
                return Cuenta;
            }

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {seccion}");

            if (Alicuota == 10.5)
            {
                if ((ds.Tables[0].Rows[0]["sec_ctaiva10D"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["sec_ctaiva10D"])) == 0)
                {
                    return Cuenta;
                }
                else
                {
                    return Convert.ToInt64(ds.Tables[0].Rows[0]["sec_ctaiva10D"]);
                }
            }

            if (Alicuota == 21)
            {
                if ((ds.Tables[0].Rows[0]["sec_ctaiva21D"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["sec_ctaiva21D"])) == 0)
                {
                    return Cuenta;
                }
                else
                {
                    return Convert.ToInt64(ds.Tables[0].Rows[0]["sec_ctaiva21D"]);
                }
            }

            if (Alicuota == 27)
            {
                if ((ds.Tables[0].Rows[0]["sec_ctaiva27D"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["sec_ctaiva27D"])) == 0)
                {
                    return Cuenta;
                }
                else
                {
                    return Convert.ToInt64(ds.Tables[0].Rows[0]["sec_ctaiva27D"]);
                }
            }

            if (Alicuota == 0)
            {
                if ((ds.Tables[0].Rows[0]["sec_ctaExento"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["sec_ctaExento"])) == 0)
                {
                    return Cuenta;
                }
                else
                {
                    return Convert.ToInt64(ds.Tables[0].Rows[0]["sec_ctaExento"]);
                }
            }
            return Cuenta;
        }

        private void Proc_CpbteVta(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"SELECT his_ctacont, sum(his_total) as total FROM MovArtic WHERE his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} GROUP BY his_ctacont");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Proc_CpbteVtaServ(ds);
                    return;
                }

                double ImpInt = 0;
                double dto = 0;
                double neto1 = 0;
                double iva1 = 0;

                int d = 0;
                int h = 0;

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) != 2)
                {
                    d = 1;
                    h = 2;
                }
                else
                {
                    d = 2;
                    h = 1;
                }
                

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                DataSet ds4 = new DataSet();
                if (Negocio.FGenerales.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {ds.Tables[0].Rows[0]["vta_seccion"]}");
                }             

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaIVA10D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva10D"]);
                long CtaIVA21D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva21D"]);
                long CtaIVA27D = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaiva27D"]);
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaImpIntVta = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaImpIntVta"]);

                long CtaDeuda = 0;
                long CtaNetoVta = 0;
                long Contrapartida = 0;
                long CtaAnticipo = 0;
                if (Negocio.FGenerales.FiltroSeccion())
                {
                    if (ParConceptoUnico == 0)
                    {
                        if ((ds4.Tables[0].Rows[0]["sec_ctaDeud"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaDeud"])) == 0)
                        {
                            CtaDeuda = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                            CtaNetoVta = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_NetoVtaArti"]);
                        }
                        else
                        {
                            CtaDeuda = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaDeud"]);
                            CtaNetoVta = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_NetoVtaArti"]);
                        }
                    }
                    else
                    {
                        if ((ds4.Tables[0].Rows[0]["sec_ctaDeud"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaDeud"])) == 0)
                        {
                            CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                        }
                        else
                        {
                            CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds4.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds4.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                        }
                    }

                    if (ds.Tables[0].Rows[0]["vta_contrap"] is DBNull || Convert.ToDouble(ds.Tables[0].Rows[0]["vta_contrap"]) == 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                        {
                            if ((ds4.Tables[0].Rows[0]["sec_ctaDeud"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaDeud"])) == 0)
                            {
                                Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                            }
                            else
                            {
                                Contrapartida = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaDeud"]);
                            }
                        }
                        else
                        {
                            Contrapartida = CtaCaja;
                        }
                    }

                    if ((ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"])) == 0)
                    {
                        CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);
                    }
                    else
                    {
                        CtaAnticipo = Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaAnticipoVta"]);
                    }
                }
                else
                {
                    if (ParConceptoUnico == 0)
                    {
                        CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                        CtaNetoVta = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_NetoVtaArti"]);
                    }
                    else
                    {
                            CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds4.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                    }

                    if (ds.Tables[0].Rows[0]["vta_contrap"] is DBNull || Convert.ToDouble(ds.Tables[0].Rows[0]["vta_contrap"]) == 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                        {
                            Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                        }
                        else
                        {
                            Contrapartida = CtaCaja;
                        }
                    }
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                string fecha = "";
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    fecha = ds.Tables[0].Rows[0]["vta_fecemi"].ToString();
                }
                else
                {
                    fecha = ds.Tables[0].Rows[0]["vta_fecpro"].ToString();
                }

                int n = 1;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_iva"]) < 3) //se calcula de los importes neto
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total) As total From MovArticLP Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {(Convert.ToInt32(ds3.Tables[0].Rows[0]["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToDouble(ds3.Tables[0].Rows[0]["his_ctacont"]))}, {h}, {"*"}, '', {n})", Math.Round((neto1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArtic Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {(Convert.ToInt32(ds3.Tables[0].Rows[0]["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToDouble(ds3.Tables[0].Rows[0]["his_ctacont"]))}, {h}, {"*"}, '', {n})", Math.Round((neto1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select * From CondIva Where iva_codigo = {ds.Tables[0].Rows[0]["vta_iva"]}");

                ds3 = AccesoBase.ListarDatos($"Select his_aliva, Sum(his_total) As total From MovArtic Left Join AliIva on ali_porc = his_aliva Where ali_ctacont is null And his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_aliva");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No han sido Definidas la Cuentas Contables de Debito Fiscal.", false);
                    MessageBox.ShowDialog();
                    return;
                }

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_iva"]) < 3) //se calcula los importes de iva debito
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_aliva, ali_ctacont, Sum(his_total) As total From MovArtic Left Join AliIva on ali_porc = his_aliva Where his_aliva <> 0 And his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_aliva, ali_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2) * (Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]) / 100), 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaIvaD(Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]), Convert.ToInt64(ds3.Tables[0].Rows[0]["ali_ctacont"]), Convert.ToInt32(ds.Tables[0].Rows[0]["vta_seccion"]))}, {h}, {"*"}, '', {n})", Math.Round((iva1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArtic Where his_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]), 2) * (ds.Tables[0].Rows[0]["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) - dto, 2) * (Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]) / 100), 2).ToString("N2"));
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaIvaD(Convert.ToDouble(ds3.Tables[0].Rows[0]["his_aliva"]), Convert.ToInt64(ds3.Tables[0].Rows[0]["ali_ctacont"]), Convert.ToInt32(ds.Tables[0].Rows[0]["vta_seccion"]))}, {h}, {"*"}, '', {n})", Math.Round((iva1 * cotizacion), 2).ToString());
                        n += 1;
                    }
                }

                n += 1;

                ImpInt = ds.Tables[0].Rows[0]["vta_impint"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_impint"]);

                if (ImpInt != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaImpIntVta}, {h}, {"*"}, '', {n})", Math.Round((ImpInt * cotizacion), 2).ToString());
                }

                n += 1;

                ds3 = AccesoBase.ListarDatos($"Select otr_ctacont, otr_descri, Sum(otr_importe) as total From HistoOtrosTributosVta Where otr_importe <> 0 and otr_codigo = {ds.Tables[0].Rows[0]["vta_codigo"]} Group By otr_ctacont, otr_descri");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds3.Tables[0].Rows[0]["otr_ctacont"]}, {h}, {"*"}, '{(ds3.Tables[0].Rows[0]["otr_descri"] is DBNull ? "" : ds3.Tables[0].Rows[0]["otr_descri"].ToString()).Substring(0,80)}', {n})", (ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"])).ToString());
                    n += 1;
                }

                double anticipo = 0;

                DataSet ds6 = new DataSet();

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) != 2)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {CtaDeuda}, {d}, {"*"}, '', {n}, {(ds.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["coc_cccta"]))})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                    }
                    else
                    {
                        if (ParConceptoUnico == 0)
                        {
                            anticipo = 0;

                            ds6 = AccesoBase.ListarDatos($"Select Sum(cta_total) as total From MovCtaCteVta Where (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                            if (ds6.Tables[0].Rows.Count != 0)
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {CtaAnticipo}, {d}, {"*"}, '', {n})", ((ds6.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["total"])) * cotizacion).ToString());
                                anticipo = (ds6.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["total"])) * cotizacion;
                            }

                            n += 1;

                            ds6 = AccesoBase.ListarDatos($"Select (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End) as rbo_contrap, Sum(cta_total) as pago From MovCtaCteVta Left Join (MovVta Left Join Seccion on vta_seccion = sec_codigo) on (CONVERT(VARCHAR,vta_tipmov) + vta_cpbte) = left(cta_referencia,14) And cta_ctacli = vta_ctacli Where Not (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End)");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {(Convert.ToInt64(ds6.Tables[0].Rows[0]["rbo_contrap"]) == 0 ? CtaDeuda : Convert.ToInt64(ds6.Tables[0].Rows[0]["rbo_contrap"]))}, {d}, {"*"}, '', {n})", (ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"])).ToString());
                                n += 1;
                            }
                        }
                        else
                        {
                            ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join MovVta on LEFT(cta_referencia,1) = vta_tipmov And SUBSTRING(cta_referencia,2,14) = vta_cpbte And cta_ctacli = vta_ctacli Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on vta_conceptocont = coc_codigo Where cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And not (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {ds6.Tables[0].Rows[0]["pcu_cuenta"]}, {d}, {"*"}, '', {n}, {(ds6.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds6.Tables[0].Rows[0]["coc_cccta"]))})", ((ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"])) * cotizacion).ToString());
                                n += 1;
                            }

                            long CtaAUsar = 0;

                            ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on cta_conceptocont = coc_codigo Where cta_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And cta_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                if (Negocio.FGenerales.ConceptoACuenta() == false)
                                {
                                    CtaAUsar = CtaAnticipo;
                                }
                                else
                                {
                                    CtaAUsar = ds6.Tables[0].Rows[0]["pcu_cuenta"] is DBNull ? CtaAnticipo : Convert.ToInt64(ds6.Tables[0].Rows[0]["pcu_cuenta"]);
                                }
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, 1, '{fecha}', {CtaAUsar}, {d}, {"*"}, '', {n}, {(ds6.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds6.Tables[0].Rows[0]["coc_cccta"]))})", ((ds6.Tables[0].Rows[0]["pago"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["pago"])) * cotizacion).ToString());
                                n += 1;
                            }
                        }

                        AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                    }
                }
                else
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["tmo_ctrl"]) == 1) //factura y nota de debito
                    {
                        FormPagVta1(ds);
                    }
                    else //nota de credito
                    {
                        FormPagVta2(ds);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                DataSet ds7 = new DataSet();
                ds7 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds7.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds7.Tables[0].Rows[0]["total"]);

                ds7 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds7.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds7.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds8 = new DataSet();
                ds8 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds8.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds8.Tables[0].Rows[0]["A"]);
                }
                ds8 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds8.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds8.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. VTA. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{fecha}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_cc From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
        }

        private void FormPagVta1(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds2.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds2 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetBF"]);
                long CtaDeud = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaDeud"]);
                long CtaAnticipo = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaAnticipoVta"]);

                if (!(ds.Tables[0].Rows[0]["vta_valores"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaChet}, 1, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_tc"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_tc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, Sum(tcc_importe) as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And tcc_cpbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By tcc_tarjeta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_gasto"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 1, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_efectivo"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 1, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) * cotizacion).ToString());
                }

                DataSet ds3 = new DataSet();
                if (!(ds.Tables[0].Rows[0]["vta_retgan"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 3 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetGan}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetGan}, 1, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retgan"]) * cotizacion).ToString());
                    }
                }

                if (!(Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) == 1 || Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) == 2))
                {
                    if (!(ds.Tables[0].Rows[0]["vta_retiibb"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 2 Group By ret_ctacont");
                        if (ds3.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr3 in ds3.Tables[0].Rows)
                            {
                                if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                                {
                                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                                }
                                else
                                {
                                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetIIBB}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                                }
                            }
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetIIBB}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiibb"]) * cotizacion).ToString());
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retiva"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 1 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetIVA}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetIVA}, 1, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retiva"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retsuss"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 4 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetSuss}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetSuss}, 1, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retsuss"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retBF"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 5 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetBF}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetBF}, 1, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retBF"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_retmun"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retmun"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And ret_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And ret_tipret = 9 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(ds3.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds3.Tables[0].Rows[0]["ret_ctacont"]}, 1, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetBF}, 1, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                            }
                        }
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaRetBF}, 1, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_retmun"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_ticket"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 1, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_dep"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dep"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = {ds.Tables[0].Rows[0]["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 12)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }

                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = {ds.Tables[0].Rows[0]["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 1, {"*"}, '', 12)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_vlte"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]) != 0) || !(ds.Tables[0].Rows[0]["vta_vltc"] is DBNull && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vltc"]) != 0))
                {
                    double suma = (ds.Tables[0].Rows[0]["vta_vltc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vltc"])) + (ds.Tables[0].Rows[0]["vta_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]));
               
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 2, {"*"}, '', 13)", (suma * cotizacion).ToString());
                }

            }
            catch (Exception)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Error!", false);
                MessageBox.ShowDialog();
            }
        }

        private void FormPagVta2(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds2.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds2 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetBF"]);
                long CtaProv = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaProv"]);

                if (!(ds.Tables[0].Rows[0]["vta_valores"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaChet}, 2, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_valores"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_tc"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_tc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select chp_nroban, chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_tipmov = {ds.Tables[0].Rows[0]["vta_tipmov"]} And chp_ordpag = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' Group By chp_nroban, chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_efectivo"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 2, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_efectivo"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_dep"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_dep"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = {ds.Tables[0].Rows[0]["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }

                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["vta_cpbte"]}' And mba_tipmovref = {ds.Tables[0].Rows[0]["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["pcu_cuenta"]}, 2, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["total"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_devtc"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_devtc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_refanula = '{ds.Tables[0].Rows[0]["vta_tipmov"]}{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {ds2.Tables[0].Rows[0]["tar_ctacont"]}, 2, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_devtc"]) * cotizacion).ToString());
                    }
                }

                if (!(ds.Tables[0].Rows[0]["vta_vlte"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 1, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_vlte"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_ticket"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 2, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_ticket"]) * cotizacion).ToString());
                }

                if (!(ds.Tables[0].Rows[0]["vta_gasto"] is DBNull) && Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecpro"]}', {CtaCaja}, 2, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_gasto"]) * cotizacion).ToString());
                }
            }
            catch (Exception)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Error!", false);
                MessageBox.ShowDialog();
            }
        }

        private void Proc_MovIntVta(DataSet ds)
        {
            try
            {
                double cotizacion = ds.Tables[0].Rows[0]["vta_cotizacion"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["vta_cotizacion"]);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{ds.Tables[0].Rows[0]["vta_tipmov"]}' And ast_cbte = '{ds.Tables[0].Rows[0]["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 0;
                int h = 0;

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_tipmov"]) != 4)
                {
                    d = 1;
                    h = 2;
                }
                else
                {
                    d = 2;
                    h = 1;
                }

                if (ds.Tables[0].Rows[0]["vta_caja"] is DBNull)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");

                long CtaDeuda = 0;
                if (ParConceptoUnico == 0)
                {
                    CtaDeuda = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                }
                else
                {
                    CtaDeuda = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : ds.Tables[0].Rows[0]["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                }

                long Contrapartida = 0;
                if ((ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"])) == 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                    {
                        Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        Contrapartida = CtaCaja;
                    }
                }
                else
                {
                    Contrapartida = ds.Tables[0].Rows[0]["vta_contrap"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["vta_contrap"]);
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                int n = 1;

                if (ParConceptoUnico == 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {Contrapartida}, {h}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                }
                else
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden,cc) values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {ds3.Tables[0].Rows[0]["coc_ctacont"]}, {h}, {"*"}, '', {n}, {(ds3.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["coc_cccta"]))})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                }

                n += 1;

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["vta_formpag"]) == 2)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {CtaDeuda}, {d}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                }
                else
                {
                    AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) values ({terminal}, 1, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', {CtaCaja}, {d}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["vta_total"]) * cotizacion).ToString());
                }

                AccesoBase.InsertUpdateDatos($"UPDATE Aux_Asiento SET aux_importe = Round(aux_importe,2) WHERE aux_terminal = {terminal}");

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                double A = 0; //debe
                double B = 0; //haber

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    A = Convert.ToDouble(ds5.Tables[0].Rows[0]["A"]);
                }
                ds5 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
                if (ds5.Tables[0].Rows.Count != 0)
                {
                    B = Convert.ToDouble(ds5.Tables[0].Rows[0]["B"]);
                }
                if (A != B)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
                    MessageBox.ShowDialog();
                }

                ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["vta_tipmov"]}");
                string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["vta_fecemi"]}', 'REG. VTA. INT. {Abreviado} {ds.Tables[0].Rows[0]["vta_cpbte"]} - {ds.Tables[0].Rows[0]["vta_cliente"]}', 0, 0, {ds.Tables[0].Rows[0]["vta_tipmov"]} , '{ds.Tables[0].Rows[0]["vta_cpbte"]}', 0, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["vta_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                AsientoFinal = Asiento;
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + ds.Tables[0].Rows[0]["vta_cpbte"] + ".", false, true);
                MessageBox.ShowDialog();
            }
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

        private void Proc_CPBTECpa(DataSet ds)
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

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 12)
                {
                    h = 1;
                    d = 2;
                }
                else
                {
                    h = 2;
                    d = 1;
                }

                string fecha = "";
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_condcpa"]) == 2)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_periodo"]) != Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_feccont"].ToString().Substring(0,7)))
                    {
                        fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(0,2)), Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Length - 4) + "/" + ds.Tables[0].Rows[0]["cpa_periodo"]));
                    }
                    else
                    {
                        fecha = ds.Tables[0].Rows[0]["cpa_feccont"].ToString();
                    }
                }
                else
                {
                    fecha = ds.Tables[0].Rows[0]["cpa_fecha"].ToString();
                }

                AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

                if (ds.Tables[0].Rows[0]["cpa_ctaneto"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaneto"]}, {d}, {"*"}, '', 1)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_neto"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaexento"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaexento"]}, {d}, {"*"}, '', 2)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_exento"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva21"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaiva21"]}, {d}, {"*"}, '', 3)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva21"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva27"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaiva27"]}, {d}, {"*"}, '', 4)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva27"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva10"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaiva10"]}, {d}, {"*"}, '', 5)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva10"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva4"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva4"] is DBNull) == false) //iva4
                {
                    if (CtrlDetTot(16, d, fecha, 6, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaiva4"]}, {d}, {"*"}, '', 6)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva4"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva5"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaiva5"] is DBNull) == false) //iva5
                {
                    if (CtrlDetTot(17, d, fecha, 7, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaiva5"]}, {d}, {"*"}, '', 7)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva5"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaimpint"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    if (CtrlDetTot(14, d, fecha, 8, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaimpint"]}, {d}, {"*"}, '', 8)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_impint"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    if (CtrlDetTot(7, d, fecha, 9, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaretiva"]}, {d}, {"*"}, '', 9)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiva"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    if (CtrlDetTot(8, d, fecha, 10, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaretiibb"]}, {d}, {"*"}, '', 10)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiibb"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretgan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    if (CtrlDetTot(9, d, fecha, 11, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaretgan"]}, {d}, {"*"}, '', 11)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiva"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    if (CtrlDetTot(10, d, fecha, 12, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaperiva"]}, {d}, {"*"}, '', 12)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periva"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiibb"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    if (CtrlDetTot(11, d, fecha, 13, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaperiibb"]}, {d}, {"*"}, '', 13)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periibb"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctapergan"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    if (CtrlDetTot(12, d, fecha, 14, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctapergan"]}, {d}, {"*"}, '', 14)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_pergan"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctamonotributo"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    if (CtrlDetTot(13, d, fecha, 15, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctamonotributo"]}, {d}, {"*"}, '', 15)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_monotributo"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaotros"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    if (CtrlDetTot(15, d, fecha, 16, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaotros"]}, {d}, {"*"}, '', 16)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_otros"]) * cotizacion).ToString());
                    }
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaimportacion"].ToString().Trim() != "" || (ds.Tables[0].Rows[0]["cpa_ctaimportacion"] is DBNull) == false) //importacion
                {
                    if (CtrlDetTot(6, d, fecha, 17, Convert.ToInt64(ds.Tables[0].Rows[0]["cpa_codigo"]), cotizacion) == false)
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctaimportacion"]}, {d}, {"*"}, '', 17)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_importacion"]) * cotizacion).ToString());
                    }
                }

                //total
                if (!(ds.Tables[0].Rows[0]["cpa_ctacpbte"].ToString().Trim() == "" || ds.Tables[0].Rows[0]["cpa_ctacpbte"] is DBNull))
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_condcpa"]) == 2) //cta cte
                    {
                        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctacpbte"]}, {h}, {"*"}, '', 18)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());
                    }
                    else //ctdo
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 12)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{fecha}', {ds.Tables[0].Rows[0]["cpa_ctacpbte"]}, {h}, {"*"}, '', 18)", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());
                        }
                        else //nc ctdo
                        {
                            FormPagCpa();
                        }
                    }
                }

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


                AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', 'REG. CPA. {ds.Tables[0].Rows[0]["cpa_nrocomp"]}  -  {ds.Tables[0].Rows[0]["cpa_nombre"]}', 0, 0, {ds.Tables[0].Rows[0]["mba_tipmov"]}, '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}', {ds.Tables[0].Rows[0]["cpa_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
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

        private void Proc_LiquiCpa()
        {
            //terminar (5436)
        }

        private void FormPagCpa()
        {
            //terminar
        }

        private bool Ctrl()
        {
            DataSet ds = new DataSet();
            //falta una parte
            ds = AccesoBase.ListarDatos($"Select * From ParamContab");
            if (ds.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Antes de poder generar los Asientos deber� indicar los Par�metros Contables.", false);
                MessageBox.ShowDialog();
                return false;
            }
            return true;
        }

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
