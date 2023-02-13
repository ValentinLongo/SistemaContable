using Datos;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos;
using SistemaContable.Plan_de_Cuentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmAggModVisAsientoContable : Form
    {
        //addmodvis = proceso que realiza el frm
        public frmAggModVisAsientoContable(int addmodvis, ComboBox cbSeleccion, string asiento, string fecha, string comentario)
        {
            InitializeComponent();
            Setear(addmodvis,cbSeleccion.SelectedValue.ToString(),cbSeleccion.Text, asiento, fecha, comentario);
        }

        private void Setear(int addmodvis,string codejercicio, string descriejercicio, string asiento, string fecha, string comentario)
        {
            txtCodEjercicio.Text = codejercicio;
            txtDescriEjercicio.Text = descriejercicio;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT tas_codigo,tas_descri FROM TipAsto");
            cbTipoAsiento.DataSource = ds.Tables[0];
            cbTipoAsiento.DisplayMember = "tas_descri";
            cbTipoAsiento.ValueMember = "tas_codigo";
            cbTipoAsiento.SelectedIndex = 1;

            if (addmodvis == 1) // agregar
            {
                lblControlBar.Text = "Agregar Asiento Contable";
                txtNroAsiento.Text = "ALTA EN CONCEPTO";
                txtNroAsiento.Enabled = false;
                
                //consulta (terminar)
            }
            else if(addmodvis == 2) // modificar
            {
                lblControlBar.Text = "Modificar Asiento Contable";
                txtNroAsiento.Text = asiento;
                dtFecha.Value = Convert.ToDateTime(fecha);
                txtComentario.Text = comentario;

                //carga de datos
                txtNroAsiento.Enabled = false;
                dtFecha.Enabled = false;

                //botones
                btnGenerar.Enabled = false;

                CargarDGV(asiento);

                AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET");
            }
            else if(addmodvis == 3) // visualizar
            {
                lblControlBar.Text = "Visualizar Asiento Contable";
                txtNroAsiento.Text = asiento;
                dtFecha.Value = Convert.ToDateTime(fecha);
                txtComentario.Text = comentario;

                //carga de datos
                cbTipoAsiento.Enabled = false;
                txtNroAsiento.Enabled = false;
                dtFecha.Enabled = false;
                txtComentario.Enabled = false;

                //botones
                btnConfirmar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGenerar.Enabled = false;
                btnModelo.Enabled = false;

                //dgv
                dgvAddModVisASIENTO.Enabled = false;

                CargarDGV(asiento);
            }
        }

        private void CargarDGV(string asiento) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc FROM MovAsto WHERE mva_asiento = {asiento}");
            foreach (DataRow dr in ds.Tables[0].Rows) 
            {
                string debe = "0,0000";
                string haber = "0,0000";
                string descri = "";

                string cuenta = dr[0].ToString();

                if (dr[1].ToString() == "1")
                {
                    debe = dr[2].ToString();
                }
                else if (dr[1].ToString() == "2")
                {
                    haber = dr[2].ToString();
                }

                string concepto = dr[3].ToString();
                string cc = dr[4].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {cuenta}");
                foreach (DataRow dr2 in ds2.Tables[0].Rows) 
                {
                    descri = dr2[0].ToString();
                }

                dgvAddModVisASIENTO.Rows.Add(cuenta,descri,debe,haber,concepto,cc);
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnPlandeCta_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            frm.Show();
            //ponerle barra de control
        }

        private void dgvAddModVisASIENTO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccionado = dgvAddModVisASIENTO.CurrentCell.RowIndex;

            if (seleccionado != -1)
            {
                string cuenta = dgvAddModVisASIENTO.Rows[seleccionado].Cells[0].Value.ToString();
                string descri = dgvAddModVisASIENTO.Rows[seleccionado].Cells[1].Value.ToString();
                string debe = dgvAddModVisASIENTO.Rows[seleccionado].Cells[2].Value.ToString();
                string haber = dgvAddModVisASIENTO.Rows[seleccionado].Cells[3].Value.ToString();
                string concepto = dgvAddModVisASIENTO.Rows[seleccionado].Cells[4].Value.ToString();
                string cc = dgvAddModVisASIENTO.Rows[seleccionado].Cells[5].Value.ToString();

                frmAddModDetdeModelos frm = new frmAddModDetdeModelos(1, cuenta, descri, debe, haber, concepto, cc);
                frm.Show();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
