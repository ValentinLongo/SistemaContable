using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Rubos_Contables
{
    public partial class frmRubrosContables : Form
    {
        public frmRubrosContables()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"select * from RubroCont");
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                string Codigo = dr[0].ToString();
                string Descripcion = dr[1].ToString();
                int Vigencia = Convert.ToInt32(dr[2].ToString());
                bool check = false;
                if (Vigencia == 1)
                {
                    check = true;
                }
                dgvRubrosContables.Rows.Add(Codigo,Descripcion,check);
            }
        }
    }
}
