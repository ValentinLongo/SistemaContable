using CrystalDecisions.Shared.Json;
using Datos;
using Negocio;
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
        int autoincremental = 1;
        int autoincremental2 = 1;

        //addmodvis = proceso que realiza el frm
        public frmAggModVisAsientoContable(int addmodvis, ComboBox cbSeleccion, string asiento, string fecha, string comentario)
        {
            InitializeComponent();
            add_mod_vis = addmodvis;
            Setear(addmodvis, cbSeleccion.SelectedValue.ToString(), cbSeleccion.Text, asiento, fecha, comentario);
        }

        private void Setear(int addmodvis, string codejercicio, string descriejercicio, string asiento, string fecha, string comentario)
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
            else if (addmodvis == 2) // modificar
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
            }
            else if (addmodvis == 3) // visualizar
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
            }

            if (addmodvis == 2 || addmodvis == 3)
            {
                int terminal = Convert.ToInt32(frmLogin.NumeroTerminal);

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc FROM MovAsto WHERE mva_asiento = {asiento}");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    int debe = 0;
                    int haber = 0;
                    string descri = "";

                    int cuenta = Convert.ToInt32(dr2[0]);

                    if (dr2[1].ToString() == "1")
                    {
                        debe = Convert.ToInt32(dr2[2]);
                    }
                    else if (dr2[1].ToString() == "2")
                    {
                        haber = Convert.ToInt32(dr2[2]);
                    }

                    string concepto = dr2[3].ToString();

                    int cc = 0;
                    string centrodecosto = dr2[4].ToString();
                    if (centrodecosto != "")
                    {
                        cc = Convert.ToInt32(centrodecosto);
                    }

                    DataSet ds3 = new DataSet();
                    ds3 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {cuenta}");
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        descri = dr3[0].ToString();
                    }

                    AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES({terminal},{cuenta},'{descri}',{debe},{haber},'{concepto}',{autoincremental},{asiento},{cc})");
                    autoincremental++;
                }
                CargarDGV(asiento);
            }
        }

        private void CargarDGV(string asiento)
        {

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cc FROM Aux_MovAsto WHERE mva_asiento = '{asiento}'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string cuenta = dr["mva_cuenta"].ToString();
                string descri = dr["mva_descri"].ToString();
                string debe = dr["mva_debe"].ToString();
                string haber = dr["mva_haber"].ToString();
                string concepto = dr["mva_concepto"].ToString();
                string cc = dr["mva_cc"].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT cec_descri FROM CentroC WHERE cec_codigo = '{cc}'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        cc = dr2["cec_descri"].ToString();
                    }
                }
                else
                {
                    cc = "";
                }
                dgvAddModVisASIENTO.Rows.Add(cuenta, descri, debe, haber, concepto, cc, autoincremental2);
                autoincremental2++;
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
                //frmAddModDetdeModelos.cuentafrm = cuenta;
                frmAddModDetdeModelos.codigofrm = codigo;
                frmAddModDetdeModelos frm = new frmAddModDetdeModelos(1, cuenta, descri, debe, haber, concepto, cc);
                frm.ShowDialog();
                dgvAddModVisASIENTO.Rows.Clear();
                autoincremental2 = 1;
                CargarDGV(txtNroAsiento.Text);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToLongTimeString();
            string fecha = DateTime.Now.ToShortDateString();

            //hacer validaciones (confirmar - para agregar y para modificar)

            if (add_mod_vis == 1)
            {
                string asiento_renumera = Negocio.FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();

                AccesoBase.InsertUpdateDatos($"INSERT INTO Asiento(ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo) VALUES('{asiento_renumera}','{asiento_renumera}','{dtFecha.Value}','{txtComentario.Text}','{FLogin.IdUsuario}','{hora}','{txtCodEjercicio}','{fecha}','{cbTipoAsiento.SelectedValue}'");
                MessageBox.Show("Agregado Correctamente!", "Mensaje");
                this.Close();
            }
            else if (add_mod_vis == 2)
            {
                DialogResult boton = MessageBox.Show("Desea Finalizar la Modificación?", "Mensaje", MessageBoxButtons.OKCancel);
                if (boton == DialogResult.OK)
                {
                    int asiento = 0;
                    string fechasiento = "";

                    DataSet ds = new DataSet();
                    ds = AccesoBase.ListarDatos($"SELECT mva_asiento, mva_cuenta, mva_debe, mva_haber, mva_concepto, mva_cc FROM Aux_MovAsto");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        asiento = Convert.ToInt32(dr["mva_asiento"]);
                    }
                    AccesoBase.InsertUpdateDatos($"DELETE MovAsto WHERE mva_asiento = {asiento}");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int cuenta = Convert.ToInt32(dr["mva_cuenta"]);
                        string debe = dr["mva_debe"].ToString();
                        string haber = dr["mva_haber"].ToString();
                        string concepto = dr["mva_concepto"].ToString();
                        int cc = Convert.ToInt32(dr["mva_cc"]);
                        //string cc = dr["mva_cc"].ToString();
                        //if (cc == "0") 
                        //{
                        //    cc = null;
                        //}
                        //if (cc != null)
                        //{
                        //    Convert.ToInt32(cc);
                        //}

                        //guarda cc como null (cuando corresponda)
                        //guardar bien los decimales y el codigo
                        //corroborar codigo y probar

                        DataSet ds2 = new DataSet();
                        ds2 = AccesoBase.ListarDatos($"SELECT ast_fecha FROM Asiento WHERE ast_asiento = {asiento}");
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            fechasiento = dr2["ast_fecha"].ToString();
                        }

                        if (debe != "0")
                        {
                            AccesoBase.InsertUpdateDatos($"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{fechasiento}',{cuenta},{1},'{debe}','{concepto}',{cc})");
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatos($"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{fechasiento}',{cuenta},{2},'{haber}','{concepto}',{cc})");
                        }
                    }
                    AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto");

                    //
                    AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET ast_usumodi = '{Negocio.FLogin.IdUsuario}', ast_fecmodi = '{fecha}', ast_horamodi = '{hora}', ast_tipo = {cbTipoAsiento.SelectedValue}, ast_comenta = '{txtComentario.Text}' WHERE ast_Asiento = '{txtNroAsiento.Text}'");
                    this.Close();
                }
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral();
            frm.ArmarDGV("mod_codigo, mod_descri", "ModeloEncab", "", "ORDER BY mod_codigo", "frmAggModVisAsientoContable");
            frm.ShowDialog();
            string codigoCG = frmConsultaGeneral.codigoCG;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT det_asiento, det_fecha, det_cuenta, det_codigo, det_importe, det_comenta, det_cc FROM ModeloDet WHERE det_asiento = {codigoCG}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string debe = "0";
                string haber = "0";
                string descri = "";

                string cuenta = dr[2].ToString();

                if (dr[3].ToString() == "1")
                {
                    debe = dr[4].ToString();
                }
                else if (dr[3].ToString() == "2")
                {
                    haber = dr[4].ToString();
                }

                string codigo = dr[3].ToString(); //(esta en el dgv pero, visible = false)

                string concepto = dr[5].ToString();
                string cc = dr[6].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {cuenta}");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    descri = dr2[0].ToString();
                }
                dgvAddModVisASIENTO.Rows.Add(cuenta, descri, debe, haber, concepto, cc, codigo);
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
    }
}
