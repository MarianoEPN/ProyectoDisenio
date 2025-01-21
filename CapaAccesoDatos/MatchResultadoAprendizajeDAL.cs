using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidadea;

namespace CapaAccesoDatos
{
    public class MatchResultadoAprendizajeDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<MatchResultadoAprendizaje> MostrarMatchResultadoAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            List<MatchResultadoAprendizaje> lista = new List<MatchResultadoAprendizaje>();

            while (leer.Read())
            {
                MatchResultadoAprendizaje matchResultadoAprendizaje = new MatchResultadoAprendizaje();
                matchResultadoAprendizaje.Id = leer.GetInt32(0);
                matchResultadoAprendizaje.PerfilEgresoId = leer.GetInt32(1);
                matchResultadoAprendizaje.SubResultadoAprendizajeId = leer.GetInt32(2);
                matchResultadoAprendizaje.NivelAporte = leer.GetString(3);
                matchResultadoAprendizaje.ResultadoAprendizajeAsignaturaId = leer.GetInt32(4);
                lista.Add(matchResultadoAprendizaje);                               
                
            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarMatchResultadoAprendizaje(MatchResultadoAprendizaje match)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", match.Id);
            comando.Parameters.AddWithValue("@perfil_egreso_id", match.PerfilEgresoId);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_i", match.SubResultadoAprendizajeId);
            comando.Parameters.AddWithValue("@nivelaporte", match.NivelAporte);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
        }

        public void ActualizarMatchResultadoAprendizaje(MatchResultadoAprendizaje match)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", match.Id);
            comando.Parameters.AddWithValue("@perfil_egreso_id", match.PerfilEgresoId);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_i", match.SubResultadoAprendizajeId);
            comando.Parameters.AddWithValue("@nivelaporte", match.NivelAporte);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarMatchResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        

        
    }
}
