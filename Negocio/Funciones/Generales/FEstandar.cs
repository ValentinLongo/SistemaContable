using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Generales
{
    public class FEstandar
    {

        public static void Procesos(int proceso, [Optional] Control Mensaje, [Optional] int terminal, [Optional] DateTime desde, [Optional] DateTime hasta)
        {
            if (proceso == 2) // Auditoria Interna
            {
                AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_AuditInt WHERE aux_terminal = {terminal}");

                Cursor.Current = Cursors.WaitCursor;

                Application.DoEvents();

                Mensaje.Text = "Controlando CONTABILIDAD (1/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 29, 'COMPRAS CON MAS DE UN ASIENTO', 1, cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, cpa_total, 0, 0, 0, 0, 1, 0 From MovCpa Left Join Asiento on cpa_tipmov = ast_tipocbte And cpa_nrocomp = ast_cbte And cpa_ctapro = ast_ctapro Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And (cpa_feccont >= '{desde}' And cpa_feccont <= '{hasta}') Group By cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, cpa_total HAVING Count(ast_asiento) > 1 ");

                Mensaje.Text = "Controlando CONTABILIDAD (2/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 30, 'VENTAS CON MAS DE UN ASIENTO', 1, vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, vta_total, 0, 0, 0, 0, 1, 0 From MovVta Left Join Asiento on vta_tipmov = ast_tipocbte And vta_cpbte = ast_cbte Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And vta_fecpro <> '01/01/1990' and (vta_fecemi >= '{desde}' And vta_fecemi <= '{hasta}') Group By vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, vta_total HAVING Count(ast_asiento) > 1 ");

                Mensaje.Text = "Controlando CONTABILIDAD (3/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 31, 'TOTALES DE COMPRAS CONTRA TOTALES DE ASIENTOS (DEBE)', 1, cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, Round((((cpa_total + IsNull(cpa_totvuelto,0)) + IsNull(tcc_dto,0)) * (Case When cpa_moneda <> 1 Then IsNull(cpa_cotiz,0) Else 1 End)),2), 0, 0, 0, Sum(mva_importe) as TotalAsto, 1, 0 From MovCpa Left Join (Asiento Left Join MovAsto on ast_asiento = mva_asiento) on cpa_tipmov = ast_tipocbte And cpa_nrocomp = ast_cbte And cpa_ctapro = ast_ctapro Left Join (MovVtaTC Left Join Tarjeta on tcc_tarjeta = tar_codigo) on cpa_ctapro = tar_ctapro And tcc_cpbte = cpa_nrocomp And tcc_tipmov = 2 Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And mva_codigo = 1 And (cpa_feccont >= '{desde}' And cpa_feccont <= '{hasta}') Group By cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, cpa_total, cpa_totvuelto, cpa_cotiz, cpa_moneda, IsNull(tcc_dto,0) HAVING ABS(Sum(mva_importe) - Round((((cpa_total + IsNull(cpa_totvuelto,0)) + IsNull(tcc_dto,0)) * (Case When cpa_moneda <> 1 Then IsNull(cpa_cotiz,0) Else 1 End)),2) ) > 0.1 ");

                Mensaje.Text = "Controlando CONTABILIDAD TOTALES (1/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 32, 'TOTALES DE COMPRAS CONTRA TOTALES DE ASIENTOS (HABER)', 1, cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, Round((((cpa_total + IsNull(cpa_totvuelto,0)) + IsNull(tcc_dto,0)) * (Case When cpa_moneda <> 1 Then IsNull(cpa_cotiz,0) Else 1 End)),2), 0, 0, 0, Sum(mva_importe) as TotalAsto, 1, 0 From MovCpa Left Join (Asiento Left Join MovAsto on ast_asiento = mva_asiento) on cpa_tipmov = ast_tipocbte And cpa_nrocomp = ast_cbte And cpa_ctapro = ast_ctapro Left Join (MovVtaTC Left Join Tarjeta on tcc_tarjeta = tar_codigo) on cpa_ctapro = tar_ctapro And tcc_cpbte = cpa_nrocomp And tcc_tipmov = 2 Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And mva_codigo = 2 And (cpa_feccont >= '{desde}' And cpa_feccont <= '{hasta}') Group By cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, cpa_total, cpa_totvuelto, cpa_cotiz, cpa_moneda, IsNull(tcc_dto,0) HAVING ABS(Sum(mva_importe) - Round((((cpa_total + IsNull(cpa_totvuelto,0)) + IsNull(tcc_dto,0)) * (Case When cpa_moneda <> 1 Then IsNull(cpa_cotiz,0) Else 1 End)),2) ) > 0.1 ");

                Mensaje.Text = "Controlando CONTABILIDAD TOTALES (2/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 33, 'TOTALES DE VENTAS CONTRA TOTALES DE ASIENTOS (DEBE)', 1, vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, Round(((vta_total + (IsNull(vta_vlte,0) + IsNull(vta_vltc,0))) * (Case When vta_moneda <> 1 Then IsNull(vta_cotizacion,0) Else 1 End)),2), 0, 0, 0, Sum(mva_importe) as TotalAsto, 1, 0 From MovVTa Left Join (Asiento Left Join MovAsto on ast_asiento = mva_asiento) on vta_tipmov = ast_tipocbte And vta_cpbte = ast_cbte Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And mva_codigo = 1 And vta_fecpro <> '01/01/1990' and (vta_fecemi >= '{desde}' And vta_fecemi <= '{hasta}') Group By vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, vta_total, vta_vlte, vta_vltc, vta_cotizacion, vta_moneda HAVING ABS(Sum(mva_importe) - Round(((vta_total + (IsNull(vta_vlte,0) + IsNull(vta_vltc,0))) * (Case When vta_moneda <> 1 Then IsNull(vta_cotizacion,0) Else 1 End)),2)) > 0.1 ");

                Mensaje.Text = "Controlando CONTABILIDAD TOTALES (3/3). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 34, 'TOTALES DE VENTAS CONTRA TOTALES DE ASIENTOS (HABER)', 1, vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, Round(((vta_total + (IsNull(vta_vlte,0) + IsNull(vta_vltc,0))) * (Case When vta_moneda <> 1 Then IsNull(vta_cotizacion,0) Else 1 End)),2), 0, 0, 0, Sum(mva_importe) as TotalAsto, 1, 0 From MovVTa Left Join (Asiento Left Join MovAsto on ast_asiento = mva_asiento) on vta_tipmov = ast_tipocbte And vta_cpbte = ast_cbte Where ast_asiento is not null And Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And mva_codigo = 2 And vta_fecpro <> '01/01/1990' and (vta_fecemi >= '{desde}' And vta_fecemi <= '{hasta}') Group By vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, vta_total, vta_vlte, vta_vltc, vta_cotizacion, vta_moneda HAVING ABS(Sum(mva_importe) - Round(((vta_total + (IsNull(vta_vlte,0) + IsNull(vta_vltc,0))) * (Case When vta_moneda <> 1 Then IsNull(vta_cotizacion,0) Else 1 End)),2)) > 0.1 ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (1/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 35, 'ASIENTOS SIN DETALLE', 1, ast_fecha, 0, ast_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From Asiento Left Join MovAsto on ast_asiento = mva_asiento Where mva_asiento is null And (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (2/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 36, 'DETALLE DE ASIENTOS SIN ENCABEZADO', 1, mva_fecha, 0, mva_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From MovAsto Left Join Asiento on ast_asiento = mva_asiento Where ast_asiento is null And (mva_fecha >= '{desde}' And mva_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (3/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 37, 'DETALLE DE ASIENTOS SIN CORRESPONDECIA EN COMPRAS', 1, ast_fecha, 0, ast_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From Asiento Left Join MovCpa on ast_tipocbte = cpa_tipmov And ast_cbte = cpa_nrocomp And ast_ctapro = cpa_ctapro Where Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And Len(ast_cbte) >= 14 And cpa_codigo is null And (ast_tipocbte >= 11 And ast_tipocbte <= 21) And (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (4/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 38, 'DETALLE DE ASIENTOS SIN CORRESPONDECIA EN VENTAS', 1, ast_fecha, 0, ast_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From Asiento Left Join MovVta on ast_tipocbte = vta_tipmov And ast_cbte = vta_cpbte And vta_cliente <> 'ANULADO' Where Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And Len(ast_cbte) >= 14 And vta_codigo is null And (ast_tipocbte <= 10 or ast_tipocbte = 31 or ast_tipocbte = 53) And (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (5/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 39, 'NO CORRESPONDECIA DE FECHAS EN COMPRAS', 1, ast_fecha, 0, ast_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From Asiento Left Join MovCpa on ast_tipocbte = cpa_tipmov And ast_cbte = cpa_nrocomp And ast_ctapro = cpa_ctapro Where Len(ast_cbte) >= 14 And cpa_feccont <> ast_fecha And (ast_tipocbte >= 11 And ast_tipocbte <= 21) And (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (6/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 40, 'COMPRAS SIN ASIENTO', 1, cpa_fecha, cpa_ctapro, cpa_nrocomp, cpa_tipmov, cpa_total, 0, 0, 0, 0, 1, 0 From MovCpa Left Join Asiento on ast_tipocbte = cpa_tipmov And ast_cbte = cpa_nrocomp And ast_ctapro = cpa_ctapro Where cpa_total <> 0 And ast_asiento is null And cpa_tipmov <> 47 And (cpa_feccont >= '{desde}' And cpa_feccont <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (7/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 41, 'VENTAS SIN ASIENTO', 1, vta_fecpro, vta_ctacli, vta_cpbte, vta_tipmov, vta_total, 0, 0, 0, 0, 1, 0 From MovVta Left Join Asiento on ast_tipocbte = vta_tipmov And ast_cbte = vta_cpbte Where vta_total <> 0 And ast_asiento is null And vta_fecpro <> '01/01/1990' and (vta_fecemi >= '{desde}' And vta_fecemi <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (8/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 42, 'ING/EGR VARIOS SIN ASIENTO', 1, moc_fecpro, 0, moc_cpbte, Case When moc_tipmov = 6 Then 42 Else 43 End, moc_total, 0, 0, 0, 0, 1, 0 From MovimientoCaja Left Join Asiento on (Case When moc_tipmov = 6 Then 42 Else 43 End) = ast_tipocbte And moc_cpbte = ast_cbte Where (moc_tipmov = 54 or moc_tipmov = 6) And moc_cont = 1 And ast_asiento is NULL And (moc_fecpro >= '{desde}' And moc_fecpro <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (9/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 43, 'DEPOSITOS SIN ASIENTO', 1, mba_fecemi, 0, mba_cpbte, mba_tipmov, mba_importe, 0, 0, 0, 0, 1, 0 From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = RIGHT(('00000000' + ast_cbte),8) Where ast_asiento is NULL ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (10/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 44, 'MOV. VARIOS BANCARIOS SIN ASIENTO', 1, dcb_fecha, 0, dcb_cpbte, (Case When dcb_tipo = 1 Then 47 Else 48 End), dcb_total, 0, 0, 0, 0, 1, 0 From DebCredBan Left Join Asiento on (Case When dcb_tipo = 1 Then 47 Else 48 End) = ast_tipocbte And dcb_cpbte = ast_cbte Where ast_asiento is NULL And (dcb_fecha >= '{desde}' And dcb_fecha <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (11/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 45, 'ING/EGR VARIOS TOTAL CONTRA DEBE', 1, moc_fecpro, 0, moc_cpbte, Case When moc_tipmov = 6 Then 42 Else 43 End, Round(((moc_total + (moc_vlte + moc_vltc)) * IsNull(moc_cotizacion,0)),2), 0, 0, 0, 0, 1, 0 From MovimientoCaja Left Join Asiento on (Case When moc_tipmov = 6 Then 42 Else 43 End) = ast_tipocbte And moc_cpbte = ast_cbte Left Join (Select mva_asiento, Sum(mva_importe) as Total From MovAsto Where mva_codigo = 1 Group By mva_asiento) as X on ast_asiento = X.mva_asiento Where (moc_tipmov = 54 or moc_tipmov = 6) And moc_cont = 1 And ast_asiento is not NULL And abs(Round(((moc_total + (moc_vlte + moc_vltc)) * IsNull(moc_cotizacion,0)),2) - X.Total) > 0.01 And (moc_fecpro >= '{desde}' And moc_fecpro <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (12/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 46, 'ING/EGR VARIOS TOTAL CONTRA HABER', 1, moc_fecpro, 0, moc_cpbte, Case When moc_tipmov = 6 Then 42 Else 43 End, Round(((moc_total + (moc_vlte + moc_vltc)) * IsNull(moc_cotizacion,0)),2), 0, 0, 0, 0, 1, 0 From MovimientoCaja Left Join Asiento on (Case When moc_tipmov = 6 Then 42 Else 43 End) = ast_tipocbte And moc_cpbte = ast_cbte Left Join (Select mva_asiento, Sum(mva_importe) as Total From MovAsto Where mva_codigo = 2 Group By mva_asiento) as X on ast_asiento = X.mva_asiento Where (moc_tipmov = 54 or moc_tipmov = 6) And moc_cont = 1 And ast_asiento is not NULL And abs(Round(((moc_total + (moc_vlte + moc_vltc)) * IsNull(moc_cotizacion,0)),2) - X.Total) > 0.01 And (moc_fecpro >= '{desde}' And moc_fecpro <= '{hasta}') ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (13/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 47, 'DEPOSITOS TOTAL CONTRA DEBE', 1, mba_fecemi, 0, mba_cpbte, mba_tipmov, mba_importe, 0, 0, 0, 0, 1, 0 From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = ast_cbte Left Join (Select mva_asiento, Sum(mva_importe) as Total From MovAsto Where mva_codigo = 1 Group By mva_asiento) as Z on ast_asiento = Z.mva_asiento Where ast_asiento is not null And X.mba_importe <> Z.Total ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (14/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 48, 'DEPOSITOS TOTAL CONTRA HABER', 1, mba_fecemi, 0, mba_cpbte, mba_tipmov, mba_importe, 0, 0, 0, 0, 1, 0 From (Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBan Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') UNION Select mba_codigo, mba_tipmov, mba_cpbte, mba_fecemi, mba_fecven, mba_comentario, mba_importe, mba_tilde, mba_referencia, mba_banco, mba_sucursal, mba_tipcta, mba_nrocta, mba_caja, mba_turno, mba_chet, mba_efectivo, mba_usuario1, mba_fecha, mba_hora, mba_ctatit, mba_nomtit, mba_cotizacion From MovBanHisto Where mba_tipmov = 1 And mba_referencia = '' And (mba_fecemi >= '{desde}' And mba_fecemi <= '{hasta}') ) as X Left Join Asiento on mba_tipmov = ast_tipocbte And RIGHT(('00000000' + mba_cpbte),8) = ast_cbte Left Join (Select mva_asiento, Sum(mva_importe) as Total From MovAsto Where mva_codigo = 2 Group By mva_asiento) as Z on ast_asiento = Z.mva_asiento Where ast_asiento is not null And X.mba_importe <> Z.Total ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (15/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 49, 'ASIENTOS CON FECHA DIFERENTE EN VENTAS (CTA CTE)', 1, ast_fecha, 0, ast_asiento, 0, 0, 0, 0, 0, 0, 1, 0 From Asiento Left Join MovVta on ast_tipocbte = vta_tipmov And ast_cbte = vta_cpbte And vta_cliente <> 'ANULADO' Where (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') And vta_fecpro <> '01/01/1990' And Len(ast_cbte) >= 14 And vta_codigo is not null And (ast_tipocbte <= 10 or ast_tipocbte = 31 or ast_tipocbte = 53) And ast_fecha <> vta_fecemi ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (16/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) Select {terminal}, 50, 'DIFERENCIA ENTRE PERIODO FISCAL Y FECHA CONTABLE EN COMPRAS', 1, cpa_feccont, 0, cpa_nrocomp, cpa_tipmov, 0, 0, 0, 0, 0, 1, 0 From MovCpa Where (cpa_tipmov >= 11 And cpa_tipmov <= 21) And (cpa_feccont >= '{desde}' And cpa_feccont <= '{hasta}') And (MONTH(cpa_feccont) <> MONTH(CONVERT(DATETIME,('01/' + cpa_periodo + ' 00:00:00.000'))) or YEAR(cpa_feccont) <> YEAR(CONVERT(DATETIME,('01/' + cpa_periodo + ' 00:00:00.000'))) ) ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (17/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) select {terminal}, 51, 'ASIENTOS DUPLICADOS', 1, NULL, IsNull(AST_CTAPRO,0) as AST_CTAPRO, ast_cbte, ast_tipocbte, COUNT(ast_asiento) as Cantidad, 0, 0, 0, 0, 1, 0 FROM Asiento Where Not (ast_comenta like '%IMPUTACION S/%') And Not (ast_comenta like '%DESIMPUTACION S/%') And len(IsNull(ast_cbte,'')) > 0 And (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') Group BY ast_tipocbte, ast_cbte, IsNull(AST_CTAPRO,0) HAVING COUNT(ast_asiento) > 1 Order BY ast_tipocbte, ast_cbte, IsNull(AST_CTAPRO,0) ");

                Mensaje.Text = "Controlando CONTABILIDAD ASIENTOS (18/18). Por favor Espere...";
                Mensaje.Refresh();

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_AuditInt (aux_terminal, aux_secuencia, aux_descri, aux_codigo, aux_fecemi, aux_ctacli, aux_cpbte, aux_tipmov, aux_vtatotal, aux_vtaneto, aux_iva, aux_ctatotal, aux_histotal, aux_marca, aux_condvta) SELECT {terminal}, 52, 'ASIENTO DE IMPUTACION SIN ASIENTO ORIGINAL', 1, A.ast_fecha, 0, A.ast_cbte, A.ast_tipocbte, 0, 0, 0, 0, 0, 1, 0 FROM Asiento as A Left Join (Select * From Asiento Where (ast_fecha >= '{desde}' And ast_fecha <= '{hasta}') And ast_comenta NOT like '%IMPUTACION S/%') as B on A.ast_tipocbte = B.ast_tipocbte And A.ast_cbte = B.ast_cbte Where (A.ast_fecha >= '{desde}' And A.ast_fecha <= '{hasta}') And A.ast_comenta like '%IMPUTACION S/%' And B.ast_asiento is NULL Order BY A.ast_fecha, A.ast_asiento ");

                Cursor.Current = Cursors.Default;
            }
        }
    }
}
