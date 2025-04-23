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
    public class clsMatricula
    {
        private DBEstudiantesEntities dbestudiantes = new DBEstudiantesEntities();
        public Matricula matricula { get; set; }

        public string Registrar(Matricula matricula)
        {
            try
            {
                matricula.TotalMatricula = matricula.NumeroCreditos * matricula.ValorCredito;
                matricula.FechaMatricula = DateTime.Now;
                dbestudiantes.Matriculas.Add(matricula);
                dbestudiantes.SaveChanges();
                return "Matricula registrada con exito. \n";

            }
            catch (Exception ex)
            {
                return "Error al registrar la matricula. " + ex.Message;
            }
        }

        public Matricula Consultar(int idEstudiante, string semestre)
        {
            return dbestudiantes.Matriculas
                .FirstOrDefault(m => m.idEstudiante == idEstudiante && m.SemestreMatricula == semestre);
        }

        public string Actualizar(Matricula matricula)
        {
            try
            {
                var existente = Consultar(matricula.idEstudiante, matricula.SemestreMatricula);
                if (existente == null)
                {
                    return "La matrícula no existe.";
                }

                // Se actualizan campos
                existente.NumeroCreditos = matricula.NumeroCreditos;
                existente.ValorCredito = matricula.ValorCredito;
                existente.TotalMatricula = matricula.NumeroCreditos * matricula.ValorCredito;
                existente.MateriasMatriculadas = matricula.MateriasMatriculadas;
                dbestudiantes.SaveChanges();
                return "Matrícula actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar la matrícula: " + ex.Message;
            }
        }
        public string Eliminar(int idEstudiante, string semestre)
        {
            try
            {
                var matricula = Consultar(idEstudiante, semestre);
                if (matricula == null)
                {
                    return "La matrícula no existe.";
                }
                dbestudiantes.Matriculas.Remove(matricula);
                dbestudiantes.SaveChanges();
                return "Matrícula eliminada correctamente.";

            }
            catch (Exception ex)
            {
                return "Error al eliminar la matrícula: " + ex.Message;
            }
        }
    }
}