using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class EuraceResultadoAsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<EuraceResultadoAsignatura> MostrarEuraceResultadoAsignatura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEuraceResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<EuraceResultadoAsignatura> lista = new List<EuraceResultadoAsignatura>();

            while (leer.Read())
            {
                EuraceResultadoAsignatura item = new EuraceResultadoAsignatura();
                item.Id = leer.GetInt32(0);
                item.Comentario = leer.GetString(1);
                item.ObjEuraceId = leer.GetInt32(2);
                item.ResultadoAsignaturaId = leer.GetInt32(3);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarEuraceResultadoAsignatura(EuraceResultadoAsignatura item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEuraceResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.Parameters.AddWithValue("@obj_eurace_id", item.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_asignatura_id", item.ResultadoAsignaturaId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarEuraceResultadoAsignatura(EuraceResultadoAsignatura item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarEuraceResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.Parameters.AddWithValue("@obj_eurace_id", item.ObjEuraceId);
            comando.Parameters.AddWithValue("@resultado_asignatura_id", item.ResultadoAsignaturaId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarEuraceResultadoAsignatura(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEuraceResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
