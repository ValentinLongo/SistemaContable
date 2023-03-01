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
        public static void Agregar(Form frm, string asiento, string cuenta, string debe, string haber, string concepto, string cc) 
        {
            string centrodecosto = cc;
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
        public static void Modificar(Form frm, string asiento, string txtcuenta, string debe, string haber, string concepto, string cc, string cuenta, string codigo2) 
        {
            string centrodecosto = cc;
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

        public static void ModificarMovAsto(Form frm, string asiento, string txtcuenta, string debe, string haber, string concepto, string cc, string codigo2, string terminal)
        {
            string descri = "";
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta = '{txtcuenta}'");
            foreach (DataRow dr in ds.Tables[0].Rows) 
            {
                descri = dr["pcu_descri"].ToString();
            }

            string centrodecosto = cc;
            string codigo = "0";
            if (haber != "0,0000" || debe != "0,0000")
            {
                codigo = "102";
            }

            if (codigo == "0")
            {
                //AccesoBase.InsertUpdateDatos($"UPDATE MovAsto SET mva_fecha = '{fecha}', mva_cuenta = '{txtcuenta}', mva_codigo = '{codigo}', mva_importe = '{importe}', mva_comenta = '{concepto}', mva_cc = '{centrodecosto}' WHERE mva_asiento = '{asiento}' AND mva_cuenta = '{cuenta}' AND mva_codigo = '{codigo2}' ");
                AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES('{terminal}', '{txtcuenta}', '{descri}','{debe}', '{haber}', '{concepto}','{codigo2}','{asiento}','{centrodecosto}'");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES('{terminal}', '{txtcuenta}', '{descri}','{debe}', '{haber}', '{concepto}','{codigo2}','{asiento}','{centrodecosto}'");
            }

            AccesoBase.InsertUpdateDatos($"DELETE MovAsto WHERE ");

            MessageBox.Show("Modificado Correctamente!", "Mensaje");
            frm.Close();
        }

    }
}
