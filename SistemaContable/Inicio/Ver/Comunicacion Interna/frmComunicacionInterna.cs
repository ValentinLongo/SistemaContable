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
        public static Label nuevomsg;

        public frmComunicacionInterna(Label newmsg)
        {
            InitializeComponent();
            nuevomsg = newmsg;
            txtComentario.Text = "";
            cbSeleccionar.SelectedIndex = 0;
        }

        private void CargarDGV(string where)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT obs_fecha, obs_hora, obs_origen, obs_nomdest, obs_fechaL, obs_horaL, obs_comentario FROM Observaciones {where}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string fecha = dr["obs_fecha"].ToString();
                string hora = dr["obs_hora"].ToString();
                string origen = dr["obs_origen"].ToString();
                string destino = dr["obs_nomdest"].ToString();
                string fechaL = dr["obs_fechaL"].ToString();
                string horaL = dr["obs_horaL"].ToString();
                string comentario = dr["obs_comentario"].ToString();

                dgvMensajes.Rows.Add(fecha, hora, origen, destino, fechaL, horaL, comentario);
            }
        }

        private void cbSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMensajes.Rows.Clear();
            string where;

            if (cbSeleccionar.Text == "Bandeja de Entrada")
            {
                where = "WHERE obs_destino = " + FLogin.IdUsuario;
                CargarDGV(where);
            }
            else if (cbSeleccionar.Text == "Bandeja de Salida")
            {
                where = "WHERE obs_codori = " + FLogin.IdUsuario;
                CargarDGV(where);
            }
        }

        private void dgvMensajes_SelectionChanged(object sender, EventArgs e)
        {
            int seleccionado = dgvMensajes.CurrentCell.RowIndex;

            if (seleccionado != -1)
            {
                txtComentario.Text = dgvMensajes.Rows[seleccionado].Cells[6].Value.ToString();
            }
            else
            {
                txtComentario.Text = "";
            }
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {
            if (cbSeleccionar.Text == "Bandeja de Entrada")
            {
                Negocio.Funciones.Ver.FComunicacionInterna.VerMSGs(dgvMensajes, nuevomsg);
                cbSeleccionar_SelectedIndexChanged(sender, e);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMensajes frm = new frmMensajes();
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int seleccionado = dgvMensajes.CurrentCell.RowIndex;

            DialogResult boton = MessageBox.Show("¿Seguro que desea eliminar el mensaje?", "Atención!", MessageBoxButtons.OKCancel);
            if (boton == DialogResult.OK)
            {
                if (seleccionado != -1)
                {
                    string fecha = dgvMensajes.Rows[seleccionado].Cells[0].Value.ToString();
                    string hora = dgvMensajes.Rows[seleccionado].Cells[1].Value.ToString();
                    string origen = dgvMensajes.Rows[seleccionado].Cells[2].Value.ToString();
                    string destino = dgvMensajes.Rows[seleccionado].Cells[3].Value.ToString();

                    AccesoBase.InsertUpdateDatos($"DELETE Observaciones WHERE obs_fecha = '{fecha}' AND obs_hora = '{hora}' AND obs_origen = '{origen}' AND obs_nomdest = '{destino}'");
                    cbSeleccionar_SelectedIndexChanged(sender, e);
                }
            }
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
