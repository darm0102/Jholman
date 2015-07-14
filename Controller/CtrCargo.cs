using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Entity;

namespace Controller
{
    public class CtrCargo
    {
        public List<ClsCargo> Listar(string Nombre)
        {
            ClsCargosDAL mCargo = new ClsCargosDAL();
            return mCargo.Consultar(Nombre);
        }

        public List<ClsCargo> cargarCargos()
        {
            ClsCargosDAL mCargo = new ClsCargosDAL();
            return mCargo.cargarCargos();
        }
    }
}
