using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Contabilidad
{
    public class FLibroDiario
    {

        public static double SaldoInicial(int NroEjer, string DESDE, int tipo) // tipo 1 = DEBE / tipo 2 = HABER
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {NroEjer}");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                string desde = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    desde = dr["eje_desde"].ToString();
                }

                if (Convert.ToDateTime(desde) == Convert.ToDateTime(DESDE))
                {
                    return 0;
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT sum(case when mva_codigo = 1 then mva_importe else 0 end) as mva_debe, sum(case when mva_codigo = 2 then mva_importe = 0 end) as mva_haber FROM MovAsto LEFT JOIN PCuenta on mva_cuenta = pcu_cuenta LEFT JOIN asiento on ast_asiento = mva_asiento WHERE ast_ejercicio = {NroEjer} AND ast_fecha < '{Convert.ToDateTime(DESDE)}'");
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        if (tipo == 1)
                        {
                            return (dr2["mva_debe"] is DBNull ? 0 : Convert.ToDouble(dr2["mva_debe"]));
                        }
                        else if (tipo == 2)
                        {
                            return (dr2["mva_haber"] is DBNull ? 0 : Convert.ToDouble(dr2["mva_haber"]));
                        }
                    }
                }
            }
            return 0;
        }



    }
}
