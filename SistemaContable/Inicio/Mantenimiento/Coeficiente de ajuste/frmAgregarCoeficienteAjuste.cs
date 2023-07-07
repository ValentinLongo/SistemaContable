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
                bool validaFecha = validarPeriodo();
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

        public bool validarPeriodo()
        {
            int mes = Convert.ToInt32(maskPeriodo.Text.Substring(0, 2));
            int año = Convert.ToInt32(maskPeriodo.Text.Substring(3, 4));

            if (maskPeriodo.Text.Length == 7)
            {
                if (mes >= 1 && mes <= 12)
                {
                    if (año == AñoEjercicio(frmCoeficienteDeAjuste.codigoEjercicio))
                    {
                        DataSet ds = new DataSet();
                        int resultado = AccesoBase.ValidarDatos($"select aji_periodo from DetAjusteInf where aji_periodo = '{maskPeriodo.Text}'");
                        if (resultado == 0)
                        {
                            return true;
                        }
                        else
                        {
                            frmMessageBox Mensaje1 = new frmMessageBox("Mensaje", "Atención: El Coeficiente ya se ha definido para el ejercicio y periodo indicado.", false, true);
                            Mensaje1.ShowDialog();
                            return false;
                        }
                    }
                }

                frmMessageBox Mensaje2 = new frmMessageBox("Mensaje", "Atención: El Periodo Ingresado No se encuetra dentro de los parametros del Ejercicio.", false, true);
                Mensaje2.ShowDialog();
                return false;
            }
            else
            {
                return false;
            }
        }

        private int AñoEjercicio(int NroEjercicio)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"select eje_desde from Ejercicio where eje_codigo = {NroEjercicio}");
            int año = Convert.ToInt32(ds.Tables[0].Rows[0]["eje_desde"].ToString().Substring(6, 4));
            return año;
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
