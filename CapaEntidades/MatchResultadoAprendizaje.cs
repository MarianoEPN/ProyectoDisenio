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

        // Clave foránea hacia ResultadoAprendizajeAsignatura
        public int ResultadoAprendizajeAsignaturaId { get; set; }
        public ResultadoAprendizajeAsignatura ResultadoAprendizajeAsignatura { get; set; }
        public ResultadoAprendizaje ResultadoAprendizaje { get; set; }
        public int ResultadoAprendizajeId { get; set; }


        // Constructor vacío
        public MatchResultadoAprendizaje()
        {
        }

        // Constructor con parámetros
        public MatchResultadoAprendizaje( int perfilEgresoId, int subResultadoAprendizajeId, string nivelAporte, int resultadoAprendizajeAsignaturaId, ResultadoAprendizajeAsignatura resultadoAprendizajeAsignatura, int resultadoAprendizajeId, ResultadoAprendizaje resultadoAprendizaje)
        {
           
            PerfilEgresoId = perfilEgresoId;
            SubResultadoAprendizajeId = subResultadoAprendizajeId;
            NivelAporte = nivelAporte;
            ResultadoAprendizajeAsignaturaId = resultadoAprendizajeAsignaturaId;
            ResultadoAprendizajeAsignatura = resultadoAprendizajeAsignatura;
            ResultadoAprendizajeId = resultadoAprendizajeId;
            ResultadoAprendizaje = resultadoAprendizaje;
        }

        // Método ToString
        public override string ToString()
        {
            return $"MatchResultadoAprendizaje: [ID: {Id}, PerfilEgresoID: {PerfilEgresoId}, SubResultadoID: {SubResultadoAprendizajeId}, NivelAporte: {NivelAporte}, ResultadoAsignatura: {ResultadoAprendizajeAsignatura?.Descripcion}]";
        }
    }

}
