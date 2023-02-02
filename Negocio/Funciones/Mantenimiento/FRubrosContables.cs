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

        public void ModificarRubroContable(int codigo, string nombre,int vigencia, string desde, string hasta)
        {
            AccesoBase.InsertUpdateDatos($"update RubroCont set ruc_descri = '{nombre}', ruc_vigencia = {vigencia}, ruc_desde = '{desde}', ruc_hasta = '{hasta}' where ruc_codigo = {codigo}");
        }

        public void AgregarRubroContable(string nombre, int vigencia, string desde, string hasta)
        {
            int codigo = FGenerales.ultimoNumeroID("ruc_codigo", "RubroCont");
            AccesoBase.InsertUpdateDatos($"INSERT INTO RubroCont(ruc_codigo,ruc_descri,ruc_vigencia,ruc_desde,ruc_hasta) VALUES({codigo},'{nombre}',{vigencia},'{desde}','{hasta}')");
        }

        public void EliminarRubroContable(int codigo)
        {
            AccesoBase.InsertUpdateDatos($"DELETE FROM RubroCont WHERE ruc_codigo = {codigo}");
        }
    }
}
