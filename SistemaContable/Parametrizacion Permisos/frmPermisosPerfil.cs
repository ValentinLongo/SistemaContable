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

        public frmPermisosPerfil()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //BARRA DE CONTROL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaGeneral consultageneral = new frmConsultaGeneral();
            consultageneral.ArmarDGV("per_codigo as Codigo, per_descri as Descripcion", "Perfil", "", "ORDER BY per_codigo","frmPermisosPerfil");
            consultageneral.ShowDialog();

            string cod = frmConsultaGeneral.codigoCG;
            string descri = frmConsultaGeneral.descripcionCG;

            if (cod != null && descri != null)
            {
                txtNroPerfil.Text = cod.ToString();
                txtDescriPerfil.Text = descri;
            }

            //

            ArmarArbol(txtNroPerfil.Text);
        }

        private void ArmarArbol(string nroperfil) 
        {
            //lista.Clear();

            //DataSet ds = new DataSet();

            //int terminal = frmLogin.NumeroTerminal;

            //ds = AccesoBase.ListarDatos($"DELETE FROM Aux_MenuxUsu WHERE mxu_terminal = {terminal}");

            //AccesoBase.InsertUpdateDatos($"INSERT INTO Aux_MenuxUsu ( mxu_terminal, mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema) SELECT  {terminal}, mxu_usuario, mxu_codigo, mxu_activo, mxu_sistema From MenuxUsu Where MenuxUsu.mxu_sistema = 'CO' And MenuxUsu.mxu_usuario = {nrousu}");

            //ds = AccesoBase.ListarDatos($"select mxu_codigo, mxu_activo, mnu_descri from aux_MenuxUsu left join Menu on mxu_codigo = mnu_codigo and mxu_sistema = mnu_sistema where mxu_usuario = '{nrousu}' and mxu_sistema = 'CO' order by mnu_codigo");

            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    MPermisoUsuario mPermiso = new MPermisoUsuario()
            //    {
            //        mxu_codigo = dr["mxu_codigo"].ToString(),
            //        mxu_activo = dr["mxu_activo"].ToString(),
            //        mnu_descri = dr["mnu_descri"].ToString()
            //    };
            //    lista.Add(mPermiso);
            //}

            //var raiz = Tpermisos.Nodes.Add("");
            //var subgrupo1 = Tpermisos.Nodes.Add("");
            //var subgrupo2 = Tpermisos.Nodes.Add("");
            //Tpermisos.Nodes.Clear();

            //foreach (var i in lista)
            //{
            //    if (i.mxu_codigo.Length == 2)
            //    {
            //        raiz = Tpermisos.Nodes.Add(i.mnu_descri);
            //        if (i.mxu_activo == "1")
            //        {
            //            raiz.Checked = true;
            //        }
            //        raiz.Tag = i.mxu_codigo;
            //    }
            //    if (i.mxu_codigo.Length == 4)
            //    {
            //        subgrupo1 = raiz.Nodes.Add(i.mnu_descri);
            //        if (i.mxu_activo == "1")
            //        {
            //            subgrupo1.Checked = true;
            //        }
            //        subgrupo1.Tag = i.mxu_codigo;
            //    }
            //    if (i.mxu_codigo.Length == 6)
            //    {
            //        subgrupo2 = subgrupo1.Nodes.Add(i.mnu_descri);
            //        if (i.mxu_activo == "1")
            //        {
            //            subgrupo2.Checked = true;
            //        }
            //        subgrupo2.Tag = i.mxu_codigo;
            //    }
            //}
        }
    }
}
