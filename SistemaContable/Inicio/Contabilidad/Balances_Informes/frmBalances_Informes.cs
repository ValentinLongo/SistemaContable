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

namespace SistemaContable.Inicio.Contabilidad.Balance_de_Sumas_y_Saldos
{
    public partial class frmBalances_Informes : Form
    {
        private static int Proceso;

        public frmBalances_Informes(int proceso)
        {
            InitializeComponent();
            Seteo(proceso);
            Proceso = proceso;
        }

        private void Seteo(int proceso) 
        {
            maskDesde.Mask = "00-00-00";
            maskHasta.Mask = "00-00-00";

            if (proceso == 1) //Balance de Sumas y Saldos
            {
                Check1.Visible = true;
                lbl1.Visible = true;
                Check1.Location = new Point(101, 158);
                lbl1.Location = new Point(124, 158);

                Check2.Visible = false;
                lbl2.Visible = false;
            }
            else if (proceso == 2) //Balance General
            {
                Check1.Visible = true;
                lbl1.Visible = true;
                Check1.Location = new Point(101, 141);
                lbl1.Location = new Point(124, 141);

                Check2.Visible = true;
                lbl2.Visible = true;
            }
            else if (proceso == 3) //Informes
            {
                Check1.Visible = false;
                lbl1.Visible = false;
                Check2.Visible = false;
                lbl2.Visible = false;

                lblModelo.Visible = true;
                lblModelo.Location = new Point(18, 74);
                txtCodModelo.Visible = true;
                txtCodModelo.Location = new Point(76, 70);
                pModelo1.Visible = true;
                pModelo1.Location = new Point(76, 89);
                txtDescriModelo.Visible = true;
                txtDescriModelo.Location = new Point(158, 71);
                pModelo2.Visible = true;
                pModelo2.Location = new Point(158, 89);
                btnModelo.Visible = true;
                btnModelo.Location = new Point(386, 69);

                label1.Location = new Point(24, 102);
                maskDesde.Location = new Point(77, 104);
                label2.Location = new Point(27, 131);
                maskHasta.Location = new Point(76, 132);

                lbl3.Visible = true;
                Check3.Visible = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Proceso == 1) //Balance de Sumas y Saldos
            {

            }
            else if (Proceso == 2) //Balance General
            {

            }
            else if (Proceso == 3) //Informes
            {

            }
        }

        private void btnEjercicio_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("eje_codigo as Código, eje_descri as Descripción", "Ejercicio", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodEjercicio.Text = frmConsultaGeneral.codigoCG;
            txtDescriEjercicio.Text = frmConsultaGeneral.descripcionCG;
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("bal_codigo as Código, bal_descri as Descripción", "Balance", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodModelo.Text = frmConsultaGeneral.codigoCG;
            txtDescriModelo.Text = frmConsultaGeneral.descripcionCG;
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
