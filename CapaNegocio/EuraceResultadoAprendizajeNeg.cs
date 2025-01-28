using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using CapaAccesoDatos;


namespace CapaNegocio
{
    public class EuraceResultadoAprendizajeNeg
    {
        private EuraceResultadoAprendizajeDAL ERAprendizaje = new EuraceResultadoAprendizajeDAL();

        public void InsertarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje, ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            ERAprendizaje.InsertarEuraceResultadoAprendizaje(euraceResultadoAprendizaje, objetivo, resultado);
        }

        public List<EuraceResultadoAprendizaje> MostrarEuraceResultadoAprendizaje()
        {
            return ERAprendizaje.MostrarEuraceResultadoAprendizaje();
        }
        public void ActualizarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje, ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            ERAprendizaje.ActualizarEuraceResultadoAprendizaje(euraceResultadoAprendizaje, objetivo, resultado);
        }
        public void EliminarEuraceResultadoAprendizaje(int id)
        {
            ERAprendizaje.EliminarEuraceResultadoAprendizaje(id);
        }
        public List<EuraceResultadoAprendizaje> BuscarEuraceResultadoAprendizaje(ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            return ERAprendizaje.BuscarEuraceResultadoAprendizaje(objetivo, resultado); 
        }

    }
}
