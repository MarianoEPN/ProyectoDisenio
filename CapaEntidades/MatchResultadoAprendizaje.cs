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
        public int PerfilEgresoId { get; set; }
        public int SubResultadoAprendizajeId { get; set; }
        public string NivelAporte { get; set; }

       

        // Constructor vacío
        public MatchResultadoAprendizaje()
        {
        }

        // Constructor con parámetros
        public MatchResultadoAprendizaje( int perfilEgresoId, int subResultadoAprendizajeId, string nivelAporte)
        {
           
            PerfilEgresoId = perfilEgresoId;
            SubResultadoAprendizajeId = subResultadoAprendizajeId;
            NivelAporte = nivelAporte;
            
        }

        // Método ToString
        public override string ToString()
        {
            return $"MatchResultadoAprendizaje: [ID: {Id}, PerfilEgresoID: {PerfilEgresoId}, SubResultadoID: {SubResultadoAprendizajeId}, NivelAporte: {NivelAporte}]";
        }
    }

}
