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

namespace SistemaContable.Empresa
{
    public partial class frmEmpresa : Form
    {
        public static int codigoSucursal;
        public static string descripcionSucursal;

        public frmEmpresa()
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvSucursales.Rows.Clear();

            DataSet ds = new DataSet();
            ds = Negocio.FEmpresa.listaEmpresa();
            dgvEmpresa.DataSource = ds.Tables[0];

            ds = Negocio.FEmpresa.listaSucursales();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                string codigo = dr["suc_codigo"].ToString();
                string descripcion = dr["suc_descri"].ToString();
                dgvSucursales.Rows.Add(codigo, descripcion);
            }

            Negocio.FGenerales.CantElementos(lblCantElementos,dgvEmpresa);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarSucursal frmAgregarSucursal = new frmAgregarSucursal("Agregar");
            frmAgregarSucursal.ShowDialog();
            CargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarSucursal frmAgregarSucursal = new frmAgregarSucursal("Modificar");
            frmAgregarSucursal.ShowDialog();
            CargarDGV();
        }

        private void dgvSucursales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSucursales.Rows.Count == 0)
            {
                return;
            }
            if (dgvSucursales.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvSucursales.SelectedCells[0];
                codigoSucursal = Convert.ToInt32(Celda.Value);

                DataGridViewCell Celda2 = dgvSucursales.SelectedCells[1];
                descripcionSucursal = Celda2.Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Continuar?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto) 
            {
                Negocio.FEmpresa.eliminarSucursal(codigoSucursal);
                CargarDGV();
            }
        }

        private void btnImprimirSucursal_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.Rows.Count == 0)
            {
                return;
            }

            frmReporte reporte = new frmReporte("Sucursal", FEmpresa.querySucursales, "", "Sucursales", "Todas", DateTime.Now.ToString("d"));
            reporte.ShowDialog();
        }

        private void btnImprimirEmpresa_Click(object sender, EventArgs e)
        {
            if (dgvEmpresa.Rows.Count == 0)
            {
                return;
            }

            frmReporte reporte = new frmReporte("Empresa", FEmpresa.queryEmpresa, "", "Empresa", FLogin.NombreEmpresa, null, null);
            reporte.ShowDialog();
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
