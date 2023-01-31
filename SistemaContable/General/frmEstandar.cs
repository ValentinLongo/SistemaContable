using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmEstandar : Form
    {
        public static int proceso; //indica la parte del codigo que se va a ejecutar.
        public static string mensaje1;
        public static string mensaje2;
        public frmEstandar()
        {
            InitializeComponent();
            MensajeControlBar.Text = mensaje1;
            MensajePrincipal.Text = mensaje2;

            if (proceso == 1)
            {
                PermisosMenu();
            }
        }

        private void PermisosMenu() 
        {
            DataSet ds = new DataSet();
            ds = Datos.AccesoBase.ListarDatos($"SELECT par_permiso FROM Parametro");
            foreach (DataRow dr in ds.Tables[0].Rows) 
            {
                int permiso = Convert.ToInt32(dr["par_permiso"]);
            }
            
            

        }
    }
}
