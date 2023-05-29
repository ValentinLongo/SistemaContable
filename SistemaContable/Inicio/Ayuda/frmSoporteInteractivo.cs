using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SistemaContable.Inicio.Ayuda
{
    public partial class frmSoporteInteractivo : Form
    {
        public frmSoporteInteractivo()
        {
            InitializeComponent();
            OpenWhatsAppChat();
        }

        private void OpenWhatsAppChat()
        {
            // Configurar el ChromeDriver (asegúrate de que la ubicación del controlador sea correcta)
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("user-data-dir=C:\\Users\\Valentin\\Desktop\\chromedriver_win32");
            IWebDriver driver = new ChromeDriver(options);

            // Navegar a WhatsApp Web
            driver.Navigate().GoToUrl("https://web.whatsapp.com");

            // Esperar a que el usuario inicie sesión escaneando el código QR
            MessageBox.Show("Por favor, escanea el código QR y luego haz clic en Aceptar");
            Thread.Sleep(10000); // Aumenta el tiempo de espera si es necesario

            // Encontrar el campo de búsqueda y escribir el número de teléfono
            IWebElement searchField = driver.FindElement(By.CssSelector("._3FRCZ"));
            searchField.SendKeys("3534226477");
            Thread.Sleep(2000); // Aumenta el tiempo de espera si es necesario

            // Encontrar el chat deseado y hacer clic en él
            IWebElement chat = driver.FindElement(By.CssSelector("._2wP_Y"));
            chat.Click();

            // Cerrar el controlador
            driver.Quit();
        }
    }
}
