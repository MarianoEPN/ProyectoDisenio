using CapaEntidades;
using System;
using System.Collections.Generic;

namespace CapaEntidades
{
    public enum TipoNombre
    {
        Conocimiento,
        Destreza,
        Actitud
    }

    public class TipoResultadoAsignatura
    {
        public int Id { get; set; }
        public TipoNombre Nombre { get; set; } // Propiedad para almacenar el valor del enum
        public string Codigo { get; set; }

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public List<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }

        // Constructor vacío
        public TipoResultadoAsignatura()
        {
            ResultadosAprendizaje = new List<ResultadoAprendizajeAsignatura>();
            Nombre = TipoNombre.Conocimiento;
            Codigo = "";
        }

        // Constructor con parámetros
        public TipoResultadoAsignatura(string codigo, TipoNombre nombre)
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

