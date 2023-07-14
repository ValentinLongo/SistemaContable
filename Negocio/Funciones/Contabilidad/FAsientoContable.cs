using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Contabilidad
{
    public class FAsientoContable
    {
        public static void Proc_IngVar(DataSet ds, int terminal, int asiento)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["moc_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);

                ds2 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIva"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretGan"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretIIBB"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaretsuss"]);
                long CtaDeud = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaDeud"]);
                long CtaAnticipo = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaAnticipoVta"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (!(ds.Tables[0].Rows[0]["moc_valores"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_valores"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 1, ds.Tables[0].Rows[0]["moc_valores"].ToString(), "", 1);
                }

                if (!(ds.Tables[0].Rows[0]["moc_tc"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_tc"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select tcc_tarjeta, pcu_cuenta, Sum(tcc_importe) as total From MovVtaTC Left Join (Tarjeta Left Join PCuenta on tar_ctacont = pcu_cuenta) on tcc_tarjeta = tar_codigo Where tcc_tipmov = 42 And tcc_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' Group By tcc_tarjeta, pcu_cuenta");

                    foreach (DataRow dr3 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr3["pcu_cuenta"]), 1, dr3["total"].ToString(), "", 2);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_gasto"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_gasto"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 1, ds.Tables[0].Rows[0]["moc_gasto"].ToString(), "", 3);
                }

                if (!(ds.Tables[0].Rows[0]["moc_efectivo"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_efectivo"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 1, ds.Tables[0].Rows[0]["moc_efectivo"].ToString(), "", 4);
                }

                if (!(ds.Tables[0].Rows[0]["moc_retgan"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retgan"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaRetGan, 1, ds.Tables[0].Rows[0]["moc_retgan"].ToString(), "", 5);
                }

                if (!(ds.Tables[0].Rows[0]["moc_retiibb"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retiibb"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaRetIIBB, 1, ds.Tables[0].Rows[0]["moc_retiibb"].ToString(), "", 6);
                }

                if (!(ds.Tables[0].Rows[0]["moc_retiva"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retiva"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaRetIVA, 1, ds.Tables[0].Rows[0]["moc_retiva"].ToString(), "", 7);
                }

                if (!(ds.Tables[0].Rows[0]["moc_retsuss"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_retsuss"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaRetSuss, 1, ds.Tables[0].Rows[0]["moc_retsuss"].ToString(), "", 8);
                }

                if (!(ds.Tables[0].Rows[0]["moc_ticket"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_ticket"]) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 1, ds.Tables[0].Rows[0]["moc_ticket"].ToString(), "", 9);
                }

                if (!(ds.Tables[0].Rows[0]["moc_dep"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_dep"]) != 0)
                {
                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBan Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta ) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["mov_cpbte"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 1, dr2["total"].ToString(), "", 10);
                    }

                    ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as Tot From MovBanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta ) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov = 1 And mba_referencia = '{ds.Tables[0].Rows[0]["mov_cpbte"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 1, dr2["total"].ToString(), "", 10);
                    }
                }

                if ((!(ds.Tables[0].Rows[0]["moc_vlte"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_vlte"]) != 0) || (!(ds.Tables[0].Rows[0]["moc_vltc"] is DBNull) && Convert.ToInt32(ds.Tables[0].Rows[0]["moc_vltc"]) != 0))
                {
                    double suma = (ds.Tables[0].Rows[0]["moc_vltc"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vltc"])) + (ds.Tables[0].Rows[0]["moc_vlte"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["moc_vlte"]));

                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 2, suma.ToString(), "", 11);
                }

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) SELECT {terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', va1_cta, 2, va1_importe, va1_comentario, 12 From MovVario Where va1_tipmov = 42 And va1_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}'");

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    MessageBox.Show($"Atención: El Asiento que se va a generar a través de este Comprobante: {ds.Tables[0].Rows[0]["moc_cpbte"]}, No se encuentra correctamente Balanceado.");
                    return;
                }

                AccesoBase.InsertUpdateDatos($"Update Asiento Set ast_usumodi = {FLogin.NombreUsuario}, ast_fecmodi = '{DateTime.Now.ToShortDateString()}', ast_horamodi = '{DateTime.Now.ToShortTimeString()}' Where ast_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Delete From MovAsto Where mva_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {asiento} as Asto, '{ds.Tables[0].Rows[0]["moc_fecpro"]}' as Fec, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MessageBox.Show("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Ingreso Vario " + ds.Tables[0].Rows[0]["moc_cpbte"] + ".");
            }
        }

        public static void Proc_EgrVar(DataSet ds, int terminal, int asiento)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"Select * From Caja Where caj_codigo = {ds.Tables[0].Rows[0]["moc_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);

                ds2 = AccesoBase.ListarDatos($"Select * From ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaProv = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaProv"]);

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (!(ds.Tables[0].Rows[0]["moc_valores"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_valores"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 2, ds.Tables[0].Rows[0]["moc_valores"].ToString(), "", 1);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_chep"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_chep"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And chp_tipmov = 43 Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, ds.Tables[0].Rows[0]["total"].ToString(), "", 2);
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_efectivo"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_efectivo"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaCaja, 2, ds.Tables[0].Rows[0]["moc_efectivo"].ToString(), "", 3);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_retgan"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), CtaRetGan, 2, ds.Tables[0].Rows[0]["moc_retgan"].ToString(), "", 4);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["moc_dep"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["moc_dep"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, dr2["total"].ToString(), "", 5);

                        }

                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_tipmov <> 2 And mba_referencia = '{ds.Tables[0].Rows[0]["moc_cpbte"]}' And mba_tipmovref = 43 Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, ds.Tables[0].Rows[0]["moc_fecpro"].ToString(), Convert.ToInt32(dr2["pcu_cuenta"]), 2, dr2["total"].ToString(), "", 5);
                        }
                    }
                }

                AccesoBase.InsertUpdateDatos($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) SELECT {terminal}, 1, '{ds.Tables[0].Rows[0]["moc_fecpro"]}', va1_cta, 1, va1_importe, va1_comentario, 6 From MovVario Where va1_tipmov = 43 And va1_cpbte = '{ds.Tables[0].Rows[0]["moc_cpbte"]}'");

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    MessageBox.Show("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                    return;
                }

                AccesoBase.InsertUpdateDatos($"Update Asiento Set ast_usumodi = {FLogin.NombreUsuario}, ast_fecmodi = '{DateTime.Now.ToShortDateString()}', ast_horamodi = '{DateTime.Now.ToShortTimeString()}' Where ast_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Delete From MovAsto Where mva_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {asiento} as Asto, '{ds.Tables[0].Rows[0]["moc_fecpro"]}' as Fec, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MessageBox.Show("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Egreso Vario " + ds.Tables[0].Rows[0]["moc_cpbte"] + ".");
            }
        }

        public static void Proc_CPBTECpa(DataSet ds, int terminal, int asiento)
        {
            try
            {
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
                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_periodo"]) != Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_feccont"].ToString().Substring(ds.Tables[0].Rows[0]["cpa_feccont"].ToString().Length, -7)))
                {
                    fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(0, 2)), Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Length - 4))) + "/" + ds.Tables[0].Rows[0]["cpa_periodo"].ToString();
                }
                else
                {
                    fecha = ds.Tables[0].Rows[0]["cpa_feccont"].ToString();
                }

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);

                if (ds.Tables[0].Rows[0]["cpa_ctaneto"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaneto"] is DBNull) == false) //neto
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaneto"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_neto"]).ToString(), "", 1);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaexento"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaexento"] is DBNull) == false) //exento
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaexento"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_exento"]).ToString(), "", 2);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva21"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaiva21"] is DBNull) == false) //iva21
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaiva21"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva21"]).ToString(), "", 3);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva27"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaiva27"] is DBNull) == false) //iva27
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaiva27"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva27"]).ToString(), "", 4);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaiva10"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaiva10"] is DBNull) == false) //iva10
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaiva10"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_iva10"]).ToString(), "", 5);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaimpint"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaimpint"] is DBNull) == false) //impint
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaimpint"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_impint"]).ToString(), "", 6);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiva"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaretiva"] is DBNull) == false) //retiva
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaretiva"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiva"]).ToString(), "", 7);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretiibb"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaretiibb"] is DBNull) == false) //retiibb
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaretiibb"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retiibb"]).ToString(), "", 8);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaretgan"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaretgan"] is DBNull) == false) //retgan
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaretgan"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]).ToString(), "", 9);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiva"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaperiva"] is DBNull) == false) //periva
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaperiva"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periva"]).ToString(), "", 10);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaperiibb"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaperiibb"] is DBNull) == false) //periibb
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaperiibb"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_periibb"]).ToString(), "", 11);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctapergan"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctapergan"] is DBNull) == false) //pergan
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctapergan"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_pergan"]).ToString(), "", 12);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctamonotributo"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctamonotributo"] is DBNull) == false) //monotributo
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctamonotributo"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_monotributo"]).ToString(), "", 13);
                }

                if (ds.Tables[0].Rows[0]["cpa_ctaotros"].ToString().Trim() != "" && (ds.Tables[0].Rows[0]["cpa_ctaotros"] is DBNull) == false) //otros
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctaotros"]), d, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_otros"]).ToString(), "", 14);
                }

                //total
                if (!(ds.Tables[0].Rows[0]["cpa_ctacpbte"].ToString().Trim() == "" && ds.Tables[0].Rows[0]["cpa_ctacpbte"] is DBNull))
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_condcpa"]) == 2) //cta cte
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctacpbte"]), h, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]).ToString(), "", 15);
                    }
                    else //ctdo
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 12) //nc ctdo
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_ctacpbte"]), h, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_total"]).ToString(), "", 15);
                        }
                        else //nc ctdo
                        {
                            FormPagCpa(ds, terminal);
                        }
                    }
                }

                if (Negocio.Funciones.Generales.FAuditoriaInternaMenu.Balanceado(terminal))
                {
                    MessageBox.Show("Atención: El Asiento que se va a generar a través de este Comprobante, No se encuentra correctamente Balanceado.");
                }

                AccesoBase.InsertUpdateDatos($"Update Asiento Set ast_usumodi = {FLogin.NombreUsuario}, ast_fecmodi = '{DateTime.Now.ToShortDateString()}', ast_horamodi = '{DateTime.Now.ToShortTimeString()}' Where ast_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Delete From MovAsto Where mva_asiento = {asiento}");

                AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {asiento} as Asto, '{fecha}' as Fec, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");

                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
            }
            catch (Exception)
            {
                Negocio.Funciones.Generales.FAuditoriaInternaMenu.Delete(terminal);
                MessageBox.Show("Atención: Ha Ocurrido un Problema al intentar generar el Asiento correspondiente al Comprobante de Compra " + ds.Tables[0].Rows[0]["cpa_nrocomp"].ToString() + ".");
            }
        }

        public static void FormPagCpa(DataSet ds, int terminal)
        {
            try
            {
                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT * FROM Caja WHERE caj_codigo = {ds.Tables[0].Rows[0]["cpa_caja"]}");
                long CtaCaja = Convert.ToInt64(ds2.Tables[0].Rows[0]["caj_ctacont"]);

                ds2 = AccesoBase.ListarDatos($"SELECT * FROM ParamContab");
                long CtaRetIVA = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIVAP"]);
                long CtaRetGan = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetGanP"]);
                long CtaRetIIBB = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetIIBBP"]);
                long CtaRetSuss = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaRetSUSSP"]);
                long CtaProv = Convert.ToInt64(ds2.Tables[0].Rows[0]["par_ctaProv"]);

                string fecha = "";

                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_periodo"]) != Convert.ToDateTime(ds.Tables[0].Rows[0]["cpa_feccont"].ToString().Substring(ds.Tables[0].Rows[0]["cpa_feccont"].ToString().Length, -7)))
                {
                    fecha = Negocio.FGenerales.DiasDelMes(Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(0, 2)), Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Substring(ds.Tables[0].Rows[0]["cpa_periodo"].ToString().Length - 4))) + "/" + ds.Tables[0].Rows[0]["cpa_periodo"].ToString();
                }
                else
                {
                    fecha = ds.Tables[0].Rows[0]["cpa_feccont"].ToString();
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottercero"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottercero"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, ds.Tables[0].Rows[0]["cpa_tottercero"].ToString(), "", 1);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_totpropio"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totpropio"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta, Sum(chp_importe) as total From ChequePropio Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on chp_nroban = cta_banco And chp_tipcta = cta_tipcta And chp_sucursal = cta_sucursal And chp_nrocta = cta_nrocta Where (chp_tipo <> 'T' or chp_tipo is null or chp_tipo = '') And chp_ordpag = '{ds.Tables[0].Rows[0]["cpa_nrocomp"]}' And chp_tipmov = {ds.Tables[0].Rows[0]["cpa_tipmov"]} Group By chp_banco, chp_tipcta, chp_sucursal, chp_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, ds.Tables[0].Rows[0]["total"].ToString(), "", 2);
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_totefectivo"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totefectivo"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, ds.Tables[0].Rows[0]["cpa_totefectivo"].ToString(), "", 3);
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_retgan"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_retgan"]) != 0)
                    {
                        if (!(Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 11 || Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 12 || Convert.ToInt32(ds.Tables[0].Rows[0]["cpa_tipmov"]) == 13))
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaRetGan, 2, ds.Tables[0].Rows[0]["cpa_retgan"].ToString(), "", 4);
                        }
                    }
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottransf"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottransf"]) != 0)
                    {
                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From Movban Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["cpa_tipmov"]}{ds.Tables[0].Rows[0]["cpa_tipmov"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, ds.Tables[0].Rows[0]["total"].ToString(), "", 5);
                        }

                        ds2 = AccesoBase.ListarDatos($"Select mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta, Sum(mba_importe) as total From MovbanHisto Left Join (CtaBan Left Join PCuenta on cta_ctacont = pcu_cuenta) on mba_banco = cta_banco And mba_tipcta = cta_tipcta And mba_sucursal = cta_sucursal And mba_nrocta = cta_nrocta Where mba_referencia = '{ds.Tables[0].Rows[0]["cpa_tipmov"]}{ds.Tables[0].Rows[0]["cpa_tipmov"]}' Group By mba_banco, mba_tipcta, mba_sucursal, mba_nrocta, pcu_cuenta");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, Convert.ToInt32(dr2["pcu_cuenta"]), 2, ds.Tables[0].Rows[0]["total"].ToString(), "", 5);
                        }
                    }
                }

                if (((ds.Tables[0].Rows[0]["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvuelto"])) + (ds.Tables[0].Rows[0]["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvueltoC"]))) != 0)
                {
                    Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 1, ((ds.Tables[0].Rows[0]["cpa_totvuelto"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvuelto"])) + (ds.Tables[0].Rows[0]["cpa_totvueltoC"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_totvueltoC"]))).ToString(), "", 6);
                }

                if (!(ds.Tables[0].Rows[0]["cpa_tottickets"] is DBNull))
                {
                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottickets"]) != 0)
                    {
                        Negocio.Funciones.Generales.FAuditoriaInternaMenu.InsertAux(terminal, 1, fecha, CtaCaja, 2, Convert.ToDouble(ds.Tables[0].Rows[0]["cpa_tottickets"]).ToString(), "", 7);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Atención: Error!");
            }
        }
    }
}
