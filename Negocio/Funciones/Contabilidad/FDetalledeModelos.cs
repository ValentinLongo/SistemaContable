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
        public static void Agregar(Form frm, string asiento, string cuenta, string debe, string haber, string concepto, [Optional] string centrodecosto) 
        {
            centrodecosto = "0"; //falta (despues quitar opcional)
            string fecha = DateTime.Now.ToString();
            string codigo = "0";

            if (debe != "0,0000")
            {
               codigo = "1";
            }
            if (haber != "0,0000")
            {
               codigo = "2";
            }

            if (codigo == "1" || codigo == "0") 
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
        public static void Modificar(Form frm, string asiento, string txtcuenta, string debe, string haber, string concepto, [Optional] string centrodecosto, string cuenta, string codigo2) 
        {
            centrodecosto = "0"; //falta (despues quitar opcional)
            string fecha = DateTime.Now.ToString();
            string codigo = "0";
            string importe = "";

            if (debe != "0,0000")
            {
                codigo = "1";
                importe = debe;
            }
            if (haber != "0,0000")
            {
                codigo = "2";
                importe = haber;
            }

            if (codigo == "0")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE ModeloDet SET det_fecha = '{fecha}', det_cuenta = '{txtcuenta}', det_codigo = '{codigo}', det_importe = '{importe}', det_comenta = '{concepto}', det_cc = '{centrodecosto}' WHERE det_asiento = '{asiento}' AND det_cuenta = '{cuenta}' AND det_codigo = '{codigo2}' ");
            }
            else if (codigo == "1")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE ModeloDet SET det_fecha = '{fecha}', det_cuenta = '{txtcuenta}', det_codigo = '{codigo}', det_importe = '{debe}', det_comenta = '{concepto}', det_cc = '{centrodecosto}' WHERE det_asiento = '{asiento}' AND det_cuenta = '{cuenta}' AND det_codigo = '{codigo2}' ");
            }
            else if (codigo == "2")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE ModeloDet SET det_fecha = '{fecha}', det_cuenta = '{txtcuenta}', det_codigo = '{codigo}', det_importe = '{haber}', det_comenta = '{concepto}', det_cc = '{centrodecosto}' WHERE det_asiento = '{asiento}' AND det_cuenta = '{cuenta}' AND det_codigo = '{codigo2}' ");
            }
            MessageBox.Show("Modificado Correctamente!", "Mensaje");
            frm.Close();
        }

        public static void ModificarMovAsto(Form frm, string asiento, string txtcuenta, string debe, string haber, string concepto, [Optional] string centrodecosto, string cuenta, string codigo2)
        {
            centrodecosto = ""; //falta (despues quitar opcional)
            string fecha = DateTime.Now.ToString();
            string codigo = "0";
            string importe = "";

            if (debe != "0,0000")
            {
                codigo = "1";
                importe = debe;
            }
            if (haber != "0,0000")
            {
                codigo = "2";
                importe = haber;
            }

            if (codigo == "0")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE MovAsto SET mva_fecha = '{fecha}', mva_cuenta = '{txtcuenta}', mva_codigo = '{codigo}', mva_importe = '{importe}', mva_comenta = '{concepto}', mva_cc = '{centrodecosto}' WHERE mva_asiento = '{asiento}' AND mva_cuenta = '{cuenta}' AND mva_codigo = '{codigo2}' ");
            }
            else if (codigo == "1")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE MovAsto SET mva_fecha = '{fecha}', mva_cuenta = '{txtcuenta}', mva_codigo = '{codigo}', mva_importe = '{debe}', mva_comenta = '{concepto}', mva_cc = '{centrodecosto}' WHERE mva_asiento = '{asiento}' AND mva_cuenta = '{cuenta}' AND mva_codigo = '{codigo2}' ");
            }
            else if (codigo == "2")
            {
                AccesoBase.InsertUpdateDatos($"UPDATE MovAsto SET mva_fecha = '{fecha}', mva_cuenta = '{txtcuenta}', mva_codigo = '{codigo}', mva_importe = '{haber}', mva_comenta = '{concepto}', mva_cc = '{centrodecosto}' WHERE mva_asiento = '{asiento}' AND mva_cuenta = '{cuenta}' AND mva_codigo = '{codigo2}' ");
            }
            MessageBox.Show("Modificado Correctamente!", "Mensaje");
            frm.Close();
        }

    }
}
