using SistemaContable.General;
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

namespace SistemaContable.Empresa
{
    public partial class frmAgregarSucursal : Form
    {
        string TipoDeOperacion;
        int IdSucursal;
        public frmAgregarSucursal(string tipoOperacion)
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            TipoDeOperacion = tipoOperacion;
            if (tipoOperacion == "Modificar")
            {
                IdSucursal = frmEmpresa.codigoSucursal;
                lbCodigo.Text = IdSucursal.ToString();
                tbDescripcion.Text = frmEmpresa.descripcionSucursal;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                if (TipoDeOperacion == "Agregar")
                {
                    int id = Negocio.FGenerales.ultimoNumeroID("suc_codigo", "Sucursal");
                    Datos.AccesoBase.InsertUpdateDatos($"insert into Sucursal(suc_codigo,suc_descri) VALUES({id},'{tbDescripcion.Text}')");
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Agregado Correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                else if (TipoDeOperacion == "Modificar")
                {
                    Datos.AccesoBase.InsertUpdateDatos($"UPDATE Sucursal SET suc_descri = '{tbDescripcion.Text}' WHERE suc_codigo = {IdSucursal}");
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Modificado Correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe ingresar descripción", false);
                MessageBox.ShowDialog();
            }
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
