using RJCodeAdvance.RJControls;
using SistemaContable.Inicio.Ver.Comunicacion_Interna;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmEstandar : Form
    {
        int terminal = frmLogin.NumeroTerminal;

        public frmEstandar(int proceso, string mensaje)
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            Proceso(proceso, mensaje);
        }

        private void Proceso(int proceso, string msg) 
        {
            if (proceso == 1)
            {
                Mensaje.Text = msg;
                return;
            }

            if (proceso == 2) // Auditoria Interna
            {
                Negocio.Funciones.Generales.FEstandar.Procesos(2, Mensaje, terminal, frmRangoFechas.Desde, frmRangoFechas.Hasta);
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
