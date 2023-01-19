using SistemaContable.Parametrizacion_Permisos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmConsultaGeneral : Form
    {
        public static string codigoCG;
        public static string descripcionCG;
        public frmConsultaGeneral()
        {
            InitializeComponent();
            cbBusqueda.SelectedIndex = 0;
        }

        public void ArmarDGV(string asterisco, string tabla, string where, string orden)
        {
            DataSet data = new DataSet();

            if (cbBusqueda.SelectedIndex == 0)
            {
                data = Datos.AccesoBase.ListarDatos($"SELECT {asterisco} FROM {tabla} {where} {orden}");
                dgvUsuarios.DataSource = data.Tables[0];
            }
            else if (cbBusqueda.SelectedIndex == 1)
            {
                data = Datos.AccesoBase.ListarDatos($"SELECT {asterisco} FROM {tabla} {where} {orden}");
                dgvUsuarios.DataSource = data.Tables[0];
            }
        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBusqueda.SelectedIndex == 0)
            {
                txtBusqueda.Tag = "00100";
                CheckInicio.Visible = false;
                lblInicio.Visible = false;
            }
            else if (cbBusqueda.SelectedIndex == 1)
            {
                txtBusqueda.Tag = "01010";
                CheckInicio.Visible = true;
                lblInicio.Visible = true;
            }
            Negocio.FValidacionesEventos.EventosFormulario(this);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                if (cbBusqueda.SelectedIndex == 0)
                {
                    ArmarDGV("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "WHERE usu_codigo LIKE " + "'%" + txtBusqueda.Text + "%'", "");
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (CheckInicio.Checked)
                    {
                        ArmarDGV($"usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "WHERE usu_nombre LIKE" + "'" + txtBusqueda.Text + "%'", "");
                    }
                    else
                    {
                        ArmarDGV($"usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "WHERE usu_nombre LIKE" + "'%" + txtBusqueda.Text + "%'", "");
                    }
                }
            }
            else
            {
                ArmarDGV("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "", "ORDER BY usu_codigo");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            codigoCG = dgvUsuarios.Rows[dgvUsuarios.CurrentRow.Index].Cells[0].Value.ToString();
            descripcionCG = dgvUsuarios.Rows[dgvUsuarios.CurrentRow.Index].Cells[1].Value.ToString();
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ArmarDGV("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "", "ORDER BY usu_codigo");
            txtBusqueda.Clear();
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

        private void btnCerrar_CloseClicked(object sender, EventArgs e)
        {
            codigoCG = null;
            descripcionCG = null;
            Close();
        }
    }
}
