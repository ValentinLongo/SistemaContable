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

namespace SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste
{
    public partial class frmAgregarCoeficienteAjuste : Form
    {
        public string Evento;
        public frmAgregarCoeficienteAjuste(string evento)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Evento = evento;
            cargarDatos();
        }

        private void cargarDatos()
        {
            maskPeriodo.Mask = "00/0000";
            if (Evento == "Modificar")
            {
                maskPeriodo.Text = frmCoeficienteDeAjuste.periodoModificar;
                tbCoeficiente.Text = frmCoeficienteDeAjuste.coeficienteModificar.ToString();
                maskPeriodo.Enabled = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                bool validaFecha = validarFecha();
                if (validaFecha && Evento == "Agregar")
                {
                    try
                    {
                        AccesoBase.InsertUpdateDatos($"INSERT INTO DetAjusteInf(aji_ejercicio, aji_periodo,aji_coef,aji_usualta,aji_fecalta,aji_horaalta) values({frmCoeficienteDeAjuste.codigoEjercicio},'{maskPeriodo.Text}',{tbCoeficiente.Text},{FLogin.IdUsuario},'{DateTime.Now.ToString("d")}','{DateTime.Now.ToString("T")}')");
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado con éxito", false);
                        MessageBox.ShowDialog();
                        this.Close();
                    }
                    catch
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Error", false);
                        MessageBox.ShowDialog();
                    }
                }
                if (validaFecha && Evento == "Modificar")
                {
                    try
                    {
                        AccesoBase.InsertUpdateDatos($"UPDATE DetAjusteInf SET aji_coef = {tbCoeficiente.Text}, aji_usumodi = {FLogin.IdUsuario}, aji_fecmodi = '{DateTime.Now.ToString("d")}', aji_horamodi = '{DateTime.Now.ToString("T")}' WHERE aji_ejercicio = {frmCoeficienteDeAjuste.codigoEjercicio} and aji_periodo = '{maskPeriodo.Text}'");
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado con éxito", false);
                        MessageBox.ShowDialog();
                        this.Close();
                    }
                    catch
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Error", false);
                        MessageBox.ShowDialog();
                    }
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }

        public bool validarFecha()
        {
            if (maskPeriodo.Text.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
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
