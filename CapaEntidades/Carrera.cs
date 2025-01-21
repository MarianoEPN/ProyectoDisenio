using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Presum { get; set; }
        public string Correo { get; set; }

        // Relación con CarreraAsignatura (Muchos a Muchos con Asignatura)
        public List<Asignatura> Asignatura { get; set; }
        public List<ResultadoAprendizaje> ResultadoAprendizaje { get; set; }
        public List<ObjetivoPrograma> ObjetivoPrograma { get; set; }

        // Constructor vacío
        public Carrera()
        {
            Asignatura = new List<Asignatura>();
        }

        // Constructor con parámetros
        public Carrera(int id, string nombre, string contraseña, string presum)
        {
            Id = id;
            Nombre = nombre;
            Contraseña = contraseña;
            Presum = presum;
            Asignatura = new List<Asignatura>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"Carrera: {Nombre} (ID: {Id}, Presum: {Presum})";
        }
    }
}