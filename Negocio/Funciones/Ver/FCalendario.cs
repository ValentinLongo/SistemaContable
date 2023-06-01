using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Ver
{
    public class FCalendario
    {

        public static void Agregar(string fecha, string hora, string comentario) 
        {
            int id = FLogin.IdUsuario;
            AccesoBase.InsertUpdateDatos($"INSERT INTO Calendario(cal_usuario, cal_fecha, cal_hora, cal_observa, cal_fin, cal_visto) VALUES ( {id}, '{fecha}', '{hora}', '{comentario}', {0}, {0} )");
        }

        public static void Modificar(string fecha, string hora, string comentario, string hv, string cv)
        {
            int id = FLogin.IdUsuario;
            AccesoBase.InsertUpdateDatos($"UPDATE Calendario SET cal_fecha = '{fecha}', cal_hora = '{hora}', cal_observa = '{comentario}' WHERE cal_usuario = {id} AND cal_fecha = '{fecha}' AND cal_hora = '{hv}' AND cal_observa = '{cv}'");
        }

        public static void Eliminar(string fecha, string hora, string comentario) 
        {
            int id = FLogin.IdUsuario;
            AccesoBase.InsertUpdateDatos($"DELETE Calendario WHERE cal_usuario = {id} AND cal_fecha = '{fecha}' AND cal_hora = '{hora}' AND cal_observa = '{comentario}'");
        }

        public static void Posponer(string fechanueva, string fecha, string hora, string comentario) 
        {
            int id = FLogin.IdUsuario;
            AccesoBase.InsertUpdateDatos($"UPDATE Calendario SET cal_fecha = '{fechanueva}' WHERE cal_usuario = {id} AND cal_fecha = '{fecha}' AND cal_hora = '{hora}' AND cal_observa = '{comentario}'");
        }

        public static int MSGTareas() //RETORNA UN INT DEPENDIENDO LA DIFERENCIA EN MINUTOS ENTRE LA FECHA ACTUAL Y LA TAREA QUE ESTA POR FINALIZAR
        {
            DateTime HORACTUAL = Convert.ToDateTime(DateTime.Now.ToLongTimeString().Substring(0, 5));

            string fechaActual = DateTime.Now.ToShortDateString();

            string fecha = "";
            string hora = "";

            int id = FLogin.IdUsuario;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT cal_fecha, cal_hora FROM Calendario WHERE cal_usuario = {id} AND cal_fin = 0");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fecha = dr["cal_fecha"].ToString().Substring(0,10);
                hora = dr["cal_hora"].ToString().Substring(0,5);

                DateTime HORA = Convert.ToDateTime(hora);

                if (fecha == fechaActual)
                {
                    TimeSpan diferencia = HORA - HORACTUAL;
                    var dif_en_minutos = diferencia.TotalMinutes;

                    if (dif_en_minutos < 121 && dif_en_minutos > 60)
                    {
                        return 1;
                    }
                    else if (dif_en_minutos < 61 && dif_en_minutos > 30)
                    {
                        return 2;
                    }
                    else if (dif_en_minutos < 31 && dif_en_minutos > 15)
                    {
                        return 3;
                    }
                    else if (dif_en_minutos < 16 && dif_en_minutos > 5)
                    {
                        return 4;
                    }
                    else if (dif_en_minutos < 6 && dif_en_minutos > 0)
                    {
                        return 5;
                    }
                    else if (dif_en_minutos <= 0)
                    {
                        return 6;
                    }
                }
            }
            return 0;
        }
    }
}
