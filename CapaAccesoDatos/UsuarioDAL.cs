using System;
using System.Collections.Generic;
using System.Data;
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
                // Usar GetOrdinal para obtener el índice correcto de cada columna
                usuario.id = leer.GetInt32(leer.GetOrdinal("id"));
                usuario.Username = leer.GetString(leer.GetOrdinal("Username"));
                usuario.Correo = leer.GetString(leer.GetOrdinal("Correo"));
                usuario.Clave = leer.GetString(leer.GetOrdinal("Clave"));
                usuario.nombre = leer.GetString(leer.GetOrdinal("nombre"));

               
                lista.Add(usuario);
            }

            return lista;
        }

    
        

        public void InsertarUsuario(Usuario usuario, Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@username", usuario.Username);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@clave", usuario.Clave);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.Parameters.AddWithValue("@carrera_id", carrera.Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarUsuario(Usuario usuario, Carrera carrera)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarUsuario";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", usuario.id);
            comando.Parameters.AddWithValue("@username", usuario.Username);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@clave", usuario.Clave);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.Parameters.AddWithValue("@carrera_id", carrera.Id);
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


        
        public void RegistrarUsuario(Usuario usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "RegistrarUsuario"; // Nombre del procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            // Mapear los parámetros con los datos del objeto Usuario
            // Aquí puedes decidir si asignar usuario.nombre o dejarlo vacío para evitar el texto "Usuario Computación"
            comando.Parameters.AddWithValue("@Username", usuario.Username);
            comando.Parameters.AddWithValue("@Nombre", usuario.nombre);  // Si no deseas que se muestre "Usuario Computación", asegúrate de que 'usuario.nombre' contenga el valor deseado (por ejemplo, cadena vacía "")
            comando.Parameters.AddWithValue("@Correo", usuario.Correo);
            comando.Parameters.AddWithValue("@Clave", usuario.Clave);
            comando.Parameters.AddWithValue("@Carrera", usuario.carrera);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para insertar usuario cuando se requiere enviar además la entidad Carrera (por ejemplo, en otra funcionalidad)
      

        // Método para actualizar usuario (cuando se envía también la entidad Carrera)
       

        // Método para eliminar usuario
       
        
    }
}

    



