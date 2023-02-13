using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmAggModVisAsientoContable : Form
    {
        //addmodvis = proceso que realiza el frm
        public frmAggModVisAsientoContable(int addmodvis, ComboBox cbSeleccion, string asiento, string fecha, string comentario)
        {
            InitializeComponent();
            Setear(addmodvis,cbSeleccion.SelectedValue.ToString(),cbSeleccion.Text, asiento, fecha, comentario);
        }

        private void Setear(int addmodvis,string codejercicio, string descriejercicio, string asiento, string fecha, string comentario)
        {
            txtCodEjercicio.Text = codejercicio;
            txtDescriEjercicio.Text = descriejercicio;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT tas_codigo,tas_descri FROM TipAsto");
            cbTipoAsiento.DataSource = ds.Tables[0];
            cbTipoAsiento.DisplayMember = "tas_descri";
            cbTipoAsiento.ValueMember = "tas_codigo";
            cbTipoAsiento.SelectedIndex = 1;

            if (addmodvis == 1) // agregar
            {
                txtNroAsiento.Text = "ALTA EN CONCEPTO";
                txtNroAsiento.Enabled = false;
                
                //consulta (terminar)
            }
            else if(addmodvis == 2) // modificar
            {
                txtNroAsiento.Text = asiento;
                dtFecha.Value = Convert.ToDateTime(fecha);
                txtComentario.Text = comentario;
                txtNroAsiento.Enabled = false;
                dtFecha.Enabled = false;
                
                //consulta (terminar)
            }
            else if(addmodvis == 3) // visualizar
            {
                txtNroAsiento.Text = asiento;
                dtFecha.Value = Convert.ToDateTime(fecha);
                txtComentario.Text = comentario;
                cbTipoAsiento.Enabled = false;
                txtNroAsiento.Enabled = false;
                dtFecha.Enabled = false;
                txtComentario.Enabled = false;

                CargarDGV(asiento);

                //consulta (termminar)
            }
        }

        private void CargarDGV(string asiento) 
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT mva_cuenta, mva_codigo, mva_importe, mva_comenta, mva_cc FROM MovAsto WHERE mva_asiento = {asiento} ");
            foreach (DataRow dr in ds.Tables[0].Rows) 
            {
                string debe = "0,0000";
                string haber = "0,0000";

                string cuenta = dr[0].ToString();

                if (dr[1].ToString() == "1")
                {
                    debe = dr[2].ToString();
                }
                else if (dr[1].ToString() == "2")
                {
                    haber = dr[2].ToString();
                }

                string concepto = dr[3].ToString();
                string cc = dr[4].ToString();

                DataSet ds2 = new DataSet();
                ds2 = AccesoBase.ListarDatos($"SELECT pcu_descri FROM PCuenta WHERE pcu_cuenta");


                dgvAddModVisASIENTO.Rows.Add(cuenta);
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
