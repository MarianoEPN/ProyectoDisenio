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

        public void InsertarObjetivoPrograma(ObjetivoPrograma objetivo, Carrera carrera)
        {
            objetivoProgramaDAL.InsertarObjetivoPrograma(objetivo, carrera);
        }

        public void ActualizarObjetivoPrograma(ObjetivoPrograma objetivo, Carrera carrera)
        {
            objetivoProgramaDAL.ActualizarObjetivoPrograma(objetivo, carrera);
        }

        public void EliminarObjetivoPrograma(int idObjetivoPrograma)
        {
            objetivoProgramaDAL.EliminarObjetivoPrograma(idObjetivoPrograma);
        }

        public List<ObjetivoPrograma> ObtenerObjetivosProgramaPorCarrera(int carreraId)
        {
            return objetivoProgramaDAL.ObtenerObjetivosProgramaPorCarrera(carreraId);
        }
    }
}
