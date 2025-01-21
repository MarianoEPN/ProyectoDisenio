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

        // Relación inversa con ProgramaResultadoAprend
        public List<ProgramaResultadoAprend> ProgramasResultadoAprend { get; set; }

        public Carrera Carrera { get; set; }

        // Constructor vacío
        public ObjetivoPrograma()
        {
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
        }

        // Constructor con parámetros
        public ObjetivoPrograma(int id, string nombre, string fortalezas, string debilidades, Carrera carrera)
        {
            Id = id;
            Nombre = nombre;
            Fortalezas = fortalezas;
            Debilidades = debilidades;
            ProgramasResultadoAprend = new List<ProgramaResultadoAprend>();
            Carrera = carrera;
        }

        // Método ToString
        public override string ToString()
        {
            return $"ObjetivoPrograma: [ID: {Id}, Nombre: {Nombre}, Fortalezas: {Fortalezas}, Debilidades: {Debilidades}]";
        }
    }

}
