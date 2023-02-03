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
            cargarDGV("");
        }

        public void cargarDGV(string txtdescri)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_codigo as codigo, eje_descri as Descripción ,eje_desde as Desde, eje_hasta as Hasta, eje_cerrado as Cerrado FROM Ejercicio {txtdescri} ORDER BY eje_codigo");
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                string txtdescri;

                if (CheckInicio.Checked)
                {
                    txtdescri = "WHERE eje_descri LIKE " + "'" + txtDescripcion.Text + "%'";
                }
                else
                {
                    txtdescri = "WHERE eje_descri LIKE " + "'%" + txtDescripcion.Text + "%'";
                }
                dgvEjercicioContable.Rows.Clear();
                cargarDGV(txtdescri);
            }
            else
            {
                dgvEjercicioContable.Rows.Clear();
                cargarDGV("");
            }
        }

        private void dgvEjercicioContable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string codigo = (string)dgvEjercicioContable.Rows[e.RowIndex].Cells[0].Value;
            bool estado = (bool)dgvEjercicioContable.Rows[e.RowIndex].Cells[4].Value;
            if (estado)
            {
                DialogResult boton2 = MessageBox.Show("Atención: El ejercicio contable se encuentra cerrado. ¿Desea abierto?", "Contable", MessageBoxButtons.OKCancel);
                if (boton2 == DialogResult.OK)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Ejercicio SET eje_cerrado = '0' WHERE eje_codigo = '{codigo}'");
                }
            }
            else
            {
                DialogResult boton2 = MessageBox.Show("Atención: El ejercicio contable se encuentra abierto. ¿Desea cerrarlo?", "Contable", MessageBoxButtons.OKCancel);
                if (boton2 == DialogResult.OK)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Ejercicio SET eje_cerrado = '1' WHERE eje_codigo = '{codigo}'");
                }
            }
            dgvEjercicioContable.Rows.Clear();
            cargarDGV("");

        }

        private void dgvEjercicioContable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEjercicioContable.IsCurrentCellDirty)
            {
                dgvEjercicioContable.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            frmAggEjercicioContable aggejerciciocontable = new frmAggEjercicioContable();
            aggejerciciocontable.ShowDialog();
            dgvEjercicioContable.Rows.Clear();
            cargarDGV("");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult boton2 = MessageBox.Show("¿Seguro que Desea Continuar?", "Mensaje", MessageBoxButtons.OKCancel);
            if (boton2 == DialogResult.OK) 
            {
                int seleccion = dgvEjercicioContable.CurrentCell.RowIndex;
                string codigo;
                if (seleccion > -1)
                {
                    codigo = dgvEjercicioContable.Rows[seleccion].Cells[0].Value.ToString();
                    Datos.AccesoBase.InsertUpdateDatos($"DELETE FROM Ejercicio WHERE eje_codigo = '{codigo}'");
                    MessageBox.Show("Eliminado correctamente!", "Mensaje");
                    dgvEjercicioContable.Rows.Clear();
                    cargarDGV("");
                }
            }
        }
    }
}
