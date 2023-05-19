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
    public partial class frmReporte2 : Form
    {
        public frmReporte2(string NombreReporte, int Folio, [Optional] string Campo1, [Optional] string Campo2, [Optional] string Campo3, [Optional] string Campo4)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cargarReporte(NombreReporte,Folio, Campo1, Campo2, Campo3, Campo4);
        }
        private void cargarReporte(string NombreReporte, int Folio, [Optional] string Campo1, [Optional] string Campo2, [Optional] string Campo3, [Optional] string Campo4)
        {
            // Crea un objeto de informe de Crystal Reports
            ReportDocument report = new ReportDocument();

            // Carga el informe externo en el objeto de informe de Crystal Reports
            report.Load($@"..\..\Reportes\{NombreReporte}.rpt");

            report.SetParameterValue("Folio", Folio);
            report.SetParameterValue("Campo1", Campo1);
            report.SetParameterValue("Campo2", Campo2);
            report.SetParameterValue("Campo3", Campo3);
            report.SetParameterValue("Campo4", Campo4);

            // Actualiza el informe de Crystal Reports para que muestre los datos del conjunto de datos asignado
            crystalReportViewer1.ReportSource = report;
        }
    }
}
