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
using System.Speech.Synthesis.TtsEngine;
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

        public static int nuevoasiento = 0;

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
                    double debe = 0;
                    double haber = 0;
                    string descri = "";

                    int cuenta = Convert.ToInt32(dr2[0]);

                    if (dr2["mva_codigo"].ToString() == "1")
                    {
                        debe = Convert.ToDouble(dr2["mva_importe"]);
                    }
                    else if (dr2["mva_codigo"].ToString() == "2")
                    {
                        haber = Convert.ToDouble(dr2["mva_importe"]);
                    }

                    string concepto = dr2["mva_comenta"].ToString();

                    int cc = 0;
                    string centrodecosto = dr2["mva_cc"].ToString();
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

                    string query = "";
                    string money = "";
                    if (debe != 0)
                    {
                        money = debe.ToString();
                        query = $"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES({terminal},{cuenta},'{descri}',*,0,'{concepto}',{autoincremental},'{asiento}',{cc})";
                    }
                    else if (haber != 0)
                    {
                        money = haber.ToString();
                        query = $"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES({terminal},{cuenta},'{descri}',0,*,'{concepto}',{autoincremental},'{asiento}',{cc})";
                    }
                    AccesoBase.InsertUpdateDatosMoney(query, money);
                    autoincremental++;
                }
                CargarDGV(asiento);
            }
        }

        private void CargarDGV(string asiento)
        {
            if (asiento == "ALTA EN CONCEPTO")
            {
                asiento = Negocio.FGenerales.ultimoNumeroID("ast_asiento","Asiento").ToString();
            }

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

        private void dgvAddModVisASIENTO_DoubleClick_1(object sender, EventArgs e)
        {
            try
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
                    string codigo = dgvAddModVisASIENTO.Rows[seleccionado].Cells[6].Value.ToString(); //codigo autoincremental

                    frmAddModDetdeModelos.desdeotrofrm = true;
                    frmAddModDetdeModelos.asientofrm = txtNroAsiento.Text;
                    frmAddModDetdeModelos.codigofrm = codigo;
                    frmAddModDetdeModelos frm = new frmAddModDetdeModelos(1, cuenta, descri, debe, haber, concepto, cc);
                    frm.ShowDialog();
                    dgvAddModVisASIENTO.Rows.Clear();
                    autoincremental2 = 1;
                    CargarDGV(txtNroAsiento.Text);
                }
            }
            catch (NullReferenceException)
            {
                frmAddModDetdeModelos.desdeotrofrm = true;
                frmAddModDetdeModelos.asientofrm = txtNroAsiento.Text;
                frmAddModDetdeModelos frm = new frmAddModDetdeModelos(0);
                frm.ShowDialog();
                frmAddModDetdeModelos.desdeotrofrm = false;
                dgvAddModVisASIENTO.Rows.Clear();
                CargarDGV(nuevoasiento.ToString());
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToLongTimeString();
            string fecha = DateTime.Now.ToShortDateString();

            //VALIDACIONES
            int validaciones = 0;
            int[] MSGValidaciones = new int[4];

            DataSet dsV = new DataSet();
            dsV = AccesoBase.ListarDatos("SELECT mva_debe, mva_haber FROM Aux_MovAsto");
            if (dsV.Tables[0].Rows.Count != 0)
            {
                validaciones++; //VALIDA QUE HAYA POR LO MENOS UN DETALLE
                MSGValidaciones[0] = 1;
            }

            double totaldebe = 0;
            double totalhaber = 0;
            foreach (DataRow drV in dsV.Tables[0].Rows) 
            {
                double debe = Convert.ToDouble(drV["mva_debe"]);
                double haber = Convert.ToDouble(drV["mva_haber"]);

                totaldebe = totaldebe + debe;
                totalhaber = totalhaber + haber;
            }
            if (totaldebe == totalhaber)
            {
                validaciones++; //VALIDA QUE EL ASIENTO ESTE BALANCEADO
                MSGValidaciones[1] = 1;
            }

            if (txtComentario.Text != "")
            {
                validaciones++; //VALIDA QUE EL ASIENTO TENGA COMENTARIO
                MSGValidaciones[2] = 1;
            }

            DateTime fechadesde;
            DateTime fechahasta;
            dsV = AccesoBase.ListarDatos($"SELECT eje_desde, eje_hasta FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
            foreach (DataRow drV in dsV.Tables[0].Rows) 
            {
                fechadesde = Convert.ToDateTime(drV["eje_desde"]);
                fechahasta = Convert.ToDateTime(drV["eje_hasta"]);

                if (fechadesde <= dtFecha.Value && fechahasta >= dtFecha.Value)
                {
                    validaciones++;//VALIDA QUE LA FECHA DEL ASIENTO SE ENCUENTRE DENTRO DEL EJERCICIO
                    MSGValidaciones[3] = 1;
                }

                if (Convert.ToInt32(cbTipoAsiento.SelectedValue) == 4)
                {
                    string dtfecha = dtFecha.Value.ToString();
                    dtfecha = dtfecha.Substring(0, 10);
                    
                    string fechacierre = fechahasta.ToString();
                    fechacierre = fechacierre.Substring(0, 10);

                    if (Convert.ToDateTime(dtfecha) == Convert.ToDateTime(fechacierre))
                    {
                        validaciones++;//VALIDA QUE LA FECHA DEL ASIENTO DE CIERRE SEA IGUAL QUE EL HASTA EL EJERCICIO
                        MSGValidaciones[4] = 1;
                    }
                }
            }

            if (Convert.ToInt32(cbTipoAsiento.SelectedValue) != 2)
            {
                int resultado = AccesoBase.ValidarDatos($"SELECT ast_tipo FROM Asiento WHERE ast_tipo = {cbTipoAsiento.SelectedValue}");
                if (resultado == 1) 
                {
                    DialogResult boton = MessageBox.Show("Atención: El asiento de tipo " + cbTipoAsiento.SelectedText.ToString() + " ya ha sido registrado para este ejercicio. ¿Desea Continuar?", "Mensaje", MessageBoxButtons.OKCancel);
                    if (boton == DialogResult.OK)
                    {
                        validaciones++;//ADVIERTE SI YA HAY UN TIPO DE ASIENTO DISTINTO DE REGISTRACION
                    }
                }
            }
            // 

            if (validaciones >= 4 && validaciones <= 6)
            {
                if (add_mod_vis == 1)
                {
                    string asiento_renumera = Negocio.FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();

                    AccesoBase.InsertUpdateDatos($"INSERT INTO Asiento(ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo) VALUES('{asiento_renumera}','{asiento_renumera}','{dtFecha.Value}','{txtComentario.Text}','{FLogin.IdUsuario}','{hora}','{txtCodEjercicio}','{fecha}','{cbTipoAsiento.SelectedValue}'");
                    MessageBox.Show("Agregado Correctamente!", "Mensaje");
                    this.Close();
                }
                else if (add_mod_vis == 2)
                {
                    //MODIFICÁ TABLA MOVASTO
                    DialogResult boton = MessageBox.Show("Desea Finalizar la Modificación?", "Mensaje", MessageBoxButtons.OKCancel);
                    if (boton == DialogResult.OK)
                    {
                        int terminal = 0;
                        int asiento = 0;
                        string fechasiento = "";

                        DataSet ds = new DataSet();
                        ds = AccesoBase.ListarDatos($"SELECT mva_terminal, mva_asiento, mva_cuenta, mva_debe, mva_haber, mva_concepto, mva_cc FROM Aux_MovAsto");

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            asiento = Convert.ToInt32(dr["mva_asiento"]);
                        }
                        AccesoBase.InsertUpdateDatos($"DELETE MovAsto WHERE mva_asiento = {asiento}");

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            terminal = Convert.ToInt32(dr["mva_terminal"]);
                            int cuenta = Convert.ToInt32(dr["mva_cuenta"]);
                            double debe = Convert.ToDouble(dr["mva_debe"]);
                            double haber = Convert.ToDouble(dr["mva_haber"]);
                            string concepto = dr["mva_concepto"].ToString();
                            string cc = dr["mva_cc"].ToString();
                            if (cc != "0")
                            {
                                Convert.ToInt32(cc);
                            }

                            DataSet ds2 = new DataSet();
                            ds2 = AccesoBase.ListarDatos($"SELECT ast_fecha FROM Asiento WHERE ast_asiento = {asiento}");
                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                            {
                                fechasiento = dr2["ast_fecha"].ToString();
                            }

                            string query = "";
                            string money = "";
                            int codigo = 0;
                            if (debe != 0)
                            {
                                money = debe.ToString();
                                codigo = 1;
                            }
                            else if (haber != 0)
                            {
                                money = haber.ToString();
                                codigo = 2;
                            }

                            if (cc == "0")
                            {
                                query = $"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{fechasiento}',{cuenta},{codigo},*,'{concepto}',null)";
                            }
                            else
                            {
                                query = $"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{fechasiento}',{cuenta},{codigo},*,'{concepto}',{cc})";
                            }
                            AccesoBase.InsertUpdateDatosMoney(query, money);
                        }
                        AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto WHERE mva_terminal = {terminal}");

                        //MODIFICÁ TABLA ASIENTO
                        AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET ast_usumodi = '{Negocio.FLogin.IdUsuario}', ast_fecmodi = '{fecha}', ast_horamodi = '{hora}', ast_tipo = {cbTipoAsiento.SelectedValue}, ast_comenta = '{txtComentario.Text}' WHERE ast_Asiento = '{txtNroAsiento.Text}'");
                        this.Close();
                    }
                }
            }
            else
            {
                if (MSGValidaciones[0] != 1)
                {
                    MessageBox.Show("Atención: Debe agregar un detalle", "Mensaje");
                }
                else if (MSGValidaciones[1] != 1) 
                {
                    MessageBox.Show("Atención: El asiento debe estar balanceado", "Mensaje");
                }
                else if (MSGValidaciones[2] != 1)
                {
                    MessageBox.Show("Atención: Debe agregar un comentario", "Mensaje");
                }
                else if (MSGValidaciones[3] != 1)
                {
                    MessageBox.Show("Atención: La fecha ingresada no concuerda con los parametros del ejercicio", "Mensaje");
                }
                else if (MSGValidaciones[4] != 1)
                {
                    MessageBox.Show("Atención: La fecha de cierre no concuerda con la del ejercicio", "Mensaje");
                }
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("mod_codigo, mod_descri", "ModeloEncab", "", "ORDER BY mod_codigo", "frmAggModVisAsientoContable");
            //frm.ArmarDGV("mod_codigo, mod_descri", "ModeloEncab", "", "ORDER BY mod_codigo", "frmAggModVisAsientoContable");
            frm.ShowDialog();
            string codigoCG = frmConsultaGeneral.codigoCG;
            if (codigoCG != null)
            {
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
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

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
