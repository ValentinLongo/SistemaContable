﻿using Datos.Modelos;
using Negocio.Funciones.Mantenimiento;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Coeficiente_de_ajuste
{
    public partial class frmCoeficienteDeAjuste : Form
    {
        FCoeficienteDeAjuste data = new FCoeficienteDeAjuste();
        int check;

        public static int codigoEjercicio;

        //datos de los coeficientes
        public static int codigoCoeficiente;
        public static string periodoModificar;
        public static string coeficienteModificar;

        public frmCoeficienteDeAjuste()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            check = 0;
            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvEjercicios.Rows.Clear();

            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            mCoeficienteDeAjuste = data.listaEjercicios(check);
            foreach (var datos in mCoeficienteDeAjuste)
            {
                bool cerrado = false;
                if (datos.eje_cerrado == 1)
                {
                    cerrado = true;
                }
                dgvEjercicios.Rows.Add(datos.eje_codigo, datos.eje_descri, datos.eje_desde, datos.eje_hasta, cerrado);
            }
            Negocio.FGenerales.CantElementos(lblCantElementos, dgvCoeficientes);
        }

        private void checkEjerciciosAbiertos_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (checkEjerciciosAbiertos.Checked)
            {
                check = 0;
            }
            else
            {
                check = 1;
            }
            CargarDGV();
        }

        private void dgvEjercicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEjercicios.Rows.Count == 0)
            {
                return;
            }
            if (dgvEjercicios.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvEjercicios.SelectedCells[0];
                codigoEjercicio = Convert.ToInt32(Celda.Value);
                DataSet ds = data.listaCoeficientes(codigoEjercicio);
                dgvCoeficientes.DataSource = ds.Tables[0];
            }
        }

        private void dgvCoeficientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCoeficientes.Rows.Count == 0)
            {
                return;
            }
            if (dgvCoeficientes.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvCoeficientes.SelectedCells[0];
                periodoModificar = Celda.Value.ToString();

                DataGridViewCell Celda2 = dgvCoeficientes.SelectedCells[1];
                coeficienteModificar = Celda2.Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Negocio.Funciones.Mantenimiento.FCoeficienteDeAjuste.ValidacionAsientoAjusteInf(codigoEjercicio))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ya se ha registrado por lo menos un Asiento de Ajuste por Inflacion en este Ejercicio. No podra realizar alteraciones en los Coeficientes.", false, true);
                MessageBox.ShowDialog();
                return;
            }

            frmAgregarCoeficienteAjuste agregarCoeficienteAjuste = new frmAgregarCoeficienteAjuste("Agregar");
            agregarCoeficienteAjuste.ShowDialog();
            CargarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Negocio.Funciones.Mantenimiento.FCoeficienteDeAjuste.ValidacionAsientoAjusteInf(codigoEjercicio))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ya se ha registrado por lo menos un Asiento de Ajuste por Inflacion en este Ejercicio. No podra realizar alteraciones en los Coeficientes.", false, true);
                MessageBox.ShowDialog();
                return;
            }

            frmAgregarCoeficienteAjuste agregarCoeficienteAjuste = new frmAgregarCoeficienteAjuste("Modificar");
            agregarCoeficienteAjuste.ShowDialog();
            CargarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Negocio.Funciones.Mantenimiento.FCoeficienteDeAjuste.ValidacionAsientoAjusteInf(codigoEjercicio))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Ya se ha registrado por lo menos un Asiento de Ajuste por Inflacion en este Ejercicio. No podra realizar alteraciones en los Coeficientes.", false, true);
                MessageBox.ShowDialog();
                return;
            }

            try
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Continuar?", true);
                MessageBox.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    data.eliminarCoeficiente(periodoModificar);
                    CargarDGV();
                }
            }
            catch
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Error", false);
                MessageBox.ShowDialog();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                CargarDGV();
                return;
            }

            dgvEjercicios.Rows.Clear();
            List<MCoeficienteDeAjuste> mCoeficienteDeAjuste = new List<MCoeficienteDeAjuste>();
            mCoeficienteDeAjuste = data.ejercicioParticular(check, txtBusqueda.Text);
            foreach (var datos in mCoeficienteDeAjuste)
            {
                bool cerrado = false;
                if (datos.eje_cerrado == 1)
                {
                    cerrado = true;
                }
                dgvEjercicios.Rows.Add(datos.eje_codigo, datos.eje_descri, datos.eje_desde.Substring(0, 10), datos.eje_hasta.Substring(0, 10), cerrado);
            }
        }

        private void dgvCoeficientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out double valor))
                {
                    string formato = "0.00000000000";
                    e.Value = valor.ToString(formato);
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvCoeficientes.Rows.Count == 0)
            {
                return;
            }

            string query = $"SELECT aji_periodo, aji_coef, usu_nombre as UsuAlta, aji_fecalta, aji_horaalta, aji_usumodi as UsuModi, aji_fecmodi, aji_horamodi FROM DetAjusteInf LEFT JOIN Usuario on aji_usualta = usu_codigo WHERE aji_ejercicio = {codigoEjercicio}";

            frmReporte freporte = new frmReporte("DetAjusteInf",query, "", "Coeficientes de Ajuste", Negocio.FGenerales.NombreEjercicio(codigoEjercicio), DateTime.Now.ToShortDateString());
            freporte.ShowDialog();
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
