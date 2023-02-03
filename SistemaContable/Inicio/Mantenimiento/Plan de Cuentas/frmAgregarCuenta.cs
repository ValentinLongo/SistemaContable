using Datos.Modelos;
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
    public partial class frmAgregarCuenta : Form
    {
        public frmAgregarCuenta()
        {
            InitializeComponent();
            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            CargarDatos();
        }

        private void CargarDatos()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FPlanDeCuentas.Rubros();
            cbRubro.DataSource = ds.Tables[0];
            cbRubro.DisplayMember = "ruc_descri";
            cbRubro.ValueMember = "ruc_codigo";

            tbCodigo.Mask = "##.##.##.##.##.##";

            tbCuenta.Text = Convert.ToString(Negocio.FPlanDeCuentas.UltimoNumeroCuenta());
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int validado = Negocio.FValidacionesEventos.ValidacionVacio(this);

            if (tbCodigo == null )
            {
                validado = 0; 
            }

            if (validado == 0)
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

                        MessageBox.Show("Cargado Correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Atención: Falta completar campos");
                    }
                }
                catch
                {
                    MessageBox.Show("Ocurrio un Error");
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
