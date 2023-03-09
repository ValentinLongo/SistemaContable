using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Libro_Mayor_Informe
{
    public partial class frmLibroMayorInforme : Form
    {
        public frmLibroMayorInforme()
        {
            InitializeComponent();
        }

        private void btnBuscarEjercicio_Click(object sender, EventArgs e)
        {
            frmBuscarEjercicioContable buscarEjercicioContable = new frmBuscarEjercicioContable();
            buscarEjercicioContable.ShowDialog();
            if (frmBuscarEjercicioContable.idEjercicioSelec > 0)
            {
                tbIdEjercicio.Text = frmBuscarEjercicioContable.idEjercicioSelec.ToString();
                tbDescriEjercicio.Text = frmBuscarEjercicioContable.descriEjercicioSelec;
            }
        }

        private void btnBuscarModelo_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultaGeneral = new frmConsultaGeneral("*", "Balance", "", "", "frmModelos");
            consultaGeneral.ShowDialog();
            if(Convert.ToInt32(frmConsultaGeneral.codigoCG) > 0)
            {
                tbIdModelo.Text = frmConsultaGeneral.codigoCG.ToString();
                tbDescriModelo.Text = frmConsultaGeneral.descripcionCG;
            }
        }
    }
}
