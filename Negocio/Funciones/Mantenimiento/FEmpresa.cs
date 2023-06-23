using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class FEmpresa
    {
        public static string querySucursales;
        public static string queryEmpresa;

        public static DataSet listaEmpresa()
        {
            DataSet ds = new DataSet();
            string query = "select emp_nombre as Denominación, emp_razsoc as 'Razón Social',emp_fecini as 'Inicio de Act', emp_actividad as Actividad, emp_locali as Localidad, emp_domicilio as Domicilio,emp_telefono as Telefono, emp_email as 'E-Mail', emp_web as Web, CondIva.iva_condicion as 'Condición de IVA', (emp_cuit1+'-'+emp_cuit2+'-'+emp_cuit3) as CUIT, emp_ingbru as 'Ing. Brutos' from Empresa LEFT JOIN CondIva on Empresa.emp_iva = CondIva.iva_codigo";
            queryEmpresa = "Select Empresa.*, (emp_cuit1 + '-' + emp_cuit2 + '-' + emp_cuit3) as Cuit , (CONVERT(VARCHAR,emp_codpos1) + ' - ' + loc_nombre) as Loca, iva_condicion  From Empresa Left join Tipempresa on emp_tipo = tem_codigo Left join Localidad on emp_codpos1 = loc_cod1 and emp_codpos2 = loc_cod2 Left Join CondIva on emp_iva = iva_codigo";
            ds = Datos.AccesoBase.ListarDatos(query);
            return ds;
        }
        public static DataSet listaSucursales()
        {
            DataSet ds = new DataSet();
            string query = "select * from Sucursal ORDER BY suc_codigo";
            querySucursales = query;
            ds = Datos.AccesoBase.ListarDatos(query);
            return ds;
        }

        public static void eliminarSucursal(int idSucursal)
        {
            Datos.AccesoBase.InsertUpdateDatos($"delete from Sucursal where suc_codigo = {idSucursal}");
        }
    }
}