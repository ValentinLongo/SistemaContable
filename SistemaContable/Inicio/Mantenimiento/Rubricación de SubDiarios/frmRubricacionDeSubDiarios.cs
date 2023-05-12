using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear el diálogo para guardar el archivo
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
