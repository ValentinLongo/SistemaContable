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
            if(ds.Tables[0].Rows.Count > 0)
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
    }
}
