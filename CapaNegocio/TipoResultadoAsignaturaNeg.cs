using CapaAccesoDatos;
using CapaEntidadea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TipoResultadoAsignaturaNeg
    {
        TipoResultadoAsignaturaDAL TRAsignatura = new TipoResultadoAsignaturaDAL();
        public void InsertarMatchResultadoAprendizaje(TipoResultadoAsignatura TRAsig)
        {
            TRAsignatura.InsertarTipoResultadoAsignatura(TRAsig);
        }
        public List<TipoResultadoAsignatura> MostrarMatchResultadoAprendizaje()
        {
            return TRAsignatura.MostrarTipoResultadoAsignatura();
        }
        public void ActualizarMatchResultadoAprendizaje(TipoResultadoAsignatura TRAsig)
        {
            TRAsignatura.ActualizarTipoResultadoAsignatura(TRAsig);
        }
        public void EliminarMatchResultadoAprendizaje(int id)
        {
            TRAsignatura.EliminarTipoResultadoAsignatura(id);
        }
    }
}
