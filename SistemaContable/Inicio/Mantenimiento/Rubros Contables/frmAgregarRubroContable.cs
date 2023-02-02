using Negocio.Funciones;
using SistemaContable.Rubos_Contables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Operacion = operacion;
            CargarDatos();
        }

        private void CargarDatos()
        {
            maskDesde.Mask = "##.##.##.##.##";
            maskHasta.Mask = "##.##.##.##.##";
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
                    MessageBox.Show("Modificado con éxito");
                    this.Close();
                }
                else
                {
                    data.AgregarRubroContable(tbNombre.Text, vigencia, desde, hasta);
                    MessageBox.Show("Agregado con éxito");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos correctamente antes de continuar");
            }
        }
    }
}
