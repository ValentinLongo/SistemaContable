using Datos;
using SistemaContable.General;
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
        string Query;
        public frmDefiniciondeInformes()
        {
            InitializeComponent();
            CargarDGV("");
            cbBusqueda.SelectedIndex = 0;
        }

        public void CargarDGV(string busqueda)
        {
            dgvDefiniciondeInformes.Rows.Clear();
            DataSet ds = new DataSet();
            Query = $"SELECT * FROM Balance {busqueda} ORDER BY bal_codigo";
            ds = AccesoBase.ListarDatos(Query);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr["bal_codigo"].ToString();
                string descri = dr["bal_descri"].ToString();
                dgvDefiniciondeInformes.Rows.Add(codigo, descri);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = "";
            if (cbBusqueda.Text == "Codigo")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "bal_codigo");
            }
            else if (cbBusqueda.Text == "Descripcion")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "bal_descri");
            }
            CargarDGV(busqueda);
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
            frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
            MessageBox1.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                Negocio.Funciones.Contabilidad.FActualizacionDDI.Eliminar(dgvDefiniciondeInformes);
                frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Eliminado Correctamente!", false);
                MessageBox2.ShowDialog();
                CargarDGV("");
            }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte reporte = new frmReporte("ModBalance", Query, "", "Informe de Modelos de Balance", "General", DateTime.Now.ToString("d"));
            reporte.ShowDialog();
        }
    }
}
