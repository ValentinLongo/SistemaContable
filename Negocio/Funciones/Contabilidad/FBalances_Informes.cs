using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Contabilidad
{
    public class FBalances_Informes
    {
        public static bool EstadoEjercicio(int ejercicio, int tipo) 
        {

            if (tipo == 1) //CIERRE
            {
                DataSet ds = new DataSet();
                int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {ejercicio} AND ast_tipo = 4");
                if (resultado == 1)
                {
                    return true;
                }
            }
            else if (tipo == 2) //APERTURA
            {
                DataSet ds = new DataSet();
                int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {ejercicio} AND ast_tipo = 1");
                if (resultado == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
