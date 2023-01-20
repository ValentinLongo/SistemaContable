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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TheArtOfDev.HtmlRenderer.Adapters;
using Datos;

namespace SistemaContable.Parametrizacion_Permisos
{
    public partial class frmPermisosEspecialesUsu : Form
    {
        string codigo = frmConsultaGeneral.codigoCG;
        string descri = frmConsultaGeneral.descripcionCG;
        public frmPermisosEspecialesUsu()
        {
            InitializeComponent();
            if (codigo != "" && descri != "")
            {
                txtNroUsuario.Text = codigo;
                txtDescriUsuario.Text = descri;
                txtNroUsuario.ReadOnly = true;
                txtDescriUsuario.ReadOnly = true;
                cbModulo.SelectedIndex = 0;
            }

            DataSet data = new DataSet();
            data = Datos.AccesoBase.ListarDatos($"SELECT pef_codigo as Codigo, pef_modulo as Modulo, pef_descri as Descripcion, CONVERT(bit,(Case When pxu_activo = 1 Then 'true' Else 'false' END)) as Activo FROM PermisosxUsu LEFT JOIN Permisos ON pef_codigo = pxu_codigo AND pef_sistema = pxu_sistema  WHERE pef_sistema = 'CO' AND pxu_usuario = {codigo} ORDER BY pef_codigo");
            dgvPEspeciales.DataSource = data.Tables[0];
            //dgvPEspeciales.Columns["Codigo"].Visible = false;
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dgvPEspeciales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isCellChecked = (bool)dgvPEspeciales.Rows[e.RowIndex].Cells[3].Value;
            
            if (isCellChecked)
            {
                //check
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxUsu SET pxu_activo = '1' WHERE pxu_usuario = '{codigo}' AND pxu_codigo =  AND pxu_sistema = 'CO'");
            }
            else
            {
                //nocheck
                AccesoBase.InsertUpdateDatos($"UPDATE PermisosxUsu SET pxu_activo = '0' WHERE pxu_usuario = '{codigo}' AND pxu_codigo =  AND pxu_sistema = 'CO'");
            }
        }

        private void dgvPEspeciales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPEspeciales.IsCurrentCellDirty)
            {
                dgvPEspeciales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
