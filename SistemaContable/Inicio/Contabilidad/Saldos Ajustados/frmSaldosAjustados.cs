using Datos;
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

namespace SistemaContable.Inicio.Contabilidad.Saldos_Ajustados
{
    public partial class frmSaldosAjustados : Form
    {
        int terminal = frmLogin.NumeroTerminal;
        int Posicion;

        public frmSaldosAjustados()
        {
            InitializeComponent();

            //Negocio.FValidacionesEventos.EventosFormulario(this); (NO se usa en este frm)
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void frmSaldosAjustados_Load(object sender, EventArgs e)
        {
            bool Flag = false;

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio WHERE IsNull(eje_cerrado,0) = 0");
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows.Count > 1)
                {
                    Flag = true;
                }
            }

            DataSet ds2 = new DataSet();
            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Ejercicio ORDER BY IsNull(eje_cerrado,0), eje_codigo");
            if (ds2.Tables[0].Rows.Count == 0) 
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que No Existen Ejercicio Contables Cargados.", false);
                MessageBox.ShowDialog();
                btnProcesar.Enabled = false;
            }
            else
            {
                btnProcesar.Enabled = true;

                cbSeleccion.DataSource = ds2.Tables[0];
                cbSeleccion.DisplayMember = "eje_descri";
                //cbSeleccion.ValueMember = "";

                if (Flag == false)
                {
                    cbSeleccion.SelectedIndex = 0;
                }

                DataSet ds3 = new DataSet();
                ds3 = AccesoBase.ListarDatos($"SELECT * FROM CentroC ORDER BY cec_codigo");
                cbCC.Items.Add("TODOS");
                cbCC.DataSource = ds3.Tables[0];
                cbCC.DisplayMember = "cec_descri";
                //cbCC.ValueMember = "";
                cbCC.SelectedIndex = 0;

                //(Parte de codigo que creo que es irrelevante) "por posible error"
            }
        }

        private void btnAsiento_Click(object sender, EventArgs e)
        {
            int ContraP = 0;
            string ContraPDescri = "";

            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM ParamContab LEFT JOIN PCuenta on par_cta_AjusteInf = pcu_cuenta");
            if (ds.Tables[0].Rows.Count == 0) //Validación
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá definir los Parametros Contables", false);
                MessageBox.ShowDialog();
                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
            }
            else
            {
                string descri = "";
                int hija = 0;
                int estado = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    descri = dr["pcu_descri"].ToString();
                    hija = Convert.ToInt32(dr["pcu_hija"]);
                    estado = Convert.ToInt32(dr["pcu_estado"]);

                    ContraP = Convert.ToInt32(dr["par_ctaAjusteInf"]);
                    ContraPDescri = dr["pcu_descri"].ToString();
                }

                if (descri == "") //Validación
                {
                    frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: No se ha definido la Cuenta para Ajuste por Inflación.", false, true);
                    MessageBox.ShowDialog();
                    Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                }
                else
                {
                    if (hija != 0) //Validación
                    {
                        frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros No puede Recibir Movimientos", false, true);
                        MessageBox.ShowDialog();
                        Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                    }
                    else
                    {
                        if (estado != 1) //Validación
                        {
                            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: La Cuenta para Ajuste por Inflación definida en los Parametros ha sido Inhabilitada", false, true);
                            MessageBox.ShowDialog();
                            Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                        }
                        else
                        {
                            int advertencias = 0;

                            //Advertencias
                            DataSet ds2 = new DataSet();
                            ds2 = AccesoBase.ListarDatos($"SELECT * FROM Asiento WHERE ast_tipo = 3 AND ast_ejercicio = {Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbSeleccion.Text,"Ejercicio","eje")}");
                            if (ds2.Tables[0].Rows.Count != 0)
                            {
                                frmMessageBox MessageBox1 = new frmMessageBox("Mensaje", "Atención: El Sistema ha Detectado que ya se ha Registrado al menos un Asiento de Ajuste por inflación, ¿Desea Continuar?", true, true);
                                MessageBox1.ShowDialog();
                                if (frmMessageBox.Acepto)
                                {
                                    advertencias++;
                                }
                            }

                            if (advertencias == 1)
                            {
                                DataSet ds3 = new DataSet();
                                ds3 = AccesoBase.ListarDatos($"SELECT * FROM Aux_PromMesAnio1 LEFT JOIN PCuenta on aux_codigo = pcu_cuenta WHERE aux_terminal {terminal} AND IsNull(aux_col13,0) <> 0 ORDER BY aux_codigo");
                                if (ds3.Tables[0].Rows.Count == 0)
                                {
                                    frmMessageBox MessageBox2 = new frmMessageBox("Mensaje", "Atención: No se han encontrado Datos para Generar el Asiento. Presione Procesar", false, true);
                                    MessageBox2.ShowDialog();
                                }
                                else
                                {
                                    advertencias++;
                                }
                            }

                            if (advertencias == 2)
                            {
                                frmMessageBox MessageBox3 = new frmMessageBox("Mensaje", "Atención: Al hacer click en esta opción, el Sistema Generara un Asiento Contable con los Datos Presentados en la Grilla, ¿Desea Continuar? ", true, true);
                                MessageBox3.ShowDialog();
                                if (frmMessageBox.Acepto)
                                {
                                    advertencias++;
                                }
                            }
                            //

                            if (advertencias == 3)
                            {
                                AccesoBase.InsertUpdateDatos($"DELETE FROM aux_MovAsto WHERE mva_terminal = {terminal}");

                                int n = 0;
                                int CA = 0; //Codigo Autoincremental
                                int CC = 0; //Centro de Costo

                                if (cbCC.Text != "TODOS")
                                {
                                    CC = Negocio.Funciones.Contabilidad.FSaldosAjsutados.Busca_Clave(cbCC.Text,"CentroC","cec");
                                }

                                //terminar
                            }
                            else
                            {
                                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Habilitar(this);
                            }
                        }
                    }
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.Text == "")
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Deberá Seleccionar un para Procesar", false);
                MessageBox.ShowDialog();
            }
            else
            {
                Negocio.Funciones.Contabilidad.FSaldosAjsutados.Deshabilitar(this);

                //terminar
            }

        }

        private void Actualizar() 
        {
            //terminar
        }

        private void cbSeleccion_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void cbCC_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //terminar
        }

        private void checkVDA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkValoresDeAjuste
        {
            if (checkValoresdeAjuste.Checked)
            {
                btnAsiento.Enabled = true;

                checkSaldosConAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                Actualizar();
            }
        }

        private void checkSCA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosConAjuste
        {
            if (checkSaldosConAjuste.Checked)
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosSinAjuste.Checked = false;

                Actualizar();
            }
        }

        private void checkSSA(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //checkSaldosSinAjuste
        {
            if (checkSaldosSinAjuste.Checked)
            {
                btnAsiento.Enabled = false;

                checkValoresdeAjuste.Checked = false;
                checkSaldosConAjuste.Checked = false;

                Actualizar();
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
