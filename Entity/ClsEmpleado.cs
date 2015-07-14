using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClsEmpleado
    {
        public string TipoDocumento { get; set; }
        public string Identificación { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }       
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int idCargo { get; set; }
        public bool Estado { get; set; }
    }
}
