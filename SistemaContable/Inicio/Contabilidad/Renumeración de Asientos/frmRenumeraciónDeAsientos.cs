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
            frmConsultaGeneral frm = new frmConsultaGeneral("eje_codigo as Código, eje_descri as Descripción", "Ejercicio", "", "", "eje", "codigo", "descri");
            frm.ShowDialog();
            txtNroEjercicio.Text = frmConsultaGeneral.codigoCG;
            txtDescriEjercicio.Text = frmConsultaGeneral.descripcionCG;
        }

        private void txtNroEjercicio_TextChanged(object sender, EventArgs e)
        {
            tRenumera.Start(); //(para que no se ejecute el textchange hasta que ponga el nro de ejercicio completo)
        }

        private void tRenumera_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tRenumera.Stop();

            if (txtNroEjercicio.Text != "") //Validación
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE eje_codigo = {txtNroEjercicio.Text}");
                if (ds.Tables[0].Rows.Count == 0) //Validación
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable No Existe.", false);
                    MessageBox.ShowDialog();
                    txtNroEjercicio.Text = "";
                    txtDescriEjercicio.Text = "";
                }
                else
                {
                    if (Negocio.FGenerales.EstadoEjercicio(Convert.ToInt32(txtNroEjercicio.Text), 1)) //Validación
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable se Encuentra Cerrado", false);
                        MessageBox.ShowDialog();
                        txtNroEjercicio.Text = "";
                        txtDescriEjercicio.Text = "";
                    }
                    else
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            txtDescriEjercicio.Text = dr["eje_descri"].ToString();
                        }
                    }
                }
            }
            else
            {
                txtDescriEjercicio.Text = "";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try //Validación
            {
                if (txtNroEjercicio.Text != "") //Validación
                {
                    if (Negocio.FGenerales.EstadoEjercicio(Convert.ToInt32(txtNroEjercicio.Text), 1))
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Ejercicio Contable se encuentra cerrado.", false);
                        MessageBox.ShowDialog();
                    }
                    else
                    {
                        btnProcesar.Enabled = false;

                        AccesoBase.InsertUpdateDatos($"UPDATE Caja SET caj_estado = 1");

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

                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            AccesoBase.InsertUpdateDatos($"UPDATE Asiento SET ast_renumera = {contador} WHERE ast_ejercicio = {txtNroEjercicio.Text} AND ast_asiento = {dr2["ast_asiento"]} AND ast_renumera = {dr2["ast_renumera"]}");

                            Application.DoEvents();

                            ProgressBar.Value = ProgressBar.Value + 1;

                            lblControlBar.Text = "Renumerando Asientos (" + ProgressBar.Value.ToString() + " de " + ds2.Tables[0].Rows.Count.ToString() + ") PorFavor Esperar";

                            contador = contador + 1;
                        }
                        Cursor.Current = Cursors.Default;

                        AccesoBase.InsertUpdateDatos("UPDATE Caja SET caj_Estado = 0");
                        AccesoBase.InsertUpdateDatos($"UPDATE Ejercicio SET eje_renumera = {contador} WHERE eje_codigo = {txtNroEjercicio.Text}");

                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Finalizó la Renumeración de Asientos.", false);
                        MessageBox.ShowDialog();

                        this.Close();
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

                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Hubo un problema en la Renumeración de Asientos.", false);
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
