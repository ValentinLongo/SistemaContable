using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Centro_de_Costos;
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

namespace SistemaContable.Inicio.Mantenimiento
{
    public partial class frmCentrodeCostos : Form
    {
        private string query;
        public frmCentrodeCostos()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV("");
            cbBusqueda.SelectedIndex = 0;
        }

        public void CargarDGV(string txt) 
        {
            DataSet ds = new DataSet();
            query = $"SELECT * FROM CentroC {txt} ORDER BY cec_codigo";
            ds = AccesoBase.ListarDatos(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bool estado = false;
                string codigo = dr[0].ToString();
                string descri = dr[1].ToString();
                int predef = Convert.ToInt32(dr[2]);
                if (predef == 1)
                {
                    estado = true;
                }
                dgvCentrodeCosto.Rows.Add(codigo, descri, estado);
            }

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvCentrodeCosto);
        }

        private void dgvCentrodeCosto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = (string)dgvCentrodeCosto.Rows[e.RowIndex].Cells[0].Value;
            string descri = (string)dgvCentrodeCosto.Rows[e.RowIndex].Cells[1].Value;
            bool estado = (bool)dgvCentrodeCosto.Rows[e.RowIndex].Cells[2].Value;

            if (estado)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE CentroC SET cec_predef = '0' WHERE cec_codigo = '{codigo}' AND cec_descri = '{descri}'");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"UPDATE CentroC SET cec_predef = '1' WHERE cec_codigo = '{codigo}' AND cec_descri = '{descri}'");
            }
            dgvCentrodeCosto.Rows.Clear();
            CargarDGV("");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string txtdescri = "";

            if (cbBusqueda.SelectedIndex == 0)
            {
                txtdescri = Negocio.FGenerales.Busqueda(dgvCentrodeCosto, txtBusqueda.Text, CheckInicio, 1, "cec_codigo");
            }
            else if (cbBusqueda.SelectedIndex == 1)
            {
                txtdescri = Negocio.FGenerales.Busqueda(dgvCentrodeCosto, txtBusqueda.Text, CheckInicio, 1, "cec_descri");
            }
            CargarDGV(txtdescri);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggModEjercicioContable.agg_o_mod = 0;
            frmAggModEjercicioContable aggmodejerciciocontable = new frmAggModEjercicioContable();
            aggmodejerciciocontable.ShowDialog();
            dgvCentrodeCosto.Rows.Clear();
            CargarDGV("");

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModEjercicioContable.agg_o_mod = 1;
            frmAggModEjercicioContable.DGV = dgvCentrodeCosto;
            frmAggModEjercicioContable aggmodejerciciocontable = new frmAggModEjercicioContable();
            aggmodejerciciocontable.ShowDialog();
            dgvCentrodeCosto.Rows.Clear();
            CargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                Negocio.Funciones.Mantenimiento.FCentrodeCostos.Eliminar(dgvCentrodeCosto);
                CargarDGV("");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvCentrodeCosto.Rows.Clear();
            CargarDGV("");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvCentrodeCosto.Rows.Count == 0)
            {
                return;
            }

            frmReporte reporte = new frmReporte("CentroC", query, "", "Centro de Costos", "Todos", DateTime.Now.ToString(""));
            reporte.ShowDialog();
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
