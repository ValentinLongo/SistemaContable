﻿using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
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

namespace SistemaContable.Inicio.Contabilidad.Definicion_de_Informes.Detalle_de_Modelos
{
    public partial class frmAddModDetdeModelos : Form
    {
        private int agg_o_mod;
        private string Cuenta;
        public static DataGridView DGV1;
        public static DataGridView DGV2;

        //Para utilizar el frm desde otro (sin seleccionar nada en dgv)
        public static bool desdeotrofrm = false;
        public static string asientofrm;
        public static string cuentafrm;
        public static string codigofrm;

        public frmAddModDetdeModelos(int aggmod,string cuenta,string descri,string debe,string haber,string concepto,string centrodecosto)
        {
            InitializeComponent();
            agg_o_mod = aggmod;

            txtDebe.Text = "0,0000";
            txtHaber.Text = "0,0000";

            if (agg_o_mod == 0)
            {
                lblControlBar.Text = "Agregar Detalle de Modelo";
            }
            else if (agg_o_mod == 1)
            {
                lblControlBar.Text = "Modificar Detalle de Modelo";

                Cuenta = cuenta;
                txtCuenta.Text = cuenta;
                txtDescri.Text = descri;
                txtDebe.Text = debe;
                txtHaber.Text = haber;
                txtConcepto.Text = concepto;
                cbCentrodeCosto.Text = "NINGUNO"; //falta
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string asiento;
            int seleccionado;
            int contador = 0;

            if (Convert.ToDecimal(txtDebe.Text) > 0)
            {
                contador++;
            }
            else
            {
                txtDebe.Text = "0,0000";
            }
            if (Convert.ToDecimal(txtHaber.Text) > 0)
            {
                contador++;
            }
            else
            {
                txtHaber.Text = "0,0000";
            }

            if (contador != 2)
            {
                if (agg_o_mod == 0)
                {
                    seleccionado = DGV1.CurrentCell.RowIndex;
                    asiento = DGV1.Rows[seleccionado].Cells[0].Value.ToString();

                    Negocio.Funciones.Contabilidad.FDetalledeModelos.Agregar(this, asiento, txtCuenta.Text, txtDebe.Text, txtHaber.Text, txtConcepto.Text, cbCentrodeCosto.SelectedText);
                }
                else if (agg_o_mod == 1)
                {
                    if (desdeotrofrm)
                    {
                        Negocio.Funciones.Contabilidad.FDetalledeModelos.ModificarMovAsto(this, asientofrm, txtCuenta.Text, txtDebe.Text, txtHaber.Text, txtConcepto.Text, cbCentrodeCosto.SelectedText, cuentafrm, codigofrm);
                        desdeotrofrm = false;
                    }
                    else
                    {
                        seleccionado = DGV1.CurrentCell.RowIndex;
                        asiento = DGV1.Rows[seleccionado].Cells[0].Value.ToString();

                        Negocio.Funciones.Contabilidad.FDetalledeModelos.Modificar(this, asiento, txtCuenta.Text, txtDebe.Text, txtHaber.Text, txtConcepto.Text, cbCentrodeCosto.SelectedText, Cuenta, frmDetalledeModelos.Codigo);
                    }
                }
            }
            else
            {
                MessageBox.Show("Atención: Ingrese datos en debe o en haber!","Mensaje");
                this.Close();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta buscarcuenta = new frmBuscarCuenta("Cuenta");
            buscarcuenta.ShowDialog();
            int cuenta = frmBuscarCuenta.IdCuenta;
            if (cuenta != 0)
            {
                txtCuenta.Text = cuenta.ToString();
            }
            frmBuscarCuenta.IdCuenta = 0;
        }

        private void txtHaber_Click(object sender, EventArgs e)
        {
            if (txtHaber.Text == "0,0000")
            {
                txtHaber.Text = "";
            }
        }
        private void txtHaber_Leave(object sender, EventArgs e)
        {
            if (txtHaber.Text == "")
            {
                txtHaber.Text = "0,0000";
            }
        }
        private void txtDebe_Click(object sender, EventArgs e)
        {
            if (txtDebe.Text == "0,0000")
            {
                txtDebe.Text = "";
            }
        }
        private void txtDebe_Leave(object sender, EventArgs e)
        {
            if (txtDebe.Text == "")
            {
                txtDebe.Text = "0,0000";
            }
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
