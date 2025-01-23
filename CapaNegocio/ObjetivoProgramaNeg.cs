using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ObjetivoProgramaNeg
    {
        public ObjetivoProgramaDAL objetivoProgramaDAL = new ObjetivoProgramaDAL();

        public List<ObjetivoPrograma> MostrarObjetivoPrograma()
        {
            return objetivoProgramaDAL.MostrarObjetivoPrograma();
        }

        public void InsertarObjetivoPrograma(ObjetivoPrograma objetivoPrograma)
        {
            objetivoProgramaDAL.InsertarObjetivoPrograma(objetivoPrograma);
        }

        public void ActualizarObjetivoPrograma(ObjetivoPrograma objetivoPrograma)
        {
            objetivoProgramaDAL.ActualizarObjetivoPrograma(objetivoPrograma);
        }

        public void EliminarObjetivoPrograma(int idObjetivoPrograma)
        {
            objetivoProgramaDAL.EliminarObjetivoPrograma(idObjetivoPrograma);
        }
    }
}
