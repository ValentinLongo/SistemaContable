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
    public class FActualizacionDDI
    {
        public static void Agregar(Form frm, string txt)
        {
            int ultimoID = Negocio.FGenerales.ultimoNumeroID("bal_codigo", "Balance");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Balance(bal_codigo,bal_descri) VALUES ( '{ultimoID}', '{txt}' )");
            frm.Close();
        }

        public static void Modificar(Form frm, string codigo, string txt)
        {
            AccesoBase.InsertUpdateDatos($"UPDATE Balance SET bal_descri = '{txt}' WHERE bal_codigo = '{codigo}'");
            frm.Close();
        }

        public static void Eliminar(DataGridView DGV)
        {
            int seleccion = DGV.CurrentCell.RowIndex;
            string codigo;
            if (seleccion > -1)
            {
                codigo = DGV.Rows[seleccion].Cells[0].Value.ToString();
                Datos.AccesoBase.InsertUpdateDatos($"DELETE FROM Balance WHERE bal_codigo = '{codigo}'");
            }
        }
    }
}
