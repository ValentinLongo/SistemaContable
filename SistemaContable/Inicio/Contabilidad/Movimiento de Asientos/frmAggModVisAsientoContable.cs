﻿using CrystalDecisions.Shared.Json;
using Datos;
using Datos.Modelos;
using Negocio;
using SistemaContable.General;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos;
using SistemaContable.Plan_de_Cuentas;
using SistemaContable.Usuarios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Design;
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
        private static int terminal = frmLogin.NumeroTerminal;

        int autoincremental = 1;
        int autoincremental2 = 1;

        public static int nuevoasiento = 0;

        public static bool flag = true; //para repetir la carga de detalles y que se valla actualizando el dgv

        public static bool MODELO = false; //para poder imprimir el modelo

        //addmodvis = proceso que realiza el frm
        public frmAggModVisAsientoContable(int addmodvis, [Optional] ComboBox cbSeleccion, [Optional] string asiento, [Optional] string fecha, [Optional] string comentario, [Optional] MAsiento modelo)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            add_mod_vis = addmodvis;

            if (modelo != null)
            {
                MODELO = true;
                Setear(addmodvis, "", "", "", "", "", modelo);
            }
            else
            {
                Setear(addmodvis, cbSeleccion.SelectedValue.ToString(), cbSeleccion.Text, asiento, fecha, comentario);
            }
        }

        private void Setear(int addmodvis, string codejercicio, string descriejercicio, string asiento, string fecha, string comentario, [Optional] MAsiento modelo)
        {
            if (modelo == null)
            {
                AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto WHERE mva_terminal = {terminal}");
            }

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
                maskFecha.Text = DateTime.Now.ToString();

                //carga de datos
                txtNroAsiento.Enabled = false;

                //botones
                btnGenerar.Enabled = false;

                if (modelo != null)
                {
                    txtCodEjercicio.Text = modelo.ast_nroEjer.ToString();
                    txtDescriEjercicio.Text = modelo.ast_descriEjer;
                    cbTipoAsiento.SelectedIndex = modelo.ast_cbTipoAsientoIndex;
                    maskFecha.Text = Convert.ToDateTime(modelo.ast_fecha).ToString();
                    cbTipoAsiento.Enabled = modelo.ast_cbTipoAsiento;
                    btnGenerar.Enabled = modelo.ast_btnGenerar;
                    btnPlandeCta.Enabled = modelo.ast_btnPlanDeCuenta;
                    btnModelo.Enabled = modelo.ast_btnModelo;

                    CargarDGV("ALTA EN CONCEPTO", modelo);
                }

            }
            else if (addmodvis == 2) // modificar
            {
                lblControlBar.Text = "Modificar Asiento Contable";
                txtNroAsiento.Text = asiento;
                maskFecha.Text = Convert.ToDateTime(fecha).ToString();
                txtComentario.Text = comentario;

                //carga de datos
                txtNroAsiento.Enabled = false;
                maskFecha.Enabled = false;

                //botones
                btnGenerar.Enabled = false;
            }
            else if (addmodvis == 3) // visualizar
            {
                lblControlBar.Text = "Visualizar Asiento Contable";
                txtNroAsiento.Text = asiento;
                maskFecha.Text = Convert.ToDateTime(fecha).ToString();
                txtComentario.Text = comentario;

                //carga de datos
                cbTipoAsiento.Enabled = false;
                txtNroAsiento.Enabled = false;
                maskFecha.Enabled = false;
                txtComentario.Enabled = false;

                //botones
                btnConfirmar.Enabled = false;
                btnGenerar.Enabled = false;
                btnModelo.Enabled = false;

                //dgv
                dgvAddModVisASIENTO.ReadOnly = true;
            }

            if (addmodvis == 2 || addmodvis == 3)
            {
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
            SeteoFooter(dgvAddModVisASIENTO, footer);
            ActualizarFooter();
        }

        public void CargarDGV(string asiento, [Optional] MAsiento modelo)
        {
            dgvAddModVisASIENTO.Rows.Clear();

            if (asiento == "ALTA EN CONCEPTO")
            {
                asiento = Negocio.FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();
            }

            if (modelo != null)
            {
                asiento = "0";
            }

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cc, mva_cod FROM Aux_MovAsto WHERE mva_asiento = '{asiento}' AND mva_terminal = '{terminal}' ORDER BY mva_haber, mva_debe, mva_cuenta");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string cuenta = dr["mva_cuenta"].ToString();
                string descri = dr["mva_descri"].ToString();
                string debe = dr["mva_debe"].ToString();
                string haber = dr["mva_haber"].ToString();
                string concepto = dr["mva_concepto"].ToString();
                string cc = dr["mva_cc"].ToString();
                string cod = dr["mva_cod"].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT cec_descri FROM CentroC WHERE cec_codigo = '{cc}'");
                cc = ds2.Tables[0].Rows.Count != 0 ? cc = ds2.Tables[0].Rows[0]["cec_descri"].ToString() : cc = "";

                dgvAddModVisASIENTO.Rows.Add(cuenta, descri, debe, haber, concepto, cc, cod);
                autoincremental2++;
            }
            SeteoFooter(dgvAddModVisASIENTO, footer);
            ActualizarFooter();
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvAddModVisASIENTO);
        }

        private void btnPlandeCta_Click(object sender, EventArgs e)
        {
            if (Negocio.FInicio.FormActivo("frmPlanDeCuentas"))
            {
                Negocio.FInicio.MostrarForm("frmPlanDeCuentas", true);
                return;
            }
            frmPlanDeCuentas frm = new frmPlanDeCuentas();
            frm.ShowDialog();
        }
        private void dgvAddModVisASIENTO_DoubleClick_1(object sender, EventArgs e)
        {
            if (add_mod_vis == 3)
            {
                return;
            }

            flag = true;

            try //modificar
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
                    frmAddModDetdeModelos frm = new frmAddModDetdeModelos(1, cuenta, descri, debe, haber, concepto, cc, Convert.ToInt32(cbTipoAsiento.SelectedValue));
                    frm.ShowDialog();
                    CargarDGV(txtNroAsiento.Text);
                    autoincremental2 = 1;
                }
            }
            catch (NullReferenceException) //agregar
            {
                while (flag)
                {
                    frmAddModDetdeModelos.desdeotrofrm = true;
                    frmAddModDetdeModelos.asientofrm = txtNroAsiento.Text;
                    frmAddModDetdeModelos frm = new frmAddModDetdeModelos(0, null, null, null, null, null, null, Convert.ToInt32(cbTipoAsiento.SelectedValue));
                    frm.ShowDialog();
                    CargarDGV(nuevoasiento.ToString());
                }
            }
            ActualizarFooter();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
                return;
            }

            string hora = DateTime.Now.ToLongTimeString();
            string fecha = DateTime.Now.ToShortDateString();

            //VALIDACIONES
            int validaciones = 0;
            int[] MSGsErrores = new int[7];

            DataSet dsV = new DataSet();
            dsV = AccesoBase.ListarDatos($"SELECT mva_debe, mva_haber FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
            if (dsV.Tables[0].Rows.Count != 0)
            {
                validaciones++; //VALIDA QUE HAYA POR LO MENOS UN DETALLE.
            }
            else
            {
                MSGsErrores[0] = 1;
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

            if (Math.Round(totaldebe) == Math.Round(totalhaber))
            {
                validaciones++; //VALIDA QUE EL ASIENTO ESTE BALANCEADO.
            }
            else
            {
                MSGsErrores[1] = 1;
            }

            if (txtComentario.Text != "")
            {
                validaciones++; //VALIDA QUE EL ASIENTO TENGA COMENTARIO.
            }
            else
            {
                MSGsErrores[2] = 1;
            }

            DateTime fechadesde;
            DateTime fechahasta;
            dsV = AccesoBase.ListarDatos($"SELECT eje_desde, eje_hasta FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
            foreach (DataRow drV in dsV.Tables[0].Rows)
            {
                fechadesde = Convert.ToDateTime(drV["eje_desde"]);
                fechahasta = Convert.ToDateTime(drV["eje_hasta"]);

                if (fechadesde <= Convert.ToDateTime(maskFecha.Text) && fechahasta >= Convert.ToDateTime(maskFecha.Text))
                {
                    validaciones++;//VALIDA QUE LA FECHA DEL ASIENTO SE ENCUENTRE DENTRO DEL EJERCICIO.
                }
                else
                {
                    MSGsErrores[3] = 1;
                }

                string dtfecha = Convert.ToDateTime(maskFecha.Text).ToString();
                dtfecha = dtfecha.Substring(0, 10);

                if (Convert.ToInt32(cbTipoAsiento.SelectedValue) == 4)
                {
                    string fechacierre = fechahasta.ToString();
                    fechacierre = fechacierre.Substring(0, 10);

                    if (Convert.ToDateTime(dtfecha) == Convert.ToDateTime(fechacierre))
                    {
                        validaciones++;//VALIDA QUE LA FECHA DEL ASIENTO DE CIERRE SEA IGUAL QUE EL HASTA EL EJERCICIO.
                    }
                    else
                    {
                        MSGsErrores[4] = 1;
                    }
                }
                else if (Convert.ToInt32(cbTipoAsiento.SelectedValue) == 1)
                {
                    string fechapertura = fechadesde.ToString();
                    fechapertura = fechapertura.Substring(0, 10);

                    if (Convert.ToDateTime(dtfecha) == Convert.ToDateTime(fechapertura))
                    {
                        validaciones++;//VALIDA QUE LA FECHA DEL ASIENTO DE APERTURA SEA IGUAL QUE EL DESDE EL EJERCICIO.
                    }
                    else
                    {
                        MSGsErrores[5] = 1;
                    }
                }
            }

            bool asientorepetido = true;

            int resultado = AccesoBase.ValidarDatos($"SELECT ast_tipo FROM Asiento WHERE ast_tipo = {cbTipoAsiento.SelectedValue}");
            if (resultado == 1)
            {
                if (Convert.ToInt32(cbTipoAsiento.SelectedValue) == 4)
                {
                    asientorepetido = false; //VALIDA QUE SI YA HAY UN ASIENTO DE CIERRE NO LO DEJA CONTINUAR.
                    MSGsErrores[6] = 1;
                }
                else if (Convert.ToInt32(cbTipoAsiento.SelectedValue) == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ya hay un asiento del tipo (apertura), ¿Desea Continuar?", false, true);
                    MessageBox.ShowDialog();
                    if (frmMessageBox.Cancelo)
                    {
                        asientorepetido = false; //VALIDA QUE SI YA HAY UN ASIENTO DE APERTURA PREGUNTE SI DESEA CONTINUAR.
                    }
                }
            }
            // 

            if (validaciones == 4 || validaciones == 5 && asientorepetido)
            {
                if (add_mod_vis == 1)
                {
                    string asiento_renumera = Negocio.FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();
                   
                    AccesoBase.InsertUpdateDatos($"INSERT INTO Asiento(ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo) VALUES('{asiento_renumera}','{asiento_renumera}','{Convert.ToDateTime(maskFecha.Text).ToString()}','{txtComentario.Text}','{FLogin.IdUsuario}','{hora}','{txtCodEjercicio.Text}','{fecha}','{cbTipoAsiento.SelectedValue}')");
                    
                    DataSet ds = new DataSet();
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int cuenta = Convert.ToInt32(dr["mva_cuenta"]);
                        double debe = Convert.ToDouble(dr["mva_debe"]);
                        double haber = Convert.ToDouble(dr["mva_haber"]);
                        string concepto = dr["mva_concepto"].ToString();
                        int asiento = Convert.ToInt32(dr["mva_Asiento"]);
                        string cc = dr["mva_cc"].ToString();

                        if (cc != "0")
                        {
                            Convert.ToInt32(cc);
                        }

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

                        string query;
                        if (cc == "0")
                        {
                            query = $"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{DateTime.Now.ToShortDateString()}',{cuenta},{codigo},{"*"},'{concepto}',null)";
                        }
                        else
                        {
                            query = $"INSERT INTO MovAsto(mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc) VALUES({asiento},'{DateTime.Now.ToShortDateString()}',{cuenta},{codigo},{"*"},'{concepto}',{cc})";
                        }
                        AccesoBase.InsertUpdateDatosMoney(query, money);
                    }

                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente!", false);
                    MessageBox.ShowDialog();

                    AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto WHERE mva_terminal = {terminal}");

                    this.Close();
                }
                else if (add_mod_vis == 2)
                {
                    //MODIFICÁ TABLA MOVASTO
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Seguro que Desea Continuar?", true);
                    MessageBox.ShowDialog();
                    if (frmMessageBox.Acepto)
                    {
                        DataSet ds = new DataSet();
                        ds = AccesoBase.ListarDatos($"SELECT mva_asiento, mva_cuenta, mva_debe, mva_haber, mva_concepto, mva_cc FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                        int asiento = Convert.ToInt32(ds.Tables[0].Rows[0]["mva_asiento"]);

                        AccesoBase.InsertUpdateDatos($"DELETE MovAsto WHERE mva_asiento = {asiento}");

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
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
                            string fechasiento = ds2.Tables[0].Rows[0]["ast_fecha"].ToString();

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
                if (MSGsErrores[0] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe agregar un detalle", false);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[1] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El asiento debe estar balanceado", false);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[2] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe agregar un comentario", false);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[3] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La fecha ingresada no concuerda con los parametros del ejercicio", false, true);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[4] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La fecha de cierre no concuerda con la del ejercicio", false, true);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[5] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La fecha de apertura no concuerda con la del ejercicio", false, true);
                    MessageBox.ShowDialog();
                }
                else if (MSGsErrores[6] == 1)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ya hay un asiento del tipo (Cierre)", false);
                    MessageBox.ShowDialog();
                }
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("mod_codigo as Código, mod_descri as Descripción", "ModeloEncab", "", "ORDER BY mod_codigo", "mod", "codigo", "descri");
            frm.ShowDialog();

            string codigoCG = frmConsultaGeneral.codigoCG;
            if (codigoCG != null)
            {
                string asiento = txtNroAsiento.Text;
                if (asiento == "ALTA EN CONCEPTO")
                {
                    asiento = Negocio.FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();
                }

                autoincremental2 = 1;

                AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto WHERE mva_terminal = {terminal}");

                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT det_asiento, det_fecha, det_cuenta, det_codigo, det_importe, det_comenta, det_cc FROM ModeloDet WHERE det_asiento = {codigoCG}");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ds2 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = {Convert.ToInt32(dr["det_cuenta"])}");
                    string descri = ds2.Tables[0].Rows[0]["pcu_descri"].ToString();
                    if (Convert.ToInt32(dr["det_codigo"]) == 1)
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MovAsto (mva_terminal,mva_cuenta,mva_descri,mva_debe,mva_haber,mva_concepto,mva_cod,mva_asiento,mva_cc) VALUES ({terminal},{dr["det_cuenta"]},'{descri}','{dr["det_importe"]}',{"0"},'{dr["det_comenta"]}',{autoincremental2},{asiento},{dr["det_cc"]})");
                    }
                    else
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MovAsto (mva_terminal,mva_cuenta,mva_descri,mva_debe,mva_haber,mva_concepto,mva_cod,mva_asiento,mva_cc) VALUES ({terminal},{dr["det_cuenta"]},'{descri}',{"0"},'{dr["det_importe"]}','{dr["det_comenta"]}',{autoincremental2},{asiento},{dr["det_cc"]})");
                    }
                    autoincremental2++;
                }
                CargarDGV(asiento.ToString());
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Al hacer Click el Sistema rellenara la Grilla con los datos necesarios para Confeccionar un asiento de Cierre o Apertura, se sobreescribiran los datos que actualmente existan. ¿Desea Continuar?", true, true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                Cursor.Current = Cursors.WaitCursor;

                int resultado = AccesoBase.ValidarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {txtCodEjercicio.Text} AND ast_tipo = {cbTipoAsiento.SelectedValue}");
                if (resultado == 1)
                {
                    frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: El asiento de tipo " + cbTipoAsiento.Text + " ya ha sido registrado para este ejercicio", false, true);
                    MessageBox2.ShowDialog();
                    return;
                }

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: El ejercicio no Existe", false);
                    MessageBox3.ShowDialog();
                    return;
                }

                string desde = ds.Tables[0].Rows[0]["eje_desde"].ToString();
                string hasta = ds.Tables[0].Rows[0]["eje_hasta"].ToString();

                int codautonum = 0;

                if (cbTipoAsiento.SelectedIndex == 3) //cierre
                {
                    DataSet ds2 = new DataSet();
                    ds2 = AccesoBase.ListarDatos($"SELECT mva_cuenta, pcu_descri as mva_descri, " +
                        $"Sum(Case When mva_codigo = 1 Then mva_importe Else 0 End) as mva_debe, " +
                        $"Sum(Case When mva_codigo = 2 Then mva_importe Else 0 End) as mva_haber, " +
                        $"(Sum(Case When mva_codigo = 1 Then mva_importe Else 0 End) - Sum(Case When mva_codigo = 2 Then mva_importe Else 0 End))as mva_saldo " +
                        $"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                        $"WHERE ast_ejercicio = {txtCodEjercicio.Text} AND (ast_fecha >= '{desde}' AND ast_fecha <= '{hasta}') " +
                        $"GROUP BY mva_cuenta, pcu_codigo, pcu_descri HAVING (Sum(Case When mva_codigo = 1 Then mva_importe Else 0 End) - Sum(Case When mva_codigo = 2 Then mva_importe Else 0 End)) <> 0 " +
                        $"ORDER BY pcu_codigo");

                    AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MovAsto WHERE mva_terminal = {terminal}");

                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        DataSet ds3 = new DataSet();
                        ds3 = AccesoBase.ListarDatos($"SELECT max(mva_cod)as maximo FROM Aux_MovAsto WHERE mva_terminal = {terminal}");

                        if (ds3.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr3 in ds3.Tables[0].Rows)
                            {
                                codautonum++;
                            }
                        }

                        if (Convert.ToDecimal(dr2["mva_saldo"]) < 0)
                        {
                            AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_movasto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) " +
                            $"VALUES ({terminal}, {Convert.ToInt32(dr2["mva_cuenta"])}, '{dr2["mva_descri"].ToString()}', *, 0, '', {codautonum}, 0, 0 )", Math.Abs(Convert.ToDecimal(dr2["mva_saldo"])).ToString());
                        }
                        else
                        {
                            AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_movasto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) " +
                            $"VALUES ({terminal}, {Convert.ToInt32(dr2["mva_cuenta"])}, '{dr2["mva_descri"].ToString()}', 0, * , '', {codautonum}, 0, 0 )", Math.Abs(Convert.ToDecimal(dr2["mva_saldo"])).ToString());
                        }
                    }

                    Cursor.Current = Cursors.Default;
                }
                else //apertura
                {
                    DataSet ds2 = new DataSet();
                    ds2 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_hasta < '{desde}' ORDER BY eje_hasta desc");
                    if (ds2.Tables[0].Rows.Count == 0)
                    {
                        frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: No se ha encontrado un Ejercicio Anterior", false);
                        MessageBox3.ShowDialog();
                        return;
                    }

                    int ejercicio = Convert.ToInt32(ds2.Tables[0].Rows[0]["eje_codigo"]);

                    DataSet ds3 = new DataSet();
                    ds3 = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 4 AND ast_ejercicio = {ejercicio}");
                    if (ds3.Tables[0].Rows.Count == 0)
                    {
                        frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: No se ha encontrado el Asientos de Cierre para el Ejercicio " + ejercicio.ToString(), false, true);
                        MessageBox3.ShowDialog();
                        return;
                    }

                    int asiento = Convert.ToInt32(ds3.Tables[0].Rows[0]["ast_asiento"]);

                    frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: ¿Confimar la Generación del Asiento de apertura Para el Ejercicio Contable " + txtCodEjercicio.Text + " , Basado en el Asiento de Cierre Nº " + asiento + " del Ejercicio anterior Nº " + ejercicio, true, true);
                    MessageBox2.ShowDialog();
                    if (frmMessageBox.Acepto)
                    {
                        AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MovAsto WHERE mva_terminal = {terminal}");

                        codautonum = 0;

                        DataSet ds4 = new DataSet();
                        ds4 = AccesoBase.ListarDatos($"SELECT * FROM MovAsto LEFT JOIN PCuenta on mva_cuenta = pcu_cuenta WHERE mva_asiento = {asiento} ORDER BY mva_codigo desc, mva_cuenta");
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            codautonum = codautonum + 1;

                            if (Convert.ToDecimal(dr4["mva_codigo"]) != 1)
                            {
                                AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_movasto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) " +
                                $"VALUES ({terminal}, {Convert.ToInt32(dr4["mva_cuenta"])}, '{dr4["pcu_Descri"].ToString()}', *, 0, '', {codautonum}, 0, 0)", Math.Abs(Convert.ToDecimal(dr4["mva_importe"])).ToString());
                            }
                            else
                            {
                                AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_movasto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) " +
                                $"VALUES ({terminal}, {Convert.ToInt32(dr4["mva_cuenta"])}, '{dr4["pcu_Descri"].ToString()}', 0, *, '', {codautonum}, 0, 0)", Math.Abs(Convert.ToDecimal(dr4["mva_importe"])).ToString());
                            }
                        }
                    }
                }
                CargarDGV("0");
            }
        }

        private void dgvAddModVisASIENTO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAddModVisASIENTO.Columns[e.ColumnIndex].Name == "ColumnDebe" || dgvAddModVisASIENTO.Columns[e.ColumnIndex].Name == "ColumnHaber" && e.Value != null && e.Value != "")
            {
                double numero = Convert.ToDouble(e.Value);
                e.Value = numero.ToString("0.00");
                e.FormattingApplied = true;
            }
        }

        private void cbTipoAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoAsiento.SelectedIndex == 3)
            {
                btnGenerar.Enabled = true;
            }
            else if (cbTipoAsiento.SelectedIndex == 0)
            {
                btnGenerar.Enabled = true;
            }
            else
            {
                btnGenerar.Enabled = false;
            }
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (add_mod_vis == 1)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Los datos que se encuentran en la grilla actualmente no se guardaran. ¿Desea Continuar?", true, true);
                MessageBox.ShowDialog();
            }
            else if (add_mod_vis == 2)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Las Modificaciones en la grilla no se guardaran. ¿Desea Continuar?", true, true);
                MessageBox.ShowDialog();
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                this.Close();
            }

            if (frmMessageBox.Acepto)
            {
                AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                this.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvAddModVisASIENTO.Rows.Count == 0)
            {
                return;
            }

            string NroAsiento = txtNroAsiento.Text;

            if (NroAsiento == "ALTA EN CONCEPTO")
            {
                NroAsiento = (Negocio.FGenerales.ultimoNumeroID("mva_asiento", "Aux_movAsto") - 1).ToString();
                if (NroAsiento == "0" && MODELO == false)
                {
                    return;
                }
            }

            string query = $"SELECT mva_cuenta, mva_descri, mva_haber, mva_debe, mva_concepto FROM Aux_MovAsto WHERE mva_asiento = {NroAsiento}";

            frmReporte freporte = new frmReporte("MovAsto", $"{query}", "", "Movimientos de Asiento", NroAsiento, Convert.ToDateTime(maskFecha.Text).ToString(), txtComentario.Text, txtDescriEjercicio.Text);
            freporte.ShowDialog();
        }

        //FOOTER
        private void SeteoFooter(DataGridView dgv1, DataGridView footer) //sincroniza las columnas del dgv con el footer
        {
            foreach (DataGridViewColumn Columna in dgv1.Columns)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Width = Columna.Width;
                footer.Columns.Add(col);
            }
        }
        private void ActualizarFooter()
        {
            double sumaDebe = 0;
            double sumaHaber = 0;

            foreach (DataGridViewRow fila in dgvAddModVisASIENTO.Rows)
            {
                if (fila.Cells["ColumnDebe"].Value != null)
                {
                    double valor = Convert.ToDouble(fila.Cells["ColumnDebe"].Value);
                    sumaDebe += valor;
                }
                if (fila.Cells["ColumnHaber"].Value != null)
                {
                    double valor = Convert.ToDouble(fila.Cells["ColumnHaber"].Value);
                    sumaHaber += valor;
                }
            }

            if (dgvAddModVisASIENTO.Rows.Count != 0)
            {
                footer.Columns[1].HeaderText = "Totales:";
                footer.Columns[2].HeaderText = sumaDebe == 0 ? "0,00" : Math.Round(sumaDebe, 2).ToString();
                footer.Columns[3].HeaderText = sumaHaber == 0 ? "0,00" : Math.Round(sumaHaber, 2).ToString();
            }
            else
            {
                footer.Columns[1].HeaderText = "Totales:";
                footer.Columns[2].HeaderText = "0,00";
                footer.Columns[3].HeaderText = "0,00";
            }
        }
        private void dgvAddModVisASIENTO_Scroll(object sender, ScrollEventArgs e) //sincroniza el scroll del dgv con el footer
        {
            if (dgvAddModVisASIENTO.HorizontalScrollingOffset == e.NewValue)
            {
                footer.HorizontalScrollingOffset = e.NewValue;
            }

            bool scrollVerticalActivo = dgvAddModVisASIENTO.DisplayedRowCount(false) < dgvAddModVisASIENTO.RowCount;
            if (scrollVerticalActivo)
            {
                if (dgvAddModVisASIENTO.Rows.Count != 0)
                {
                    if (Negocio.FGenerales.SincronizarFooter(dgvAddModVisASIENTO))
                    {
                        footer.Location = new Point(14, 238);
                    }
                    else
                    {
                        footer.Location = new Point(14, 431);
                    }
                }
            }
        }
        //

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
