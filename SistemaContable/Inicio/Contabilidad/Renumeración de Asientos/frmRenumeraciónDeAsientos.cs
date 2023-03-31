using Datos;
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

namespace SistemaContable.Inicio.Contabilidad.Renumeración_de_Asientos
{
    public partial class frmRenumeraciónDeAsientos : Form
    {
        public frmRenumeraciónDeAsientos()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void btnEjercicio_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral frm = new frmConsultaGeneral("eje_codigo as Código, eje_descri as Descripción", "Ejercicio", "", "", "frmRenumeraDeAsientos");
            frm.ShowDialog();
            txtNroEjercicio.Text = frmConsultaGeneral.codigoCG;
            txtDescriEjercicio.Text = frmConsultaGeneral.descripcionCG;
        }

        private void txtNroEjercicio_TextChanged(object sender, EventArgs e)
        {
            if (txtNroEjercicio.Text != "")
            {
                DataSet ds = new DataSet();

                ds = AccesoBase.ListarDatos($"SELECT eje_descri FROM Ejercicio WHERE eje_codigo = {txtNroEjercicio.Text}");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtDescriEjercicio.Text = dr["eje_descri"].ToString();
                }
            }
            else
            {
                txtDescriEjercicio.Text = "";
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
