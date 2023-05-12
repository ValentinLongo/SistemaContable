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

namespace SistemaContable.Inicio.Contabilidad.Modelos_de_Asientos.Actualizacion
{
    public partial class frmEncabezadodeModelos : Form
    {
        string query;
        public frmEncabezadodeModelos()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV("");
            cbBusqueda.SelectedIndex = 0;
        }

        public void CargarDGV(string busqueda) 
        {
            dgvEncabezadodeModelos.Rows.Clear();
            DataSet ds = new DataSet();
            query = $"SELECT * FROM ModeloEncab {busqueda} ORDER BY mod_codigo";
            ds = AccesoBase.ListarDatos(query);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr["mod_codigo"].ToString();
                string descri = dr["mod_descri"].ToString();
                dgvEncabezadodeModelos.Rows.Add(codigo, descri);
            }

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvEncabezadodeModelos);
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = "";
            if (cbBusqueda.Text == "Codigo")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "mod_codigo");
            }
            else if (cbBusqueda.Text == "Descripcion")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "mod_descri");
            }
            CargarDGV(busqueda);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggModEncabdeMod.agg_o_mod = 0;
            frmAggModEncabdeMod.DGV = dgvEncabezadodeModelos;
            frmAggModEncabdeMod encabdemod = new frmAggModEncabdeMod();
            encabdemod.ShowDialog();
            CargarDGV("");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModEncabdeMod.agg_o_mod = 1;
            frmAggModEncabdeMod.DGV = dgvEncabezadodeModelos;
            frmAggModEncabdeMod encabdemod = new frmAggModEncabdeMod();
            encabdemod.ShowDialog();
            CargarDGV("");
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
            MessageBox1.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                Negocio.Funciones.Contabilidad.FActualizacionMDA.Eliminar(dgvEncabezadodeModelos);
                CargarDGV("");
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDGV("");
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte reporte = new frmReporte("ModeloEncab", query, "", "Informe de Encabezado de Modelos", "General", DateTime.Now.ToString("d"));
            reporte.ShowDialog();
        }
    }
}
