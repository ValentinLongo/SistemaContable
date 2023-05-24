using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.General
{
    public partial class frmReporte : Form
    {
        public frmReporte(string NombreReporte, string Consulta, string Comando, string Titulo, [Optional] string Param1, [Optional] string Param2, [Optional] string Param3, [Optional] string Param4, [Optional] string Param5, [Optional] string Param6, [Optional] string Param7, [Optional] string Param8, [Optional] string Param9, [Optional] string Param10, [Optional] string Param11, [Optional] string Param12, [Optional] string Param13, [Optional] string Param14, [Optional] string Param15, [Optional] string Folio, [Optional] string campo1, [Optional] string campo2, [Optional] string campo3, [Optional] string campo4)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            if (NombreReporte != "Libro IVA 2")
            {
                cargarReporte(NombreReporte, Consulta, Comando, Titulo, Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13, Param14, Param15);
            }
            else
            {
                CargarReporteRubSub(NombreReporte, Folio, campo1, campo2, campo3, campo4);
            }
        }

        //Nombre Reporte = nombre reporte en la carpeta
        //Consulta = Query
        private void cargarReporte(string NombreReporte, string Consulta, string Comando, string Titulo, string Param1, [Optional] string Param2, [Optional] string Param3, [Optional] string Param4, [Optional] string Param5, [Optional] string Param6, [Optional] string Param7, [Optional] string Param8, [Optional] string Param9, [Optional] string Param10, [Optional] string Param11, [Optional] string Param12, [Optional] string Param13, [Optional] string Param14, [Optional] string Param15)
        {
            // Crea un objeto de informe de Crystal Reports
            ReportDocument report = new ReportDocument();

            // Carga el informe externo en el objeto de informe de Crystal Reports
            report.Load($@"..\..\Reportes\{NombreReporte}.rpt");

            // Configura la conexión de datos de Crystal Reports
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = $@"{FLogin.Servidor}";
            connectionInfo.DatabaseName = $"{FLogin.BaseDeDatos}";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "1220";
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = connectionInfo;
            foreach (Table table in report.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            //Crea un conjunto de datos en C#
            if (Consulta != "")
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"{Consulta}");

                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                // Asigna el conjunto de datos al informe de Crystal Reports
                report.SetDataSource(dt);

                if (report.Subreports.Count != 0)
                {
                    ReportDocument subreport = report.Subreports[0];

                    foreach (Table table in subreport.Database.Tables)
                    {
                        table.ApplyLogOnInfo(tableLogOnInfo);
                    }
                }
            }

            if (Comando != "")
            {
                report.SetParameterValue("Cons", $"{Comando}");
            }
            report.SetParameterValue("Empresa", $"{FLogin.NombreEmpresa}");
            report.SetParameterValue("Titulo", $"{Titulo}");
            if (Param1 != null)
            {
                report.SetParameterValue("Param1", $"{Param1}");
            }           
            if (Param2 != null)
            {
                report.SetParameterValue("Param2", $"{Param2}");
            }
            if (Param3 != null)
            {
                report.SetParameterValue("Param3", $"{Param3}");
            }
            if (Param4 != null)
            {
                report.SetParameterValue("Param4", $"{Param4}");
            }
            if (Param5 != null)
            {
                report.SetParameterValue("Param5", $"{Param5}");
            }
            if (Param6 != null)
            {
                report.SetParameterValue("Param6", $"{Param6}");
            }
            if (Param7 != null)
            {
                report.SetParameterValue("Param7", $"{Param7}");
            }
            if (Param8 != null)
            {
                report.SetParameterValue("Param8", $"{Param8}");
            }
            if (Param9 != null)
            {
                report.SetParameterValue("Param9", $"{Param9}");
            }
            if (Param10 != null)
            {
                report.SetParameterValue("Param10", $"{Param10}");
            }
            if (Param11 != null)
            {
                report.SetParameterValue("Param11", $"{Param11}");
            }
            if (Param12 != null)
            {
                report.SetParameterValue("Param12", $"{Param12}");
            }
            if (Param13 != null)
            {
                report.SetParameterValue("Param13", $"{Param13}");
            }
            if (Param14 != null)
            {
                report.SetParameterValue("Param14", $"{Param14}");
            }
            if (Param15 != null)
            {
                report.SetParameterValue("Param15", $"{Param15}");
            }

            report.SetParameterValue("Usuario", $"{FLogin.NombreUsuario}");
            report.SetParameterValue("Hora", $"{DateTime.Now.ToString("t")}");

            // Actualiza el informe de Crystal Reports para que muestre los datos del conjunto de datos asignado
            crystalReportViewer1.ReportSource = report;
        }

        private void CargarReporteRubSub(string NombreReporte, string Folio, string Campo1, string Campo2, string Campo3, string Campo4) //Para el reporte de Rubricación de Subdiarios
        {
            // Crea un objeto de informe de Crystal Reports
            ReportDocument report = new ReportDocument();

            // Carga el informe externo en el objeto de informe de Crystal Reports
            report.Load($@"..\..\Reportes\{NombreReporte}.rpt");

            report.SetParameterValue("Folio", Convert.ToInt32(Folio));
            report.SetParameterValue("Campo1", Campo1);
            report.SetParameterValue("Campo2", Campo2);
            report.SetParameterValue("Campo3", Campo3);
            report.SetParameterValue("Campo4", Campo4);

            // Actualiza el informe de Crystal Reports para que muestre los datos del conjunto de datos asignado
            crystalReportViewer1.ReportSource = report;
        }

    }
}
