USE acreditacion;
GO

--TABLA tipo_resultado_asignatura

-- Insertar en tipo_resultado_asignatura
CREATE PROCEDURE InsertarTipoResultadoAsignatura
  @codigo VARCHAR(12),
  @nombre VARCHAR(255)
AS
BEGIN
  INSERT INTO tipo_resultado_asignatura (codigo, nombre)
  VALUES (@codigo, @nombre);
END;
GO

-- Mostrar todos los registros de tipo_resultado_asignatura
CREATE PROCEDURE MostrarTipoResultadoAsignatura
AS
BEGIN
  SELECT * FROM tipo_resultado_asignatura;
END;
GO

-- Actualizar un registro de tipo_resultado_asignatura por id
CREATE PROCEDURE ActualizarTipoResultadoAsignatura
  @id INT,
  @codigo VARCHAR(12),
  @nombre VARCHAR(255)
AS
BEGIN
  UPDATE tipo_resultado_asignatura
  SET codigo = @codigo,
      nombre = @nombre
  WHERE id = @id;
END;
GO

-- Eliminar un registro de tipo_resultado_asignatura por id
CREATE PROCEDURE EliminarTipoResultadoAsignatura
  @id INT
AS
BEGIN
  DELETE FROM tipo_resultado_asignatura
  WHERE id = @id;
END;
GO

-- TABLA carrera

-- Insertar en carrera
CREATE PROCEDURE InsertarCarrera
  @correo VARCHAR(32),
  @nombre VARCHAR(255),
  @pensum VARCHAR(255)
AS
BEGIN
  INSERT INTO carrera (correo, nombre, pensum)
  VALUES (@correo, @nombre, @pensum);
END;
GO

-- Mostrar todos los registros de carrera
CREATE PROCEDURE MostrarCarrera
AS
BEGIN
  SELECT * FROM carrera;
END;
GO

-- Actualizar un registro de carrera por id
CREATE PROCEDURE ActualizarCarrera
  @id INT,
  @correo VARCHAR(32),
  @nombre VARCHAR(255),
  @pensum VARCHAR(255)
AS
BEGIN
  UPDATE carrera
  SET correo = @correo,
      nombre = @nombre,
      pensum = @pensum
  WHERE id = @id;
END;
GO

-- Eliminar un registro de carrera por id
CREATE PROCEDURE EliminarCarrera
  @id INT
AS
BEGIN
  DELETE FROM carrera
  WHERE id = @id;
END;
GO


--------------------TABLA ObetivoEurace---------------------
-- Insertar
CREATE PROCEDURE InsertarObetivoEurace (
    @id INT,
	@codigo VARCHAR(12),
	@nombre VARCHAR(400),
    @descripcion VARCHAR(400)
)
AS
BEGIN
    INSERT INTO objetivo_eurace(id, codigo, nombre, descripcion)
    VALUES (@id, @codigo, @nombre, @descripcion);
END;
GO

-- Mostrar
CREATE PROCEDURE MostrarObetivoEurace
AS
BEGIN
    SELECT * FROM objetivo_eurace;
END;
GO

-- Actualizar
CREATE PROCEDURE ActualizarObetivoEurace (
    @id INT,
	@codigo VARCHAR(12),
	@nombre VARCHAR(400),
    @descripcion VARCHAR(400)
)
AS
BEGIN
    UPDATE objetivo_eurace
    SET codigo = @codigo,
		nombre = @nombre,
		descripcion = @descripcion        
    WHERE id = @id;
END;
GO

-- Eliminar
CREATE PROCEDURE EliminarObetivoEurace (
    @id INT
)
AS
BEGIN
    DELETE FROM objetivo_eurace WHERE id = @id;
END;
GO

--------------------TABLA Asignatura ---------------------

-- Insertar
CREATE PROCEDURE InsertarAsignatura (
    @id INT,
	@codigo VARCHAR (12),
    @nombre VARCHAR(255),
    @nivel INT
)
AS
BEGIN
    INSERT INTO asignatura(id, codigo, nombre, nivel)
    VALUES (@id, @codigo, @nombre, @nivel);
END;
GO

-- Mostrar
CREATE PROCEDURE MostrarAsignatura
AS
BEGIN
    SELECT * FROM asignatura;
END;
GO

-- Actualizar
CREATE PROCEDURE ActualizarAsignatura (
    @id INT,
	@codigo VARCHAR (12),
    @nombre VARCHAR(255),
    @nivel INT
)
AS
BEGIN
    UPDATE asignatura
    SET codigo = @codigo,
        nombre = @nombre,
		nivel =  @nivel
    WHERE id = @id;
END;
GO

-- Eliminar
CREATE PROCEDURE EliminarAsignatura (
    @id INT
)
AS
BEGIN
    DELETE FROM asignatura WHERE id = @id;
END;
GO

--------------------TABLA OBJETIVO PROGRAMA---------------------
-- Insertar--
CREATE PROCEDURE InsertarObjetivoPrograma (
    @nombre VARCHAR(400),
    @codigo VARCHAR(12),
    @fortaleza VARCHAR(255),
    @debilidad VARCHAR(255),
    @carrera_id INT
)
AS
BEGIN
    INSERT INTO objetivo_programa (nombre, codigo, fortaleza, debilidad, carrera_id)
    VALUES (@nombre, @codigo, @fortaleza, @debilidad, @carrera_id);
