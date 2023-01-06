using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FPlanDeCuentas
    {
        public static DataSet ListaCuentas()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select pcu_codigo as Codigo, pcu_cuenta as Cuenta, pcu_descri as Descripcion, pcu_superior as Superior, pcu_hija as Hija, pcu_tabulador as Tabulador from PCuenta");
            return ds;
        }

        public static DataSet BusquedaCuenta(string Descripcion)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select pcu_codigo as Codigo, pcu_cuenta as Cuenta, pcu_descri as Descripcion, pcu_superior as Superior, pcu_hija as Hija, pcu_tabulador as Tabulador from PCuenta where pcu_descri = '{Descripcion}'");
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

        public static int cantidadHijos(string codigo)
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"select * from PCuenta where pcu_codigo LIKE '{codigo}%'");
            int cantidad = ds.Tables[0].Rows.Count;
            cantidad--;
            return cantidad;
        }
    }
}
