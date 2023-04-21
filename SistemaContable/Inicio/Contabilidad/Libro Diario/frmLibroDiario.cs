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

namespace SistemaContable.Inicio.Contabilidad.Libro_Diario
{
    public partial class frmLibroDiario : Form
    {
        public frmLibroDiario()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo();
        }

        private void Seteo() 
        {
            CheckInfDet.Checked = true;
            CheckImpStandar.Checked = true;

            maskDesde.Mask = "00-00-0000";
            maskHasta.Mask = "00-00-0000";
            maskHasta.Text = DateTime.Now.ToShortDateString();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (tbIdEjercicio.Text == "")
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera Seleccionar un Ejercicio Contable.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (maskDesde.MaskFull == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera Indicar la fecha Inferior.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (maskHasta.MaskFull == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera Indicar la fecha Superior.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Negocio.FGenerales.DesdeHastaEjercicio(Convert.ToInt32(tbIdEjercicio.Text), maskDesde.Text, maskHasta.Text) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "La fecha ingresada, No se encuentra dentro del periodo habilitado del ejercicio", false, true);
                MessageBox.ShowDialog();
                return;
            }

            if (CheckImpSinEncNF.Checked)
            {
                if (tbFolioInicial.Text.TrimEnd() == "")
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera indicar el Nro del Folio.", false);
                    MessageBox.ShowDialog();
                    return;
                }
            }

            int CantPag = 0;
            string Leyenda = "";

            if (tbLibroN.Text.TrimEnd() == "")
            {
                Leyenda = "Libro Diario General - " + tbDescriEjercicio.Text;
            }
            else
            {
                Leyenda = "Libro Diario General Nº " + tbLibroN.Text;
            }

