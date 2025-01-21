using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidadea;

namespace CapaAccesoDatos
{
    public class ObjetivoEuraceDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ObjetivoEurace> MostrarObjetivoEurace()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarObjetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ObjetivoEurace> lista = new List<ObjetivoEurace>();

            while (leer.Read())
            {
                ObjetivoEurace objetivoEurace = new ObjetivoEurace();
                objetivoEurace.Id = leer.GetInt32(0);
                objetivoEurace.Nombre = leer.GetString(1);
                objetivoEurace.Descripcion = leer.GetString(2);
                lista.Add(objetivoEurace);

            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarObjetivoEurace(ObjetivoEurace objetivo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarObjetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", objetivo.Id);
            comando.Parameters.AddWithValue("@codigo", objetivo.Codigo);
            comando.Parameters.AddWithValue("@nombre", objetivo.Nombre);
            comando.Parameters.AddWithValue("@descripcion", objetivo.Descripcion);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
        }   

        public void ActualizarObjetivoEurace(ObjetivoEurace objetivo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarObjetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", objetivo.Id);
            comando.Parameters.AddWithValue("@codigo", objetivo.Codigo);
            comando.Parameters.AddWithValue("@nombre", objetivo.Nombre);
            comando.Parameters.AddWithValue("@descripcion", objetivo.Descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarObejtivoEurace(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarObjetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }







    }
}
