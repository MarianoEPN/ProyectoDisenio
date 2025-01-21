using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CarreraNeg
    {
        private CarreraDAL carreraDAL = CarreraDAL();

        public List<Carrera> MostrarAsignatura()
        {
            return carreraDAL.MostrarAsignaturas();
        }

        public void InsertarAsignatura(Carrera carrera)
        {
            carreraDAL.InsertarAsignatura(carrera);
        }

        public void ActualizarAsignatura(Carrera carrera)
        {
            carreraDAL.ActualizarAsignatura(carrera);
        }

        public void EliminarAsignatura(Carrera id)
        {
            carreraDAL.EliminarAsignatura(id);
        }
    }
}
