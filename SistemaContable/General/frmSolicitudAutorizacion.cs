using Datos;
using Datos.Modelos;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable
{
    public partial class frmCambiarUsuario : Form
    {
        public static int perfil;
        public static int cambia;
        public frmCambiarUsuario()
        {
            InitializeComponent();
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

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //falta cambia
            if ((txtUsuario.Text != null && txtContraseña.Text != null) || (txtUsuario.Text != "" && txtContraseña.Text != ""))
            {
                txtUsuario.Text = txtUsuario.Text.ToUpper();
                txtContraseña.Text = txtContraseña.Text.ToUpper();

                int perfilautorizacion = 5;
                int estado = 0;

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT usu_perfil, usu_estado FROM Usuario WHERE usu_login = '{txtUsuario.Text}' and usu_contraseña = '{txtContraseña.Text}'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    perfilautorizacion = Convert.ToInt32(dr["usu_perfil"]);
                    estado = Convert.ToInt32(dr["usu_estado"]);
                    
                }
                int resultado = AccesoBase.ValidarDatos($"SELECT usu_login, usu_contraseña FROM Usuario WHERE usu_login = '{txtUsuario.Text}' and usu_contraseña = '{txtContraseña.Text}'");

                if (perfilautorizacion <= perfil && estado == 1 && resultado == 1)
                {
                    //hacer
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }
        //tablas usadas = Terminal y usuario (dsp borrar)
        private void frmCambiarUsuario_Load(object sender, EventArgs e)
        {
            int resultado = 0;
            int terminal = frmLogin.NumeroTerminal;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT ter_pideautcod FROM Terminal WHERE ter_codigo = {terminal}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                resultado = Convert.ToInt32(dr["ter_pideautcod"]);
            }

            if (resultado == 1)
            {
                frmCodigoBarra codigobarra = new frmCodigoBarra();
                codigobarra.Show();
            }
        }
    }
}
