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
            if(Evento == "Modificar")
            {
                maskPeriodo.Text = frmCoeficienteDeAjuste.periodoModificar;
                tbCoeficiente.Text = frmCoeficienteDeAjuste.coeficienteModificar.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool validaFecha = validarFecha();
        }

        public bool validarFecha()
        {
            if(maskPeriodo.Text.Length == 7)
            {
                return true;
            }
        }
    }
}
