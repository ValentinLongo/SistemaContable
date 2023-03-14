using Datos;
using Negocio;
using SistemaContable.General;
using SistemaContable.Inicio.Mantenimiento.Conceptos_Contables;
using SistemaContable.Plan_de_Cuentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using TextBox = System.Windows.Forms.TextBox;

namespace SistemaContable.Inicio.Mantenimiento.Parametros_Contables
{
    public partial class frmParametrosContables : Form
    {
        public frmParametrosContables()
        {
            InitializeComponent();
            cargarDatos();
            cargarCheck();
        }

        private void cargarCheck()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM ParamContabH");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is CheckBox)
                    {
                        CheckBox che = (CheckBox)Ctrl;
                        int valor;
                        string nombreCheck = Ctrl.Name.Substring(0, Ctrl.Name.Length - 1);
                        try
                        {
                            valor = Convert.ToInt32(dr[$"{nombreCheck}"].ToString());
                        }
                        catch
                        {
                            valor = 0;
                        }
                        if(valor == 1)
                        {
                            che.Checked = true;
                        }
                    }
                }
            }
        }

        private void cargarDatos()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM ParamContab");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is TextBox)
                    {
                        try
                        {
                            Ctrl.Text = dr[$"{Ctrl.Name}"].ToString();
                        }
                        catch
                        {
                            Ctrl.Text = descripcionTextBox(Ctrl);
                        }
                    }
                }
            }
        }

        public string descripcionTextBox(Control tb)
        {
            string descri = tb.Name.Substring(0, tb.Name.Length - 1);
            string codigo;
            try
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos("SELECT * FROM ParamContab");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    codigo = dr[$"{descri}"].ToString();
                    DataSet ds1 = new DataSet();
                    ds1 = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {codigo}");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            descri = dr1["pcu_descri"].ToString();
                        }
                    }
                    else
                    {
                        descri = "";
                    }
                }
            }
            catch
            {
                descri = "";
            }
            return descri;
        }

        public string descripcionTextBoxPorID(string campo)
        {
            string descripcion = "";
            DataSet ds = new DataSet();
            ds = FPlanDeCuentas.BusquedaCuentaPorCuenta(campo);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                descripcion = dr["pcu_descri"].ToString();
            }
            return descripcion;
        }

        private void AbrirCuentas(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string campo;

            frmBuscarCuenta buscarCuenta = new frmBuscarCuenta("Cuenta");
            buscarCuenta.ShowDialog();
            if(frmBuscarCuenta.IdCuenta > 0)
            {
                campo = btn.Name.Substring(0, btn.Name.Length - 1);

                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is TextBox)
                    {
                        string textBox = campo;
                        string descriTextBox = $"{campo}1";
                        if(Ctrl.Name == textBox)
                        {
                            Ctrl.Text = frmBuscarCuenta.IdCuenta.ToString();
                        }
                        if(Ctrl.Name == descriTextBox)
                        {
                            Ctrl.Text = descripcionTextBoxPorID(frmBuscarCuenta.IdCuenta.ToString());
                        }
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (Control Ctrl in this.Controls)
            {
                if (Ctrl is TextBox)
                {
                    try
                    {
                        int codigo = Convert.ToInt32(Ctrl.Text);
                        string campo = Ctrl.Name;
                        AccesoBase.InsertUpdateDatos($"UPDATE ParamContab SET {campo} = {codigo}");
                    }
                    catch
                    {

                    }
                }
            }
            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente", false);
            MessageBox.ShowDialog();
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
