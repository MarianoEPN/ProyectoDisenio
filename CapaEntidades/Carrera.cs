using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Pensum { get; set; }

        // Relación con CarreraAsignatura (Muchos a Muchos con Asignatura)
        public ICollection<CarreraAsignatura> CarrerasAsignatura { get; set; }
    }

}
