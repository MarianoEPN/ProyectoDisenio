using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaAccesoDatos
{
    public class ResultadoAprendizajeDAL
    {

        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        // Mostrar todos los resultados de aprendizaje
        public List<ResultadoAprendizaje> MostrarResultadosAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarResultadosAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ResultadoAprendizaje> lista = new List<ResultadoAprendizaje>();

            while (leer.Read())
            {
                ResultadoAprendizaje resultado = new ResultadoAprendizaje();

                resultado.Id = leer.GetInt32(0);
                resultado.Codigo = leer.GetString(1);
                resultado.Descripcion = leer.GetString(2);



                lista.Add(resultado);
            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        // Insertar un nuevo resultado de aprendizaje
        public void InsertarResultadoAprendizaje(ResultadoAprendizaje resultado, Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", resultado.Codigo);
            comando.Parameters.AddWithValue("@descripcion", resultado.Descripcion);
            comando.Parameters.AddWithValue("@carrera_id", carrera.Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Actualizar un resultado de aprendizaje existente
        public void ActualizarResultadoAprendizaje(ResultadoAprendizaje resultado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", resultado.Id);
            comando.Parameters.AddWithValue("@codigo", resultado.Codigo);
            comando.Parameters.AddWithValue("@descripcion", resultado.Descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        // Eliminar un resultado de aprendizaje por ID
        public void EliminarResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public List<ResultadoAprendizaje> ObtenerResultadosAprendizaje(int carreraId)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ObtenerResultadosAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@CarreraID", carreraId);

            leer = comando.ExecuteReader();

            List<ResultadoAprendizaje> lista = new List<ResultadoAprendizaje>();

            while (leer.Read())
            {
                ResultadoAprendizaje resultado = new ResultadoAprendizaje();
                resultado.Id = leer.GetInt32(0);
                resultado.Codigo = leer.GetString(1);
                resultado.Descripcion = leer.GetString(2);
                lista.Add(resultado);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

    }
}