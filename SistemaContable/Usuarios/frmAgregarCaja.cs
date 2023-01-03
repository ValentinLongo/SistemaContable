using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Usuarios
{
    public partial class frmAgregarCaja : Form
    {
        public frmAgregarCaja()
        {
            InitializeComponent();
            CargarDGV();
        }

        private void CargarDGV()
        {
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"select caj_codigo as Código, caj_descri as Descipción from Caja");
            dgvCajas.DataSource = data.Tables[0];
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int seleccion = dgvCajas.CurrentCell.RowIndex;
            int idCaja;
            if (seleccion > -1)
            {
                idCaja = Convert.ToInt32(dgvCajas.Rows[seleccion].Cells[0].Value);
                DataSet data = new DataSet();
                data = Datos.AccesoBase.ListarDatos($"select caj_codigo as Caja, caj_descri as Descripcion, Moneda.mon_descri as Moneda, CajaxUsuario.cxu_predef as Predef from CajaxUsuario INNER JOIN Caja on CajaxUsuario.cxu_caja = Caja.caj_codigo INNER JOIN Usuario on CajaxUsuario.cxu_usuario = Usuario.usu_codigo INNER JOIN Moneda on Caja.caj_moneda = Moneda.mon_codigo WHERE CajaxUsuario.cxu_usuario = {Negocio.FLogin.IdUsuario} Order by caj_codigo");
                int predef;
                if (data.Tables[0].Rows.Count > 0)
                {
                    predef = 0;
                }
                else
                {
                    predef = 1;
                }
                DataSet data2 = new DataSet();
                data2 = Datos.AccesoBase.ListarDatos($"select * from CajaxUsuario where cxu_usuario = {Negocio.FLogin.IdUsuario} and cxu_caja = {idCaja}");
                if (data2.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Caja ya habilitada para este usuario");
                }
                else
                {
                    Datos.AccesoBase.InsertUpdateDatos($"INSERT INTO CajaxUsuario(cxu_usuario,cxu_caja,cxu_predef) VALUES({Negocio.FLogin.IdUsuario},{idCaja},{predef})");
                    MessageBox.Show("Caja agregada correctamente");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = "select caj_codigo as Código, caj_descri as Descipción from Caja ";
            if (tbCodigo.Text != null && tbCodigo.Text != "")
            {
                if (query.Contains("WHERE"))
                {
                    query += $"and caj_codigo = {tbCodigo.Text}";
                }
                else
                {
                    query += $"WHERE caj_codigo = {tbCodigo.Text}";
                }
            }
            if (tbDescripcion.Text != null && tbDescripcion.Text != "")
            {
                if (query.Contains("WHERE"))
                {
                    query += $"and caj_descri = '{tbDescripcion.Text}'";
                }
                else
                {
                    query += $"WHERE caj_descri = '{tbDescripcion.Text}'";
                }
            }
            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos(query);
            dgvCajas.DataSource = data.Tables[0];
        }
    }
}
