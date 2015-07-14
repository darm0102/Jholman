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
    public class CtrProveedor
    {
        public int Guardar(string TipoDocumento, int Identificacion, string Nombres, string Apellidos, string Genero, string Direccion, string Telefono, string Celular, string Empresa)
        {
            ClsProveedor eProveedor = new ClsProveedor();
            eProveedor.Tipo_documento = TipoDocumento;
            eProveedor.Identificación = Identificacion;
            eProveedor.Nombres = Nombres;
            eProveedor.Apellidos = Apellidos;
            eProveedor.Género = Genero;
            //pCliente.Fecha_Nac = dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;
            eProveedor.Dirección = Direccion;
            eProveedor.Telefono = Telefono;
            eProveedor.Celular = Celular;
            eProveedor.Empresa = Empresa;

            ClsProveedorDAL mProveedor = new ClsProveedorDAL();
            int resultado = mProveedor.Agregar(eProveedor);
            return resultado;

        }
        public int Actualizar(string TipoDocumento, int Identificacion, string Nombres, string Apellidos, string Genero, string Direccion, string Telefono, string Celular, string Empresa)
        {
            ClsProveedor eProveedor = new ClsProveedor();
            eProveedor.Tipo_documento = TipoDocumento;
            eProveedor.Identificación = Identificacion;
            eProveedor.Nombres = Nombres;
            eProveedor.Apellidos = Apellidos;
            eProveedor.Género = Genero;
            //pCliente.Fecha_Nac = dtpFechaNacimiento.Value.Year + "/" + dtpFechaNacimiento.Value.Month + "/" + dtpFechaNacimiento.Value.Day;
            eProveedor.Dirección = Direccion;
            eProveedor.Telefono = Telefono;
            eProveedor.Celular = Celular;
            eProveedor.Empresa = Empresa;

            ClsProveedorDAL mProveedor = new ClsProveedorDAL();
            int resultado = mProveedor.Actualizar(eProveedor);
            return resultado;
        }     
        
        public int Eliminar(int Identificacion)
        {
            ClsProveedorDAL mProveedor = new ClsProveedorDAL();
            return mProveedor.Eliminar(Identificacion);
        }
        public int ProveedorRegistrado(int Identificacion)        
        {
            ClsProveedorDAL mProveedor = new ClsProveedorDAL();
            return mProveedor.ProveedorRegistrado(Identificacion);
        }
        //public DataTable Buscar()
        //{
        //    ClsClientesDAL mClientes = new ClsClientesDAL();
        //    return mClientes.Buscar();
        //}       
    }
}
