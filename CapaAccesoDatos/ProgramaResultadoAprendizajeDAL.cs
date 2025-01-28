using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class ProgramaResultadoAprendizajeDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();

        public List<ProgramaResultadoAprendizaje> MostrarProgramaResultadoAprendizaje()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Clear();
            leer = comando.ExecuteReader();

            List<ProgramaResultadoAprendizaje> lista = new List<ProgramaResultadoAprendizaje>();

            while (leer.Read())
            {
                ProgramaResultadoAprendizaje item = new ProgramaResultadoAprendizaje();
                item.Id = leer.GetInt32(0);                
                item.Comentario = leer.GetString(3);
                lista.Add(item);
            }

            leer.Close();
            conexion.CerrarConexion();
            return lista;
        }

        public void InsertarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje item, ObjetivoPrograma objetivo, ResultadoAprendizaje resultado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;   
            comando.Parameters.AddWithValue("@obj_programa_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarProgramaResultadoAprendizaje(ProgramaResultadoAprendizaje item, ObjetivoPrograma objetivo, ResultadoAprendizaje resultado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", item.Id);
            comando.Parameters.AddWithValue("@obj_programa_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);
            comando.Parameters.AddWithValue("@comentario", item.Comentario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarProgramaResultadoAprendizaje(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public List<ProgramaResultadoAprendizaje> BuscarProgramaResultadoAprendizaje(ObjetivoPrograma objetivo, ResultadoAprendizaje resultado)
        {
            List<ProgramaResultadoAprendizaje> lista = new List<ProgramaResultadoAprendizaje>();

            // Abrir conexión
            comando.Connection = conexion.AbrirConexion();

            // Configuración del comando
            comando.CommandText = "BuscarProgramaResultadoAprendizaje";
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            // Limpiar parámetros anteriores (si los hay) y agregar nuevos
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@objetivo_programa_id", objetivo.Id);
            comando.Parameters.AddWithValue("@resultado_aprendizaje_id", resultado.Id);

            // Ejecutar el lector de datos
            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                ProgramaResultadoAprendizaje programaResultadoAprendizaje = new ProgramaResultadoAprendizaje();
                programaResultadoAprendizaje.Id = leer.GetInt32(0); // Asignar ID
                programaResultadoAprendizaje.Comentario = !leer.IsDBNull(3)
                    ? leer.GetString(3)
                    : null; // Asignar Comentario

                // Agregar a la lista
                lista.Add(programaResultadoAprendizaje);
            }

            // Cerrar conexión y lector
            conexion.CerrarConexion();
            leer.Close();

            return lista;
        }

    }
}

/*
 --CREACION DEL PROCEDIMIENTO BuscarProgramaResultadoAprendizaje
CREATE PROCEDURE BuscarProgramaResultadoAprendizaje
    @objetivo_programa_id INT,
    @resultado_aprendizaje_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        pra.id,
        pra.obj_programa_id,
        pra.resultado_aprendizaje_id,
        pra.comentario
    FROM 
        programa_resultado_aprendizaje pra
    WHERE 
        pra.obj_programa_id = @objetivo_programa_id
        AND pra.resultado_aprendizaje_id = @resultado_aprendizaje_id;
END;
GO

--Ejemplos de busqueda
EXEC BuscarProgramaResultadoAprendizaje @objetivo_programa_id = 16, @resultado_aprendizaje_id = 25;
EXEC BuscarProgramaResultadoAprendizaje @objetivo_programa_id = 30, @resultado_aprendizaje_id = 25;
 
 */