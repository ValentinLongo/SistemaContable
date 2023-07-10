using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables.Intereses
{
    public partial class frmAggModInteres : Form
    {
        public frmAggModInteres(int proceso)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            Seteo(proceso);
        }

        private void Seteo(int proceso)
        {           
            maskPeriodo.Mask = "00/0000";
            maskCoef.Mask = "0.0000000000";
            maskCoef.Text = "1.0000000000";

            if (proceso == 1)
            {
                lblControlBar.Text = "Agregar Interes";
            }
            else if (proceso == 2)
            {
                lblControlBar.Text = "Modificar Interes";
                maskPeriodo.Text = frmIntereses.Periodo;
                string formato = "0.0000000000";
                maskCoef.Text = Convert.ToDouble(frmIntereses.Coef).ToString(formato);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0) //validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Faltan campos de Completar.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (validarPeriodo() == false)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Periodo Ingresado No es Valido.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (Convert.ToDouble(maskCoef.Text) <= 0) //validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Coeficiente no puede ser Cero(0)", false);
                MessageBox.ShowDialog();
                return;
            }

            if (lblControlBar.Text == "Agregar Interes")
            {
                AccesoBase.InsertUpdateDatosMoney($"INSERT INTO Intereses (int_conceptocont, int_periodo, int_coef) VALUES ({frmIntereses.CCC}, '{maskPeriodo.Text}', '{"*"}')", maskCoef.Text);
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente!", false);
                MessageBox.ShowDialog();
            }
            else if (lblControlBar.Text == "Modificar Interes")
            {
                string CoefAntes = frmIntereses.Coef.Replace(",", ".");

                AccesoBase.InsertUpdateDatosMoney($"UPDATE Intereses SET int_periodo = '{maskPeriodo.Text}', int_coef = '{"*"}' WHERE int_conceptocont = {frmIntereses.CCC} AND int_periodo = '{frmIntereses.Periodo}' AND int_coef = '{CoefAntes}'", maskCoef.Text);
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente!", false);
                MessageBox.ShowDialog();
            }
            this.Close();
        }

        private bool validarPeriodo()
        {
            int mes = Convert.ToInt32(maskPeriodo.Text.Substring(0, 2));
            int año = Convert.ToInt32(maskPeriodo.Text.Substring(3, 4));

            if (maskPeriodo.Text.Length == 7)
            {
                if (mes >= 1 && mes <= 12)
                {
                    return true;
                }
                return false;
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