END;
GO

-- Mostrar--
CREATE PROCEDURE MostrarObjetivosPrograma
AS
BEGIN
    SELECT op.id, op.nombre, op.codigo, op.fortaleza, op.debilidad, c.nombre AS carrera
    FROM objetivo_programa op
    JOIN carrera c ON op.carrera_id = c.id;
END;
GO

-- Actualizar--
CREATE PROCEDURE ActualizarObjetivoPrograma (
    @id INT,
    @nombre VARCHAR(400),
    @codigo VARCHAR(12),
    @fortaleza VARCHAR(255),
    @debilidad VARCHAR(255),
    @carrera_id INT
)
AS
BEGIN
    UPDATE objetivo_programa
    SET nombre = @nombre,
        codigo = @codigo,
        fortaleza = @fortaleza,
        debilidad = @debilidad,
        carrera_id = @carrera_id
    WHERE id = @id;
END;
GO

-- Eliminar--
CREATE PROCEDURE EliminarObjetivoPrograma (
    @id INT
)
AS
BEGIN
    DELETE FROM objetivo_programa WHERE id = @id;
END;
GO

--------------------TABLA RESULTADO_APRENDIZAJE---------------------
-- Insertar--
CREATE PROCEDURE InsertarResultadoAprendizaje (
    @codigo VARCHAR(12),
    @descripcion VARCHAR(500),
    @carrera_id INT
)
AS
BEGIN
    INSERT INTO resultado_aprendizaje (codigo, descripcion, carrera_id)
    VALUES (@codigo, @descripcion, @carrera_id);
END;
GO

-- Mostrar--
CREATE PROCEDURE MostrarResultadosAprendizaje
AS
BEGIN
    SELECT ra.id, ra.codigo, ra.descripcion, c.nombre AS carrera
    FROM resultado_aprendizaje ra
    JOIN carrera c ON ra.carrera_id = c.id;
END;
GO

-- Actualizar--

CREATE PROCEDURE ActualizarResultadoAprendizaje (
    @id INT,
    @codigo VARCHAR(12),
    @descripcion VARCHAR(500),
    @carrera_id INT
)
AS
BEGIN
    UPDATE resultado_aprendizaje
    SET codigo = @codigo,
        descripcion = @descripcion,
        carrera_id = @carrera_id
    WHERE id = @id;
END;
GO


-- Eliminar--

CREATE PROCEDURE EliminarResultadoAprendizaje (
    @id INT
)
AS
BEGIN
    DELETE FROM resultado_aprendizaje WHERE id = @id;
END;
GO

----------resultado_aprendizaje_asignatura----------------------------
CREATE PROCEDURE InsertarResultadoAprendizajeAsignatura(
  @asignatura_id INT,
  @tipo_id INT,
  @codigo VARCHAR(12),
  @descripcion VARCHAR(500)
)
AS
BEGIN
  INSERT INTO resultado_aprendizaje_asignatura (asignatura_id, tipo_id, codigo, descripcion)
  VALUES (@asignatura_id, @tipo_id, @codigo, @descripcion);
END;
GO

CREATE PROCEDURE ActualizarResultadoAprendizajeAsignatura(
  @id INT,
  @asignatura_id INT,
  @tipo_id INT,
  @codigo VARCHAR(12),
  @descripcion VARCHAR(500)
 )
AS
BEGIN
  UPDATE resultado_aprendizaje_asignatura
  SET asignatura_id = @asignatura_id,
      tipo_id = @tipo_id,
      codigo = @codigo,
      descripcion = @descripcion
  WHERE id = @id;
END;
GO

CREATE PROCEDURE EliminarResultadoAprendizajeAsignatura (
  @id INT
)
AS
BEGIN
  DELETE FROM resultado_aprendizaje_asignatura
  WHERE id = @id;
END;
GO

CREATE PROCEDURE MostrarResultadoAprendizajeAsignatura
AS
BEGIN
  SELECT * FROM resultado_aprendizaje_asignatura;
END;
GO

----------programa_resultado_aprendizaje-----------
CREATE PROCEDURE InsertarProgramaResultadoAprendizaje (
  @obj_programa_id INT,
  @resultado_aprendizaje_id INT,
  @comentario VARCHAR(255)
 )
AS
BEGIN
  INSERT INTO programa_resultado_aprendizaje (obj_programa_id, resultado_aprendizaje_id, comentario)
  VALUES (@obj_programa_id, @resultado_aprendizaje_id, @comentario);
END;
GO

CREATE PROCEDURE ActualizarProgramaResultadoAprendizaje (
  @id INT,
  @obj_programa_id INT,
  @resultado_aprendizaje_id INT,
  @comentario VARCHAR(255)
)
AS
BEGIN
  UPDATE programa_resultado_aprendizaje
  SET obj_programa_id = @obj_programa_id,
      resultado_aprendizaje_id = @resultado_aprendizaje_id,
      comentario = @comentario
  WHERE id = @id;
