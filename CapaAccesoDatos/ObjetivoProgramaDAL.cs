using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class ObjetivoProgramaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ObjetivoPrograma> MostrarObjetivoPrograma()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarObjetivoPrograma";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            List<ObjetivoPrograma> lista = new List<ObjetivoPrograma>();

            while (leer.Read())
            {
                ObjetivoPrograma objetivoPrograma = new ObjetivoPrograma();
                objetivoPrograma.Id = leer.GetInt32(0);
                objetivoPrograma.Nombre = leer.GetString(1);
                objetivoPrograma.Fortalezas = leer.GetString(2);
                objetivoPrograma.Debilidades = leer.GetString(3);

                lista.Add(objetivoPrograma);

            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarObjetivoPrograma(ObjetivoPrograma obj)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarObjetivoPrograma";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", obj.Nombre);
            comando.Parameters.AddWithValue("@fortaleza", obj.Fortalezas);
            comando.Parameters.AddWithValue("@debilidad", obj.Debilidades);
            comando.Parameters.AddWithValue("@carrera_id", obj.Carrera);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void ActualizarObjetivoPrograma(ObjetivoPrograma obj)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarTObjetivoPrograma";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", obj.Id);
            comando.Parameters.AddWithValue("@nombre", obj.Nombre);
            comando.Parameters.AddWithValue("@fortaleza", obj.Fortalezas);
            comando.Parameters.AddWithValue("@debilidad", obj.Debilidades);
            comando.Parameters.AddWithValue("@carrera_id", obj.Carrera);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void EliminarObjetivoPrograma(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarObjetivoPrograma";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
    }
}