using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmSesion : Form
    {
        public static bool autorizado;

        public frmSesion()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
                return;
            }

            string usuario = txtUsuario.Text.ToUpper();
            string contraseña = txtContraseña.Text.ToUpper();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Usuario WHERE usu_login = '{usuario}'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                autorizado = false;
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Usuario Incorrecto!", false);
                MessageBox.ShowDialog();
                return;
            }

            Negocio.FLogin.IdUsuario = Convert.ToInt32(ds.Tables[0].Rows[0]["usu_codigo"]);
            Negocio.FLogin.NombreUsuario = ds.Tables[0].Rows[0]["usu_nombre"].ToString();
            Negocio.FLogin.ContraUsuario = ds.Tables[0].Rows[0]["usu_contraseña"].ToString();

            autorizado = true;
            this.Close();
        }

        private void pbVisibilidad_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == Convert.ToChar("*"))
            {
                txtContraseña.PasswordChar = '\0';
                pbVisibilidad.Visible = false;
                pbOcultar.Visible = true;
            }
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar != Convert.ToChar("*"))
            {
                txtContraseña.PasswordChar = Convert.ToChar("*");
                pbVisibilidad.Visible = true;
                pbOcultar.Visible = false;
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
