using Datos.Modelos;
using Negocio.Funciones.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste
{
    public partial class frmCoeficienteDeAjuste : Form
    {
        FCoeficienteDeAjuste data = new FCoeficienteDeAjuste();
        int check;

        public static int codigoEjercicio;

        //datos de los coeficientes
        public static int codigoCoeficiente;
        public static string periodoModificar;
        public static double coeficienteModificar;
        public frmCoeficienteDeAjuste()
        {
            InitializeComponent();
            check = 0;
            CargarDGV();
        }

        private void CargarDGV()
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvEjercicios.Rows.Clear();
            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            mCoeficienteDeAjuste = data.listaEjercicios(check);
            foreach(var datos in mCoeficienteDeAjuste)
            {
                bool cerrado = false;
                if(datos.eje_cerrado == 1)
                {
                    cerrado = true;
                }
                dgvEjercicios.Rows.Add(datos.eje_codigo,datos.eje_descri,datos.eje_desde,datos.eje_hasta,cerrado);
            }
        }

        private void cambioEjercicioAbierto(object sender, EventArgs e)
        {
            if (checkEjercicio.Checked)
            {
                check = 0;
            }
            else
            {
                check = 1;
            }
            CargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            if(indice >= 0)
            {
                codigoEjercicio = Convert.ToInt32(dgvEjercicios.Rows[indice].Cells[0].Value.ToString());
                DataSet ds = data.listaCoeficientes(codigoEjercicio);
                dgvCoeficientes.DataSource = ds.Tables[0];
            }
        }

        private void ClickCoeficientes(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            int codigoEjercicio;
            int indice = e.RowIndex;
            if( indice >= 0)
            {
                codigoEjercicio = Convert.ToInt32(dgvCoeficientes.Rows[indice].Cells[0].Value.ToString());
                codigoCoeficiente = codigoEjercicio;
                periodoModificar = dgvCoeficientes.Rows[indice].Cells[1].Value.ToString();
                coeficienteModificar = Convert.ToDouble(dgvCoeficientes.Rows[indice].Cells[2].Value.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCoeficientes.Rows.Clear();
            dgvEjercicios.Rows.Clear();
            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            mCoeficienteDeAjuste = data.ejercicioParticular(check,tbDescripcion.Text);
            foreach (var datos in mCoeficienteDeAjuste)
            {
                bool cerrado = false;
                if (datos.eje_cerrado == 1)
                {
                    cerrado = true;
                }
                dgvEjercicios.Rows.Add(datos.eje_codigo, datos.eje_descri, datos.eje_desde, datos.eje_hasta, cerrado);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCoeficienteAjuste agregarCoeficienteAjuste = new frmAgregarCoeficienteAjuste("Agregar");
            agregarCoeficienteAjuste.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            frmAgregarCoeficienteAjuste agregarCoeficienteAjuste = new frmAgregarCoeficienteAjuste("Modificar");
            agregarCoeficienteAjuste.ShowDialog();
        }

    }
}
