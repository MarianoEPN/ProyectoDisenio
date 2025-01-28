using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ResultadoAprendizajeAsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ResultadoAprendizajeAsignatura> MostrarResultadoAprendizajeAsignatura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarResultadoAprendizajeAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ResultadoAprendizajeAsignatura> lista = new List<ResultadoAprendizajeAsignatura>();

            while (leer.Read())
            {
                ResultadoAprendizajeAsignatura item = new ResultadoAprendizajeAsignatura();
                item.Id = leer.GetInt32(0);                
                item.Codigo = leer.GetString(3);
                item.Descripcion = leer.GetString(4);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, Asignatura asignatura, TipoResultadoAsignatura tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarResultadoAprendizajeAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;   
            comando.Parameters.AddWithValue("@asignatura_id", asignatura.Id);
            comando.Parameters.AddWithValue("@tipo_id", tipo.Id);
            comando.Parameters.AddWithValue("@codigo", item.Codigo);
            comando.Parameters.AddWithValue("@descripcion", item.Descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarResultadoAprendizajeAsignatura(ResultadoAprendizajeAsignatura item, Asignatura asignatura, TipoResultadoAsignatura tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarResultadoAprendizajeAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);    
            comando.Parameters.AddWithValue("@asignatura_id", asignatura.Id);
            comando.Parameters.AddWithValue("@tipo_id", tipo.Id);
            comando.Parameters.AddWithValue("@codigo", item.Codigo);
            comando.Parameters.AddWithValue("@descripcion", item.Descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarResultadoAprendizajeAsignatura(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarResultadoAprendizajeAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

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
