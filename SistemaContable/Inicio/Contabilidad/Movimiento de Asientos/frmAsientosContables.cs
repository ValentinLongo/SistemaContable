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

        private void CargarDGV(int valorData)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                DataSet ds = new DataSet();
                ds = AccesoBase.ListarDatos($"Select X.ast_asiento as Asiento, X.ast_fecha as Fecha,X.ast_comenta as Comentario,Sum(X.Debe) as Debe,Sum(X.Haber) as Haber,X.usu_nombre as Creó,X.ast_fecalta as FechaCreó,X.ast_hora as HoraCreó, X.UsuModi as Modificó, X.ast_fecmodi as FechaModi, X.ast_horamodi as HoraModi From (Select *, Z.UsuModi1 as UsuModi, Case When mva_codigo = 1 Then mva_importe Else 0 End as Debe, Case When mva_codigo = 2 Then mva_importe Else 0 End as Haber From MovAsto Left Join Asiento on mva_asiento = ast_asiento Left Join PCuenta on mva_cuenta = pcu_cuenta Left Join Usuario on ast_user = Usuario.usu_codigo Left Join Ejercicio on ast_ejercicio = eje_codigo Left Join TipAsto on ast_tipo = tas_codigo Left Join (Select usu_codigo as UsuCod, usu_nombre as UsuModi1 From Usuario) as Z on ast_usumodi = Z.UsuCod Where ast_ejercicio = '{cbSeleccion.SelectedValue}' ) as X Group By X.ast_asiento, X.ast_renumera, X.ast_fecha, X.ast_ctapro, X.ast_comenta, X.ast_tipocbte, X.ast_cbte, X.ast_ejercicio, X.eje_descri, X.ast_user, X.usu_nombre, X.ast_hora, X.ast_fecalta, X.UsuModi, X.ast_fecmodi, X.ast_horamodi, X.ast_tipo, X.tas_descri Order By X.ast_fecha, X.ast_asiento");
                //ds = AccesoBase.ListarDatosPaginado($"SELECT ast_asiento as Asiento, ast_fecha as Fecha, ast_comenta as Comentario, Debe as Debe, Debe as Haber, usu_nombre as 'Creó', ast_fecalta as Fecha, ast_hora as Hora, ast_usumodi as 'Modificó', ast_fecmodi as Fecha, ast_horamodi as Hora FROM Asiento as A LEFT JOIN Usuario ON A.ast_user = Usuario.usu_codigo Left Join (SELECT mva_asiento, SUM(mva_importe) / 2 as Debe FROM MovAsto group by mva_asiento) as B on A.ast_asiento = B.mva_asiento where ast_ejercicio = '{cbSeleccion.SelectedValue}' group by ast_asiento, ast_fecha, ast_comenta, ast_user, Debe, usu_nombre,ast_fecalta,ast_hora,ast_usumodi,ast_fecmodi,ast_horamodi order by ast_fecha", valorData);
                dgvAsientosContables.DataSource = ds.Tables[0];
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbSeleccion.SelectedIndex > -1)
            {
                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(1, cbSeleccion,"","","");
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
                int seleccionado = dgvAsientosContables.CurrentCell.RowIndex;
                string asiento = dgvAsientosContables.Rows[seleccionado].Cells[0].Value.ToString();
                string fecha = dgvAsientosContables.Rows[seleccionado].Cells[1].Value.ToString();
                string comentario = dgvAsientosContables.Rows[seleccionado].Cells[2].Value.ToString();

                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(2, cbSeleccion, asiento, fecha, comentario);
                frm.ShowDialog();
                AccesoBase.InsertUpdateDatos($"DELETE Aux_MovAsto");
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
                int seleccionado = dgvAsientosContables.CurrentCell.RowIndex;
                string asiento = dgvAsientosContables.Rows[seleccionado].Cells[0].Value.ToString();
                string fecha = dgvAsientosContables.Rows[seleccionado].Cells[1].Value.ToString();
                string comentario = dgvAsientosContables.Rows[seleccionado].Cells[2].Value.ToString();

                frmAggModVisAsientoContable frm = new frmAggModVisAsientoContable(3, cbSeleccion, asiento, fecha, comentario);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Atención: Debe seleccionar un Ejercicio!", "Mensaje");
            }
        }

        private void cbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
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
