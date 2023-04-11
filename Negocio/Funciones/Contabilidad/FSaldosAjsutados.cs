using Bunifu.UI.WinForms;
using Datos;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Contabilidad
{
    public class FSaldosAjsutados
    {
        public static void Deshabilitar(Form frm) 
        {
            foreach (Control Ctrl in frm.Controls)
            {
                if (Ctrl is RJButton || Ctrl is Label || Ctrl is ComboBox || Ctrl is BunifuCheckBox)
                {
                    Ctrl.Enabled = false;
                }
            }
        }

        public static void Habilitar(Form frm) 
        {
            foreach (Control Ctrl in frm.Controls)
            {
                if (Ctrl is RJButton || Ctrl is Label || Ctrl is ComboBox || Ctrl is BunifuCheckBox)
                {
                    Ctrl.Enabled = true;
                }
            }
        }

        public static int Busca_Clave(string nombre, string tabla, string pref) 
        {
            int retorno = 0;
            string query = $"SELECT * FROM " + tabla + " WHERE " + pref + "_descri = '" + nombre + "'";

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"{query}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                retorno = Convert.ToInt32(dr[pref + "_codigo"]);
            }
            return retorno;
        }


    }
}
