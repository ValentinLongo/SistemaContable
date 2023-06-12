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

        string txtbusqueda;

        public void cargarDGV(string txt)
        {
            txtbusqueda = txt;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_codigo as codigo, eje_descri as Descripción ,eje_desde as Desde, eje_hasta as Hasta, eje_cerrado as Cerrado FROM Ejercicio {txt} ORDER BY eje_codigo");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bool estado = false;
                string codigo = dr[0].ToString();
                string descri = dr[1].ToString();
                string desde = dr[2].ToString().Substring(0, 10);
                string hasta = dr[3].ToString().Substring(0, 10);
                int cerrado = Convert.ToInt32(dr[4]);

                if (cerrado == 1)
                {
                    estado = true;
                }
                dgvEjercicioContable.Rows.Add(codigo, descri, desde, hasta, estado);
            }
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvEjercicioContable);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            string txtbusqueda = "";
            if (cbBusqueda.SelectedIndex == 0)
            {
                txtbusqueda = Negocio.FGenerales.Busqueda(dgvEjercicioContable, txtBusqueda.Text, CheckInicio, 1, "eje_codigo");
            }
            else if (cbBusqueda.SelectedIndex == 1)
            {
                txtbusqueda = Negocio.FGenerales.Busqueda(dgvEjercicioContable, txtBusqueda.Text, CheckInicio, 1, "eje_descri");
            }
            else if (cbBusqueda.SelectedIndex == 2)
            {
                txtbusqueda = Negocio.FGenerales.Busqueda(dgvEjercicioContable, txtBusqueda.Text, CheckInicio, 1, "eje_desde");
            }
            cargarDGV(txtbusqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggEjercicioContable aggejerciciocontable = new frmAggEjercicioContable();
            aggejerciciocontable.ShowDialog();
            dgvEjercicioContable.Rows.Clear();
            cargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                Negocio.Funciones.Mantenimiento.FEjercicioContable.Eliminar(dgvEjercicioContable);
                cargarDGV("");
            }

        }

        private void Imprimir(object sender, EventArgs e)
        {
            if (dgvEjercicioContable.Rows.Count == 0)
            {
                return;
            }

            if (txtbusqueda == null)
            {
                frmReporte reporte = new frmReporte("Ejercicio", "select * from Ejercicio ORDER BY eje_codigo", "", "Informe de Ejercicios Contables", "General", DateTime.Now.ToString("d"));
                reporte.ShowDialog();
            }
            else
            {
                frmReporte reporte = new frmReporte("Ejercicio", $"select * from Ejercicio {txtbusqueda} ORDER BY eje_codigo", "", "Informe de Ejercicios Contables", "General", DateTime.Now.ToString("d"));
                reporte.ShowDialog();
            }
        }

        private void dgvEjercicioContable_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e) //PARA CAMBIAR EL ESTADO DEL EJERCICIO
        {
            string codigo = (string)dgvEjercicioContable.Rows[e.RowIndex].Cells[0].Value;
            bool estado = (bool)dgvEjercicioContable.Rows[e.RowIndex].Cells[4].Value;

            if (estado)
            {
                frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El ejercicio contable se encuentra cerrado. ¿Desea abrirlo?", true, true);
                MessageBox1.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    Negocio.Funciones.Mantenimiento.FEjercicioContable.EstadoCheckBox(dgvEjercicioContable, codigo, estado);
                    cargarDGV("");
                }
            }
            else
            {
                frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El ejercicio contable se encuentra abierto. ¿Desea cerrarlo?", true, true);
                MessageBox1.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    Negocio.Funciones.Mantenimiento.FEjercicioContable.EstadoCheckBox(dgvEjercicioContable, codigo, estado);
                    cargarDGV("");
                }
            }
        }

        private void dgvEjercicioContable_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvEjercicioContable.IsCurrentCellDirty)
            {
                dgvEjercicioContable.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
