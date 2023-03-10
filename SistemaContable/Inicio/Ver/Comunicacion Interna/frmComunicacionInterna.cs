using Datos;
using Negocio;
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

namespace SistemaContable.Inicio.Ver.Comunicacion_Interna
{
    public partial class frmComunicacionInterna : Form
    {
        public static Label nuevomsg;
        string Query;
        public frmComunicacionInterna(Label newmsg)
        {
            InitializeComponent();
            nuevomsg = newmsg;
            txtComentario.Text = "";
            cbSeleccionar.SelectedIndex = 0;
        }
        string fecha;
        string origen;
        string destino;
        private void CargarDGV(string where)
        {
            DataSet ds = new DataSet();
            Query = $"SELECT * FROM Observaciones {where}";
            ds = AccesoBase.ListarDatos(Query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fecha = dr["obs_fecha"].ToString();
                string hora = dr["obs_hora"].ToString();
                origen = dr["obs_origen"].ToString();
                destino = dr["obs_nomdest"].ToString();
                string fechaL = dr["obs_fechaL"].ToString();
                string horaL = dr["obs_horaL"].ToString();
                string comentario = dr["obs_comentario"].ToString();

                fechaL = fechaL.Substring(0, 10);
                fecha = fecha.Substring(0, 10);
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
            frmReporte reporte = new frmReporte("Msg", Query, "", "Comunicación Interna", origen, destino,fecha);
            reporte.ShowDialog();
        }
    }
}
