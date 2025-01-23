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

        public List<ProgramaResultadoAprendizaje> MostrarProgramaResultadoAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ProgramaResultadoAprendizaje> lista = new List<ProgramaResultadoAprendizaje>();

            while (leer.Read())
            {
                ProgramaResultadoAprendizaje item = new ProgramaResultadoAprendizaje();
                item.Id = leer.GetInt32(0);                
                item.Comentario = leer.GetString(3);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;    
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);            
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
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
