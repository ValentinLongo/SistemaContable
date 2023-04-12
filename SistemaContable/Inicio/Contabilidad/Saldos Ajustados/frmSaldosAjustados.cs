using Datos;
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

namespace SistemaContable.Inicio.Contabilidad.Saldos_Ajustados
{
    public partial class frmSaldosAjustados : Form
    {
        int terminal = frmLogin.NumeroTerminal;
        int Posicion;

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
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que No Existen Ejercicio Contables Cargados.", false);
                MessageBox.ShowDialog();
                btnProcesar.Enabled = false;
            }
            else
            {
                btnProcesar.Enabled = true;

                cbSeleccion.DataSource = ds2.Tables[0];
                cbSeleccion.DisplayMember = "eje_descri";
                //cbSeleccion.ValueMember = "";

                if (Flag == false)
                {
                    cbSeleccion.SelectedIndex = 0;
                }
                else
                {
                    cbSeleccion.SelectedIndex = -1;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT * FROM CentroC ORDER BY cec_codigo");
                cbCC.Items.Add("TODOS");
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    cbCC.Items.Add(dr3["cec_descri"]);
                    //cbCC.ValueMember = "";
                }
                cbCC.SelectedIndex = 0;

                //(Parte de codigo que creo que es irrelevante) "por posible error"
            }
        }

        private void btnAsiento_Click(object sender, EventArgs e)
        {
            int ContraP = 0;
            string ContraPDescri = "";

            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM ParamContab LEFT JOIN PCuenta on par_cta_AjusteInf = pcu_cuenta");
            if (ds.Tables[0].Rows.Count == 0) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá definir los Parametros Contables", false);
                MessageBox.ShowDialog();
                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
            }
            else
            {
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
                }
                else
                {
                    if (hija != 0) //Validación
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros No puede Recibir Movimientos", false, true);
                        MessageBox.ShowDialog();
                        Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                    }
                    else
                    {
                        if (estado != 1) //Validación
                        {
                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros ha sido Inhabilitada", false, true);
                            MessageBox.ShowDialog();
                            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                        }
                        else
                        {
                            int advertencias = 0;

                            //Advertencias
                            DataSet ds2 = new DataSet();
                            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 3 AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text,"Ejercicio","eje")}");
                            if (ds2.Tables[0].Rows.Count != 0)
                            {
                                frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que ya se ha Registrado al menos un Asiento de Ajuste por inflación, ¿Desea Continuar?", true, true);
                                MessageBox1.ShowDialog();
                                if (frmMessageBox.Acepto)
                                {
                                    advertencias++;
                                }
                            }


                            DataSet ds3 = new DataSet();
                            ds3 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal {terminal} AND IsNull(aux_col13,0) <> 0 ORDER BY aux_codigo");
                            if (advertencias == 1)
                            {
                                if (ds3.Tables[0].Rows.Count == 0)
                                {
                                    frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: No se han encontrado Datos para Generar el Asiento. Presione Procesar", false, true);
                                    MessageBox2.ShowDialog();
                                }
                                else
                                {
                                    advertencias++;
                                }
                            }

                            if (advertencias == 2)
                            {
                                frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: Al hacer click en esta opción, el Sistema Generara un Asiento Contable con los Datos Presentados en la Grilla, ¿Desea Continuar? ", true, true);
                                MessageBox3.ShowDialog();
                                if (frmMessageBox.Acepto)
                                {
                                    advertencias++;
                                }
                            }
                            //

                            if (advertencias == 3)
                            {
                                AccesoBase.InsertUpdateDatos($"DELETE FROM aux_MovAsto WHERE mva_terminal = {terminal}");

                                int n = 0;
                                int CA = 0; //Codigo Autoincremental
                                int CC = 0; //Centro de Costo

                                if (cbCC.Text != "TODOS")
                                {
                                    CC = Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text,"CentroC","cec");
                                }

                                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                {
                                    DataSet ds4 = new DataSet();
                                    ds4 = AccesoBase.ListarDatos($"SELECT max(mva_cod) as maximo FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                                    {
                                        CA = dr4["maximo"] is null ? 1 : Convert.ToInt32(dr4["maximo"]) + 1;
                                    }

                                    double money;

                                    if (dr3["aux_col13"] is null)
                                    {
                                        money = 0;
                                    }
                                    else
                                    {
                                        money = Math.Abs(Convert.ToDouble(dr3["aux_col13"]));
                                    }

                                    if (Convert.ToInt32(dr3["aux_col13"].ToString() == "" ? "0" : dr3["aux_col13"].ToString()) > 0)
                                    {
                                        AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {dr3["aux_codigo"]}, '{dr3["pcu_descri"]}', {"*"}, 0, '', {CA}, 0, {CC})", money.ToString());
                                    }
                                    else
                                    {
                                        AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {dr3["aux_codigo"]}, '{dr3["pcu_descri"]}', 0, {"*"}, '', {CA}, 0, {CC})", money.ToString());
                                    }
                                }

                                DataSet ds5 = new DataSet();
                                ds5 = AccesoBase.ListarDatos($"SELECT max(mva_cod) as maximo FROM Aux_MovAsto WHERE mva_terminal = {terminal}");
                                foreach (DataRow dr5 in ds5.Tables[0].Rows)
                                {
                                    CA = dr5["maximo"] is null ? 1 : Convert.ToInt32(dr5["maximo"]) + 1;
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
                                        dif = Math.Abs(Convert.ToDouble(dr6["Diferencia"]));
                                    }
                                }

                                if (dif < 0)
                                {
                                    AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto (mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {ContraP}, '{ContraPDescri}', {"*"}, 0, '', {CA}, 0, 0)", dif.ToString() );
                                }
                                else
                                {
                                    AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Aux_MovAsto (mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES ({terminal}, {ContraP}, '{ContraPDescri}', 0, {"*"}, '', {CA}, 0, 0)", dif.ToString() );
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

                                //terminar
                            }
                            else
                            {
                                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                            }
                        }
                    }
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.Text == "")
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá Seleccionar un para Procesar", false);
                MessageBox.ShowDialog();
            }
            else
            {
                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

                //terminar
            }

        }

        private void Actualizar() 
        {
            if (cbSeleccion.Text != "")
            {
                //Cursor.Current = Cursors.WaitCursor;
                //Application.DoEvents();

                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();

                if (checkValoresdeAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio1 WHERE aux_terminal = {terminal}");

                    ds2 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }
                else if (checkSaldosConAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio2 WHERE aux_terminal = {terminal}");

                    ds2 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio2 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }
                else if (checkSaldosSinAjuste.Checked)
                {
                    ds = AccesoBase.ListarDatos($"SELECT sum(aux_col1) as Col1, sum(aux_col2) as Col2, sum(aux_col3) as Col3, sum(aux_col4) as Col4, sum(aux_col5) as Col5, sum(aux_col6) as Col6, sum(aux_col7) as Col7, sum(aux_col8) as Col8, sum(aux_col9) as Col9, sum(aux_col10) as Col10, sum(aux_col11) as Col11, sum(aux_col12) as Col12, sum(aux_col13) as Col13 FROM Aux_PromMesAnio3 WHERE aux_terminal = {terminal}");

                    ds2 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio3 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal = {terminal} ORDER BY aux_codigo");
                }

                //terminar

                //Cursor.Current = Cursors.Default;
            }
        }

        private void cbSeleccion_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void cbCC_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void checkVDA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkValoresDeAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false)
            {
                checkValoresdeAjuste.Checked = true;
            }
            if (checkValoresdeAjuste.Checked)
            {
                btnAsiento.Enabled = true;

                checkSaldosConAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                Actualizar();
            }
        }

        private void checkSCA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosConAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false)
            {
                checkSaldosConAjuste.Checked = true;
            }
            if (checkSaldosConAjuste.Checked)
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                Actualizar();
            }
        }

        private void checkSSA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosSinAjuste
        {
            if (checkValoresdeAjuste.Checked == false && checkSaldosConAjuste.Checked == false && checkSaldosSinAjuste.Checked == false)
            {
                checkSaldosSinAjuste.Checked = true;
            }
            if (checkSaldosSinAjuste.Checked)
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosConAjuste.Checked = false;

                Actualizar();
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
