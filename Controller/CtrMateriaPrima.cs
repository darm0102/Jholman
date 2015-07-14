using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Entity;
using System.Data;

namespace Controller
{
    public class CtrMateriaPrima
    {
        public int Guardar(string Nombre, int Stock_Minimo, int Stock_Maximo, string Disponibilidad)
        {
            int resultado = 0;
            ClsMateriasPrimas eMateriasPrimas = new ClsMateriasPrimas();
            eMateriasPrimas.Nombre = Nombre;
            eMateriasPrimas.Stock_Minimo = Stock_Minimo;
            eMateriasPrimas.Stock_Maximo = Stock_Maximo;
            eMateriasPrimas.Disponibilidad = Disponibilidad;

            ClsMateriasPrimasDAL mMateriasPrimas = new ClsMateriasPrimasDAL();
            resultado = mMateriasPrimas.Agregar(eMateriasPrimas);
            return resultado;
        }

        public int Actualizar(string Nombre, int Stock_Minimo, int Stock_Maximo, string Disponibilidad)
        {
            int resultado = 0;
            ClsMateriasPrimas eMateriasPrimas = new ClsMateriasPrimas();
            eMateriasPrimas.Nombre = Nombre;
            eMateriasPrimas.Stock_Minimo = Stock_Minimo;
            eMateriasPrimas.Stock_Maximo = Stock_Maximo;
            eMateriasPrimas.Disponibilidad = Disponibilidad;

            ClsMateriasPrimasDAL mMateriasPrimas = new ClsMateriasPrimasDAL();
            resultado = mMateriasPrimas.Actualizar(eMateriasPrimas);
            return resultado;
        }
        public int Eliminar(string Codigo)
        {
            ClsMateriasPrimasDAL mMateriasPrimas = new ClsMateriasPrimasDAL();
            return mMateriasPrimas.Eliminar(Codigo);
        }       
        public DataTable cargarMaterias()
        {
            ClsMateriasPrimasDAL mMaterias = new ClsMateriasPrimasDAL();
            return mMaterias.cargarMaterias();
        }
        //public List<ClsMateriasPrimas> Listar(int Codigo)
        //{
        //    ClsMateriasPrimasDAL mMaterias = new ClsMateriasPrimasDAL();
        //    return mMaterias.Consultar(Codigo);
        //}
        public int MateriaRegistrada(string Nombre)
        {
            ClsMateriasPrimasDAL mMaterias = new ClsMateriasPrimasDAL();
            return mMaterias.MateriaRegistrada(Nombre);
        }
    }
}
