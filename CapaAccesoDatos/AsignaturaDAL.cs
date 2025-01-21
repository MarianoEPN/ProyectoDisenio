using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class AsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        // Mostrar todas las asignaturas
        public List<Asignatura> MostrarAsignaturas()
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
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        // Insertar una nueva asignatura
        public void InsertarAsignatura(Asignatura asignatura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", asignatura.Id);
            comando.Parameters.AddWithValue("@codigo", asignatura.Codigo);
            comando.Parameters.AddWithValue("@nombre", asignatura.Nombre);
            comando.Parameters.AddWithValue("@nivel", asignatura.Nivel);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Actualizar una asignatura existente
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

        // Eliminar una asignatura por ID
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
