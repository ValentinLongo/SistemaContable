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
        public DataSet RubroContableParticular(int idRubro)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from RubroCont where ruc_codigo = {idRubro}");
            return ds;
        }
    }
}
