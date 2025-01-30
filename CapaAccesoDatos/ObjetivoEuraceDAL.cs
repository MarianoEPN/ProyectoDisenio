using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            comando.CommandText = "MostrarObetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ObjetivoEurace> lista = new List<ObjetivoEurace>();

            while (leer.Read())
            {
                ObjetivoEurace objetivo = new ObjetivoEurace();
                objetivo.Id = leer.GetInt32(0);
                objetivo.Codigo = leer.GetString(1);
                objetivo.Nombre = leer.GetString(2);
                objetivo.Descripcion = leer.GetString(3);
                lista.Add(objetivo);
            }


            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public void InsertarObjetivoEurace(ObjetivoEurace objetivo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarObjetivoEurace";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
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

        public void EliminarObjetivoEurace(int id)
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
