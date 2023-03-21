using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.General
{
    public partial class frmBuscarEjercicioContable : Form
    {
        public static int idEjercicioSelec;
        public static string descriEjercicioSelec;

        private int idEjercicio;
        private string descriEjercicio;
        public frmBuscarEjercicioContable()
        {
            InitializeComponent();
            CargarDatos("");
        }

        private void CargarDatos(string txt)
        {
            DataSet ds = new DataSet();

            ds = AccesoBase.ListarDatos($"SELECT eje_codigo as codigo, eje_descri as Descripción ,eje_desde as Desde, eje_hasta as Hasta, eje_cerrado as Cerrado FROM Ejercicio {txt} ORDER BY eje_codigo");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bool estado = false;
                string codigo = dr[0].ToString();
                string descri = dr[1].ToString();
                string desde = dr[2].ToString();
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (idEjercicio != 0)
            {
                idEjercicioSelec = idEjercicio;
                descriEjercicioSelec = descriEjercicio;
                this.Close();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
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
            CargarDatos(txtbusqueda);
        }

        private void dgvEjercicioContable_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            idEjercicio = Convert.ToInt32(dgvEjercicioContable.Rows[e.RowIndex].Cells[0].Value.ToString());
            descriEjercicio = dgvEjercicioContable.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
