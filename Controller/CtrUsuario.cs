using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Entity;
using Model;
using System.Data;

namespace Controller
{
    public class CtrUsuario
    {
        public int Crear(string Nombre, string Usuario, string Contraseña, string Pregunta, string Respuesta)
        {
            int resultado = 0;
            ClsUsuario eUsuario = new ClsUsuario();
            eUsuario.Usuario = Usuario;
            eUsuario.Nombre = Nombre;
            eUsuario.Contraseña = Contraseña;
            eUsuario.idPregunta = Pregunta;
            eUsuario.Respuesta = Respuesta;
            eUsuario.idRol = 2;
            eUsuario.Estado = true;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            resultado = mUsuario.CrearCuenta(eUsuario);
            return resultado;
        }
        
        public int Actualizar(string Nombre, string Usuario, string Contraseña, string Pregunta, string Respuesta)
        {
            int resultado = 0;
            ClsUsuario eUsuario = new ClsUsuario();
            eUsuario.Usuario = Usuario;
            eUsuario.Nombre = Nombre;
            eUsuario.Contraseña = Contraseña;
            eUsuario.idPregunta = Pregunta;
            eUsuario.Respuesta = Respuesta;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            resultado = mUsuario.Actualizar(eUsuario);
            return resultado;
        }

        public int Habilitar (string Usuario)
        {
            int resultado = 0;
            ClsUsuario eUsuario = new ClsUsuario();
            eUsuario.Usuario = Usuario;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            resultado = mUsuario.Habilitar(eUsuario);
            return resultado;
        }
        public int Inhabilitar(string Usuario)
        {
            int resultado = 0;
            ClsUsuario eUsuario = new ClsUsuario();
            eUsuario.Usuario = Usuario;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            resultado = mUsuario.Inhabilitar(eUsuario);
            return resultado;
        }
        public DataTable cargarUsuarioHabilitado()
        {
            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            return mUsuario.cargarUsuarioHabilitado();
        }
        public DataTable cargarUsuarioInhabilitado()
        {
            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            return mUsuario.cargarUsuarioInhabilitado();
        }
        public int ContraseñaNueva(string Usuario, string Contraseña)
        {
            int resultado = 0;
            ClsUsuario eUsuario = new ClsUsuario();
            eUsuario.Usuario = Usuario;
            eUsuario.Contraseña = Contraseña;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            resultado = mUsuario.ContraseñaNueva(eUsuario);
            return resultado;
        }
        public int UsuarioRegistrado(string Usuario)
        {
            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            return mUsuario.UsuarioRegistrado(Usuario);
        }       
    }       
}
