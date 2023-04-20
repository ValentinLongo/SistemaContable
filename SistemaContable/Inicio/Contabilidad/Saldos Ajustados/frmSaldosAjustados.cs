﻿using Datos;
using Datos.Modelos;
using Microsoft.SqlServer.Server;
using Negocio;
using SistemaContable.General;
using SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Saldos_Ajustados
{
    public partial class frmSaldosAjustados : Form
    {
        int terminal = frmLogin.NumeroTerminal;

        public frmSaldosAjustados()
        {
            InitializeComponent();

            checkValoresdeAjuste.Checked = true;

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void frmSaldosAjustados_Load(object sender, EventArgs e)
        {
            bool Flag = false;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE IsNull(eje_cerrado,0) = 0");
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows.Count > 1)
                {
                    Flag = true;
                }
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio ORDER BY IsNull(eje_cerrado,0), eje_codigo");
            if (ds2.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que No Existen Ejercicios Contables Cargados.", false);
                MessageBox.ShowDialog();
                btnProcesar.Enabled = false;
            }
            else
            {
                btnProcesar.Enabled = true;

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.LimpiarDGVs(this, dgv1, dgv2, footer);

                SeteoFooter(dgv1, footer); // sincroniza el footer

                cbSeleccion.DataSource = ds2.Tables[0];
                cbSeleccion.DisplayMember = "eje_descri";

                if (Flag)
                {
                    cbSeleccion.SelectedIndex = -1;
                }
                else
                {
                    cbSeleccion.SelectedIndex = 0;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT * FROM CentroC ORDER BY cec_codigo");
                cbCC.Items.Add("TODOS");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    cbCC.Items.Add(dr3["cec_descri"]);
                }
                cbCC.SelectedIndex = 0;
            }
        }

        private void btnAsiento_Click(object sender, EventArgs e)
        {
            int ContraP = 0;
            string ContraPDescri = "";

            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM ParamContab LEFT JOIN PCuenta on par_ctaAjusteInf = pcu_cuenta");
            if (ds.Tables[0].Rows.Count == 0) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá definir los Parametros Contables", false);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            string descri = "";
            int hija = 0;
            int estado = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                descri = dr["pcu_descri"].ToString();
                hija = Convert.ToInt32(dr["pcu_hija"]);
                estado = Convert.ToInt32(dr["pcu_estado"]);

                ContraP = Convert.ToInt32(dr["par_ctaAjusteInf"]);
                ContraPDescri = dr["pcu_descri"].ToString();
            }

            if (descri == "") //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se ha definido la Cuenta para Ajuste por Inflación.", false, true);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            if (hija != 0) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros No puede Recibir Movimientos", false, true);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            if (estado != 1) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros ha sido Inhabilitada", false, true);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 3 AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")}");
            if (ds2.Tables[0].Rows.Count != 0) //Advertencia
            {
                frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que ya se ha Registrado al menos un Asiento de Ajuste por inflación, ¿Desea Continuar?", true, true);
                MessageBox1.ShowDialog();
                if (frmMessageBox.Acepto == false)
                {
                    Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                    return;
                }
            }

            DataSet ds3 = new DataSet();
            ds3 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} AND IsNull(aux_col13,0) <> 0 ORDER BY aux_codigo");
            if (ds3.Tables[0].Rows.Count == 0) //Validación
            {
                frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: No se han encontrado Datos para Generar el Asiento. Presione Procesar", false, true);
                MessageBox2.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: Al hacer click en esta opción, el Sistema Generara un Asiento Contable con los Datos Presentados en la Grilla, ¿Desea Continuar? ", true, true);
            MessageBox3.ShowDialog();
            if (frmMessageBox.Acepto == false) //Advertencia
            {
                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            //

            AccesoBase.InsertUpdateDatos($"DELETE FROM aux_MovAsto WHERE mva_terminal = {terminal}");

            int n = 0;
            int CA = 0; //Codigo Autoincremental
            int CC = 0; //Centro de Costo

            if (cbCC.Text != "TODOS")
            {
                CC = Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text, "CentroC", "cec");
            }

            foreach (DataRow dr3 in ds3.Tables[0].Rows)
            {
                DataSet ds4 = new DataSet();
                ds4 = AccesoBase.ListarDatos($"SELECT max(mva_cod) as maximo FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                foreach (DataRow dr4 in ds4.Tables[0].Rows)
                {
                    CA = dr4["maximo"] is DBNull ? 1 : Convert.ToInt32(dr4["maximo"]) + 1;
                }

                double money;

                if (dr3["aux_col13"] is null)
                {
                    money = 0;
                }
                else
                {
                    money = Convert.ToDouble(dr3["aux_col13"]);
                }

                if (money > 0)
                {
                    money = Math.Abs(money);
                    AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {dr3["aux_codigo"]}, '{dr3["pcu_descri"]}', {"*"}, 0, '', {CA}, 0, {CC})", money.ToString());
                }
                else
                {
                    money = Math.Abs(money);
                    AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {dr3["aux_codigo"]}, '{dr3["pcu_descri"]}', 0, {"*"}, '', {CA}, 0, {CC})", money.ToString());
                }
            }

            DataSet ds5 = new DataSet();
            ds5 = AccesoBase.ListarDatos($"SELECT max(mva_cod) as maximo FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
            foreach (DataRow dr5 in ds5.Tables[0].Rows)
            {
                CA = dr5["maximo"] is DBNull ? 1 : Convert.ToInt32(dr5["maximo"]) + 1;
            }

            double dif = 0;

            DataSet ds6 = new DataSet();
            ds6 = AccesoBase.ListarDatos($"SELECT (sum(mva_debe) - sum(mva_haber)) as Diferencia FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
            foreach (DataRow dr6 in ds6.Tables[0].Rows)
            {
                if (ds6.Tables[0].Rows.Count == 0)
                {
                    dif = 0;
                }
                else
                {
                    dif = Convert.ToDouble(dr6["Diferencia"]);
                }
            }

            if (dif < 0)
            {
                dif = Math.Abs(dif);
                AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto (mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {ContraP}, '{ContraPDescri}', {"*"}, 0, '', {CA}, 0, 0)", dif.ToString());
            }
            else
            {
                dif = Math.Abs(dif);
                AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto (mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {ContraP}, '{ContraPDescri}', 0, {"*"}, '', {CA}, 0, 0)", dif.ToString());
            }

            DataSet ds7 = new DataSet();
            ds7 = AccesoBase.ListarDatos($"SELECT * FROM Aux_MovAsto WHERE mva_terminal = {terminal} ORDER BY mva_haber, mva_debe, mva_cuenta ");

            CA = 1;

            foreach (DataRow dr7 in ds7.Tables[0].Rows)
            {
                CA = CA + 1;

                AccesoBase.InsertUpdateDatos($"UPDATE Aux_MovAsto SET mva_cod = {CA} WHERE mva_terminal = {terminal} AND mva_cod = {dr7["mva_cod"]}");
            }

            DataSet ds8 = new DataSet();
            ds8 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")}");
            string hasta = "";
            foreach (DataRow dr8 in ds8.Tables[0].Rows)
            {
                hasta = dr8["eje_hasta"].ToString();
            }

            MAsiento modelo = new MAsiento()
            {
                ast_nroEjer = Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje"),
                ast_descriEjer = cbSeleccion.Text,
                ast_fecha = hasta,
                ast_cbTipoAsientoIndex = 2,
                ast_cbTipoAsiento = false,
                ast_btnGenerar = false,
                ast_btnModelo = false,
                ast_btnPlanDeCuenta = false,
            };

            frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(1, null, null, null, null, modelo);
            frm.ShowDialog();

            CargarDGV();
            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.Text == "") //validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá Seleccionar un Ejercicio antes de Procesar", false);
                MessageBox.ShowDialog();

                return;
            }

            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM DetAjusteInf WHERE aji_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} ORDER BY (RIGHT(aji_periodo,4) + LEFT(aji_periodo,2))");           
            if (ds.Tables[0].Rows.Count == 0) //validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se ha definido un coeficiente para  el Ejercicio Seleccionado", false, true);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            int n = 3;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dgv1.Columns[n].HeaderText = dr["aji_periodo"].ToString();
                n = n + 1;
            }
            dgv1.Columns["Acumulado"].HeaderText = "Acumulado";


            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE IsNull(pcu_ajustainf, 0) = 1");
            if (ds2.Tables[0].Rows.Count == 0) //validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se han Definido las Cuentas Contables que van a ser incluidas en este informe.", false, true);
                MessageBox.ShowDialog();

                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                return;
            }

            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio2 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio3 WHERE aux_terminal = {terminal}");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_PromMesAnio1 (aux_terminal, aux_codigo,  aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, aux_col14, aux_col15, aux_col16, aux_col17, aux_col18, aux_col19, aux_col20, aux_col21, aux_col22, aux_col23, aux_col24, aux_col25, aux_col26, aux_col27, aux_col28, aux_col29, aux_col30, aux_col31, aux_col32, aux_col33, aux_col34, aux_col35, aux_col36, aux_col37, aux_col38, aux_col39, aux_col40) " +
            $"SELECT {terminal}, pcu_cuenta, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 FROM PCuenta WHERE IsNull(pcu_ajustainf, 0) = 1");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_PromMesAnio2 (aux_terminal, aux_codigo,  aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, aux_col14, aux_col15, aux_col16, aux_col17, aux_col18, aux_col19, aux_col20, aux_col21, aux_col22, aux_col23, aux_col24, aux_col25, aux_col26, aux_col27, aux_col28, aux_col29, aux_col30, aux_col31, aux_col32, aux_col33, aux_col34, aux_col35, aux_col36, aux_col37, aux_col38, aux_col39, aux_col40) " +
            $"SELECT {terminal}, pcu_cuenta, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 FROM PCuenta WHERE IsNull(pcu_ajustainf, 0) = 1");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_PromMesAnio3 (aux_terminal, aux_codigo,  aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, aux_col14, aux_col15, aux_col16, aux_col17, aux_col18, aux_col19, aux_col20, aux_col21, aux_col22, aux_col23, aux_col24, aux_col25, aux_col26, aux_col27, aux_col28, aux_col29, aux_col30, aux_col31, aux_col32, aux_col33, aux_col34, aux_col35, aux_col36, aux_col37, aux_col38, aux_col39, aux_col40) " +
            $"SELECT {terminal}, pcu_cuenta, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 FROM PCuenta WHERE IsNull(pcu_ajustainf, 0) = 1");

            string CC = ""; //Centro de Costo
            bool Ctrl;

            if (cbCC.Text == "TODOS")
            {
                CC = "";
                Ctrl = false;
            }
            else
            {
                CC = " AND mva_cc = " + Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text, "CentroC", "cec");
                Ctrl = true;
            }

            if (Ctrl)
            {
                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT * FROM MovAsto LEFT JOIN Aux_PromMesAnio1 on aux_codigo = mva_cuenta AND aux_terminal = {terminal} " +
                $"LEFT JOIN Asiento on mva_asiento = ast_asiento WHERE aux_terminal = {terminal} AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} AND IsNull(mva_cc,0) = 0");
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que Existen movimientos asociados a las Cuentas Contables incluidas en este informe, que No poseen un Centro de Costo Asociado", false, true);
                    MessageBox.ShowDialog();
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            int X = 1;
            double coeficiente = 0;
            double SCA = 0; // Saldo Con Ajuste
            double SSA = 0; // Saldo Sin Ajuste
            double ajuste = 0;

            for (n = 3; n < dgv1.Columns.Count; n++)
            {
                if (dgv1.Columns[n].HeaderText != "")
                {
                    DataSet ds4 = new DataSet();
                    ds4 = AccesoBase.ListarDatos($"SELECT * FROM DetAjusteInf WHERE aji_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} AND aji_periodo = '{dgv1.Columns[n].HeaderText}'");
                    if (ds4.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            coeficiente = Convert.ToDouble(dr4["aji_coef"]);
                        }

                        DataSet ds5 = new DataSet();
                        ds5 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            DataSet ds6 = new DataSet();
                            ds6 = AccesoBase.ListarDatos($"SELECT (sum(case when mva_codigo = 1 then mva_importe else 0 end) - sum(case when mva_codigo = 2 then mva_importe else 0 end)) as mva_saldo " +
                            $"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                            $"WHERE ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} AND mva_cuenta = {dr5["aux_codigo"]} " +
                            $"AND (MONTH(ast_fecha) = '{dgv1.Columns[n].HeaderText.Substring(0, 2)}' AND YEAR(ast_fecha) = '{dgv1.Columns[n].HeaderText.Substring(dgv1.Columns[n].HeaderText.Length - 4)}') {CC}");
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                SCA = Math.Round((dr6["mva_saldo"] is DBNull ? 0 : Convert.ToDouble(dr6["mva_saldo"]) * coeficiente),2);
                                SSA = Math.Round((dr6["mva_saldo"] is DBNull ? 0 : Convert.ToDouble(dr6["mva_saldo"])),2);
                                ajuste = SCA - SSA;
                                break;
                            }

                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_PromMesAnio1 SET aux_col{X} = {"*"} WHERE aux_terminal = {terminal} AND aux_codigo = {dr5["aux_codigo"]}", ajuste.ToString());
                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_PromMesAnio2 SET aux_col{X} = {"*"} WHERE aux_terminal = {terminal} AND aux_codigo = {dr5["aux_codigo"]}", SCA.ToString());
                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_PromMesAnio3 SET aux_col{X} = {"*"} WHERE aux_terminal = {terminal} AND aux_codigo = {dr5["aux_codigo"]}", SSA.ToString());
                        }
                        X = X + 1;
                    }
                }
            }

            if (Ctrl)
            {
                AccesoBase.InsertUpdateDatos($"DELETE Aux_PromMesAnio1 FROM Aux_PromMesAnio1 LEFT JOIN (MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento) on aux_codigo = mva_cuenta AND IsNull(mva_cc,0) = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text, "CentroC", "cec")} AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} WHERE mva_asiento is null");
                AccesoBase.InsertUpdateDatos($"DELETE Aux_PromMesAnio2 FROM Aux_PromMesAnio2 LEFT JOIN (MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento) on aux_codigo = mva_cuenta AND IsNull(mva_cc,0) = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text, "CentroC", "cec")} AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} WHERE mva_asiento is null");
                AccesoBase.InsertUpdateDatos($"DELETE Aux_PromMesAnio3 FROM Aux_PromMesAnio3 LEFT JOIN (MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento) on aux_codigo = mva_cuenta AND IsNull(mva_cc,0) = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text, "CentroC", "cec")} AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} WHERE mva_asiento is null");
            }

            AccesoBase.InsertUpdateDatos($"UPDATE Aux_PromMesAnio1 SET aux_col13 = IsNull(aux_col1, 0) + IsNull(aux_col2, 0) + IsNull(aux_col3, 0) + IsNull(aux_col4, 0) + IsNull(aux_col5, 0) + IsNull(aux_col6, 0) + IsNull(aux_col7, 0) + IsNull(aux_col8, 0) + IsNull(aux_col9, 0) + IsNull(aux_col10, 0) + IsNull(aux_col11, 0) + IsNull(aux_col12, 0) WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"UPDATE Aux_PromMesAnio2 SET aux_col13 = IsNull(aux_col1, 0) + IsNull(aux_col2, 0) + IsNull(aux_col3, 0) + IsNull(aux_col4, 0) + IsNull(aux_col5, 0) + IsNull(aux_col6, 0) + IsNull(aux_col7, 0) + IsNull(aux_col8, 0) + IsNull(aux_col9, 0) + IsNull(aux_col10, 0) + IsNull(aux_col11, 0) + IsNull(aux_col12, 0) WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"UPDATE Aux_PromMesAnio3 SET aux_col13 = IsNull(aux_col1, 0) + IsNull(aux_col2, 0) + IsNull(aux_col3, 0) + IsNull(aux_col4, 0) + IsNull(aux_col5, 0) + IsNull(aux_col6, 0) + IsNull(aux_col7, 0) + IsNull(aux_col8, 0) + IsNull(aux_col9, 0) + IsNull(aux_col10, 0) + IsNull(aux_col11, 0) + IsNull(aux_col12, 0) WHERE aux_terminal = {terminal}");

            CargarDGV();
            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
            Cursor.Current = Cursors.Default;
        }

        private void CargarDGV()
        {
            if (cbSeleccion.Text != "")
            {
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                if (checkValoresdeAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal}");


                    ds2 = AccesoBase.ListarDatos($"SELECT aux_codigo, aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, pcu_descri, pcu_centroC FROM Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }
                else if (checkSaldosConAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio2 WHERE aux_terminal = {terminal}");

                    ds2 = AccesoBase.ListarDatos($"SELECT aux_codigo, aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, pcu_descri, pcu_centroC FROM Aux_PromMesAnio2 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }
                else if (checkSaldosSinAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio3 WHERE aux_terminal = {terminal}");

                    ds2 = AccesoBase.ListarDatos($"SELECT aux_codigo, aux_col1, aux_col2, aux_col3, aux_col4, aux_col5, aux_col6, aux_col7, aux_col8, aux_col9, aux_col10, aux_col11, aux_col12, aux_col13, pcu_descri, pcu_centroC FROM Aux_PromMesAnio3 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }

                foreach (DataRow dr in ds.Tables[0].Rows) // asigno los total al footer
                {
                    footer.Columns[2].HeaderText = "Totales";
                    footer.Columns[3].HeaderText = dr["Col1"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col1"]),2).ToString();
                    footer.Columns[4].HeaderText = dr["Col2"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col2"]), 2).ToString();
                    footer.Columns[5].HeaderText = dr["Col3"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col3"]),2).ToString();
                    footer.Columns[6].HeaderText = dr["Col4"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col4"]),2).ToString();
                    footer.Columns[7].HeaderText = dr["Col5"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col5"]),2).ToString();
                    footer.Columns[8].HeaderText = dr["Col6"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col6"]),2).ToString();
                    footer.Columns[9].HeaderText = dr["Col7"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col7"]),2).ToString();
                    footer.Columns[10].HeaderText = dr["Col8"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col8"]),2).ToString();
                    footer.Columns[11].HeaderText = dr["Col9"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col9"]),2).ToString();
                    footer.Columns[12].HeaderText = dr["Col10"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col10"]),2).ToString();
                    footer.Columns[13].HeaderText = dr["Col11"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col11"]),2).ToString();
                    footer.Columns[14].HeaderText = dr["Col12"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col12"]),2).ToString();
                    footer.Columns[15].HeaderText = dr["Col13"] is DBNull ? "0" : Math.Round(Convert.ToDouble(dr["Col13"]),2).ToString();
                }

                dgv1.DataSource = ds2.Tables[0];

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT aji_periodo, aji_coef FROM DetAjusteInf WHERE aji_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje")} ORDER BY (RIGHT(aji_periodo,4) + LEFT(aji_periodo,2)) ");

                dgv2.DataSource = ds3.Tables[0];
            }
        }

        private void cbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio2 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio3 WHERE aux_terminal = {terminal}");

            if (Negocio.Funciones.Contabilidad.FSaldosAjsutados.LimpiarDGVs(this, dgv1, dgv2, footer)) 
            {
                this.Close();
                frmSaldosAjustados frm = new frmSaldosAjustados();
                frm.Show();
            }
        }

        private void cbCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio2 WHERE aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_PromMesAnio3 WHERE aux_terminal = {terminal}");

            if (Negocio.Funciones.Contabilidad.FSaldosAjsutados.LimpiarDGVs(this, dgv1, dgv2, footer))
            {
                this.Close();
                frmSaldosAjustados frm = new frmSaldosAjustados();
                frm.Show();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string reporte = "";
            string query = "";

            if (checkValoresdeAjuste.Checked)
            {
                reporte = "Valores de Ajuste";
                query = $"SELECT * FROM Aux_PromMesAnio1 as Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo";
            }
            else if (checkSaldosConAjuste.Checked)
            {
                reporte = "Saldos con Ajuste";
                query = $"SELECT * FROM Aux_PromMesAnio2 as Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo";
            }
            else if (checkSaldosSinAjuste.Checked)
            {
                reporte = "Saldos sin Ajuste";
                query = $"SELECT * FROM Aux_PromMesAnio3 as Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo";
            }

            //(cambiar valores)
            frmReporte freporte = new frmReporte("SaldosAjustados", $"{query}", "", "Usuarios del Sistema", "Activos", DateTime.Now.ToString("d"));
            freporte.ShowDialog();
        }

        private void checkVDA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkValoresDeAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false) //para que funsione como un radiobutton
            {
                checkValoresdeAjuste.Checked = true;
            }
            if (checkValoresdeAjuste.Checked) //para que solo pueda marcar una opción
            {
                btnAsiento.Enabled = true;

                checkSaldosConAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                CargarDGV();
            }
        }

        private void checkSCA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosConAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false) //para que funsione como un radiobutton
            {
                checkSaldosConAjuste.Checked = true;
            }
            if (checkSaldosConAjuste.Checked) //para que solo pueda marcar una opción
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                CargarDGV();
            }
        }

        private void checkSSA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosSinAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false) //para que funsione como un radiobutton
            {
                checkSaldosSinAjuste.Checked = true;
            }
            if (checkSaldosSinAjuste.Checked) //para que solo pueda marcar una opción
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosConAjuste.Checked = false;

                CargarDGV();
            }
        }

        //FOOTER
        private void SeteoFooter(DataGridView dgv1, DataGridView footer)
        {
            foreach (DataGridViewColumn Columna in dgv1.Columns)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Width = Columna.Width;
                footer.Columns.Add(col);
            }
        }

        private void dgv1_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgv1.HorizontalScrollingOffset == e.NewValue)
            {
                footer.HorizontalScrollingOffset = e.NewValue;
            }

            if (dgv1.Rows.Count != 0)
            {
                if (Negocio.FGenerales.SincronizarFooter(dgv1))
                {
                    footer.Location = new Point(9, 140);
                }
                else
                {
                    footer.Location = new Point(9, 470);
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
