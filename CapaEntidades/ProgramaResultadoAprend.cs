using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ProgramaResultadoAprend
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        // Clave foránea hacia ResultadoAprendizaje
        public int ResultadoAprendizajeId { get; set; }
        public ResultadoAprendizaje ResultadoAprendizaje { get; set; }

        // Clave foránea hacia ObjetivoPrograma
        public int ObjProgramaId { get; set; }
        public ObjetivoPrograma ObjetivoPrograma { get; set; }

        // Constructor vacío
        public ProgramaResultadoAprend()
        {
        }

        // Constructor con parámetros
        public ProgramaResultadoAprend(string comentario, int resultadoAprendizajeId, ResultadoAprendizaje resultadoAprendizaje, int objProgramaId, ObjetivoPrograma objetivoPrograma)
        {
     
            Comentario = comentario;
            ResultadoAprendizajeId = resultadoAprendizajeId;
            ResultadoAprendizaje = resultadoAprendizaje;
            ObjProgramaId = objProgramaId;
            ObjetivoPrograma = objetivoPrograma;
        }

        // Método ToString
        public override string ToString()
        {
            return $"ProgramaResultadoAprend: [ID: {Id}, Comentario: {Comentario}, ResultadoAprendizaje: {ResultadoAprendizaje?.Codigo}, ObjetivoPrograma: {ObjetivoPrograma?.Nombre}]";
        }
    }

}
