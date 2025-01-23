using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class CarreraDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<Carrera> MostrarCarrera()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            List<Carrera> lista = new List<Carrera>();

            while (leer.Read())
            {
                Carrera carrera = new Carrera();
                carrera.Id = leer.GetInt32(0);
                carrera.Nombre = leer.GetString(1);
                carrera.Correo = leer.GetString(2);
                carrera.Pensum = leer.GetString(3);
                lista.Add(carrera);

            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarCarrera(Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", carrera.Id);
            comando.Parameters.AddWithValue("@nombre", carrera.Nombre);
            comando.Parameters.AddWithValue("@correo", carrera.Correo);
            comando.Parameters.AddWithValue("@pensum", carrera.Pensum);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void ActualizarCarrera(Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", carrera.Id);
            comando.Parameters.AddWithValue("@nombre", carrera.Nombre);
            comando.Parameters.AddWithValue("@correo", carrera.Correo);
            comando.Parameters.AddWithValue("@pensum", carrera.Pensum);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void EliminarCarrera(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
    }
}
