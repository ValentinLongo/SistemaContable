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

namespace SistemaContable.Parametrizacion_Permisos
{
    public partial class frmPermisosUsuarios : Form
    {
        public frmPermisosUsuarios()
        {
            InitializeComponent();
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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultageneral = new frmConsultaGeneral();
            consultageneral.ArmarDGV("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "", "ORDER BY usu_codigo");
            consultageneral.ShowDialog();

            int cod = frmConsultaGeneral.codigo;
            string descri = frmConsultaGeneral.descripcion;

            if (cod != null && descri != "")
            {
                txtNroUsuario.Text = cod.ToString();
                txtDescriUsuario.Text = descri;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
