using Datos.Modelos;
using Datos;
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
    public partial class frmPermisosPerfil : Form
    {
        public static List<MPermisoPerfil> lista = new List<MPermisoPerfil>();
        public static string NroPerfil;
        public static string DescriPerfil;


        public frmPermisosPerfil()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultageneral = new frmConsultaGeneral("per_codigo as Codigo, per_descri as Descripcion", "Perfil", "", "ORDER BY per_codigo", "per", "codigo", "descri");
            //consultageneral.ArmarDGV("per_codigo as Codigo, per_descri as Descripcion", "Perfil", "", "ORDER BY per_codigo","frmPermisosPerfil");
            consultageneral.ShowDialog();

            string cod = frmConsultaGeneral.codigoCG;
            string descri = frmConsultaGeneral.descripcionCG;

            if (cod != null && descri != null)
            {
                txtNroPerfil.Text = cod.ToString();
                txtDescriPerfil.Text = descri;
            }

            ArmarArbol(txtNroPerfil.Text);
        }

        private void ArmarArbol(string nroperfil) 
        {
            lista.Clear();

            DataSet ds = new DataSet();

            int terminal = frmLogin.NumeroTerminal;

            AccesoBase.InsertUpdateDatos($"DELETE FROM Aux_MenuxPerfil WHERE mxp_terminal = {terminal}");

            AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MenuxPerfil ( mxp_terminal, mxp_perfil, mxp_codigo, mxp_activo, mxp_sistema) SELECT  {terminal}, mxp_perfil, mxp_codigo, mxp_activo, mxp_sistema From MenuxPerfil Where MenuxPerfil.mxp_sistema = 'CO' And MenuxPerfil.mxp_perfil = {nroperfil}");

            ds = AccesoBase.ListarDatos($"select mxp_codigo, mxp_activo, mnu_descri from aux_MenuxPerfil left join Menu on mxp_codigo = mnu_codigo and mxp_sistema = mnu_sistema where mxp_perfil = '{nroperfil}' and mxp_sistema = 'CO' order by mnu_codigo");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MPermisoPerfil mPermiso = new MPermisoPerfil()
                {
                    mxp_codigo = dr["mxp_codigo"].ToString(),
                    mxp_activo = dr["mxp_activo"].ToString(),
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
                if (i.mxp_codigo.Length == 2)
                {
                    raiz = Tpermisos.Nodes.Add(i.mnu_descri);
                    if (i.mxp_activo == "1")
                    {
                        raiz.Checked = true;
                    }
                    raiz.Tag = i.mxp_codigo;
                }
                if (i.mxp_codigo.Length == 4)
                {
                    subgrupo1 = raiz.Nodes.Add(i.mnu_descri);
                    if (i.mxp_activo == "1")
                    {
                        subgrupo1.Checked = true;
                    }
                    subgrupo1.Tag = i.mxp_codigo;
                }
                if (i.mxp_codigo.Length == 6)
                {
                    subgrupo2 = subgrupo1.Nodes.Add(i.mnu_descri);
                    if (i.mxp_activo == "1")
                    {
                        subgrupo2.Checked = true;
                    }
                    subgrupo2.Tag = i.mxp_codigo;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int terminal = frmLogin.NumeroTerminal;
            DataSet ds = new DataSet();

            AccesoBase.InsertUpdateDatos($"DELETE FROM MenuxPerfil WHERE mxp_sistema = 'CO' AND mxp_perfil = {txtNroPerfil.Text}");

            AccesoBase.InsertUpdateDatos($"INSERT INTO MenuxPerfil ( mxp_perfil, mxp_codigo, mxp_activo, mxp_sistema) SELECT mxp_perfil, mxp_codigo, mxp_activo, mxp_sistema From aux_MenuxPerfil Where aux_MenuxPerfil.mxp_sistema = 'CO' AND mxp_terminal = '{terminal}' AND aux_MenuxPerfil.mxp_perfil = {txtNroPerfil.Text}");

            frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Cambios realizados correctamente!", false);
            MessageBox.ShowDialog();
            this.Close();
        }

        private void Tpermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int terminal = frmLogin.NumeroTerminal;
            var codigo = e.Node.Tag;
            if (e.Node.Checked)
            {
                AccesoBase.InsertUpdateDatos($"UPDATE aux_MenuxPerfil SET mxp_activo = '1' WHERE mxp_terminal = {terminal} AND mxp_codigo = {codigo}");
            }
            else
            {
                AccesoBase.InsertUpdateDatos($"UPDATE aux_MenuxPerfil SET mxp_activo = '0' WHERE mxp_terminal = {terminal} AND mxp_codigo = {codigo}");
            }
        }

        private void btnAbrirArbol_Click(object sender, EventArgs e)
        {
            Tpermisos.ExpandAll();
        }

        private void btnCerrarArbol_Click(object sender, EventArgs e)
        {
            Tpermisos.CollapseAll();
        }

        private void btnEspeciales_Click(object sender, EventArgs e)
        {
            if (txtNroPerfil.Text != "" && txtDescriPerfil.Text != "")
            {
                NroPerfil = txtNroPerfil.Text;
                DescriPerfil = txtDescriPerfil.Text;

                frmPermisosEspecialesPerfil especialperfil = new frmPermisosEspecialesPerfil();
                especialperfil.Show();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Atención: Debera indicar un perfil.", false);
                MessageBox.ShowDialog();
            }
        }

        private void txtNroPerfil_TextChanged(object sender, EventArgs e)
        {
            txtDescriPerfil.Clear();

            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT per_descri FROM perfil WHERE per_codigo = '{txtNroPerfil.Text}'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtDescriPerfil.Text = dr["per_Descri"].ToString();
            }

            ArmarArbol(txtNroPerfil.Text);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtNroPerfil.Text != "")
            {
                string query = "Select LEFT((REPLICATE('   ', len(mxp_codigo)) + RTRIM(LTRIM(mnu_descri))),65) as Descri, mxp_activo, * From MenuxPerfil Left Join Menu on mxp_codigo = mnu_codigo WHERE mxp_perfil = " + txtNroPerfil.Text + " AND mxp_sistema = 'CO' AND mnu_sistema = 'CO' Order By mxp_codigo";

                frmReporte freporte = new frmReporte("MenuxPerfil", $"{query}", "", "Permisos por Perfil", "Permisos Confirmados", txtNroPerfil.Text + " - " + txtDescriPerfil.Text);
                freporte.ShowDialog();
            }
            else
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Debe Seleccionar un Perfil.", false);
                MessageBox.ShowDialog();
            }
        }

        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
