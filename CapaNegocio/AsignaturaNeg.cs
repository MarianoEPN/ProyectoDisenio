using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidadea;

namespace CapaNegocio
{
    public class AsignaturaNeg
    {
        private AsignaturaDAL asignaturaDAL = AsignaturaDAL();

        public List<Asignatura> MostrarAsignatura()
        {
            return asignaturaDAL.MostrarAsignaturas();
        }

        public void InsertarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.InsertarAsignatura(asignatura);
        }

        public void ActualizarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.ActualizarAsignatura(asignatura);
        }

        public void EliminarAsignatura(Asignatura id)
        {
            asignaturaDAL.EliminarAsignatura(id);
        }
    }
}
