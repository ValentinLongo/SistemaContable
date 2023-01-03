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

namespace SistemaContable
{
    public partial class frmLogin : Form
    {
        public static int NumeroTerminal;
        public frmLogin()
        {
            InitializeComponent();

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
        }

        private void pbVisibilidad_Click(object sender, EventArgs e)
        {
            if (txtConstrasenia.PasswordChar == Convert.ToChar("*"))
            {
                txtConstrasenia.PasswordChar = '\0';
                pbVisibilidad.Visible = false;
                pbOcultar.Visible = true;
            }
        }

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
                int resultado = Negocio.FLogin.buscarUsuario(txtUsuario.Text, txtConstrasenia.Text);
                if (resultado == 1)
                {
                    frmInicio inicio = new frmInicio();
                    this.Visible = false;
                    inicio.ShowDialog();
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
    }
}
