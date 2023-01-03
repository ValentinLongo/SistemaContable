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
    public class FLogin
    {
        public static int IdUsuario;
        //BUSCO SI EXISTE USUARIO
        public static int buscarUsuario(string usuario, string contrasenia)
        {
            int resultado = 0;
            resultado = AccesoBase.ValidarDatos($"SELECT * FROM Usuario WHERE usu_login = '{usuario}' and usu_contraseña = '{contrasenia}'");
            if (resultado == 1)
            {
                BuscarIdUsuario(usuario, contrasenia);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void BuscarIdUsuario(string usuario, string contrasenia)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT usu_codigo FROM Usuario WHERE usu_login = '{usuario}' and usu_contraseña = '{contrasenia}'");

            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MUsuario mUsuario = new MUsuario()
                {
                    usu_codigo = Convert.ToInt32(dr["usu_codigo"])
                };
                IdUsuario = mUsuario.usu_codigo;
            }
        }

        //COMPLETO LINEA DE CONEXION CON DATOS DE LA LINEA DE COMANDO (EN ACCESO DIRECTO)
        public static int completarConexion()
        {
            List<string> argumentos = new List<string>();
            string[] passedInArgs = Environment.GetCommandLineArgs();
            foreach (string s in passedInArgs)
            {
                argumentos.Add(s);
            }

            string Servidor = argumentos[1];
            string BaseDeDatos = argumentos[2];
            int NumeroTerminal = Convert.ToInt32(argumentos[3]);
            Datos.AccesoBase.datosConexion = @"Data Source = " + Servidor + ";Initial Catalog = " + BaseDeDatos + "; User ID = sa; Password=1220;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=true";
            return NumeroTerminal;
        }
    }
}
