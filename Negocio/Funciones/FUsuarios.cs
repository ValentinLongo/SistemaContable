using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FUsuarios
    {
        public static DataSet Perfiles()
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos("Select * from Perfil");
            return ds;
        }

        public static DataSet Estados()
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos("Select * from Estado");
            return ds;
        }

        public static DataSet Secciones()
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos("Select * from Seccion");
            return ds;
        }

        public static DataSet Vendedores()
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos("select ven_codigo as Codigo, ven_nombre as Nombre from Vendedor where ven_estado = 1");
            return ds;
        }

        public static MUsuario UsuarioParticular(int idUsuario)
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"SELECT usu_codigo, usu_nombre, usu_login, usu_direccion, Perfil.per_descri, usu_telefono, usu_perfil, usu_fecnac, usu_estado, usu_seccion, usu_vendedor, ven_nombre FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo LEFT JOIN Vendedor on usu_vendedor = ven_codigo WHERE usu_codigo = {idUsuario}");

            MUsuario mUsuario = new MUsuario();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int usuvendedor = 0;
                string vennombre = "";
                if (dr["usu_vendedor"].ToString() != "")
                {
                    usuvendedor = Convert.ToInt32(dr["usu_vendedor"]);
                    vennombre = dr["ven_nombre"].ToString();
                }
                MUsuario oUsuario = new MUsuario()
                {
                    usu_codigo = Convert.ToInt32(dr["usu_codigo"]),
                    usu_nombre = dr["usu_nombre"].ToString(),
                    usu_login = dr["usu_login"].ToString(),
                    per_descri = dr["per_descri"].ToString(),
                    usu_perfil = Convert.ToInt32(dr["usu_perfil"]),
                    usu_direccion = dr["usu_direccion"].ToString(),
                    usu_telefono = dr["usu_telefono"].ToString(),
                    usu_fecnac = Convert.ToDateTime(dr["usu_fecnac"].ToString()),
                    usu_estado = Convert.ToInt32(dr["usu_estado"]),
                    usu_seccion = Convert.ToInt32(dr["usu_seccion"]),
                    usu_vendedor = usuvendedor,
                    ven_nombre = vennombre
                };
                mUsuario = oUsuario;
            }
            return mUsuario;
        }

        public static void AgregarUsuario(MUsuario mUsuario)
        {
            int ultimoID = 0;
            ultimoID = Negocio.FGenerales.ultimoNumeroID("usu_codigo", "Usuario");
            Datos.AccesoBase.InsertUpdateDatos($"INSERT INTO Usuario(usu_codigo,usu_nombre,usu_login,usu_perfil,usu_direccion,usu_telefono,usu_fecnac, usu_estado,usu_vendedor, usu_seccion) values ({ultimoID},'{mUsuario.usu_nombre}','{mUsuario.usu_login}',{mUsuario.usu_perfil},'{mUsuario.usu_direccion}','{mUsuario.usu_telefono}','{mUsuario.usu_fecnac}',{mUsuario.usu_estado},{mUsuario.usu_vendedor},{mUsuario.usu_seccion})");
        }

        public static void ModificarUsuario(MUsuario mUsuario)
        {
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE Usuario SET usu_nombre = '{mUsuario.usu_nombre}', usu_login = '{mUsuario.usu_login}', usu_direccion = '{mUsuario.usu_direccion}', usu_telefono = '{mUsuario.usu_telefono}', usu_perfil = {mUsuario.usu_perfil}, usu_fecnac = '{mUsuario.usu_fecnac}', usu_estado = {mUsuario.usu_estado}, usu_seccion = {mUsuario.usu_seccion}, usu_vendedor = {mUsuario.usu_vendedor} WHERE usu_codigo = {mUsuario.usu_codigo}");
        }

        public static void ModificarCajaPredefinida(int idCaja)
        {
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE CajaxUsuario SET cxu_predef = 0 where cxu_usuario = {Negocio.FLogin.IdUsuario}");
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE CajaxUsuario SET cxu_predef = 1 where cxu_usuario = {Negocio.FLogin.IdUsuario} and cxu_caja = {idCaja}");
        }
    }
}
