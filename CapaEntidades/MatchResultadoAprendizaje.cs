using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class MatchResultadoAprendizaje
    {
        public int Id { get; set; }
   
        public string NivelAporte { get; set; }

       

        // Constructor vacío
        public MatchResultadoAprendizaje()
        {
        }

        // Constructor con parámetros
        public MatchResultadoAprendizaje( string nivelAporte)
        {
           
            NivelAporte = nivelAporte;
            
        }

        // Método ToString
        public override string ToString()
        {
            return $"MatchResultadoAprendizaje: [ID: {Id}, NivelAporte: {NivelAporte}]";
        }
    }

}
