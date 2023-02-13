using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoBase
    {
        //Cambiar por la base de datos que pidan
        // Data Source=, ESTE VALOR REPRESENTA EL NOMBRE DEL SERVIDOR QUE APARECE EN EL MANAGEMENT STUDIO
        // Initial Catalog=, AQUI SE COLOCA EL NOMBRE DE LA BASE DE DATOS
        // Integrated Security=, REPRESENTA SI TIENE INTEGRADA SEGURIDAD, DEJAR EN TRUE (UTILIZA LA VALIDACION DE WINDOWS)
        //private static string datosConexion = @"Data Source=DESKTOP-E314JV2\SQLEXPRESS;Initial Catalog=db_testconnect;Integrated Security=true";
        //public static string datosConexion = @"Data Source = SERVERMASER\MASER_INF;Initial Catalog = CoronelApp; User ID = sa; Password=1220;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=true";
        private static SqlConnection sqlConec = new SqlConnection();
        public static string datosConexion = "";

        #region [Metodos Publicos]

        // ESTA FUNCION SE UTILIZA PARA LISTA DATOS DE UNA BASE, LO CUAL VA A DEVOLVER UN DATASET
        // PARA LUEGO INSERTARLO EN UNA GRILLA (DATAGRIDVIEW)
        public static DataSet ListarDatos(string strSQL)
        {
            try
            {
                DataSet oData = new DataSet();
                AbrirBD();
                SqlDataAdapter oAdap = new SqlDataAdapter(strSQL, sqlConec);
                oAdap.Fill(oData, "Registros");
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarBD();
            }
        }

        public static DataSet ListarDatosPaginado(string strSQL,int scollVal)
        {
            try
            {
                DataSet oData = new DataSet();
                AbrirBD();
                SqlDataAdapter oAdap = new SqlDataAdapter(strSQL, sqlConec);
                oAdap.Fill(oData,scollVal,100, "Registros");
                return oData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarBD();
            }
        }

        // ESTA FUNCION LA USAMOS PARA VERIFICAR SI EXISTE UN DATO EN LA BASE
        // POR EJEMPLO PARA HACER UN LOGIN, O VERIFICAR SI EXISTE UN REGISTRO ANTES DE INSERTARLO
        // SI EL REGISTRO A VALIDAR EXISTE DEVUELVE INT = 1 SINO INT = -1
        public static Int32 ValidarDatos(string strSQL)
        {
            try
            {
                SqlCommand cmd = null;
                AbrirBD();
                cmd = new SqlCommand(strSQL, sqlConec);
                if (cmd.ExecuteScalar() != null) return 1;
                else return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarBD();
            }
        }

        // ESTA FUNCION SE USA PARA HACER INSERTS Y UPDATES A LA BASE DE DATOS,
        // SI EL REGISTRO SE INSERTA O ACTUALIZA CON EXITO DEVUELVE UN INT = 1, SINO UN INT = -1
        public static int InsertUpdateDatos(string queryString)
        {
            SqlCommand command = null;
            try
            {
                AbrirBD();
                command = new SqlCommand(queryString, sqlConec);
                return command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                return -1;
            }
            catch (Exception exs)
            {
                return -1;
            }
            finally
            {
                if (sqlConec.State != System.Data.ConnectionState.Closed)
                {
                    CerrarBD();
                }
            }
        }
        #endregion

        #region [Metodos Privado usados en los Metodos Publicos]
        private static SqlConnection AbrirBD()
        {
            try
            {
                sqlConec.ConnectionString = datosConexion;
                sqlConec.Open();
                return sqlConec;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private static void CerrarBD()
        {
            try
            {
                sqlConec.Close();
                sqlConec.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
