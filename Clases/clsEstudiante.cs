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
	

    public class clsEstudiante
	{
        private DBEstudiantesEntities dbestudiantes = new DBEstudiantesEntities();
        public Estudiante estudiante { get; set; }
        public string CrearEstudiante(string documento, string nombreCompleto, string usuario, string clave)
        {
            try
            {
                if (dbestudiantes.Estudiantes.FirstOrDefault(e => e.Documento == documento)!=null)
                    
                    return "El usuario ya existe.";

                Estudiante nuevo = new Estudiante
                {
                    Documento = documento,
                    NombreCompleto = nombreCompleto,
                    Usuario = usuario,
                    Clave = clave 
                };

                dbestudiantes.Estudiantes.Add(nuevo);
                dbestudiantes.SaveChanges();
                return "Estudiante creado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al crear estudiante: " + ex.Message;
            }
        }

        public Estudiante ConsultarEstudiante(string documento)
        {
            return dbestudiantes.Estudiantes.FirstOrDefault(e => e.Documento == documento);
        }

        public string ActualizarEstudiante(string documento, string nuevoNombre, string nuevoUsuario, string nuevaClave)
        {
            try
            {
                var estudiante = dbestudiantes.Estudiantes.FirstOrDefault(e => e.Documento == documento);
                if (estudiante == null)
                    return "Estudiante no encontrado.";

                estudiante.NombreCompleto = nuevoNombre;
                estudiante.Usuario = nuevoUsuario;
                estudiante.Clave = nuevaClave; // puedes volver a cifrar

                dbestudiantes.SaveChanges();
                return "Estudiante actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public string EliminarEstudiante(string documento)
        {
            try
            {
                var estudiante = dbestudiantes.Estudiantes.FirstOrDefault(e => e.Documento == documento);
                if (estudiante == null)
                    return "Estudiante no encontrado.";

                dbestudiantes.Estudiantes.Remove(estudiante);
                dbestudiantes.SaveChanges();
                return "Estudiante eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }
    }
}