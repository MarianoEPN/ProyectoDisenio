using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidadea
{
    public class ResultadoAprendizaje
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        // Relación inversa con ProgramaResultadoAprend y EuraceResultadoAprendizaje
        public ICollection<ProgramaResultadoAprend> ProgramasResultadoAprend { get; set; }
        public ICollection<EuraceResultadoAprendizaje> EuraceResultadosAprendizaje { get; set; }
    }

}
