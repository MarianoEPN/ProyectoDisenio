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
                
                
                match.NivelAporte = leer.GetString(3);
                lista.Add(match);
            }


            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public void InsertarMatchResultadoAprendizaje(MatchResultadoAprendizaje match, ResultadoAprendizajeAsignatura resultado, ResultadoAprendizaje resultadoAprendizaje)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure; 
            comando.Parameters.AddWithValue("@perfil_egreso_id", resultado.Id);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", resultadoAprendizaje.Id);
            comando.Parameters.AddWithValue("@nivelaporte", match.NivelAporte);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarMatchResultadoAprendizaje(MatchResultadoAprendizaje match, ResultadoAprendizajeAsignatura resultado, ResultadoAprendizaje resultadoAprendizaje)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", match.Id);  
            comando.Parameters.AddWithValue("@perfil_egreso_id", resultado.Id);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", resultadoAprendizaje.Id);
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

        public List<MatchResultadoAprendizaje> MostrarMatchResultadoAprendizajePorCarrera(int carreraId)
        {
            List<MatchResultadoAprendizaje> lista = new List<MatchResultadoAprendizaje>();

            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();

            // Configurar el comando para el procedimiento almacenado
            comando.CommandText = "MostrarMatchResultadoAprendizajePorCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@carrera_id", carreraId);

            // Ejecutar el lector
            leer = comando.ExecuteReader();

            while (leer.Read())
            {
                MatchResultadoAprendizaje matchResultado = new MatchResultadoAprendizaje
                    Id = leer.GetInt32(0),
                    PerfilEgresoId = leer.GetInt32(1),
                    SubResultadoAsignaturaId = leer.GetInt32(2),
                    NivelAporte = leer.GetString(3)

                lista.Add(matchResultado);
            }

            // Cerrar la conexión y el lector
            leer.Close();
            conexion.CerrarConexion();

            return lista;
        }



    }







}
