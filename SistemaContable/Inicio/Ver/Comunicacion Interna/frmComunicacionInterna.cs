using Datos;
using Negocio;
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

namespace SistemaContable.Inicio.Ver.Comunicacion_Interna
{
    public partial class frmComunicacionInterna : Form
    {

        public frmComunicacionInterna()
        {
            InitializeComponent();
            cbSeleccionar.SelectedIndex = 0;
        }

        private void CargarDGV(string where) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT obs_fecha, obs_hora, obs_origen, obs_nomdest, obs_fechaL, obs_horaL, obs_comentario FROM Observaciones {where}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string fecha = dr[0].ToString();
                string hora = dr[1].ToString();
                string origen = dr[2].ToString();
                string destino = dr[3].ToString();
                string fechaL = dr[4].ToString();
                string horaL = dr[5].ToString();
                string comentario = dr[6].ToString();

                dgvMensajes.Rows.Add(fecha,hora,origen,destino,fechaL,horaL,comentario);
            }
        }

        private void cbSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string where;

            if (cbSeleccionar.Text == "Bandeja de Entrada")
            {
                where = "WHERE obs_estado = 0 AND obs_destino = " + FLogin.IdUsuario;
                CargarDGV(where);
            }
            else if (cbSeleccionar.SelectedText == "Bandeja de Salida")
            {
                where = "WHERE obs_estado = 1 AND obs_codori = " + FLogin.IdUsuario;
                CargarDGV(where);
            }          
        }

        private void dgvMensajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccionado = dgvMensajes.CurrentCell.RowIndex;

            if (seleccionado != -1)
            {
                txtComentario.Text = dgvMensajes.Rows[seleccionado].Cells[6].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMensajes frm = new frmMensajes();
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
