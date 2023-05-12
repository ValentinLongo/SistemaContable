﻿using SistemaContable.General;
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

namespace SistemaContable.Usuarios
{
    public partial class frmAgregarCaja : Form
    {
        public frmAgregarCaja()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            cbBusqueda.SelectedIndex = 0;
            ShapeBusqueda.SendToBack();

            CargarDGV("");
        }

        private void CargarDGV(string busqueda)
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"select caj_codigo as Código, caj_descri as Descipción from Caja " + busqueda);
            dgvCajas.DataSource = data.Tables[0];

            Negocio.FGenerales.CantElementos(lblCantElementos, dgvCajas);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int seleccion = dgvCajas.CurrentCell.RowIndex;
            int idCaja;
            if (seleccion > -1)
            {
                idCaja = Convert.ToInt32(dgvCajas.Rows[seleccion].Cells[0].Value);
                DataSet data = new DataSet();
                data = Datos.AccesoBase.ListarDatos($"select caj_codigo as Caja, caj_descri as Descripcion, Moneda.mon_descri as Moneda, CajaxUsuario.cxu_predef as Predef from CajaxUsuario INNER JOIN Caja on CajaxUsuario.cxu_caja = Caja.caj_codigo INNER JOIN Usuario on CajaxUsuario.cxu_usuario = Usuario.usu_codigo INNER JOIN Moneda on Caja.caj_moneda = Moneda.mon_codigo WHERE CajaxUsuario.cxu_usuario = {Negocio.FLogin.IdUsuario} Order by caj_codigo");
                int predef;
                if (data.Tables[0].Rows.Count > 0)
                {
                    predef = 0;
                }
                else
                {
                    predef = 1;
                }
                DataSet data2 = new DataSet();
                data2 = Datos.AccesoBase.ListarDatos($"select * from CajaxUsuario where cxu_usuario = {Negocio.FLogin.IdUsuario} and cxu_caja = {idCaja}");
                if (data2.Tables[0].Rows.Count > 0)
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Caja ya habilitada para este usuario", false);
                    MessageBox.ShowDialog();
                }
                else
                {
                    Datos.AccesoBase.InsertUpdateDatos($"INSERT INTO CajaxUsuario(cxu_usuario,cxu_caja,cxu_predef) VALUES({Negocio.FLogin.IdUsuario},{idCaja},{predef})");
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Caja agregada correctamente", false);
                    MessageBox.ShowDialog();
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = "";
            if (cbBusqueda.Text == "Codigo")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "caj_codigo");
            }
            else if (cbBusqueda.Text == "Descripcion")
            {
                busqueda = Negocio.FGenerales.Busqueda(dgvAux, txtBusqueda.Text, CheckInicio, 1, "caj_descri");
            }
            CargarDGV(busqueda);
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
