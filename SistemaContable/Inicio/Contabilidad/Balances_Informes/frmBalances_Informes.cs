using Datos;
using Negocio;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace SistemaContable.Inicio.Contabilidad.Balance_de_Sumas_y_Saldos
{
    public partial class frmBalances_Informes : Form
    {
        private static int Proceso;

        public frmBalances_Informes(int proceso)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo(proceso);
            Proceso = proceso;
        }

        private void Seteo(int proceso) // Seteo porque hay 3 frm en 1
        {
            maskDesde.Mask = "00-00-0000";
            maskHasta.Mask = "00-00-0000";
            maskHasta.Text = DateTime.Now.ToShortDateString();

            if (proceso == 1) //Balance de Sumas y Saldos
            {
                Check1.Visible = true;
                lbl1.Visible = true;

                Check2.Visible = true;
                lbl2.Visible = true;

                Check4.Visible = true;
                lbl4.Visible = true;
            }
            else if (proceso == 2) //Balance General
            {
                Check1.Visible = true;
                lbl1.Visible = true;

                Check2.Visible = true;
                lbl2.Visible = true;

                Check4.Visible = true;
                lbl4.Visible = true;
            }
            else if (proceso == 3) //Informes
            {
                Check1.Visible = false;
                lbl1.Visible = false;
                Check2.Visible = false;
                lbl2.Visible = false;

                lblModelo.Visible = true;
                lblModelo.Location = new Point(18, 74);
                txtCodModelo.Visible = true;
                txtCodModelo.Location = new Point(76, 70);
                pModelo1.Visible = true;
                pModelo1.Location = new Point(76, 89);
                txtDescriModelo.Visible = true;
                txtDescriModelo.Location = new Point(158, 71);
                pModelo2.Visible = true;
                pModelo2.Location = new Point(158, 89);
                btnModelo.Visible = true;
                btnModelo.Location = new Point(386, 69);

                label1.Location = new Point(24, 102);
                maskDesde.Location = new Point(77, 104);
                label2.Location = new Point(27, 131);
                maskHasta.Location = new Point(76, 132);

                lbl3.Visible = true;
                Check3.Visible = true;

                Check4.Visible = false;
                lbl4.Visible = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int MaxTab = 0;
            int i;
            int n;

            bool validacion = true; // Solo para el frm de INFORME
            if (Proceso == 3) //Validacion solo para (INFORME)
            {
                if (txtCodEjercicio.Text == "")
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá seleccionar un Modelo de Balance.", false);
                    MessageBox.ShowDialog();
                    validacion = false;
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = AccesoBase.ListarDatos($"SELECT * FROM Balance WHERE bal_codigo = {txtCodModelo.Text}");

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Modelo de Balance no existe.", false);
                        MessageBox.ShowDialog();
                        validacion = false;
                    }
                }
            }

            if (txtCodEjercicio.Text != "" && validacion) //Validacion
            {
                string desde = "";
                string hasta = "";

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT eje_desde, eje_hasta FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    desde = dr["eje_desde"].ToString();
                    hasta = dr["eje_hasta"].ToString();
                }

                if (maskDesde.MaskFull) //Validacion
                {
                    if (maskHasta.MaskFull) //Validacion
                    {
                        if (Convert.ToDateTime(maskDesde.Text) >= Convert.ToDateTime(desde)) //Validacion
                        {
                            if (Convert.ToDateTime(maskHasta.Text) <= Convert.ToDateTime(hasta)) //Validacion
                            {
                                int terminal = frmLogin.NumeroTerminal;

                                if (Proceso == 1) /////BALANCE DE SUMAS Y SALDOS/////
                                {
                                    if (Check4.Checked) // Check4 = Sumar al saldo actual el saldo del ejercicio anterior
                                    {
                                        if(DESDE != Convert.ToDateTime(maskDesde.Text))
                                        {
                                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El sistema detecto que ha sido alterada la fecha (DESDE) para emitir el informe. Por ende no podra acular al saldo el resultado del ejercicio anterior.", false, true);
                                            MessageBox.ShowDialog();
                                        }
                                        else
                                        {
                                            DataSet ds2 = new DataSet();
                                            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_desde < {DESDE} ORDER BY eje_desde DESC");

                                            int EjAnt = 0; //Ejercicio Anterior
                                            if (ds2.Tables[0].Rows.Count != 0)
                                            {
                                                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                                {
                                                    EjAnt = Convert.ToInt32(dr2["eje_codigo"]);
                                                    break; //para que guarde solo el primero (en orden descendente)
                                                }
                                            }

                                            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");

                                            if (Check1.Checked == false) // Check1 = Visualizar informe con centro de costo
                                            {
                                                AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral (bal_terminal, bal_cuenta, bal_saldo) " +
                                                    $"SELECT {terminal}, mva_cuenta, (sum(case when mva_codigo = 1 then mva_importe else 0 end) - sum(case when mva_codigo = 2 then mva_importe else 0 end) as mva_saldo " +
                                                    $"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                                                    $"WHERE ast_ejercicio = {EjAnt} GROUP BY mva_cuenta");
                                            }
                                            else
                                            {
                                                AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral (bal_terminal, bal_cuenta, bal_saldo, bal_cc) SELECT {terminal}, mva_cuenta, (Sum(Case When mva_codigo = 1 Then mva_importe Else 0 End) - (Case When mva_codigo = 2 Then mva_importe Else 0 End)) as mva_Saldo, IsNull(mva_cc,0) " +
                                                $"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                                                $"LEFT JOIN (CentroCxPCuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo) on cxp_cuenta = mva_cuenta AND cxp_centroc = mva_cc " +
                                                $"WHERE ast_ejercicio = {EjAnt} GROUP BY mva_cuenta, IsNull (mva_cc,0)");
                                            }

                                            if (Check1.Checked) //Check1 = Visualizar informe con centro de costo
                                            {
                                                if (Check4.Checked) //Check4 = Sumar al saldo actual el saldo del ejercicio anterior
                                                {
                                                    //imprimir (al revez del original)
                                                }
                                                else
                                                {
                                                    //imprimir
                                                }
                                            }
                                            else
                                            {
                                                if (Check4.Checked) //Check4 = Sumar al saldo actual el saldo del ejercicio anterior
                                                {
                                                    //imprimir
                                                }
                                                else
                                                {
                                                    //imprimir
                                                }
                                            }

                                        }
                                    }
                                }
                                else if (Proceso == 2) /////BALANCE GENERAL/////
                                {
                                    AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");

                                    if (Check1.Checked == false) // Check1 = Visualizar informe con centro de costo
                                    {
                                        AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral(bal_Terminal, bal_codigo, bal_cuenta, bal_descri, bal_superior, bal_hija, bal_tabulador, bal_saldo, bal_col1, bal_col1D, bal_col2, bal_col2D, bal_col3, bal_col3D, bal_col4, bal_col4D) " +
                                        $" SELECT {terminal}, pcu_codigo, pcu_cuenta, pcu_descri, pcu_superior, pcu_hija, pcu_tabulador, 0, 0, '', 0, '', 0, '', 0, '' FROM PCuenta ORDER BY pcu_codigo");

                                        DataSet ds2 = new DataSet();
                                        ds2 = AccesoBase.ListarDatos($"SELECT mva_cuenta, pcu_descri as mva_Descri, pcu_codigo as mva_cod, " +
                                            $"(sum(case when mva_codigo = 1 then mva_importe else 0 end) - sum(case when mva_codigo = 2 then mva_importe else 0 end) as mva_saldo " +
                                            $"FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on ast_asiento = mva_asiento " +
                                            $"WHERE ast_ejercicio = {txtCodEjercicio.Text} AND  (ast_fecha >= {Convert.ToDateTime(maskDesde.Text)} AND ast_fecha <= {Convert.ToDateTime(maskHasta.Text)}) " +
                                            $"GROUP BT mva_cuenta, pcu_descri, pcu_codigo ORDER BY pcu_codigo");

                                        if (ds2.Tables[0].Rows.Count != 0)
                                        {
                                            foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                            {
                                                AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_Saldo = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr2["mva_cuenta"]}", dr2["mva_saldo"].ToString());
                                            }
                                        }

                                        DataSet ds3 = new DataSet();
                                        ds3 = AccesoBase.ListarDatos($"SELECT max(bal_tabulador) as bal_maxTabu FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");
                                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                        {
                                            MaxTab = Convert.ToInt32(dr3["bal_maxTabu"]);
                                        }

                                        n = MaxTab;

                                        for (i = 1; i == MaxTab - 1; i++)
                                        {
                                            DataSet ds4 = new DataSet();
                                            ds4 = AccesoBase.ListarDatos($"SELECT bal_superior, sum(bal_saldo) as bal_saldoGral FROM Aux_BalanceGral WHERE bal_terminal = {terminal} " +
                                            $"AND bal_tabulador = {n} GROUP BY bal_superior");

                                            foreach (DataRow dr4 in ds4.Tables[0].Rows)
                                            {
                                                AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_Saldo = {"*"} WHERE bal_terminal = {terminal} AND bal_codigo = {dr4["bal_superior"]}", dr4["mva_saldoGral"].ToString());
                                            }
                                            n = n - 1;
                                        }

                                        if (Check2.Checked) // Check2 = Visualizar informe segun rubro contable
                                        {
                                            DataSet ds5 = new DataSet();
                                            ds5 = AccesoBase.ListarDatos($"SELECT * FROM Aux_BalanceGral LEFT JOIN (PCuenta LEFT JOIN RubroCont on pcu_rubrocont = ruc_codigo) on bal_cuenta = pcu_cuenta " +
                                            $"WHERE bal_terminal = {terminal}");

                                            foreach (DataRow dr5 in ds5.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt32((dr5["pcu_hija"] == null) ? 0 : dr5["pcu_hija"]) == 0) //if en una linea
                                                {
                                                    switch (Convert.ToInt32((dr5["pcu_rubrocont"] == null) ? 0 : dr5["pcu_rubrocont"])) //if en una linea
                                                    {
                                                        case 0:
                                                            break;

                                                        case 1:
                                                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_col1 = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr5["pcu_cuenta"]}", dr5["bal_saldo"].ToString());
                                                            AccesoBase.InsertUpdateDatos($"UPDATE Aux_BalanceGral SET bal_col1D = UCase(left{dr5["ruc_descri"]}, 1) LCase(right {dr5["ruc_descri"]}, Len({dr5["ruc_descri"]} - 1) WHERE bal_terminal = {terminal}");
                                                            break;

                                                        case 2:
                                                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_col2 = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr5["pcu_cuenta"]}", dr5["bal_saldo"].ToString());
                                                            AccesoBase.InsertUpdateDatos($"UPDATE Aux_BalanceGral SET bal_col2D = UCase(left{dr5["ruc_descri"]}, 1) LCase(right {dr5["ruc_descri"]}, Len({dr5["ruc_descri"]} - 1) WHERE bal_terminal = {terminal}");
                                                            break;

                                                        case 3:
                                                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_col3 = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr5["pcu_cuenta"]}", dr5["bal_saldo"].ToString());
                                                            AccesoBase.InsertUpdateDatos($"UPDATE Aux_BalanceGral SET bal_col3D = UCase(left{dr5["ruc_descri"]}, 1) LCase(right {dr5["ruc_descri"]}, Len({dr5["ruc_descri"]} - 1) WHERE bal_terminal = {terminal}");
                                                            break;

                                                        case 4:
                                                            AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_col4 = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr5["pcu_cuenta"]}", dr5["bal_saldo"].ToString());
                                                            AccesoBase.InsertUpdateDatos($"UPDATE Aux_BalanceGral SET bal_col4D = UCase(left{dr5["ruc_descri"]}, 1) LCase(right {dr5["ruc_descri"]}, Len({dr5["ruc_descri"]} - 1) WHERE bal_terminal = {terminal}");
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                }
                                            }
                                            //imprimir
                                        }
                                        else
                                        {
                                            //imprimir
                                        }
                                    }
                                    else
                                    {
                                        AccesoBase.InsertUpdateDatos($"INSER INTO Aux_BalanceGral (bal_terminal, bal_codigo, bal_cuenta, bal_descri, bal_superior, " +
                                        $" bal_hija, bal_tabulador, bal_saldo, bal_col1, bal_coli1D, bal_col2, bal_col2D, bal_col3, bal_col3D, bal_col4, bal_col4D) " +
                                        $"SELECT {terminal}, pcu_codigo, pcu_cuenta, pcu_descri, pcu_superior, pcu_hija, pcu_tabulador, 0, 0, '', 0, '', 0, '', 0, '' FROM PCuenta ORDER BY pcu_codigo");

                                        AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_BalanceGral (bal_terminal, bal_codigo, bal_cuenta, bal_descri, bal_superior, " +
                                        $"bal_hija, bal_tabulador, bal_saldo, bal_cc, bal_ccdescri) SELECT {terminal}, pcu_codigo, pcu_cuenta, pcu_descri, pcu_superior, " +
                                        $"pcu_hija, pcu_tabulador, 0, cec_codigo, cec_descri FROM PCuenta LEFT JOIN (CentroCxPCuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo) " +
                                        $"on pcu_cuenta = cxp_cuenta WHERE cec_codigo is not null ORDER BY pcu_codigo");

                                        DataSet ds2 = new DataSet();
                                        ds2 = AccesoBase.ListarDatos($"SELECT mva_cuenta, pcu_descri as mva_Descri, pcu_codigo as mva_cod, cec_codigo, cec_descri, " +
                                        $"sum(case when mva_codigo = 1 then mva_importe else 0 end) - sum(case( when mva_codigo = 2 then mva_importe else 0 end)) " +
                                        $"as mva_saldo FROM MovAsto LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta = mva_cuenta LEFT JOIN Asiento on ast_asiento = mva_asiento " +
                                        $"WHERE ast_ejercicio = {txtCodEjercicio.Text} AND  (ast_fecha >= {Convert.ToDateTime(maskDesde.Text)} AND ast_fecha {Convert.ToDateTime(maskHasta.Text)}) " +
                                        $"GROUP by mva_cuenta, pcu_descri, pcu_codigo, cec_codigo, cec_descri ORDER BY pcu_codigo");

                                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                        {
                                            if (dr2["cec_codigo"] == null)
                                            {
                                                AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_saldo = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr2["mva_cuenta"]} AND bal_cc is null", dr2["mva_saldo"].ToString());
                                            }
                                            else
                                            {
                                                AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_saldo = {"*"} WHERE bal_terminal = {terminal} AND bal_cuenta = {dr2["mva_cuenta"]} AND bal_cc = {dr2["cec_codigo"]}", dr2["mva_saldo"].ToString());
                                            }
                                        }

                                        DataSet ds3 = new DataSet();
                                        ds3 = AccesoBase.ListarDatos($"SELECT max(bal_tabulador) as bal_maxTabu FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");

                                        if (ds3.Tables[0].Rows.Count != 0)
                                        {
                                            foreach (DataRow dr3 in ds3.Tables[0].Rows)
                                            {
                                                MaxTab = Convert.ToInt32(dr3["bal_maxTabu"]);
                                            }

                                            n = MaxTab;

                                            for (i = 1; i == MaxTab - 1; i++)
                                            {
                                                DataSet ds4 = new DataSet();
                                                ds4 = AccesoBase.ListarDatos($"SELECT bal_superior, sum(bal_saldo) as bal_saldoGral FROM Aux_BalanceGral WHERE bal_terminal = {terminal} " +
                                                $"AND bal_tabulador = {n} GROUP BY bal_superior");

                                                foreach (DataRow dr4 in ds4.Tables[0].Rows)
                                                {
                                                    AccesoBase.InsertUpdateDatosMoney($"UPDATE Aux_BalanceGral SET bal_Saldo = {"*"} WHERE bal_terminal = {terminal} AND bal_codigo = {dr4["bal_superior"]}", dr4["bal_saldoGral"].ToString());
                                                }
                                                n = n - 1;
                                            }

                                            //imprimir
                                        }

                                        AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_BalanceGral WHERE bal_terminal = {terminal}");
                                    }

                                }
                                else if (Proceso == 3) /////INFORMES/////
                                {
                                    if (Check3.Checked) // Check3 = imprimir informe sin centro de costo
                                    {
                                        string query = $"SELECT mva_cuenta, pcu_descri as mva_descri, cec_descri, sum(case when mva_codigo = 1 then mva_importe else 0 end) as mva_debe, " +
                                        $"sum(case when mva_codigo = 2 then mva_importe else 0 end) as mva_haber, (sum(case when mva_codigo = 1 then mva_importe else 0 end) - sum(case when mva_codigo = 2 then mva_importe else 0 end)) " +
                                        $"as mva_saldo FROM BalanceDet LEFT JOIN MovAsto on det_ctacont = mva_cuenta AND IsNull(det_cc,0) = IsNull(mva_cc,0) " +
                                        $"LEFT JOIN PCuenta on pcu_cuenta = mva_cuenta LEFT JOIN Asiento on mva_asiento = ast_asiento " +
                                        $"LEFT JOIN (CentroCxPCuenta LEFT JOIN CentroC on cxp_centroc = cec_codigo) on cxp_cuenta = mva_cuenta and cxp_centroc = mva_cc " +
                                        $"WHERE ast_ejercicio = {txtCodEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND " +
                                        $"ast_fecha <= '{maskHasta.Text}') AND det_codigo = {txtCodModelo.Text} GROUP BY det_orden, mva_cuenta, pcu_codigo, pcu_descri, cec_descri " +
                                        $"ORDER BY det_orden, pcu_codigo";

                                        frmReporte freporte = new frmReporte("BalanceCC", $"{query}", "", txtDescriModelo.Text + " - Sin Centro de Costos", maskDesde.Text, maskHasta.Text, txtDescriEjercicio.Text);
                                        freporte.ShowDialog();
                                    }
                                    else
                                    {
                                        //frmReporte freporte = new frmReporte("BalanceCC", $"{query}", "", txtDescriModelo.Text + " - Sin Centro de Costos", maskDesde.Text, maskHasta.Text, txtDescriEjercicio.Text);
                                        //freporte.ShowDialog();
                                    }
                                }
                            }
                            else
                            {
                                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "La fecha superior, No se encuentra dentro del periodo habilitado del ejercicio", false, true);
                                MessageBox.ShowDialog();
                            }
                        }
                        else
                        {
                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "La fecha inferior, No se encuentra dentro del periodo habilitado del ejercicio", false, true);
                            MessageBox.ShowDialog();
                        }
                    }
                    else
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Indicar la fecha superior.", false);
                        MessageBox.ShowDialog();
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Indicar la fecha inferior.", false);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                if (validacion)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debera Seleccionar un Ejercicio Contable.", false);
                    MessageBox.ShowDialog();
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Error en el dato ingresado en (Modelo de Balance)", false);
                    MessageBox.ShowDialog();
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnEjercicio_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("eje_codigo as Código, eje_descri as Descripción", "Ejercicio", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodEjercicio.Text = frmConsultaGeneral.codigoCG;
            txtDescriEjercicio.Text = frmConsultaGeneral.descripcionCG;
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("bal_codigo as Código, bal_descri as Descripción", "Balance", "", "", "frmBalanceDeSumasySaldos");
            frm.ShowDialog();
            txtCodModelo.Text = frmConsultaGeneral.codigoCG;
            txtDescriModelo.Text = frmConsultaGeneral.descripcionCG;
        }

        private void txtCodEjercicio_TextChanged(object sender, EventArgs e)
        {
            timer1.Start(); //(para que no se ejecute el textchange hasta que ponga el nro de ejercicio completo)
        }

        private void txtCodModelo_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtCodEjercicio.Text != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Balance WHERE bal_codigo = {txtCodModelo.Text}");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtDescriModelo.Text = dr["bal_descri"].ToString();
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Modelo de Balance no existe.", false);
                    MessageBox.ShowDialog();

                    txtCodModelo.Text = "";
                    txtDescriModelo.Text = "";
                }

            }
            else
            {
                txtDescriModelo.Text = "";
            }
            Cursor.Current = Cursors.Default;
        }

        private void Check1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) // Check con Centro de Costo
        {
            if (Check1.Checked)
            {
                Check2.Checked = false;
            }
        }

        private void Check2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) // Check Segun Rubro Contable
        {
            if (Check2.Checked)
            {
                Check1.Checked = false;
            }
        }

        DateTime DESDE; // se le asigna el valor (desde), del ejercicio
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            timer1.Stop();
            if (txtCodEjercicio.Text != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {txtCodEjercicio.Text}");

                if (ds.Tables[0].Rows.Count != 0) //si existe el ejercicio
                {
                    if (Negocio.Funciones.Contabilidad.FBalances_Informes.EstadoEjercicio(Convert.ToInt32(txtCodEjercicio.Text), 1)) //Funcion para verificar si el ejercicio esta cerrado
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable se encuentra cerrado.", false);
                        MessageBox.ShowDialog();
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtDescriEjercicio.Text = dr["eje_descri"].ToString();
                        maskDesde.Text = dr["eje_desde"].ToString();
                        maskHasta.Text = dr["eje_hasta"].ToString();

                        DESDE = Convert.ToDateTime(dr["eje_desde"]);
                    }

                    if (Proceso == 1) //Balance de Sumas y Saldos
                    {
                        if (Negocio.Funciones.Contabilidad.FBalances_Informes.EstadoEjercicio(Convert.ToInt32(txtCodEjercicio.Text), 2)) //verifica que el ejercicio tenga asiento del apertura
                        {
                            Check4.Enabled = true;
                            Check4.Checked = true;
                            lbl4.Enabled = true;
                        }
                        else
                        {
                            Check4.Enabled = false;
                            Check4.Checked = false;
                            lbl4.Enabled = false;
                        }
                    }
                    else
                    {
                        Check4.Enabled = false;
                        Check4.Checked = false;
                        lbl4.Enabled = false;
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable No Existe.", false);
                    MessageBox.ShowDialog();

                    Check4.Enabled = true;
                    Check4.Checked = false;
                    lbl4.Enabled = true;
                }
            }
            else
            {
                txtDescriEjercicio.Clear();
                maskDesde.Clear();
                maskHasta.Clear();

                Check4.Enabled = true;
                Check4.Checked = false;
                lbl4.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
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
