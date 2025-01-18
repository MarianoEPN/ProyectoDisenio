using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
{
    
    public class CarreraAsignatura
    {
        public int Id { get; set; }

        // Clave foránea hacia Carrera
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        // Clave foránea hacia Asignatura
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
    }

}
