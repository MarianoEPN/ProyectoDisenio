using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class EuraceResultadoAprendizajeDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<EuraceResultadoAprendizaje> MostrarEuraceResultadoAprendizaje()
        {
            List<EuraceResultadoAprendizaje> lista = new List<EuraceResultadoAprendizaje>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                EuraceResultadoAprendizaje euraceResultadoAprendizaje = new EuraceResultadoAprendizaje();
                euraceResultadoAprendizaje.Id = leer.GetInt32(0);
                euraceResultadoAprendizaje.Comentario = leer.GetString(3);

                lista.Add(euraceResultadoAprendizaje);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;

        }

        public void InsertarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje, ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@obj_eurace_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);
            comando.Parameters.AddWithValue("@comentario", euraceResultadoAprendizaje.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarEuraceResultadoAprendizaje(EuraceResultadoAprendizaje euraceResultadoAprendizaje, ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@id", euraceResultadoAprendizaje.Id);
            comando.Parameters.AddWithValue("@obj_eurace_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);
            comando.Parameters.AddWithValue("@comentario", euraceResultadoAprendizaje.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarEuraceResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public List<EuraceResultadoAprendizaje> BuscarEuraceResultadoAprendizaje(ObjetivoEurace objetivo, ResultadoAprendizaje resultado)
        {
            List<EuraceResultadoAprendizaje> lista = new List<EuraceResultadoAprendizaje>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarEuraceResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@obj_eurace_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);
            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                EuraceResultadoAprendizaje euraceResultadoAprendizaje = new EuraceResultadoAprendizaje();
                euraceResultadoAprendizaje.Id = leer.GetInt32(0);
                euraceResultadoAprendizaje.Comentario = leer.GetString(3);

                lista.Add(euraceResultadoAprendizaje);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        /*
         -- Usar la base de datos creada
USE acreditacion;
GO

CREATE PROCEDURE BuscarEuraceResultadoAprendizaje
    @obj_eurace_id INT,
    @resultado_aprendizaje_id INT
AS
BEGIN
    -- Seleccionar los registros que coinciden con los parámetros de entrada
    SELECT 
        id,
        obj_eurace_id,
        resultado_aprendizaje_id,
        comentario
    FROM 
        eurace_resultado_aprendizaje
    WHERE 
        (@obj_eurace_id IS NULL OR obj_eurace_id = @obj_eurace_id) AND
        (@resultado_aprendizaje_id IS NULL OR resultado_aprendizaje_id = @resultado_aprendizaje_id);
END;

---Pruebas 

EXEC BuscarEuraceResultadoAprendizaje @obj_eurace_id = NULL, @resultado_aprendizaje_id = 2;

EXEC BuscarEuraceResultadoAprendizaje @obj_eurace_id = 10, @resultado_aprendizaje_id = 2;

EXEC BuscarEuraceResultadoAprendizaje @obj_eurace_id = 2, @resultado_aprendizaje_id = NULL;

EXEC BuscarEuraceResultadoAprendizaje @obj_eurace_id = NULL, @resultado_aprendizaje_id = NULL; 
         
         
       
         */




    }
}
