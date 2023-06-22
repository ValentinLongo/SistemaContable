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
    public partial class frmMessageBox : Form
    {
        public static bool Acepto;
        public static bool Cancelo;

        public frmMessageBox(string msg1, string msg2, bool dialogresult, [Optional] bool MsgLargo)
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            Acepto = false;
            Cancelo = false;
            Seteo(msg1, msg2, dialogresult, MsgLargo);
        }

        private void Seteo(string msg1, string msg2, bool dialogresult, bool MsgLargo)
        {
            if (dialogresult)
            {
                btnAceptar.Visible = true;
                btnAceptar.Location = new Point(68, 92);
                btnCancelar.Visible = true;
                lblMSG1.Text = msg1;

                if (MsgLargo)
                {
                    txtMsgLargo.Text = msg2;
                    txtMsgLargo.Visible = true;
                    lblMSG2.Visible = false;
                }
                else
                {
                    lblMSG2.Text = msg2;

                    //para que el msg comun se centre sin importar su longitud
                    int a = this.Width - lblMSG2.Width;
                    a = a / 2;
                    lblMSG2.Location = new Point(a, 54);
                    //

                    txtMsgLargo.Visible = false;
                    lblMSG2.Visible = true;
                }
            }
            else
            {
                btnAceptar.Visible = true;
                btnAceptar.Location = new Point(142, 92);
                btnCancelar.Visible = false;
                lblMSG1.Text = msg1;

                if (MsgLargo)
                {
                    txtMsgLargo.Text = msg2;
                    txtMsgLargo.Visible = true;
                    lblMSG2.Visible = false;
                }
                else
                {
                    lblMSG2.Text = msg2;

                    int a = this.Width - lblMSG2.Width;
                    a = a / 2;
                    lblMSG2.Location = new Point(a, 54);

                    txtMsgLargo.Visible = false;
                    lblMSG2.Visible = true;
                }
            }
        }

        private void ClickAceptar(object sender, EventArgs e)
        {
            Acepto = true;
            this.Close();
        }

        private void ClickCancelar(object sender, EventArgs e)
        {
            Cancelo = true;
            this.Close();
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
