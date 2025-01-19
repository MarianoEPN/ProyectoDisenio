using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public ICollection<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }

        // Relación con CarreraAsignatura (Muchos a Muchos con Carrera)
        public ICollection<CarreraAsignatura> CarrerasAsignatura { get; set; }
    }

}
