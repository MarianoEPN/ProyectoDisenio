using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class ResultadoAprendizaje2DAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ResultadoAprendizaje> ObtenerResultadosAprendizaje(int carreraId)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ObtenerResultadosAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@CarreraID", carreraId);

            leer = comando.ExecuteReader();

            List<ResultadoAprendizaje> lista = new List<ResultadoAprendizaje>();

            while (leer.Read())
            {
                ResultadoAprendizaje resultado = new ResultadoAprendizaje();
                resultado.Id = leer.GetInt32(0);
                resultado.Codigo = leer.GetString(1);
                resultado.Descripcion = leer.GetString(2);
                lista.Add(resultado);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }
    }
}
