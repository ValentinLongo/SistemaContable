using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Evento = evento;
            cargarDatos();
        }

        private void cargarDatos()
        {
            maskPeriodo.Mask = "##/####";
            if (Evento == "Modificar")
            {
                maskPeriodo.Text = frmCoeficienteDeAjuste.periodoModificar;
                tbCoeficiente.Text = frmCoeficienteDeAjuste.coeficienteModificar.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool validaFecha = validarFecha();
            if (validaFecha && Evento == "Agregar")
            {
                try
                {
                    AccesoBase.InsertUpdateDatos($"INSERT INTO DetAjusteInf(aji_ejercicio, aji_periodo,aji_coef,aji_usualta,aji_fecalta,aji_horaalta) values({frmCoeficienteDeAjuste.codigoEjercicio},'{maskPeriodo.Text}',{tbCoeficiente.Text},{FLogin.IdUsuario},'{DateTime.Now.ToString("d")}','{DateTime.Now.ToString("T")}')");
                    MessageBox.Show("Modificado con éxito");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
            if (validaFecha && Evento == "Modificar")
            {
                try
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE DetAjusteInf SET aji_periodo = '{maskPeriodo.Text}', aji_coef = {tbCoeficiente.Text}, aji_usumodi = {FLogin.IdUsuario}, aji_fecmodi = '{DateTime.Now.ToString("d")}', aji_horamodi = '{DateTime.Now.ToString("T")}' WHERE aji_ejercicio = {frmCoeficienteDeAjuste.codigoEjercicio}");
                    MessageBox.Show("Modificado con éxito");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }

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
    }
}
