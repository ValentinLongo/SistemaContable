using Negocio.Funciones.Contabilidad;
using SistemaContable.General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private void btnAbrir_Click(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";
            saveFileDialog1.Title = "Guardar archivo de texto";

            // Si el usuario presiona el botón "Guardar"
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Crear el archivo y escribir las líneas
                using (StreamWriter archivo = new StreamWriter(saveFileDialog1.FileName))
                {
                    archivo.WriteLine($"{txtFolioDesde.Text}");
                    archivo.WriteLine($"{txtFolioHasta.Text}");
                    archivo.WriteLine($"{txtCampo1.Text}");
                    archivo.WriteLine($"{txtCampo2.Text}");
                    archivo.WriteLine($"{txtCampo3.Text}");
                    archivo.WriteLine($"{txtCampo4.Text}");
                    // Agregar más líneas aquí si es necesario
                }
            }
        }

        private void LeerArchivoTexto(string rutaArchivo)
        {
            try
            {
                // Lee el contenido del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo);

                txtFolioDesde.Text = lineas[0];
                txtFolioHasta.Text = lineas[1];
                txtCampo1.Text = lineas[2];
                txtCampo2.Text = lineas[3];
                txtCampo3.Text = lineas[4];
                txtCampo4.Text = lineas[5];
               
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la lectura del archivo
                MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPantalla_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 1)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Los campos (Apartir Folio) y (Hasta Folio) son obligatorios.", false);
                MessageBox.ShowDialog();
                return;
            }
            if (Convert.ToInt32(txtFolioDesde.Text) > Convert.ToInt32(txtFolioHasta.Text))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "El Folio Apartir no puede ser Mayor que el Folio Hasta.", false);
                MessageBox.ShowDialog();
                return;
            }

            for (int i = Convert.ToInt32(txtFolioDesde.Text); i <= Convert.ToInt32(txtFolioHasta.Text); i++)
            {
                frmReporte reporte = new frmReporte("Libro IVA 2", "", "", "", "", "", "", "", "", "", "", "", "", "", i.ToString(), txtCampo1.Text, txtCampo2.Text, txtCampo3.Text, txtCampo3.Text);
                reporte.ShowDialog();
            }
        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            if (Negocio.FValidacionesEventos.ValidacionVacio(this) == 1)
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "Los campos (Apartir Folio) y (Hasta Folio) son obligatorios", false);
                MessageBox.ShowDialog();
                return;
            }
            if (Convert.ToInt32(txtFolioDesde.Text) > Convert.ToInt32(txtFolioHasta.Text))
            {
                frmMessageBox MessageBox = new frmMessageBox("Mensaje", "El Folio Desde no puede ser Mayor que el Folio Hasta.", false);
                MessageBox.ShowDialog();
                return;
            }

            // Crear una instancia de PrintDocument
            PrintDocument printDocument = new PrintDocument();

            // Asignar el controlador de eventos para el evento PrintPage
            printDocument.PrintPage += Imprimir;

            // Obtener la impresora predeterminada
            string impresoraPredeterminada = printDocument.PrinterSettings.PrinterName;

            // Establecer la impresora predeterminada en PrintDocument
            printDocument.PrinterSettings.PrinterName = impresoraPredeterminada;

            // Iniciar el proceso de impresión
            printDocument.Print();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            for (int i = Convert.ToInt32(txtFolioDesde.Text); i <= Convert.ToInt32(txtFolioHasta.Text); i++)
            {
                frmReporte reporte = new frmReporte("Libro IVA 2", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", i.ToString(), txtCampo1.Text, txtCampo2.Text, txtCampo3.Text, txtCampo3.Text);
                reporte.ShowDialog();
            }
        }

        //para abrir los menus
        private void btnArchivos_Click(object sender, EventArgs e)
        {
            MenuArchivo.Show(btnArchivos, 0, btnArchivos.Height);
        }
        private void btnImpresion_Click(object sender, EventArgs e)
        {
            MenuImpresion.Show(btnImpresion, 0, btnImpresion.Height);
        }

        //diseño para los botones
        private void btnArchivos_MouseEnter(object sender, EventArgs e)
        {
            btnArchivos.BackColor = Color.FromArgb(0, 52, 162);
        }
        private void btnArchivos_MouseLeave(object sender, EventArgs e)
        {
            btnArchivos.BackColor = Color.FromArgb(0, 34, 108);
        }
        private void btnImpresion_MouseEnter(object sender, EventArgs e)
        {
            btnImpresion.BackColor = Color.FromArgb(0, 52, 162);
        }
        private void btnImpresion_MouseLeave(object sender, EventArgs e)
        {
            btnImpresion.BackColor = Color.FromArgb(0, 34, 108);
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
