using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entity;

namespace Model
{
    public class ClsMateriasPrimasDAL
    {
        public int Agregar(ClsMateriasPrimas pMateriasPrimas)
        {
            int retorno = 0;
           
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "guardarMateriasPrimas";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", pMateriasPrimas.Codigo);
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", pMateriasPrimas.Nombre);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@min", pMateriasPrimas.Stock_Minimo);
            cmd.Parameters["@min"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@max", pMateriasPrimas.Stock_Maximo);
            cmd.Parameters["@max"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@exis", pMateriasPrimas.Existencias);
            cmd.Parameters["@exis"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@disp", pMateriasPrimas.Disponibilidad);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public int Actualizar(ClsMateriasPrimas pMateriasPrimas)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "actualizarMateriasPrimas";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod", pMateriasPrimas.Codigo);
            cmd.Parameters["@cod"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@nom", pMateriasPrimas.Nombre);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@min", pMateriasPrimas.Stock_Minimo);
            cmd.Parameters["@min"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@max", pMateriasPrimas.Stock_Maximo);
            cmd.Parameters["@max"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@exis", pMateriasPrimas.Existencias);
            cmd.Parameters["@exis"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@disp", pMateriasPrimas.Disponibilidad);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public int Eliminar(string pCodigo)
        {
            int retorno = 0;
           
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "eliminarMateriasPrimas";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod", pCodigo);
            cmd.Parameters["@cod"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        public DataTable cargarMaterias()
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarMaterias";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }
       
        public int MateriaRegistrada(string Nombre)
        {
            int resultado = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "materiaRegistrada";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom", Nombre);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado++;
            }

            return resultado;
        }
      
    }
}
