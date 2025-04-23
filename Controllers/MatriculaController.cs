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
    [RoutePrefix("api/matricula")]
    [Authorize]
    public class MatriculaController : ApiController
    {
        clsMatricula cls = new clsMatricula();

        [HttpPost]
        [Route("registrar")]
        public IHttpActionResult Registrar([FromBody] Matricula matricula)
        {
            var resultado = cls.Registrar(matricula);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("consultar")]
        [Authorize]
        public IHttpActionResult Consultar(int idEstudiante, string semestre)
        {
            clsMatricula cls = new clsMatricula();
            var matricula = cls.Consultar(idEstudiante, semestre);
            if (matricula == null)
            {
                return NotFound();
            }
            return Ok(matricula);
        }

        [HttpPut]
        [Route("actualizar")]
        public IHttpActionResult Actualizar([FromBody] Matricula matricula)
        {
            var resultado = cls.Actualizar(matricula);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("eliminar")]
        public IHttpActionResult Eliminar(int idEstudiante, string semestre)
        {
            var resultado = cls.Eliminar(idEstudiante, semestre);
            return Ok(resultado);
        }
    }
}