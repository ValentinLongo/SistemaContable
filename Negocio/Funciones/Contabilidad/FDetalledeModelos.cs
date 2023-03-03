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
using System.Web.Services.Description;
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

            if (debe != "0")
            {
               codigo = "1";
            }
            if (haber != "0")
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

        public static int AgregarAux_MovAsto(Form frm, string asiento, string cuenta, string debe, string haber, string concepto, string cc, string codigo, string terminal, string descri) 
        {
            //autoincremental
            int codigoAI = FGenerales.ultimoNumeroID("mva_cod", "Aux_MovAsto");
            asiento = FGenerales.ultimoNumeroID("ast_asiento", "Asiento").ToString();

            if (cc == "NINGUNO")
            {
                cc = "0";
            }

            double DEBE = Convert.ToDouble(debe);
            double HABER = Convert.ToDouble(haber);

            string query = "";
            string money = "";
            if (DEBE != 0)
            {
                money = debe.ToString();
                query = $"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES({terminal},{cuenta},'{descri}',*,0,'{concepto}',{codigoAI},'{asiento}',{cc})";
            }
            else if (HABER != 0)
            {
                money = haber.ToString();
                query = $"INSERT INTO Aux_MovAsto(mva_terminal, mva_cuenta, mva_descri, mva_debe, mva_haber, mva_concepto, mva_cod, mva_asiento, mva_cc) VALUES({terminal},{cuenta},'{descri}',0,*,'{concepto}',{codigoAI},'{asiento}',{cc})";

            }
            AccesoBase.InsertUpdateDatosMoney(query, money);

            MessageBox.Show("Agregado Correctamente!", "Mensaje");
            frm.Close();

            return Convert.ToInt32(asiento);
        }

        public static void Modificar(Form frm, string asiento, string txtcuenta, string debe, string haber, string concepto, string cc, string cuenta, string codigo2) 
        {
            string centrodecosto = cc;
            string fecha = DateTime.Now.ToString();
            string codigo = "0";
            string importe = "";

            if (debe != "0")
            {
                codigo = "1";
                importe = debe;
            }
            if (haber != "0")
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

        public static void ModificarAux_MovAsto(Form frm, string asiento, string cuenta, string debe, string haber, string concepto, string cc, string codigo, string terminal,string descri)
        {
            if (cc == "NINGUNO")
            {
                cc = "0";
            }

            double DEBE = Convert.ToDouble(debe);
            double HABER = Convert.ToDouble(haber);

            string query = "";
            string money = "";
            if (DEBE != 0)
            {
                money = debe.ToString();
                query = $"UPDATE Aux_MovAsto SET mva_terminal = '{terminal}', mva_cuenta = '{cuenta}', mva_descri = '{descri}', mva_debe = {"*"}, mva_haber = 0, mva_concepto = '{concepto}', mva_cc = '{cc}' WHERE mva_cod = '{codigo}'";
            }
            else if (HABER != 0)
            {
                money = haber.ToString();
                query = $"UPDATE Aux_MovAsto SET mva_terminal = '{terminal}', mva_cuenta = '{cuenta}', mva_descri = '{descri}', mva_debe = 0, mva_haber = {"*"}, mva_concepto = '{concepto}', mva_cc = '{cc}' WHERE mva_cod = '{codigo}'";

            }
            AccesoBase.InsertUpdateDatosMoney(query, money);

            MessageBox.Show("Modificado Correctamente!", "Mensaje");
            frm.Close();
        }
    }
}
