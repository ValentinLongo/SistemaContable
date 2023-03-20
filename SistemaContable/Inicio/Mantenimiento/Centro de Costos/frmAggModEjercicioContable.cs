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

namespace SistemaContable.Inicio.Mantenimiento.Centro_de_Costos
{
    public partial class frmAggModEjercicioContable : Form
    {
        public static int agg_o_mod; // 0 = agregar y 1 = modificar
        public static DataGridView DGV;
        public frmAggModEjercicioContable()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            if (agg_o_mod == 0)
            {
                lblControlBar.Text = "Agregar Ejercicio Contable";
                txtmsg.Text = "ALTA EN CONCEPTO";
            }
            if (agg_o_mod == 1)
            {
                lblControlBar.Text = "Modificar Ejercicio Contable";
                int seleccionado = DGV.CurrentCell.RowIndex;
                txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                txtDescripcion.Text = DGV.Rows[seleccionado].Cells[1].Value.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int validado = Negocio.FValidacionesEventos.ValidacionVacio(this);
            if (validado == 0)
            {
                if (agg_o_mod == 0)
                {
                    txtmsg.Text = "ALTA EN CONCEPTO";
                    Negocio.Funciones.Mantenimiento.FCentrodeCostos.Agregar(this, txtDescripcion.Text);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente!", false);
                    MessageBox.ShowDialog();
                }
                if (agg_o_mod == 1)
                {
                    int seleccionado = DGV.CurrentCell.RowIndex;
                    txtmsg.Text = DGV.Rows[seleccionado].Cells[0].Value.ToString();
                    Negocio.Funciones.Mantenimiento.FCentrodeCostos.Modificar(this, txtmsg.Text, txtDescripcion.Text);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente!", false);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Falta completar campos.", false);
                MessageBox.ShowDialog();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
