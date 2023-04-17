using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Usuario");
            dgv1.DataSource = ds.Tables[0];
            dgvFooter(dgv1, dgv2);

            //DataSet ds2 = new DataSet();
            //ds2 = AccesoBase.ListarDatos($"SELECT * FROM Usuario WHERE usu_codigo = 1");
            //dgv2.DataSource = ds2.Tables[0];
            //dgv2.BringToFront();
        }

        private void dgvFooter(DataGridView dgv1, DataGridView dgv2) 
        {
            //sincronizar dgvs
        }

        private void dgv1_Scroll(object sender, ScrollEventArgs e)
        {
            dgv2.HorizontalScrollingOffset = e.NewValue;
        }

        private void dgv2_Scroll(object sender, ScrollEventArgs e)
        {
            dgv1.HorizontalScrollingOffset = e.NewValue;
        }
    }
}
