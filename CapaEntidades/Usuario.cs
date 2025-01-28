using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
       
        public Usuario()
        {
            nombre = "";
            Username = "";
            Clave = "";
            Correo = "";
        }
        public Usuario(string nombre, string username, string clave, string correo)
        {
         
            this.nombre = nombre;
            Username = username;
            Clave = clave;
            Correo = correo;
        }

        public override string ToString()
        {
            return $"Usuario: {nombre} (ID: {id}, Username: {Username})";
        }
    }
}
