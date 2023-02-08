﻿using Datos.Modelos;
using Negocio;
using Negocio.Funciones.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Mantenimiento.Conceptos_Contables
{
    public partial class frmAgregarConceptoContable : Form
    {
        private string Accion;
        FConceptosContables data = new FConceptosContables();
        public frmAgregarConceptoContable(string accion)
        {
            InitializeComponent();
            Accion = accion;
            cargarDatos();
        }

        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = data.listaCentroC();
            if (ds.Tables.Count > 0)
            {
                cbCentroCostos1.DataSource = ds.Tables[0];
                cbCentroCostos1.DisplayMember = "cec_descri";
                cbCentroCostos1.ValueMember = "cec_codigo";

                cbCentroCostos2.DataSource = ds.Tables[0];
                cbCentroCostos2.DisplayMember = "cec_descri";
                cbCentroCostos2.ValueMember = "cec_codigo";
            }
            else
            {
                cbCentroCostos1.Text = "NINGUNO";
                cbCentroCostos2.Text = "NINGUNO";
            }
            MConceptoContable mConceptoContable = new MConceptoContable();
            if (Accion == "Agregar")
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
            }
            if (Accion == "Modificar")
            {
                tbCodigo.Text = frmConceptosContables.Codigo.ToString();
                mConceptoContable = data.conceptoContableParticular(frmConceptosContables.Codigo);
                tbDescripción.Text = mConceptoContable.coc_descri;
                tbNroCuenta.Text = mConceptoContable.coc_ctacont.ToString();
                tbDescriCuenta.Text = mConceptoContable.pcu_descriCuenta;
                tbNumContrapartida.Text = mConceptoContable.coc_contrap.ToString();
                tbDescriContrapartida.Text = mConceptoContable.pcu_descriContrap;
                cbCentroCostos1.SelectedItem = mConceptoContable.coc_cccta;
                cbCentroCostos2.SelectedItem = mConceptoContable.coc_cccontrap;
                if (mConceptoContable.coc_vta == 1)
                {
                    checkVentas.Checked = true;
                }
                if (mConceptoContable.coc_cpa == 1)
                {
                    checkCompras.Checked = true;
                }
                if (mConceptoContable.coc_caja == 1)
                {
                    checkTesoreria.Checked = true;
                }
                if (mConceptoContable.coc_banco == 1)
                {
                    checkBancos.Checked = true;
                }
                
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Cuenta");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdCuenta);
            if (descripcion != "")
            {
                tbNroCuenta.Text = frmBuscarCuenta.IdCuenta.ToString();
                tbDescriCuenta.Text = descripcion;
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscarCuenta = new frmBuscarCuenta("Contrapartida");
            frmBuscarCuenta.ShowDialog();
            string descripcion = data.descripcionCuenta(frmBuscarCuenta.IdContrapartida);
            if (descripcion != "")
            {
                tbNumContrapartida.Text = frmBuscarCuenta.IdContrapartida.ToString();
                tbDescriContrapartida.Text = descripcion;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MConceptoContable mConceptoContable = new MConceptoContable()
            {
                coc_codigo = FGenerales.ultimoNumeroID("coc_codigo", "ConceptoCont"),
                coc_descri = tbDescripción.Text,
                coc_vta = 0,
                coc_cpa = 0,
                coc_caja = 0,
                coc_banco = 0,
                coc_ctacont = Convert.ToInt32(tbNroCuenta.Text),
                pcu_descriCuenta = tbDescriCuenta.Text,
                coc_contrap = Convert.ToInt32(tbNumContrapartida.Text),
                pcu_descriContrap = tbDescriContrapartida.Text,
                coc_cccontrap = Convert.ToInt32(cbCentroCostos2.SelectedValue),
                coc_cccta = Convert.ToInt32(cbCentroCostos1.SelectedValue),
            };
            if (checkVentas.Checked)
            {
                mConceptoContable.coc_vta = 1;
            }
            if (checkCompras.Checked)
            {
                mConceptoContable.coc_cpa = 1;
            }
            if (checkTesoreria.Checked)
            {
                mConceptoContable.coc_caja = 1;
            }
            if (checkBancos.Checked)
            {
                mConceptoContable.coc_banco = 1;
            }
            if(Accion == "Agregar")
            {
                data.agregarConceptoCont(mConceptoContable);
                MessageBox.Show("Agregado Correctamente");
                this.Close();
            }
            if(Accion == "Modificar")
            {
                mConceptoContable.coc_codigo = Convert.ToInt32(tbCodigo.Text);
                data.modificarConceptoCont(mConceptoContable);
                MessageBox.Show("Modificado Correctamente");
                this.Close();
            }
        }
    }
}
