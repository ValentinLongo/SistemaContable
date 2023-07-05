using Bunifu.UI.WinForms;
using Datos;
using Datos.Modelos;
using Negocio;
using Negocio.Funciones.Generales;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
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
using System.Windows.Interop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
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
        }//

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

            if (Negocio.FGenerales.ValidacionHoraFecha(2, maskDesde) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Fecha Desde Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Negocio.FGenerales.ValidacionHoraFecha(2, maskHasta) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Fecha Hasta Invalida.", false);
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
            AsientoInicial = ds.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt32(ds.Tables[0].Rows[0]["maximo"]);

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
                    if (Convert.ToInt32(ds2.Tables[0].Rows[0]["pcu_hija"]) != 0)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta Contable No puede recibir movimientos", false, true);
                        MessageBox.ShowDialog();
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }

                ds = AccesoBase.ListarDatos($"Select * From MovVta Left Join TipMov on vta_tipmov = tmo_codigo Left Join Asiento on vta_tipmov = ast_tipocbte And vta_cpbte = ast_cbte Left Join ConceptoCont on vta_conceptocont = coc_codigo Where LEFT(vta_cliente,7) <> 'ANULADO' And ast_asiento is NULL And (vta_fecpro >= '{maskDesde.Text}' And vta_fecpro <= '{maskHasta.Text}')");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ProgressBar.Maximum = ds.Tables[0].Rows.Count;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Comprobante de Venta " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["vta_tipmov"]))
                        {
                            case 1: // 1 = factura
                            case 2: // 2 = Nota de Credito
                            case 3: // 3 = Nota de Debito
                                Proc_CpbteVta(dr);
                                break;

                            case 4: // credito interno
                            case 5: // debito interno
                                Proc_MovIntVta(dr);
                                break;

                            case 9: // liquido producto
                                Proc_LiquiP(dr);
                                break;

                            case 10: // ticket z
                                Proc_CpbteTKVta(dr);
                                break;

                            case 31: // recibo
                                Proc_Recibo(dr);
                                break;

                            case 53: // liquidacion vta
                                Proc_liquiVta(dr);
                                break;

                            default:
                                break;
                        }
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Comprobante de Compra " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["cpa_tipmov"]))
                        {
                            case 11: // 1 = factura
                            case 12: // 2 = Nota de Credito
                            case 13: // 3 = Nota de Debito
                                Proc_CPBTECpa(dr);
                                break;

                            case 14: // credito interno
                            case 15: // debito interno
                                Proc_MovIntCpa(dr);
                                break;

                            case 16: // liquidaciones de tc
                                //Proc_LIQTC();
                                break;

                            case 21: // op
                                Proc_OP(dr);
                                break;

                            case 54: // liquidacion cpa
                                Proc_LiquiCpa(dr);
                                break;

                            default:
                                break;
                        }
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Comprobante de Liquidación de Tarjeta " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_LIQTC(dr);
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Movimiento de Caja " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        switch (Convert.ToInt32(dr["moc_tipmov"]))
                        {
                            case 6: //ING
                                Proc_IngVar(dr);
                                break;

                            case 54: //EGR
                                Proc_EgrVar(dr);
                                break;

                            default:
                                break;
                        }
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Movimiento de Caja " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_Transf(dr);
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Depósito Bancario " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_Dep(dr);
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Movimiento Bancario " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_DCBan(dr);
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
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No ha sido Definido el Código de la Extracción Bancaria en los Parámetros.", false, true);
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Extracción Bancaria " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_Extraccion(dr);
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

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Application.DoEvents();

                        ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                        lblConteo.Text = "Depósito en Caución  " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                        Proc_Caucion(dr);
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

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Application.DoEvents();

                    ProgressBar.Value = ds.Tables[0].Rows.IndexOf(dr);

                    lblConteo.Text = "Transferencia Bancaria " + ds.Tables[0].Rows.IndexOf(dr) + " de " + ds.Tables[0].Rows.Count;

                    Proc_TraB(dr);
                }
            }
        salto2:

            ProgressBar.Value = 0;

            AccesoBase.InsertUpdateDatos($"Update Asiento Set ast_ejercicio = eje_codigo From Asiento Left Join Ejercicio on eje_desde <= ast_fecha And eje_hasta >= ast_fecha ");

            AccesoBase.InsertUpdateDatos($"Delete From MovAsto Where mva_importe = 0");

            Cursor.Current = Cursors.Default;

            lblConteo.Text = "Conteo de Comprobantes";

            MensajeError("Atención: El Proceso finalizó con Exito. Se Generaron los Asientos correspondientes a la numeración desde " + AsientoInicial + " hasta " + AsientoFinal);

            this.Close();
        }//

        private void Proc_LIQTC(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {dr["tar_ctapro"]} And ast_tipocbte = 16 And ast_cbte = '{dr["tcc_cpbte"]}'");

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join Tarjeta on tcc_tarjeta = tar_codigo Left Join Caja on tcc_caja = caj_codigo Where tcc_tipmov = 2 And tcc_cpbte = '{dr["tcc_cpbte"]}' And tar_ctapro = {dr["tar_ctapro"]}");

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

                double total = (ds3.Tables[0].Rows[0]["tcc_dto"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["tcc_dto"])) * cotizacion;

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = dr["tcc_fecha"].ToString();

                if (Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_formpag"]) == 1) //caja
                {
                    if ((ds3.Tables[0].Rows[0]["tcc_efectivo"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_dto"])) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, d, ds3.Tables[0].Rows[0]["tcc_efectivo"] is DBNull ? "0" : ds3.Tables[0].Rows[0]["tcc_efectivo"].ToString(), "", 18);
                    }

                    if ((ds3.Tables[0].Rows[0]["tcc_chet"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_chet"])) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCheT, d, ds3.Tables[0].Rows[0]["tcc_chet"] is DBNull ? "0" : ds3.Tables[0].Rows[0]["tcc_chet"].ToString(), "", 19);
                    }

                    if ((ds3.Tables[0].Rows[0]["tcc_dep"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_dep"])) != 0)
                    {
                        DataSet ds5 = new DataSet();
                        ds5 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["cpa_nrocomp"]}' And mba_tipmovref = 16 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["pcu_cuenta"]), d, (Convert.ToDouble(dr5["total"]) * cotizacion).ToString(), "", 20);
                        }

                        ds5 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["cpa_nrocomp"]}' And mba_tipmovref = 16 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["pcu_cuenta"]), d, (Convert.ToDouble(dr5["total"]) * cotizacion).ToString(), "", 21);
                        }
                    }
                }
                else if (Convert.ToInt32(ds3.Tables[0].Rows[0]["tcc_formpag"]) == 2) //banco
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaBan, d, total.ToString(), "", 18);
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaTar, h, ds3.Tables[0].Rows[0]["tcc_importe"] is DBNull ? "0" : (Convert.ToDouble(ds3.Tables[0].Rows[0]["tcc_importe"]) * cotizacion).ToString(), "", 25);

                if (dr["tcc_dto"].ToString() != dr["tcc_importe"].ToString())
                {
                    if (dr["cpa_ctaneto"].ToString().Trim() != "" && (dr["cpa_ctaneto"] is DBNull) == false) //neto
                    {
                        if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaneto"]), d, (Convert.ToDouble(dr["cpa_neto"]) * cotizacion).ToString(), "", 1);
                        }
                    }

                    if (dr["cpa_ctaexento"].ToString().Trim() != "" && (dr["cpa_ctaexento"] is DBNull) == false) //exento
                    {
                        if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaexento"]), d, (Convert.ToDouble(dr["cpa_exento"]) * cotizacion).ToString(), "", 2);
                        }
                    }

                    if (dr["cpa_ctaiva21"].ToString().Trim() != "" && (dr["cpa_ctaiva21"] is DBNull) == false) //iva21
                    {
                        if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva21"]), d, (Convert.ToDouble(dr["cpa_iva21"]) * cotizacion).ToString(), "", 3);
                        }
                    }

                    if (dr["cpa_ctaiva27"].ToString().Trim() != "" && (dr["cpa_ctaiva27"] is DBNull) == false) //iva27
                    {
                        if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva27"]), d, (Convert.ToDouble(dr["cpa_iva27"]) * cotizacion).ToString(), "", 4);
                        }
                    }

                    if (dr["cpa_ctaiva10"].ToString().Trim() != "" && (dr["cpa_ctaiva10"] is DBNull) == false) //iva10
                    {
                        if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva10"]), d, (Convert.ToDouble(dr["cpa_iva10"]) * cotizacion).ToString(), "", 5);
                        }
                    }

                    if (dr["cpa_ctaiva4"].ToString().Trim() != "" && (dr["cpa_ctaiva4"] is DBNull) == false) //iva4
                    {
                        if (CtrlDetTot(16, d, fecha, 6, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva4"]), d, (Convert.ToDouble(dr["cpa_iva4"]) * cotizacion).ToString(), "", 6);
                        }
                    }

                    if (dr["cpa_ctaiva5"].ToString().Trim() != "" && (dr["cpa_ctaiva5"] is DBNull) == false) //iva5
                    {
                        if (CtrlDetTot(17, d, fecha, 7, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva5"]), d, (Convert.ToDouble(dr["cpa_iva5"]) * cotizacion).ToString(), "", 7);
                        }
                    }

                    if (dr["cpa_ctaimpint"].ToString().Trim() != "" && (dr["cpa_ctaimpint"] is DBNull) == false) //impint
                    {
                        if (CtrlDetTot(14, d, fecha, 8, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimpint"]), d, (Convert.ToDouble(dr["cpa_impint"]) * cotizacion).ToString(), "", 8);
                        }
                    }

                    if (dr["cpa_ctaretiva"].ToString().Trim() != "" && (dr["cpa_ctaretiva"] is DBNull) == false) //retiva
                    {
                        if (CtrlDetTot(7, d, fecha, 9, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiva"]), d, (Convert.ToDouble(dr["cpa_retiva"]) * cotizacion).ToString(), "", 9);
                        }
                    }

                    if (dr["cpa_ctaretiibb"].ToString().Trim() != "" && (dr["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                    {
                        if (CtrlDetTot(8, d, fecha, 10, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiibb"]), d, (Convert.ToDouble(dr["cpa_retiibb"]) * cotizacion).ToString(), "", 10);
                        }
                    }

                    if (dr["cpa_ctaretgan"].ToString().Trim() != "" && (dr["cpa_ctaretgan"] is DBNull) == false) //retgan
                    {
                        if (CtrlDetTot(9, d, fecha, 11, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretgan"]), d, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 11);
                        }
                    }

                    if (dr["cpa_ctaperiva"].ToString().Trim() != "" && (dr["cpa_ctaperiva"] is DBNull) == false) //periva
                    {
                        if (CtrlDetTot(10, d, fecha, 12, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiva"]), d, (Convert.ToDouble(dr["cpa_periva"]) * cotizacion).ToString(), "", 12);
                        }
                    }

                    if (dr["cpa_ctaperiibb"].ToString().Trim() != "" && (dr["cpa_ctaperiibb"] is DBNull) == false) //periibb
                    {
                        if (CtrlDetTot(11, d, fecha, 13, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiibb"]), d, (Convert.ToDouble(dr["cpa_periibb"]) * cotizacion).ToString(), "", 13);
                        }
                    }

                    if (dr["cpa_ctapergan"].ToString().Trim() != "" && (dr["cpa_ctapergan"] is DBNull) == false) //pergan
                    {
                        if (CtrlDetTot(12, d, fecha, 14, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctapergan"]), d, (Convert.ToDouble(dr["cpa_pergan"]) * cotizacion).ToString(), "", 14);
                        }
                    }

                    if (dr["cpa_ctamonotributo"].ToString().Trim() != "" && (dr["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                    {
                        if (CtrlDetTot(13, d, fecha, 15, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctamonotributo"]), d, (Convert.ToDouble(dr["cpa_monotributo"]) * cotizacion).ToString(), "", 15);
                        }
                    }

                    if (dr["cpa_ctaotros"].ToString().Trim() != "" && (dr["cpa_ctaotros"] is DBNull) == false) //otros
                    {
                        if (CtrlDetTot(15, d, fecha, 16, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaotros"]), d, (Convert.ToDouble(dr["cpa_otros"]) * cotizacion).ToString(), "", 16);
                        }
                    }

                    if (dr["cpa_ctaimportacion"].ToString().Trim() != "" && (dr["cpa_ctaimportacion"] is DBNull) == false) //importacion
                    {
                        if (CtrlDetTot(6, d, fecha, 17, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimportacion"]), d, (Convert.ToDouble(dr["cpa_importacion"]) * cotizacion).ToString(), "", 17);
                        }
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                    return;
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "COBRANZA DE TARJETAS " + "Abreviado" + dr["tcc_cpbte"].ToString(), 0, 0, 16, dr["tcc_cpbte"].ToString(), Convert.ToInt32(dr["tar_ctapro"]), dr, "vta_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente la Liquidacion de TC " + dr["cpa_nrocomp"].ToString() + ".");
            }
        } //

        private void Proc_Caucion(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "mba_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["mba_tipmov"]} And ast_cbte = '{dr["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["mba_caja"]}");

                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {dr["mba_banco"]} And cta_sucursal = {dr["mba_sucursal"]} And cta_tipcta = {dr["mba_tipcta"]} And cta_nrocta = '{dr["mba_nrocta"]}'");

                long CtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if ((dr["mba_efectivo"] is DBNull ? 0 : Convert.ToInt32(dr["mba_efectivo"])) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaCaja, 2, ((dr["mba_efectivo"] is DBNull ? 0 : Convert.ToDouble(dr["mba_efectivo"])) * cotizacion).ToString(), "", 1);
                }

                if ((dr["mba_chet"] is DBNull ? 0 : Convert.ToInt32(dr["mba_chet"])) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaChet, 2, ((dr["mba_chet"] is DBNull ? 0 : Convert.ToDouble(dr["mba_chet"])) * cotizacion).ToString(), "", 1);
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaBan, 1, (Convert.ToDouble(dr["mba_importe"]) * cotizacion).ToString(), "", 2);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["mba_fecemi"].ToString(), "DEPOSITO BANCARIO(CAUCION)" + dr["mba_cpbte"].ToString(), 0, 0, Convert.ToInt32(dr["mba_tipmov"]), dr["mba_cpbte"].ToString(), 0, dr, "mba_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"] + ".");
            }
        }//

        private void Proc_Extraccion(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "mba_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["mba_tipmov"]} And ast_cbte = '{dr["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["mba_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {dr["mba_banco"]} And cta_sucursal = {dr["mba_sucursal"]} And cta_tipcta = {dr["mba_tipcta"]} And cta_nrocta = '{dr["mba_nrocta"]}'");
                long CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["mba_importe"]) * cotizacion).ToString(), "", 1);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaCtaBan, 2, (Convert.ToDouble(dr["mba_importe"]) * cotizacion).ToString(), "", 2);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["mba_fecemi"].ToString(), "EXT. BANCARIA" + dr["mba_cpbte"].ToString(), 0, 0, Convert.ToInt32(dr["mba_tipmov"]), dr["mba_cpbte"].ToString(), 0, dr, "mba_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"] + ".");
            }
        }//

        private void Proc_DCBan(DataRow dr)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["dcb_tipmov"]} And ast_cbte = '{dr["dcb_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                long CtaPro = 0;

                ds2 = AccesoBase.ListarDatos($"Select * From MovCpa Where cpa_tipmov = {dr["dcb_tipmov"]} And cpa_nrocomp = '{dr["dcb_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    CtaPro = 0;
                }
                else
                {
                    CtaPro = Convert.ToInt64(ds2.Tables[0].Rows[0]["cpa_ctapro"]);
                }

                if (Convert.ToInt32(dr["dcb_tipmov"]) == 47) //debito
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["dcb_feccont"].ToString(), Convert.ToInt32(dr["dcb_ctacont"]), 2, dr["dcb_total"].ToString(), "", 1);
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Select {terminal}, 1, '{dr["dcb_feccont"]}', det_ctacont, 1, det_importe, '', 2 From DetDebCredBan Where det_tipo = {dr["dcb_tipo"]} And det_cpbte = '{dr["dcb_cpbte"]}'");
                }
                else //credito
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["dcb_feccont"].ToString(), Convert.ToInt32(dr["dcb_ctacont"]), 1, dr["dcb_total"].ToString(), "", 1);
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Select {terminal}, 1, '{dr["dcb_feccont"]}', det_ctacont, 2, det_importe, '', 2 From DetDebCredBan Where det_tipo = {dr["dcb_tipo"]} And det_cpbte = '{dr["dcb_cpbte"]}'");
                }

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["dcb_feccont"].ToString(), (Convert.ToInt32(dr["dcb_tipo"]) == 1 ? "DEBITO BANCARIO" : "CREDITO BANCARIO") + dr["dcb_cpbte"].ToString(), 0, 0, Convert.ToInt32(dr["mba_tipmov"]), dr["mba_cpbte"].ToString(), Convert.ToInt32(CtaPro), dr, "mva_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["dcb_cpbte"].ToString() + ".");
            }
        }//

        private void Proc_Transf(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "moc_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["moc_tipmov"]} And RIGHT(('00000000' + ast_cbte),8) = '{dr["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["tra_cajaO"]}");
                long CtaCajaO = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["tra_cajaD"]}");
                long CtaCajaD = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                long Asiento = 0;

                if (Convert.ToInt32(dr["tra_tipo"]) == 1) // transferencia de valores
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_fecpro"].ToString(), CtaCajaD, 1, (Convert.ToDouble(dr["moc_total"]) * cotizacion).ToString(), "", 1);

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_fecpro"].ToString(), CtaCajaO, 2, (Convert.ToDouble(dr["moc_total"]) * cotizacion).ToString(), "", 2);

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                    if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                    {
                        //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                    }

                    ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                    Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                    AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{dr["moc_fecpro"]}', 'TRANSF VALORES {dr["moc_cpbte"]}', 0, 0, 57, '{dr["moc_cpbte"]}', 0, {FLogin.IdUsuario}, '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                    AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{dr["moc_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                }
                else //transferencia de efectivo
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_fecpro"].ToString(), CtaCajaD, 1, (Convert.ToDouble(dr["moc_total"]) * cotizacion).ToString(), "", 1);

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_fecpro"].ToString(), CtaCajaO, 2, (Convert.ToDouble(dr["moc_total"]) * cotizacion).ToString(), "", 2);

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);


                    if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                    {
                        //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                    }

                    ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
                    Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

                    AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{dr["moc_fecpro"]}', 'TRANSF EFECTIVO {dr["moc_cpbte"]}', 0, 0, 57, '{dr["moc_cpbte"]}', 0, {FLogin.IdUsuario}, '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
                    AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{dr["moc_fecpro"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                AsientoFinal = Asiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"] + ".");
            }
        }//

        private void Proc_MovIntCpa(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {dr["cpa_ctapro"]} And ast_tipocbte = {dr["cpa_tipmov"]} And ast_cbte = '{dr["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(dr["cpa_tipmov"]) == 14)
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
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

                string fecha = dr["cpa_feccont"].ToString();

                if (dr["cpa_ctaneto"].ToString().Trim() != "" && (dr["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaneto"]), d, (Convert.ToDouble(dr["cpa_neto"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (dr["cpa_ctaexento"].ToString().Trim() != "" && (dr["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaexento"]), d, (Convert.ToDouble(dr["cpa_exento"]) * cotizacion).ToString(), "", 2);
                    }
                }

                if (dr["cpa_ctaiva21"].ToString().Trim() != "" && (dr["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva21"]), d, (Convert.ToDouble(dr["cpa_iva21"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (dr["cpa_ctaiva27"].ToString().Trim() != "" && (dr["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva27"]), d, (Convert.ToDouble(dr["cpa_iva27"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (dr["cpa_ctaiva10"].ToString().Trim() != "" && (dr["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva10"]), d, (Convert.ToDouble(dr["cpa_iva10"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (dr["cpa_ctaimpint"].ToString().Trim() != "" && (dr["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    if (CtrlDetTot(14, d, fecha, 6, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimpint"]), d, (Convert.ToDouble(dr["cpa_impint"]) * cotizacion).ToString(), "", 6);
                    }
                }

                if (dr["cpa_ctaretiva"].ToString().Trim() != "" && (dr["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    if (CtrlDetTot(7, d, fecha, 7, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiva"]), d, (Convert.ToDouble(dr["cpa_retiva"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (dr["cpa_ctaretiibb"].ToString().Trim() != "" && (dr["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    if (CtrlDetTot(8, d, fecha, 8, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiibb"]), d, (Convert.ToDouble(dr["cpa_retiibb"]) * cotizacion).ToString(), "", 8);
                    }
                }

                if (dr["cpa_ctaretgan"].ToString().Trim() != "" && (dr["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    if (CtrlDetTot(9, d, fecha, 9, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretgan"]), d, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (dr["cpa_ctaperiva"].ToString().Trim() != "" && (dr["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    if (CtrlDetTot(10, d, fecha, 10, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiva"]), d, (Convert.ToDouble(dr["cpa_periva"]) * cotizacion).ToString(), "", 10);
                    }
                }

                if (dr["cpa_ctaperiibb"].ToString().Trim() != "" && (dr["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    if (CtrlDetTot(11, d, fecha, 11, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiibb"]), d, (Convert.ToDouble(dr["cpa_periibb"]) * cotizacion).ToString(), "", 11);
                    }
                }

                if (dr["cpa_ctapergan"].ToString().Trim() != "" && (dr["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    if (CtrlDetTot(12, d, fecha, 12, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctapergan"]), d, (Convert.ToDouble(dr["cpa_pergan"]) * cotizacion).ToString(), "", 12);
                    }
                }

                if (dr["cpa_ctamonotributo"].ToString().Trim() != "" && (dr["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    if (CtrlDetTot(13, d, fecha, 13, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctamonotributo"]), d, (Convert.ToDouble(dr["cpa_monotributo"]) * cotizacion).ToString(), "", 13);
                    }
                }

                if (dr["cpa_ctaotros"].ToString().Trim() != "" && (dr["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    if (CtrlDetTot(15, d, fecha, 14, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaotros"]), d, (Convert.ToDouble(dr["cpa_otros"]) * cotizacion).ToString(), "", 14);
                    }
                }

                if (dr["cpa_ctaimportacion"].ToString().Trim() != "" && (dr["cpa_ctaimportacion"] is DBNull) == false) //importacion
                {
                    if (CtrlDetTot(6, d, fecha, 15, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimportacion"]), d, (Convert.ToDouble(dr["cpa_importacion"]) * cotizacion).ToString(), "", 15);
                    }
                }

                //total
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaProv, h, (Convert.ToDouble(dr["cpa_total"]) * cotizacion).ToString(), "", 16);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. CPA." + "Abreviado" + dr["cpa_nrocomp"] + "-" + dr["cpa_nombre"].ToString(), 0, 0, Convert.ToInt32(dr["cpa_tipmov"]), dr["cpa_nrocomp"].ToString(), Convert.ToInt32(dr["cpa_ctapro"]), dr, "cpa_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"] + ".");
            }
        }//

        //private void Proc_MovIntCpaBCKP(DataSet ds)
        //{
        //    try
        //    {
        //        double cotizacion = ds.Tables[0].Rows[0]["cpa_cotiz"] is DBNull ? 1 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_cotiz"]);

        //        DataSet ds2 = new DataSet();
        //        ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {ds.Tables[0].Rows[0]["cpa_ctapro"]} And ast_tipocbte = {ds.Tables[0].Rows[0]["cpa_tipmov"]} And ast_cbte = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}'");
        //        if (ds2.Tables[0].Rows.Count != 0)
        //        {
        //            return;
        //        }

        //        int n = 1;

        //        int d = 0; //debe
        //        int h = 0; //haber

        //        if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 14)
        //        {
        //            h = 1;
        //            d = 2;
        //        }
        //        else
        //        {
        //            h = 2;
        //            d = 1;
        //        }

        //        DataSet ds3 = new DataSet();
        //        ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["cpa_caja"]}");
        //        long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

        //        ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
        //        long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

        //        AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

        //        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', {txtNroCuenta.Text}, {d}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());

        //        n = +1;

        //        AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, 1, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', {CtaProv}, {h}, {"*"}, '', {n})", (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]) * cotizacion).ToString());

        //        AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");

        //        ds3 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
        //        double debe = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

        //        ds3 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
        //        double haber = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

        //        double dif = debe - haber;

        //        if (dif != 0)
        //        {
        //            AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
        //        }

        //        double A = 0; //debe
        //        double B = 0; //haber

        //        DataSet ds4 = new DataSet();
        //        ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
        //        if (ds4.Tables[0].Rows.Count != 0)
        //        {
        //            A = Convert.ToDouble(ds4.Tables[0].Rows[0]["A"]);
        //        }
        //        ds4 = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
        //        if (ds4.Tables[0].Rows.Count != 0)
        //        {
        //            B = Convert.ToDouble(ds4.Tables[0].Rows[0]["B"]);
        //        }
        //        if (A != B)
        //        {
        //            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.", false, true);
        //            MessageBox.ShowDialog();
        //        }

        //        ds2 = AccesoBase.ListarDatos("Select Max(ast_asiento) as maximo From Asiento");
        //        long Asiento = ds2.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt64(ds2.Tables[0].Rows[0]["maximo"]) + 1;

        //        ds2 = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = {ds.Tables[0].Rows[0]["cpa_tipmov"]}");
        //        string Abreviado = ds2.Tables[0].Rows[0]["tmo_abrev"].ToString();

        //        AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{ds.Tables[0].Rows[0]["cpa_feccont"]}', 'REG. CPA. {Abreviado.ToUpper()} {ds.Tables[0].Rows[0]["cpa_nrocomp"]} {ds.Tables[0].Rows[0]["cpa_nombre"]}', 0, 0, {ds.Tables[0].Rows[0]["cpa_tipmov"]}, '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}', {ds.Tables[0].Rows[0]["cpa_ctapro"]}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
        //        AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asiento, '{ds.Tables[0].Rows[0]["cpa_feccont"]}' as Fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
        //        AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

        //        AsientoFinal = Asiento;
        //    }
        //    catch (Exception)
        //    {
        //        AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
        //        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"] + ".", false, true);
        //        MessageBox.ShowDialog();
        //    }
        //}//

        private void Proc_TraB(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "mba_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Parametro");
                int CodOpeO = Convert.ToInt32(ds2.Tables[0].Rows[0]["par_TranBanExt"]);
                int CodOpeD = Convert.ToInt32(ds2.Tables[0].Rows[0]["par_TranBanDep"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                ds2 = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpeO} And mba_referencia = '' And mba_cpbte = '{dr["mba_cpbte"]}' UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpeO} And mba_referencia = '' And mba_cpbte = '{dr["mba_cpbte"]}' ) as X Where mba_importe <> 0");

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds2.Tables[0].Rows[0]["mba_banco"]} And cta_sucursal = {ds2.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds2.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds2.Tables[0].Rows[0]["mba_nrocta"]}'");
                long CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds2.Tables[0].Rows[0]["mba_fecemi"].ToString(), CtaCtaBan, 1, ds2.Tables[0].Rows[0]["mba_importe"].ToString(), "", 1);

                ds2 = AccesoBase.ListarDatos($"Select * From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = {CodOpeD} And mba_referencia = '' And mba_cpbte = '{dr["mba_cpbte"]}' UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = {CodOpeD} And mba_referencia = '' And mba_cpbte = '{dr["mba_cpbte"]}' ) as X Where mba_importe <> 0");

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {ds2.Tables[0].Rows[0]["mba_banco"]}  And cta_sucursal = {ds2.Tables[0].Rows[0]["mba_sucursal"]} And cta_tipcta = {ds2.Tables[0].Rows[0]["mba_tipcta"]} And cta_nrocta = '{ds2.Tables[0].Rows[0]["mba_nrocta"]}'");
                CtaCtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds2.Tables[0].Rows[0]["mba_fecemi"].ToString(), CtaCtaBan, 2, ds2.Tables[0].Rows[0]["mba_importe"].ToString(), "", 2);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["mba_fecemi"].ToString(), "TRANF. BANCARIA" + dr["mba_cpbte"].ToString(), 0, 0, 100, dr["mba_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["mba_cpbte"] + ".");
            }
        }//

        private void Proc_Dep(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "mba_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 1 And ast_cbte = '{dr["mba_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["mba_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From CtaBan Where cta_banco = {dr["mba_banco"]} And cta_sucursal = {dr["mba_sucursal"]} And cta_tipcta = {dr["mba_tipcta"]} And cta_nrocta = '{dr["mba_nrocta"]}'");
                long CtaBan = Convert.ToInt64(ds3.Tables[0].Rows[0]["cta_ctacont"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if ((dr["mba_efectivo"] is DBNull ? 0 : Convert.ToDouble(dr["mba_efectivo"])) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaCaja, 2, dr["mba_efectivo"] is DBNull ? "0" : (Convert.ToDouble(dr["mba_efectivo"]) * cotizacion).ToString(), "", 1);
                }

                if ((dr["mba_chet"] is DBNull ? 0 : Convert.ToDouble(dr["mba_chet"])) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaChet, 2, dr["mba_chet"] is DBNull ? "0" : (Convert.ToDouble(dr["mba_chet"]) * cotizacion).ToString(), "", 1);
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["mba_fecemi"].ToString(), CtaBan, 1, (Convert.ToDouble(dr["mba_importe"]) * cotizacion).ToString(), "", 2);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["mba_fecemi"].ToString(), "DEPOSITO BANCARIO" + dr["mba_cpbte"].ToString(), 0, 0, 1, dr["mba_cpbte"].ToString(), 0, dr, "mba_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Depòsito " + dr["mba_cpbte"] + ".");
            }
        }//

        private void Proc_IngVar(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "moc_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 42 And ast_cbte = '{dr["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["moc_caja"]}");
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

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (!(dr["moc_valores"] is DBNull) && Convert.ToInt32(dr["moc_valores"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaChet, 1, (Convert.ToDouble(dr["moc_valores"]) * cotizacion).ToString(), "", 1);
                }

                if (!(dr["moc_tc"] is DBNull) && Convert.ToInt32(dr["moc_tc"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, Sum(tcc_importe) as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = 42 And tcc_cpbte = '{dr["moc_cpbte"]}' Group By tcc_tarjeta, pcu_cuenta");

                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 1, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 2);
                    }

                }

                if (!(dr["moc_gasto"] is DBNull) && Convert.ToInt32(dr["moc_gasto"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["moc_gasto"]) * cotizacion).ToString(), "", 3);
                }

                if (!(dr["moc_efectivo"] is DBNull) && Convert.ToInt32(dr["moc_efectivo"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["moc_efectivo"]) * cotizacion).ToString(), "", 4);
                }

                DataSet ds4 = new DataSet();
                if (!(dr["moc_retgan"] is DBNull) && Convert.ToInt32(dr["moc_retgan"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 3 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(dr4["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["ret_ctacont"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 5);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetGan, 1, (Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]) * cotizacion).ToString(), "", 5);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetGan, 1, (Convert.ToDouble(ds3.Tables[0].Rows[0]["moc_retgan"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (!(dr["moc_retiibb"] is DBNull) && Convert.ToInt32(dr["moc_retiibb"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 2 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(dr4["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["ret_ctacont"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 6);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetIIBB, 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 6);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetIIBB, 1, (Convert.ToDouble(dr["moc_retiibb"]) * cotizacion).ToString(), "", 6);
                    }
                }

                if (!(dr["moc_retiva"] is DBNull) && Convert.ToInt32(dr["moc_retiva"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as Tot From Retencion Where ret_recibo = '{dr["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 1 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(dr4["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["ret_ctacont"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 7);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetIVA, 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 7);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetIVA, 1, (Convert.ToDouble(dr["moc_retiva"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (!(dr["moc_retsuss"] is DBNull) && Convert.ToInt32(dr["moc_retsuss"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 4 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(dr4["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["ret_ctacont"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 8);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetSuss, 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 8);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetSuss, 1, (Convert.ToDouble(dr["moc_retsuss"]) * cotizacion).ToString(), "", 8);
                    }
                }

                if (!(dr["moc_retBF"] is DBNull) && Convert.ToInt32(dr["moc_retBF"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["moc_cpbte"]}' And ret_tipmov = 42 And ret_tipret = 2 Group By ret_ctacont");

                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            if (!(dr4["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["ret_ctacont"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 9);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 9);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr["moc_retBF"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (!(dr["moc_ticket"] is DBNull) && Convert.ToInt32(dr["moc_ticket"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["moc_ticket"]) * cotizacion).ToString(), "", 10);
                }

                if (!(dr["moc_dep"] is DBNull) && Convert.ToInt32(dr["moc_dep"]) != 0)
                {
                    ds4 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["moc_cpbte"]}' And mba_tipmovref = 42 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["pcu_cuenta"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 11);
                    }

                    ds4 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["moc_cpbte"]}' And mba_tipmovref = 42 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr4["pcu_cuenta"]), 1, (Convert.ToDouble(dr4["total"]) * cotizacion).ToString(), "", 11);
                    }
                }

                if ((!(dr["moc_vlte"] is DBNull) && Convert.ToInt32(dr["moc_vlte"]) != 0) || (!(dr["moc_vltc"] is DBNull) && Convert.ToInt32(dr["moc_vltc"]) != 0))
                {
                    double suma = (dr["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vltc"])) + (dr["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vlte"]));

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 2, (suma * cotizacion).ToString(), "", 12);
                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_CC) SELECT {terminal}, 1, '{dr["moc_feccont"]}', va1_cta, 2, va1_importe * {"#"}, va1_comentario, 12, va1_cc From MovVario Where va1_tipmov = 42 And va1_cpbte = '{dr["moc_cpbte"]}' ", cotizacion.ToString(), true);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["moc_feccont"].ToString(), "ING. VAR." + dr["moc_cpbte"].ToString() + "-" + dr["moc_descri"].ToString(), 0, 0, 42, dr["moc_cpbte"].ToString(), 0, dr, "moc_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Ingreso Vario " + dr["moc_cpbte"] + ".");
            }
        }//

        private void Proc_EgrVar(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "moc_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = 43 And ast_cbte = '{dr["moc_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["moc_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaProv = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaProv"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (!(dr["moc_valores"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_valores"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaChet, 2, (Convert.ToDouble(dr["moc_valores"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (!(dr["moc_chep"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_chep"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{dr["moc_cpbte"]}' And chp_tipmov = 43 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");

                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 2);
                        }
                    }                   
                }

                if (!(dr["moc_efectivo"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_efectivo"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 2, (Convert.ToDouble(dr["moc_efectivo"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (!(dr["moc_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_retgan"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaRetGan, 2, (Convert.ToDouble(dr["moc_retgan"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (!(dr["moc_dep"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_dep"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{dr["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 5);

                        }

                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{dr["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 5);
                        }
                    }
                }

                if (!(dr["moc_devtc"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_devtc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_refanula = '43 {dr["moc_cpbte"]}'");

                        if (ds3.Tables[0].Rows.Count != 0)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["tar_ctacont"]), 2, (Convert.ToDouble(dr["moc_devtc"]) * cotizacion).ToString(), "", 4);
                        }

                    }
                }

                if (((dr["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vlte"])) + (dr["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vltc"]))) == 0)
                {
                    //Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 2, ((dr["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vltc"])) + (dr["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vlte"]) * cotizacion)).ToString(), "", 6);
                }
                else
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), CtaCaja, 1, ((dr["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vltc"])) + (dr["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["moc_vlte"])) * cotizacion).ToString(), "", 6);
                }

                if (!(dr["moc_tc"] is DBNull))
                {
                    if (Convert.ToDouble(dr["moc_tc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select tap_nombre, pcu_cuenta, Sum(txo_importe) as total From TarjetaxOP Left Join (TarjetaP Left Join PCuenta on tap_ctacont = pcu_cuenta) on tap_codigo = txo_marca Where txo_ctapro = 0 And txo_nrocomp = '{dr["moc_cpbte"]}' And txo_tipmov = 43 Group By tap_nombre, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["moc_feccont"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 7);
                        }
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) SELECT {terminal}, 1, '{dr["moc_feccont"]}', va1_cta, 1, va1_importe * {"#"}, va1_comentario, 7, va1_cc From MovVario Where va1_tipmov = 43 And va1_cpbte = '{dr["moc_cpbte"]}' ", cotizacion.ToString(), true);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["moc_feccont"].ToString(), "EGR. VAR." + dr["moc_cpbte"].ToString() + "-" + dr["moc_descri"].ToString(), 0, 0, 43, dr["moc_cpbte"].ToString(), 0, dr, "moc_tipmov");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.ToString());

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Egreso Vario " + dr["moc_cpbte"] + ".");
            }
        }//

        private void Proc_Recibo(DataRow dr)
        {
            try
            {
                double cotizacion = 0;
                if (Convert.ToInt32(dr["vta_moneda"]) == 1)
                {
                    cotizacion = 1;
                }
                else
                {
                    cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["vta_tipmov"]} And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds3.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctaCheT"]);

                DataSet ds4 = new DataSet();
                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {dr["vta_seccion"]}");
                }

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaRetBF"]);

                long CtaDeud = 0;
                long CtaAnticipo = 0;
                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion())
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

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FechaCont() == false) ? dr["vta_fecpro"].ToString() : dr["vta_fecemi"].ToString();

                if (!(dr["vta_valores"] is DBNull) && Convert.ToDouble(dr["vta_valores"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaChet, 1, ((Convert.ToDouble(dr["vta_valores"])) * cotizacion).ToString(), "", 1);
                }

                if (!(dr["vta_tc"] is DBNull) && Convert.ToDouble(dr["vta_tc"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, tcc_importe as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = 31 And tcc_cpbte = '{dr["vta_cpbte"]}'");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 1, ((Convert.ToDouble(dr3["total"])) * cotizacion).ToString(), "TARJETA DE CREDITO", 2);
                    }
                }

                if (!(dr["vta_gasto"] is DBNull) && Convert.ToDouble(dr["vta_gasto"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, ((Convert.ToDouble(dr["vta_gasto"])) * cotizacion).ToString(), "", 3);
                }

                if (!(dr["vta_efectivo"] is DBNull) && Convert.ToDouble(dr["vta_efectivo"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, ((Convert.ToDouble(dr["vta_efectivo"])) * cotizacion).ToString(), "", 4);
                }

                DataSet ds5 = new DataSet();
                if (!(dr["vta_retiibb"] is DBNull) && Convert.ToInt32(dr["vta_retiibb"]) != 0)
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, ret_total as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 2");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["ret_ctacont"]), 1, ((Convert.ToDouble(dr5["total"])) * cotizacion).ToString(), "RETENCION DE IIBB", 6);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetIIBB, 1, ((Convert.ToDouble(dr5["total"])) * cotizacion).ToString(), "RETENCION DE IIBB", 6);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetIIBB, 1, ((Convert.ToDouble(dr["vta_retiibb"]) * cotizacion)).ToString(), "RETENCION DE IIBB", 6);
                    }
                }

                if (!(dr["vta_retiva"] is DBNull) && Convert.ToInt32(dr["vta_retiva"]) != 0)
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, ret_total as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 1");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["ret_ctacont"]), 1, ((Convert.ToDouble(dr5["total"])) * cotizacion).ToString(), "RETENCION DE IVA", 7);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetIVA, 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "RETENCION DE IVA", 7);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetIVA, 1, ((Convert.ToDouble(dr["vta_retiva"])) * cotizacion).ToString(), "RETENCION DE IVA", 7);
                    }
                }

                if (!(dr["vta_retgan"] is DBNull) && Convert.ToInt32(dr["vta_retgan"]) != 0)
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, ret_total as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 3");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["ret_ctacont"]), 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "RETENCION DE GANANCIAS", 22);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetGan, 1, ((Convert.ToDouble(dr5["total"])) * cotizacion).ToString(), "RETENCION DE GANANCIAS", 22);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetGan, 1, ((Convert.ToDouble(dr["vta_retgan"]) * cotizacion)).ToString(), "RETENCION DE GANANCIAS", 22);
                    }
                }

                if (!(dr["vta_retsuss"] is DBNull) && Convert.ToInt32(dr["vta_retsuss"]) != 0)
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, ret_total as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 4");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["ret_ctacont"]), 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "RETENCION SUSS", 8);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetSuss, 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "RETENCION SUSS", 8);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetSuss, 1, ((Convert.ToDouble(dr["vta_retsuss"])) * cotizacion).ToString(), "RETENCION SUSS", 8);
                    }
                }

                if (!(dr["vta_retBF"] is DBNull) && Convert.ToInt32(dr["vta_retBF"]) != 0)
                {
                    ds5 = AccesoBase.ListarDatos($"Select ret_ctacont, ret_total as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 5");

                    if (ds5.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            if (!(ds5.Tables[0].Rows[0]["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr5["ret_ctacont"]), 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "BONO FISCAL", 9);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetBF, 1, ((Convert.ToDouble(dr5["total"]) * cotizacion)).ToString(), "BONO FISCAL", 9);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetBF, 1, ((Convert.ToDouble(dr["vta_retBF"]) * cotizacion)).ToString(), "BONO FISCAL", 9);
                    }
                }

                if (!(dr["vta_ticket"] is DBNull) && Convert.ToDouble(dr["vta_ticket"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, ((Convert.ToDouble(dr["vta_ticket"])) * cotizacion).ToString(), "", 10);
                }

                if (!(dr["vta_dep"] is DBNull) && Convert.ToDouble(dr["vta_dep"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = 31 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 1, ((Convert.ToDouble(dr3["total"])) * cotizacion).ToString(), "", 11);
                    }

                    ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = 31 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 1, ((Convert.ToDouble(dr3["total"])) * cotizacion).ToString(), "", 11);
                    }
                }

                if ((!(dr["vta_vlte"] is DBNull) && Convert.ToDouble(dr["vta_vlte"]) != 0) || (!(dr["vta_vltc"] is DBNull) && Convert.ToDouble(dr["vta_vltc"]) != 0))
                {
                    double Vuelto = 0;

                    ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{dr["vta_cpbte"]}' And chp_tipmov = 31 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 2, ((Convert.ToDouble(dr3["total"]) * cotizacion)).ToString(), "", 12);
                        Vuelto += (Convert.ToDouble(dr3["total"]) * cotizacion);
                    }

                    double suma = (dr["vta_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_vltc"])) + (dr["vta_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["vta_vlte"]));
                    suma = suma - Vuelto;

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (suma * cotizacion).ToString(), "", 13);
                }

                double Anticipo = 0;
                int n = 12;

                DataSet ds6 = new DataSet();
                if (ParConceptoUnico == 0)
                {
                    ds6 = AccesoBase.ListarDatos($"Select Sum(cta_total) as cta_total From MovCtaCteVta Where (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}'");
                    if (ds6.Tables[0].Rows.Count != 0)
                    {
                        if ((dr["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(dr["vta_moneda2"])) == 1)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAnticipo, 2, (ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"])).ToString(), "", n);
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]);
                        }
                        else
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAnticipo, 2, (ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion).ToString(), "", n);
                            Anticipo = ds6.Tables[0].Rows[0]["cta_total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                        }
                    }

                    n += 1;

                    ds6 = AccesoBase.ListarDatos($"Select (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End) as rbo_contrap, Sum(cta_total) as pago From MovCtaCteVta Left Join (MovVta Left Join Seccion on vta_seccion = sec_codigo) on (CONVERT(VARCHAR,vta_tipmov) + vta_cpbte) = left(cta_referencia,14) And cta_ctacli = vta_ctacli Where Not (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' Group By (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End)");
                    foreach (DataRow dr6 in ds6.Tables[0].Rows)
                    {
                        long contrap = Convert.ToInt64(dr6["rbo_contrap"]) == 0 ? CtaDeud : Convert.ToInt64(dr6["rbo_contrap"]);
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, contrap, 2, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])).ToString(), "", n);
                        n += 1;
                    }
                }
                else
                {
                    int cc = 0;

                    ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join MovVta on LEFT(cta_referencia,1) = vta_tipmov And SUBSTRING(cta_referencia,2,14) = vta_cpbte And cta_ctacli = vta_ctacli Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on vta_conceptocont = coc_codigo Where cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' And not (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                    foreach (DataRow dr6 in ds6.Tables[0].Rows)
                    {
                        cc = dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"]);
                        if ((dr["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(dr["vta_moneda2"])) == 1)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr6["pcu_cuenta"]), 2, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])).ToString(), "", n, cc);
                        }
                        else
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr6["pcu_cuenta"]), 2, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"]) * cotizacion).ToString(), "", n, cc);
                        }
                        n += 1;
                    }

                    long CtaAUsar = 0;

                    ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on cta_conceptocont = coc_codigo Where cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' And (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                    foreach (DataRow dr6 in ds6.Tables[0].Rows)
                    {
                        cc = dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"]);
                        if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.ConceptoACuenta() == false)
                        {
                            CtaAUsar = CtaAnticipo;
                        }
                        else
                        {
                            CtaAUsar = dr6["pcu_cuenta"] is DBNull ? CtaAnticipo : Convert.ToInt64(dr6["pcu_cuenta"]);
                        }

                        if ((dr["vta_moneda2"] is DBNull ? 1 : Convert.ToDouble(dr["vta_moneda2"])) == 1)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAUsar, 2, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])).ToString(), "", n, cc);
                        }
                        else
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAUsar, 2, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"]) * cotizacion).ToString(), "", n, cc);
                        }
                        n += 1;
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "s/RE" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Recibo " + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private void Proc_OP(DataRow dr)
        {
            try
            {
                double cotizacion = 0;
                if (Convert.ToInt32(dr["cpa_moneda"]) == 1)
                {
                    cotizacion = 1;
                }
                else
                {
                    cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {dr["cpa_ctapro"]} And ast_tipocbte = '{dr["cpa_tipmov"]}' And ast_cbte = '{dr["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["cpa_caja"]}");
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

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = Negocio.Funciones.Generales.FAuditoriaInternaMenu.FechaCont() == false ? dr["cpa_feccont"].ToString() : dr["cpa_feccpbte"].ToString();

                if (!(dr["cpa_tottercero"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottercero"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaChet, 2, (Convert.ToDouble(dr["cpa_tottercero"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (!(dr["cpa_tottc"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottc"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select tap_nombre, pcu_cuenta, Sum(txo_importe) as total From TarjetaxOP Left Join (TarjetaP Left Join PCuenta on tap_ctacont = pcu_cuenta) on tap_codigo = txo_marca Where txo_ctapro = {dr["cpa_ctapro"]} And txo_nrocomp = '{dr["cpa_nrocomp"]}' And txo_tipmov = 21 Group By tap_nombre, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 2, dr3["total"].ToString(), "", 20);
                        }
                    }
                }

                if (!(dr["cpa_totpropio"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_totpropio"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{dr["cpa_nrocomp"]}' And chp_tipmov = 21 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 2);
                        }
                    }
                }

                if (!(dr["cpa_totefectivo"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_totefectivo"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (Convert.ToDouble(dr["cpa_totefectivo"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (!(dr["cpa_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_retgan"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetGan, 2, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (!(dr["cpa_retBF"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_retBF"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaBF, 2, (Convert.ToDouble(dr["cpa_retBF"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (!(dr["cpa_tottransf"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottransf"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["cpa_nrocomp"]}' And mba_tipmovref = 21 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 5);
                        }

                        ds3 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["cpa_nrocomp"]}' And mba_tipmovref = 21 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["pcu_cuenta"]), 2, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 5);
                        }
                    }
                }

                if (((dr["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvuelto"])) + (dr["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvueltoC"]))) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, ((dr["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvuelto"])) + (dr["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvueltoC"])) * cotizacion).ToString(), "", 6);
                }

                if (!(dr["cpa_tottickets"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottickets"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (Convert.ToDouble(dr["cpa_tottickets"]) * cotizacion).ToString(), "", 7);
                    }
                }

                double Anticipo = 0;

                ds3 = AccesoBase.ListarDatos($"Select * From MovCtaCte Where cta_ctapro = {dr["cpa_ctapro"]} And cta_tipmov = 21 And cta_nrocomp = '{dr["cpa_nrocomp"]}' And (IsNull(cta_referencia,'') = '' or IsNull(cta_referencia,'') = 'A CUENTA')");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    Anticipo = Convert.ToDouble(ds3.Tables[0].Rows[0]["cta_total"]) * cotizacion;
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAnticipo, 1, Anticipo.ToString(), "", 6);
                }

                ds3 = AccesoBase.ListarDatos("Select par_AstoCtaProvOP From Parametro");
                if ((ds3.Tables[0].Rows[0]["par_AstoCtaProvOP"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["par_AstoCtaProvOP"])) == 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaProv, 1, ((Convert.ToDouble(dr["cpa_total"]) - Anticipo) * cotizacion).ToString(), "", 6);
                }
                else
                {
                    long CtaAux = 0;

                    ds3 = AccesoBase.ListarDatos($"Select cpa_ctacpbte, Sum(cta_total) as total From MovCtaCte Left Join MovCpa on cpa_ctapro = cta_ctapro And CONVERT(VARCHAR,cpa_tipmov) = left(cta_referencia,2) And cpa_nrocomp = SUBSTRING(cta_referencia,3,14) Where cta_ctapro = {dr["cpa_ctapro"]} And cta_tipmov = 21 And cta_nrocomp = '{dr["cpa_nrocomp"]}' And not (IsNull(cta_referencia,'') = '' or IsNull(cta_referencia,'') = 'A CUENTA') Group By cpa_ctacpbte");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        if ((dr3["cpa_ctacpbte"] is DBNull ? "" : dr3["cpa_ctacpbte"].ToString()) == "")
                        {
                            CtaAux = CtaProv;
                        }
                        else
                        {
                            if (Convert.ToDouble(dr3["cpa_ctacpbte"]) == 0)
                            {
                                CtaAux = CtaProv;
                            }
                            else
                            {
                                CtaAux = Convert.ToInt64(dr3["cpa_ctacpbte"]);
                            }
                        }
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAux, 1, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 6);
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "s/OP" + dr["cpa_nrocomp"].ToString() + "-" + dr["cpa_nombre"].ToString(), 0, 0, Convert.ToInt32(dr["cpa_tipmov"]), dr["cpa_nrocomp"].ToString(), Convert.ToInt32(dr["cpa_ctapro"]), dr, "cpa_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente a la Orden de Pago " + dr["cpa_nrocomp"] + ".");
            }
        }//

        private void Proc_liquiVta(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{dr["vta_tipmov"]}' And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0 || Convert.ToDouble(dr["vta_total"]) == 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(dr["tmo_ctrl"]) == 1)
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
                ds3 = AccesoBase.ListarDatos($"Select * From DetCtaContVta Where dcc_codigo = {dr["vta_codigo"]}");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = Negocio.Funciones.Generales.FAuditoriaInternaMenu.FechaCont() == false ? dr["vta_fecpro"].ToString() : dr["vta_fecemi"].ToString();

                if (Convert.ToDouble(dr["vta_neto21"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto1"]), d, dr["vta_neto21"].ToString(), "", 1);
                }

                if (Convert.ToDouble(dr["vta_neto27"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto3"]), d, ds3.Tables[0].Rows[0]["dcc_ctaneto3"].ToString(), "", 16);
                }

                if (Convert.ToDouble(dr["vta_neto10"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto2"]), d, ds3.Tables[0].Rows[0]["dcc_ctaneto2"].ToString(), "", 17);
                }

                if (Convert.ToDouble(dr["vta_exento"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaexento"]), d, ds3.Tables[0].Rows[0]["dcc_ctaexento"].ToString(), "", 2);
                }
                else if (Convert.ToDouble(dr["vta_exento"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaexento"]), h, (Convert.ToDouble(dr["vta_exento"]) * -1).ToString(), "", 2);
                }

                if (Convert.ToDouble(dr["vta_iva27"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva3"]), d, dr["vta_iva27"].ToString(), "", 18);
                }

                if (Convert.ToDouble(dr["vta_iva21"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva1"]), d, dr["vta_iva21"].ToString(), "", 3);
                }

                if (Convert.ToDouble(dr["vta_iva10"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva2"]), d, dr["vta_iva10"].ToString(), "", 4);
                }

                if (Convert.ToDouble(dr["vta_impint"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaimpint"]), d, dr["vta_impint"].ToString(), "", 5);
                }
                else if (Convert.ToDouble(dr["vta_impint"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaimpint"]), h, (Convert.ToDouble(dr["vta_iva10"]) * -1).ToString(), "", 5);
                }

                if (Convert.ToDouble(dr["vta_retiva"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretIVA"]), d, dr["vta_retiva"].ToString(), "", 6);
                }
                else if (Convert.ToDouble(dr["vta_retiva"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretIVA"]), h, (Convert.ToDouble(dr["vta_retiva"]) * -1).ToString(), "", 6);
                }

                if (Convert.ToDouble(dr["vta_retiibb"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretIIBB"]), d, dr["vta_retiibb"].ToString(), "", 7);
                }
                else if (Convert.ToDouble(dr["vta_retiibb"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretIIBB"]), h, (Convert.ToDouble(dr["vta_retiibb"]) * -1).ToString(), "", 7);
                }

                if (Convert.ToDouble(dr["vta_retgan"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretGan"]), d, dr["vta_retgan"].ToString(), "", 8);
                }
                else if (Convert.ToDouble(dr["vta_retgan"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretGan"]), h, (Convert.ToDouble(dr["vta_retgan"]) * -1).ToString(), "", 8);
                }

                if (Convert.ToDouble(dr["vta_retsuss"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretSUSS"]), d, dr["vta_retsuss"].ToString(), "", 9);
                }
                else if (Convert.ToDouble(dr["vta_retsuss"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretSUSS"]), h, (Convert.ToDouble(dr["vta_retsuss"]) * -1).ToString(), "", 9);
                }

                if (Convert.ToDouble(dr["vta_retBF"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretBF"]), d, dr["vta_retBF"].ToString(), "", 13);
                }
                else if (Convert.ToDouble(dr["vta_retBF"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaretBF"]), h, (Convert.ToDouble(dr["vta_retBF"]) * -1).ToString(), "", 13);
                }

                if (Convert.ToDouble(dr["vta_formpag"]) == 2)
                {
                    if (Convert.ToDouble(dr["vta_total"]) > 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctatotal"]), h, dr["vta_total"].ToString(), "", 15);
                    }
                }
                else
                {
                    if (Convert.ToDouble(dr["tmo_ctrl"]) == 1) //FACTURA y NOTA DE DEBITO
                    {
                        FormPagVta1(dr);
                    }
                    else //NOTA DE CREDITO
                    {
                        FormPagVta1(dr);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + dr["vta_cpbte"] + ".");
            }
        }//

        private void Proc_CpbteVtaServ(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{dr["vta_tipmov"]}' And ast_cbte = '{dr["vta_cpbte"]}'");
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

                if (Convert.ToInt32(dr["vta_tipmov"]) == 2)
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
                ds3 = AccesoBase.ListarDatos($"Select cli_codigo, ser_ctacont, coc_cccta, Sum(hin_calculo) as total From SE_HistoNovedad Left Join Cliente on hin_ctacli = cli_codigo Left Join (SE_Servicio Left Join ConceptoCont on ser_conceptocont = coc_codigo) on hin_servicio = ser_codigo Where hin_tipmov = {dr["vta_tipmov"]} And hin_ctacli = {dr["vta_ctacli"]} And hin_cpbte = '{dr["vta_cpbte"]}' Group By cli_codigo, ser_ctacont, coc_cccta");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    Proc_CpbteTKVta(dr);
                    return;
                }

                double total = ds3.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds3.Tables[0].Rows[0]["total"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["ser_ctacont"]), d, (total * cotizacion).ToString(), "", 1, ds3.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["coc_cccta"]));

                ds3 = AccesoBase.ListarDatos($"Select cli_codigo, con_ctacont, Sum(hin_calculo) as total From SE_HistoNovedad Left Join Cliente on hin_ctacli = cli_codigo Left Join SE_ConceptoF on hin_concepto = con_codigo And con_servicio = hin_servicio Left Join SE_Servicio on hin_servicio = ser_codigo Where hin_tipmov = {dr["vta_tipmov"]} And hin_ctacli = {dr["vta_ctacli"]} And hin_cpbte = '{dr["vta_cpbte"]}' Group By cli_codigo, con_ctacont");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), Convert.ToInt32(dr3["con_ctacont"]), h, (Convert.ToDouble(dr3["total"]) * cotizacion).ToString(), "", 2);
                }

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
                double debe = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                ds4 = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
                double haber = ds4.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds4.Tables[0].Rows[0]["total"]);

                double dif = debe - haber;

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["vta_fecemi"].ToString(), "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Servicios " + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private void Proc_CpbteTKVta(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["vta_tipmov"]} And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0 || Convert.ToDouble(dr["vta_total"]) == 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(dr["vta_tipmov"]) != 2 || Convert.ToInt32(dr["vta_tipmov"]) == 10)
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
                ds3 = AccesoBase.ListarDatos($"Select * From DetCtaContVta Where dcc_codigo = {dr["vta_codigo"]}");
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = Negocio.Funciones.Generales.FAuditoriaInternaMenu.FechaCont() == false ? dr["vta_fecpro"].ToString() : dr["vta_fecemi"].ToString();

                if (Convert.ToDouble(dr["vta_neto21"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto1"]), d, dr["vta_neto21"].ToString(), "", 1);
                }

                if (Convert.ToDouble(dr["vta_neto27"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto3"]), d, dr["vta_neto27"].ToString(), "", 16);
                }

                if (Convert.ToDouble(dr["vta_neto10"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaneto2"]), d, dr["vta_neto10"].ToString(), "", 17);
                }

                if (Convert.ToDouble(dr["vta_exento"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaexento"]), d, dr["vta_exento"].ToString(), "", 2);
                }
                else if (Convert.ToDouble(dr["vta_exento"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaexento"]), h, (Convert.ToDouble(dr["vta_exento"]) * -1).ToString(), "", 2);
                }

                if (Convert.ToDouble(dr["vta_iva27"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva3"]), d, dr["vta_iva27"].ToString(), "", 18);
                }

                if (Convert.ToDouble(dr["vta_iva21"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva1"]), d, dr["vta_iva21"].ToString(), "", 3);
                }

                if (Convert.ToDouble(dr["vta_iva10"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaiva2"]), d, dr["vta_iva10"].ToString(), "", 4);
                }

                if (Convert.ToDouble(dr["vta_impint"]) > 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaimpint"]), d, dr["vta_impint"].ToString(), "", 5);
                }
                else if (Convert.ToDouble(dr["vta_impint"]) < 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctaimpint"]), h, (Convert.ToDouble(dr["vta_iva10"]) * -1).ToString(), "", 5);
                }

                if (Convert.ToDouble(dr["vta_formpag"]) == 2)
                {
                    if (Convert.ToDouble(dr["vta_total"]) > 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds3.Tables[0].Rows[0]["dcc_ctatotal"]), h, dr["vta_total"].ToString(), "", 15);
                    }
                }
                else
                {
                    if (Convert.ToDouble(dr["tmo_ctrl"]) == 1) //FACTURA y NOTA DE DEBITO
                    {
                        FormPagVta1(dr);
                    }
                    else //NOTA DE CREDITO
                    {
                        FormPagVta1(dr);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta" + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private void Proc_LiquiPAdm(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{dr["vta_tipmov"]}' And ast_cbte = '{dr["vta_cpbte"]}'");
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
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
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
                    CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                }

                long Contrapartida = 0;
                if (dr["vta_contrap"] is DBNull || Convert.ToInt32(dr["vta_contrap"]) == 0)
                {
                    if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                    {
                        Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        Contrapartida = CtaCaja;
                    }
                }

                long CtaAnticipo = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaAnticipoVta"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = Negocio.Funciones.Generales.FAuditoriaInternaMenu.FechaCont() == false ? dr["vta_fecpro"].ToString() : dr["vta_fecemi"].ToString();

                int n = 1;
                if (Convert.ToInt32(dr["vta_iva"]) < 3) //se calcula de los importes neto
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total) As total From MovArticLP Where his_codigo = {dr["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * (dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(dr3["total"]), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToInt32(dr3["his_ctacont"]), h, Math.Round((neto1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArticLP Where his_codigo = {dr["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * (dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"]) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(dr3["total"]), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToInt32(dr3["his_ctacont"]), h, Math.Round((neto1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }

                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"Select * From CondIva Where iva_codigo = {dr["vta_iva"]}");

                ds3 = AccesoBase.ListarDatos($"Select his_aliva, Sum(his_total) As Tot From MovArticLP Left Join AliIva on ali_porc = his_aliva Where ali_ctacont is null And his_codigo = {dr["vta_codigo"]} Group by his_aliva");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                    MensajeError("Atención: No han sido Definidas la Cuentas Contables de Débito Fiscal.");
                    return;
                }

                if (Convert.ToInt32(dr["vta_iva"]) < 3) //se calcula los importes de iva debito
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_aliva, ali_ctacont, Sum(his_total) As Total From MovArticLP Left Join AliIva on ali_porc = his_aliva Where his_aliva <> 0 And his_codigo = {dr["vta_codigo"]} Group by his_aliva, ali_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * (dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2) * (Convert.ToDouble(dr3["his_aliva"]) / 100), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["ali_ctacont"]), h, Math.Round((iva1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArticLP Where his_codigo = {dr["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * (dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2) * (Convert.ToDouble(dr3["his_aliva"]) / 100), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["ali_ctacont"]), h, Math.Round((iva1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }

                n += 1;

                ImpInt = dr["vta_impint"] is DBNull ? 0 : Convert.ToDouble(dr["vta_impint"]);
                if (ImpInt != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaImpIntVta, h, Math.Round((ImpInt * cotizacion), 2).ToString(), "", n);
                }

                if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAnticipo, d, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n);
                }
                else
                {
                    if (Convert.ToInt32(dr["tmo_ctrl"]) == 1) //factura y nota de debito
                    {
                        FormPagVta1(dr);
                    }
                    else //nota de credito
                    {
                        FormPagVta2(dr);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente Liquido Producto " + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private void Proc_LiquiP(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{dr["vta_tipmov"]}' And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"Select * From MovArticLP Where his_codigo = {dr["vta_codigo"]}");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    Proc_LiquiPAdm(dr);
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
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                DataSet ds4 = new DataSet();
                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {dr["vta_seccion"]}");
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
                    CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                }

                long Contrapartida = 0;
                if (dr["vta_contrap"] is DBNull || Convert.ToInt32(dr["vta_contrap"]) == 0)
                {
                    if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                    {
                        Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                    }
                    else
                    {
                        Contrapartida = CtaCaja;
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                int n = 1;

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{dr["vta_fecpro"]}', {dr["coc_ctacont"]}, {h}, sum(cel_importe), '', {n} FROM SE_Celular WHERE cel_LP = '{dr["vta_cpbte"]}'");

                n += 1;

                ds3 = AccesoBase.ListarDatos($"Select cel_aliva as Aliva, ali_ctacont, Sum(cel_iva) as iva From SE_Celular Left Join CondIva on iva_codigo = cel_condiva Left Join AliIva on cel_aliva = ali_porc Where cel_LP = '{dr["vta_cpbte"]}' Group By cel_aliva, ali_ctacont ");
                foreach (DataRow dr3 in ds3.Tables[0].Rows) //se calcula los importes de iva debito
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ali_ctacont"]), h, Math.Round(Convert.ToDouble(dr3["iva"]), 2).ToString(), "", n);
                    n += 1;
                }

                if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                {
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{dr["vta_fecpro"]}', {CtaDeuda}, {d}, sum(cel_importe + cel_iva), '', {n} FROM SE_Celular WHERE cel_LP = '{dr["vta_cpbte"]}'");
                }
                else
                {
                    AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) select {terminal}, 1, '{dr["vta_fecpro"]}', {CtaCaja}, {d}, sum(cel_importe + cel_iva), '', {n} FROM SE_Celular WHERE cel_LP = '{dr["vta_cpbte"]}'");
                }

                double dif = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Diferencia(terminal, d, h);

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["vta_fecpro"].ToString(), "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private long CtaIvaD(double Alicuota, long Cuenta, int seccion)
        {
            if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion() == false)
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
        }//

        private void Proc_CpbteVta(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = {dr["vta_tipmov"]} And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                ds2 = AccesoBase.ListarDatos($"SELECT his_ctacont, sum(his_total) as total FROM MovArtic WHERE his_codigo = {dr["vta_codigo"]} GROUP BY his_ctacont");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Proc_CpbteVtaServ(dr);
                    return;
                }

                double ImpInt = 0;
                double dto = 0;
                double neto1 = 0;
                double iva1 = 0;

                int d = 0;
                int h = 0;

                if (Convert.ToInt32(dr["vta_tipmov"]) != 2)
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
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                DataSet ds4 = new DataSet();
                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion())
                {
                    ds4 = AccesoBase.ListarDatos($"Select * From Seccion Where sec_codigo = {dr["vta_seccion"]}");
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
                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.FiltroSeccion())
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
                            CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                        }
                        else
                        {
                            CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds4.Tables[0].Rows[0]["sec_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                        }
                    }

                    if (dr["vta_contrap"] is DBNull || Convert.ToDouble(dr["vta_contrap"]) == 0)
                    {
                        if (Convert.ToInt32(dr["vta_formpag"]) == 2)
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
                        CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds4.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                    }

                    if (dr["vta_contrap"] is DBNull || Convert.ToDouble(dr["vta_contrap"]) == 0)
                    {
                        if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                        {
                            Contrapartida = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                        }
                        else
                        {
                            Contrapartida = CtaCaja;
                        }
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                string fecha = "";
                if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                {
                    fecha = dr["vta_fecemi"].ToString();
                }
                else
                {
                    fecha = dr["vta_fecpro"].ToString();
                }

                int n = 1;
                if (Convert.ToInt32(dr["vta_iva"]) < 3) //se calcula de los importes neto
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total) As total From MovArtic Where his_codigo = {dr["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * ((dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"])) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToInt32(dr3["his_ctacont"]), h, Math.Round((neto1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_ctacont, Sum(his_total / (1 + (his_aliva / 100.0))) As total From MovArtic Where his_codigo = {dr["vta_codigo"]} Group by his_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * ((dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"])) / 100), 2);
                        neto1 = Convert.ToDouble(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["his_ctacont"]) == 0 ? CtaNetoVta : Convert.ToInt32(dr3["his_ctacont"]), h, Math.Round((neto1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }

                DataSet ds5 = new DataSet();
                ds5 = AccesoBase.ListarDatos($"Select * From CondIva Where iva_codigo = {dr["vta_iva"]}");

                ds3 = AccesoBase.ListarDatos($"Select his_aliva, Sum(his_total) As total From MovArtic Left Join AliIva on ali_porc = his_aliva Where ali_ctacont is null And his_codigo = {dr["vta_codigo"]} Group by his_aliva");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                    MensajeError("Atención: No han sido Definidas la Cuentas Contables de Debito Fiscal.");
                    return;
                }

                if (Convert.ToInt32(dr["vta_iva"]) < 3) //se calcula los importes de iva debito
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_aliva, ali_ctacont, Sum(his_total) As total From MovArtic Left Join AliIva on ali_porc = his_aliva Where his_aliva <> 0 And his_codigo = {dr["vta_codigo"]} Group by his_aliva, ali_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * ((dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"])) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2) * (Convert.ToDouble(dr3["his_aliva"]) / 100), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaIvaD(Convert.ToDouble(dr3["his_aliva"]), Convert.ToInt64(dr3["ali_ctacont"]), Convert.ToInt32(dr["vta_seccion"])), h, Math.Round((iva1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }
                else
                {
                    ds3 = AccesoBase.ListarDatos($"Select his_aliva, ali_ctacont, Sum(his_total) As Total From MovArtic Left Join AliIva on ali_porc = his_aliva Where his_aliva <> 0 And his_codigo = {dr["vta_codigo"]} Group by his_aliva, ali_ctacont");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        dto = Math.Round(Math.Round(Convert.ToDouble(dr3["total"]), 2) * (dr["vta_dtoporc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_dtoporc"]) / 100), 2);
                        iva1 = Convert.ToDouble(Math.Round(Math.Round(Convert.ToDouble(dr3["total"]) - dto, 2) * (Convert.ToDouble(dr3["his_aliva"]) / 100), 2).ToString("N2"));
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaIvaD(Convert.ToDouble(dr3["his_aliva"]), Convert.ToInt64(dr3["ali_ctacont"]), Convert.ToInt32(dr["vta_seccion"])), h, Math.Round((iva1 * cotizacion), 2).ToString(), "", n);
                        n += 1;
                    }
                }

                n += 1;

                ImpInt = dr["vta_impint"] is DBNull ? 0 : Convert.ToDouble(dr["vta_impint"]);

                if (ImpInt != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaImpIntVta, h, Math.Round((ImpInt * cotizacion), 2).ToString(), "", n);
                }

                n += 1;

                ds3 = AccesoBase.ListarDatos($"Select otr_ctacont, otr_descri, Sum(otr_importe) as total From HistoOtrosTributosVta Where otr_importe <> 0 and otr_codigo = {dr["vta_codigo"]} Group By otr_ctacont, otr_descri");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr3["otr_ctacont"]), h, (dr3["total"] is DBNull ? 0 : Convert.ToDouble(dr3["total"])).ToString(), dr3["otr_descri"] is DBNull ? "" : dr3["otr_descri"].ToString().Substring(0, 80), n);
                    n += 1;
                }

                double anticipo = 0;

                DataSet ds6 = new DataSet();

                if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                {
                    if (Convert.ToInt32(dr["vta_tipmov"]) != 2)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaDeuda, d, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n, (dr["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr["coc_cccta"])));
                    }
                    else
                    {
                        if (ParConceptoUnico == 0)
                        {
                            anticipo = 0;

                            ds6 = AccesoBase.ListarDatos($"Select Sum(cta_total) as total From MovCtaCteVta Where (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}'");
                            if (ds6.Tables[0].Rows.Count != 0)
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAnticipo, d, ((ds6.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["total"])) * cotizacion).ToString(), "", n);
                                anticipo = (ds6.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds6.Tables[0].Rows[0]["total"])) * cotizacion;
                            }

                            n += 1;

                            ds6 = AccesoBase.ListarDatos($"Select (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End) as rbo_contrap, Sum(cta_total) as pago From MovCtaCteVta Left Join (MovVta Left Join Seccion on vta_seccion = sec_codigo) on (CONVERT(VARCHAR,vta_tipmov) + vta_cpbte) = left(cta_referencia,14) And cta_ctacli = vta_ctacli Where Not (cta_referencia is null or cta_referencia = '' or cta_referencia = 'A CUENTA') And cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' Group By (Case When IsNUll(vta_contrap,0) = 0 Then IsNUll(sec_ctaDeud,0) Else IsNUll(vta_contrap,0) End)");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, (Convert.ToInt64(dr6["rbo_contrap"]) == 0 ? CtaDeuda : Convert.ToInt64(dr6["rbo_contrap"])), d, (dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])).ToString(), "", n);
                                n += 1;
                            }
                        }
                        else
                        {
                            ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join MovVta on LEFT(cta_referencia,1) = vta_tipmov And SUBSTRING(cta_referencia,2,14) = vta_cpbte And cta_ctacli = vta_ctacli Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on vta_conceptocont = coc_codigo Where cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' And not (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr6["pcu_cuenta"]), d, ((dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])) * cotizacion).ToString(), "", n, (dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"])));
                                n += 1;
                            }

                            long CtaAUsar = 0;

                            ds6 = AccesoBase.ListarDatos($"Select pcu_cuenta, coc_cccta, Sum(cta_total) as Pago From MovCtaCteVta Left Join (ConceptoCont Left Join PCuenta on coc_contrap = pcu_cuenta) on cta_conceptocont = coc_codigo Where cta_tipmov = {dr["vta_tipmov"]} And cta_cpbte = '{dr["vta_cpbte"]}' And (cta_referencia = '' or cta_referencia is null or cta_referencia = 'A CUENTA') Group By pcu_cuenta, coc_cccta");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.ConceptoACuenta() == false)
                                {
                                    CtaAUsar = CtaAnticipo;
                                }
                                else
                                {
                                    CtaAUsar = dr6["pcu_cuenta"] is DBNull ? CtaAnticipo : Convert.ToInt64(dr6["pcu_cuenta"]);
                                }
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaAUsar, d, ((dr6["pago"] is DBNull ? 0 : Convert.ToDouble(dr6["pago"])) * cotizacion).ToString(), "", n, (dr6["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(dr6["coc_cccta"])));
                                n += 1;
                            }
                        }
                        AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());
                    }
                }
                else
                {
                    if (Convert.ToInt32(dr["tmo_ctrl"]) == 1) //factura y nota de debito
                    {
                        FormPagVta1(dr);
                    }
                    else //nota de credito
                    {
                        FormPagVta2(dr);
                    }
                }

                AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = Round(aux_importe * {"*"},2) Where aux_terminal = {terminal}", cotizacion.ToString());

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. VTA." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + dr["vta_cpbte"].ToString() + ".");
            }
        }//

        private void FormPagVta1(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
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

                if (!(dr["vta_valores"] is DBNull) && Convert.ToDouble(dr["vta_valores"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaChet, 1, (Convert.ToDouble(dr["vta_valores"]) * cotizacion).ToString(), "", 1);
                }

                if (!(dr["vta_tc"] is DBNull) && Convert.ToDouble(dr["vta_tc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, Sum(tcc_importe) as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = {dr["vta_tipmov"]} And tcc_cpbte = '{dr["vta_cpbte"]}' Group By tcc_tarjeta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 2);
                    }
                }

                if (!(dr["vta_gasto"] is DBNull) && Convert.ToDouble(dr["vta_gasto"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["vta_gasto"]) * cotizacion).ToString(), "", 3);
                }

                if (!(dr["vta_efectivo"] is DBNull) && Convert.ToDouble(dr["vta_efectivo"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["vta_efectivo"]) * cotizacion).ToString(), "", 4);
                }

                DataSet ds3 = new DataSet();
                if (!(dr["vta_retgan"] is DBNull) && Convert.ToDouble(dr["vta_retgan"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 3 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(dr3["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetGan, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetGan, 1, (Convert.ToDouble(dr["vta_retgan"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (!(Convert.ToInt32(dr["vta_tipmov"]) == 1 || Convert.ToInt32(dr["vta_tipmov"]) == 2))
                {
                    if (!(dr["vta_retiibb"] is DBNull) && Convert.ToDouble(dr["vta_retiibb"]) != 0)
                    {
                        ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 2 Group By ret_ctacont");
                        if (ds3.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr3 in ds3.Tables[0].Rows)
                            {
                                if (!(dr3["ret_ctacont"] is DBNull))
                                {
                                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 6);
                                }
                                else
                                {
                                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetIIBB, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 6);
                                }
                            }
                        }
                        else
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetIIBB, 1, (Convert.ToDouble(dr["vta_retiibb"]) * cotizacion).ToString(), "", 6);
                        }
                    }
                }

                if (!(dr["vta_retiva"] is DBNull) && Convert.ToDouble(dr["vta_retiva"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 1 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(dr3["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 7);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetIVA, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 7);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetIVA, 1, (Convert.ToDouble(dr["vta_retiva"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (!(dr["vta_retsuss"] is DBNull) && Convert.ToDouble(dr["vta_retsuss"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 4 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(dr3["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 8);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetSuss, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 8);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetSuss, 1, (Convert.ToDouble(dr["vta_retsuss"]) * cotizacion).ToString(), "", 8);
                    }
                }

                if (!(dr["vta_retBF"] is DBNull) && Convert.ToDouble(dr["vta_retBF"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 5 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(dr3["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 9);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 9);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr["vta_retBF"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (!(dr["vta_retmun"] is DBNull) && Convert.ToDouble(dr["vta_retmun"]) != 0)
                {
                    ds3 = AccesoBase.ListarDatos($"Select ret_ctacont, Sum(ret_total) as total From Retencion Where ret_recibo = '{dr["vta_cpbte"]}' And ret_tipmov = {dr["vta_tipmov"]} And ret_tipret = 9 Group By ret_ctacont");
                    if (ds3.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            if (!(dr3["ret_ctacont"] is DBNull))
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr3["ret_ctacont"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 10);
                            }
                            else
                            {
                                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 10);
                            }
                        }
                    }
                    else
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaRetBF, 1, (Convert.ToDouble(dr["vta_retmun"]) * cotizacion).ToString(), "", 10);
                    }
                }

                if (!(dr["vta_ticket"] is DBNull) && Convert.ToDouble(dr["vta_ticket"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["vta_ticket"]) * cotizacion).ToString(), "", 11);
                }

                if (!(dr["vta_dep"] is DBNull) && Convert.ToDouble(dr["vta_dep"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = {dr["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 12);
                    }

                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = {dr["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 1, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 12);
                    }
                }

                if (!(dr["vta_vlte"] is DBNull) && Convert.ToDouble(dr["vta_vlte"]) != 0 || !(dr["vta_vltc"] is DBNull) && Convert.ToDouble(dr["vta_vltc"]) != 0)
                {
                    double suma = (dr["vta_vltc"] is DBNull ? 0 : Convert.ToDouble(dr["vta_vltc"])) + (dr["vta_vlte"] is DBNull ? 0 : Convert.ToDouble(dr["vta_vlte"]));

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 2, (suma * cotizacion).ToString(), "", 13);
                }

            }
            catch (Exception)
            {
                MensajeError("Atención: Ha Ocurrido un Error!");
            }
        }//

        private void FormPagVta2(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds2.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds2 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaRetBF = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetBF"]);
                long CtaProv = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaProv"]);

                if (!(dr["vta_valores"] is DBNull) && Convert.ToDouble(dr["vta_valores"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaChet, 2, (Convert.ToDouble(dr["vta_valores"]) * cotizacion).ToString(), "", 1);
                }

                if (!(dr["vta_tc"] is DBNull) && Convert.ToDouble(dr["vta_tc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select chp_nroban, chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_tipmov = {dr["vta_tipmov"]} And chp_ordpag = '{dr["vta_cpbte"]}' Group By chp_nroban, chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 2);
                    }
                }

                if (!(dr["vta_efectivo"] is DBNull) && Convert.ToDouble(dr["vta_efectivo"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 2, (Convert.ToDouble(dr["vta_efectivo"]) * cotizacion).ToString(), "", 3);
                }

                if (!(dr["vta_dep"] is DBNull) && Convert.ToDouble(dr["vta_dep"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = {dr["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                    }

                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["vta_cpbte"]}' And mba_tipmovref = {dr["vta_tipmov"]} Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (!(dr["vta_devtc"] is DBNull) && Convert.ToDouble(dr["vta_devtc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select * From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_refanula = '{dr["vta_tipmov"]}{dr["vta_cpbte"]}'");
                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), Convert.ToInt32(ds2.Tables[0].Rows[0]["tar_ctacont"]), 2, (Convert.ToDouble(dr["vta_devtc"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (!(dr["vta_vlte"] is DBNull) && Convert.ToDouble(dr["vta_vlte"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 1, (Convert.ToDouble(dr["vta_vlte"]) * cotizacion).ToString(), "", 6);
                }

                if (!(dr["vta_ticket"] is DBNull) && Convert.ToDouble(dr["vta_ticket"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 2, (Convert.ToDouble(dr["vta_ticket"]) * cotizacion).ToString(), "", 7);
                }

                if (!(dr["vta_gasto"] is DBNull) && Convert.ToDouble(dr["vta_gasto"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecpro"].ToString(), CtaCaja, 2, (Convert.ToDouble(dr["vta_gasto"]) * cotizacion).ToString(), "", 8);
                }
            }
            catch (Exception)
            {
                MensajeError("Atención: Ha Ocurrido un Error!");
            }
        }//

        private void Proc_MovIntVta(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "vta_cotizacion");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_tipocbte = '{dr["vta_tipmov"]}' And ast_cbte = '{dr["vta_cpbte"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 0;
                int h = 0;

                if (Convert.ToInt32(dr["vta_tipmov"]) != 4)
                {
                    d = 1;
                    h = 2;
                }
                else
                {
                    d = 2;
                    h = 1;
                }

                if (dr["vta_caja"] is DBNull)
                {
                    return;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {dr["vta_caja"]}");
                long CtaCaja = Convert.ToInt64(ds3.Tables[0].Rows[0]["caj_ctacont"]);

                ds3 = AccesoBase.ListarDatos($"Select * From ParamContab");

                long CtaDeuda = 0;
                if (ParConceptoUnico == 0)
                {
                    CtaDeuda = Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]);
                }
                else
                {
                    CtaDeuda = dr["vta_contrap"] is DBNull ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : dr["vta_contrap"].ToString() == "0" ? Convert.ToInt64(ds3.Tables[0].Rows[0]["par_ctaDeud"]) : Convert.ToInt64(dr["vta_contrap"]);
                }

                long Contrapartida = 0;
                if ((dr["vta_contrap"] is DBNull ? 0 : Convert.ToInt64(dr["vta_contrap"])) == 0)
                {
                    if (Convert.ToInt32(dr["vta_formpag"]) == 2)
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
                    Contrapartida = dr["vta_contrap"] is DBNull ? 0 : Convert.ToInt64(dr["vta_contrap"]);
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                int n = 1;

                if (ParConceptoUnico == 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), Contrapartida, h, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n);
                }
                else
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), Convert.ToInt32(ds3.Tables[0].Rows[0]["coc_ctacont"]), h, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n, ds3.Tables[0].Rows[0]["coc_cccta"] is DBNull ? 0 : Convert.ToInt32(ds3.Tables[0].Rows[0]["coc_cccta"]));
                }

                n += 1;

                if (Convert.ToInt32(dr["vta_formpag"]) == 2)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), CtaDeuda, d, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n);
                }
                else
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, dr["vta_fecemi"].ToString(), CtaCaja, d, (Convert.ToDouble(dr["vta_total"]) * cotizacion).ToString(), "", n);
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                double dif = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Diferencia(terminal, d, h);

                if (dif != 0)
                {
                    AccesoBase.InsertUpdateDatosMoney($"Update Aux_Asiento Set aux_importe = aux_importe + {"*"} Where aux_terminal = {terminal} And aux_orden = 1 And aux_codigo = {h}", dif.ToString());
                }

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, dr["vta_fecemi"].ToString(), "REG. VTA. INT." + "Abreviado" + dr["vta_cpbte"].ToString() + "-" + dr["vta_cliente"].ToString(), 0, 0, Convert.ToInt32(dr["vta_tipmov"]), dr["vta_cpbte"].ToString(), 0, dr, "vta_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente el Comprobante de Venta " + dr["vta_cpbte"] + ".");
            }
        }//

        private bool CtrlDetTot(int tipo, int debe, string fecha, int orden, long codigo, double cotD)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select * From DetTotCpa Where dcp_tipo = {tipo} And dcp_codigo = {codigo}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["dcp_ctacont"]), debe, (Convert.ToDouble(dr["dcp_descri"]) * cotD).ToString(), dr["dcp_descri"].ToString(), orden);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//

        private void Proc_CPBTECpa(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {dr["cpa_ctapro"]} And ast_tipocbte = {dr["cpa_tipmov"]} And ast_cbte = '{dr["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 0; //debe
                int h = 0; //haber

                if (Convert.ToInt32(dr["cpa_tipmov"]) == 12)
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
                if (Convert.ToInt32(dr["cpa_condcpa"]) == 2)
                {
                    if (Convert.ToDateTime(dr["cpa_periodo"]) != Convert.ToDateTime(dr["cpa_feccont"].ToString().Substring(0, 7)))
                    {
                        fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(0, 2)), Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(dr["cpa_periodo"].ToString().Length - 4))) + "/" + dr["cpa_periodo"].ToString();
                    }
                    else
                    {
                        fecha = dr["cpa_feccont"].ToString();
                    }
                }
                else
                {
                    fecha = dr["cpa_fecha"].ToString();
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (dr["cpa_ctaneto"].ToString().Trim() != "" && (dr["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaneto"]), d, (Convert.ToDouble(dr["cpa_neto"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (dr["cpa_ctaexento"].ToString().Trim() != "" && (dr["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaexento"]), d, (Convert.ToDouble(dr["cpa_exento"]) * cotizacion).ToString(), "", 2);
                    }
                }

                if (dr["cpa_ctaiva21"].ToString().Trim() != "" && (dr["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva21"]), d, (Convert.ToDouble(dr["cpa_iva21"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (dr["cpa_ctaiva27"].ToString().Trim() != "" && (dr["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva27"]), d, (Convert.ToDouble(dr["cpa_iva27"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (dr["cpa_ctaiva10"].ToString().Trim() != "" && (dr["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva10"]), d, (Convert.ToDouble(dr["cpa_iva10"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (dr["cpa_ctaiva4"].ToString().Trim() != "" && (dr["cpa_ctaiva4"] is DBNull) == false) //iva4
                {
                    if (CtrlDetTot(16, d, fecha, 6, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva4"]), d, (Convert.ToDouble(dr["cpa_iva4"]) * cotizacion).ToString(), "", 6);
                    }
                }

                if (dr["cpa_ctaiva5"].ToString().Trim() != "" && (dr["cpa_ctaiva5"] is DBNull) == false) //iva5
                {
                    if (CtrlDetTot(17, d, fecha, 7, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva5"]), d, (Convert.ToDouble(dr["cpa_iva5"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (dr["cpa_ctaimpint"].ToString().Trim() != "" && (dr["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    if (CtrlDetTot(14, d, fecha, 8, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimpint"]), d, (Convert.ToDouble(dr["cpa_impint"]) * cotizacion).ToString(), "", 8);
                    }
                }

                if (dr["cpa_ctaretiva"].ToString().Trim() != "" && (dr["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    if (CtrlDetTot(7, d, fecha, 9, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiva"]), d, (Convert.ToDouble(dr["cpa_retiva"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (dr["cpa_ctaretiibb"].ToString().Trim() != "" && (dr["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    if (CtrlDetTot(8, d, fecha, 10, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiibb"]), d, (Convert.ToDouble(dr["cpa_retiibb"]) * cotizacion).ToString(), "", 10);
                    }
                }

                if (dr["cpa_ctaretgan"].ToString().Trim() != "" && (dr["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    if (CtrlDetTot(9, d, fecha, 11, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretgan"]), d, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 11);
                    }
                }

                if (dr["cpa_ctaperiva"].ToString().Trim() != "" && (dr["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    if (CtrlDetTot(10, d, fecha, 12, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiva"]), d, (Convert.ToDouble(dr["cpa_periva"]) * cotizacion).ToString(), "", 12);
                    }
                }

                if (dr["cpa_ctaperiibb"].ToString().Trim() != "" && (dr["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    if (CtrlDetTot(11, d, fecha, 13, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiibb"]), d, (Convert.ToDouble(dr["cpa_periibb"]) * cotizacion).ToString(), "", 13);
                    }
                }

                if (dr["cpa_ctapergan"].ToString().Trim() != "" && (dr["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    if (CtrlDetTot(12, d, fecha, 14, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctapergan"]), d, (Convert.ToDouble(dr["cpa_pergan"]) * cotizacion).ToString(), "", 14);
                    }
                }

                if (dr["cpa_ctamonotributo"].ToString().Trim() != "" && (dr["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    if (CtrlDetTot(13, d, fecha, 15, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctamonotributo"]), d, (Convert.ToDouble(dr["cpa_monotributo"]) * cotizacion).ToString(), "", 15);
                    }
                }

                if (dr["cpa_ctaotros"].ToString().Trim() != "" && (dr["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    if (CtrlDetTot(15, d, fecha, 16, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaotros"]), d, (Convert.ToDouble(dr["cpa_otros"]) * cotizacion).ToString(), "", 16);
                    }
                }

                if (dr["cpa_ctaimportacion"].ToString().Trim() != "" && (dr["cpa_ctaimportacion"] is DBNull) == false) //importacion
                {
                    if (CtrlDetTot(6, d, fecha, 17, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimportacion"]), d, (Convert.ToDouble(dr["cpa_importacion"]) * cotizacion).ToString(), "", 17);
                    }
                }

                //total
                if (!(dr["cpa_ctacpbte"].ToString().Trim() == "" && dr["cpa_ctacpbte"] is DBNull))
                {
                    if (Convert.ToInt32(dr["cpa_condcpa"]) == 2) //cta cte
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctacpbte"]), h, (Convert.ToDouble(dr["cpa_total"]) * cotizacion).ToString(), "", 18);
                    }
                    else //ctdo
                    {
                        if (Convert.ToInt32(dr["cpa_tipmov"]) == 12)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctacpbte"]), h, (Convert.ToDouble(dr["cpa_total"]) * cotizacion).ToString(), "", 18);
                        }
                        else //nc ctdo
                        {
                            FormPagCpa(dr);
                        }
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    //MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. CPA." + dr["cpa_nrocomp"].ToString() + "-" + dr["cpa_nombre"].ToString(), 0, 0, Convert.ToInt32(dr["cpa_tipmov"]), dr["cpa_nrocomp"].ToString(), Convert.ToInt32(dr["cpa_ctapro"]), dr, "cpa_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"].ToString() + ".");
            }
        }//

        private void Proc_LiquiCpa(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Asiento Where ast_ctapro = {dr["cpa_ctapro"]} And ast_tipocbte = {dr["cpa_tipmov"]} And ast_cbte = '{dr["cpa_nrocomp"]}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    return;
                }

                int d = 1; //debe
                int h = 2; //haber               

                string fecha = "";
                if (Convert.ToInt32(dr["cpa_condcpa"]) == 2)
                {
                    if (Convert.ToDateTime(dr["cpa_periodo"]) != Convert.ToDateTime(dr["cpa_feccont"].ToString().Substring(0, 7)))
                    {
                        fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(0, 2)), Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(dr["cpa_periodo"].ToString().Length - 4))) + "/" + dr["cpa_periodo"].ToString();
                    }
                    else
                    {
                        fecha = dr["cpa_feccont"].ToString();
                    }
                }
                else
                {
                    fecha = dr["cpa_fecha"].ToString();
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (dr["cpa_ctaneto"].ToString().Trim() != "" && (dr["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    if (CtrlDetTot(1, d, fecha, 1, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaneto"]), d, (Convert.ToDouble(dr["cpa_neto"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (dr["cpa_ctaexento"].ToString().Trim() != "" && (dr["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    if (CtrlDetTot(2, d, fecha, 2, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaexento"]), d, (Convert.ToDouble(dr["cpa_exento"]) * cotizacion).ToString(), "", 2);
                    }
                }

                if (dr["cpa_ctaiva21"].ToString().Trim() != "" && (dr["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    if (CtrlDetTot(3, d, fecha, 3, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva21"]), d, (Convert.ToDouble(dr["cpa_iva21"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (dr["cpa_ctaiva27"].ToString().Trim() != "" && (dr["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    if (CtrlDetTot(4, d, fecha, 4, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva27"]), d, (Convert.ToDouble(dr["cpa_iva27"]) * cotizacion).ToString(), "", 4);
                    }
                }

                if (dr["cpa_ctaiva10"].ToString().Trim() != "" && (dr["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    if (CtrlDetTot(5, d, fecha, 5, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaiva10"]), d, (Convert.ToDouble(dr["cpa_iva10"]) * cotizacion).ToString(), "", 5);
                    }
                }

                if (dr["cpa_ctaimpint"].ToString().Trim() != "" && (dr["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    if (CtrlDetTot(14, d, fecha, 6, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimpint"]), d, (Convert.ToDouble(dr["cpa_impint"]) * cotizacion).ToString(), "", 6);
                    }
                }

                if (dr["cpa_ctaretiva"].ToString().Trim() != "" && (dr["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    if (CtrlDetTot(7, d, fecha, 7, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiva"]), d, (Convert.ToDouble(dr["cpa_retiva"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (dr["cpa_ctaretiibb"].ToString().Trim() != "" && (dr["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    if (CtrlDetTot(8, d, fecha, 8, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretiibb"]), d, (Convert.ToDouble(dr["cpa_retiibb"]) * cotizacion).ToString(), "", 8);
                    }
                }

                if (dr["cpa_ctaretgan"].ToString().Trim() != "" && (dr["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    if (CtrlDetTot(9, d, fecha, 9, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaretgan"]), d, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 9);
                    }
                }

                if (dr["cpa_ctaperiva"].ToString().Trim() != "" && (dr["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    if (CtrlDetTot(10, d, fecha, 10, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiva"]), d, (Convert.ToDouble(dr["cpa_periva"]) * cotizacion).ToString(), "", 10);
                    }
                }

                if (dr["cpa_ctaperiibb"].ToString().Trim() != "" && (dr["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    if (CtrlDetTot(11, d, fecha, 11, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaperiibb"]), d, (Convert.ToDouble(dr["cpa_periibb"]) * cotizacion).ToString(), "", 11);
                    }
                }

                if (dr["cpa_ctapergan"].ToString().Trim() != "" && (dr["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    if (CtrlDetTot(12, d, fecha, 12, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctapergan"]), d, (Convert.ToDouble(dr["cpa_pergan"]) * cotizacion).ToString(), "", 12);
                    }
                }

                if (dr["cpa_ctamonotributo"].ToString().Trim() != "" && (dr["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    if (CtrlDetTot(13, d, fecha, 13, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctamonotributo"]), d, (Convert.ToDouble(dr["cpa_monotributo"]) * cotizacion).ToString(), "", 13);
                    }
                }

                if (dr["cpa_ctaotros"].ToString().Trim() != "" && (dr["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    if (CtrlDetTot(15, d, fecha, 14, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaotros"]), d, (Convert.ToDouble(dr["cpa_otros"]) * cotizacion).ToString(), "", 14);
                    }
                }

                if (dr["cpa_ctaimportacion"].ToString().Trim() != "" && (dr["cpa_ctaimportacion"] is DBNull) == false) //importacion
                {
                    if (CtrlDetTot(6, d, fecha, 15, Convert.ToInt64(dr["cpa_codigo"]), cotizacion) == false)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctaimportacion"]), d, (Convert.ToDouble(dr["cpa_importacion"]) * cotizacion).ToString(), "", 15);
                    }
                }

                //total
                if (!(dr["cpa_ctacpbte"].ToString().Trim() == "" || dr["cpa_ctacpbte"] is DBNull))
                {
                    if (Convert.ToInt32(dr["cpa_condcpa"]) == 2) //cta cte
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctacpbte"]), h, (Convert.ToDouble(dr["cpa_total"]) * cotizacion).ToString(), "", 16);
                    }
                    else //ctdo
                    {
                        if (Convert.ToInt32(dr["cpa_tipmov"]) == 12) //nc ctdo
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr["cpa_ctacpbte"]), h, (Convert.ToDouble(dr["cpa_total"]) * cotizacion).ToString(), "", 16);
                        }
                        else
                        {
                            FormPagCpa(dr);
                        }
                    }
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Update(terminal);

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    MensajeError("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AsientoFinal = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Insert(terminal, fecha, "REG. CPA." + dr["cpa_nrocomp"].ToString() + "-" + dr["cpa_nombre"].ToString(), 0, 0, Convert.ToInt32(dr["cpa_tipmov"]), dr["cpa_nrocomp"].ToString(), Convert.ToInt32(dr["cpa_ctapro"]), dr, "cpa_tipmov");
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MensajeError("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + dr["cpa_nrocomp"] + ".");
            }
        }//

        private void FormPagCpa(DataRow dr)
        {
            try
            {
                double cotizacion = Negocio.Funciones.Generales.FAuditoriaInternaMenu.Cotizacion(dr, "cpa_cotiz");

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT * FROM Caja WHERE caj_codigo = {dr["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);
                long CtaChet = ds2.Tables[0].Rows[0]["caj_ctaCheT"] is DBNull ? Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]) : Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctaCheT"]);

                ds2 = AccesoBase.ListarDatos($"SELECT * FROM ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaRetBF = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretBFP"]);
                long CtaProv = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaProv"]);

                string fecha = "";

                if (Convert.ToDateTime(dr["cpa_periodo"]) != Convert.ToDateTime(dr["cpa_feccont"].ToString().Substring(0, 7)))
                {
                    fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(0, 2)), Convert.ToInt32(dr["cpa_periodo"].ToString().Substring(dr["cpa_periodo"].ToString().Length - 4))) + "/" + dr["cpa_periodo"].ToString();
                }
                else
                {
                    fecha = dr["cpa_feccont"].ToString();
                }

                if (!(dr["cpa_tottercero"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottercero"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaChet, 2, (Convert.ToDouble(dr["cpa_tottercero"]) * cotizacion).ToString(), "", 1);
                    }
                }

                if (!(dr["cpa_tottercero"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottercero"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{dr["cpa_nrocomp"]}' And chp_tipmov = {dr["cpa_tipmov"]}");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 2);
                        }
                    }
                }

                if (!(dr["cpa_totefectivo"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_totefectivo"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (Convert.ToDouble(dr["cpa_totefectivo"]) * cotizacion).ToString(), "", 3);
                    }
                }

                if (!(dr["cpa_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_retgan"]) != 0)
                    {
                        if (!(Convert.ToInt32(dr["cpa_tipmov"]) == 11 || Convert.ToInt32(dr["cpa_tipmov"]) == 12 || Convert.ToInt32(dr["cpa_tipmov"]) == 13))
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetGan, 2, (Convert.ToDouble(dr["cpa_retgan"]) * cotizacion).ToString(), "", 4);
                        }
                    }
                }

                if (!(dr["cpa_tottransf"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottransf"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["cpa_tipmov"]}{dr["cpa_tipmov"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                        }

                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{dr["cpa_tipmov"]}{dr["cpa_tipmov"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, (Convert.ToDouble(dr["total"]) * cotizacion).ToString(), "", 5);
                        }
                    }
                }

                if (((dr["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvuelto"])) + (dr["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvueltoC"]))) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, (((dr["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvuelto"])) + (dr["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(dr["cpa_totvueltoC"]))) * cotizacion).ToString(), "", 6);
                }

                if (!(dr["cpa_tottickets"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_tottickets"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (Convert.ToDouble(dr["cpa_tottickets"]) * cotizacion).ToString(), "", 7);
                    }
                }

                if (!(dr["cpa_totgasto"] is DBNull))
                {
                    if (Convert.ToDouble(dr["cpa_totgasto"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, (Convert.ToDouble(dr["cpa_totgasto"]) * cotizacion).ToString(), "", 8);
                    }
                }
            }
            catch (Exception)
            {
                MensajeError("Atención: Ha Ocurrido un Error!");
            }
        }//

        private bool Ctrl()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select * From ParamContab");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MensajeError("Atención: Antes de poder generar los Asientos deberá indicar los Parámetros Contables.");
                return false;
            }
            return true;
        }//

        private void MensajeError(string msg)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", msg, false, true);
            MessageBox.ShowDialog();
        }

        private void btnCtaCont_Click(object sender, EventArgs e) //para traer el nº de cuenta con su descripción.
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                txtNroCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                txtDescriCuenta.Text = frmBuscarCuenta.DescriCuenta;
            }
        }

        private void txtNroCuenta_TextChanged(object sender, EventArgs e) //para actualizar los txt cuando se ingresa/cambia un nro de cuenta.
        {
            timerCuenta.Start();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            maskDesde.Text = dtpDesde.Value.ToString();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            maskHasta.Text = dtpHasta.Value.ToString();
        }

        private void timerCuenta_Tick(object sender, EventArgs e)
        {
            timerCuenta.Stop();

            if (txtNroCuenta.Text == "")
            {
                txtNroCuenta.Text = "";
                txtDescriCuenta.Text = "";
                return;
            }

            DataSet ds = new DataSet();
            if (frmBuscarCuenta.ValidacionMovimientos(Convert.ToInt32(txtNroCuenta.Text)))
            {
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
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                MessageBox.ShowDialog();
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
