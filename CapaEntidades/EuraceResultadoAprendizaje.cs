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

        public int ObjEuraceId { get; set; }           // Agregado para identificar el objetivo
        public int ResultadoAprendizajeId { get; set; }  // Agregado para identificar el resultado

        // Constructor vacío
        public EuraceResultadoAprendizaje()
        {
            Comentario = "";
        }

        // Constructor con parámetros
        public EuraceResultadoAprendizaje(string comentario)
        {

            Comentario = comentario;
        }

        // Método ToString
        public override string ToString()
        {
            return $"EuraceResultadoAprendizaje: [ID: {Id}, Comentario: {Comentario}]";
        }
    }

}
