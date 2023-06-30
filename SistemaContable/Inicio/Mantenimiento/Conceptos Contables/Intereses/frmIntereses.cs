using Bunifu.UI.WinForms.Helpers.Transitions;
using Datos;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables.Intereses;
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

namespace SistemaContable.General
{
    public partial class frmIntereses : Form
    {
        public static string Periodo;
        public static string Coef;
        public static int CCC; //CodigoConceptoContable

        public frmIntereses(int CodConceptoContable)
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

            CCC = CodConceptoContable;

            CargarDGV(CodConceptoContable);
        }

        private void CargarDGV(int CodConceptoContable)
        {
            dgvIntereses.Rows.Clear();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Intereses WHERE int_conceptocont = {CodConceptoContable}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string Periodo = dr["int_periodo"].ToString();
                string Coef = dr["int_coef"].ToString();
                dgvIntereses.Rows.Add(Periodo, Coef);
            }
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvIntereses);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAggModInteres frm = new frmAggModInteres(1);
            frm.ShowDialog();
            CargarDGV(CCC);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAggModInteres frm = new frmAggModInteres(2);
            frm.ShowDialog();
            CargarDGV(CCC);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Continuar?", true);
            MessageBox.ShowDialog();
            if (frmMessageBox.Acepto)
            {
                string Coef = frmIntereses.Coef.Replace(",", ".");
                AccesoBase.InsertUpdateDatos($"DELETE FROM Intereses WHERE int_conceptocont = {CCC} AND int_periodo = '{Periodo}' AND int_coef = '{Coef}'");
            }
            CargarDGV(CCC);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //falta
        }

        private void dgvIntereses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIntereses.SelectedCells.Count > 0)
            {
                DataGridViewCell periodo = dgvIntereses.SelectedCells[0];
                DataGridViewCell coef = dgvIntereses.SelectedCells[1];

                if (periodo.Value != null && coef.Value != null)
                {
                    Periodo = periodo.Value.ToString();
                    Coef = coef.Value.ToString();
                }
            }
        }

        private void dgvIntereses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out double valor))
                {
                    string formato = "0.00000000000";
                    e.Value = valor.ToString(formato);
                    e.FormattingApplied = true;
                }
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
