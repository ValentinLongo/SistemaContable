using Datos;
using Datos.Modelos;
using RJCodeAdvance.RJControls;
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

        public static List<MRecalcularPermisos> ListaMenu(MenuDropDown mArchivos, MenuDropDown mVer, MenuDropDown mContabilidad, MenuDropDown mMantenimiento, MenuDropDown mAyuda, Form frm)
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
                        mnu_codigo = item2.Tag.ToString(),
                        mnu_descri = item2.Text,
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
                            mnu_codigo = item2.Tag.ToString(),
                            mnu_descri = item2.Text,
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
            foreach (Control Ctrl in frm.Controls) //para agregar el nivel raiz a la lista, ya que no forma parte de los menus
            {
                if (Ctrl.Name == "PanelMenu")
                {
                    foreach (Control Ctrl2 in Ctrl.Controls)
                    {
                        if (Ctrl2.Tag == null)
                        {
                            continue;
                        }
                        if (Ctrl2.Tag.ToString() == "10" || Ctrl2.Tag.ToString() == "20" || Ctrl2.Tag.ToString() == "30" || Ctrl2.Tag.ToString() == "40" || Ctrl2.Tag.ToString() == "50")
                        {
                            MRecalcularPermisos mrecalcular1 = new MRecalcularPermisos()
                            {
                                mnu_codigo = Ctrl2.Tag.ToString(),
                                mnu_descri = Ctrl2.Text.Trim(),
                            };
                            lista.Add(mrecalcular1);
                        }
                    }
                }
            }
            return lista;
        }

        public static void RecalcularPermisos(MenuDropDown mArchivos, MenuDropDown mVer, MenuDropDown mContabilidad, MenuDropDown mMantenimiento, MenuDropDown mAyuda, Form frm)
        {
            List<MRecalcularPermisos> lista = new List<MRecalcularPermisos>();
            lista = ListaMenu(mArchivos, mVer, mContabilidad, mMantenimiento, mAyuda, frm);

            int resultado;
            int codigo;
            int perfil;
            bool bandera;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
            permiso = ds.Tables[0].Rows[0]["par_permiso"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_permiso"]);

            Cursor.Current = Cursors.WaitCursor;
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
                ds2 = AccesoBase.ListarDatos($"SELECT * FROM Usuario");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    codigo = Convert.ToInt32(dr2["usu_codigo"]);

                    resultado = AccesoBase.ValidarDatos($"SELECT * FROM MenuxUsu WHERE mxu_usuario = {codigo} AND mxu_codigo = '{i.mnu_codigo}' AND mxu_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxUsu (mxu_usuario,mxu_codigo,mxu_activo,mxu_sistema) VALUES ( {codigo}, '{i.mnu_codigo}', {permiso}, 'CO' )");
                    }
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT * FROM Perfil");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    perfil = Convert.ToInt32(dr3["per_codigo"]);

                    resultado = AccesoBase.ValidarDatos($"SELECT * FROM MenuxPerfil WHERE mxp_perfil = {perfil} AND mxp_codigo = '{i.mnu_codigo}' AND mxp_sistema = 'CO'");

                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxPerfil (mxp_perfil,mxp_codigo,mxp_activo,mxp_sistema) VALUES ({perfil}, '{i.mnu_codigo}', {permiso}, 'CO')");
                    }
                }
            }

            bandera = true;

            DataSet ds4 = new DataSet();
            ds4 = AccesoBase.ListarDatos($"SELECT * FROM menu WHERE mnu_sistema = 'CO'");
            foreach (DataRow dr in ds4.Tables[0].Rows)
            {
                foreach (var i in lista)
                {
                    if (i.mnu_codigo == dr["mnu_codigo"].ToString())
                    {
                        bandera = false;
                    }
                }
                if (bandera)
                {
                    AccesoBase.InsertUpdateDatos($"DELETE FROM Menu WHERE mnu_codigo = '{dr["mnu_codigo"].ToString()}' AND mnu_sistema = 'CO'");
                    AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxUsu WHERE mxu_codigo = '{dr["mnu_codigo"].ToString()}' AND mxu_sistema = 'CO'");
                    AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxPerfil WHERE mxp_codigo = '{dr["mnu_codigo"].ToString()}' AND mxp_sistema = 'CO'");
                }
                else
                {
                    bandera = true;
                }
            }
            Cursor.Current = Cursors.Default;
        }


        public static void RecalcularPermisosEspeciales()
        {
            int codigo; // tabla permisos
            int usuario; // tabla usuario
            int perfil; // tabla perfil
            int resultado;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Parametro");
            permiso = ds.Tables[0].Rows[0]["par_permiso"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_permiso"]);

            Cursor.Current = Cursors.WaitCursor;

            ds = AccesoBase.ListarDatos($"SELECT * FROM Permisos WHERE pef_sistema = 'CO'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                codigo = Convert.ToInt32(dr["pef_codigo"]);

                ds = AccesoBase.ListarDatos($"SELECT * FROM Usuario");
                foreach (DataRow dr2 in ds.Tables[0].Rows)
                {
                    usuario = Convert.ToInt32(dr2["usu_codigo"]);

                    resultado = AccesoBase.ValidarDatos($"SELECT * FROM PermisosxUsu WHERE pxu_usuario = {usuario} AND pxu_codigo = {codigo} AND pxu_sistema = 'CO'");
                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO PermisosxUsu ( pxu_usuario, pxu_codigo, pxu_activo, pxu_sistema ) VALUES ( {usuario}, {codigo}, {permiso}, 'CO' )");
                    }
                }
            }

            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();

            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Permisos WHERE pef_sistema = 'CO'");
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                ds3 = AccesoBase.ListarDatos("Select * From Perfil");
                foreach (DataRow dr2 in ds3.Tables[0].Rows)
                {
                    perfil = Convert.ToInt32(dr2["per_codigo"]);

                    resultado = AccesoBase.ValidarDatos($"SELECT * FROM PermisosxPerfil WHERE pxp_perfil = {perfil} AND pxp_codigo = {Convert.ToInt32(dr["pef_codigo"])} AND pxp_sistema = 'CO'");
                    if (resultado == 0)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO PermisosxPerfil (pxp_perfil, pxp_codigo, pxp_activo, pxp_sistema) VALUES ({Convert.ToInt32(dr2["per_codigo"])}, {Convert.ToInt32(dr["pef_codigo"])}, {permiso}, 'CO')");
                    }
                }
            }

            AccesoBase.InsertUpdateDatos("Delete PermisosxUsu From PermisosxUsu Left Join Permisos on pxu_codigo = pef_codigo Where pef_sistema = 'CO' And pxu_sistema = 'CO' And pef_codigo is null");
            AccesoBase.InsertUpdateDatos("Delete PermisosxPerfil From PermisosxPerfil Left Join Permisos on pxp_codigo = pef_codigo Where pxp_sistema = 'CO' And pef_sistema = 'CO' And pef_codigo is null");

            Cursor.Current = Cursors.Default;
        }
    }
}
