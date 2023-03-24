using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class FInicio
    {
        public static void DatosUsuEmp(Control lblusuario, Control lblempresa, Control lblperfil) //SETEO INICIO
        {
            string perfil = "";

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT usu_perfil FROM Usuario WHERE usu_codigo = {FLogin.IdUsuario}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                perfil = dr["usu_perfil"].ToString();
            }

            if (perfil == "1")
            {
                perfil = "SUPERVISOR";
            }
            else if (perfil == "2")
            {
                perfil = "ADMINISTRADOR";
            }
            else if (perfil == "3")
            {
                perfil = "ENCARGADO";
            }
            else
            {
                perfil = "OPERADOR";
            }

            lblusuario.Text = "Usuario: " + FLogin.NombreUsuario;
            lblempresa.Text = "Empresa: (Empresa)";
            lblperfil.Text = "Perfil: " + perfil;
        }
    }
}
