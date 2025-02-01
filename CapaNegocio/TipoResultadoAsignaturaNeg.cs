using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TipoResultadoAsignaturaNeg
    {
        private TipoResultadoAsignaturaDAL TRAsignatura = new TipoResultadoAsignaturaDAL();
        public void InsertarTipoResultadoAprendizaje(TipoResultadoAsignatura TRAsig)
        {
            TRAsignatura.InsertarTipoResultadoAsignatura(TRAsig);
        }
        public List<TipoResultadoAsignatura> MostrarTipoResultadoAprendizaje()
        {
            return TRAsignatura.MostrarTipoResultadoAsignatura();
        }
        public void ActualizarTipoResultadoAprendizaje(TipoResultadoAsignatura TRAsig)
        {
            TRAsignatura.ActualizarTipoResultadoAsignatura(TRAsig);
        }
        public void EliminarTipoResultadoAprendizaje(int id)
        {
            TRAsignatura.EliminarTipoResultadoAsignatura(id);
        }
    }
}
