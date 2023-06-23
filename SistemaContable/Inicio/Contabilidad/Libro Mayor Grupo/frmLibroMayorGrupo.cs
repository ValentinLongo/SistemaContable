using Datos;
using Negocio.Funciones.Contabilidad;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Grupo
{
    public partial class frmLibroMayorGrupo : Form
    {
        public static string CodigoCuenta1;
        public static string CodigoCuenta2;
        public frmLibroMayorGrupo()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            maskDesde.Mask = "00/00/0000";
            maskHasta.Mask = "00/00/0000";
            maskHasta.Text = DateTime.Now.ToShortDateString();

        }

        private void btnBuscarEjercicio_Click(object sender, EventArgs e)
        {
            frmBuscarEjercicioContable buscarEjercicioContable = new frmBuscarEjercicioContable();
            buscarEjercicioContable.ShowDialog();
            if (frmBuscarEjercicioContable.idEjercicioSelec > 0)
            {
                tbIdEjercicio.Text = frmBuscarEjercicioContable.idEjercicioSelec.ToString();
                tbDescriEjercicio.Text = frmBuscarEjercicioContable.descriEjercicioSelec;
            }
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                tbIdCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = frmBuscarCuenta.DescriCuenta;
                CodigoCuenta1 = frmBuscarCuenta.CodigoCuenta;
            }
        }

        private void btnBuscarCuenta2_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                tbIdCuenta2.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta2.Text = frmBuscarCuenta.DescriCuenta;
                CodigoCuenta2 = frmBuscarCuenta.CodigoCuenta;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Negocio.FGenerales.ValidacionHoraFecha(2, maskDesde) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Fecha Desde Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Negocio.FGenerales.ValidacionHoraFecha(2, maskHasta) == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Fecha Hasta Invalida.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Convert.ToDateTime(maskDesde.Text) <= Convert.ToDateTime(maskHasta.Text))
            {
                DataSet datos = new DataSet();
                datos = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE (pcu_codigo >= '{CodigoCuenta1}' and pcu_codigo <= '{CodigoCuenta2}')");
                foreach (DataRow dataRow in datos.Tables[0].Rows)
                {
                    string pcuCodigo = dataRow["pcu_codigo"].ToString();
                    string pcuCuenta = dataRow["pcu_cuenta"].ToString();
                    string pcuDescri = dataRow["pcu_descri"].ToString();

                    double Debe = 0;
                    double Haber = 0;
                    double Saldo = 0;
                    string fechaDesde = "";
                    int EjAnterior = 0;
                    if (ChSumSalEjAnt.Checked == true)
                    {
                        DataSet ds = new DataSet();
                        ds = AccesoBase.ListarDatos($"select * from Ejercicio where eje_codigo = {tbIdEjercicio.Text}");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            fechaDesde = dr["eje_desde"].ToString();
                        }
                        if (fechaDesde != "")
                        {
                            DataSet ds2 = new DataSet();
                            ds2 = AccesoBase.ListarDatos($"select top 1 * from Ejercicio where eje_desde < '{fechaDesde}' order by eje_desde desc");
                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                EjAnterior = Convert.ToInt32(dr["eje_codigo"].ToString());
                            }

                            DataSet ds3 = new DataSet();
                            ds3 = AccesoBase.ListarDatos($"SELECT SUM(mva_importe) as Debe FROM MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento WHERE ast_ejercicio = {EjAnterior} and mva_codigo = 1 and mva_cuenta = {pcuCuenta}");
                            foreach (DataRow dr in ds3.Tables[0].Rows)
                            {
                                Debe = Convert.ToDouble(dr["Debe"].ToString());
                            }

                            DataSet ds4 = new DataSet();
                            ds4 = AccesoBase.ListarDatos($"SELECT SUM(mva_importe) as Haber FROM MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento WHERE ast_ejercicio = {EjAnterior} and mva_codigo = 2 and mva_cuenta = {pcuCuenta}");
                            foreach (DataRow dr in ds4.Tables[0].Rows)
                            {
                                Haber = Convert.ToDouble(dr["Haber"].ToString());
                            }
                        }
                    }

                    DataSet ds5 = new DataSet();
                    ds5 = AccesoBase.ListarDatos($"SELECT SUM(mva_importe) as Debe FROM MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento Left Join PCuenta on mva_cuenta = pcu_cuenta WHERE ast_ejercicio = {tbIdEjercicio.Text} and mva_codigo = 1 and pcu_codigo = '{pcuCodigo}' and ast_fecha < '{maskDesde.Text}'");
                    foreach (DataRow dr in ds5.Tables[0].Rows)
                    {
                        double debeSaldo;
                        try
                        {
                            debeSaldo = Convert.ToDouble(dr["Debe"].ToString());
                        }
                        catch
                        {
                            debeSaldo = 0;
                        }
                        Debe = Debe + debeSaldo;
                    }

                    DataSet ds6 = new DataSet();
                    ds6 = AccesoBase.ListarDatos($"SELECT SUM(mva_importe) as Haber FROM MovAsto LEFT JOIN Asiento on mva_asiento = ast_asiento Left Join PCuenta on mva_cuenta = pcu_cuenta WHERE ast_ejercicio = {tbIdEjercicio.Text} and mva_codigo = 2 and pcu_codigo = '{pcuCodigo}' and ast_fecha < '{maskDesde.Text}'");
                    foreach (DataRow dr in ds6.Tables[0].Rows)
                    {
                        double haberSaldo;
                        try
                        {
                            haberSaldo = Convert.ToDouble(dr["Haber"].ToString());
                        }
                        catch
                        {
                            haberSaldo = 0;
                        }
                        Haber = Haber + haberSaldo;
                    }
                    Saldo = Debe - Haber;

                    string saldoEjAnterior = "ast_comenta";
                    if (ChSumSalEjAnt.Checked)
                    {
                        saldoEjAnterior = "Case When len(ISNULL(ast_cbte,'')) = 0 Then ast_comenta Else (Case When ast_tipocbte = 1 Then (Case When LEN(ISNULL(ast_cbte,'')) < 14 Then tba_abrev Else tmo_abrev End) Else tmo_abrev End + ' ' + ast_cbte) End AS ast_comenta";
                    }

                    string query = $"select ast_fecha as mva_fecha, ast_renumera, mva_comenta, {saldoEjAnterior}, " +
                    $"Case When mva_codigo = 1 Then mva_importe Else 0 End as mva_debe," +
                    $"Case When mva_codigo = 2 Then mva_importe Else 0 End as mva_haber, pcu_descri as mva_descri, cec_descri " +
                    $"From MovAsto Left Join PCuenta on pcu_cuenta = mva_cuenta Left Join (Asiento Left Join TipMov on ast_tipocbte = tmo_codigo Left Join " +
                    $"TipMovBan on ast_tipocbte = tba_codigo) on mva_asiento = ast_asiento " +
                    $"Left Join (CentroCxPCuenta Left Join CentroC on cxp_centroc = cec_codigo) on cxp_cuenta = mva_cuenta and cxp_centroc = mva_cc " +
                    $"Where ast_ejercicio = {tbIdEjercicio.Text} and pcu_codigo = '{pcuCodigo}' and ast_fecha >= '{maskDesde.Text}' and ast_fecha <= '{maskHasta.Text}' " +
                    $"ORDER BY ast_tipo, ast_fecha, mva_asiento";


                    frmReporte reporte = new frmReporte("LibroMayorCC", query, "", "Libro Mayor - Por Grupo", $"{maskDesde.Text}", $"{maskHasta.Text}", pcuDescri, $"{Debe}", $"{Haber}", $"{tbDescriEjercicio.Text}");
                    reporte.ShowDialog();


                }
            }
            else
            {
                MessageBox.Show("La fecha desde tiene que se menor que la fecha hasta.");
            }
        }

        private void tbIdEjercicio_TextChanged(object sender, EventArgs e)
        {
            if (tbIdEjercicio.Text == "")
            {
                tbDescriEjercicio.Text = "";
                maskDesde.Text = "";
                maskHasta.Text = "";
                return;
            }

            FLibroMayor fLibroMayor = new FLibroMayor();
            string[] fechasydescri;
            fechasydescri = FLibroMayor.fechasDesdeHasta(Convert.ToInt32(tbIdEjercicio.Text));
            if (fechasydescri[0] != null && fechasydescri[1] != null && fechasydescri[2] != null)
            {
                maskDesde.Text = fechasydescri[0].ToString();
                maskHasta.Text = fechasydescri[1].ToString();
                tbDescriEjercicio.Text = fechasydescri[2].ToString();
            }
            else
            {
                tbDescriEjercicio.Text = "";
                maskDesde.Text = "";
                maskHasta.Text = "";
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            maskDesde.Text = dtpDesde.Value.ToString();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            maskHasta.Text = dtpHasta.Value.ToString();
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
    }
}
