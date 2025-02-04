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
        public string Comentario { get; set; }


        public int PerfilEgresoId { get; set; }           // Agregado para identificar el perfil de egreso
        public int SubResultadoAprendizageAsignaturaId { get; set; }  // Agregado para identificar el SubResultadoAprendizageAsignatura

        // Constructor vacío
        public MatchResultadoAprendizaje()
        {
            NivelAporte = "";
            Comentario = "";

        }


        // Constructor con parámetros
        public MatchResultadoAprendizaje( string nivelAporte, string comentario)
        {
           
            NivelAporte = nivelAporte;
            Comentario = comentario;

        }

        // Método ToString
        public override string ToString()
        {
            return $"MatchResultadoAprendizaje: [ID: {Id}, NivelAporte: {NivelAporte}]";
        }
    }

}
