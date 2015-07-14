using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entity;
using System.Data;

namespace Model
{
    public class ClsProveedorDAL
    {
        public int Agregar(ClsProveedor Proveedor)        
        {
            int retorno = 0;                                   

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "guardarProveedores";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipo", Proveedor.Tipo_documento);
            cmd.Parameters["@tipo"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@id", Proveedor.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", Proveedor.Nombres);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ape", Proveedor.Apellidos);
            cmd.Parameters["@ape"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@sex", Proveedor.Género);
            cmd.Parameters["@sex"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@direc", Proveedor.Dirección);
            cmd.Parameters["@direc"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@tel", Proveedor.Telefono);
            cmd.Parameters["@tel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@cel", Proveedor.Celular);
            cmd.Parameters["@cel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@emp", Proveedor.Empresa);
            cmd.Parameters["@emp"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;                      
        }     

        public int ProveedorRegistrado(int Identificacion)        
        {
            int resultado = 0;
          
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "proveedorRegistrado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Identificacion);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado++;
            }

            return resultado;            
        }

        public int Actualizar(ClsProveedor Proveedor)        
        {
            int retorno = 0;            
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "actualizarProveedores";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipo", Proveedor.Tipo_documento);
            cmd.Parameters["@tipo"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@id", Proveedor.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", Proveedor.Nombres);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ape", Proveedor.Apellidos);
            cmd.Parameters["@ape"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@sex", Proveedor.Género);
            cmd.Parameters["@sex"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@direc", Proveedor.Dirección);
            cmd.Parameters["@direc"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@tel", Proveedor.Telefono);
            cmd.Parameters["@tel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@cel", Proveedor.Celular);
            cmd.Parameters["@cel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@emp", Proveedor.Empresa);
            cmd.Parameters["@emp"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;  
        }
        public int Eliminar(int Identificación)        
        {
            int retorno = 0;          

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "eliminarProveedores";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;      

        }        
       

        //public DataTable Buscar()
        //{
        //    MySqlConnection conexion = BdConexion.ObtenerConexion();
        //    MySqlCommand cmd = conexion.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "Select * from clientes where identificacion like('" + txtBuscar.Text + "%') or nombres like('" + txtBuscar.Text + "%')";
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    conexion.Close();
        //    return dt;
        //}
    }

}
    