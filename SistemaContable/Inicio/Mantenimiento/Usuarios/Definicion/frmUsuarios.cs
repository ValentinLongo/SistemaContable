using Datos.Modelos;
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
        }

        public void llenarDGV(string busqueda)
        {
            dgvUsuarios.Rows.Clear();

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

            DataSet data = new DataSet();
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

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 0)
            {
                return;
            }
            if (dgvUsuarios.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvUsuarios.SelectedCells[0];
                codigoUsuario = Convert.ToInt32(Celda.Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggModUsuario frmAgregarUsuario = new frmAggModUsuario(1);
            frmAgregarUsuario.ShowDialog();
            llenarDGV("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModUsuario formModificarUsuario = new frmAggModUsuario(2);
            formModificarUsuario.ShowDialog();
            llenarDGV("");
        }

        private void btnDefinirCajas_Click(object sender, EventArgs e)
        {
            if (Negocio.FGenerales.PermisoEspecial(10)) // 10 = VINCULAR CAJAS POR USUARIO
            {
                frmAutorización frmAutorizacion = new frmAutorización(this);
                bool autorizado = frmAutorización.Autoriza(4, true);
                frmAutorizacion.Show();
                if (frmAutorización.visibilidad == true)
                {
                    frmAutorizacion.SendToBack();
                }

                if (autorizado)
                {
                    frmDefinirCajas definirCajas = new frmDefinirCajas(codigoUsuario);
                    definirCajas.Show();

                    frmAutorizacion.Close();
                    frmAutorización.usuario = "";
                    frmAutorización.contraseña = "";
                }
            }
            else
            {
                frmDefinirCajas definirCajas = new frmDefinirCajas(codigoUsuario);
                definirCajas.Show();
            }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 0)
            {
                return;
            }

            frmReporte freporte = new frmReporte("Usuarios", $"{query}", "", "Usuarios del Sistema", "Activos", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }

        private void frmUsuarios_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}