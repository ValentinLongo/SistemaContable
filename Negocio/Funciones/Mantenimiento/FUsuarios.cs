using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void ModificarCajaPredefinida(int idCaja, int CodigoUsuario)
        {
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE CajaxUsuario SET cxu_predef = 0 where cxu_usuario = {CodigoUsuario}");
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE CajaxUsuario SET cxu_predef = 1 where cxu_usuario = {CodigoUsuario} and cxu_caja = {idCaja}");
        }

        public static void ModificarContra(string nuevaContra)
        {
            Datos.AccesoBase.InsertUpdateDatos($"UPDATE Usuario SET usu_contraseña = '{nuevaContra}' WHERE usu_codigo = {FLogin.IdUsuario}");
        }

        //Agrega los permisos correspondientes al nuevo usuario
        public static void AgregarPermisos(MenuDropDown m1, MenuDropDown m2, MenuDropDown m3, MenuDropDown m4, MenuDropDown m5, Form frm)
        {
            int nrousu = (Negocio.FGenerales.ultimoNumeroID("usu_codigo", "Usuario")) - 1;

            List<MRecalcularPermisos> lista = new List<MRecalcularPermisos>();
            lista = Negocio.Funciones.FRecalcularPermisos.ListaMenu(m1, m2, m3, m4, m5, frm);

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
            int permiso = ds.Tables[0].Rows[0]["par_permiso"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_permiso"]);

            int resultado;
            int codigo;

            foreach (var i in lista)
            {
                resultado = AccesoBase.ValidarDatos($"SELECT * FROM Menu WHERE mnu_codigo = '{i.mnu_codigo}' and mnu_sistema = 'CO'");

                if (resultado == 1)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Menu SET mnu_descri = '{i.mnu_descri}' WHERE mnu_codigo = '{i.mnu_codigo}' AND mnu_sistema = 'CO'");
                }
                else
                {
                    AccesoBase.InsertUpdateDatos($"INSERT INTO Menu (mnu_codigo, mnu_descri, mnu_sistema) VALUES ( '{i.mnu_codigo}', '{i.mnu_descri}', 'CO' )");
                }

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT * FROM Usuario WHERE usu_codigo = {nrousu}");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    codigo = Convert.ToInt32(dr2["usu_codigo"]);

                    resultado = AccesoBase.ValidarDatos($"SELECT * FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxUsu (mxu_usuario,mxu_codigo,mxu_activo,mxu_sistema) VALUES ( {codigo}, '{i.mnu_codigo}', {permiso}, 'CO')");
                    }
                }
            }
        }

        public static bool ValidarPermisoDefinirCaja()
        {
            int resultado = AccesoBase.ValidarDatos($"select * from PermisosxUsu where pxu_usuario = {FLogin.IdUsuario} and pxu_codigo = 10 and pxu_activo = '1' and pxu_sistema = 'CO'");
            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
