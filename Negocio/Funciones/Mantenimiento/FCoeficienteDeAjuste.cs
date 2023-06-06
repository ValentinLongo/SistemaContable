using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Mantenimiento
{
    public class FCoeficienteDeAjuste
    {
        public List<MCoeficienteDeAjuste> listaEjercicios(int ejercicio)
        {
            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            DataSet ds = new DataSet();
            if(ejercicio == 0)
            {
                ds = AccesoBase.ListarDatos($"select * from Ejercicio where eje_cerrado = 0 order by eje_hasta");
            }
            else
            {
                ds = AccesoBase.ListarDatos($"select * from Ejercicio order by eje_hasta");
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MCoeficienteDeAjuste mCoeficienteDeAjuste1 = new MCoeficienteDeAjuste()
                {
                    eje_codigo = Convert.ToInt32(dr["eje_codigo"].ToString()),
                    eje_descri = dr["eje_descri"].ToString(),
                    eje_desde = dr["eje_desde"].ToString().Substring(0,10),
                    eje_hasta = dr["eje_hasta"].ToString().Substring(0, 10),
                    eje_renumera = Convert.ToInt32(dr["eje_renumera"].ToString()),
                    eje_asiento = Convert.ToInt32(dr["eje_asiento"].ToString()),
                    eje_cerrado = Convert.ToInt32(dr["eje_cerrado"].ToString())
                };
                mCoeficienteDeAjuste.Add(mCoeficienteDeAjuste1);
            }
            return mCoeficienteDeAjuste;
        }

        public List<MCoeficienteDeAjuste> ejercicioParticular(int ejercicio, string descripcion)
        {
            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            DataSet ds = new DataSet();
            if (ejercicio == 0)
            {
                ds = AccesoBase.ListarDatos($"select * from Ejercicio where eje_cerrado = 0 and eje_descri LIKE'%{descripcion}%' order by eje_hasta");
            }
            else
            {
                ds = AccesoBase.ListarDatos($"select * from Ejercicio where eje_descri LIKE'%{descripcion}%' order by eje_hasta");
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MCoeficienteDeAjuste mCoeficienteDeAjuste1 = new MCoeficienteDeAjuste()
                {
                    eje_codigo = Convert.ToInt32(dr["eje_codigo"].ToString()),
                    eje_descri = dr["eje_descri"].ToString(),
                    eje_desde = dr["eje_desde"].ToString(),
                    eje_hasta = dr["eje_hasta"].ToString(),
                    eje_renumera = Convert.ToInt32(dr["eje_renumera"].ToString()),
                    eje_asiento = Convert.ToInt32(dr["eje_asiento"].ToString()),
                    eje_cerrado = Convert.ToInt32(dr["eje_cerrado"].ToString())
                };
                mCoeficienteDeAjuste.Add(mCoeficienteDeAjuste1);
            }
            return mCoeficienteDeAjuste;
        }

        public DataSet listaCoeficientes(int idEjercicio) 
        {
            DataSet ds = AccesoBase.ListarDatos($"SELECT aji_periodo as Periodo, aji_coef as 'Coeficiente de Ajuste', usu_nombre as Creó, aji_fecalta as Fecha, aji_horaalta as Hora, aji_usumodi as Modificó, aji_fecmodi as FechaModi, aji_horamodi as HoraModi FROM DetAjusteInf LEFT JOIN Usuario on aji_usualta = usu_codigo WHERE aji_ejercicio = {idEjercicio}");
            return ds;
        }

        public void eliminarCoeficiente(string Periodo)
        {
            AccesoBase.InsertUpdateDatos($"DELETE FROM DetAjusteInf WHERE aji_periodo = '{Periodo}'");
        }
    }
}
