using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ProgramaResultadoAprend
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        // Clave foránea hacia ResultadoAprendizaje
        public int ResultadoAprendizajeId { get; set; }
        public ResultadoAprendizaje ResultadoAprendizaje { get; set; }

        // Clave foránea hacia ObjetivoPrograma
        public int ObjProgramaId { get; set; }
        public ObjetivoPrograma ObjetivoPrograma { get; set; }
    }

}