            if (CheckInfDet.Checked)
            {
                double debe = Negocio.Funciones.Contabilidad.FLibroDiario.SaldoInicial(Convert.ToInt32(tbIdEjercicio.Text), maskDesde.Text, 1);
                double haber = Negocio.Funciones.Contabilidad.FLibroDiario.SaldoInicial(Convert.ToInt32(tbIdEjercicio.Text), maskDesde.Text, 2);

                string LeyTotal;

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {tbIdEjercicio.Text}");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToDateTime(dr["eje_hasta"]) == Convert.ToDateTime(maskHasta.Text))
                        {
                            LeyTotal = "Total :";
                        }
                        else
                        {
                            LeyTotal = "Transporte :";

                        }
                    }
                }

                string modelo = "";

                if (CheckImpStandar.Checked)
                {
                    modelo = "";
                }
                if (CheckImpSinEnc.Checked)
                {
                    modelo = "1";
                }
                if (CheckImpSinEncNF.Checked)
                {
                    modelo = "3";
                }

                //Imprimir

            }
            else if (CheckInfAgDi.Checked)
            {
                AsientoDiario();
            }
            else if (CheckInfAgMen.Checked)
            {
                AsientoMensual();
            }
        }

        private void AsientoDiario() 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM TipoxTipMov");
            if (ds.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se han definido los Tipos por tipo de Movimiento", false);
                MessageBox.ShowDialog();
                return;
            }

            ds = AccesoBase.ListarDatos($"SELECT ast_fecha, txt_orden, txt_tipo, txt_descri, ast_tipocbte FROM Asiento LEFT JOIN TipoxTipMov on txt_tipmov = IsNull(case when ast_tipocbte = 1 then case when len(ast_cbte) <> 14 then 111 else 1 end else ast_tipocbte end,0) where ast_ejercicio = {tbIdEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND ast_fecha <= '{maskHasta.Text}') AND ast_grupo1 is null AND IsNull(ast_cbte,'') <> '' AND txt_orden is null GROUP BY ast_fecha, txt_orden, txt_tipo, txt_descri, ast_tipocbte ORDER BY ast_fecha, txt_orden, txt_tipo, txt_descri, ast_tipocbte");
            if (ds.Tables[0].Rows.Count == 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Existen Tipos de Comprobantes que no han sido parametrizados para su agrupamiento. Por Ejemplo el Tipo " + dr["ast_tipocbte"].ToString(), false, true);
                    MessageBox.ShowDialog();
                    break;
                }
                return;
            }

            ds = AccesoBase.ListarDatos($"SELECT ast_fecha, txt_orden, txt_tipo, txt_descri FROM Asiento LEFT JOIN TipoxTipMov on txt_tipmov = IsNull(case when ast_tipocbte = 1 then case when len(ast_cbte) <> 14 then 111 else 1 end else ast_tipocbte end,0) where ast_ejercicio = {tbIdEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND ast_fecha <= '{maskHasta.Text}') AND ast_grupo1 is null AND IsNull(ast_cbte,'') <> '' AND txt_orden is null GROUP BY ast_fecha, txt_orden, txt_tipo, txt_descri ORDER BY ast_fecha, txt_orden, txt_tipo, txt_descri");

            int Asiento = 0;

            DataSet ds2 = new DataSet();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblControlBar.Text = "Libro Diario (reporte) - Procesando Día " + dr["ast_fecha"].ToString();

                ds2 = AccesoBase.ListarDatos($"SELECT max(ast_asiento) as maximo FROM AsientoG WHERE ast_tipoG = 'D' ");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    Asiento = (dr2["maximo"] is DBNull ? 1 : Convert.ToInt32(dr2["maximo"]) + 1);
                    break;
                }

                AccesoBase.InsertUpdateDatos($"INSERT INTO AsientoG (ast_asiento, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo, ast_tipoG, ast_orden) Values ({Asiento}, '{dr["ast_fecha"]}', '{dr["txt_descri"]}', 0, 0, '', 0, {FLogin.IdUsuario}, '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', {tbIdEjercicio.Text}, '{DateTime.Now.ToString().Substring(0,10)}', 2, 'D', {dr["txt_orden"]}) ");
                AccesoBase.InsertUpdateDatos($"INSERT INTO MovAstoG (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_tipoG) SELECT {Asiento}, '{dr["ast_fecha"]}', mva_cuenta, mva_codigo, sum(mva_importe) as mva_importe, '', 'D' FROM MovAsto LEFT JOIN (Asiento LEFT JOIN TipoxTipMov on txt_tipmov = IsNull(case when ast_tipocbte = 1 then case when len(ast_cbte) <> 14 then 111 else 1 end else ast_tipocbte end 0)) on mva_asiento = ast_asiento AND txt_orden = {dr["txt_orden"]} GROUP BY mva_cuenta, mva_codigo ORDER BY mva_cuenta, mva_codigo");
                AccesoBase.InsertUpdateDatos($"UPDATE Asiento set ast_grupo1 = {Asiento} FROM Asiento LEFT JOIN TipoxTipMov on txt_tipmov = IsNull(case when ast_tipocbte = 1 then case when len(ast_cbte) <> 14 then 111 else 1 end else ast_tipocbte end, 0) WHERE ast_ejercicio = {tbIdEjercicio.Text} AND ast_fecha = '{dr["ast_fecha"]}' AND txt_orden = {dr["txt_orden"]}");
            }

            int orden = 0;

            ds = AccesoBase.ListarDatos($"SELECT * FROM TipoxTipMov WHERE txt_tipmov = 0");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                orden = Convert.ToInt32(dr["txt_orden"]);
            }

            ds = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 2 AND ast_ejercicio = {tbIdEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND ast_fecha <= '{maskHasta.Text}') AND ast_grupo1 is null AND IsNull(ast_cbte,'') = '' ORDER BY ast_tipo, ast_fecha");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblControlBar.Text = "Libro Diario (reporte) - Procesando Manuales";

                ds2 = AccesoBase.ListarDatos($"SELECT max(ast_asiento) as maximo FROM AsientoG WHERE ast_tipoG = 'D' ");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    Asiento = (dr2["maximo"] is DBNull ? 1 : Convert.ToInt32(dr2["maximo"]) + 1);
                    break;
                }

                AccesoBase.InsertUpdateDatos($"INSERT INTO AsientoG (ast_asiento, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo, ast_tipoG, ast_orden) SELECT {Asiento}, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo, 'D', {orden} FROM Asiento WHERE ast_asiento = {dr["ast_asiento"]}");
                AccesoBase.InsertUpdateDatos($"INSERT INTO MovAstoG (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_tipoG) SELECT {Asiento}, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, 'D' FROM MovAsto WHERE ast_asiento = {dr["ast_asiento"]}");
                AccesoBase.InsertUpdateDatos($"UPDATE Asiento set ast_grupo1 = {Asiento} FROM Asiento WHERE ast_asiento = {dr["ast_asiento"]}");
            }

            ds = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 2 AND ast_ejercicio = {tbIdEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND ast_fecha <= '{maskHasta.Text}') AND ast_grupo1 is null AND IsNull(ast_cbte,'') = '' ORDER BY ast_tipo, ast_fecha");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblControlBar.Text = "Libro Diario (reporte) - Procesando Apertura y Cierre";

                ds2 = AccesoBase.ListarDatos($"SELECT max(ast_asiento) as maximo FROM AsientoG WHERE ast_tipoG = 'D' ");
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    Asiento = (dr2["maximo"] is DBNull ? 1 : Convert.ToInt32(dr2["maximo"]) + 1);
                    break;
                }

                AccesoBase.InsertUpdateDatos($"INSERT INTO AsientoG (ast_asiento, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo, ast_tipoG, ast_orden) SELECT {Asiento}, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_ejercicio, ast_fecalta, ast_tipo, 'D', {orden} FROM Asiento WHERE ast_asiento = {dr["ast_asiento"]}");
                AccesoBase.InsertUpdateDatos($"INSERT INTO MovAstoG (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_tipoG) SELECT {Asiento}, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta, 'D' FROM MovAsto WHERE ast_asiento = {dr["ast_asiento"]}");
                AccesoBase.InsertUpdateDatos($"UPDATE Asiento set ast_grupo1 = {Asiento} FROM Asiento WHERE ast_asiento = {dr["ast_asiento"]}");
            }

            Asiento = 0;

            ds = AccesoBase.ListarDatos($"SELECT * FROM AsientoG WHERE ast_renumera is null ORDER BY ast_tipo, ast_fecha, ast_orden");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Asiento++;

                lblControlBar.Text = "Libro Diario (reporte) - Renumerando " + Asiento + " de " + ds.Tables[0].Rows.Count.ToString();

                AccesoBase.InsertUpdateDatos($"UPDATE AsientoG SET ast_renumera = {Asiento} WHERE ast_asiento = {dr["ast_asiento"]} AND ast_tipoG = 'D' ");
            }

            string Leyenda = "";

            if (tbLibroN.Text.TrimEnd() == "")
            {
                Leyenda = "Libro Diario General - " + tbDescriEjercicio.Text + " Agrupado Diario";
            }
            else
            {
                Leyenda = "Libro Diario General Nº " + tbFolioInicial.Text;
            }

            double debe = Negocio.Funciones.Contabilidad.FLibroDiario.SaldoInicial(Convert.ToInt32(tbIdEjercicio.Text), maskDesde.Text, 1);
            double haber = Negocio.Funciones.Contabilidad.FLibroDiario.SaldoInicial(Convert.ToInt32(tbIdEjercicio.Text), maskDesde.Text, 2);

            string LeyTotal;

            DataSet ds3 = new DataSet();
            ds3 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {tbIdEjercicio.Text}");
            if (ds3.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dr3["eje_hasta"]) == Convert.ToDateTime(maskHasta.Text))
                    {
                        LeyTotal = "Total :";
                    }
                    else
                    {
                        LeyTotal = "Transporte :";

                    }
                }
            }

            string modelo = "";

            if (CheckImpStandar.Checked)
            {
                modelo = "";
            }
            if (CheckImpSinEnc.Checked)
            {
                modelo = "1";
            }
            if (CheckImpSinEncNF.Checked)
            {
                modelo = "3";
            }

            //Imprimir

            lblControlBar.Text = "Libro Diario (reporte)";
        }

        private void AsientoMensual()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM TipoxTipMov");
            if (ds.Tables[0].Rows.Count == 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se han definido los Tipos por tipo de Movimiento", false);
                MessageBox.ShowDialog();
                return;
            }

            ds = AccesoBase.ListarDatos($"SELECT X.MesAnio, X.Mes, X.Anio, X.txt_orden, X.txt_orden, X.txt_tipo, X.txt_descri FROM (SELECT ast_fecha (convert(varchar,datepart()mm,ast_fecha)) + '/' + convert(varchar,datepart()yyyy,ast_fecha))) as MesAnio, datepart(mm,ast_fecha) as Mes, datepart(yyyy,ast_fecha) as Anio, txt_orden, txt_tipo, txt_descri FROM Asiento LEFT JOIN TipoxTipMov on txt_tipmov = IsNull(case when ast_tipocbte = 1 then case when len()ast_cbte) <> 14 then 111 else 1 end else ast_tipocbte end,0) WHERE ast_ejercicio = {tbIdEjercicio.Text} AND (ast_fecha >= '{maskDesde.Text}' AND ast_fecha <= '{maskHasta.Text}') and AST_GRUPO2 IS NULL AND iSnULL()AST_CBTE,'') <> '' GROUP BY ast_fecha, txt_orden, txt_tipo, txt_descri) as X GRUOP BY X.MesAnio, X.Mes, X.Anio, X.txt_tipo, X.txt_descri GROUP BY X.Mes, X.Anio, X.txt_orden, X.txt_tipo, X.txt_descri");

            int Asiento = 0;
            string fecha = "";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //terminar
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarEjercicioContable buscarEjercicioContable = new frmBuscarEjercicioContable();
            buscarEjercicioContable.ShowDialog();
            if(frmBuscarEjercicioContable.idEjercicioSelec > 0)
            {
                tbIdEjercicio.Text = frmBuscarEjercicioContable.idEjercicioSelec.ToString();
                tbDescriEjercicio.Text = frmBuscarEjercicioContable.descriEjercicioSelec;
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // para hacer radiobutton los primeros 3 checkbox
        private void CheckInfDet_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckInfDet.Checked == false && CheckInfAgDi.Checked == false && CheckInfAgMen.Checked == false)
            {
                CheckInfDet.Checked = true;
            }
            if (CheckInfDet.Checked)
            {
                CheckInfAgDi.Checked = false;
                CheckInfAgMen.Checked = false;
            }
        }

        private void CheckInfAgDi_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckInfDet.Checked == false && CheckInfAgDi.Checked == false && CheckInfAgMen.Checked == false)
            {
                CheckInfAgDi.Checked = true;
            }
            if (CheckInfAgDi.Checked)
            {
                CheckInfDet.Checked = false;
                CheckInfAgMen.Checked = false;
            }
        }

        private void CheckInfAgMen_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckInfDet.Checked == false && CheckInfAgDi.Checked == false && CheckInfAgMen.Checked == false)
            {
                CheckInfAgMen.Checked = true;
            }
            if (CheckInfAgMen.Checked)
            {
                CheckInfDet.Checked = false;
                CheckInfAgDi.Checked = false;
            }
        }
        //

        // para hacer radiobutton los ultimos 3 checkbox
        private void CheckImpStandar_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckImpStandar.Checked == false && CheckImpSinEnc.Checked == false && CheckImpSinEncNF.Checked == false)
            {
                CheckImpStandar.Checked = true;
            }
            if (CheckImpStandar.Checked)
            {
                tbLibroN.Enabled = true;
                tbFolioInicial.Enabled = true;

                CheckImpSinEnc.Checked = false;
                CheckImpSinEncNF.Checked = false;
            }
        }

        private void CheckImpSinEnc_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckImpStandar.Checked == false && CheckImpSinEnc.Checked == false && CheckImpSinEncNF.Checked == false)
            {
                CheckImpSinEnc.Checked = true;
            }
            if (CheckImpSinEnc.Checked)
            {
                tbLibroN.Enabled = false;
                tbFolioInicial.Enabled = false;

                CheckImpStandar.Checked = false;
                CheckImpSinEncNF.Checked = false;
            }
        }

        private void CheckImpSinEncNF_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckImpStandar.Checked == false && CheckImpSinEnc.Checked == false && CheckImpSinEncNF.Checked == false)
            {
                CheckImpSinEncNF.Checked = true;
            }
            if (CheckImpSinEncNF.Checked)
            {
                tbLibroN.Enabled = false;
                tbFolioInicial.Enabled = true;

                CheckImpSinEnc.Checked = false;
                CheckImpStandar.Checked = false;
            }
        }
        //

        private void tbIdEjercicio_TextChanged(object sender, EventArgs e)
        {
            if (tbIdEjercicio.Text != "")
            {
                if (Negocio.FGenerales.EstadoEjercicio(Convert.ToInt32(tbIdEjercicio.Text),1))
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable se encuentra Cerrado.", false);
                    MessageBox.ShowDialog();
                }

                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {tbIdEjercicio.Text}");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable no Existe.", false);
                    MessageBox.ShowDialog();

                    tbIdEjercicio.Text = "";
                    tbDescriEjercicio.Text = "";

                    maskDesde.Text = "";
                    maskHasta.Text = "";
                }
                else
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tbDescriEjercicio.Text = (dr["eje_descri"] is DBNull ? "" : dr["eje_descri"].ToString());
                        maskDesde.Text = dr["eje_desde"].ToString();
                        maskHasta.Text = dr["eje_hasta"].ToString();
                    }
                }
            }
            else
            {
                maskDesde.Text = "";
                maskHasta.Text = "";
                tbDescriEjercicio.Text = "";
            }
        }

    }
}
