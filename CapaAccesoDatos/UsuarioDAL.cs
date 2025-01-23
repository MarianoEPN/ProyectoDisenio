using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class UsuarioDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<Usuario> MostrarUsuario()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<Usuario> lista = new List<Usuario>();

            while (leer.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = leer.GetInt32(0);                
                usuario.Username = leer.GetString(2);
                usuario.Correo = leer.GetString(3);
                usuario.Clave = leer.GetString(4);
                usuario.nombre = leer.GetString(5);
                lista.Add(usuario);
            }


            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;            
            comando.Parameters.AddWithValue("@username", usuario.Username);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@clave", usuario.Clave);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", usuario.id);            
            comando.Parameters.AddWithValue("@username", usuario.Username);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@clave", usuario.Clave);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarUsuario(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
