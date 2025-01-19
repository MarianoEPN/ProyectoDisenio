using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
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
    }

}
