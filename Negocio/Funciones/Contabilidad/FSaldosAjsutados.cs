using Bunifu.UI.WinForms;
using Datos;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
                if (Ctrl is RJButton || Ctrl is ComboBox || Ctrl is BunifuCheckBox)
                {
                    Ctrl.Enabled = false;
                }
            }
        }

        public static void Habilitar(Form frm)
        {
            foreach (Control Ctrl in frm.Controls)
            {
                if (Ctrl is RJButton || Ctrl is ComboBox || Ctrl is BunifuCheckBox)
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

        //setea propiedades y limpia DGVs
        public static bool LimpiarDGVs(Form frm,[Optional] DataGridView dgv1, [Optional] DataGridView dgv2, [Optional] DataGridView footer) 
        {
            if (dgv1.DataSource != null)
            {
                return true;              
            }
            else
            {
                dgv1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns[0].HeaderText = "Cuenta";
                dgv1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns[1].HeaderText = "Descripción";
                dgv1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns[2].HeaderText = "Centro de Costo";
            }

            dgv2.Columns[0].HeaderText = "Periodo";
            dgv2.Columns[1].HeaderText = "Coeficiente";

            for (int i = 3; i < dgv1.Columns.Count; i++)
            {
                dgv1.Columns[i].DefaultCellStyle.Format = "0.00";
                dgv1.Columns[i].Width = 125;
                dgv1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            return false;
        }
    }
}
