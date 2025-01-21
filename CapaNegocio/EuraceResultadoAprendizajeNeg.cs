﻿using System;
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

        public void InsertarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje ERApr)
        {
            ERAprendizaje.InsertarEuraceResultadoAprendizaje(ERApr);
        }

        public List<EuraceResultadoAprendizaje> MostrarEuraceResultadoAprendizaje()
        {
            return ERAprendizaje.MostrarEuraceResultadoAprendizaje();
        }
        public void ActualizarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje ERApr)
        {
            ERAprendizaje.ActualizarEuraceResultadoAprendizaje(ERApr);
        }
        public void EliminarEuraceResultadoAprendizaje(int id)
        {
            ERAprendizaje.EliminarEuraceResultadoAprendizaje(id);
        }


    }
}
