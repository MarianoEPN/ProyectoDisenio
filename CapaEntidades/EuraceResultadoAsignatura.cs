using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
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
    }

}
