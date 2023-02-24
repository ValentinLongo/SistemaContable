﻿using CrystalDecisions.CrystalReports.Engine;
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
        public frmReporte(string NombreReporte, string Consulta, string Comando, string Titulo, string Param1, [Optional] string Param2, [Optional] string Param3, [Optional] string Param4)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cargarReporte(NombreReporte, Consulta, Comando, Titulo, Param1, Param2, Param3, Param4);
        }

        //Nombre Reporte = nombre reporte en la carpeta
        //Consulta = Query
        private void cargarReporte(string NombreReporte, string Consulta, string Comando, string Titulo, string Param1, [Optional] string Param2, [Optional] string Param3, [Optional] string Param4)
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

            // Crea un conjunto de datos en C#
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"{Consulta}");

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            // Asigna el conjunto de datos al informe de Crystal Reports
            report.SetDataSource(dt);
            if (Comando != "")
            {
                report.SetParameterValue(6, $"{Comando}");
            }
            report.SetParameterValue("Empresa", "Nombre Empresa");
            report.SetParameterValue("Titulo", $"{Titulo}");
            report.SetParameterValue("Param1", $"{Param1}");
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

            report.SetParameterValue("Usuario", $"{FLogin.NombreUsuario}");
            report.SetParameterValue("Hora", $"{DateTime.Now.ToString("t")}");

            // Actualiza el informe de Crystal Reports para que muestre los datos del conjunto de datos asignado
            crystalReportViewer1.ReportSource = report;
        }
    }
}
