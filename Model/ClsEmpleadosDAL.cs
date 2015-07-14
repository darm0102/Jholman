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
    public class ClsEmpleadosDAL
    {
        public int Agregar(ClsEmpleado pEmpleado)
        {
            int retorno = 0;
            //MySqlConnection conexion = BdConexion.ObtenerConexion();
            //MySqlCommand _comando = new MySqlCommand(
            //String.Format("Insert into tb_empleados(tipo_documento, identificacion, nombres, apellidos, genero, telefono_fijo, telefono_celular, Tb_Cargos_idCargo) values ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
            //pEmpleado.TipoDocumento, pEmpleado.Identificación, pEmpleado.Nombres, pEmpleado.Apellidos, pEmpleado.Genero, pEmpleado.Telefono, pEmpleado.Celular, pEmpleado.idCargo), conexion);
            //retorno = _comando.ExecuteNonQuery();
            //conexion.Close();
            //return retorno;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "guardarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipo", pEmpleado.TipoDocumento);
            cmd.Parameters["@tipo"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@id", pEmpleado.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", pEmpleado.Nombres);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ape", pEmpleado.Apellidos);
            cmd.Parameters["@ape"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@gen", pEmpleado.Genero);
            cmd.Parameters["@gen"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@tel", pEmpleado.Telefono);
            cmd.Parameters["@tel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@cel", pEmpleado.Celular);
            cmd.Parameters["@cel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@car", pEmpleado.idCargo);
            cmd.Parameters["@car"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@est", pEmpleado.Estado);
            cmd.Parameters["@est"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;  
        }     
        public int Actualizar(ClsEmpleado Empleado)
        {
            int retorno = 0;          
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "actualizarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tipo", Empleado.TipoDocumento);
            cmd.Parameters["@tipo"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@id", Empleado.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", Empleado.Nombres);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ape", Empleado.Apellidos);
            cmd.Parameters["@ape"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@sex", Empleado.Genero);
            cmd.Parameters["@sex"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@tel", Empleado.Telefono);
            cmd.Parameters["@tel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@cel", Empleado.Celular);
            cmd.Parameters["@cel"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@car", Empleado.idCargo);
            cmd.Parameters["@car"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        public DataTable cargarEmpleadoInhabilitado()
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarEmpleadoInhabilitado";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }
        public DataTable cargarEmpleadoHabilitado()
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarEmpleadoHabilitado";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }      
        public int EmpleadoRegistrado(int Identificacion)
        {
            int resultado = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "empleadoRegistrado";
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
        public static List<ClsCargo> cargarCargos()
        {
            List<ClsCargo> _lista = new List<ClsCargo>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarCargos";
            cmd.CommandType = CommandType.StoredProcedure;
           
            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                ClsCargo pCargo = new ClsCargo();
                pCargo.IdCargo = _reader.GetInt32(0);
                pCargo.NombreCargo = _reader.GetString(1);

                _lista.Add(pCargo);
            }
            return _lista;
        }
        public int Habilitar(ClsEmpleado Empleado)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "habilitarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Empleado.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public int Inhabilitar(ClsEmpleado Empleado)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "inhabilitarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Empleado.Identificación);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
    }
}
