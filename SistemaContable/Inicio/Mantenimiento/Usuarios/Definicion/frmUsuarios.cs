using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public static int codigoUsuario;
        string query;
        public frmUsuarios()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cbBusqueda.SelectedIndex = 0;
            llenarDGV("");
            btnModificar.Enabled = false;
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            frmInicio frmInicio = new frmInicio();
            frmInicio.Show();
        }

        public void llenarDGV(string busqueda)
        {
            dgvUsuarios.Rows.Clear();

            DataSet data = new DataSet();
            //query = "SELECT usu_codigo as Codigo, usu_nombre as Nombre, usu_login as Login, Perfil.per_descri as Perfil, usu_telefono as Telefono FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo ORDER BY usu_codigo";
            if (CheckUsuario.Checked)
            {
                if (busqueda == "")
                {
                    query = "SELECT * FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo " + busqueda + "WHERE usu_estado = 1";
                }
                else
                {
                    query = "SELECT * FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo " + busqueda + "AND usu_estado = 1";
                }
            }
            else
            {
                query = "SELECT * FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo " + busqueda;
            }

            data = Datos.AccesoBase.ListarDatos($"{query + " ORDER BY usu_codigo"}");

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                string codigo = dr["usu_codigo"].ToString();
                string nombre = dr["usu_nombre"].ToString();
                string login = dr["usu_login"].ToString();
                string perfil = dr["per_descri"].ToString();
                string telefono = dr["usu_telefono"].ToString();
                dgvUsuarios.Rows.Add(codigo, nombre, login, perfil, telefono);
            }

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvUsuarios);
        }

        private void Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnModificar.Enabled = true;
                int indice = e.RowIndex;
                codigoUsuario = Convert.ToInt32(dgvUsuarios.Rows[indice].Cells[0].Value.ToString());
            }
            catch
            {
                btnModificar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frmAgregarUsuario = new frmAgregarUsuario();
            frmAgregarUsuario.ShowDialog();
            llenarDGV("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarUsuario formModificarUsuario = new frmModificarUsuario();
            formModificarUsuario.ShowDialog();
            llenarDGV("");
        }

        private void btnDefinirCajas_Click(object sender, EventArgs e)
        {
            frmDefinirCajas definirCajas = new frmDefinirCajas();
            definirCajas.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte freporte = new frmReporte("Usuarios", $"{query}", "","Usuarios del Sistema", "Activos", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }

        private void CheckUsuario_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            dgvUsuarios.Rows.Clear();
            llenarDGV("");
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = "";
            if (cbBusqueda.Text == "Codigo")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvUsuarios, txtbusqueda.Text, CheckInicio, 1, "usu_codigo");
            }
            else if (cbBusqueda.Text == "Nombre")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvUsuarios, txtbusqueda.Text, CheckInicio, 1, "usu_nombre");
            }
            llenarDGV(busqueda);
        }
    }
}