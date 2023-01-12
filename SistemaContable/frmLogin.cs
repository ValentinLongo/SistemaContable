using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Negocio;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Security.Policy;
using Datos;
using System.Net;
using System.Collections;
using Bunifu.UI.WinForms.Helpers.Transitions;

namespace SistemaContable
{
    public partial class frmLogin : Form
    {
        public static int NumeroTerminal;

        public frmLogin()
        {
            InitializeComponent();
            Negocio.FGenerales.EventosFormulario(this);

            //BUSCO NOMBRE DEL EQUIPO
            string nombreEquipo = Environment.MachineName;
            string localIP = "";

            //BUSQUEDA IP
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }

            //COMPLETO LA CONEXION CON LOS ARGUMENTOS QUE LE PASAMOS MEDIANTE EL ACCESO DIRECTO. ORDEN = SERVIDOR,BASE DE DATOS, TERMINAL.
            try
            {
                NumeroTerminal = Negocio.FLogin.completarConexion();
            }
            catch
            {
                MessageBox.Show("Error en los datos de la conexion");
                this.Close();
            }

            //Negocio.FFormatoSistema.SetearFormato(this);

        }

        //MUESTRA MENU INICIO
        private void pbVisibilidad_Click(object sender, EventArgs e)
        {
            if (txtConstrasenia.PasswordChar == Convert.ToChar("*"))
            {
                txtConstrasenia.PasswordChar = '\0';
                pbVisibilidad.Visible = false;
                pbOcultar.Visible = true;
            }
        }

        //OCULTA MENU INICIO
        private void pbOcultar_Click(object sender, EventArgs e)
        {
            if (txtConstrasenia.PasswordChar != Convert.ToChar("*"))
            {
                txtConstrasenia.PasswordChar = Convert.ToChar("*");
                pbVisibilidad.Visible = true;
                pbOcultar.Visible = false;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text != null && txtConstrasenia.Text != null) || (txtUsuario.Text != "" && txtConstrasenia.Text != ""))
            {
                txtUsuario.Text = txtUsuario.Text.ToUpper();
                txtConstrasenia.Text = txtConstrasenia.Text.ToUpper();
                Negocio.FLogin.BuscarIdUsuario(txtUsuario.Text, txtConstrasenia.Text);
                int resultado = Negocio.FLogin.buscarUsuario(txtUsuario.Text, txtConstrasenia.Text);
                if (resultado == 1)
                {
                    frmCarga PantallaCarga = new frmCarga();
                    PantallaCarga.lblUsuario.Text = Negocio.FLogin.NombreUsuario;
                    this.Visible = false;
                    PantallaCarga.ShowDialog();
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

