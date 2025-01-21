using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class CarreraDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        // Mostrar todas las carreras
        public List<Carrera> MostrarCarrera()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<Carrera> lista = new List<Carrera>();

            while (leer.Read())
            {
                Carrera carrera = new Carrera();
                carrera.Id = leer.GetInt32(0);
                carrera.Correo = leer.GetString(1);
                carrera.Nombre = leer.GetString(2);
                carrera.Contraseña = leer.GetString(3);
                carrera.Presum = leer.GetString(4);
                lista.Add(carrera);
            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        // Insertar una nueva carrera
        public void InsertarCarrera(Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", carrera.Id);
            comando.Parameters.AddWithValue("@correo", carrera.Correo);
            comando.Parameters.AddWithValue("@nombre", carrera.Nombre);
            comando.Parameters.AddWithValue("@contrasenia", carrera.Contraseña);
            comando.Parameters.AddWithValue("@pensum", carrera.Presum);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Actualizar una carrera existente
        public void ActualizarCarrera(Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarCarrera";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", carrera.Id);
            comando.Parameters.AddWithValue("@correo", carrera.Correo);
            comando.Parameters.AddWithValue("@nombre", carrera.Nombre);
            comando.Parameters.AddWithValue("@contrasenia", carrera.Contraseña);
            comando.Parameters.AddWithValue("@pensum", carrera.Presum);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Eliminar una carrera por ID
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
