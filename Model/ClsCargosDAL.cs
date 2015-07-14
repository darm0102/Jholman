using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using MySql.Data.MySqlClient;

namespace Model
{
    public class ClsCargosDAL
    {
        public List<ClsCargo> Consultar(string pNombre)
        {
            List<ClsCargo> _lista = new List<ClsCargo>();

            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM cargos WHERE nombre_cargo ='{0}'", pNombre), BdConexion.ObtenerConexion());

            //MySqlCommand cmd = new MySqlCommand();
            //cmd.Connection = BdConexion.ObtenerConexion();

            //cmd.CommandText = "consultarEmpleado";
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@id", pIdentificación);
            //cmd.Parameters["@id"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsCargo eCargo = new ClsCargo();
                eCargo.Codigo = _reader.GetString(0);
                eCargo.Nombre = _reader.GetString(1);

                _lista.Add(eCargo);
            }

            return _lista;
        }

        public static ClsCargo ObtenerCargo(string pNombre)
        {
            ClsCargo eCargo = new ClsCargo();

            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM cargos WHERE idCargo ='{0}'", pNombre), BdConexion.ObtenerConexion());

            //MySqlCommand cmd = new MySqlCommand();
            //cmd.Connection = BdConexion.ObtenerConexion();

            //cmd.CommandText = "consultarCargo";
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@car", pCargo);
            //cmd.Parameters["@car"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                eCargo.Codigo = _reader.GetString(0);
                eCargo.Nombre = _reader.GetString(1);
            }

            conexion.Close();
            return eCargo;
        }

        public List<ClsCargo> cargarCargos()
        {
            List<ClsCargo> _lista = new List<ClsCargo>();

            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Select * from cargos"), conexion);

            MySqlDataReader _reader = comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsCargo pCargo = new ClsCargo();
                pCargo.Codigo = _reader.GetString(0);
                pCargo.Nombre = _reader.GetString(1);


                _lista.Add(pCargo);
            }

            return _lista;
        }

    }
}
