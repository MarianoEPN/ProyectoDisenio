using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaNegocio
{
    public class ResultadoAprendizajeNeg
    {
        private ResultadoAprendizajeDAL RADAL = new ResultadoAprendizajeDAL();

        public void InsertarResultadoAprendizaje(ResultadoAprendizaje resultado, Carrera carrera)
        {
             RADAL.InsertarResultadoAprendizaje(resultado, carrera);
         }
        public List<ResultadoAprendizaje> MostrarResultadosAprendizaje()
        {
              return RADAL.MostrarResultadosAprendizaje();
         }
        public void ActualizarResultadoAprendizaje(ResultadoAprendizaje resultado)
        {
              RADAL.ActualizarResultadoAprendizaje(resultado);
         }
        public void EliminarResultadoAprendizaje(int id)
        {
              RADAL.EliminarResultadoAprendizaje(id);
        }
        public List<ResultadoAprendizaje> ObtenerResultadosAprendizaje(int carreraId)
        {
            return RADAL.ObtenerResultadosAprendizaje(carreraId);
        }


    }
}
