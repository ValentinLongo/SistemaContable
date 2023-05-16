using Datos;
using Datos.Modelos;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Parametrizacion_Permisos
{
    public partial class frmPermisosUsu : Form
    {
        public static List<MPermisoUsuario> lista = new List<MPermisoUsuario>();
        public static string NroUsu;
        public static string DescriUsu;

        public frmPermisosUsu()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultageneral = new frmConsultaGeneral("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "", "ORDER BY usu_codigo", "usu", "codigo", "nombre");
            //consultageneral.ArmarDGV("usu_codigo as Codigo, usu_nombre as Nombre", "usuario", "", "ORDER BY usu_codigo", "frmPermisosUsuarios");
            consultageneral.ShowDialog();

            string cod = frmConsultaGeneral.codigoCG;
            string descri = frmConsultaGeneral.descripcionCG;

            if (cod != null && descri != null)
            {
                txtNroUsuario.Text = cod.ToString();
                txtDescriUsuario.Text = descri;
            }

            //

            ArmarArbol(txtNroUsuario.Text);
        }

        private void ArmarArbol(string nrousu)
        {
            Cursor.Current = Cursors.WaitCursor;

            lista.Clear();

            DataSet ds = new DataSet();

            int terminal = frmLogin.NumeroTerminal;

            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MenuxUsu WHERE mxu_terminal = {terminal}");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MenuxUsu ( mxu_terminal, mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema) SELECT  {terminal}, mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema From MenuxUsu Where MenuxUsu.mxu_sistema = 'CO' And MenuxUsu.mxu_usuario = {nrousu}");

            ds = AccesoBase.ListarDatos($"select mxu_codigo, mxu_activo, mnu_descri from aux_MenuxUsu left join Menu on mxu_codigo = mnu_codigo and mxu_sistema = mnu_sistema where mxu_usuario = '{nrousu}' and mxu_sistema = 'CO' and mxu_terminal = {terminal} order by mnu_codigo");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MPermisoUsuario mPermiso = new MPermisoUsuario()
                {
                    mxu_codigo = dr["mxu_codigo"].ToString(),
                    mxu_activo = dr["mxu_activo"].ToString(),
                    mnu_descri = dr["mnu_descri"].ToString()
                };
                lista.Add(mPermiso);
            }

            var raiz = Tpermisos.Nodes.Add("");
            var subgrupo1 = Tpermisos.Nodes.Add("");
            var subgrupo2 = Tpermisos.Nodes.Add("");
            Tpermisos.Nodes.Clear();

            foreach (var i in lista)
            {
                if (i.mxu_codigo.Length == 2)
                {
                    raiz = Tpermisos.Nodes.Add(i.mnu_descri);
                    if (i.mxu_activo == "1")
                    {
                        raiz.Checked = true;
                    }
                    raiz.Tag = i.mxu_codigo;
                }
                if (i.mxu_codigo.Length == 4)
                {
                    subgrupo1 = raiz.Nodes.Add(i.mnu_descri);
                    if (i.mxu_activo == "1")
                    {
                        subgrupo1.Checked = true;
                    }
                    subgrupo1.Tag = i.mxu_codigo;
                }
                if (i.mxu_codigo.Length == 6)
                {
                    subgrupo2 = subgrupo1.Nodes.Add(i.mnu_descri);
                    if (i.mxu_activo == "1")
                    {
                        subgrupo2.Checked = true;
                    }
                    subgrupo2.Tag = i.mxu_codigo;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 0)
            {
                int terminal = frmLogin.NumeroTerminal;
                DataSet ds = new DataSet();

                AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxUsu WHERE mxu_sistema = 'CO' AND mxu_usuario = {txtNroUsuario.Text}");

                AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxUsu ( mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema) SELECT mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema From aux_MenuxUsu Where aux_MenuxUsu.mxu_sistema = 'CO' AND mxu_terminal = '{terminal}' AND aux_MenuxUsu.mxu_usuario = {txtNroUsuario.Text}");

                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Cambios realizados correctamente!", false);
                MessageBox.ShowDialog();
                this.Close();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe completar todos los campos", false);
                MessageBox.ShowDialog();
            }
        }

        private void Tpermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int terminal = frmLogin.NumeroTerminal;
            var codigo = e.Node.Tag;
            if (e.Node.Checked)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE aux_MenuxUsu SET mxu_activo = '1' WHERE mxu_terminal = {terminal} AND mxu_codigo = {codigo}");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"UPDATE aux_MenuxUsu SET mxu_activo = '0' WHERE mxu_terminal = {terminal} AND mxu_codigo = {codigo}");
            }
        }

        private void btnAbrirArbol_Click(object sender, EventArgs e)
        {
            Tpermisos.ExpandAll();
        }

        private void btnEspeciales_Click(object sender, EventArgs e)
        {
            if (txtNroUsuario.Text != "" && txtDescriUsuario.Text != "")
            {
                NroUsu = txtNroUsuario.Text;
                DescriUsu = txtDescriUsuario.Text;

                frmPermisosEspecialesUsu especialusuario = new frmPermisosEspecialesUsu();
                especialusuario.Show();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera indicar un usuario.", false);
                MessageBox.ShowDialog();
            }
        }

        private void btnCerrarTodo_Click(object sender, EventArgs e)
        {
            Tpermisos.CollapseAll();
        }

        private void txtNroUsuario_TextChanged(object sender, EventArgs e)
        {
            txtDescriUsuario.Clear();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT usu_nombre FROM Usuario WHERE usu_codigo = '{txtNroUsuario.Text}'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtDescriUsuario.Text = dr["usu_nombre"].ToString();
            }

            ArmarArbol(txtNroUsuario.Text);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtNroUsuario.Text != "")
            {
                string query = "Select LEFT((REPLICATE(' ', len(mxu_codigo)) + RTRIM(LTRIM(mnu_descri))) + REPLICATE('.',100),65) as Descri, mxu_activo, * From MenuxUsu Left Join Menu on mxu_codigo = mnu_codigo WHERE mxu_usuario = " + txtNroUsuario.Text + " AND mxu_sistema = 'CO' AND mnu_sistema = 'CO' Order By mxu_codigo";

                frmReporte freporte = new frmReporte("MenuxUsu", $"{query}", "", "Permisos por Usuario", "Confirmados", txtNroUsuario.Text + " - " + txtDescriUsuario.Text);
                freporte.ShowDialog();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe Seleccionar un Usuario.", false);
                MessageBox.ShowDialog();
            }
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
    }
}
