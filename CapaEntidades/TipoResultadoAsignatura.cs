using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TipoResultadoAsignatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public ICollection<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }

        // Constructor vacío
        public TipoResultadoAsignatura()
        {
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
        }

        // Constructor con parámetros
        public TipoResultadoAsignatura( string codigo, string nombre)
        {
         
            Codigo = codigo;
            Nombre = nombre;
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"TipoResultadoAsignatura: [ID: {Id}, Código: {Codigo}, Nombre: {Nombre}]";
        }
    }

}
