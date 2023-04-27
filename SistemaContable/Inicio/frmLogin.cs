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
using SistemaContable.General;

namespace SistemaContable
{
    public partial class frmLogin : Form
    {
        public static int NumeroTerminal;
        public frmLogin()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);

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
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Error en los datos de la conexion",false);
                MessageBox.ShowDialog();
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
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                txtUsuario.Text = txtUsuario.Text.ToUpper();
                txtConstrasenia.Text = txtConstrasenia.Text.ToUpper();
                Negocio.FLogin.BuscarIdUsuario(txtUsuario.Text, txtConstrasenia.Text);
                int resultado = Negocio.FLogin.buscarUsuario(txtUsuario.Text, txtConstrasenia.Text);
                if (resultado == 1)
                {
                    Negocio.FLogin.buscarNombreEmpresa();
                    frmCarga PantallaCarga = new frmCarga();
                    PantallaCarga.lblUsuario.Text = Negocio.FLogin.NombreUsuario;
                    this.Visible = false;
                    PantallaCarga.ShowDialog();
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Datos Incorrectos", false);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                if (lblMayus.Visible)
                {
                    lblMayus.Visible = false;
                }
                else
                {
                    lblMayus.Visible = true;
                }
            }
        }

        private void txtConstrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                if (lblMayus.Visible)
                {
                    lblMayus.Visible = false;
                }
                else
                {
                    lblMayus.Visible = true;
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

