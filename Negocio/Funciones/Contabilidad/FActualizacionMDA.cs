using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Contabilidad
{
    public class FActualizacionMDA
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
                        txtbusqueda = "WHERE mod_codigo LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE mod_codigo LIKE " + "'%" + txt.Text + "%'";
                    }
                    return txtbusqueda;
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE mod_descri LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE mod_descri LIKE " + "'%" + txt.Text + "%'";
                    }
                    return txtbusqueda;
                }
            }
            else
            {
                return "";
            }
            return "";
        }
        public static void Agregar(Form frm, string txt)
        {
            int ultimoID = Negocio.FGenerales.ultimoNumeroID("mod_codigo", "ModeloEncab");

            AccesoBase.InsertUpdateDatos($"INSERT INTO ModeloEncab(mod_codigo,mod_descri) VALUES ( '{ultimoID}', '{txt}' )");
            MessageBox.Show("Agregado Correctamente!", "Mensaje");
            frm.Close();
        }
        public static void Modificar(Form frm, string codigo, string txt)
        {
            AccesoBase.InsertUpdateDatos($"UPDATE ModeloEncab SET mod_descri = '{txt}' WHERE mod_codigo = '{codigo}'");
            MessageBox.Show("Modificado Correctamente!", "Mensaje");
            frm.Close();
        }
        public static void Eliminar(DataGridView DGV)
        {
            DialogResult boton = MessageBox.Show("¿Seguro que Desea Continuar?", "Mensaje", MessageBoxButtons.OKCancel);
            if (boton == DialogResult.OK)
            {
                int seleccion = DGV.CurrentCell.RowIndex;
                string codigo;
                if (seleccion > -1)
                {
                    codigo = DGV.Rows[seleccion].Cells[0].Value.ToString();
                    Datos.AccesoBase.InsertUpdateDatos($"DELETE FROM ModeloEncab WHERE mod_codigo = '{codigo}'");
                    MessageBox.Show("Eliminado correctamente!", "Mensaje");
                }
            }
        }

    }
}
