using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ObjetivoPrograma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Fortalezas { get; set; }
        public string Debilidades { get; set; }

        public string Codigo { get; set; }

        // Relación inversa con ProgramaResultadoAprend
        public List<ProgramaResultadoAprendizaje> ProgramasResultadoAprend { get; set; }

       

        // Constructor vacío
        public ObjetivoPrograma()
        {
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
            Nombre = "";
            Fortalezas = "";
            Debilidades = "";
            Codigo = "";    
        }

        // Constructor con parámetros
        public ObjetivoPrograma( string nombre, string fortalezas, string debilidades, Carrera carrera)
        {
        
            Nombre = nombre;
            Fortalezas = fortalezas;
            Debilidades = debilidades;
            ProgramasResultadoAprend = new List<ProgramaResultadoAprendizaje>();
           
        }

        // Método ToString
        public override string ToString()
        {
            return $"ObjetivoPrograma: [ID: {Id}, Nombre: {Nombre}, Fortalezas: {Fortalezas}, Debilidades: {Debilidades}]";
        }
    }

}
