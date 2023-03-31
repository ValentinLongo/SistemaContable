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
using static System.Net.Mime.MediaTypeNames;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.DetalledeInformes
{
    public partial class frmDetalledeInformes : Form
    {
        string Query;

        public frmDetalledeInformes()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Cargar("");
        }

        private void Cargar(string busqueda)
        {
            DataSet ds = new DataSet();
            string query = $"SELECT bal_codigo AS Código, bal_descri AS Descripción FROM Balance {busqueda} ORDER BY bal_codigo";
            ds = AccesoBase.ListarDatos(query);
            dgvDetalleDeInformes.DataSource = ds.Tables[0];
        }

        private void dgvDetalleDeInformes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnImprimir.Enabled = true;
            string codigo;
            codigo = dgvDetalleDeInformes.Rows[dgvDetalleDeInformes.CurrentRow.Index].Cells[0].Value.ToString();

            if (codigo == string.Empty)
            {
                codigo = "0";
            }
            DataSet ds = new DataSet();
            Query = $"SELECT * FROM BalanceDet LEFT JOIN PCuenta ON pcu_cuenta = det_ctacont LEFT JOIN Balance on det_codigo = bal_codigo WHERE det_codigo = {codigo}";
            ds = AccesoBase.ListarDatos(Query);
            dgvDetalledeInformesAux.Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string cuenta = dr["det_ctacont"].ToString();
                string descri = dr["pcu_descri"].ToString();
                string cc = dr["pcu_centroC"].ToString();
                string orden = "";
                try
                {
                    orden = dr["det_orden"].ToString();
                }
                catch
                {

                }
                dgvDetalledeInformesAux.Rows.Add(cuenta, descri, cc, orden);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            btnImprimir.Enabled = false;
            string busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "bal_descri");
            Cargar(busqueda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggDetalledeInformes frmAggDetalledeInformes = new frmAggDetalledeInformes(0);
            frmAggDetalledeInformes.ShowDialog();
            Cargar("");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporte reporte = new frmReporte("ModBalanceDet", Query, "", "Informe de Modelos de Balance","General",DateTime.Now.ToString("d"));
            reporte.ShowDialog();
        }

        //CONTROLBAR
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
