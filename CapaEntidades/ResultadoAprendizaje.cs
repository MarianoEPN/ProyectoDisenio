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
        public List<ProgramaResultadoAprendizaje> ProgramasResultadoAprend { get; set; }
        public List<EuraceResultadoAprendizaje> EuraceResultadosAprendizaje { get; set; }
        public List<MatchResultadoAprendizaje> MatchResultadosAprendizaje { get; set; }
     

        // Constructor vacío
        public ResultadoAprendizaje()
        {
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
            MatchResultadosAprendizaje = new List<MatchResultadoAprendizaje>();
            Codigo = "";
            Descripcion = "";

        }

        // Constructor con parámetros
        public ResultadoAprendizaje( string codigo, string descripcion, Carrera carrera)
        {
           
            Codigo = codigo;
            Descripcion = descripcion;
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
            MatchResultadosAprendizaje = new List<MatchResultadoAprendizaje>();
           


        }

        // Método ToString
        public override string ToString()
        {
            return $"{Codigo}, {Descripcion}";
        }
    }

}
