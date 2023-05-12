using Datos;
using Negocio;
using Negocio.Funciones.Mantenimiento;
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
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    public partial class frmBuscarCuenta : Form
    {
        FConceptosContables data = new FConceptosContables();
        private string Accion;
        public static int IdCuenta;
        public static string DescriCuenta;
        public static int IdContrapartida;
        public static string txt = "";
        public static string txt2 = "";

        public frmBuscarCuenta(string accion) 
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDGV();
            cbBusqueda.SelectedIndex = 0;
            Accion = accion;
        }

        private void cargarDGV()
        {
            btnSeleccionar.Enabled = false;
            DataSet ds = new DataSet();

            if (checkActivas.Checked == true)
            {
                ds = data.listaCuentasActivas(txt2);
                dgvCuentas.DataSource = ds.Tables[0];
            }
            else
            {
                ds = data.listaCuentas(txt);
                dgvCuentas.DataSource = ds.Tables[0];
            }

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvCuentas);
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (IdCuenta > -1)
            {
                this.Close();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe seleccionar una cuenta", false);
                MessageBox.ShowDialog();
            }
        }

        private void checkActivas_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            cargarDGV();
        }

        private void dgvCuentas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSeleccionar.Enabled = true;
            if (Accion == "Cuenta")
            {
                IdCuenta = (int)dgvCuentas.Rows[e.RowIndex].Cells[1].Value;
                DescriCuenta = dgvCuentas.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else if (Accion == "Contrapartida")
            {
                IdContrapartida = (int)dgvCuentas.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                if (cbBusqueda.SelectedIndex == 0)
                {
                    if (CheckInicio.Checked)
                    {
                        txt = "WHERE pcu_cuenta LIKE " + "'" + txtBusqueda.Text + "%'";
                        txt2 = "AND pcu_cuenta LIKE " + "'" + txtBusqueda.Text + "%'";
                    }
                    else
                    {
                        txt = "WHERE pcu_cuenta LIKE " + "'%" + txtBusqueda.Text + "%'";
                        txt2 = "AND pcu_cuenta LIKE " + "'%" + txtBusqueda.Text + "%'";
                    }
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (CheckInicio.Checked)
                    {
                        txt = "WHERE pcu_descri LIKE " + "'" + txtBusqueda.Text + "%'";
                        txt2 = "AND pcu_descri LIKE " + "'" + txtBusqueda.Text + "%'";
                    }
                    else
                    {
                        txt = "WHERE pcu_descri LIKE " + "'%" + txtBusqueda.Text + "%'";
                        txt2 = "AND pcu_descri LIKE " + "'%" + txtBusqueda.Text + "%'";
                    }
                }
            }
            else
            {
                txt = "";
                txt2 = "";
            }
            cargarDGV();
        }

        private void bunifuFormControlBox1_CloseClicked(object sender, EventArgs e)
        {
            IdCuenta = 0;
            DescriCuenta = "";
            IdContrapartida = 0;
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
