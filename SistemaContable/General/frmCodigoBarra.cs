using Datos;
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

namespace SistemaContable.General
{
    public partial class frmCodigoBarra : Form
    {
        public static string usucodigobarra;
        public static string contracodigobarra;
        public frmCodigoBarra()
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);
        }
        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            tCodigoBarra.Start();           
        }
        private void tCodigoBarra_Tick(object sender, EventArgs e)
        {
            usucodigobarra = "";
            contracodigobarra = "";

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT usu_login, usu_contraseña FROM Usuario WHERE usu_cbarra = {txtCodigoBarra.Text}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                usucodigobarra = dr["usu_login"].ToString();
                contracodigobarra = dr["usu_contraseña"].ToString();
            }
            this.Close();
        }
        private void bunifuFormControlBox1_CloseClicked(object sender, EventArgs e)
        {
            usucodigobarra = "";
            contracodigobarra = "";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
