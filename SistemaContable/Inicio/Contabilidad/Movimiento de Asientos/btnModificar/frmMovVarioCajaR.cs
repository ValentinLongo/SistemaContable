using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos;
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

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmMovVarioCajaR : Form
    {
        private static int terminal = frmLogin.NumeroTerminal;

        public static bool confirmó = false;

        private static string TipoCaja;
        private static string TipMov;
        private static string Tipo;
        private static string Codigo;
        private static string Fecha;

        public frmMovVarioCajaR(Form frm, string msgControlBar, string cpbte, string descri, string comentario, string fecha, string tipocaja, string tipmov, string tipo, string codigo)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            lblControlBar.Text = msgControlBar;

            TipoCaja = tipocaja;
            TipMov = tipmov;
            Tipo = tipo;
            Codigo = codigo;
            Fecha = fecha;

            Seteo(frm, cpbte, descri, comentario);
        }

        private void Seteo(Form frm, string cpbte, string descri, string comentario)
        {
            if (frm.Name == "frmAsientosContables")
            {
                txtCPBTE1.Text = cpbte.Substring(0, 1);
                txtCPBTE2.Text = cpbte.Substring(1, 4);
                txtCPBTE3.Text = cpbte.Substring(cpbte.Length - 8);
                txtDescri.Text = descri;
                txtComentario.Text = comentario;

                txtCPBTE1.Enabled = false;
                txtCPBTE2.Enabled = false;
                txtCPBTE3.Enabled = false;
                txtDescri.Enabled = false;
                txtComentario.Enabled = false;
            }

            CargarDGV();
        }

        private void CargarDGV()
        {
            if (dgvMovVario.Rows.Count != 0)
            {
                dgvMovVario.Rows.Clear();
            }

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Aux_MovVarioCaja WHERE aux_terminal = {terminal}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int cuenta = Convert.ToInt32(dr["aux_cta"]);
                string descri = dr["aux_descri"].ToString();
                string importe = dr["aux_importe"].ToString();
                string comentario = dr["aux_comentario"].ToString();
                string orden = dr["aux_orden"].ToString();

                dgvMovVario.Rows.Add(cuenta, descri, importe, comentario, orden);
            }
            SeteoFooter(dgvMovVario, footer);
            ActualizarFooter();
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvMovVario);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirmó = true;

            Cursor.Current = Cursors.WaitCursor;

            int seleccionado = dgvMovVario.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                if (Convert.ToDouble(dgvMovVario.Rows[seleccionado].Cells[2].Value) == 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá indicar un Importe.", false);
                    MessageBox.ShowDialog();
                }
            }         

            AccesoBase.InsertUpdateDatos($"Delete From MovVario Where va1_movim = {Codigo}");

            AccesoBase.InsertUpdateDatos($"Insert Into MovVario (va1_codigo, va1_numero, va1_tipmov, va1_cpbte, va1_fecha, va1_cta, va1_comentario, va1_importe, va1_movim, va1_orden) SELECT {Tipo} as T, 0 as N, {TipMov} as Tip, '{txtCPBTE1.Text + txtCPBTE2.Text + "-" + txtCPBTE3.Text}' as cpbte, '{Fecha}', aux_cta, aux_comentario, aux_importe, {Codigo} As C, aux_orden From Aux_MovVarioCaja Where aux_terminal = {terminal}");

            Cursor.Current = Cursors.Default;

            frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El Movimiento ha sido Registrado.", false);
            MessageBox1.ShowDialog();

            AccesoBase.InsertUpdateDatos($"Delete From Aux_MovVarioCaja Where aux_terminal = {terminal}");

            this.Close();
        }

        private void dgvMovVario_DoubleClick(object sender, EventArgs e)
        {
            int seleccionado = dgvMovVario.CurrentCell.RowIndex;
            if (seleccionado != -1)
            {
                string cuenta = dgvMovVario.Rows[seleccionado].Cells[0].Value.ToString();
                string descri = dgvMovVario.Rows[seleccionado].Cells[1].Value.ToString();
                string importe = dgvMovVario.Rows[seleccionado].Cells[2].Value.ToString();
                string comentario = dgvMovVario.Rows[seleccionado].Cells[3].Value.ToString();
                string orden = dgvMovVario.Rows[seleccionado].Cells[4].Value.ToString();

                frmDetMovVarioCajaR frm = new frmDetMovVarioCajaR(this, cuenta, descri, importe, comentario, orden, lblControlBar.Text);
                frm.ShowDialog();

                if (frmDetMovVarioCajaR.confirmó == false)
                {
                    return;
                }
                frmDetMovVarioCajaR.confirmó = false;

                CargarDGV();
            }
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
            double Total = 0;

            foreach (DataGridViewRow fila in dgvMovVario.Rows)
            {
                if (fila.Cells[2].Value != null)
                {
                    double valor = Convert.ToDouble(fila.Cells[2].Value);
                    Total += valor;
                }
            }

            if (dgvMovVario.Rows.Count != 0)
            {
                footer.Columns[1].HeaderText = "Totales:";
                footer.Columns[2].HeaderText = Total == 0 ? "0,00" : Math.Round(Total, 2).ToString();
            }
            else
            {
                footer.Columns[1].HeaderText = "Totales:";
                footer.Columns[2].HeaderText = "0,00";
            }
        }
        private void dgvAddModVisASIENTO_Scroll(object sender, ScrollEventArgs e) //sincroniza el scroll del dgv con el footer
        {
            if (dgvMovVario.HorizontalScrollingOffset == e.NewValue)
            {
                footer.HorizontalScrollingOffset = e.NewValue;
            }

            bool scrollVerticalActivo = dgvMovVario.DisplayedRowCount(false) < dgvMovVario.RowCount;
            if (scrollVerticalActivo)
            {
                if (dgvMovVario.Rows.Count != 0)
                {
                    if (Negocio.FGenerales.SincronizarFooter(dgvMovVario))
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
