using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class MUsuario
    {
        public int usu_codigo { get; set;}
        public string usu_nombre { get; set;}
        public string usu_login { get; set;}
        public string per_descri { get; set;}
        public string usu_direccion { get; set; }
        public int usu_perfil { get; set;}
        public string usu_telefono { get; set;}
        public DateTime usu_fecnac { get; set;}
        public int usu_estado { get; set;}
        public int usu_vendedor { get; set;}
        public int usu_seccion { get; set;}
        public string ven_nombre { get; set;}
    }
}
