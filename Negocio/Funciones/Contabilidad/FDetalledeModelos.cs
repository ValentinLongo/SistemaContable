using Bunifu.UI.WinForms;
using Datos;
using Negocio.Funciones.Mantenimiento;
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
    public class FDetalledeModelos
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

        public static void Agregar(Form frm, string asiento, string cuenta, string codigo, string debe, string haber, string concepto, [Optional] string centrodecosto) 
        {
            centrodecosto = "0";
            string fecha = DateTime.Now.ToString();
            if (codigo == "1") 
            {
                AccesoBase.InsertUpdateDatos($"INSERT INTO ModeloDet ( det_asiento, det_fecha, det_cuenta, det_codigo, det_importe, det_comenta, det_cc ) VALUES ( '{asiento}', '{fecha}', '{cuenta}', '{codigo}', '{debe}', '{concepto}', '{centrodecosto}' )");
            }
            else if (codigo == "2")
            {
                AccesoBase.InsertUpdateDatos($"INSERT INTO ModeloDet ( det_asiento, det_fecha, det_cuenta, det_codigo, det_importe, det_comenta, det_cc ) VALUES ( '{asiento}', '{fecha}', '{cuenta}', '{codigo}', '{haber}', '{concepto}', '{centrodecosto}' )");
            }
            MessageBox.Show("Agregado Correctamente!", "Mensaje");
            frm.Close();

        }
    }
}
