using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ObjetivoPrograma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Fortalezas { get; set; }
        public string Debilidades { get; set; }

        // Relación inversa con ProgramaResultadoAprend
        public ICollection<ProgramaResultadoAprend> ProgramasResultadoAprend { get; set; }
    }

}
