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

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Actualizacion
{
    public partial class frmAggModDefdeInf : Form
    {
        public static int agg_o_mod; // 0 = agregar y 1 = modificar
        public static DataGridView DGV;
        public frmAggModDefdeInf()
        {
            InitializeComponent();
            if (agg_o_mod == 0)
            {
                lblControlBar.Text = "Agregar Definición de Informe";
            }
            if (agg_o_mod == 1)
            {
                lblControlBar.Text = "Modificar Definición de Informe";
                int seleccionado = DGV.CurrentCell.RowIndex;
                txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                txtDescripcion.Text = DGV.Rows[seleccionado].Cells[1].Value.ToString();
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (agg_o_mod == 0)
            {
                Negocio.Funciones.Contabilidad.FActualizacionDDI.Agregar(this, txtDescripcion.Text);
            }
            else if (agg_o_mod == 1)
            {
                int seleccionado = DGV.CurrentCell.RowIndex;
                txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                Negocio.Funciones.Contabilidad.FActualizacionDDI.Modificar(this, txtmsg.Text, txtDescripcion.Text);
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
