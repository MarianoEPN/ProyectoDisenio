using CapaEntidadea;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class EuraceResultadoAprendizajeDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<EuraceResultadoAprendizaje> MostrarEuraceResultadoAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<EuraceResultadoAprendizaje> lista = new List<EuraceResultadoAprendizaje>();

            while (leer.Read())
            {
                EuraceResultadoAprendizaje item = new EuraceResultadoAprendizaje();
                item.Id = leer.GetInt32(0);
                item.Comentario = leer.GetString(1);
                item.ObjEuraceId = leer.GetInt32(2);
                item.ResultadoAprendizajeId = leer.GetInt32(3);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.Parameters.AddWithValue("@obj_eurace_id", item.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", item.ResultadoAprendizajeId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.Parameters.AddWithValue("@obj_eurace_id", item.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", item.ResultadoAprendizajeId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarEuraceResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
