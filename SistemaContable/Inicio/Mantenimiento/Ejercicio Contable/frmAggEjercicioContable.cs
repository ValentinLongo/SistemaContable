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

namespace SistemaContable.Inicio.Mantenimiento.Ejercicio_Contable
{
    public partial class frmAggEjercicioContable : Form
    {
        public frmAggEjercicioContable()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            maskDesde.Mask = "00/00/0000";
            maskHasta.Mask = "00/00/0000";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string fechadesde = maskDesde.Text.ToString().Substring(0, 10);
            string fechahasta = maskHasta.Text.ToString().Substring(0, 10);

            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Falta completar campos.", false);
                MessageBox.ShowDialog();
            }

            AccesoBase.InsertUpdateDatos($"INSERT INTO Ejercicio (eje_codigo, eje_descri, eje_desde, eje_hasta, eje_renumera, eje_asiento, eje_cerrado) VALUES ('{txtCodigo.Text}', '{txtDescri.Text}', '{fechadesde}', '{fechahasta}', '{txtRenumeracion.Text}', {txtAsiento.Text}, '0')");
            frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Agregado Correctamente", false);
            MessageBox2.ShowDialog();
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

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            maskDesde.Text = dtpDesde.Value.ToString();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            maskHasta.Text = dtpHasta.Value.ToString();
        }
    }
}
