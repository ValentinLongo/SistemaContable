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
        private static string formulario;
        private static string ast; //asterisco
        private static string tab; //tabla
        private static string whe; //where
        private static string ord; //orden
        public frmConsultaGeneral()
        {
            InitializeComponent();
            cbBusqueda.SelectedIndex = 0;
        }

        public void ArmarDGV(string asterisco, string tabla, string where, string orden, string frm) //frm = desde que formulario fue llamado
        {
            DataSet data = new DataSet();

            if (cbBusqueda.SelectedIndex == 0)
            {
                data = Datos.AccesoBase.ListarDatos($"SELECT {asterisco} FROM {tabla} {where} {orden}");
                dgvConsulta.DataSource = data.Tables[0];
            }
            else if (cbBusqueda.SelectedIndex == 1)
            {
                data = Datos.AccesoBase.ListarDatos($"SELECT {asterisco} FROM {tabla} {where} {orden}");
                dgvConsulta.DataSource = data.Tables[0];
            }

            formulario = frm;
            ast = asterisco;
            tab = tabla;
            whe = where;
            ord = orden;
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
                    whe = "WHERE usu_codigo LIKE" + "'%" + txtBusqueda.Text + "%'";
                    ArmarDGV(ast, tab, whe, "", "");
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (CheckInicio.Checked)
                    {
                        whe = "WHERE usu_nombre LIKE" + "'" + txtBusqueda.Text + "%'";
                        ArmarDGV(ast, tab, whe, "", "");
                    }
                    else
                    {
                        whe = "WHERE usu_nombre LIKE" + "'%" + txtBusqueda.Text + "%'";
                        ArmarDGV(ast, tab, whe, "", "");
                    }
                }
            }
            else
            {
                ArmarDGV(ast, tab, "", ord, "");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            codigoCG = dgvConsulta.Rows[dgvConsulta.CurrentRow.Index].Cells[0].Value.ToString();
            descripcionCG = dgvConsulta.Rows[dgvConsulta.CurrentRow.Index].Cells[1].Value.ToString();
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ArmarDGV(ast, tab, "", ord, "");
            txtBusqueda.Clear();
        }

        private void btnCerrar_CloseClicked(object sender, EventArgs e)
        {
            codigoCG = null;
            descripcionCG = null;
            Close();
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
