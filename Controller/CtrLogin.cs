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
    public class CtrLogin
    {
        public int Validar(string Usuario, string Contraseña)
        {
            ClsLogin eLogin = new ClsLogin();

            eLogin.Usuario = Usuario;
            eLogin.Contraseña = Contraseña;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            int resultado = mUsuario.Autentificar(eLogin);
            return resultado;
        }
        //public int ValidarUsuario(string Usuario)
        //{          
        //    ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
        //    return mUsuario.ValidarUsuario(Usuario);
        //}
        public int Recuperar(string Usuario)
        {
            ClsUsuario eUsuario = new ClsUsuario();

            eUsuario.Usuario = Usuario;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            int resultado = mUsuario.AutentificarUsuario(eUsuario);
            return resultado;
        }

        public int Seguridad(string Pregunta, string Respuesta)
        {
            ClsUsuario eUsuario = new ClsUsuario();

            eUsuario.Usuario = Pregunta;
            eUsuario.Usuario = Respuesta;

            ClsUsuarioDAL mUsuario = new ClsUsuarioDAL();
            int resultado = mUsuario.Seguridad(Pregunta, Respuesta);
            return resultado;
        }

    }
}
