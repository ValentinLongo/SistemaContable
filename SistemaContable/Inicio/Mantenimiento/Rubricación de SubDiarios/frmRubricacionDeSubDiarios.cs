using Negocio.Funciones.Contabilidad;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;


namespace SistemaContable.Inicio.Mantenimiento.Rubricación_de_SubDiarios
{
    public partial class frmRubricacionDeSubDiarios : Form
    {
        public frmRubricacionDeSubDiarios()
        {
            InitializeComponent();

            Negocio.FValidacionesEventos.EventosFormulario(this);
            //Negocio.FFormatoSistema.SetearFormato(this);
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

        private void guardarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";
            saveFileDialog1.Title = "Guardar archivo de texto";
            saveFileDialog1.ShowDialog();

            // Si el usuario presiona el botón "Guardar"
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Crear el archivo y escribir las líneas
                using (StreamWriter archivo = new StreamWriter(saveFileDialog1.FileName))
                {
                    archivo.WriteLine($"{FolioDesde.Text}");
                    archivo.WriteLine($"{FolioHasta.Text}");
                    archivo.WriteLine($"{Campo1.Text}");
                    archivo.WriteLine($"{Campo2.Text}");
                    archivo.WriteLine($"{Campo3.Text}");
                    archivo.WriteLine($"{Campo4.Text}");
                    // Agregar más líneas aquí si es necesario
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establecer las propiedades del cuadro de diálogo
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            openFileDialog.Title = "Seleccionar archivo de texto";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                LeerArchivoTexto(rutaArchivo);
            }
        }
        private void LeerArchivoTexto(string rutaArchivo)
        {
            try
            {
                // Lee el contenido del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo);

                FolioDesde.Text = lineas[0];
                FolioHasta.Text = lineas[1];
                Campo1.Text = lineas[2];
                Campo2.Text = lineas[3];
                Campo3.Text = lineas[4];
                Campo4.Text = lineas[5];
               
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la lectura del archivo
                MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirPorPantallaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte2 reporte = new frmReporte2("ReporteMatias", 2);
            reporte.ShowDialog();
        }
    }
}
