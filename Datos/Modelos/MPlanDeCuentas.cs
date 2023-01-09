using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class MPlanDeCuentas
    {
        public string pcu_codigo { get; set; }
        public int pcu_cuenta { get; set; }
        public string pcu_descri { get; set; }
        public string pcu_superior { get; set; }
        public int pcu_hija { get; set; }
        public int pcu_tabulador { get; set; }
        public int pcu_estado { get; set; }
        public int pcu_rubrocont { get; set; }
        public int pcu_ajustainf { get; set; }
    }
}
