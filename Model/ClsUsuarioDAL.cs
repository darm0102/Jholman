using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using Entity;
using System.Data;

namespace Model
{
    public class ClsUsuarioDAL
    {
        public int CrearCuenta(ClsUsuario pUsuario)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "guardarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom", pUsuario.Nombre);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@user", pUsuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pass", pUsuario.Contraseña);
            cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pre", pUsuario.idPregunta);
            cmd.Parameters["@pre"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@res", pUsuario.Respuesta);
            cmd.Parameters["@res"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@rol", pUsuario.idRol);
            cmd.Parameters["@rol"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@est", pUsuario.Estado);
            cmd.Parameters["@est"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        public int Autentificar(ClsLogin pLogin)
        {
            int resultado = -1;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "autentificarLogin";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", pLogin.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pass", pLogin.Contraseña);
            cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

            //cmd.Parameters.AddWithValue("@est", pLogin.Estado);
            //cmd.Parameters["@est"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado = 50;
            }

            return resultado;
        }
        //public int ValidarUsuario(string Usuario)
        //{
        //    int resultado = -1;

        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = BdConexion.ObtenerConexion();

        //    cmd.CommandText = "validarUsuario";
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    MySqlDataReader _reader = cmd.ExecuteReader();
        //    while (_reader.Read())
        //    {
        //        resultado = 50;
        //    }

        //    return resultado;
        //}
        public int AutentificarUsuario(ClsUsuario pUsuario)
        {
            int resultado = -1;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "autentificarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", pUsuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado = 50;
            }

            return resultado;
        }
        public int Seguridad(string idPregunta, string Respuesta)
        {
            int resultado = -1;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "seguridad";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pre", idPregunta);
            cmd.Parameters["@pre"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@res", Respuesta);
            cmd.Parameters["@res"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado = 50;
            }

            return resultado;
        }
        public int ContraseñaNueva(ClsUsuario pUsuario)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "nuevoPassword";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", pUsuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pass", pUsuario.Contraseña);
            cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
        public int UsuarioRegistrado(string Usuario)
        {
            int resultado = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "usuarioRegistrado";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                resultado++;
            }

            return resultado;
        }
        public int Actualizar(ClsUsuario pUsuario)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "actualizarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom", pUsuario.Nombre);
            cmd.Parameters["@nom"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@user", pUsuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pass", pUsuario.Contraseña);
            cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@pre", pUsuario.idPregunta);
            cmd.Parameters["@pre"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@res", pUsuario.Respuesta);
            cmd.Parameters["@res"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }        
        public DataTable cargarUsuarioInhabilitado()
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarUsuarioInhabilitado";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }
        public DataTable cargarUsuarioHabilitado()
        {
            DataTable dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarUsuarioHabilitado";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }
        public static List<ClsPregunta> cargarPreguntas()
        {
            List<ClsPregunta> _lista = new List<ClsPregunta>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "cargarPreguntas";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                ClsPregunta pPregunta = new ClsPregunta();
                pPregunta.IdPregunta = _reader.GetInt32(0);
                pPregunta.NombrePregunta = _reader.GetString(1);

                _lista.Add(pPregunta);
            }
            return _lista;
        }

        public int Habilitar(ClsUsuario Usuario)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "habilitarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", Usuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        public int Inhabilitar(ClsUsuario Usuario)
        {
            int retorno = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = BdConexion.ObtenerConexion();

            cmd.CommandText = "inhabilitarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", Usuario.Usuario);
            cmd.Parameters["@user"].Direction = ParameterDirection.Input;

            retorno = cmd.ExecuteNonQuery();
            return retorno;
        }
    }
}
    
