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
        string codigo = frmConsultaGeneral.codigoCG;
        string descri = frmConsultaGeneral.descripcionCG;
        public frmPermisosEspecialesPerfil()
        {
            InitializeComponent();
            if (codigo != "" && descri != "")
            {
                txtNroPerfil.Text = codigo;
                txtDescriPerfil.Text = descri;
                txtNroPerfil.ReadOnly = true;
                txtDescriPerfil.ReadOnly = true;
                cbModulo.SelectedIndex = 0;
            }
            cargarDGV("", "", "");
        }

        public void cargarDGV(string modulobusqueda, string txtdescri, string estado)
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT pef_codigo as Codigo, pef_modulo as Modulo, pef_descri as Descripcion, pxp_activo as Activo FROM PermisosxPerfil LEFT JOIN Permisos ON pef_codigo = pxp_codigo AND pef_sistema = pxp_sistema  WHERE pef_sistema = 'CO' AND pxp_perfil = {codigo} {modulobusqueda} {txtdescri} ORDER BY pef_codigo");
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
            //dgvPEspeciales.DataSource = data.Tables[0];
        }

        private void dgvPEspeciales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPEspeciales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void cbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btnSacarTodos_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

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
