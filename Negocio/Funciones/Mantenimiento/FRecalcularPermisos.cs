using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones
{
    public class FRecalcularPermisos
    {
        private static int permiso;
        public static void RecalculaPermisosEspeciales()
        {
            int codigo; // tabla permisos
            int usuario; // tabla usuario
            int perfil; // tabla perfil
            int resultado;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_permiso FROM Parametro");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               permiso = Convert.ToInt32(dr["par_permiso"]);
            }

            ds = AccesoBase.ListarDatos($"SELECT pef_codigo FROM Permisos WHERE pef_sistema = 'CO' ORDER BY pef_codigo");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                codigo = Convert.ToInt32(dr["pef_codigo"]);

                ds = AccesoBase.ListarDatos($"SELECT usu_codigo FROM Usuario ORDER BY usu_codigo");
                foreach (DataRow dr2 in ds.Tables[0].Rows) 
                {
                    usuario = Convert.ToInt32(dr2["usu_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT pxu_usuario,pxu_codigo,pxu_sistema FROM PermisosxUsu WHERE pxu_usuario = {usuario} AND pxu_codigo = {codigo} AND pxu_sistema = 'CO'");
                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO PermisosxUsu ( pxu_usuario, pxu_codigo, pxu_activo, pxu_sistema ) VALUES ( {usuario}, {codigo}, {permiso}, 'CO' )");
                    }
                }

                ds = AccesoBase.ListarDatos($"SELECT per_codigo FROM Perfil ORDER BY = per_codigo");
                foreach (DataRow dr3 in ds.Tables[0].Rows) 
                {
                    perfil = Convert.ToInt32(dr3["per_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT pxp_perfil,pxp_codigo,pxp_sistema FROM PermisosxPerfil WHERE pxp_perfil = {perfil} AND pxp_codigo = {codigo} AND pxp_sistema = 'CO'");
                    if (resultado == 0 )
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO PermisosxPerfil ( pxp_perfil, pxp_codigo, pxp_activo, pxp_sistema ) VALUES ( {perfil}, {codigo}, {permiso}, 'CO' )");
                    }
                }
            }
        }
    }
}
