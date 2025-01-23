using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    internal class AsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<Asignatura> MostrarAsignatura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<Asignatura> lista = new List<Asignatura>();

            while (leer.Read())
            {
                Asignatura asignatura = new Asignatura();
                asignatura.Id = leer.GetInt32(0);
                asignatura.Codigo = leer.GetString(1);
                asignatura.Nombre = leer.GetString(2);
                asignatura.Nivel = leer.GetInt32(3);
                lista.Add(asignatura);
            }


            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public void IsertarAsignatura(Asignatura asignatura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAsignaturas";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", asignatura.Codigo);
            comando.Parameters.AddWithValue("@nombre", asignatura.Nombre);
            comando.Parameters.AddWithValue("@nivel", asignatura.Nivel);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarAsignatura(Asignatura asignatura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", asignatura.Id);
            comando.Parameters.AddWithValue("@codigo", asignatura.Codigo);
            comando.Parameters.AddWithValue("@nombre", asignatura.Nombre);
            comando.Parameters.AddWithValue("@nivel", asignatura.Nivel);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarAsignatura(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
