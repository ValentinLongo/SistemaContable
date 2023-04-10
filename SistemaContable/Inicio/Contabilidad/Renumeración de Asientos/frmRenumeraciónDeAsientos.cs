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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroEjercicio.Text != "")
                {
                    if (Negocio.FGenerales.EstadoEjercicio(Convert.ToInt32(txtNroEjercicio), 1))
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable se encuentra cerrado.", false);
                        MessageBox.ShowDialog();
                    }
                    else
                    {
                        btnProcesar.Enabled = false;

                        AccesoBase.InsertUpdateDatos($"UPDATE Caja SET caj_estado = 1");

                        int cant = 0;
                        int contador = 0;

                        DataSet ds = new DataSet();
                        ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {txtNroEjercicio.Text}");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            contador = Convert.ToInt32(dr["eje_renumera"].ToString() == "" ? "1" : dr["eje_renumera"].ToString() == "0" ? "1" : dr["eje_renumera"].ToString());
                        }

                        DataSet ds2 = new DataSet();
                        ds2 = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_ejercicio = {txtNroEjercicio.Text} ORDER BY ast_tipo, ast_fecha");

                        ProgressBar.Maximum = ds2.Tables[0].Rows.Count;

                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET ast_renumera = {contador} WHERE ast_ejercicio = {txtNroEjercicio.Text} AND ast_asiento = {dr2["ast_asiento"]} AND ast_renumera = {dr2["ast_renumera"]}");

                            ProgressBar.Value = ProgressBar.Value + 1;

                            lblControlBar.Text = "Renumerando Asientos (" + ProgressBar.Value.ToString() + " de " + ds2.Tables[0].Rows.Count.ToString() + ")";

                            contador = contador + 1;
                        }

                        //AccesoBase.InsertUpdateDatos();

                    }
                }
                else
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera seleccionar un Ejercicio Contable.", false);
                    MessageBox.ShowDialog();
                }
            }
            catch (Exception)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE Caja SET caj_estado = 0");

                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Hubi un problema en la Renumeración de Aientos.", false);
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
