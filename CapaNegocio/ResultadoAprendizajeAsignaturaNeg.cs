using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ResultadoAprendizajeAsignaturaNeg
    {
        private ResultadoAprendizajeAsignaturaDAL RAAsignatura = new ResultadoAprendizajeAsignaturaDAL();

        public void InsertarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, Asignatura asignatura, TipoResultadoAsignatura tipo)
        {
            RAAsignatura.InsertarResultadoAprendizajeAsignatura(item, asignatura, tipo);
        }
        public List<ResultadoAprendizajeAsignatura> MostrarResultadoAprendizajeAsignatura()
        {
             return RAAsignatura.MostrarResultadoAprendizajeAsignatura();
        }
        public void ActualizarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, TipoResultadoAsignatura tipo)
        {
             RAAsignatura.ActualizarResultadoAprendizajeAsignatura(item, tipo);
        }
        public void EliminarResultadoAprendizajeAsignatura(int id)
        {
             RAAsignatura.EliminarResultadoAprendizajeAsignatura(id);
        }

        public List<ResultadoAprendizajeAsignatura> ObtenerResultadosAprendizajeAsignatura(int asignaturaId)
        {
            return RAAsignatura.ObtenerResultadosAprendizajeAsignatura(asignaturaId);
        }


    }
}
