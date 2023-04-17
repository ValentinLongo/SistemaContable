using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class MAsiento
    {
        public int ast_nroEjer { get; set; }
        public string ast_descriEjer { get; set; }
        public string ast_fecha { get; set; }
        public int ast_nroAsiento { get; set; }
        public string ast_comentario { get; set; }

        public int ast_cbTipoAsientoIndex { get; set; } // tipo de asiento en el combobox
        public bool ast_cbTipoAsiento { get; set; } // para activar o desactivar el control

        public bool ast_btnGenerar { get; set; } // para activar o desactivar el control
        public bool ast_btnPlanDeCuenta { get; set; } // para activar o desactivar el control
        public bool ast_btnModelo { get; set; } // para activar o desactivar el control
        public bool ast_btnImprimir { get; set; } // para activar o desactivar el control

    }
}
