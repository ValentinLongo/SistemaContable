using Datos;
using Negocio;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Ver.Calendario
{
    public partial class frmCalendario : Form
    {
        string query;

        public frmCalendario()
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa para este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvCalendario.Rows.Clear();

            bool fin = false;
            int Finalizadas = 0;
            if (CheckFinalizadas.Checked)

            {
                Finalizadas = 1;
            }

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT cal_fecha, cal_hora, cal_observa, cal_fin FROM Calendario WHERE cal_usuario = {FLogin.IdUsuario} AND cal_fin = {Finalizadas}");
            query = "SELECT cal_usuario, cal_fecha, cal_hora, cal_observa, cal_fin, cal_marcaO, cal_visto FROM Calendario WHERE cal_usuario = " + FLogin.IdUsuario + "AND cal_fin = " + Finalizadas;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string fecha = dr["cal_fecha"].ToString();
                fecha = fecha.Substring(0, 10);
                string hora = dr["cal_hora"].ToString();
                string observa = dr["cal_observa"].ToString();
                if (Convert.ToInt32(dr["cal_fin"]) == 0)
                {
                    fin = false;
                }
                else 
                {
                    fin = true;
                }
                dgvCalendario.Rows.Add(fecha,hora,observa,fin);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = dtFecha.Value.ToString();
            fecha = fecha.Substring(0, 10);


            frmAggModCalendario frm = new frmAggModCalendario(1,fecha);
            frm.ShowDialog();
            CargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (CheckFinalizadas.Checked == false)
            {
                int seleccionado = dgvCalendario.CurrentCell.RowIndex;
                if (seleccionado != -1)
                {
                    string fecha = dgvCalendario.Rows[seleccionado].Cells["ColumnaFecha"].Value.ToString();
                    string hora = dgvCalendario.Rows[seleccionado].Cells["ColumnaHora"].Value.ToString();
                    string comentario = dgvCalendario.Rows[seleccionado].Cells["ColumnaComentario"].Value.ToString();

                    frmAggModCalendario frm = new frmAggModCalendario(2, fecha, hora, comentario);
                    frm.ShowDialog();
                    CargarDGV();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Eliminar la Tarea?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                int seleccionado = dgvCalendario.CurrentCell.RowIndex;
                if (seleccionado != -1)
                {
                    string fecha = dgvCalendario.Rows[seleccionado].Cells["ColumnaFecha"].Value.ToString();
                    string hora = dgvCalendario.Rows[seleccionado].Cells["ColumnaHora"].Value.ToString();
                    string comentario = dgvCalendario.Rows[seleccionado].Cells["ColumnaComentario"].Value.ToString();

                    Negocio.Funciones.Ver.FCalendario.Eliminar(fecha, hora, comentario);
                    CargarDGV();
                }
            }
        }

        private void btnPosponer_Click(object sender, EventArgs e)
        {
            string fechanueva = dtFecha.Value.ToString();
            fechanueva = fechanueva.Substring(0, 10);

            frmMessageBox MessageBox = new frmMessageBox("Mensaje", $"¿Posponer la tarea a la fecha {fechanueva}?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto) 
            {
                int seleccionado = dgvCalendario.CurrentCell.RowIndex;
                if (seleccionado != -1) 
                {
                    string fecha = dgvCalendario.Rows[seleccionado].Cells["ColumnaFecha"].Value.ToString();
                    string hora = dgvCalendario.Rows[seleccionado].Cells["ColumnaHora"].Value.ToString();
                    string comentario = dgvCalendario.Rows[seleccionado].Cells["ColumnaComentario"].Value.ToString();

                    Negocio.Funciones.Ver.FCalendario.Posponer(fechanueva,fecha,hora,comentario);

                    frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Pospuesto Correctamente", false);
                    MessageBox2.ShowDialog();
                    CargarDGV();
                }
            }
        }

        private void CheckFinalizadas_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            CargarDGV();
        }

        private void dgvCalendario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccionado = dgvCalendario.CurrentCell.RowIndex;
            if (seleccionado != -1) 
            {
                int id = FLogin.IdUsuario;
                string fecha = dgvCalendario.Rows[seleccionado].Cells["ColumnaFecha"].Value.ToString();
                fecha = fecha + " 00:00:00.000";
                string hora = dgvCalendario.Rows[seleccionado].Cells["ColumnaHora"].Value.ToString();
                string Comentario = dgvCalendario.Rows[seleccionado].Cells["ColumnaComentario"].Value.ToString();

                bool checkeado = Convert.ToBoolean(dgvCalendario.Rows[seleccionado].Cells["ColumnaCheck"].Value);
                if (checkeado == false)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Calendario SET cal_fin = 1, cal_visto = 1 WHERE cal_usuario = {id} AND cal_fecha = '{fecha}' AND cal_hora = '{hora}' AND cal_observa = '{Comentario}'");
                    CargarDGV();
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte freporte = new frmReporte("Calendario", $"{query}", "", "Calendario", DateTime.Now.ToShortDateString(), FLogin.NombreUsuario);
            freporte.ShowDialog();
        }
    }
}
