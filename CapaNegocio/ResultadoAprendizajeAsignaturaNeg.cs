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

        public void InsertarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura RAAsig)
        {
            RAAsignatura.InsertarResultadoAprendizajeAsignatura(RAAsig);
        }
        public List<ResultadoAprendizajeAsignatura> MostrarResultadoAprendizajeAsignatura()
        {
             return RAAsignatura.MostrarResultadoAprendizajeAsignatura();
        }
        public void ActualizarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura RAAsig)
        {
             RAAsignatura.ActualizarResultadoAprendizajeAsignatura(RAAsig);
        }
        public void EliminarResultadoAprendizajeAsignatura(int id)
        {
             RAAsignatura.EliminarResultadoAprendizajeAsignatura(id);
        }
       
    }
}
