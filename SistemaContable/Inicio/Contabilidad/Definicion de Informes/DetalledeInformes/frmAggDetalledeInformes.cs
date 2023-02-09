using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
