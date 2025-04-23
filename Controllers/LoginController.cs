using Examen3.Clases;
using Examen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Codigo realizado por
//Carlos Andrés Jaramillo Arias  Cc 1.039.447.735
//ALAN ARIAS RUIZ CC1000441329
namespace Examen3.Controllers
{
    [RoutePrefix("api/login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost] 
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar ([FromBody] Login login)
        {
            clsLogin _login = new clsLogin();
            _login.login = login;
            return _login.Ingresar();
        }
    }
}