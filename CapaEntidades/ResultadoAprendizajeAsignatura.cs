using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ResultadoAprendizajeAsignatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        // Clave foránea hacia Asignatura
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        // Clave foránea hacia TipoResultadoAsignatura
        public int TipoId { get; set; }
        public TipoResultadoAsignatura TipoResultado { get; set; }

        // Relaciones con tablas relacionadas (Uno a Muchos)
        public ICollection<EuraceResultadoAsignatura> EuraceResultados { get; set; }
        public ICollection<MatchResultadoAprendizaje> MatchesResultadoAprendizaje { get; set; }
        public ICollection<ProgramaResultadoAprend> ProgramasResultadoAprend { get; set; }
    }

}
