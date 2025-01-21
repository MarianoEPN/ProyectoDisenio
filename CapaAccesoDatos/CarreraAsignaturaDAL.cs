using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class CarreraAsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        /*
        public List<CarreraAsignatura> MostrarCarreraAsignatura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCarreraAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<CarreraAsignatura> lista = new List<CarreraAsignatura>();

            while (leer.Read())
            {
                CarreraAsignatura item = new CarreraAsignatura();
                item.Id = leer.GetInt32(0);
                item.CarreraId = leer.GetInt32(1);
                item.AsignaturaId = leer.GetInt32(2);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }
        

        public void InsertarCarreraAsignatura(CarreraAsignatura item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCarreraAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@carrera_id", item.CarreraId);
            comando.Parameters.AddWithValue("@asignatura_id", item.AsignaturaId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarCarreraAsignatura(CarreraAsignatura item)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarCarreraAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@carrera_id", item.CarreraId);
            comando.Parameters.AddWithValue("@asignatura_id", item.AsignaturaId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarCarreraAsignatura(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCarreraAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        */
    }
}
