using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EuraceResultadoAprendizaje
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        // Clave foránea hacia ObjetivoEurace
        public int ObjEuraceId { get; set; }
        public ObjetivoEurace ObjetivoEurace { get; set; }

        // Clave foránea hacia ResultadoAprendizaje
        public int ResultadoAprendizajeId { get; set; }
        public ResultadoAprendizaje ResultadoAprendizaje { get; set; }

        // Constructor vacío
        public EuraceResultadoAprendizaje()
        {
        }

        // Constructor con parámetros
        public EuraceResultadoAprendizaje(int id, string comentario, int objEuraceId, ObjetivoEurace objetivoEurace, int resultadoAprendizajeId, ResultadoAprendizaje resultadoAprendizaje)
        {
            Id = id;
            Comentario = comentario;
            ObjEuraceId = objEuraceId;
            ObjetivoEurace = objetivoEurace;
            ResultadoAprendizajeId = resultadoAprendizajeId;
            ResultadoAprendizaje = resultadoAprendizaje;
        }

        // Método ToString
        public override string ToString()
        {
            return $"EuraceResultadoAprendizaje: [ID: {Id}, Comentario: {Comentario}, ObjetivoEurace: {ObjetivoEurace?.Nombre}, ResultadoAprendizaje: {ResultadoAprendizaje?.Codigo}]";
        }
    }

}
