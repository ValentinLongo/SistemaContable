﻿using Datos;
using Datos.Modelos;
using SistemaContable.General;
using SistemaContable.Parametrizacion_Permisos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable
{
    public partial class frmAutorización : Form
    {
        public static string usuario;
        public static string contraseña;
        public static bool visibilidad = false;
        private static bool CBI = false; //codigo de barra incorrecto.
        private static int PERFIL;
        private static bool CAMBIA;
        private static int TIPO; 
        private static int COD1; 
        private static int COD2; 
        private static string COD3;
        private static string DESCRI1;
        private static string DESCRI2;
        private static string DESCRI3;
        private static string OBSERVA;
        private static string REFERENCIA;

        public frmAutorización()
        {
            InitializeComponent();
            this.Select(); //con esto funciona el evento keydown.
            frmCodigoBarra codigobarra = new frmCodigoBarra();

            int resultado = 0;
            int terminal = frmLogin.NumeroTerminal;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select ter_pideautcod from terminal where ter_codigo = {terminal}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["ter_pideautcod"] != DBNull.Value)
                {
                    resultado = Convert.ToInt32(dr["ter_pideautcod"]);
                }
            }
            if (resultado == 1)
            {
                visibilidad = true;
                codigobarra.ShowDialog();
                visibilidad = false;
                if (frmCodigoBarra.usucodigobarra != "" && frmCodigoBarra.contracodigobarra != "")
                {
                    txtUsuario.Text = frmCodigoBarra.usucodigobarra;
                    txtContraseña.Text = frmCodigoBarra.contracodigobarra;
                    usuario = txtUsuario.Text;
                    contraseña = txtContraseña.Text;
                }
                else
                {
                    CBI = true;
                }
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            bool autorizado = Autoriza(PERFIL, CAMBIA, TIPO.ToString(), COD1.ToString(), COD2.ToString(), COD3, DESCRI1, DESCRI2, DESCRI3, OBSERVA, REFERENCIA);
            if (autorizado)
            {
                if (frmInicio.frm == "perfiles")
                {
                    frmPermisosPerfil permisosperfil = new frmPermisosPerfil();
                    permisosperfil.Show();
                    this.Close();
                    frmAutorización.usuario = "";
                    frmAutorización.contraseña = "";
                }
                else if (frmInicio.frm == "usuarios")
                {
                    frmPermisosUsu permisosusuario = new frmPermisosUsu();
                    permisosusuario.Show();
                    this.Close();
                    frmAutorización.usuario = "";
                    frmAutorización.contraseña = "";
                }
                else if (frmInicio.frm == "estandar")
                {
                    this.Close();
                    frmAutorización.usuario = "";
                    frmAutorización.contraseña = "";
                    DialogResult boton = MessageBox.Show("Atención: ¿desea recalcular los permisos del menu?", "Contable", MessageBoxButtons.OKCancel);
                    if (boton == DialogResult.OK)
                    {
                        frmEstandar.proceso = 1;
                        frmEstandar.mensaje = "Se estan Revisando los Permisos de Menu asignados para los Usuarios. Porfavor espere...";
                        frmEstandar estandar = new frmEstandar();
                        estandar.ShowDialog();
                    }
                }
            }
        }

        public static bool Autoriza(int perfil, bool cambia, [Optional] string tipo, [Optional] string cod1, [Optional] string cod2, [Optional] string cod3, [Optional] string descri1, [Optional] string descri2, [Optional] string descri3, [Optional] string observa, [Optional] string referencia)
        {
            PERFIL = perfil;
            CAMBIA = cambia;
            if (tipo == null || tipo == "")
            {
                TIPO = 0;
            }
            else
            {
                TIPO = Convert.ToInt32(tipo);
            }
            COD1 = Convert.ToInt32(cod1);
            COD2 = Convert.ToInt32(cod2);
            COD3 = cod3;
            DESCRI1 = descri1;
            DESCRI2 = descri2;
            DESCRI3 = descri3;
            OBSERVA = observa;
            REFERENCIA = referencia;

            if (usuario != null && contraseña != null && usuario != "" && contraseña != "")
            {
                usuario = usuario.ToUpper();
                contraseña = contraseña.ToUpper();

                int perfilautorizacion = 5;
                int estado = 0;

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT usu_perfil, usu_estado FROM Usuario WHERE usu_login = '{usuario}' and usu_contraseña = '{contraseña}'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    perfilautorizacion = Convert.ToInt32(dr["usu_perfil"]);
                    estado = Convert.ToInt32(dr["usu_estado"]);

                }
                int resultado = AccesoBase.ValidarDatos($"SELECT usu_login, usu_contraseña FROM Usuario WHERE usu_login = '{usuario}' and usu_contraseña = '{contraseña}'");

                if(cambia)
                {
                    Negocio.FLogin.NombreUsuario = usuario;
                    Negocio.FLogin.ContraUsuario = contraseña;
                }
                if (perfilautorizacion <= perfil && estado == 1 && resultado == 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error: Datos ingresados invalidos", "Mensaje");
                    return false;
                }
            }
            else
            {
                if (CBI)
                {
                    visibilidad = false;
                }
            }
            return false;
        }

        private void frmAutorización_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                int codigo = Negocio.FGenerales.ultimoNumeroID("aut_codigo", "Autoriza");

                if (TIPO == 0)
                {
                    MessageBox.Show("No se puede solicitar autorizacion remota en este caso.","Atencion!");
                }
                else
                {
                    string hora = DateTime.Now.ToLongTimeString();
                    string fecha = DateTime.Now.ToShortDateString();
                    int terminal = frmLogin.NumeroTerminal;

                    if (timer1.Enabled == false)
                    {
                        timer1.Enabled = true;
                        txtUsuario.Enabled = false;
                        txtContraseña.Enabled = false;
                        btnAcceder.Enabled = false;
                        labelcontrolbox.Text = "ESPERANDO AUTORIZACIÓN...";

                        switch (TIPO)
                        {
                            case 1:
                                AccesoBase.InsertUpdateDatos($"INSERT INTO Autoriza (aut_codigo, aut_cod1, aut_descri1, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{usuario}', '{fecha}', '{hora}', {terminal}, {TIPO}, '{REFERENCIA}')");
                                break;

                            case 2:
                                AccesoBase.InsertUpdateDatos($"INSERT INTO Autoriza (aut_codigo, aut_cod1, aut_descri1, aut_descri2, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{DESCRI2}', '{usuario}', '{fecha}', '{hora}', {terminal},{TIPO},'{REFERENCIA}')");
                                break;

                            case 3:
                                AccesoBase.InsertUpdateDatos($"INSERT INTO autoriza (aut_codigo, aut_cod1, aut_descri1, aut_descri2, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_observa, aut_cod3, aut_descri3, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{DESCRI2}', '{usuario}', '{fecha}', '{hora}', '{terminal}', {TIPO}, '{OBSERVA}', '{COD3}', '{DESCRI3}', '{REFERENCIA}')");
                                break;

                            case 4:
                                AccesoBase.InsertUpdateDatos($"INSERT INTO autoriza (aut_codigo, aut_cod1, aut_descri1, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{usuario}', '{fecha}', '{hora}', '{terminal}', {TIPO}, '{REFERENCIA}')");
                                break;

                            case 5:                              
                                AccesoBase.InsertUpdateDatos($"INSERT INTO autoriza (aut_codigo, aut_cod1, aut_descri1, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{usuario}', '{fecha}', '{hora}', '{terminal}', {TIPO}, '{REFERENCIA}')");
                                break;

                            case 6:
                                AccesoBase.InsertUpdateDatos($"INSERT INTO autoriza (aut_codigo, aut_cod1, aut_descri1, aut_usuarioO, aut_fechaO, aut_horaO, aut_terminalO, aut_tipo, aut_referencia) VALUES ({codigo}, {COD1}, '{DESCRI1}', '{usuario}', '{fecha}', '{hora}', '{terminal}', {TIPO}, '{REFERENCIA}')");
                                break;
                        }
                    }
                    else
                    {
                        labelcontrolbox.Text = "Solicitud de Autorización";
                        timer1.Enabled = false;
                        txtUsuario.Enabled = true;
                        txtContraseña.Enabled = true;
                        btnAcceder.Enabled = true;
                        txtUsuario.Text = "";
                        txtContraseña.Text = "";
                        AccesoBase.InsertUpdateDatos($"DELETE * FROM autoriza where aut_codigo = {codigo}");
                    }
                }
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
