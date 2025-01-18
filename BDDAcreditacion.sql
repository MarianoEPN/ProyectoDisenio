-- Crear la base de datos
CREATE DATABASE acreditacionBDD;
GO

-- Usar la base de datos creada
USE acreditacionBDD;
GO

-- Crear las tablas en el orden correcto para asegurar las relaciones

-- Tabla objetivo_eurace
CREATE TABLE objetivo_eurace (
    id INT NOT NULL PRIMARY KEY,
    codigo VARCHAR(12),
    nombre VARCHAR(400),
    descripcion VARCHAR(400)
);

-- Tabla tipo_resultado_asignatura
CREATE TABLE tipo_resultado_asignatura (
    id INT NOT NULL PRIMARY KEY,
    codigo VARCHAR(12),
    nombre VARCHAR(255)
);

-- Tabla asignatura
CREATE TABLE asignatura (
    id INT NOT NULL PRIMARY KEY,
    codigo VARCHAR(12),
    nombre VARCHAR(255),
    nivel INT
);

CREATE TABLE carrera (
    id INT NOT NULL PRIMARY KEY,
	correo VARCHAR(255) NOT NULL,
    nombre VARCHAR(255) NOT NULL,
    contrasenia VARCHAR(255) NOT NULL,
    pensum TEXT
);

-- Tabla intermedia carrera_asignatura 
CREATE TABLE carrera_asignatura (
    id INT NOT NULL PRIMARY KEY, 
    carrera_id INT NOT NULL,
    asignatura_id INT NOT NULL,
    FOREIGN KEY (carrera_id) REFERENCES carrera(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (asignatura_id) REFERENCES asignatura(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Tabla doctrine_migration_versions
CREATE TABLE doctrine_migration_versions (
    version VARCHAR(191) NOT NULL PRIMARY KEY,
    executed_at DATETIME,
    execution_time INT
);

-- Tabla resultado_aprendizaje
CREATE TABLE resultado_aprendizaje ( --PERFIL EGRESO
    id INT NOT NULL PRIMARY KEY,
    codigo VARCHAR(12),
    descripcion VARCHAR(380),
    carrera_id INT NOT NULL, -- Relación directa con carrera
    FOREIGN KEY (carrera_id) REFERENCES carrera(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Tabla resultado_aprendizaje_asignatura
CREATE TABLE resultado_aprendizaje_asignatura (
    id INT NOT NULL PRIMARY KEY,
    codigo VARCHAR(12),
    descripcion VARCHAR(800),
    asignatura_id INT,
    tipo_id INT,
    FOREIGN KEY (asignatura_id) REFERENCES asignatura(id),
    FOREIGN KEY (tipo_id) REFERENCES tipo_resultado_asignatura(id)
);

-- Tabla eurace_resultado_asignatura
CREATE TABLE eurace_resultado_asignatura (
    id INT NOT NULL PRIMARY KEY,
    comentario VARCHAR(255),
    obj_eurace_id INT,
    resultado_asignatura_id INT,
    FOREIGN KEY (obj_eurace_id) REFERENCES objetivo_eurace(id),
    FOREIGN KEY (resultado_asignatura_id) REFERENCES resultado_aprendizaje_asignatura(id)
);

-- Tabla eurace_resultado_aprendizaje
CREATE TABLE eurace_resultado_aprendizaje (
    id INT NOT NULL PRIMARY KEY,
    comentario VARCHAR(800),
    obj_eurace_id INT,
    resultado_aprendizaje_id INT,
    FOREIGN KEY (obj_eurace_id) REFERENCES objetivo_eurace(id),
    FOREIGN KEY (resultado_aprendizaje_id) REFERENCES resultado_aprendizaje(id)
);

-- Tabla match_resultado_aprendizaje
CREATE TABLE match_resultado_aprendizaje (
    id INT NOT NULL PRIMARY KEY,
    perfil_egreso_id INT,
    sub_resultado_aprendizage_asignatura_id INT,
    nivelaporte VARCHAR(12),
    FOREIGN KEY (perfil_egreso_id) REFERENCES resultado_aprendizaje(id),
    FOREIGN KEY (sub_resultado_aprendizage_asignatura_id) REFERENCES resultado_aprendizaje_asignatura(id)
);

-- Tabla messenger_messages
CREATE TABLE messenger_messages (
    id BIGINT NOT NULL PRIMARY KEY,
    body TEXT,
    headers TEXT,
    queue_name VARCHAR(190),
    created_at DATETIME,
    available_at DATETIME,
    delivered_at DATETIME
);

-- Tabla objetivo_programa
CREATE TABLE objetivo_programa (  --PERFIL PROFESIONAL
    id INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(400),
    codigo VARCHAR(12),
    fortaleza VARCHAR(255),
    debilidad VARCHAR(255),
    carrera_id INT NOT NULL, -- Relación directa con carrera
    FOREIGN KEY (carrera_id) REFERENCES carrera(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Tabla programa_resultado_aprendizaje
CREATE TABLE programa_resultado_aprendizaje (
    id INT NOT NULL PRIMARY KEY,
    comentario VARCHAR(255),
    obj_programa_id INT,
    resultado_aprendizaje_id INT,
    FOREIGN KEY (obj_programa_id) REFERENCES objetivo_programa(id),
    FOREIGN KEY (resultado_aprendizaje_id) REFERENCES resultado_aprendizaje(id)
);