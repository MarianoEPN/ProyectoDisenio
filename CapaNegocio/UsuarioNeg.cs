using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;
namespace CapaNegocio
{
    public class UsuarioNeg
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public List<Usuario> MostrarUsuario()
        {
            return usuarioDAL.MostrarUsuario();
        }

        public void InsertarUsuario(Usuario usuario, Carrera carrera)
        {
            usuarioDAL.InsertarUsuario(usuario, carrera);
        }

        public void ActualizarUsuario(Usuario usuario, Carrera carrera)
        {
            usuarioDAL.ActualizarUsuario(usuario, carrera);
        }

        public void EliminarUsuario(int usuario)
        {
            usuarioDAL.EliminarUsuario(usuario);
        }
        public bool RegistrarUsuario(Usuario usuario)
        {
            // Validación de formato de correo electrónico
            if (!Regex.IsMatch(usuario.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false; // Correo no válido
            }

            try
            {
                // Se llama al método del DAL que usa el procedimiento almacenado "RegistrarUsuario"
                usuarioDAL.RegistrarUsuario(usuario);
                return true;
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error (ex.Message) para depuración
                return false;
            }
        }
    }
}


