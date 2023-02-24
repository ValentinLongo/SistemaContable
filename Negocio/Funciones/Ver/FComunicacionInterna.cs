using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio.Funciones.Ver
{
    public class FComunicacionInterna
    {
        public static void VerMSGs(DataGridView dgv, Label nuevomsg)
        {
            int seleccionado = dgv.CurrentCell.RowIndex;

            if (seleccionado != -1)
            {
                string horaL = DateTime.Now.ToLongTimeString();
                string fechaL = DateTime.Now.ToShortDateString();

                string fecha = dgv.Rows[seleccionado].Cells[0].Value.ToString();
                string hora = dgv.Rows[seleccionado].Cells[1].Value.ToString();
                string origen = dgv.Rows[seleccionado].Cells[2].Value.ToString();
                string destino = dgv.Rows[seleccionado].Cells[3].Value.ToString();

                AccesoBase.InsertUpdateDatos($"UPDATE Observaciones SET obs_Estado = 1, obs_fechaL = '{fechaL}', obs_horaL = '{horaL}' WHERE obs_fecha = '{fecha}' AND obs_hora = '{hora}' AND obs_origen = '{origen}' AND obs_nomdest = '{destino}'");

                if (NuevosMSGs() == false)
                {
                    nuevomsg.Visible = false;
                }

            }
        }

        public static bool NuevosMSGs()
        {
            string estado = "";
            bool flag = false;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT obs_estado FROM Observaciones WHERE obs_destino = " + FLogin.IdUsuario);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                estado = dr["obs_estado"].ToString();

                if (estado == "0")
                {
                    flag = true;
                }
            }

            if (flag)
            {
                return true;
            }

            return false;
        }
    }
}
