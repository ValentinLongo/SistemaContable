using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class MConceptoContable
    {
        public int coc_codigo { get; set; }
        public string coc_descri { get; set; }
        public int coc_vta { get; set; }
        public int coc_cpa { get; set; }
        public int coc_caja { get; set; }
        public int coc_banco { get; set; }
        public int coc_ctacont { get; set; }
        public int coc_contrap { get; set; }
        public int coc_cccta { get; set; }
        public int coc_cccontrap { get; set; }
        public string pcu_descriCuenta { get; set; }
        public string pcu_descriContrap { get; set; }
    }
}
