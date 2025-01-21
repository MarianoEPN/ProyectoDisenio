using CapaAccesoDatos;
using CapaEntidadea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MatchResultadoAprendizajeNeg
    {
        private MatchResultadoAprendizajeDAL MRAprendizaje = new MatchResultadoAprendizajeDAL();

        public void InsertarMatchResultadoAprendizaje(MatchResultadoAprendizaje MRApr)
        {
            MRAprendizaje.InsertarMatchResultadoAprendizaje(MRApr);
        }
        public List<MatchResultadoAprendizaje> MostrarMatchResultadoAprendizaje()
        {
            return MRAprendizaje.MostrarMatchResultadoAprendizaje();
        }
        public void ActualizarMatchResultadoAprendizaje(MatchResultadoAprendizaje MRApr)
        {
            MRAprendizaje.ActualizarMatchResultadoAprendizaje(MRApr);
        }
        public void EliminarMatchResultadoAprendizaje(int id)
        {
            MRAprendizaje.EliminarMatchResultadoAprendizaje(id);
        }
    }
}
