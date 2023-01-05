using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable
{
    public partial class frmCarga : Form
    {
        public frmCarga()
        {
            InitializeComponent();
            CircleProgress.Value = 0;
            //Negocio.FGenerales.SetearFormato(this);
        }

        private void tAparece_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            CircleProgress.Value += 1;
            CircleProgress.Text = CircleProgress.Value.ToString();
            if (CircleProgress.Value == 100)
            {
                tAparece.Stop();
                tDesaparece.Start();
            }
        }

        private void tDesaparece_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                frmInicio Inicio = new frmInicio();

                tDesaparece.Stop();
                this.Close();

                Inicio.ShowDialog();
            }
        }

        private void frmCarga_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            tAparece.Start();
        }
    }
}
