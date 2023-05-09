﻿using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Contabilidad
{
    public class FLibroMayor
    {
        public static string[] fechasDesdeHasta(int NroEjer) // tipo 1 = DEBE / tipo 2 = HABER
        {
            DataSet ds = new DataSet();
            string[] fechas = new string[2];
            ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {NroEjer}");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    fechas[0] = dr["eje_desde"].ToString();
                    fechas[1] = dr["eje_hasta"].ToString();
                }
            }
            return fechas;
        }
    }
}