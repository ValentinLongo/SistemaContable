using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.DetalledeInformes
{
    public partial class frmAggDetalledeInformes : Form
    {
        private int opcion;
        public frmAggDetalledeInformes(int opcion)
        {
            InitializeComponent();
            this.opcion = opcion;
            if(opcion == 1)
            {
                lblControlBar.Text = "Modificar Detalle de Informes";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Cuenta");
            frmBuscarCuenta.ShowDialog();
            int idCuenta = frmBuscarCuenta.IdCuenta;
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT pcu_descri from PCuenta WHERE pcu_cuenta = {idCuenta}");
            foreach(DataRow ds2 in ds.Tables[0].Rows)
            {
                txtDescripcion.Text = ds2.ItemArray[0].ToString();
            }
        }
        
    }
}
