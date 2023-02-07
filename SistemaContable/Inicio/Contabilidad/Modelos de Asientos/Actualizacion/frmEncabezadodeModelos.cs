using Datos;
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
        public frmEncabezadodeModelos()
        {
            InitializeComponent();

            CargarDGV("");
            cbBusqueda.SelectedIndex = 0;
            
        }
        public void CargarDGV(string txt) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mod_codigo as Codigo, mod_descri as Descripción FROM ModeloEncab {txt} ORDER BY mod_codigo");
            dgvEncabezadodeModelos.DataSource = ds.Tables[0];
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string txtbusqueda = Negocio.Funciones.Contabilidad.FActualizacionMDA.Busqueda(dgvEncabezadodeModelos,txtBusqueda,cbBusqueda,CheckInicio);
            CargarDGV(txtbusqueda);
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
            Negocio.Funciones.Contabilidad.FActualizacionMDA.Eliminar(dgvEncabezadodeModelos);
            CargarDGV("");
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
    }
}
