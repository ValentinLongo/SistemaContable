using Datos;
using Negocio;
using OpenQA.Selenium.Internal;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace SistemaContable.Inicio.Ver.Comunicacion_Interna
{
    public partial class frmComunicacionInterna : Form
    {
        public static Label nuevomsg; //para avisar en el menu principal cuando un hay nuevos mensajes

        public frmComunicacionInterna(Label newmsg)
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa para este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            nuevomsg = newmsg;
            txtComentario.Text = "";
            cbSeleccionar.SelectedIndex = 0;
        }

        private void CargarDGV(string where)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Observaciones {where} ORDER BY obs_fecha DESC");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string fecha = dr["obs_fecha"].ToString();
                string hora = dr["obs_hora"].ToString();
                string origen = dr["obs_origen"].ToString();
                string destino = dr["obs_nomdest"].ToString();
                string fechaL = dr["obs_fechaL"].ToString();
                string horaL = dr["obs_horaL"].ToString();
                string comentario = dr["obs_comentario"].ToString();

                if (fechaL != "" && fecha != "")
                {
                    fechaL = fechaL.Substring(0, 10);
                    fecha = fecha.Substring(0, 10);
                }
                dgvMensajes.Rows.Add(fecha, hora, origen, destino, fechaL, horaL, comentario);
            }
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvMensajes);

            Cursor.Current = Cursors.Default;
        }

        private void cbSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMensajes.Rows.Clear();
            txtComentario.Text = "";
            string where = "";

            if (cbSeleccionar.Text == "Bandeja de Entrada")
            {
                where = $"WHERE obs_destino = {FLogin.IdUsuario} AND obs_fecha >= '{DateTime.Now.AddDays(-7)}' AND obs_fecha <= '{DateTime.Now}'";
            }
            else if (cbSeleccionar.Text == "Bandeja de Salida")
            {
                where = $"WHERE obs_codori = {FLogin.IdUsuario} AND obs_fecha >= '{DateTime.Now.AddDays(-7)}' AND obs_fecha <= '{DateTime.Now}'";
            }
            CargarDGV(where);

            lblDesde.Text = "Desde: " + DateTime.Now.AddDays(-7).ToString().Substring(0,10);
            lblHasta.Text = "Hasta: " + DateTime.Now.ToString().Substring(0, 10);
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
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMensajes frm = new frmMensajes();
            frm.ShowDialog();
            cbSeleccionar_SelectedIndexChanged(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMensajes.CurrentCell == null)
            {
                return;
            }

            int seleccionado = dgvMensajes.CurrentCell.RowIndex;

            frmMessageBox MessageBox = new frmMessageBox("Atención!", "¿Seguro que desea eliminar el mensaje?", false);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                if (seleccionado != -1)
                {
                    Cursor = Cursors.WaitCursor;

                    string fecha = dgvMensajes.Rows[seleccionado].Cells[0].Value.ToString();
                    string hora = dgvMensajes.Rows[seleccionado].Cells[1].Value.ToString();
                    string origen = dgvMensajes.Rows[seleccionado].Cells[2].Value.ToString();
                    string destino = dgvMensajes.Rows[seleccionado].Cells[3].Value.ToString();

                    AccesoBase.InsertUpdateDatos($"DELETE Observaciones WHERE obs_fecha = '{fecha}' AND obs_hora = '{hora}' AND obs_origen = '{origen}' AND obs_nomdest = '{destino}'");
                    cbSeleccionar_SelectedIndexChanged(sender, e);

                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvMensajes.Rows.Count == 0)
            {
                return;
            }

            string fecha = dgvMensajes.SelectedRows[0].Cells[0].Value.ToString();
            string hora = dgvMensajes.SelectedRows[0].Cells[1].Value.ToString();
            string origen = dgvMensajes.SelectedRows[0].Cells[2].Value.ToString();
            string destino = dgvMensajes.SelectedRows[0].Cells[3].Value.ToString();

            string Query = $"SELECT * FROM Observaciones WHERE obs_fecha = '{fecha}' AND obs_hora = '{hora}' AND obs_origen = '{origen}' AND obs_nomdest = '{destino}'";

            frmReporte reporte = new frmReporte("Msg", Query, "", "Comunicación Interna", origen, destino, fecha);
            reporte.ShowDialog();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) //para filtrar por fecha
        {
            frmRangoFechas frm = new frmRangoFechas(1, Convert.ToDateTime(lblDesde.Text.Substring(7,10)), Convert.ToDateTime(lblHasta.Text.Substring(7, 10)));
            frm.ShowDialog();

            dgvMensajes.Rows.Clear();

            string where = "";
            if (cbSeleccionar.Text == "Bandeja de Entrada")
            {
                where = $"WHERE obs_destino = {FLogin.IdUsuario} AND obs_fecha >= '{frmRangoFechas.Desde}' AND obs_fecha <= '{frmRangoFechas.Hasta}'";
            }
            else if (cbSeleccionar.Text == "Bandeja de Salida")
            {
                where = $"WHERE obs_codori = {FLogin.IdUsuario} AND obs_fecha >= '{frmRangoFechas.Desde}' AND obs_fecha <= '{frmRangoFechas.Hasta}'";
            }
            CargarDGV(where);

            lblDesde.Text = "Desde: " + frmRangoFechas.Desde.ToString().Substring(0, 10);
            lblHasta.Text = "Hasta: " + frmRangoFechas.Hasta.ToString().Substring(0, 10);
        }

        private void frmComunicacionInterna_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}
