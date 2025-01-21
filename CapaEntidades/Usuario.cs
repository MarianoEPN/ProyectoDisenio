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
        public List<Carrera> carreras { get; set; }

        public Usuario()
        {
            carreras = new List<Carrera>();
        }

        public Usuario(int id, string nombre, string username, string clave, List<Carrera> carreras)
        {
            this.id = id;
            this.nombre = nombre;
            Username = username;
            Clave = clave;
            this.carreras = carreras;
        }

        public override string ToString()
        {
            return $"Usuario: {nombre} (ID: {id}, Username: {Username})";
        }
    }
}
