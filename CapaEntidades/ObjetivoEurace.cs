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
        public ICollection<EuraceResultadoAsignatura> EuraceResultadosAsignatura { get; set; }
        public ICollection<EuraceResultadoAprendizaje> EuraceResultadosAprendizaje { get; set; }
    }

}
