using Datos;
using SistemaContable.Inicio.Contabilidad.Modelos_de_Asientos.Actualizacion;
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
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Actualizacion
{
    public partial class frmDefiniciondeInformes : Form
    {
        public frmDefiniciondeInformes()
        {
            InitializeComponent();

            CargarDGV("");
            cbBusqueda.SelectedIndex = 0;
        }
        public void CargarDGV(string txt) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT bal_codigo as Codigo, bal_descri as Descripción FROM Balance {txt} ORDER BY bal_codigo");
            dgvDefiniciondeInformes.DataSource = ds.Tables[0];
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string txtbusqueda = Negocio.Funciones.Contabilidad.FActualizacionDDI.Busqueda(dgvDefiniciondeInformes, txtBusqueda, cbBusqueda, CheckInicio);
            CargarDGV(txtbusqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggModDefdeInf.DGV = dgvDefiniciondeInformes;
            frmAggModDefdeInf defdeinf = new frmAggModDefdeInf(0);
            defdeinf.ShowDialog();
            CargarDGV("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModDefdeInf.DGV = dgvDefiniciondeInformes;
            frmAggModDefdeInf defdeinf = new frmAggModDefdeInf(1);
            defdeinf.ShowDialog();
            CargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.Funciones.Contabilidad.FActualizacionDDI.Eliminar(dgvDefiniciondeInformes);
            CargarDGV("");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDGV("");
        }

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
