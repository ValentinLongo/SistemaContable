﻿using Datos;
using Negocio.Funciones.Mantenimiento;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.LibroMayor
{
    public partial class frmLibroMayor : Form
    {
        public frmLibroMayor()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM CentroC");
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cbCentroCosto.DataSource = ds.Tables[0];
                    cbCentroCosto.ValueMember = "cec_codigo";
                    cbCentroCosto.DisplayMember = "cec_descri";
                }
            }
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

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if (frmBuscarCuenta.IdCuenta > 0)
            {
                tbIdCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = frmBuscarCuenta.DescriCuenta;
            }
        }
    }
}
