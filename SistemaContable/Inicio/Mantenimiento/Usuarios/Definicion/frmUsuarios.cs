using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public static int codigoUsuario;
        public frmUsuarios()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            llenarDGV();
            btnModificar.Enabled = false;
        }
        
        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            frmInicio frmInicio = new frmInicio();
            frmInicio.Show();
        }

        public void llenarDGV()
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos("SELECT usu_codigo as Codigo, usu_nombre as Nombre, usu_login as Login, Perfil.per_descri as Perfil, usu_telefono as Telefono FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo ORDER BY usu_codigo");
            dgvUsuarios.DataSource = data.Tables[0];
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            string query = "SELECT usu_codigo as Codigo, usu_nombre as Nombre, usu_login as Login, Perfil.per_descri as Perfil, usu_telefono as Telefono FROM Usuario INNER JOIN Perfil on usu_perfil = per_codigo ";
            if (tbNombreBusqueda.Text != null && tbNombreBusqueda.Text != "")
            {
                if (query.Contains("WHERE"))
                {
                    query += $"and usu_nombre = '{tbNombreBusqueda.Text}'";
                }
                else
                {
                    query += $"WHERE usu_nombre = '{tbNombreBusqueda.Text}'";
                }
            }
            if (tbCodigo.Text != null && tbCodigo.Text != "")
            {
                if (query.Contains("WHERE"))
                {
                    query += $"and usu_codigo = {tbCodigo.Text}";
                }
                else
                {
                    query += $"WHERE usu_codigo = '{tbCodigo.Text}'";
                }
            }
            if (dtNacimiento.Value < Convert.ToDateTime("01/01/2015"))
            {
                if (query.Contains("WHERE"))
                {
                    query += $"and usu_fecnac = '{dtNacimiento.Text}'";
                }
                else
                {
                    query += $"WHERE usu_fecnac = '{dtNacimiento.Text}'";
                }
            }

            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos(query);

            dgvUsuarios.DataSource = data.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frmAgregarUsuario = new frmAgregarUsuario();
            frmAgregarUsuario.ShowDialog();
            llenarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarUsuario formModificarUsuario = new frmModificarUsuario();
            formModificarUsuario.ShowDialog();
            llenarDGV();
        }

        private void btnDefinirCajas_Click(object sender, EventArgs e)
        {
            frmDefinirCajas definirCajas = new frmDefinirCajas();
            definirCajas.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte freporte = new frmReporte("Usuarios", "SELECT * FROM Usuario Left Join Perfil on usu_perfil = per_codigo WHERE usu_codigo = 1","Titulo","Param1","Param2");
            freporte.ShowDialog();
        }
    }
}