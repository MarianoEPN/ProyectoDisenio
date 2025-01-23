using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
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
            List<EuraceResultadoAprendizaje> lista = new List<EuraceResultadoAprendizaje>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                EuraceResultadoAprendizaje euraceResultadoAprendizaje = new EuraceResultadoAprendizaje();
                euraceResultadoAprendizaje.Id = leer.GetInt32(0);
                euraceResultadoAprendizaje.ObjEuraceId = leer.GetInt32(1);
                euraceResultadoAprendizaje.ResultadoAprendizajeId = leer.GetInt32(2);
                euraceResultadoAprendizaje.Comentario = leer.GetString(3);

                lista.Add(euraceResultadoAprendizaje);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;

        }

        public void InsertarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@obj_eurace_id", euraceResultadoAprendizaje.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", euraceResultadoAprendizaje.ResultadoAprendizajeId);
            comando.Parameters.AddWithValue("@comentario", euraceResultadoAprendizaje.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@id", euraceResultadoAprendizaje.Id);
            comando.Parameters.AddWithValue("@obj_eurace_id", euraceResultadoAprendizaje.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", euraceResultadoAprendizaje.ResultadoAprendizajeId);
            comando.Parameters.AddWithValue("@comentario", euraceResultadoAprendizaje.Comentario);
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
