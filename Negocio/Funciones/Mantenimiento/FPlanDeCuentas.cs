using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FPlanDeCuentas
    {
        public static string query;
        public static string wherePCuenta;
        public static DataSet BusquedaCuenta(string Descripcion)
        {
            //add.rows
            //DataSet ds = new DataSet();
            //string Query = $"select * from PCuenta where pcu_descri LIKE'%{Descripcion}%'";
            //query = Query;
            //ds = AccesoBase.ListarDatos(Query);
            //return ds;

            //datasource
            DataSet ds = new DataSet();
            string Query = $"select pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción, pcu_superior as Superior, pcu_hija as Hija, pcu_tabulador as Tabulador, pcu_ajustainf as AjustaInf from PCuenta where pcu_descri LIKE'%{Descripcion}%'";
            wherePCuenta = $"where pcu_descri LIKE'%{Descripcion}%'";
            query = Query;
            ds = AccesoBase.ListarDatos(Query);
            return ds;

        }

        public static DataSet BusquedaCuentaPorCuenta(string codigo)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from PCuenta where pcu_cuenta = {codigo}");
            return ds;
        }

        public static DataSet Rubros()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from RubroCont");
            return ds;
        }

        public static int UltimoNumeroCuenta()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select TOP 1 pcu_cuenta from PCuenta ORDER BY pcu_cuenta desc");
            int ultimoId = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ultimoId = Convert.ToInt32(dr["pcu_cuenta"]);
            }
            ultimoId++;
            return ultimoId;
        }

        public static int tabulador(string codigo)
        {
            int tabulador = 0;
            string[] cod = new string[codigo.Length];
            for (int i = 0; i < cod.Length; i++)
            {
                cod[i] = Convert.ToString(codigo[i]);
            }

            if (cod[1] != "0" && cod[1] != " ")
            {
                tabulador = 1;
            }
            if (cod[4] != "0" && cod[4] != " ")
            {
                tabulador = 2;
            }
            if (cod[7] != "0" && cod[7] != " ")
            {
                tabulador = 3;
            }
            if (cod[10] != "0" && cod[10] != " ")
            {
                tabulador = 4;
            }
            if (cod[13] != "0" && cod[13] != " ")
            {
                tabulador = 5;
            }
            return tabulador;
        }

        public static void cantidadHijos(string codigo)
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"Select * from PCuenta where pcu_superior = '{codigo}'");
            int cantidad = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cantidad++;
                }
            }
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE PCuenta set pcu_hija = {cantidad} where pcu_codigo = '{codigo}'");
        }

        public static void agregarPlanDeCuentas(MPlanDeCuentas mPlanDeCuentas)
        {
            Datos.AccesoBase.InsertUpdateDatos($"INSERT INTO PCuenta(pcu_codigo,pcu_cuenta,pcu_descri,pcu_superior,pcu_hija,pcu_tabulador,pcu_estado,pcu_rubrocont, pcu_ajustainf) " +
                $"VALUES ('{mPlanDeCuentas.pcu_codigo}',{mPlanDeCuentas.pcu_cuenta},'{mPlanDeCuentas.pcu_descri}','{mPlanDeCuentas.pcu_superior}',{mPlanDeCuentas.pcu_hija},{mPlanDeCuentas.pcu_tabulador},{mPlanDeCuentas.pcu_estado},{mPlanDeCuentas.pcu_rubrocont},{mPlanDeCuentas.pcu_ajustainf})");
        }

        public static void modificarPlanDeCuentas(MPlanDeCuentas mPlanDeCuentas)
        {
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE PCuenta SET pcu_descri = '{mPlanDeCuentas.pcu_descri}', pcu_estado = {mPlanDeCuentas.pcu_estado}, pcu_rubrocont = {mPlanDeCuentas.pcu_rubrocont}, pcu_ajustainf = {mPlanDeCuentas.pcu_ajustainf} where pcu_codigo = '{mPlanDeCuentas.pcu_codigo}'");
        }

        public static void eliminarCuenta(string idCuenta)
        {
            Datos.AccesoBase.InsertUpdateDatos($"DELETE PCuenta WHERE pcu_cuenta = {idCuenta}");
        }

        public static string msgRetorno;
        public static bool Ctrl_Ctas(string Cuenta, string Param, bool Traba)
        {
            if (Cuenta != "")
            {
                DataSet ds = new DataSet();

                if (Param.IndexOf("CAJA") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Caja WHERE caj_ctacont = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido definida en las Cajas del Sistema.";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido definida en las Cajas del Sistema.";
                            return false;
                        }
                    }
                }

                if (Param.IndexOf("CTABAN") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM CtaBan WHERE caj_ctacont = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido definida en las Cuentas Bancarias del Sistema.";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido definida en las Cuentas Bancarias del Sistema.";
                            return false;
                        }
                    }
                }

                if (Param.IndexOf("TARJETA") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Tarjeta WHERE tar_ctacont = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido definida en las Tarjetas de Crédito del Sistema.";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido definida en las Tarjetas de Crédito del Sistema.";
                            return false;
                        }
                    }
                }

                if (Param.IndexOf("PARAMCONTAB") == -1)
                {
                    DataSet ds2 = new DataSet();
                    ds2 = AccesoBase.ListarDatos($"Select * From ParamContabH");

                    ds = AccesoBase.ListarDatos($"Select * From ParamContab");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return true;
                    }

                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        if (dc.ColumnName.Substring(0, 8) != "par_conc")
                        {
                            if (ds.Tables[0].Rows[0][dc.ColumnName].ToString() == Cuenta)
                            {
                                if (ds2.Tables[0].Rows.Count == 0)
                                {
                                    msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido Parametrizada como de Uso Automático del Sistema.";
                                    return false;
                                }
                                else
                                {
                                    if ((ds2.Tables[0].Rows[0][dc.ColumnName] is DBNull ? "0" : ds2.Tables[0].Rows[0][dc.ColumnName].ToString()) == "1")
                                    {
                                        msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido Parametrizada como de Uso Automático del Sistema.";
                                        return true;
                                    }
                                    else
                                    {
                                        msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido Parametrizada como de Uso Automático del Sistema.";
                                        return false;
                                    }
                                }
                            }
                        }
                    }                   
                }

                if (Param.IndexOf("ARTICULO") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Articulo WHERE art_ctacont = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido asignada a un artículo";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido asignada a un artículo";
                            return false;
                        }
                    }
                }

                if (Param.IndexOf("PROVEEDOR") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Proveedor WHERE prv_impcont = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido asignada a un Proveedor";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido asignada a un Proveedor";
                            return false;
                        }
                    }
                }

                if (Param.IndexOf("MODELO") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM ModeloDet WHERE det_cuenta = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido asignada a un modelo de Asiento.";
                        return true;
                    }
                }

                if (Param.IndexOf("CONCEPTOCONT") == -1)
                {
                    ds = AccesoBase.ListarDatos($"SELECT * FROM ConceptoCont WHERE coc_ctacont = '{Cuenta}' or coc_contrap = '{Cuenta}' or coc_cccta = '{Cuenta}' or coc_cccontrap = '{Cuenta}'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Traba == false)
                        {
                            msgRetorno = "Atención: Se Recomienda la No utilización de la Cuenta Contable elegida ya que ha sido asignada a un Concepto Contable";
                            return true;
                        }
                        else
                        {
                            msgRetorno = "Atención: No se podrá utilizar la Cuenta Contable elegida ya que ha sido asignada a un Concepto Contable";
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}
