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

namespace SistemaContable.Inicio.Mantenimiento.Ejercicio_Contable
{
    public partial class frmEjercicioContable : Form
    {
        public frmEjercicioContable()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDGV("");
            cbBusqueda.SelectedIndex = 0;
        }
        public void cargarDGV(string txt)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_codigo as codigo, eje_descri as Descripción ,eje_desde as Desde, eje_hasta as Hasta, eje_cerrado as Cerrado FROM Ejercicio '{txt}' ORDER BY eje_codigo");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bool estado = false;
                string codigo = dr[0].ToString();
                string descri = dr[1].ToString();
                string desde =  dr[2].ToString();
                desde = desde.Substring(0, 10);
                string hasta = dr[3].ToString();
                hasta = hasta.Substring(0, 10);
                int cerrado = Convert.ToInt32(dr[4]);

                if (cerrado == 1)
                {
                    estado = true;
                }
                dgvEjercicioContable.Rows.Add(codigo, descri, desde, hasta, estado);
            }
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
           string txtbusqueda = Negocio.Funciones.Mantenimiento.FEjercicioContable.Busqueda(dgvEjercicioContable,txtBusqueda, cbBusqueda, CheckInicio);
           cargarDGV(txtbusqueda);
        }
        private void dgvEjercicioContable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = (string)dgvEjercicioContable.Rows[e.RowIndex].Cells[0].Value;
            bool estado = (bool)dgvEjercicioContable.Rows[e.RowIndex].Cells[4].Value;
            Negocio.Funciones.Mantenimiento.FEjercicioContable.EstadoCheckBox(dgvEjercicioContable, codigo, estado);
            cargarDGV("");
        }
        private void dgvEjercicioContable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEjercicioContable.IsCurrentCellDirty)
            {
                dgvEjercicioContable.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggEjercicioContable aggejerciciocontable = new frmAggEjercicioContable();
            aggejerciciocontable.ShowDialog();
            dgvEjercicioContable.Rows.Clear();
            cargarDGV("");
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvEjercicioContable.Rows.Clear();
            cargarDGV("");
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.Funciones.Mantenimiento.FEjercicioContable.Eliminar(dgvEjercicioContable);
            cargarDGV("");
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
