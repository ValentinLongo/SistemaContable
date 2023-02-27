using Datos;
using SistemaContable.General;
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
        private static int add_mod_vis;

        //addmodvis = proceso que realiza el frm
        public frmAggModVisAsientoContable(int addmodvis, ComboBox cbSeleccion, string asiento, string fecha, string comentario)
        {
            InitializeComponent();
            add_mod_vis = addmodvis;
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

                string codigo = dr[1].ToString(); //(esta en el dgv pero, visible = false)

                string concepto = dr[3].ToString();
                string cc = dr[4].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {cuenta}");
                foreach (DataRow dr2 in ds2.Tables[0].Rows) 
                {
                    descri = dr2[0].ToString();
                }

                dgvAddModVisASIENTO.Rows.Add(cuenta,descri,debe,haber,concepto,cc,codigo);
            }
        }

        private void btnPlandeCta_Click(object sender, EventArgs e)
        {
            frmPlanDeCuentas.MostrarControlBar = true;
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            frm.Show();
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
                string codigo = dgvAddModVisASIENTO.Rows[seleccionado].Cells[6].Value.ToString();

                frmAddModDetdeModelos.desdeotrofrm = true;
                frmAddModDetdeModelos.asientofrm = txtNroAsiento.Text;
                frmAddModDetdeModelos.cuentafrm = cuenta;
                frmAddModDetdeModelos.codigofrm = codigo;
                frmAddModDetdeModelos frm = new frmAddModDetdeModelos(1, cuenta, descri, debe, haber, concepto, cc);
                frm.ShowDialog();
                dgvAddModVisASIENTO.Rows.Clear();
                CargarDGV(txtNroAsiento.Text);

                //terminar modificar (preguntar jp)
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //hacer validaciones (preguntar jp)

            if (add_mod_vis == 1)
            {
                //terminar agregar
            }
            else if (add_mod_vis == 2)
            {
                string hora = DateTime.Now.ToLongTimeString();
                string fecha = DateTime.Now.ToShortDateString();

                DialogResult boton = MessageBox.Show("Desea Finalizar la Modificación?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (boton == DialogResult.OK) 
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET ast_usumodi = '{Negocio.FLogin.IdUsuario}', ast_fecmodi = '{fecha}', ast_horamodi = '{hora}', ast_tipo = {cbTipoAsiento.SelectedValue}, ast_comenta = '{txtComentario.Text}' WHERE ast_Asiento = '{txtNroAsiento.Text}'");
                    MessageBox.Show("Modificado Correctamente!", "Mensaje");
                    this.Close();
                }
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral();
            frm.ArmarDGV("mod_codigo, mod_descri", "ModeloEncab","","ORDER BY mod_codigo", "frmAggModVisAsientoContable");
            frm.ShowDialog();
            string codigo = frmConsultaGeneral.codigoCG;



            //terminar (preguntar jp)
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
    }
}
