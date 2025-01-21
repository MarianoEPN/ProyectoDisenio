using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class ProgramaResultadoAprendizajeDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ProgramaResultadoAprend> MostrarProgramaResultadoAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            List<ProgramaResultadoAprend> lista = new List<ProgramaResultadoAprend>();

            while (leer.Read())
            {
                ProgramaResultadoAprend programaResultadoAprendizaje = new ProgramaResultadoAprend();
                programaResultadoAprendizaje.Id = leer.GetInt32(0);
                programaResultadoAprendizaje.Comentario = leer.GetString(1);
                programaResultadoAprendizaje.ObjProgramaId = leer.GetInt32(2);
                programaResultadoAprendizaje.ResultadoAprendizajeId = leer.GetInt32(3);

                lista.Add(programaResultadoAprendizaje);

            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarProgramaResultadoAprendizaje(ProgramaResultadoAprend result)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@comentario", result.Comentario);
            comando.Parameters.AddWithValue("@obj_programa_id", result.ObjProgramaId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", result.ResultadoAprendizajeId);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }

        public void ActualizarProgramaResultadoAprendizaje(ProgramaResultadoAprend result)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", result.Id);
            comando.Parameters.AddWithValue("@comentario", result.Comentario);
            comando.Parameters.AddWithValue("@obj_programa_id", result.ObjProgramaId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", result.ResultadoAprendizajeId);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarProgramaResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
