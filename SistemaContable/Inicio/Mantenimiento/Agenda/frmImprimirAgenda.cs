using Datos;
using Datos.Modelos;
using Negocio;
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

namespace SistemaContable.Inicio.Mantenimiento.Agenda
{
    public partial class frmImprimirAgenda : Form
    {
        private int CodPos1 = 0;
        private int CodPos2 = 0;
        private int idActividad = 0;
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

            ds = AccesoBase.ListarDatos("SELECT * FROM Localidad ORDER BY loc_nombre");
            cbLocalidad.Items.Add("TODAS");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                cbLocalidad.Items.Add(dr["loc_nombre"]);
            }
            cbActividad.SelectedIndex = 0;
            cbLocalidad.SelectedIndex = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(cbActividad.SelectedIndex > 0)
            {
                idActividad = FAgenda.buscarIdActividad(cbActividad.Text);
            }
            else
            {
                idActividad = 0;
            }
            if(cbLocalidad.SelectedIndex > 0)
            {
                buscarIdLocalidad(cbLocalidad.Text);
            }
            else
            {
                CodPos1 = 0;
                CodPos2 = 0;
            }
            string query = FAgenda.armarQuery(idActividad,CodPos1,CodPos2);

            frmReporte reporte = new frmReporte("Agenda",query,"","Agenda del Sistema", "TODOS",cbActividad.Text,cbLocalidad.Text,"");
            reporte.ShowDialog();
        }


       private void buscarIdLocalidad(string descripcion)
        {
            DataSet ds = AccesoBase.ListarDatos($"SELECT * FROM Localidad WHERE loc_nombre = '{descripcion}'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CodPos1 = Convert.ToInt32(dr["loc_cod1"].ToString());
                CodPos2 = Convert.ToInt32(dr["loc_cod2"].ToString());
            }
        }
    }
}
