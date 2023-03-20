using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio.Funciones.Mantenimiento
{
    public class FCentrodeCostos
    {
        public static string Busqueda(DataGridView DGV, TextBox txt, ComboBox cbBusqueda, BunifuCheckBox cbInicio)
        {
            if (txt.Text != "")
            {
                string txtbusqueda;

                if (cbBusqueda.SelectedIndex == 0)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE cec_codigo LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE cec_codigo LIKE " + "'%" + txt.Text + "%'";
                    }
                    DGV.Rows.Clear();
                    return txtbusqueda;
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE cec_descri LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE cec_descri LIKE " + "'%" + txt.Text + "%'";
                    }
                    DGV.Rows.Clear();
                    return txtbusqueda;
                }
            }
            else
            {
                DGV.Rows.Clear();
                return "";
            }
            return "";
        }

        public static void Agregar(Form frm, string txt)
        {
            int ultimoID = Negocio.FGenerales.ultimoNumeroID("cec_codigo", "CentroC");

            AccesoBase.InsertUpdateDatos($"INSERT INTO CentroC(cec_codigo,cec_descri,cec_predef) VALUES ( '{ultimoID}', '{txt}', 0 )");
            frm.Close();
        }

        public static void Modificar(Form frm, string codigo, string txt)
        {
            AccesoBase.InsertUpdateDatos($"UPDATE CentroC SET cec_descri = '{txt}' WHERE cec_codigo = '{codigo}'");
            frm.Close();
        }

        public static void Eliminar(DataGridView DGV)
        {
            int seleccion = DGV.CurrentCell.RowIndex;
            string codigo;
            if (seleccion > -1)
            {
                codigo = DGV.Rows[seleccion].Cells[0].Value.ToString();
                Datos.AccesoBase.InsertUpdateDatos($"DELETE FROM CentroC WHERE cec_codigo = '{codigo}'");
                DGV.Rows.Clear();
            }
        }
    }
}
