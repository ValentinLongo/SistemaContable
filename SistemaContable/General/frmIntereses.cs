using Datos;
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
        public frmIntereses(int CodConceptoContable)
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);

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

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

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
