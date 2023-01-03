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
    }
}
