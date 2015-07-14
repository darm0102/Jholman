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
    public class CtrCliente
    {
        public int Guardar(string TipoDocumento, string Identificacion, string Nombres, string Apellidos, string Genero, string Direccion, string Telefono, string Celular, string Empresa)
        {
            Clscliente eCliente = new Clscliente();
            eCliente.Tipo_documento = TipoDocumento;
            eCliente.Identificación = Identificacion;
            eCliente.Nombres = Nombres;
            eCliente.Apellidos = Apellidos;
            eCliente.Genero = Genero;
            //pCliente.Fecha_Nac = dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;
            eCliente.Dirección = Direccion;
            eCliente.Telefono = Telefono;
            eCliente.Celular = Celular;
            eCliente.Empresa = Empresa;
            eCliente.Estado = true;

            ClsClientesDAL mCliente = new ClsClientesDAL();
            int resultado = mCliente.Agregar(eCliente);
            return resultado;
            
        }
        public int Actualizar(string TipoDocumento, string Identificacion, string Nombres, string Apellidos, string Genero, string Direccion, string Telefono, string Celular, string Empresa)
        {
            Clscliente eCliente = new Clscliente();
            eCliente.Tipo_documento = TipoDocumento;
            eCliente.Identificación = Identificacion;
            eCliente.Nombres = Nombres;
            eCliente.Apellidos = Apellidos;
            eCliente.Genero = Genero;
            //pCliente.Fecha_Nac = dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;
            eCliente.Dirección = Direccion;
            eCliente.Telefono = Telefono;
            eCliente.Celular = Celular;
            eCliente.Empresa = Empresa;

            ClsClientesDAL mCliente = new ClsClientesDAL();
            int resultado = mCliente.Actualizar(eCliente);
            return resultado;
        }
        //public List<Clscliente> Listar(int Identificacion)
        //{
        //    ClsClientesDAL mClientes = new ClsClientesDAL();
        //    return mClientes.Consultar(Identificacion);
        //}  
        public int Habilitar(string Identificacion)
        {
            int resultado = 0;
            Clscliente eCliente = new Clscliente();
            eCliente.Identificación = Identificacion;

            ClsClientesDAL mCliente = new ClsClientesDAL();
            resultado = mCliente.Habilitar(eCliente);
            return resultado;
        }
        public int Inhabilitar(string Identificacion)
        {
            int resultado = 0;
            Clscliente eCliente = new Clscliente();
            eCliente.Identificación = Identificacion;

            ClsClientesDAL mCliente = new ClsClientesDAL();
            resultado = mCliente.Inhabilitar(eCliente);
            return resultado;
        }
        public DataTable cargarClienteHabilitado()
        {
            ClsClientesDAL mCliente = new ClsClientesDAL();
            return mCliente.cargarClienteHabilitado();
        }
        public DataTable cargarClienteInhabilitado()
        {
            ClsClientesDAL mCliente = new ClsClientesDAL();
            return mCliente.cargarClienteInhabilitado();
        }
        public int ClienteRegistrado(int Identificacion)
        {
            ClsClientesDAL mClientes = new ClsClientesDAL();
            return mClientes.ClienteRegistrado(Identificacion);
        }
        //public DataTable Buscar()
        //{
        //    ClsClientesDAL mClientes = new ClsClientesDAL();
        //    return mClientes.Buscar();
        //}
       
    }
}
