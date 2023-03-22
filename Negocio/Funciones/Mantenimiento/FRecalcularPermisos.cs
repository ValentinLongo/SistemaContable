using Datos;
using Datos.Modelos;
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

        public static void RecalcularPermisos(MenuDropDown mArchivos, MenuDropDown mVer, MenuDropDown mContabilidad , MenuDropDown mMantenimiento, MenuDropDown mAyuda) 
        {
            List<MRecalcularPermisos> lista = new List<MRecalcularPermisos>();
            foreach (ToolStripMenuItem item in mArchivos.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in mVer.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in mContabilidad.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular2);
                }
            }
            foreach (ToolStripMenuItem item in mMantenimiento.Items)
            {
                if (item.Tag != null)
                {
                    MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                    {
                        mnu_codigo = item.Tag.ToString(),
                        mnu_descri = item.Text,
                    };
                    lista.Add(mrecalcular1);
                }
                foreach (ToolStripMenuItem item2 in item.DropDownItems)
                {
                    if (item2.Tag != null)
                    {
                        MRecalcularPermisos mrecalcular2 = new MRecalcularPermisos()
                        {
                            mnu_codigo = item.Tag.ToString(),
                            mnu_descri = item.Text,
                        };
                        lista.Add(mrecalcular2);
                    }
                }
            }
            foreach (ToolStripMenuItem item in mAyuda.Items)
            {
                MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                {
                    mnu_codigo = item.Tag.ToString(),
                    mnu_descri = item.Text,
                };
                lista.Add(mrecalcular1);
            }

            int resultado;
            int codigo;
            int perfil;
            bool bandera;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_permiso FROM Parametro");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                permiso = Convert.ToInt32(dr["par_permiso"]);
            }
            foreach (var i in lista)
            {
                resultado = 0;
                resultado = AccesoBase.ValidarDatos($"SELECT mnu_codigo FROM Menu WHERE mnu_codigo = '{i.mnu_codigo}' and mnu_sistema = 'CO'");

                if (resultado == 1)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Menu SET mnu_descri = '{i.mnu_descri}' WHERE mnu_codigo = '{i.mnu_codigo}' AND mnu_sistema = 'CO'");
                }
                else
                {
                    AccesoBase.InsertUpdateDatos($"INSERT INTO Menu ( mnu_codigo, mnu_descri, mnu_sistema ) VALUES ( '{i.mnu_codigo}', '{i.mnu_descri}', 'CO' )");
                }

                ds = AccesoBase.ListarDatos($"SELECT usu_codigo FROM Usuario");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    codigo = Convert.ToInt32(dr["usu_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT mxu_usuario,mxu_codigo,mxu_sistema FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxUsu ( mxu_usuario,mxu_codigo,mxu_activo,mxu_sistema ) VALUES ( {codigo}, '{i.mnu_codigo}', {permiso}, 'CO' )");
                    }
                }

                ds = AccesoBase.ListarDatos($"SELECT per_codigo FROM Perfil");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    perfil = Convert.ToInt32(dr["per_codigo"]);

                    resultado = 0;
                    resultado = AccesoBase.ValidarDatos($"SELECT mxp_perfil,mxp_codigo,mxp_sistema FROM MenuxPerfil WHERE mxp_perfil = {perfil} AND mxp_codigo = '{i.mnu_codigo}' AND mxp_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxPerfil ( mxp_perfil,mxp_codigo,mxp_activo,mxp_sistema ) VALUES ( {perfil}, '{i.mnu_codigo}', {permiso}, 'CO' )");
                    }
                }

                bandera = true;

                ds = AccesoBase.ListarDatos($"SELECT mnu_codigo FROM menu WHERE mnu_sistema = 'CO'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int tag = Convert.ToInt32(dr["mnu_codigo"]);

                    if (tag == Convert.ToInt32(i.mnu_codigo))
                    {
                        bandera = false;
                    }
                    if (bandera)
                    {
                        //terminar deletes
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM Menu WHERE mnu_codigo = '{i.mnu_codigo}' AND mnu_descri = '{i.mnu_descri}' AND mnu_sistema = 'CO'");
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_activo = {permiso} AND mxu_sistema = 'CO'");
                        //AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxPerfil WHERE mxup_perfil = {perfil} AND mxp_codigo = '{i.mnu_codigo}' AND mxp_activo = {permiso} AND mxp_sistema = 'CO'");
                    }
                }
            }
        }


        public static void RecalcularPermisosEspeciales()
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

                //falta deletes
            }
        }
    }
}
