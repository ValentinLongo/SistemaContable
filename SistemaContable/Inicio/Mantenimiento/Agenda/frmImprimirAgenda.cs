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
            cbActividad.DataSource = ds.Tables[0];
            cbActividad.DisplayMember = "act_descri";
            cbActividad.ValueMember = "act_codigo";


            ds = AccesoBase.ListarDatos("SELECT * FROM Localidad");
            cbLocalidad.DataSource = ds.Tables[0];
            cbLocalidad.DisplayMember = "loc_nombre";
            cbLocalidad.ValueMember = "loc_cod1";
        }
    }
}
