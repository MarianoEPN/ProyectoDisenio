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
        public TipoResultadoAsignatura Tipo { get; set; }
        public string Descripcion { get; set; }

        // Clave foránea hacia Asignatura

        // Relaciones con tablas relacionadas (Uno a Muchos)
       
        public List<MatchResultadoAprendizaje> MatchesResultadoAprendizaje { get; set; }
        public List<ProgramaResultadoAprendizaje> ProgramasResultadoAprend { get; set; }

        // Constructor vacío
        public ResultadoAprendizajeAsignatura()
        {  
            MatchesResultadoAprendizaje = new List<MatchResultadoAprendizaje>();
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
            Codigo = "";
            Descripcion = "";
            Tipo = new TipoResultadoAsignatura();
        }


        // Constructor con parámetros
        public ResultadoAprendizajeAsignatura( string codigo, string descripcion, int asignaturaId, Asignatura asignatura, int tipoId, TipoResultadoAsignatura tipoResultado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            MatchesResultadoAprendizaje = new List<MatchResultadoAprendizaje>();
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
            Tipo = new TipoResultadoAsignatura();
        }

        // Método ToString
        public override string ToString()
        {
            return $"{Codigo} {Descripcion}";
        }
    }

}
