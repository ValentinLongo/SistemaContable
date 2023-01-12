using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FAgenda
    {
        public static DataSet listaAgenda()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select age_nombre as 'Nombre', age_telefono as 'Teléfono', age_direccion as 'Dirección' from Agenda");
            return ds;
        }

        public static DataSet listaActividad()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from Actividad");
            return ds;
        }
    }
}
