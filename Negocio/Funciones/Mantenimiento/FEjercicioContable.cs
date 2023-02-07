using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Mantenimiento
{
    public class FEjercicioContable
    {
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
                    Datos.AccesoBase.InsertUpdateDatos($"DELETE FROM Ejercicio WHERE eje_codigo = '{codigo}'");
                    MessageBox.Show("Eliminado correctamente!", "Mensaje");
                    DGV.Rows.Clear();
                }
            }
        }

        public static void EstadoCheckBox(DataGridView DGV,string codigo, bool estado) 
        {
            if (estado)
            {
                DialogResult boton2 = MessageBox.Show("Atención: El ejercicio contable se encuentra cerrado. ¿Desea abrirlo?", "Contable", MessageBoxButtons.OKCancel);
                if (boton2 == DialogResult.OK)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Ejercicio SET eje_cerrado = '0' WHERE eje_codigo = '{codigo}'");
                }
            }
            else
            {
                DialogResult boton2 = MessageBox.Show("Atención: El ejercicio contable se encuentra abierto. ¿Desea cerrarlo?", "Contable", MessageBoxButtons.OKCancel);
                if (boton2 == DialogResult.OK)
                {
                    AccesoBase.InsertUpdateDatos($"UPDATE Ejercicio SET eje_cerrado = '1' WHERE eje_codigo = '{codigo}'");
                }
            }
            DGV.Rows.Clear();
        }

        public static string Busqueda(DataGridView DGV,TextBox txt,ComboBox cbBusqueda,BunifuCheckBox cbInicio)
        {
            if (txt.Text != "")
            {
                string txtbusqueda;

                if (cbBusqueda.SelectedIndex == 0)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE eje_codigo LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE eje_codigo LIKE " + "'%" + txt.Text + "%'";
                    }
                    DGV.Rows.Clear();
                    return txtbusqueda;
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE eje_descri LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE eje_descri LIKE " + "'%" + txt.Text + "%'";
                    }
                    DGV.Rows.Clear();
                    return txtbusqueda;
                }
                else if (cbBusqueda.SelectedIndex == 2)
                {
                    if (cbInicio.Checked)
                    {
                        txtbusqueda = "WHERE eje_desde LIKE " + "'" + txt.Text + "%'";
                    }
                    else
                    {
                        txtbusqueda = "WHERE eje_desde LIKE " + "'%" + txt.Text + "%'";
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
    }
}
