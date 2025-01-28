using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Carrera
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public string Correo { get; set; }
        public string Pensum { get; set; }
        // Relación con CarreraAsignatura (Muchos a Muchos con Asignatura)
        public List<Asignatura> Asignaturas { get; set; }
        public List<ResultadoAprendizaje> ResultadoAprendizaje { get; set; }
        public List<ObjetivoPrograma> ObjetivoPrograma { get; set; }

        // Constructor vacío
        public Carrera()
        {
            Asignaturas = new List<Asignatura>();
            ResultadoAprendizaje = new List<ResultadoAprendizaje>();
            ObjetivoPrograma = new List<ObjetivoPrograma>();
            Nombre = "";
            Correo = "";
            Pensum = "";

        }


        // Constructor con parámetros
        public Carrera( string nombre, string correo, string pensum)
        {
            
            Nombre = nombre;
            Correo = correo;
            Pensum = pensum;
            Asignaturas = new List<Asignatura>();
            ResultadoAprendizaje = new List<ResultadoAprendizaje>();
            ObjetivoPrograma = new List<ObjetivoPrograma>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"Carrera: {Nombre} (ID: {Id})";
        }
    }
}