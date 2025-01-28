using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Asignatura
    {
        // Propiedades
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
      

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public List<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }

        // Relación con CarreraAsignatura (Muchos a Muchos con Carrera)
      

        public Asignatura()
        {
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
            Codigo = "";
            Nombre = "";
            Nivel = 0;


        }

        // Constructor con parámetros
        public Asignatura( string codigo, string nombre, int nivel)
        {
           
            Codigo = codigo;
            Nombre = nombre;
            Nivel = nivel;
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
            
        }

        // Método ToString
        public override string ToString()
        {
            return $"Asignatura: {Nombre} (Código: {Codigo}, Nivel: {Nivel})";
        }
    }

}
