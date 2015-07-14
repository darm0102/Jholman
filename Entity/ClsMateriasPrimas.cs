using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClsMateriasPrimas
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public int Existencias { get; set; }
        public string Disponibilidad { get; set; }
    }
}
