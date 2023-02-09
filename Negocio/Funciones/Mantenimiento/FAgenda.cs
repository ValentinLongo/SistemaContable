using Datos;
using Datos.Modelos;
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
            ds = AccesoBase.ListarDatos($"select age_codigo as 'Codigo', age_nombre as 'Nombre', age_telefono as 'Teléfono', age_direccion as 'Dirección' from Agenda");
            return ds;
        }

        public static DataSet listaActividad()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select * from Actividad");
            return ds;
        }

        public void agregarAgenda(MAgenda mAgenda)
        {
            AccesoBase.InsertUpdateDatos($"INSERT INTO Agenda(age_codigo, age_nombre, age_direccion, age_codpos1, age_codpos2, age_telefono, age_celular, age_email, age_web, age_observa, age_fecnac, age_actividad) " +
            $"VALUES({mAgenda.age_codigo},'{mAgenda.age_nombre}','{mAgenda.age_direccion}',{mAgenda.age_codpos1},{mAgenda.age_codpos2},'{mAgenda.age_telefono}','{mAgenda.age_celular}','{mAgenda.age_email}','{mAgenda.age_web}','{mAgenda.age_observa}','{mAgenda.age_fecnac}',{mAgenda.age_actividad})");
        }

        public void modificarAgenda(MAgenda mAgenda)
        {
            AccesoBase.InsertUpdateDatos($"UPDATE Agenda SET age_nombre = '{mAgenda.age_nombre}', age_direccion = '{mAgenda.age_direccion}', age_codpos1 = {mAgenda.age_codpos1}, age_codpos2 = {mAgenda.age_codpos2}, age_telefono = '{mAgenda.age_telefono}', age_celular= '{mAgenda.age_celular}', age_email = '{mAgenda.age_email}', age_web = '{mAgenda.age_web}', age_observa = '{mAgenda.age_observa}', age_fecnac = '{mAgenda.age_fecnac}', age_actividad = '{mAgenda.age_actividad}' WHERE age_codigo = {mAgenda.age_codigo}");
        }

        public MAgenda agendaAModificar(int idAgenda)
        {
            MAgenda mAgenda = new MAgenda();
            DataSet ds = AccesoBase.ListarDatos($"SELECT * FROM Agenda WHERE age_codigo = {idAgenda}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MAgenda agenda = new MAgenda()
                {
                    age_nombre = dr["age_nombre"].ToString(),
                    age_direccion = dr["age_direccion"].ToString(),
                    age_codpos1 = Convert.ToInt32(dr["age_codpos1"].ToString()),
                    age_codpos2 = Convert.ToInt32(dr["age_codpos2"].ToString()),
                    age_telefono = dr["age_telefono"].ToString(),
                    age_celular = dr["age_celular"].ToString(),
                    age_email = dr["age_email"].ToString(),
                    age_web = dr["age_web"].ToString(),
                    age_observa = dr["age_observa"].ToString(),
                    age_fecnac = dr["age_fecnac"].ToString(),
                    //age_actividad = Convert.ToInt32(dr["age_direccion"].ToString())
                };
                mAgenda = agenda;
            }
            return mAgenda;
        }
    }
}
