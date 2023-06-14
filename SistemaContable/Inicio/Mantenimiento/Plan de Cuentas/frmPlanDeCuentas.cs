using Datos;
using Negocio;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Plan_de_Cuentas
{
    public partial class frmPlanDeCuentas : Form
    {
        public static string idCuenta;

        public frmPlanDeCuentas()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarDGV("");
        }

        private void CargarDGV(string descri)
        {
            dgvCuentas.Rows.Clear();

            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.BusquedaCuenta(descri);
            dgvCuentas.DataSource = ds.Tables[0];
            DataGridViewColumn columna = dgvCuentas.Columns["AjustaInf"];

            //Asigno a la columnaCheckBox los valores de la columna que se carga con el datasouce
            DataGridViewCheckBoxColumn columnaCheckBox = new DataGridViewCheckBoxColumn();
            columnaCheckBox.HeaderText = columna.HeaderText;
            columnaCheckBox.Name = columna.Name;
            columnaCheckBox.DataPropertyName = columna.DataPropertyName;

            // Reemplaza la columna existente con la columnaCheckBox
            int indiceColumna = columna.Index;
            dgvCuentas.Columns.RemoveAt(indiceColumna);
            dgvCuentas.Columns.Insert(indiceColumna, columnaCheckBox);

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvCuentas);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCuenta frmAgregarCuenta = new frmAgregarCuenta();
            frmAgregarCuenta.ShowDialog();
            CargarDGV("");
        }

        private void dgvCuentas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                int indice = e.RowIndex;
                idCuenta = dgvCuentas.Rows[indice].Cells[1].Value.ToString();
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarCuenta formModificarCuenta = new frmModificarCuenta();
            formModificarCuenta.ShowDialog();
            CargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Eliminar la Cuenta?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto) 
            {
                FPlanDeCuentas.eliminarCuenta(idCuenta);
                CargarDGV("");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.Rows.Count == 0)
            {
                return;
            }

            frmReporte freporte = new frmReporte("PCuenta", $"{FPlanDeCuentas.query}", "", "Plan de Cuentas", "General", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            CargarDGV(txtBusqueda.Text);
        }

        private void frmPlanDeCuentas_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }

        //BARRA DE CONTROL
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
