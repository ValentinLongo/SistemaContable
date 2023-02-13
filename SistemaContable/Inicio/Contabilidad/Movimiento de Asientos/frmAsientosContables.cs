using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Contabilidad.Movimiento_de_Asientos
{
    public partial class frmAsientosContables : Form
    {
        public static int valorDgv = 0;
        //con el eje_codigo(Ejercicio) filtrar en ast_ejercicio(Asiento)

        //asiento = ast_asiento
        //fecha = ast_fecha
        //comentario = ast_comenta

        //debe = (tabla MovAsto)
        //haber = (tabla MovAsto)

        //creo = ast_user (traer de tabla usuario el nombre)
        //fecha = ast_fecalta
        //hora = ast_hora

        //Modifico = ast_usumodi
        //fecha = ast_fecmodi
        //hora = ast_horamodi
        public frmAsientosContables()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            List<DataRow> lista = new List<DataRow>();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT eje_codigo,eje_descri FROM Ejercicio");
            cbSeleccion.DataSource = ds.Tables[0];
            cbSeleccion.DisplayMember = "eje_descri";
            cbSeleccion.ValueMember = "eje_codigo";
            cbSeleccion.SelectedIndex = -1;
        }

        //private void CargarDGV(int valorData)
        //{
        //    if (cbSeleccion.SelectedIndex > -1)
        //    {
        //        string WHERE = "WHERE ast_ejercicio = " + cbSeleccion.SelectedValue;

        //        DataSet ds = new DataSet();
        //        ds = AccesoBase.ListarDatosPaginado($"SELECT ast_asiento, ast_fecha, ast_comenta, ast_user, ast_fecalta, ast_hora, ast_usumodi, ast_fecmodi, ast_horamodi FROM Asiento {WHERE} ORDER BY ast_fecha", valorData);

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            string nombreusuario = "";
        //            decimal DEBE = 0;
        //            decimal HABER = 0;

        //            string asiento = dr[0].ToString();
        //            string fecha = dr[1].ToString();
        //            string comentario = dr[2].ToString();

        //            DataSet ds2 = new DataSet();
        //            ds2 = AccesoBase.ListarDatos($"SELECT mva_codigo, mva_importe FROM MovAsto WHERE mva_asiento = '{asiento}'");
        //            foreach (DataRow dr2 in ds2.Tables[0].Rows)
        //            {
        //                if (dr2[0].ToString() == "1")
        //                {
        //                    DEBE = DEBE + Convert.ToDecimal(dr2[1]);
        //                }
        //                if (dr2[0].ToString() == "2")
        //                {
        //                    HABER = HABER + Convert.ToDecimal(dr2[1]);
        //                }
        //            }
        //            string debe = DEBE.ToString();
        //            string haber = HABER.ToString();

        //            DataSet ds3 = new DataSet();
        //            ds3 = AccesoBase.ListarDatos($"SELECT usu_nombre FROM Usuario WHERE usu_codigo = '{dr[3].ToString()}'");
        //            foreach (DataRow dr3 in ds3.Tables[0].Rows)
        //            {
        //                nombreusuario = dr3[0].ToString();
        //            }
        //            string creo = nombreusuario;

        //            string fechacreo = dr[4].ToString();
        //            string horacreo = dr[5].ToString();
        //            string modifico = dr[6].ToString();
        //            string fechamod = dr[7].ToString();
        //            string horamod = dr[8].ToString();

        //            dgvAsientosContables.Rows.Add(asiento, fecha, comentario, debe, haber, creo, fechacreo, horacreo, modifico, fechamod, horamod);
        //        }
        //    }
        //}

        private void CargarDGV(int valorData)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatosPaginado($"SELECT ast_asiento as Asiento, ast_fecha as Fecha, ast_comenta as Comentario, Debe as Debe, Debe as Haber, usu_nombre as 'Creó', ast_fecalta as Fecha, ast_hora as Hora, ast_usumodi as 'Modificó', ast_fecmodi as Fecha, ast_horamodi as Hora FROM Asiento as A LEFT JOIN Usuario ON A.ast_user = Usuario.usu_codigo Left Join (SELECT mva_asiento, SUM(mva_importe) / 2 as Debe FROM MovAsto group by mva_asiento) as B on A.ast_asiento = B.mva_asiento where ast_ejercicio = '{cbSeleccion.SelectedValue}' group by ast_asiento, ast_fecha, ast_comenta, ast_user, Debe, usu_nombre,ast_fecalta,ast_hora,ast_usumodi,ast_fecmodi,ast_horamodi order by ast_fecha", valorData);
                dgvAsientosContables.DataSource = ds.Tables[0];
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(1, cbSeleccion);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Atención: Debe seleccionar un Ejercicio!", "Mensaje");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(2, cbSeleccion);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Atención: Debe seleccionar un Ejercicio!", "Mensaje");
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(3, cbSeleccion);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Atención: Debe seleccionar un Ejercicio!", "Mensaje");
            }
        }

        private void cbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAsientosContables.Rows.Clear();

            if (cbSeleccion.Tag.ToString() != "0")
            {
                valorDgv = 0;
                CargarDGV(valorDgv);
            }
            else
            {
                cbSeleccion.Tag = "1";
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

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            valorDgv += 150;
            CargarDGV(valorDgv);
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (valorDgv >= 150)
            {
                valorDgv -= 150;
                CargarDGV(valorDgv);
            }

        }
    }
}
