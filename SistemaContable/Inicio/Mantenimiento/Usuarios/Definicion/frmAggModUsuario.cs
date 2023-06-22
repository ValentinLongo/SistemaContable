using Datos.Modelos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SistemaContable.Usuarios
{
    public partial class frmAggModUsuario : Form
    {

        private int PROCESO;

        public frmAggModUsuario(int proceso) // proceso 1 = agregar / proceso 2 = modificar
        {
            InitializeComponent();

            PROCESO = proceso;

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);

            LlenarCB();

            if (proceso == 2)
            {
                lblControlBar.Text = "Modificar Usuario";
                tbCodigo.Text = "";
                tbCodigo.Tag = "10100";
                traerDatos();
            }
        }

        private void traerDatos()
        {
            tbCodigo.Text = frmUsuarios.codigoUsuario.ToString();
            MUsuario oUsuario = new MUsuario();
            oUsuario = Negocio.FUsuarios.UsuarioParticular(Convert.ToInt32(tbCodigo.Text));

            tbNombre.Text = oUsuario.usu_nombre;
            tbDireccion.Text = oUsuario.usu_direccion;
            tbTelefono.Text = oUsuario.usu_telefono;
            dtFechaNachimiento.Value = oUsuario.usu_fecnac;
            tbLogin.Text = oUsuario.usu_login;
            cbPerfil.SelectedValue = oUsuario.usu_perfil;
            cbEstado.SelectedValue = oUsuario.usu_estado;
            cbSeccion.SelectedValue = oUsuario.usu_seccion;
            if (oUsuario.usu_vendedor == 0)
            {
                CambioCheck.Checked = true;
            }
            else
            {
                tbVendedor.Text = oUsuario.ven_nombre;
            }
        }

        private void LlenarCB()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FUsuarios.Perfiles();
            cbPerfil.DataSource = ds.Tables[0];
            cbPerfil.DisplayMember = "per_descri";
            cbPerfil.ValueMember = "per_codigo";

            DataSet ds2 = new DataSet();
            ds2 = Negocio.FUsuarios.Estados();
            cbEstado.DataSource = ds2.Tables[0];
            cbEstado.DisplayMember = "est_descri";
            cbEstado.ValueMember = "est_codigo";

            DataSet ds3 = new DataSet();
            ds3 = Negocio.FUsuarios.Secciones();
            cbSeccion.DataSource = ds3.Tables[0];
            cbSeccion.DisplayMember = "sec_descri";
            cbSeccion.ValueMember = "sec_codigo";


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmSeleccionVendedores frmSeleccionVendedore = new frmSeleccionVendedores();
            frmSeleccionVendedore.ShowDialog();
            if (SistemaContable.Usuarios.frmSeleccionVendedores.NombreVendedor != "")
            {
                tbVendedor.Text = SistemaContable.Usuarios.frmSeleccionVendedores.NombreVendedor;
            }
        }

        private void CambioCheck_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CambioCheck.Checked == true)
            {
                tbVendedor.Enabled = false;
                btnBuscar.Enabled = false;
                SistemaContable.Usuarios.frmSeleccionVendedores.NombreVendedor = "";
                SistemaContable.Usuarios.frmSeleccionVendedores.CodigoVendedor = 0;
                tbVendedor.Text = "";
            }
            else if (CambioCheck.Checked == false)
            {
                tbVendedor.Enabled = true;
                btnBuscar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                if (PROCESO == 1)
                {
                    MUsuario mUsuario = new MUsuario
                    {
                        usu_nombre = tbNombre.Text,
                        usu_login = tbLogin.Text,
                        usu_direccion = tbDireccion.Text,
                        usu_telefono = tbTelefono.Text,
                        usu_fecnac = Convert.ToDateTime(dtFechaNachimiento.Text),
                        usu_perfil = Convert.ToInt32(cbPerfil.SelectedValue.ToString()),
                        usu_estado = Convert.ToInt32(cbEstado.SelectedValue.ToString()),
                        usu_seccion = Convert.ToInt32(cbSeccion.SelectedValue.ToString()),
                        usu_vendedor = SistemaContable.Usuarios.frmSeleccionVendedores.CodigoVendedor
                    };
                    Negocio.FUsuarios.AgregarUsuario(mUsuario);

                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Usuario agregado correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
                else if (PROCESO == 2)
                {
                    int seccion = 0;
                    if (cbSeccion.SelectedValue != null)
                    {
                        seccion = Convert.ToInt32(cbSeccion.SelectedValue);
                    }
                    MUsuario mUsuario = new MUsuario
                    {
                        usu_codigo = Convert.ToInt32(tbCodigo.Text),
                        usu_nombre = tbNombre.Text,
                        usu_login = tbLogin.Text,
                        usu_direccion = tbDireccion.Text,
                        usu_telefono = tbTelefono.Text,
                        usu_fecnac = Convert.ToDateTime(dtFechaNachimiento.Text),
                        usu_perfil = Convert.ToInt32(cbPerfil.SelectedValue.ToString()),
                        usu_estado = Convert.ToInt32(cbEstado.SelectedValue.ToString()),
                        usu_seccion = seccion,
                        usu_vendedor = SistemaContable.Usuarios.frmSeleccionVendedores.CodigoVendedor
                    };

                    Negocio.FUsuarios.ModificarUsuario(mUsuario);

                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Usuario modificado correctamente", false);
                    MessageBox.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Falta completar campos.", false);
                MessageBox.ShowDialog();
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
