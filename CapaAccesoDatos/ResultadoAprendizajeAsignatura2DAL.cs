using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class ResultadoAprendizajeAsignatura2DAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ResultadoAprendizajeAsignatura> ObtenerResultadosAprendizajeAsignatura(int asignaturaId)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ObtenerResultadosAprendizajeAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@AsignaturaID", asignaturaId);

            leer = comando.ExecuteReader();

            List<ResultadoAprendizajeAsignatura> lista = new List<ResultadoAprendizajeAsignatura>();

            while (leer.Read())
            {
                ResultadoAprendizajeAsignatura resultadoAsignatura = new ResultadoAprendizajeAsignatura();
                resultadoAsignatura.Id = leer.GetInt32(0);
   
          
                resultadoAsignatura.Codigo = leer.GetString(3);
                resultadoAsignatura.Descripcion = leer.GetString(4);
                lista.Add(resultadoAsignatura);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }
    }
}
