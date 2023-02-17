using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmReporte : Form
    {
        public frmReporte(string NombreReporte, string Consulta)
        {
            InitializeComponent();
            cargarReporte(NombreReporte,Consulta);
        }
        //Nombre Reporte = nombre reporte en la carpeta
        //Consulta = Query
        private void cargarReporte(string NombreReporte, string Consulta)
        {
            // Crea un objeto de informe de Crystal Reports
            ReportDocument report = new ReportDocument();

            // Carga el informe externo en el objeto de informe de Crystal Reports
            report.Load($@"C:\Pedidos\REPORTES\{NombreReporte}.rpt");

            // Configura la conexión de datos de Crystal Reports
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = @"SERVERMASER\MASER_INF";
            connectionInfo.DatabaseName = "CoronelApp";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "1220";
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = connectionInfo;
            foreach (Table table in report.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            // Crea un conjunto de datos en C#
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"{Consulta}");

            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            // Asigna el conjunto de datos al informe de Crystal Reports
            report.SetDataSource(dt);

            // Actualiza el informe de Crystal Reports para que muestre los datos del conjunto de datos asignado
            crystalReportViewer1.ReportSource = report;
        }
    }
}
