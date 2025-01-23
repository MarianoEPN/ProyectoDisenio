using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ResultadoAprendizaje
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        // Relación inversa con ProgramaResultadoAprend y EuraceResultadoAprendizaje
        public List<ProgramaResultadoAprend> ProgramasResultadoAprend { get; set; }
        public List<EuraceResultadoAprendizaje> EuraceResultadosAprendizaje { get; set; }
        public List<MatchResultadoAprendizaje> MatchResultadosAprendizaje { get; set; }
        public Carrera Carrera { get; set; }


        // Constructor vacío
        public ResultadoAprendizaje()
        {
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
            MatchResultadosAprendizaje = new List<MatchResultadoAprendizaje>();
        }

        // Constructor con parámetros
        public ResultadoAprendizaje( string codigo, string descripcion, Carrera carrera)
        {
           
            Codigo = codigo;
            Descripcion = descripcion;
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
            MatchResultadosAprendizaje = new List<MatchResultadoAprendizaje>();
            Carrera = carrera;


        }

        // Método ToString
        public override string ToString()
        {
            return $"ResultadoAprendizaje: [ID: {Id}, Código: {Codigo}, Descripción: {Descripcion}]";
        }
    }

}
