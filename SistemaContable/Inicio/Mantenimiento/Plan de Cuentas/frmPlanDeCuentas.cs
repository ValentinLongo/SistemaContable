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

            CargarDGV("");
        }

        private void CargarDGV(string descri)
        {
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
            frmAggModCuenta frmAgregar = new frmAggModCuenta(1);
            frmAgregar.ShowDialog();
            CargarDGV("");
        }

        private void dgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCuentas.Rows.Count == 0)
            {
                return;
            }
            if (dgvCuentas.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvCuentas.SelectedCells[1];
                idCuenta = Celda.Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModCuenta frmModificar = new frmAggModCuenta(2);
            frmModificar.ShowDialog();
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

            frmReporte freporte = new frmReporte("PCuenta", $"select * from PCuenta {FPlanDeCuentas.wherePCuenta}", "", "Plan de Cuentas", "General", DateTime.Now.ToString("d"));
            freporte.Show();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            CargarDGV(txtBusqueda.Text);
        }

        private void frmPlanDeCuentas_Resize(object sender, EventArgs e)
        {
            if (Negocio.FInicio.FormActivo("frmAggModVisAsientoContable")) //porque al abrir el frmPlanDeCuenta desde frmAggModVisAsientoContable, el metodo " MinimizarMDIchild " provocaba: Error al crear identificador de ventana.
            {
                return;
            }
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}
