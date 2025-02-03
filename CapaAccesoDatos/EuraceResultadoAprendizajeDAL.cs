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
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@obj_eurace_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);

            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                EuraceResultadoAprendizaje relacion = new EuraceResultadoAprendizaje();
                relacion.Id = leer.GetInt32(0);
                relacion.ObjEuraceId = leer.GetInt32(1);
                relacion.ResultadoAprendizajeId = leer.GetInt32(2);
                relacion.Comentario = leer.GetString(3);
                lista.Add(relacion);
            }

            conexion.CerrarConexion();
            leer.Close();
            return lista;
        }

        public List<EuraceResultadoAprendizaje> MostrarEuraceResultadoAprendizajePorCarrera(int carreraId)
        {
            List<EuraceResultadoAprendizaje> lista = new List<EuraceResultadoAprendizaje>();

            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();

            // Configurar el comando para llamar al procedimiento almacenado
            comando.CommandText = "MostrarEuraceResultadoAprendizajePorCarrera";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@carrera_id", carreraId);

            // Ejecutar el lector
            leer = comando.ExecuteReader();

            // Leer cada registro y llenar la lista
            while (leer.Read())
            {
                EuraceResultadoAprendizaje euraceResultadoAprendizaje = new EuraceResultadoAprendizaje();
                euraceResultadoAprendizaje.Id = leer.GetInt32(0);
                euraceResultadoAprendizaje.ObjEuraceId = leer.GetInt32(1);            // Obteniendo el id del objetivo
                euraceResultadoAprendizaje.ResultadoAprendizajeId = leer.GetInt32(2);   // Obteniendo el id del resultado
                euraceResultadoAprendizaje.Comentario = leer.GetString(3);

                lista.Add(euraceResultadoAprendizaje);
            }

            // Cerrar el lector y la conexión
            leer.Close();
            conexion.CerrarConexion();

            return lista;
        }

    }
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



CREATE PROCEDURE MostrarEuraceResultadoAprendizajePorCarrera
    @carrera_id INT
AS
BEGIN
    SELECT era.id,
           era.obj_eurace_id,
           era.resultado_aprendizaje_id,
           era.comentario
    FROM eurace_resultado_aprendizaje era
    INNER JOIN objetivo_eurace oe ON era.obj_eurace_id = oe.id
    INNER JOIN resultado_aprendizaje ra ON era.resultado_aprendizaje_id = ra.id
    WHERE ra.carrera_id = @carrera_id;
END;
GO

EXEC MostrarEuraceResultadoAprendizajePorCarrera @carrera_id = 1;



 */

