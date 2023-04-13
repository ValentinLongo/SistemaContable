using Datos;
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

namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Informe
{
    public partial class frmLibroMayorInforme : Form
    {
        public frmLibroMayorInforme()
        {
            InitializeComponent();
        }

        private void btnBuscarModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultaGeneral = new frmConsultaGeneral("*", "Balance", "", "", "frmModelos");
            consultaGeneral.ShowDialog();
            if (Convert.ToInt32(frmConsultaGeneral.codigoCG) > 0)
            {
                tbIdModelo.Text = frmConsultaGeneral.codigoCG.ToString();
                tbDescriModelo.Text = frmConsultaGeneral.descripcionCG;
            }
        }

        private void btnBuscarEjercicio_Click(object sender, EventArgs e)
        {
            frmBuscarEjercicioContable buscarEjercicioContable = new frmBuscarEjercicioContable();
            buscarEjercicioContable.ShowDialog();
            if (frmBuscarEjercicioContable.idEjercicioSelec > 0)
            {
                tbIdEjercicio.Text = frmBuscarEjercicioContable.idEjercicioSelec.ToString();
                tbDescriEjercicio.Text = frmBuscarEjercicioContable.descriEjercicioSelec;
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
