using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

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
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<MatchResultadoAprendizaje> lista = new List<MatchResultadoAprendizaje>();

            while (leer.Read())
            {
                MatchResultadoAprendizaje match = new MatchResultadoAprendizaje();
                match.Id = leer.GetInt32(0);
                match.PerfilEgresoId = leer.GetInt32(1);
                match.SubResultadoAprendizajeId = leer.GetInt32(2);
                match.NivelAporte = leer.GetString(3);
                lista.Add(match);
            }


            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public void IsertarMatchResultadoAprendizaje(MatchResultadoAprendizaje match)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@perfil_egreso_id", match.PerfilEgresoId);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", match.SubResultadoAprendizajeId);
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
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", match.SubResultadoAprendizajeId);
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
