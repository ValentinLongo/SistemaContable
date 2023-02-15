using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Usuarios
{
    public partial class frmModificarContra : Form
    {
        public frmModificarContra()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            lbUsuario.Text = Negocio.FLogin.NombreUsuario;
            tbContraActual.Text = Negocio.FLogin.ContraUsuario;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (tbNuevaContra.Text == tbConfNuevaContra.Text)
            {
                Negocio.FUsuarios.ModificarContra(tbNuevaContra.Text);
                MessageBox.Show("Contraseña modificada correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinsiden");
            }
        }
    }
}
