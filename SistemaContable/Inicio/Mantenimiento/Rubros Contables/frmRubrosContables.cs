using Datos;
using Negocio.Funciones;
using SistemaContable.General;
using SistemaContable.Rubros_Contables;
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

namespace SistemaContable.Rubos_Contables
{
    public partial class frmRubrosContables : Form
    {
        FRubrosContables rubrosContables = new FRubrosContables();
        public static int codigoRubro;

        public frmRubrosContables()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV("");
        }

        private void CargarDGV(string busqueda)
        {
            dgvRubrosContables.Rows.Clear();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT * FROM RubroCont " + busqueda + " ORDER BY ruc_codigo");
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
            CargarDGV("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarRubroContable agregarRubroContable = new frmAgregarRubroContable("Modificar");
            agregarRubroContable.ShowDialog();
            CargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            rubrosContables.EliminarRubroContable(codigoRubro);
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Registro borrado correctamente", false);
            MessageBox.ShowDialog();
            CargarDGV("");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = Negocio.FGenerales.Busqueda(dgvRubrosContables, txtBusqueda.Text, CheckInicio, 1, "ruc_descri");
            CargarDGV(busqueda);
        }

        private void dgvRubrosContables_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
