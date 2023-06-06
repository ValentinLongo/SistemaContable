using SistemaContable.General;
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

namespace SistemaContable.Inicio.Ver.Calendario
{
    public partial class frmAggModCalendario : Form
    {
        private static int proceso;
        private static string horavieja;
        private static string comentarioviejo;

        public frmAggModCalendario(int seteo, string fecha, [Optional] string hora, [Optional] string comentario)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            horavieja = hora;
            comentarioviejo = comentario;

            txtFecha.Text = fecha;
            txtFecha.Enabled = false;
            maskHora.Mask = "00:00:00";

            if (seteo == 1)
            {
                maskHora.Text = "  :  :00";
            }
            else
            {
                maskHora.Text = hora;
                txtComentario.Text = comentario;
            }

            proceso = seteo;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                if (Negocio.FGenerales.ValidacionHoraFecha(1, maskHora) == false)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Hora ingresada Invalida.", false);
                    MessageBox.ShowDialog();
                    return;
                }

                if (proceso == 1)
                {
                    Negocio.Funciones.Ver.FCalendario.Agregar(txtFecha.Text, maskHora.Text, txtComentario.Text);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente.", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                else if (proceso == 2)
                {
                    Negocio.Funciones.Ver.FCalendario.Modificar(txtFecha.Text, maskHora.Text, txtComentario.Text, horavieja, comentarioviejo);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente.", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos.", false);
                MessageBox.ShowDialog();
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
