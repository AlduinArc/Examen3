using Examen3.Clases;
using Examen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen3.Controllers
{
    [RoutePrefix("api/estudiantes")]
    public class EstudiantesController : ApiController
    {
        clsEstudiante estudianteService = new clsEstudiante();

        [HttpPost]
        [Route("crear")]
        public string Crear([FromBody] Estudiante e)
        {
            return estudianteService.CrearEstudiante(e.Documento, e.NombreCompleto, e.Usuario, e.Clave);
        }

        [HttpGet]
        [Route("consultar")]
        public Estudiante Consultar(string documento)
        {
            return estudianteService.ConsultarEstudiante(documento);
        }

        [HttpPut]
        [Route("actualizar")]
        public string Actualizar([FromBody] Estudiante e)
        {
            return estudianteService.ActualizarEstudiante(e.Documento, e.NombreCompleto, e.Usuario, e.Clave);
        }

        [HttpDelete]
        [Route("eliminar")]
        public string Eliminar(string documento)
        {
            return estudianteService.EliminarEstudiante(documento);
        }

    }
}