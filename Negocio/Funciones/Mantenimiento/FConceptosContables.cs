using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Mantenimiento
{
    public class FConceptosContables
    {
        public DataSet listaConceptosContables()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT coc_codigo as Código, coc_descri as Descripción FROM ConceptoCont");
            return ds;
        }

        public DataSet listaCuentas()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta");
            return ds;
        }

        public DataSet listaCuentasActivas()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta WHERE pcu_estado = 1");
            return ds;
        }

        public string descripcionCuenta(int idCuenta)
        {
            string Descripcion = "";
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {idCuenta}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Descripcion = dr["pcu_descri"].ToString();
            }
            return Descripcion;
        }
    }
}
