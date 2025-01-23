using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaAccesoDatos
{ 

        public class ObjetivoProgramaDAL
        {
            private ConexionBD conexion = new ConexionBD();
            SqlDataReader leer;
            SqlCommand comando = new SqlCommand();

            // Mostrar todos los objetivos del programa
            public List<ObjetivoPrograma> MostrarObjetivosPrograma()
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "MostrarObjetivosPrograma";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Clear();
                leer = comando.ExecuteReader();

                List<ObjetivoPrograma> lista = new List<ObjetivoPrograma>();

                while (leer.Read())
                {
                        ObjetivoPrograma objetivo = new ObjetivoPrograma();
                        Id = leer.GetInt32(0),
                        Nombre = leer.GetString(1),
                        Codigo = leer.GetString(2);
                        Fortaleza = leer.GetString(3),
                        Debilidad = leer.GetString(4),
                        CarreraID = leer.GetInt32(5),
                        lista.Add(objetivo);
            }
                    
                
                leer.Close();
                conexion.CerrarConexion();
                return lista;
            }

            // Insertar un nuevo objetivo del programa
            public void InsertarObjetivoPrograma(ObjetivoPrograma objetivo)
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "InsertarObjetivoPrograma";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", objetivo.Nombre);
                comando.Parameters.AddWithValue("@codigo", objetivo.Codigo);
                comando.Parameters.AddWithValue("@fortaleza", objetivo.Fortaleza);
                comando.Parameters.AddWithValue("@debilidad", objetivo.Debilidad);
                comando.Parameters.AddWithValue("@carrera_id", objetivo.CarreraId);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

            // Actualizar un objetivo del programa existente
            public void ActualizarObjetivoPrograma(ObjetivoPrograma objetivo)
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "ActualizarObjetivoPrograma";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", objetivo.Id);
                comando.Parameters.AddWithValue("@nombre", objetivo.Nombre);
                comando.Parameters.AddWithValue("@codigo", objetivo.Codigo);
                comando.Parameters.AddWithValue("@fortaleza", objetivo.Fortaleza);
                comando.Parameters.AddWithValue("@debilidad", objetivo.Debilidad);
                comando.Parameters.AddWithValue("@carrera_id", objetivo.CarreraId);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }

            // Eliminar un objetivo del programa por ID
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
}



