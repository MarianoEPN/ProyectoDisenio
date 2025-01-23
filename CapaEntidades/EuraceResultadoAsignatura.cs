using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EuraceResultadoAsignatura
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        // Clave foránea hacia ResultadoAprendizajeAsignatura
        public int ResultadoAsignaturaId { get; set; }
        public ResultadoAprendizajeAsignatura ResultadoAprendizajeAsignatura { get; set; }

        // Clave foránea hacia ObjetivoEurace
        public int ObjEuraceId { get; set; }
        public ObjetivoEurace ObjetivoEurace { get; set; }

        // Constructor vacío
        public EuraceResultadoAsignatura()
        {
        }

        // Constructor con parámetros
        public EuraceResultadoAsignatura(string comentario, int resultadoAsignaturaId, ResultadoAprendizajeAsignatura resultadoAprendizajeAsignatura, int objEuraceId, ObjetivoEurace objetivoEurace)
        {
         
            Comentario = comentario;
            ResultadoAsignaturaId = resultadoAsignaturaId;
            ResultadoAprendizajeAsignatura = resultadoAprendizajeAsignatura;
            ObjEuraceId = objEuraceId;
            ObjetivoEurace = objetivoEurace;
        }

        // Método ToString
        public override string ToString()
        {
            return $"EuraceResultadoAsignatura: [ID: {Id}, Comentario: {Comentario}, ResultadoAsignatura: {ResultadoAprendizajeAsignatura?.Descripcion}, ObjetivoEurace: {ObjetivoEurace?.Nombre}]";
        }
    }

}
