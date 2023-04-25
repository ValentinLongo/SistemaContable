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
    public partial class frmRangoFechas : Form
    {
        public static DateTime Desde;
        public static DateTime Hasta;

        private static int PROCESO = 1; //para utilizar el frm como lo requiera otro frm

        public frmRangoFechas(int proceso)
        {
            InitializeComponent();

            PROCESO = proceso;

            dtDesde.Value = Convert.ToDateTime("01/01/1900");
            dtHasta.Value = DateTime.Now;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtHasta.Value) > DateTime.Now || Convert.ToDateTime(dtHasta.Value) < Convert.ToDateTime("01/01/1900")) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Error: Fecha ingresada Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Convert.ToDateTime(dtDesde.Value) < Convert.ToDateTime("01/01/1900") || Convert.ToDateTime(dtDesde.Value) > DateTime.Now) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Error: Fecha ingresada Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Convert.ToDateTime(dtDesde.Value) > Convert.ToDateTime(dtHasta.Value))
            {
                frmMessageBox MessageBox = new frmMessageBox("Atención!", "Error: Fecha ingresada Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            Desde = Convert.ToDateTime(dtDesde.Value);
            Hasta = Convert.ToDateTime(dtHasta.Value);

            if (PROCESO == 1)
            {
                this.Close();
                return;
            }

            if (PROCESO == 2) //Auditoria Interna
            {
                frmEstandar frm = new frmEstandar(2, "");
                frm.Show();
                this.Close();
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
