using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Empresa
{
    public partial class frmAgregarSucursal : Form
    {
        public frmAgregarSucursal()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbDescripcion.Text != "")
            {
                int id = Negocio.FGenerales.ultimoNumeroID("suc_codigo", "Sucursal");
                id = id + 1;
                Datos.AccesoBase.InsertUpdateDatos($"insert into Sucursal(suc_codigo,suc_descri) VALUES({id},'{tbDescripcion.Text}')");
                MessageBox.Show("Agregado Correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe ingresar descripción");
            }
        }
    }
}
