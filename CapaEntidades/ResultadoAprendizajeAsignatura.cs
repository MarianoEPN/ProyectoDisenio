using CapaEntidades;
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

        // Constructor vacío
        public ResultadoAprendizajeAsignatura()
        {
            EuraceResultados = new List<EuraceResultadoAsignatura>();
            MatchesResultadoAprendizaje = new List<MatchResultadoAprendizaje>();
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
        }

        // Constructor con parámetros
        public ResultadoAprendizajeAsignatura(int id, string codigo, string descripcion, int asignaturaId, Asignatura asignatura, int tipoId, TipoResultadoAsignatura tipoResultado)
        {
            Id = id;
            Codigo = codigo;
            Descripcion = descripcion;
            AsignaturaId = asignaturaId;
            Asignatura = asignatura;
            TipoId = tipoId;
            TipoResultado = tipoResultado;
            EuraceResultados = new List<EuraceResultadoAsignatura>();
            MatchesResultadoAprendizaje = new List<MatchResultadoAprendizaje>();
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"ResultadoAprendizajeAsignatura: [ID: {Id}, Código: {Codigo}, Descripción: {Descripcion}, Asignatura: {Asignatura?.Nombre}, Tipo: {TipoResultado?.Nombre}]";
        }
    }

}
