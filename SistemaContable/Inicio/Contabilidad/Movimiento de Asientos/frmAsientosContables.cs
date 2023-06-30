using CrystalDecisions.ReportAppServer;
using Datos;
using Negocio;
using OpenQA.Selenium.Internal;
using SistemaContable.General;
using SistemaContable.Plan_de_Cuentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmAsientosContables : Form
    {
        public frmAsientosContables()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo();
        }

        private void Seteo()
        {
            maskFecha.Mask = "00/00/0000";

            List<DataRow> lista = new List<DataRow>();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_codigo,eje_descri FROM Ejercicio");
            cbSeleccion.DataSource = ds.Tables[0];
            cbSeleccion.DisplayMember = "eje_descri";
            cbSeleccion.ValueMember = "eje_codigo";
            cbSeleccion.SelectedIndex = -1;
            cbBusqueda.SelectedIndex = 0;
        }

        private void CargarDGV(string busqueda, string manuales, string modificados, string diferencia)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cbSeleccion.SelectedIndex > -1)
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"Select X.ast_asiento as Asiento, X.ast_fecha as Fecha,X.ast_comenta as Comentario,Sum(X.Debe) as Debe,Sum(X.Haber) as Haber,X.usu_nombre as Creó,X.ast_fecalta as FechaCreó,X.ast_hora as HoraCreó, X.UsuModi as Modificó, X.ast_fecmodi as FechaModi, X.ast_horamodi as HoraModi From (Select *, Z.UsuModi1 as UsuModi, Case When mva_codigo = 1 Then mva_importe Else 0 End as Debe, Case When mva_codigo = 2 Then mva_importe Else 0 End as Haber From MovAsto Left Join Asiento on mva_asiento = ast_asiento Left Join PCuenta on mva_cuenta = pcu_cuenta Left Join Usuario on ast_user = Usuario.usu_codigo Left Join Ejercicio on ast_ejercicio = eje_codigo Left Join TipAsto on ast_tipo = tas_codigo Left Join (Select usu_codigo as UsuCod, usu_nombre as UsuModi1 From Usuario) as Z on ast_usumodi = Z.UsuCod Where ast_ejercicio = '{cbSeleccion.SelectedValue}' {busqueda} {manuales} {modificados} ) as X Group By X.ast_asiento, X.ast_renumera, X.ast_fecha, X.ast_ctapro, X.ast_comenta, X.ast_tipocbte, X.ast_cbte, X.ast_ejercicio, X.eje_descri, X.ast_user, X.usu_nombre, X.ast_hora, X.ast_fecalta, X.UsuModi, X.ast_fecmodi, X.ast_horamodi, X.ast_tipo, X.tas_descri {diferencia} Order By X.ast_fecha, X.ast_asiento");
                dgvAsientosContables.DataSource = ds.Tables[0];

                //propiedades por codigo porque no se asignaban de otra forma
                dgvAsientosContables.DefaultCellStyle.ForeColor = Color.White;

                DataGridViewColumn columnaComentario = dgvAsientosContables.Columns["Comentario"];
                columnaComentario.Width = 280;

                DataGridViewColumn columnaCreo = dgvAsientosContables.Columns["Creó"];
                columnaCreo.Width = 150;

                DataGridViewColumn columnaDebe = dgvAsientosContables.Columns["Debe"];
                columnaDebe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewColumn columnaHaber = dgvAsientosContables.Columns["Haber"];
                columnaHaber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            SeteoFooter(dgvAsientosContables, footer);
            ActualizarFooter(busqueda, manuales, modificados, diferencia);
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvAsientosContables);
            Cursor.Current = Cursors.Default;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(1, cbSeleccion, "", "", "");
                frm.ShowDialog();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
            CargarDGV("", "", "", "");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                int seleccionado = dgvAsientosContables.CurrentCell.RowIndex;
                string asiento = dgvAsientosContables.Rows[seleccionado].Cells[0].Value.ToString();
                string fecha = dgvAsientosContables.Rows[seleccionado].Cells[1].Value.ToString();
                string comentario = dgvAsientosContables.Rows[seleccionado].Cells[2].Value.ToString();

                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(2, cbSeleccion, asiento, fecha, comentario);
                frm.ShowDialog();
                AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto");
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
            CargarDGV("", "", "", "");
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                int seleccionado = dgvAsientosContables.CurrentCell.RowIndex;
                string asiento = dgvAsientosContables.Rows[seleccionado].Cells[0].Value.ToString();
                string fecha = dgvAsientosContables.Rows[seleccionado].Cells[1].Value.ToString();
                string comentario = dgvAsientosContables.Rows[seleccionado].Cells[2].Value.ToString();

                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(3, cbSeleccion, asiento, fecha, comentario);
                frm.ShowDialog();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
        }

        private void cbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeleccion.Tag.ToString() != "0")
            {
                CargarDGV("", "", "", "");
            }
            else
            {
                cbSeleccion.Tag = "1";
            }
        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBusqueda.Text == "Asiento")
            {
                btnBuscar.Visible = false;
                lblDesde.Visible = false;
                maskFecha.Visible = false;
                txtBusqueda.Visible = true;
                LineaBusqueda.Visible = true;
                CheckInicio.Visible = true;
                lblinicio.Visible = true;
            }
            else if (cbBusqueda.Text == "Descripción")
            {
                btnBuscar.Visible = false;
                lblDesde.Visible = false;
                maskFecha.Visible = false;
                txtBusqueda.Visible = true;
                LineaBusqueda.Visible = true;
                CheckInicio.Visible = true;
                lblinicio.Visible = true;
            }
            else if (cbBusqueda.Text == "Fecha")
            {
                btnBuscar.Visible = true;
                lblDesde.Visible = true;
                maskFecha.Visible = true;
                txtBusqueda.Visible = false;
                LineaBusqueda.Visible = false;
                CheckInicio.Visible = false;
                lblinicio.Visible = false;
            }
        }

        private void Click(object sender, EventArgs e)
        {
            string diferencia = "";
            string manuales = "";
            string modificados = "";

            if (CheckDiferencia.Checked)
            {
                diferencia = " HAVING Sum(X.Debe) <> Sum(X.Haber) ";
            }
            if (CheckManuales.Checked)
            {
                manuales = " And (ast_cbte is null or ast_cbte = '') ";
            }
            if (CheckModificados.Checked)
            {
                modificados = " And not (ast_fecmodi is null or ast_fecmodi = '01/01/1900') ";
            }
            CargarDGV("", manuales, modificados, diferencia);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            timerBusqueda.Start();
        }

        private void timerBusqueda_Tick(object sender, EventArgs e)
        {
            timerBusqueda.Stop();
            if (cbSeleccion.SelectedIndex > -1)
            {
                string busqueda = "";

                if (cbBusqueda.Text == "Asiento")
                {
                    busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 2, "ast_asiento");
                }
                else if (cbBusqueda.Text == "Descripción")
                {
                    busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 2, "ast_comenta");
                }
                CargarDGV(busqueda, "", "", "");
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                if (Negocio.FGenerales.ValidacionHoraFecha(2, maskFecha) == false)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Fecha ingresada Invalida.", false);
                    MessageBox.ShowDialog();
                    return;
                }

                string busqueda = "AND ast_fecha = " + "'" + maskFecha.Text + " 00:00:00.000'";
                CargarDGV(busqueda, "", "", "");
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                int seleccionado = dgvAsientosContables.CurrentCell.RowIndex;
                if (seleccionado != -1)
                {
                    int validado = 0;
                    int asiento = Convert.ToInt32(dgvAsientosContables.Rows[seleccionado].Cells[0].Value);

                    int resultado = AccesoBase.ValidarDatos($"SELECT ast_cbte FROM Asiento WHERE ast_asiento = {asiento}");
                    if (resultado == 1)
                    {
                        validado++;
                    }
                    else
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El asiento ha sido generado en forma automatica por el sistema. No podra ser anulado.", false);
                        MessageBox.ShowDialog();
                        return;
                    }

                    int ID = FLogin.IdUsuario;
                    int activo = 0;

                    DataSet ds = new DataSet();
                    ds = AccesoBase.ListarDatos($"SELECT pxu_activo FROM PermisosxUsu WHERE pxu_usuario = {ID} AND pxu_codigo = 3 AND pxu_sistema = 'CO'");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        activo = Convert.ToInt32(dr["pxu_activo"]);
                    }
                    if (activo == 1)
                    {
                        validado++;
                    }
                    else
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No tiene permisos para anular el asiento", false);
                        MessageBox.ShowDialog();
                        return;
                    }
                    if (validado == 2)
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Seguro que desea Anular el Asiento Contable?", true);
                        MessageBox.ShowDialog();
                        if (frmMessageBox.Acepto)
                        {
                            AccesoBase.InsertUpdateDatos($"DELETE Asiento WHERE ast_asiento = {asiento}");
                        }
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debe seleccionar un Ejercicio!", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvAsientosContables.Rows.Count == 0)
            {
                return;
            }

            int NroEjercicio = Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text, "Ejercicio", "eje");

            string[] fechas = Negocio.Funciones.Contabilidad.FLibroMayor.fechasDesdeHasta(NroEjercicio);

            frmRangoFechas frm = new frmRangoFechas(3, Convert.ToDateTime(fechas[0]), DateTime.Now);
            frm.ShowDialog();

            if (frmRangoFechas.Desde == Convert.ToDateTime("26/12/2003") && frmRangoFechas.Hasta == Convert.ToDateTime("31/12/9999"))
            {
                return;
            }

            string query = $"Select X.ast_asiento, X.ast_renumera, X.ast_fecha, X.ast_ctapro, X.ast_comenta, X.ast_tipocbte, X.ast_cbte, X.ast_ejercicio, X.eje_descri, X.ast_user, X.usu_nombre, X.UsuModi as UsuModi, X.ast_hora, X.ast_fecalta, X.ast_fecmodi, X.ast_horamodi, X.ast_tipo, X.tas_descri, Sum(X.Debe) as mva_debe, Sum(X.Haber) as mva_haber From (Select *, Z.UsuModi1 as UsuModi, Case When mva_codigo = 1 Then mva_importe Else 0 End as Debe, Case When mva_codigo = 2 Then mva_importe Else 0 End as Haber From MovAsto Left Join Asiento on mva_asiento = ast_asiento Left Join PCuenta on mva_cuenta = pcu_cuenta Left Join Usuario on ast_user = Usuario.usu_codigo Left Join Ejercicio on ast_ejercicio = eje_codigo Left Join TipAsto on ast_tipo = tas_codigo Left Join (Select usu_codigo as UsuCod, usu_nombre as UsuModi1 From Usuario) as Z on ast_usumodi = Z.UsuCod ) as X " +
            $"WHERE ast_ejercicio = {NroEjercicio} AND (ast_fecha >= '{frmRangoFechas.Desde}') AND (ast_fecha <= '{frmRangoFechas.Hasta}') Group By X.ast_asiento, X.ast_renumera, X.ast_fecha, X.ast_ctapro, X.ast_comenta, X.ast_tipocbte, X.ast_cbte, X.ast_ejercicio, X.eje_descri, X.ast_user, X.usu_nombre, X.ast_hora, X.ast_fecalta, X.UsuModi, X.ast_fecmodi, X.ast_horamodi, X.ast_tipo, X.tas_descri Order By X.ast_tipo, X.ast_fecha, X.ast_asiento, X.ast_renumera";

            frmReporte reporte = new frmReporte("ResumAsto", "", $"{query}", "Resumen de Asientos", frmRangoFechas.Desde.ToString().Substring(0, 10) + " al " + frmRangoFechas.Hasta.ToString().Substring(0, 10), cbSeleccion.Text, frmRangoFechas.CheckValue.ToString());
            reporte.ShowDialog();
        }

        //FOOTER
        private void SeteoFooter(DataGridView dgv1, DataGridView footer)
        {
            footer.Columns.Clear();
            foreach (DataGridViewColumn Columna in dgv1.Columns)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Width = Columna.Width;
                footer.Columns.Add(col);

                Columna.Resizable = DataGridViewTriState.False; //para que el usuario no pueda modificar el ancho de las columnas
            }
        }
        private void ActualizarFooter(string busqueda, string manuales, string modificados, string diferencia)
        {
            if (diferencia != "")
            {
                diferencia = "HAVING sum(case when mva_codigo = 1 then mva_importe else 0 end) <> sum(case when mva_codigo = 2 then mva_importe else 0 end)";
            }

            if (dgvAsientosContables.Rows.Count != 0)
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT sum(X.Debe) as Debe, Sum(X.Haber) as Haber FROM(SELECT ast_asiento, sum(case when mva_codigo = 1 then mva_importe else 0 end) as Debe, sum(case when mva_codigo = 2 then mva_importe else 0 end) as Haber FROM MovAsto left join Asiento on mva_asiento = ast_asiento left join Ejercicio on ast_ejercicio = eje_codigo left join TipAsto on ast_tipo = tas_codigo left join (select usu_codigo as UsuCod, usu_nombre as UsuModi1 FROM Usuario) as Z on ast_usumodi = Z.UsuCod WHERE ast_ejercicio = '{cbSeleccion.SelectedValue}' {busqueda} {manuales} {modificados} Group By ast_asiento {diferencia} ) as X");

                footer.Columns[2].HeaderText = "Totales:";
                footer.Columns[3].HeaderText = ds.Tables[0].Rows[0]["Debe"] is DBNull ? "0" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["Debe"]), 2).ToString();
                footer.Columns[4].HeaderText = ds.Tables[0].Rows[0]["Haber"] is DBNull ? "0" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["Haber"]), 2).ToString();

                footer.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                footer.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewColumn columna = dgvAsientosContables.Columns["Debe"];
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                columna.Width = footer.Columns[3].Width;
                DataGridViewColumn columna2 = dgvAsientosContables.Columns["Haber"];
                columna2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                columna2.Width = footer.Columns[4].Width;
            }
        }
        private void dgvAsientosContables_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvAsientosContables.HorizontalScrollingOffset == e.NewValue)
            {
                footer.HorizontalScrollingOffset = e.NewValue;
            }

            bool scrollVerticalActivo = dgvAsientosContables.DisplayedRowCount(false) < dgvAsientosContables.RowCount;
            if (scrollVerticalActivo)
            {
                if (dgvAsientosContables.Rows.Count != 0)
                {
                    if (Negocio.FGenerales.SincronizarFooter(dgvAsientosContables))
                    {
                        footer.Location = new Point(26, 84);
                    }
                    else
                    {
                        footer.Location = new Point(26, 514);
                    }
                }
            }
        }
        //

        private void frmAsientosContables_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}
