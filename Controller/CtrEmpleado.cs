using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Model;
using System.Data;

namespace Controller
{
    public class CtrEmpleado
    {
        public int Guardar(string TipoDocumento, string Identificacion, string Nombres, string Apellidos, string Genero, string Telefono, string Celular, string Cargo)
        {
            int resultado = 0;
            ClsEmpleado eEmpleado = new ClsEmpleado();
            eEmpleado.TipoDocumento = TipoDocumento;
            eEmpleado.Identificación = Identificacion;
            eEmpleado.Nombres = Nombres;
            eEmpleado.Apellidos = Apellidos;
            eEmpleado.Genero = Genero;
            eEmpleado.Telefono = Telefono;
            eEmpleado.Celular = Celular;
            eEmpleado.idCargo = Convert.ToInt32(Cargo);
            eEmpleado.Estado = true;

            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            resultado = mEmpleado.Agregar(eEmpleado);
            return resultado;
        }

        public int Actualizar(string TipoDocumento, string Identificacion, string Nombres, string Apellidos, string Genero, string Telefono, string Celular, string Cargo)
        {
            int resultado = 0;
            ClsEmpleado eEmpleado = new ClsEmpleado();
            eEmpleado.TipoDocumento = TipoDocumento;
            eEmpleado.Identificación = Identificacion;
            eEmpleado.Nombres = Nombres;
            eEmpleado.Apellidos = Apellidos;
            eEmpleado.Genero = Genero;
            eEmpleado.Telefono = Telefono;
            eEmpleado.Celular = Celular;
            eEmpleado.idCargo = Convert.ToInt32(Cargo);

            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            resultado = mEmpleado.Actualizar(eEmpleado);
            return resultado;
        }
        public int Habilitar(string Identificacion)
        {
            int resultado = 0;
            ClsEmpleado eEmpleado = new ClsEmpleado();
            eEmpleado.Identificación = Identificacion;

            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            resultado = mEmpleado.Habilitar(eEmpleado);
            return resultado;
        }
        public int Inhabilitar(string Identificacion)
        {
            int resultado = 0;
            ClsEmpleado eEmpleado = new ClsEmpleado();
            eEmpleado.Identificación = Identificacion;

            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            resultado = mEmpleado.Inhabilitar(eEmpleado);
            return resultado;
        }
        public DataTable cargarEmpleadoHabilitado()
        {
            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            return mEmpleado.cargarEmpleadoHabilitado();
        }
        public DataTable cargarEmpleadoInhabilitado()
        {
            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            return mEmpleado.cargarEmpleadoInhabilitado();
        }
        //public int Eliminar(int Identificacion)
        //{
        //    ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
        //    return mEmpleado.Eliminar(Identificacion);
        //}
        public int EmpleadoRegistrado(int Identificacion)
        {
            ClsEmpleadosDAL mEmpleado = new ClsEmpleadosDAL();
            return mEmpleado.EmpleadoRegistrado(Identificacion);
        }
    }
}
