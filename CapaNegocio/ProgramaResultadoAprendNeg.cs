﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProgramaResultadoAprendNeg
    {
        public ProgramaResultadoAprendizajeDAL programaResultadoAprendizajeDAL = new ProgramaResultadoAprendizajeDAL();

        public List<ProgramaResultadoAprendizaje> MostrarProgramaResultadoAprendizaje()
        {
            return programaResultadoAprendizajeDAL.MostrarProgramaResultadoAprendizaje();
        }

        public void InsertarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje programaResultadoAprendizaje)
        {
            programaResultadoAprendizajeDAL.InsertarProgramaResultadoAprendizaje(programaResultadoAprendizaje);
        }

        public void ActualizarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje programaResultadoAprendizaje)
        {
            programaResultadoAprendizajeDAL.ActualizarProgramaResultadoAprendizaje(programaResultadoAprendizaje);
        }

        public void EliminarProgramaResultadoAprendizaje(int idProgramaResultadoAprendizaje)
        {
            programaResultadoAprendizajeDAL.EliminarProgramaResultadoAprendizaje(idProgramaResultadoAprendizaje);
        }
    }
}
