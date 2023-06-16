using Datos.Modelos;
using SistemaContable.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Plan_de_Cuentas
{
    public partial class frmAggModCuenta : Form
    {
        int PROCESO;

        public frmAggModCuenta(int proceso) // proceso 1 = Agregar y proceso 2 = Modificar
        {
            InitializeComponent();

            PROCESO = proceso;

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDatos(proceso);
        }

        private void CargarDatos(int proceso)
        {
            DataSet ds = new DataSet();

            if (proceso == 1)
            {
                ds = Negocio.FPlanDeCuentas.Rubros();
                cbRubro.DataSource = ds.Tables[0];
                cbRubro.DisplayMember = "ruc_descri";
                cbRubro.ValueMember = "ruc_codigo";

                tbCodigo.Mask = "00.00.00.00.00.00";

                tbCuenta.Text = Convert.ToString(Negocio.FPlanDeCuentas.UltimoNumeroCuenta());
            }
            else if (proceso == 2)
            {
                ds = Negocio.FPlanDeCuentas.Rubros();
                cbRubro.DataSource = ds.Tables[0];
                cbRubro.DisplayMember = "ruc_descri";
                cbRubro.ValueMember = "ruc_codigo";

                DataSet ds2 = new DataSet();
                ds2 = Negocio.FPlanDeCuentas.BusquedaCuentaPorCuenta(frmPlanDeCuentas.idCuenta);
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    tbCodigo.Text = dr2["pcu_codigo"].ToString();
                    tbCuenta.Text = dr2["pcu_cuenta"].ToString();
                    tbDescripcion.Text = dr2["pcu_descri"].ToString();
                    try
                    {
                        string rubrocont = dr2["pcu_rubrocont"].ToString();
                        cbRubro.SelectedValue = Convert.ToInt32(rubrocont);
                    }
                    catch
                    {
                        cbRubro.Text = "";
                    }

                    if (dr2["pcu_ajustainf"].ToString() != "" && dr2["pcu_ajustainf"].ToString() != "0")
                    {
                        CheckAjuste.Checked = true;
                    }
                    int estado = Convert.ToInt32(dr2["pcu_estado"].ToString());
                    cbEstado.SelectedIndex = estado - 1;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) != 0 || tbCodigo == null)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Falta completar campos.", false);
                MessageBox.ShowDialog();
                return;
            }

            if (PROCESO == 1)
            {
                try
                {
                    string codigoElegido = tbCodigo.Text;
                    int ajusta = 0;
                    if (CheckAjuste.Checked == true)
                    {
                        ajusta = 1;
                    }

                    //Datos
                    MPlanDeCuentas mPlanDeCuentas = new MPlanDeCuentas()
                    {
                        pcu_codigo = codigoCuenta(),
                        pcu_cuenta = Convert.ToInt32(tbCuenta.Text),
                        pcu_descri = tbDescripcion.Text,
                        pcu_superior = cuentaSuperior(),
                        pcu_hija = 0,
                        pcu_tabulador = Negocio.FPlanDeCuentas.tabulador(codigoElegido),
                        pcu_estado = Convert.ToInt32(cbEstado.SelectedIndex + 1),
                        pcu_rubrocont = Convert.ToInt32(cbRubro.SelectedValue),
                        pcu_ajustainf = ajusta
                    };

                    //Validacion codigo
                    string code = codigoCuenta();
                    if (code != "00.00.00.00.00.00")
                    {
                        //INSERT
                        Negocio.FPlanDeCuentas.agregarPlanDeCuentas(mPlanDeCuentas);

                        //Establezco los hijos de la cuenta superior
                        Negocio.FPlanDeCuentas.cantidadHijos(mPlanDeCuentas.pcu_superior);
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Cargado Correctamente!", false);
                        MessageBox.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Falta completar campos", false);
                        MessageBox.ShowDialog();
                    }
                }
                catch
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Ocurrio un Error", false);
                    MessageBox.ShowDialog();
                }
            }
            else if (PROCESO == 2)
            {
                try
                {
                    int check = 0;
                    if (CheckAjuste.Checked)
                    {
                        check = 1;
                    }
                    MPlanDeCuentas mPlanDeCuentas = new MPlanDeCuentas()
                    {
                        pcu_codigo = tbCodigo.Text,
                        pcu_descri = tbDescripcion.Text,
                        pcu_estado = Convert.ToInt32(cbEstado.SelectedIndex + 1),
                        pcu_rubrocont = Convert.ToInt32(cbRubro.SelectedValue),
                        pcu_ajustainf = check
                    };
                    Negocio.FPlanDeCuentas.modificarPlanDeCuentas(mPlanDeCuentas);
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Cuenta Modificada!", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                catch
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Ocurrio un error", false);
                    MessageBox.ShowDialog();
                }
            }           
        }

        public string codigoCuenta()
        {
            string codigoElegido = tbCodigo.Text;
            string[] codigo = new string[codigoElegido.Length];
            string[] nuevoCodigo = new string[codigoElegido.Length];
            for (int i = 0; i < codigoElegido.Length; i++)
            {

                codigo[i] = Convert.ToString(codigoElegido[i]);
                if (codigo[i] == ",")
                {
                    nuevoCodigo[i] = ".";
                }
                else if (codigo[i] == " ")
                {
                    nuevoCodigo[i] = "0";
                }
                else
                {
                    nuevoCodigo[i] = codigo[i];
                }

            }
            string CodigoCuenta = "";
            for (int i = 0; i < codigoElegido.Length; i++)
            {
                CodigoCuenta += nuevoCodigo[i];
            }
            for (int i = codigoElegido.Length; i < 17; i++)
            {
                CodigoCuenta += "0";
            }
            return CodigoCuenta;
        }

        public string cuentaSuperior()
        {
            string codigoElegido = tbCodigo.Text;
            string[] codigo = new string[codigoElegido.Length];
            string[] nuevoCodigo = new string[codigoElegido.Length];
            bool romper = false;
            for (int i = 0; i < codigoElegido.Length; i++)
            {
                if (romper == false)
                {
                    codigo[i] = Convert.ToString(codigoElegido[i]);
                    if (codigo[i] == ",")
                    {
                        nuevoCodigo[i] = ".";
                    }
                    else if (codigo[i] == " ")
                    {
                        romper = true;
                    }
                    else
                    {
                        nuevoCodigo[i] = codigo[i];
                    }
                }
            }
            string CodigoCuenta = "";
            for (int i = 0; i < codigoElegido.Length; i++)
            {
                CodigoCuenta += nuevoCodigo[i];
            }
            string CuentaSuperior = "";
            if (CodigoCuenta.Length > 4)
            {
                CuentaSuperior = CodigoCuenta.Remove(CodigoCuenta.Length - 4, 4);
                if (CuentaSuperior.Length == 2)
                {
                    CuentaSuperior += ".00.00.00.00.00";
                }
                else if (CuentaSuperior.Length == 5)
                {
                    CuentaSuperior += ".00.00.00.00";
                }
                else if (CuentaSuperior.Length == 8)
                {
                    CuentaSuperior += ".00.00.00";
                }
                else if (CuentaSuperior.Length == 11)
                {
                    CuentaSuperior += ".00.00";
                }
                else if (CuentaSuperior.Length == 14)
                {
                    CuentaSuperior += ".00";
                }
            }
            else
            {
                CuentaSuperior = "00";
            }
            return CuentaSuperior;
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
