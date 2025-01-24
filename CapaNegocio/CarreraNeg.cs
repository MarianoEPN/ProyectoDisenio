using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaNegocio
{
    public class CarreraNeg
    {
        
        private CarreraDAL carreraDAL = new CarreraDAL();

        public List<Carrera> MostrarCarrera()
        {
            return carreraDAL.MostrarCarrera();
        }

        public void InsertarCarrera(Carrera carrera)
        {
            carreraDAL.InsertarCarrera(carrera);
        }

        public void ActualizarCarrera(Carrera carrera)
        {
            carreraDAL.ActualizarCarrera(carrera);
        }

        public void EliminarCarrera(int id)
        {
            carreraDAL.EliminarCarrera(id);
        }
        
    }
}
