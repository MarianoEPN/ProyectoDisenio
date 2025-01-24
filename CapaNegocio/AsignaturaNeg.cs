using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class AsignaturaNeg
    {
        
        private AsignaturaDAL asignaturaDAL = new AsignaturaDAL();

        public List<Asignatura> MostrarAsignatura()
        {
            return asignaturaDAL.MostrarAsignatura();
        }

        public void InsertarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.InsertarAsignatura(asignatura);
        }

        public void ActualizarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.ActualizarAsignatura(asignatura);
        }

        public void EliminarAsignatura(int id)
        {
            asignaturaDAL.EliminarAsignatura(id);
        }
        
    }
}
