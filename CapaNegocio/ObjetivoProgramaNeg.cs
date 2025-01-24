using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ObjetivoProgramaNeg
    {
        public ObjetivoProgramaDAL objetivoProgramaDAL = new ObjetivoProgramaDAL();

        public List<ObjetivoPrograma> MostrarObjetivoPrograma()
        {
            return objetivoProgramaDAL.MostrarObjetivosPrograma();
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
