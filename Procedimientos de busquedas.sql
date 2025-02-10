USE acreditacion;
GO

------------------------ ObtenerCarreraPorUsuario ----------------------------------
CREATE PROCEDURE ObtenerCarreraPorUsuario
    @UsuarioId INT
AS
BEGIN
    -- Declarar una variable para almacenar el valor de la foreign key (carrera_id)
    DECLARE @CarreraId INT;

    -- Obtener el valor de la clave foránea (carrera_id) del usuario
    SELECT @CarreraId = carrera_id
    FROM Usuario
    WHERE Id = @UsuarioId;

    -- Verificar si se encontró el usuario y la clave foránea
    IF @CarreraId IS NOT NULL
    BEGIN
        -- Retornar los datos de la tabla Carrera donde Id = @CarreraId
        SELECT *
        FROM Carrera
        WHERE Id = @CarreraId;
    END
    ELSE
    BEGIN
        -- Retornar un mensaje en caso de que no se encuentre el usuario o la carrera
        RAISERROR ('Usuario no encontrado o no tiene una carrera asignada.', 16, 1);
    END
END;
GO



-- Procedimiento almacenado para obtener las asignaturas de una carrera
CREATE PROCEDURE ObtenerAsignaturasPorCarrera
    @CarreraID INT
AS
BEGIN
    SELECT 
        a.id AS AsignaturaID,
        a.codigo AS Codigo,
        a.nombre AS Nombre,
        a.nivel AS Nivel
    FROM asignatura a
    WHERE a.carrera_id = @CarreraID;
END;
GO



-- Procedimiento almacenado para obtener los objetivos del programa de una carrera
CREATE PROCEDURE ObtenerObjetivosProgramaPorCarrera
    @CarreraID INT
AS
BEGIN
    SELECT 
        o.id AS ObjetivoProgramaID,
        o.nombre AS Nombre,
        o.fortaleza AS Fortaleza,
        o.debilidad AS Debilidad,
        o.carrera_id AS CarreraID
    FROM objetivo_programa o
    WHERE o.carrera_id = @CarreraID;
END;
GO


-----------------------ObtenerResultadosAprendizaje------------------------------------------
CREATE PROCEDURE ObtenerResultadosAprendizaje
    @CarreraID INT
AS
BEGIN
    SELECT ra.*
    FROM resultado_aprendizaje ra
    INNER JOIN carrera c ON ra.carrera_id = c.id
    WHERE c.id = @CarreraID;
END;
GO


-------------------ObtenerResultadosAprendizajeAsignatura -----------------------------
CREATE PROCEDURE ObtenerResultadosAprendizajeAsignatura
    @AsignaturaID INT
AS
BEGIN
    SELECT raa.*
    FROM resultado_aprendizaje_asignatura raa
    INNER JOIN asignatura a ON raa.asignatura_id = a.id
    WHERE a.id = @AsignaturaID;
END;
GO


--------CREACION DEL PROCEDIMIENTO BuscarProgramaResultadoAprendizaje--------------------
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
 GO



 ----------------------- BuscarEuraceResultadoAprendizaje --------------------------------------
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
GO



-----------------BuscarMatchResultadoAprendizaje-------------------------------------------------
CREATE PROCEDURE BuscarMatchResultadoAprendizaje
    @ResultadoAprendizajeAsignaturaID INT,
    @ResultadoAprendizajeID INT
AS
BEGIN
    SELECT mra.*
    FROM match_resultado_aprendizaje mra
    INNER JOIN resultado_aprendizaje_asignatura raa ON mra.sub_resultado_aprendizage_asignatura_id = raa.id
    INNER JOIN resultado_aprendizaje ra ON mra.perfil_egreso_id = ra.id
    WHERE raa.id = @ResultadoAprendizajeAsignaturaID AND ra.id = @ResultadoAprendizajeID;
END;