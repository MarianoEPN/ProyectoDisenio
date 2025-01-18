using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
{
    public class TipoResultadoAsignatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        // Relación inversa hacia ResultadoAprendizajeAsignatura
        public ICollection<ResultadoAprendizajeAsignatura> ResultadosAprendizaje { get; set; }
    }

}
