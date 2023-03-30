using Negocio;
using SistemaContable.General;
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

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDatos();
        }

        private void cargarDatos()
        {
            lbUsuario.Text = Negocio.FLogin.NombreUsuario;
            tbContraActual.Text = Negocio.FLogin.ContraUsuario;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                if (tbNuevaContra.Text == tbConfNuevaContra.Text)
                {
                    Negocio.FUsuarios.ModificarContra(tbNuevaContra.Text);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Contraseña modificada correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Las contraseñas no coinsiden", false);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }
    }
}
