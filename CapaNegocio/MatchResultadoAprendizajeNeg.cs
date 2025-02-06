using CapaAccesoDatos;
using CapaEntidades;
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

        public void InsertarMatchResultadoAprendizaje(MatchResultadoAprendizaje match, ResultadoAprendizajeAsignatura resultado, ResultadoAprendizaje resultadoAprendizaje)
        {
            MRAprendizaje.InsertarMatchResultadoAprendizaje(match, resultado, resultadoAprendizaje);
        }
        public List<MatchResultadoAprendizaje> MostrarMatchResultadoAprendizaje()
        {
            return MRAprendizaje.MostrarMatchResultadoAprendizaje();
        }
        public void ActualizarMatchResultadoAprendizaje(MatchResultadoAprendizaje match, ResultadoAprendizajeAsignatura resultado, ResultadoAprendizaje resultadoAprendizaje)
        {
            MRAprendizaje.ActualizarMatchResultadoAprendizaje(match, resultado, resultadoAprendizaje);
        }
        public void EliminarMatchResultadoAprendizaje(int id)
        {
            MRAprendizaje.EliminarMatchResultadoAprendizaje(id);
        }

        public List<MatchResultadoAprendizaje> MostrarMatchResultadoAprendizajePorCarrera(int carreraId)
        {
            return MRAprendizaje.MostrarMatchResultadoAprendizajePorCarrera(carreraId);
        }

        public List<MatchResultadoAprendizaje> BuscarMatchResultadoAprendizaje(ResultadoAprendizajeAsignatura resultadoAprendizajeAsignaturaId, ResultadoAprendizaje resultadoAprendizajeId) 
        {
            return MRAprendizaje.BuscarMatchResultadoAprendizaje(resultadoAprendizajeAsignaturaId, resultadoAprendizajeId);
        }


    }
}
