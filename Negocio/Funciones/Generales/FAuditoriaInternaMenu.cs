using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Generales
{
    public class FAuditoriaInternaMenu
    {
      
        public static double Cotizacion(DataSet ds, string col) // obtiene la cotizacion.
        {
            if (ds.Tables[0].Rows[0][col] is DBNull)
            {
                return 1;
            }
            else
            {
                return Convert.ToDouble(ds.Tables[0].Rows[0][col]);
            }
        }

        public static void Delete(int terminal) // delete Aux_Asiento (porque se repite mucho).
        {
            AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");
        }

        public static void Update(int terminal) // update Aux_Asiento (porque se repite mucho).
        {
            AccesoBase.InsertUpdateDatos($"Update Aux_Asiento Set aux_importe = Round(aux_importe,2) Where aux_terminal = {terminal}");
        }

        public static void InsertAux(int terminal, int asiento, string fecha, long cuenta, int codigo, string money, string comenta, int orden, [Optional] int cc) // Insert Aux_Asiento (porque se repite mucho).
        {
            if (cc.ToString() == "")
            {
                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden) Values ({terminal}, {asiento}, '{fecha}', {cuenta}, {codigo}, {"*"}, '{comenta}', {orden})", money);
            }
            else
            {
                AccesoBase.InsertUpdateDatosMoney($"Insert Into Aux_Asiento (aux_terminal, aux_asiento, aux_fecha, aux_cuenta, aux_codigo, aux_importe, aux_comenta, aux_orden, aux_cc) Values ({terminal}, {asiento}, '{fecha}', {cuenta}, {codigo}, {"*"}, '{comenta}', {orden}, {cc})", money);
            }
        }

        public static long Insert(int terminal, string fecha, string comenta, int codigo, int nro, int tipocbte, string cpbte, int ctapro) // Insert Asiento y MovAsto, tambien retorna el asiento final (porque se repite mucho).
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select Max(ast_asiento) as maximo From Asiento");
            long Asiento = ds.Tables[0].Rows[0]["maximo"] is DBNull ? 1 : Convert.ToInt32(ds.Tables[0].Rows[0]["maximo"]) + 1;

            ds = AccesoBase.ListarDatos($"Select * From TipMov Where tmo_codigo = 16");
            string Abreviado = ds.Tables[0].Rows[0]["tmo_abrev"].ToString();
            comenta = comenta.Replace("Abreviado", Abreviado);

            AccesoBase.InsertUpdateDatos($"Insert Into Asiento (ast_asiento, ast_renumera, ast_fecha, ast_comenta, ast_codigo, ast_numero, ast_tipocbte, ast_cbte, ast_ctapro, ast_user, ast_hora, ast_fecalta, ast_tipo) Values ({Asiento}, {Asiento}, '{fecha}', '{comenta}', {codigo}, {nro}, {tipocbte}, '{cpbte}', {ctapro}, '{FLogin.NombreUsuario}', '{DateTime.Now.ToString().Substring(DateTime.Now.ToString().Length - 8)}', '{DateTime.Now.ToString().Substring(0, 10)}', 2)");
            AccesoBase.InsertUpdateDatos($"Insert Into MovAsto (mva_asiento, mva_fecha, mva_cuenta, mva_codigo, mva_importe, mva_comenta) Select {Asiento} as Asto, '{fecha}' as Fec, aux_cuenta, aux_codigo, aux_importe, aux_comenta From Aux_Asiento Where aux_terminal = {terminal}");
            AccesoBase.InsertUpdateDatos($"Delete From Aux_Asiento Where aux_terminal = {terminal}");

            return Asiento;
        }

        public static double Diferencia(int terminal, int d, int h) // devuelve la diferencia entre debe y haber.
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {d} Group By aux_codigo");
            double debe = ds.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["total"]);

            ds = AccesoBase.ListarDatos($"Select aux_codigo, sum(aux_importe) as total From Aux_Asiento Where aux_terminal = {terminal} And aux_codigo = {h} Group By aux_codigo");
            double haber = ds.Tables[0].Rows[0]["total"] is DBNull ? 0 : Convert.ToDouble(ds.Tables[0].Rows[0]["total"]);

            double dif = debe - haber;
            return dif;
        }

        public static bool Balanceado(int terminal)
        {
            double A = 0;
            double B = 0;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"Select Sum(aux_importe) as A From Aux_Asiento Where aux_codigo = 1 And aux_terminal = {terminal}");
            if (ds.Tables[0].Rows.Count != 0)
            {
                A = Convert.ToDouble(ds.Tables[0].Rows[0]["A"]);
            }

            ds = AccesoBase.ListarDatos($"Select Sum(aux_importe) as B From Aux_Asiento Where aux_codigo = 2 And aux_terminal = {terminal}");
            if (ds.Tables[0].Rows.Count != 0)
            {
                B = Convert.ToDouble(ds.Tables[0].Rows[0]["B"]);
            }

            return A != B ? true : false;
        }

        public static bool FiltroSeccion() // "validacion".
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_FiltroSeccion FROM Parametro");

            if ((ds.Tables[0].Rows[0]["par_FiltroSeccion"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_FiltroSeccion"])) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

        public static bool FechaCont() // "validacion".
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_FechaCont FROM Parametro");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            if ((ds.Tables[0].Rows[0]["par_FechaCont"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_FechaCont"])) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
        public static bool ConceptoACuenta() // "validacion".
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT par_ConceptoACuenta FROM Parametro");
            if ((ds.Tables[0].Rows[0]["par_ConceptoACuenta"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["par_ConceptoACuenta"])) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
