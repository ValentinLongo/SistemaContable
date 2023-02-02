using Datos;
using Negocio.Funciones;
using SistemaContable.Rubros_Contables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Rubos_Contables
{
    public partial class frmRubrosContables : Form
    {
        FRubrosContables rubrosContables = new FRubrosContables();
        public static int codigoRubro;
        public frmRubrosContables()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvRubrosContables.Rows.Clear();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT * FROM RubroCont ORDER BY ruc_codigo");
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                string Codigo = dr[0].ToString();
                string Descripcion = dr[1].ToString();
                int Vigencia = Convert.ToInt32(dr[2].ToString());
                bool check = false;
                if (Vigencia == 1)
                {
                    check = true;
                }
                dgvRubrosContables.Rows.Add(Codigo, Descripcion, check);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRubrosContables.Rows.Clear();
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"select * from RubroCont where ruc_descri LIKE '%{tbDescripcion.Text}%'");
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                string Codigo = dr[0].ToString();
                string Descripcion = dr[1].ToString();
                int Vigencia = Convert.ToInt32(dr[2].ToString());
                bool check = false;
                if (Vigencia == 1)
                {
                    check = true;
                }
                dgvRubrosContables.Rows.Add(Codigo, Descripcion, check);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarRubroContable agregarRubroContable = new frmAgregarRubroContable("Agregar");
            agregarRubroContable.ShowDialog();
            CargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarRubroContable agregarRubroContable = new frmAgregarRubroContable("Modificar");
            agregarRubroContable.ShowDialog();
            CargarDGV();
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                int indice = e.RowIndex;
                codigoRubro = Convert.ToInt32(dgvRubrosContables.Rows[indice].Cells[0].Value.ToString());
            }
            catch
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            rubrosContables.EliminarRubroContable(codigoRubro);
            MessageBox.Show("Registro borrado correctamente");
            CargarDGV();
        }
    }
}
