using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public List<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }

        // Relación con CarreraAsignatura (Muchos a Muchos con Carrera)
        public List<Carrera> Carreras { get; set; }

        public Asignatura()
        {
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
            Carreras = new List<Carrera>();
        }

        // Constructor con parámetros
        public Asignatura(int id, string codigo, string nombre, int nivel)
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Nivel = nivel;
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
            Carreras = new List<Carrera>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"Asignatura: {Nombre} (Código: {Codigo}, Nivel: {Nivel})";
        }
    }

}
