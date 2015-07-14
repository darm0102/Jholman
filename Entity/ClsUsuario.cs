using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClsUsuario
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string idPregunta { get; set; }
        public string Respuesta { get; set; }
        public int idRol { get; set; }
        public bool Estado { get; set; }
    }
}
