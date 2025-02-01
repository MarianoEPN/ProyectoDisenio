using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ResultadoAprendizajeAsignaturaNeg
    {
        private ResultadoAprendizajeAsignaturaDAL raaAsignatura = new ResultadoAprendizajeAsignaturaDAL();
        private TipoResultadoAsignaturaDAL tipoResultadoDAL = new TipoResultadoAsignaturaDAL();

        public void InsertarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, Asignatura asignatura)
        {
            raaAsignatura.InsertarResultadoAprendizajeAsignatura(item, asignatura);
        }
        public List<ResultadoAprendizajeAsignatura> MostrarResultadoAprendizajeAsignatura()
        {
             return raaAsignatura.MostrarResultadoAprendizajeAsignatura();
        }
        public void ActualizarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, Asignatura asignatura)
        {
            raaAsignatura.ActualizarResultadoAprendizajeAsignatura(item, asignatura);
        }
        public void EliminarResultadoAprendizajeAsignatura(int id)
        {
            raaAsignatura.EliminarResultadoAprendizajeAsignatura(id);
        }

        public List<ResultadoAprendizajeAsignatura> ObtenerResultadosAprendizajeAsignatura(int asignaturaId)
        {
            List<ResultadoAprendizajeAsignatura> lista = raaAsignatura.ObtenerResultadosAprendizajeAsignatura(asignaturaId);
            List<TipoResultadoAsignatura> listaTipo = tipoResultadoDAL.MostrarTipoResultadoAsignatura();

            foreach (ResultadoAprendizajeAsignatura result in lista)
            {
                foreach (TipoResultadoAsignatura tipo in listaTipo)
                {
                    if (result.Tipo.Id == tipo.Id)
                    {
                        result.Tipo = tipo;
                    }

                }
            }
            return lista;
        }


    }
}
