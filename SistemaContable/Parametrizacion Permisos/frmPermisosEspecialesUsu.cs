﻿using SistemaContable.General;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TheArtOfDev.HtmlRenderer.Adapters;
using Datos;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms.VisualStyles;

namespace SistemaContable.Parametrizacion_Permisos
{
    public partial class frmPermisosEspecialesUsu : Form
    {
        string codigo = frmConsultaGeneral.codigoCG;
        string descri = frmConsultaGeneral.descripcionCG;
        public frmPermisosEspecialesUsu()
        {
            InitializeComponent();
            if (codigo != "" && descri != "")
            {
                txtNroUsuario.Text = codigo;
                txtDescriUsuario.Text = descri;
                txtNroUsuario.ReadOnly = true;
                txtDescriUsuario.ReadOnly = true;
                cbModulo.SelectedIndex = 0;
            }
            cargarDGV("","","");
        }

        public void cargarDGV(string modulobusqueda, string txtdescri, string estado) 
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT pef_codigo as Codigo, pef_modulo as Modulo, pef_descri as Descripcion, pxu_activo as Activo FROM PermisosxUsu LEFT JOIN Permisos ON pef_codigo = pxu_codigo AND pef_sistema = pxu_sistema  WHERE pef_sistema = 'CO' AND pxu_usuario = {codigo} {modulobusqueda} {txtdescri} ORDER BY pef_codigo");
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                bool check = false;
                var codigo2 = dr[0].ToString();
                var modulo = dr[1].ToString();
                var descri = dr[2].ToString();
                if (estado != "") 
                {
                    if (estado == "1")
                    {
                        check = true;
                    }
                }
                else
                {
                    int activo = Convert.ToInt32(dr[3].ToString());
                    if (activo == 1)
                    {
                        check = true;
                    }
                }
                dgvPEspeciales.Rows.Add(codigo2, modulo, descri, check);
            }
            //dgvPEspeciales.DataSource = data.Tables[0];
        }

        private void dgvPEspeciales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string codigo2 = (string)dgvPEspeciales.Rows[e.RowIndex].Cells[0].Value; //codigo2 = pxu_usuario de la tabla permisosxusu
            bool isCellChecked = (bool)dgvPEspeciales.Rows[e.RowIndex].Cells[3].Value;
            if (isCellChecked)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxUsu SET pxu_activo = '0' WHERE pxu_usuario = '{codigo}' AND pxu_codigo = '{codigo2}'  AND pxu_sistema = 'CO'");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxUsu SET pxu_activo = '1' WHERE pxu_usuario = '{codigo}' AND pxu_codigo = '{codigo2}' AND pxu_sistema = 'CO'");
            }
            dgvPEspeciales.Rows.Clear();
            cargarDGV("","","");
        }

        private void dgvPEspeciales_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvPEspeciales.IsCurrentCellDirty)
            {
                dgvPEspeciales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string modulobusqueda = cbModulo.Text;
            if (modulobusqueda == "TODOS")
            {
                modulobusqueda = "";
            }
            else
            {
                modulobusqueda = "AND pef_modulo = " + "'" + modulobusqueda + "'";
            }

            dgvPEspeciales.Rows.Clear();
            cargarDGV(modulobusqueda,"","");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                string txtdescri;

                if (CheckInicio.Checked)
                {
                    txtdescri = "AND pef_descri LIKE " + "'" + txtDescripcion.Text + "%'";
                }
                else
                {
                    txtdescri = "AND pef_descri LIKE " + "'%" + txtDescripcion.Text + "%'";
                }
                dgvPEspeciales.Rows.Clear();
                cargarDGV("", txtdescri,"");
            }
        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            dgvPEspeciales.Rows.Clear();
            cargarDGV("","","1");
        }

        private void btnSacarTodos_Click(object sender, EventArgs e)
        {
            dgvPEspeciales.Rows.Clear();
            cargarDGV("", "","0");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}