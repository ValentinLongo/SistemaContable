using Negocio.Funciones;
using SistemaContable.General;
using SistemaContable.Rubos_Contables;
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

namespace SistemaContable.Rubros_Contables
{
    public partial class frmAgregarRubroContable : Form
    {
        public static string Operacion;
        FRubrosContables data = new FRubrosContables();
        public frmAgregarRubroContable(string operacion)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Operacion = operacion;
            CargarDatos();
        }

        private void CargarDatos()
        {
            maskDesde.Mask = "00.00.00.00.00";
            maskHasta.Mask = "00.00.00.00.00";
            if (Operacion == "Modificar")
            {
                DataSet ds = new DataSet();
                ds = data.RubroContableParticular(frmRubrosContables.codigoRubro);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    tbCodigo.Text = dr["ruc_codigo"].ToString();
                    tbNombre.Text = dr["ruc_descri"].ToString();
                    maskDesde.Text = dr["ruc_desde"].ToString();
                    maskHasta.Text = dr["ruc_hasta"].ToString();
                    if (Convert.ToInt32(dr["ruc_vigencia"].ToString()) == 1)
                    {
                        checkVigente.Checked = true;
                    }
                }
            }
            else
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
                maskDesde.Text = "00.00.00.00.00";
                maskHasta.Text = "00.00.00.00.00";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                string desde = maskDesde.Text.Replace(",", ".");
                string hasta = maskHasta.Text.Replace(",", ".");
                int vigencia = 0;
                if (checkVigente.Checked == true)
                {
                    vigencia = 1;
                }
                if (desde.Length == 14 && hasta.Length == 14)
                {
                    if (Operacion == "Modificar")
                    {
                        data.ModificarRubroContable(Convert.ToInt32(tbCodigo.Text), tbNombre.Text, vigencia, desde, hasta);
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado con éxito", false);
                        MessageBox.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        data.AgregarRubroContable(tbNombre.Text, vigencia, desde, hasta);
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado con éxito", false);
                        MessageBox.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar los campos (Desde y Hasta) correctamente antes de continuar", false, true);
                    MessageBox.ShowDialog();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
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
    }
}
