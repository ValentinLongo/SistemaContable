using Datos.Modelos;
using Negocio;
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

namespace SistemaContable.Agenda
{
    public partial class frmAgregarAgenda : Form
    {
        private string Accion;
        FAgenda data = new FAgenda();
        public frmAgregarAgenda(string accion)
        {
            InitializeComponent();
            Accion = accion;
            llenarCombo();
        }

        private void llenarCombo()
        {
            DataSet ds = new DataSet();
            ds = Negocio.FAgenda.listaActividad();
            cbActividad.DataSource = ds.Tables[0];
            cbActividad.DisplayMember = "act_descri";
            cbActividad.ValueMember = "act_codigo";

            if (Accion == "Agregar")
            {
                tbCodigo.Text = "ALTA DE CONCEPTO";
            }
            if (Accion == "Modificar")
            {
                try
                {
                    tbCodigo.Text = frmAgenda.IdModificar.ToString();
                    MAgenda mAgenda = new MAgenda();
                    mAgenda = data.agendaAModificar(frmAgenda.IdModificar);
                    tbNombre.Text = mAgenda.age_nombre;
                    tbDireccion.Text = mAgenda.age_direccion;
                    tbLocalidad1.Text = mAgenda.age_codpos1.ToString();
                    tbLocalidad2.Text = mAgenda.age_codpos2.ToString();
                    tbLocalidad3.Text = mAgenda.localidad.ToString();
                    tbTel.Text = mAgenda.age_telefono;
                    tbCel.Text = mAgenda.age_celular;
                    tbMail.Text = mAgenda.age_email;
                    tbWeb.Text = mAgenda.age_web;
                    tbObserv.Text = mAgenda.age_observa;
                    if (mAgenda.age_fecnac != "")
                    {
                        dtFechaNacimiento.Value = Convert.ToDateTime(mAgenda.age_fecnac);
                    }
                    if (mAgenda.age_actividad != "")
                    {
                        cbActividad.SelectedValue = mAgenda.age_actividad;
                    }
                }
                catch
                {
                    MessageBox.Show("Error en el Usuario Seleccionado");
                }
            }
        }

        private void btnBusLoc_Click(object sender, EventArgs e)
        {
            frmLocalidades frmLocalidades = new frmLocalidades();
            frmLocalidades.ShowDialog();
            tbLocalidad1.Text = frmLocalidades.CodigoLocalidad.ToString();
            tbLocalidad2.Text = frmLocalidades.SubCodigoLocalidad.ToString();
            tbLocalidad3.Text = frmLocalidades.NombreLocalidad;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MAgenda mAgenda = new MAgenda()
            {
                age_codigo = FGenerales.ultimoNumeroID("age_codigo", "Agenda"),
                age_nombre = tbNombre.Text,
                age_direccion = tbDireccion.Text,
                age_codpos1 = Convert.ToInt32(tbLocalidad1.Text),
                age_codpos2 = Convert.ToInt32(tbLocalidad2.Text),
                age_telefono = tbTel.Text,
                age_celular = tbCel.Text,
                age_email = tbMail.Text,
                age_web = tbWeb.Text,
                age_observa = tbObserv.Text,
                //age_fecnac = Convert.ToDateTime(dtFechaNacimiento.Value),
                age_fecnac = dtFechaNacimiento.Value.ToString(),
                age_actividad = cbActividad.SelectedValue.ToString(),
            };
            if (Accion == "Agregar")
            {
                data.agregarAgenda(mAgenda);
                MessageBox.Show("Agregado Correctamente");
                this.Close();
            }
            if (Accion == "Modificar")
            {
                mAgenda.age_codigo = Convert.ToInt32(tbCodigo.Text);
                data.modificarAgenda(mAgenda);
                MessageBox.Show("Modificado Correctamente");
                this.Close();
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
