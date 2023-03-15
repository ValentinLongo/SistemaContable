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

        public static int MSGTareas()
        {
            bool unahora = false;
            bool cincominutos = false;

            string horaActual = DateTime.Now.ToLongTimeString();
            string horaUnaHora = horaActual.Substring(0,2);
            string horaCincoMinutos = horaActual.Substring(3, 2);

            string fechaActual = DateTime.Now.ToShortDateString();

            string fecha = "";
            string hora = "";

            int id = FLogin.IdUsuario;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT cal_fecha, cal_hora FROM Calendario WHERE cal_usuario = {id} ");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fecha = dr["cal_fecha"].ToString();
                fecha = fecha.Substring(0, 10);

                hora = dr["cal_hora"].ToString();
                string hora1h = hora.Substring(0, 2);
                string hora5m = hora.Substring(3, 2);

                if (fecha == fechaActual)
                {
                    if (Convert.ToInt32(hora1h) - Convert.ToInt32(horaUnaHora) == 1)
                    {
                        unahora = true;
                    }
                    if (Convert.ToInt32(hora5m) - Convert.ToInt32(horaCincoMinutos) == 5)
                    {
                        cincominutos = true;
                    }
                }
            }

            if (unahora)
            {
                return 1;
            }
            else
            {
                if (cincominutos)
                {
                    return 2;
                }
            }
            return 0;
        }
    }
}
