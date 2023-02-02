using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones
{
    public class FRubrosContables
    {
        public static DataSet ListaRubrosContables()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from RubroCont");
            return ds;
        }
    }
}
