using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ProgramaResultadoAprendizaje
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        public int ObjProgramaId { get; set; }           // Agregado para identificar el objetivo
        public int ResultadoAprendizajeId { get; set; }  // Agregado para identificar el resultado

        // Constructor vacío
        public ProgramaResultadoAprendizaje()
        {
            Comentario = "";
        }

        // Constructor con parámetros
        public ProgramaResultadoAprendizaje(string comentario, int resultadoAprendizajeId, ResultadoAprendizaje resultadoAprendizaje, int objProgramaId, ObjetivoPrograma objetivoPrograma)
        {
     
            Comentario = comentario;
           
        }

        // Método ToString
        public override string ToString()
        {
            return $"ProgramaResultadoAprend: [ID: {Id}, Comentario: {Comentario}]";
        }
    }

}
