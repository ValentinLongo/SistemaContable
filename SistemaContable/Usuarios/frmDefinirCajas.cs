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

namespace SistemaContable.Usuarios
{
    public partial class frmDefinirCajas : Form
    {
        public frmDefinirCajas()
        {
            InitializeComponent();
            //Negocio.FGenerales.SetearFormato(this);

            CargarDGV();
        }

        private void CargarDGV()
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"select caj_codigo as Caja, caj_descri as Descripcion, Moneda.mon_descri as Moneda, CajaxUsuario.cxu_predef as Predef from CajaxUsuario INNER JOIN Caja on CajaxUsuario.cxu_caja = Caja.caj_codigo INNER JOIN Usuario on CajaxUsuario.cxu_usuario = Usuario.usu_codigo INNER JOIN Moneda on Caja.caj_moneda = Moneda.mon_codigo WHERE CajaxUsuario.cxu_usuario = {Negocio.FLogin.IdUsuario} Order by caj_codigo");
            foreach(DataRow dr in data.Tables[0].Rows)
            { 
                string caja = dr[0].ToString();
                string descripcion = dr[1].ToString();
                string moneda = dr[2].ToString();
                int predef = Convert.ToInt32(dr[3].ToString());
                bool check = false;
                if(predef == 1)
                {
                    check = true;
                }
                dgvCajas.Rows.Add(caja, descripcion, moneda, check);
            }

            //dgvCajas.DataSource = data.Tables[0];
        }

        private void DobleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccion = dgvCajas.CurrentCell.RowIndex;
            int idCaja;
            if (seleccion > -1)
            {
                idCaja = Convert.ToInt32(dgvCajas.Rows[seleccion].Cells[0].Value);
                Negocio.FUsuarios.ModificarCajaPredefinida(idCaja);
                dgvCajas.Rows.Clear();
                CargarDGV();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCaja agregarCaja = new frmAgregarCaja();
            agregarCaja.ShowDialog();
            dgvCajas.Rows.Clear();
            CargarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int seleccion = dgvCajas.CurrentCell.RowIndex;
            int idCaja;
            if (seleccion > -1)
            {
                idCaja = Convert.ToInt32(dgvCajas.Rows[seleccion].Cells[0].Value);
                Datos.AccesoBase.InsertUpdateDatos($"delete from CajaxUsuario where cxu_usuario = {Negocio.FLogin.IdUsuario} and cxu_caja = {idCaja}");
                MessageBox.Show("Caja eliminada correctamente");
                dgvCajas.Rows.Clear();
                CargarDGV();
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
