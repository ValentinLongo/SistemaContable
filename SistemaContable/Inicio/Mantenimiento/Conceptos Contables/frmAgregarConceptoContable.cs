using Datos;
using Datos.Modelos;
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

namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    public partial class frmAgregarConceptoContable : Form
    {
        private string Accion;
        FConceptosContables data = new FConceptosContables();
        public frmAgregarConceptoContable(string accion)
        {
            InitializeComponent();

            checkVentas.Checked = true;

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Accion = accion;
            cargarDatos();
        }

        private void cargarDatos()
        {
            cbCentroCostos1.Text = "NINGUNO";
            cbCentroCostos2.Text = "NINGUNO";

            MConceptoContable mConceptoContable = new MConceptoContable();
            if (Accion == "Agregar")
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
            }
            if (Accion == "Modificar")
            {
                tbCodigo.Text = frmConceptosContables.Codigo.ToString();
                mConceptoContable = data.conceptoContableParticular(frmConceptosContables.Codigo);
                tbDescripción.Text = mConceptoContable.coc_descri;
                tbNroCuenta.Text = mConceptoContable.coc_ctacont.ToString();
                tbDescriCuenta.Text = mConceptoContable.pcu_descriCuenta;
                tbNumContrapartida.Text = mConceptoContable.coc_contrap.ToString();
                tbDescriContrapartida.Text = mConceptoContable.pcu_descriContrap;
                cbCentroCostos1.SelectedItem = mConceptoContable.coc_cccta;
                cbCentroCostos2.SelectedItem = mConceptoContable.coc_cccontrap;
                if (mConceptoContable.coc_vta == 1)
                {
                    checkVentas.Checked = true;
                }
                if (mConceptoContable.coc_cpa == 1)
                {
                    checkCompras.Checked = true;
                }
                if (mConceptoContable.coc_caja == 1)
                {
                    checkTesoreria.Checked = true;
                }
                if (mConceptoContable.coc_banco == 1)
                {
                    checkBancos.Checked = true;
                }

            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Cuenta");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdCuenta);
            if (descripcion != "")
            {
                tbNroCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = descripcion;
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Contrapartida");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdContrapartida);
            if (descripcion != "")
            {
                tbNumContrapartida.Text = frmBuscarCuenta.IdContrapartida.ToString();
                tbDescriContrapartida.Text = descripcion;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                MConceptoContable mConceptoContable = new MConceptoContable()
                {
                    coc_codigo = FGenerales.ultimoNumeroID("coc_codigo", "ConceptoCont"),
                    coc_descri = tbDescripción.Text,
                    coc_vta = 0,
                    coc_cpa = 0,
                    coc_caja = 0,
                    coc_banco = 0,
                    coc_ctacont = Convert.ToInt32(tbNroCuenta.Text),
                    pcu_descriCuenta = tbDescriCuenta.Text,
                    coc_contrap = Convert.ToInt32(tbNumContrapartida.Text),
                    pcu_descriContrap = tbDescriContrapartida.Text,
                    coc_cccontrap = Convert.ToInt32(cbCentroCostos2.SelectedValue),
                    coc_cccta = Convert.ToInt32(cbCentroCostos1.SelectedValue),
                };
                if (checkVentas.Checked)
                {
                    mConceptoContable.coc_vta = 1;
                }
                if (checkCompras.Checked)
                {
                    mConceptoContable.coc_cpa = 1;
                }
                if (checkTesoreria.Checked)
                {
                    mConceptoContable.coc_caja = 1;
                }
                if (checkBancos.Checked)
                {
                    mConceptoContable.coc_banco = 1;
                }
                if (Accion == "Agregar")
                {
                    data.agregarConceptoCont(mConceptoContable);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                if (Accion == "Modificar")
                {
                    mConceptoContable.coc_codigo = Convert.ToInt32(tbCodigo.Text);
                    data.modificarConceptoCont(mConceptoContable);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }

        private void tbNroCuenta_TextChanged(object sender, EventArgs e)
        {
            if (tbNroCuenta.Text == "")
            {
                tbNroCuenta.Text = "";
                tbDescriCuenta.Text = "";
                cbCentroCostos1.DataSource = null;
                cbCentroCostos1.Text = "NINGUNO";               
                return;
            }

            DataSet ds = new DataSet();
            if (frmBuscarCuenta.ValidacionMovimientos(Convert.ToInt32(tbNroCuenta.Text)))
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {tbNroCuenta.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tbDescriCuenta.Text = dr["pcu_descri"].ToString();
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                MessageBox.ShowDialog();
                return;
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta LEFT JOIN CentroCxPCuenta on pcu_cuenta = cxp_cuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo WHERE pcu_cuenta = '{tbNroCuenta.Text}' AND cec_codigo is not null");
            if (ds2.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    cbCentroCostos1.DataSource = ds2.Tables[0];
                    cbCentroCostos1.ValueMember = "cec_codigo";
                    cbCentroCostos1.DisplayMember = "cec_descri";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NINGUNO");
                dt.Rows.Add("NINGUNO");
                cbCentroCostos1.DataSource = dt;
                cbCentroCostos1.ValueMember = "NINGUNO";
                cbCentroCostos1.DisplayMember = "NINGUNO";
            }
        }

        private void tbNumContrapartida_TextChanged(object sender, EventArgs e)
        {
            if (tbNumContrapartida.Text == "")
            {
                tbNumContrapartida.Text = "";
                tbDescriContrapartida.Text = "";
                cbCentroCostos2.DataSource = null;
                cbCentroCostos2.Text = "NINGUNO";
                return;
            }

            DataSet ds = new DataSet();
            if (frmBuscarCuenta.ValidacionMovimientos(Convert.ToInt32(tbNumContrapartida.Text)))
            {
                ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {tbNumContrapartida.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tbDescriContrapartida.Text = dr["pcu_descri"].ToString();
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La cuenta contable No puede recibir movimientos.", false);
                MessageBox.ShowDialog();
                return;
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta LEFT JOIN CentroCxPCuenta on pcu_cuenta = cxp_cuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo WHERE pcu_cuenta = '{tbNumContrapartida.Text}' AND cec_codigo is not null");
            if (ds2.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    cbCentroCostos2.DataSource = ds2.Tables[0];
                    cbCentroCostos2.ValueMember = "cec_codigo";
                    cbCentroCostos2.DisplayMember = "cec_descri";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NINGUNO");
                dt.Rows.Add("NINGUNO");
                cbCentroCostos2.DataSource = dt;
                cbCentroCostos2.ValueMember = "NINGUNO";
                cbCentroCostos2.DisplayMember = "NINGUNO";
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void checkVentas_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkVentas.Checked)
            {
                checkCompras.Checked = false;
                checkTesoreria.Checked = false;
                checkBancos.Checked = false;
            }
        }

        private void checkCompras_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkCompras.Checked)
            {
                checkVentas.Checked = false;
                checkTesoreria.Checked = false;
                checkBancos.Checked = false;
            }
        }

        private void checkTesoreria_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkTesoreria.Checked)
            {
                checkVentas.Checked = false;
                checkCompras.Checked = false;
                checkBancos.Checked = false;
            }
        }

        private void checkBancos_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkBancos.Checked)
            {
                checkVentas.Checked = false;
                checkCompras.Checked = false;
                checkTesoreria.Checked = false;
            }
        }
    }
}
