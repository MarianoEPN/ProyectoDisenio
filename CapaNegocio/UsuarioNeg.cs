using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


    }
}
