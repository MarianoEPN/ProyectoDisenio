using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EuraceResultadoAsignaturaNeg
    {
        private EuraceResultadoAsignaturaDAL ERAsignatura = new EuraceResultadoAsignaturaDAL();

        public void InsertarEuraceResultadoAsignatura(EuraceResultadoAsignatura ERApr)
        {
            ERAsignatura.InsertarEuraceResultadoAsignatura(ERApr);
        }
        public List<EuraceResultadoAsignatura> MostrarEuraceResultadoAsignatura()
        {
            return ERAsignatura.MostrarEuraceResultadoAsignatura();
        }
        public void ActualizarEuraceResultadoAsignatura(EuraceResultadoAsignatura ERApr)
        {
            ERAsignatura.ActualizarEuraceResultadoAsignatura(ERApr);
        }
        public void EliminarEuraceResultadoAsignatura(int id)
        {
            ERAsignatura.EliminarEuraceResultadoAsignatura(id);
        }
    }
}
