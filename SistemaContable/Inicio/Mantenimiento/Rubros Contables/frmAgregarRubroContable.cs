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
                    if(Convert.ToInt32(dr["ruc_vigencia"].ToString()) == 1)
                    {
                        checkVigente.Checked = true;
                    }
                }
            }
            else
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
            }
        }
    }
}
