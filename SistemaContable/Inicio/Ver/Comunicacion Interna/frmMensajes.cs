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
    public partial class frmMensajes : Form
    {
        //private static List<int> lista = new List<int>();

        public frmMensajes()
        {
            InitializeComponent();

            lblUsuario.Text = FLogin.NombreUsuario;
            CargarDGV(false);
        }

        private void CargarDGV(bool incluye)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT usu_codigo, usu_nombre FROM Usuario");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr[0].ToString();
                string nombre = dr[1].ToString();

                dgvUsuarios.Rows.Add(codigo, nombre, incluye);
            }
        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccionado = dgvUsuarios.CurrentCell.RowIndex;

            if (seleccionado != -1)
            {
                bool checkeado = Convert.ToBoolean(dgvUsuarios.Rows[seleccionado].Cells["ColumnaCheck"].Value);

                if (checkeado)
                {
                    dgvUsuarios.Rows[seleccionado].Cells["ColumnaCheck"].Value = false;
                }
                else
                {
                    dgvUsuarios.Rows[seleccionado].Cells["ColumnaCheck"].Value = true;
                }
            }
        }

        private void AgregarTodo_Click(object sender, EventArgs e)
        {
            dgvUsuarios.Rows.Clear();
            CargarDGV(true);
        }

        private void QuitarTodo_Click(object sender, EventArgs e)
        {
            dgvUsuarios.Rows.Clear();
            CargarDGV(false);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                string destino = row.Cells[0].Value.ToString();
                string nombredestino = row.Cells[1].Value.ToString();

                string hora = DateTime.Now.ToLongTimeString();
                string fecha = DateTime.Now.ToShortDateString();

                bool checkeado = Convert.ToBoolean(row.Cells[2].Value);
                if(checkeado)
                {
                    AccesoBase.InsertUpdateDatos($"INSERT INTO Observaciones(obs_codori, obs_origen, obs_destino, obs_nomdest, obs_comentario, obs_estado, obs_fecha, obs_ctrle, obs_ctrlr, obs_hora) VALUES ('{FLogin.IdUsuario}', '{FLogin.NombreUsuario}', '{destino}', '{nombredestino}', '{txtMensaje}', '0', '{fecha}', '0', '0', '{hora}')");
                }

            }
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
