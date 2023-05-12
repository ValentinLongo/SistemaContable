using Datos;
using SistemaContable.General;
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

namespace SistemaContable.Parametrizacion_Permisos
{
    public partial class frmPermisosEspecialesPerfil : Form
    {
        string codigo = frmPermisosPerfil.NroPerfil;
        string descri = frmPermisosPerfil.DescriPerfil;

        public frmPermisosEspecialesPerfil()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            if (codigo != "" && descri != "")
            {
                txtNroPerfil.Text = codigo;
                txtDescriPerfil.Text = descri;
                txtNroPerfil.ReadOnly = true;
                txtDescriPerfil.ReadOnly = true;
                cbModulo.SelectedIndex = 0;
            }
        }

        public void cargarDGV(string modulobusqueda, string busqueda, string estado)
        {
            dgvPEspeciales.Rows.Clear();
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT pef_codigo as Codigo, pef_modulo as Modulo, pef_descri as Descripcion, pxp_activo as Activo FROM PermisosxPerfil LEFT JOIN Permisos ON pef_codigo = pxp_codigo AND pef_sistema = pxp_sistema  WHERE pef_sistema = 'CO' AND pxp_perfil = {codigo} {modulobusqueda} {busqueda} ORDER BY pef_codigo");
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                bool check = false;
                var codigo2 = dr[0].ToString();
                var modulo = dr[1].ToString();
                var descri = dr[2].ToString();
                if (estado != "")
                {
                    if (estado == "1")
                    {
                        check = true;
                    }
                }
                else
                {
                    int activo = Convert.ToInt32(dr[3].ToString());
                    if (activo == 1)
                    {
                        check = true;
                    }
                }
                dgvPEspeciales.Rows.Add(codigo2, modulo, descri, check);
            }

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvPEspeciales);
        }

        private void dgvPEspeciales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string codigo2 = (string)dgvPEspeciales.Rows[e.RowIndex].Cells[0].Value; //codigo2 = pxu_usuario de la tabla permisosxusu
            bool estado = (bool)dgvPEspeciales.Rows[e.RowIndex].Cells[3].Value;
            if (estado)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxPerfil SET pxp_activo = '0' WHERE pxp_perfil = '{codigo}' AND pxp_codigo = '{codigo2}'  AND pxp_sistema = 'CO'");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxPerfil SET pxp_activo = '1' WHERE pxp_perfil = '{codigo}' AND pxp_codigo = '{codigo2}' AND pxp_sistema = 'CO'");
            }
            dgvPEspeciales.Rows.Clear();
            cargarDGV("", "", "");
        }

        private void dgvPEspeciales_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvPEspeciales.IsCurrentCellDirty)
            {
                dgvPEspeciales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string modulobusqueda = cbModulo.Text;
            if (modulobusqueda == "TODOS")
            {
                modulobusqueda = "";
            }
            else
            {
                modulobusqueda = "AND pef_modulo = " + "'" + modulobusqueda + "'";
            }

            dgvPEspeciales.Rows.Clear();
            cargarDGV(modulobusqueda,"", "");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            string busqueda = Negocio.FGenerales.Busqueda(dgvPEspeciales, txtDescripcion.Text, CheckInicio, 2, "pef_descri");
            cargarDGV("",busqueda,"");

        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            dgvPEspeciales.Rows.Clear();
            cargarDGV("", "", "1");
        }
        private void btnSacarTodo_Click(object sender, EventArgs e)
        {
            dgvPEspeciales.Rows.Clear();
            cargarDGV("", "", "0");
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
