using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ObjetivoEurace
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relación inversa con EuraceResultadoAsignatura y EuraceResultadoAprendizaje
        public List<EuraceResultadoAsignatura> EuraceResultadosAsignatura { get; set; }
        public List<EuraceResultadoAprendizaje> EuraceResultadosAprendizaje { get; set; }

        // Constructor vacío
        public ObjetivoEurace()
        {
            EuraceResultadosAsignatura = new List<EuraceResultadoAsignatura>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
        }

        // Constructor con parámetros
        public ObjetivoEurace( string codigo, string nombre, string descripcion)
        {
           
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            EuraceResultadosAsignatura = new List<EuraceResultadoAsignatura>();
            EuraceResultadosAprendizaje = new List<EuraceResultadoAprendizaje>();
        }

        // Método ToString
        public override string ToString()
        {
            return $"ObjetivoEurace: [ID: {Id}, Código: {Codigo}, Nombre: {Nombre}, Descripción: {Descripcion}]";
        }
    }

}
