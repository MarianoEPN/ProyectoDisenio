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

        public void InsertarAsignatura(Asignatura asignatura, Carrera carrera)
        {
            asignaturaDAL.InsertarAsignatura(asignatura, carrera);
        }

        public void ActualizarAsignatura(Asignatura asignatura, Carrera carrera)
        {
            asignaturaDAL.ActualizarAsignatura(asignatura, carrera);
        }

        public void EliminarAsignatura(int id)
        {
            asignaturaDAL.EliminarAsignatura(id);
        }

        public List<Asignatura> ObtenerAsignaturasPorCarrera(int carreraId)
        {
            return asignaturaDAL.ObtenerAsignaturasPorCarrera(carreraId);
        }


    }
}
