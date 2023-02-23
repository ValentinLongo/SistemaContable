using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Agenda
{
    public partial class frmImprimirAgenda : Form
    {
        public frmImprimirAgenda()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM Actividad");
            cbActividad.Items.Add("TODAS");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbActividad.Items.Add(dr["act_descri"]);
            }



            ds = AccesoBase.ListarDatos("SELECT * FROM Localidad");
            cbLocalidad.Items.Add("TODAS");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                cbLocalidad.Items.Add(dr["loc_nombre"]);
            }
        }
    }
}
