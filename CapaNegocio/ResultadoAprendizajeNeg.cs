using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ResultadoAprendizajeNeg
    {
        private ResultadoAprendizajeNeg RANeg = new ResultadoAprendizajeNeg();

         public void InsertarResultadoAprendizajeNeg(ResultadoAprendizajeNeg MRApr)
         {
             RANeg.InsertarResultadoAprendizajeNeg(MRApr);
         }
         public List<MatchResultadoAprendizaje> MostrarResultadoAprendizajeNeg()
         {
              return RANeg.MostrarResultadoAprendizajeNeg();
         }
         public void ActualizarResultadoAprendizajeNeg(ResultadoAprendizajeNeg MRApr)
         {
              RANeg.ActualizarResultadoAprendizajeNeg(MRApr);
         }
         public void EliminarResultadoAprendizajeNeg(int id)
         {
              RANeg.EliminarResultadoAprendizajeNeg(id);
         }
        public List<ResultadoAprendizaje> ObtenerResultadosAprendizaje(int carreraId)
        {
            return RANeg.ObtenerResultadosAprendizaje(carreraId);
        }


    }
}
