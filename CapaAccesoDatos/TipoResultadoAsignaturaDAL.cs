using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidadea;

namespace CapaAccesoDatos
{
    public class TipoResultadoAsignaturaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<TipoResultadoAsignatura> MostrarTipoResultadoAsignatura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarTipoResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            List<TipoResultadoAsignatura> lista = new List<TipoResultadoAsignatura>();

            while (leer.Read())
            {
                TipoResultadoAsignatura tipoResultadoAsignatura = new TipoResultadoAsignatura();
                tipoResultadoAsignatura.Id = leer.GetInt32(0);
                tipoResultadoAsignatura.Nombre = leer.GetString(1);
                lista.Add(tipoResultadoAsignatura);

            }
            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarTipoResultadoAsignatura(TipoResultadoAsignatura tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarTipoResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", tipo.Id);
            comando.Parameters.AddWithValue("@codigo", tipo.Codigo);
            comando.Parameters.AddWithValue("@nombre", tipo.Nombre);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
        }
        public void ActualizarTipoResultadoAsignatura(TipoResultadoAsignatura tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarTipoResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", tipo.Id);
            comando.Parameters.AddWithValue("@codigo", tipo.Codigo);
            comando.Parameters.AddWithValue("@nombre", tipo.Nombre);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
        }
        public void EliminarTipoResultadoAsignatura(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarTipoResultadoAsignatura";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
          
        }
        
          
    }
}