END;
GO

CREATE PROCEDURE EliminarProgramaResultadoAprendizaje(
  @id INT
)
AS
BEGIN
  DELETE FROM programa_resultado_aprendizaje
  WHERE id = @id;
END;
GO

CREATE PROCEDURE MostrarProgramaResultadoAprendizaje
AS
BEGIN
  SELECT * FROM programa_resultado_aprendizaje;
END;
GO

-- ============================
-- Procedimientos para la tabla eurace_resultado_aprendizaje
-- ============================

-- Procedimiento para Insertar
CREATE PROCEDURE InsertarEuraceResultadoAprendizaje
    @obj_eurace_id INT,
    @resultado_aprendizaje_id INT,
    @comentario VARCHAR(255)
AS
BEGIN
    INSERT INTO eurace_resultado_aprendizaje (obj_eurace_id, resultado_aprendizaje_id, comentario)
    VALUES (@obj_eurace_id, @resultado_aprendizaje_id, @comentario);
END;
GO

-- Procedimiento para Actualizar
CREATE PROCEDURE ActualizarEuraceResultadoAprendizaje
    @id INT,
    @obj_eurace_id INT,
    @resultado_aprendizaje_id INT,
    @comentario VARCHAR(255)
AS
BEGIN
    UPDATE eurace_resultado_aprendizaje
    SET obj_eurace_id = @obj_eurace_id,
        resultado_aprendizaje_id = @resultado_aprendizaje_id,
        comentario = @comentario
    WHERE id = @id;
END;
GO

-- Procedimiento para Eliminar
CREATE PROCEDURE EliminarEuraceResultadoAprendizaje
    @id INT
AS
BEGIN
    DELETE FROM eurace_resultado_aprendizaje
    WHERE id = @id;
END;
GO

-- Procedimiento para Mostrar
CREATE PROCEDURE MostrarEuraceResultadoAprendizaje
AS
BEGIN
    SELECT * FROM eurace_resultado_aprendizaje;
END;
GO

-- ============================
-- Procedimientos para la tabla match_resultado_aprendizaje
-- ============================

-- Procedimiento para Insertar
CREATE PROCEDURE InsertarMatchResultadoAprendizaje
    @perfil_egreso_id INT,
    @sub_resultado_aprendizage_asignatura_id INT,
    @nivelaporte VARCHAR(12)
AS
BEGIN
    INSERT INTO match_resultado_aprendizaje (perfil_egreso_id, sub_resultado_aprendizage_asignatura_id, nivelaporte)
    VALUES (@perfil_egreso_id, @sub_resultado_aprendizage_asignatura_id, @nivelaporte);
END;
GO

-- Procedimiento para Actualizar
CREATE PROCEDURE ActualizarMatchResultadoAprendizaje
    @id INT,
    @perfil_egreso_id INT,
    @sub_resultado_aprendizage_asignatura_id INT,
    @nivelaporte VARCHAR(12)
AS
BEGIN
    UPDATE match_resultado_aprendizaje
    SET perfil_egreso_id = @perfil_egreso_id,
        sub_resultado_aprendizage_asignatura_id = @sub_resultado_aprendizage_asignatura_id,
        nivelaporte = @nivelaporte
    WHERE id = @id;
END;
GO

-- Procedimiento para Eliminar
CREATE PROCEDURE EliminarMatchResultadoAprendizaje
    @id INT
AS
BEGIN
    DELETE FROM match_resultado_aprendizaje
    WHERE id = @id;
END;
GO

-- Procedimiento para Mostrar
CREATE PROCEDURE MostrarMatchResultadoAprendizaje
AS
BEGIN
    SELECT * FROM match_resultado_aprendizaje;
END;
GO

-- ============================
-- Procedimientos para la tabla usuario
-- ============================

-- Procedimiento para Insertar
CREATE PROCEDURE InsertarUsuario
    @carrera_id INT,
    @username VARCHAR(32),
    @correo VARCHAR(32),
    @clave VARCHAR(32),
    @nombre VARCHAR(100)
AS
BEGIN
    INSERT INTO usuario (carrera_id, username, correo, clave, nombre)
    VALUES (@carrera_id, @username, @correo, @clave, @nombre);
END;
GO

-- Procedimiento para Actualizar
CREATE PROCEDURE ActualizarUsuario
    @id INT,
    @carrera_id INT,
    @username VARCHAR(32),
    @correo VARCHAR(32),
    @clave VARCHAR(32),
    @nombre VARCHAR(100)
AS
BEGIN
    UPDATE usuario
    SET carrera_id = @carrera_id,
        username = @username,
        correo = @correo,
        clave = @clave,
        nombre = @nombre
    WHERE id = @id;
END;
GO

-- Procedimiento para Eliminar
CREATE PROCEDURE EliminarUsuario
    @id INT
AS
BEGIN
    DELETE FROM usuario
    WHERE id = @id;
END;
GO

-- Procedimiento para Mostrar
CREATE PROCEDURE MostrarUsuario
AS
BEGIN
    SELECT * FROM usuario;
END;
GO
