﻿using Datos;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Agenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Agenda
{
    public partial class frmAgenda : Form
    {
        public static int IdModificar;
        public frmAgenda()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cargarDGV("");
        }

        private void cargarDGV(string Nombre)
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaAgenda(Nombre);
            dgvAgenda.DataSource = ds.Tables[0];

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvAgenda);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda("Agregar");
            frmAgregarAgenda.ShowDialog();
            cargarDGV("");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAgregarAgenda frmAgregarAgenda = new frmAgregarAgenda("Modificar");
            frmAgregarAgenda.ShowDialog();
            cargarDGV("");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "¿Desea Continuar?", true);
                MessageBox.ShowDialog();
                if (frmMessageBox.Acepto)
                {
                    AccesoBase.InsertUpdateDatos($"DELETE FROM Agenda WHERE age_codigo = {IdModificar}");
                    cargarDGV("");
                }
            }
            catch
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Ocurrio un error", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            if (dgvAgenda.Rows.Count == 0)
            {
                return;
            }

            frmImprimirAgenda imprimirAgenda = new frmImprimirAgenda();
            imprimirAgenda.ShowDialog();
        }

        private void dgvAgenda_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgenda.Rows.Count == 0)
            {
                return;
            }
            if (dgvAgenda.SelectedCells.Count > 0)
            {
                DataGridViewCell Celda = dgvAgenda.SelectedCells[0];
                IdModificar = Convert.ToInt32(Celda.Value);               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargarDGV(tbDescipcion.Text);
        }

        private void frmAgenda_Resize(object sender, EventArgs e)
        {
            Negocio.FGenerales.MinimizarMDIchild(this);
        }
    }
}
