using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

namespace SistemaContable.Inicio.Mantenimiento.Parametros_Contables
{
    public partial class frmParametrosContables : Form
    {
        public frmParametrosContables()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM ParamContab");
            //int indice = 0;
            //int indiceInterno = 0;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    foreach (Control Ctrl in this.Controls)
            //    {
            //        if (Ctrl is TextBox)
            //        {
            //            if (indice == indiceInterno)
            //            {
            //                Ctrl.Text = dr[indice].ToString();
            //                indiceInterno++;
            //            }
            //        }
                    
            //    }
            //    indice++;
            //}
        }
    }
}
