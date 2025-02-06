using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            comando.Parameters.Clear();
            comando.CommandText = "InsertarMatchResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure; 
            comando.Parameters.AddWithValue("@perfil_egreso_id", resultadoAprendizaje.Id);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", resultado.Id);
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
            comando.Parameters.AddWithValue("@perfil_egreso_id", resultadoAprendizaje.Id);
            comando.Parameters.AddWithValue("@sub_resultado_aprendizage_asignatura_id", resultado.Id);
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
                MatchResultadoAprendizaje matchResultado = new MatchResultadoAprendizaje();
                matchResultado.Id = leer.GetInt32(0);
                matchResultado.PerfilEgresoId = leer.GetInt32(1);
                matchResultado.SubResultadoAprendizageAsignaturaId = leer.GetInt32(2);
                matchResultado.NivelAporte = leer.GetString(3);

                lista.Add(matchResultado);
            }

            // Cerrar la conexión y el lector
            leer.Close();
            conexion.CerrarConexion();

            return lista;
        }


        public List<MatchResultadoAprendizaje> BuscarMatchResultadoAprendizaje(ResultadoAprendizajeAsignatura resultadoAprendizajeAsignaturaId, ResultadoAprendizaje resultadoAprendizajeId)
        {
            List<MatchResultadoAprendizaje> lista = new List<MatchResultadoAprendizaje>();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarMatchResultadoAprendizaje";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@ResultadoAprendizajeAsignaturaID", resultadoAprendizajeAsignaturaId.Id);
            comando.Parameters.AddWithValue("@ResultadoAprendizajeID", resultadoAprendizajeId.Id);

            // Ejecutar lector
            leer = comando.ExecuteReader();

            // Leer resultados
            while (leer.Read())
            {
                MatchResultadoAprendizaje match = new MatchResultadoAprendizaje();
                match.Id = leer.GetInt32(0);
                match.PerfilEgresoId = leer.GetInt32(1);
                match.NivelAporte = leer.GetString(3);
                match.SubResultadoAprendizageAsignaturaId = leer.GetInt32(2);

                lista.Add(match);
            }

            // Cerrar conexiones y retornar la lista
            leer.Close();
            conexion.CerrarConexion();

            return lista;
        }



    }



}
