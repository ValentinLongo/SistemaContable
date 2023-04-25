using Bunifu.Framework.UI;
using Datos;
using RJCodeAdvance.RJControls;
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
        //DEVUELVE EL TIEMPO QUE FALTA PARA QUE UNA TAREA FINALIZE
        public static string DisparadorInicio(Control lblnuevomensaje) 
        {
            if (Negocio.Funciones.Ver.FComunicacionInterna.NuevosMSGs()) //PARA VER SI HAY NUEVOS MSG
            {
                lblnuevomensaje.Visible = true;
            }

            string tiempo = "";
            switch (Negocio.Funciones.Ver.FCalendario.MSGTareas()) //PARA CALCULAR EL TIEMPO QUE FALTA PARA QUE FINALIZE UNA TAREA
            {
                case 1:
                    tiempo = "2 horas";
                    break;

                case 2:
                    tiempo = "1 hora";
                    break;

                case 3:
                    tiempo = "30 minutos";
                    break;

                case 4:
                    tiempo = "15 minutos";
                    break;

                case 5:
                    tiempo = "5 minutos";
                    break;

                case 6:
                    tiempo = "expiro";
                    break;

                default:
                    break;
            }
            return tiempo;
        }

        //PARA ABRIR/CERRAR SESIÓN
        public static void Sesion(Form Inicio, ToolStrip tsAccesosDirectos, int proceso)
        {
            if (proceso == 1) //ABRE
            {
                foreach (Control Ctrl in Inicio.Controls)
                {
                    if (Ctrl is BunifuGradientPanel)
                    {
                        foreach (Control Ctrl2 in Ctrl.Controls)
                        {
                            if (Ctrl2 is RJButton)
                            {
                                Ctrl2.Enabled = false;
                            }
                        };
                    }
                    if (Ctrl is ToolStrip)
                    {
                        foreach (ToolStripItem botones in tsAccesosDirectos.Items)
                        {
                            if (botones is ToolStripButton)
                            {
                                if (botones.Tag.ToString() != "12345")
                                {
                                    botones.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            else if (proceso == 2) //CIERRA
            {
                foreach (Control Ctrl in Inicio.Controls)
                {
                    if (Ctrl is BunifuGradientPanel)
                    {
                        foreach (Control Ctrl2 in Ctrl.Controls)
                        {
                            if (Ctrl2 is RJButton)
                            {
                                Ctrl2.Enabled = true;
                            }
                        }
                    }
                    if (Ctrl is ToolStrip)
                    {
                        foreach (ToolStripItem botones in tsAccesosDirectos.Items)
                        {
                            if (botones is ToolStripButton)
                            {
                                if (botones.Tag.ToString() != "12345")
                                {
                                    botones.Enabled = true;
                                }
                            }
                        }                      
                    }
                }
            }
        }

        //SETEO DATOS INICIO
        public static void DatosUsuEmp(Control lblusuario, Control lblempresa, Control lblperfil)
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

        public static bool ValidacionSupervisor() 
        {
            int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Usuario WHERE usu_codigo = {FLogin.IdUsuario} AND usu_perfil = 1");
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
