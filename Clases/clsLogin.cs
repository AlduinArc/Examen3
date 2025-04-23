using Examen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Codigo realizado por
//Carlos Andrés Jaramillo Arias  Cc 1.039.447.735
//ALAN ARIAS RUIZ CC1000441329
namespace Examen3.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBEstudiantesEntities dbestudiantes = new DBEstudiantesEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Estudiante usuario = dbestudiantes.Estudiantes.FirstOrDefault(u => u.NombreCompleto == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                //byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                //string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                //login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                Estudiante usuario = dbestudiantes.Estudiantes.FirstOrDefault(u => u.NombreCompleto == login.Usuario && u.Clave == login.Clave);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                Estudiante usuario = dbestudiantes.Estudiantes
            .FirstOrDefault(u => u.NombreCompleto == login.Usuario && u.Clave == login.Clave);
                if (usuario != null)
                {
                    loginRespuesta.Usuario = usuario.NombreCompleto;
                    loginRespuesta.Autenticado = true;
                    loginRespuesta.Token = token;
                    loginRespuesta.Mensaje = "Login exitoso";
                }
                else
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no encontrado tras validación";
                }
            }

            return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
        }
            
    }
}