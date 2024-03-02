-- Crear la tabla de Usuarios con Identity
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255) NOT NULL
);

-- Insertar algunos registros de prueba en la tabla de Usuarios
INSERT INTO Usuarios (Nombre) VALUES ('Usuario1');
INSERT INTO Usuarios (Nombre) VALUES ('Usuario2');
INSERT INTO Usuarios (Nombre) VALUES ('Usuario3');

-- Crear la tabla de Actividades
CREATE TABLE Actividades (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(100) NOT NULL,
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id)
);

-- Insertar algunos registros de prueba en la tabla de Actividades
INSERT INTO Actividades (Descripcion, UsuarioId) VALUES ('Actividad1', 1);
INSERT INTO Actividades (Descripcion, UsuarioId) VALUES ('Actividad2', 2);
INSERT INTO Actividades (Descripcion, UsuarioId) VALUES ('Actividad3', 3);

-- Crear la tabla de Tiempos
CREATE TABLE Tiempos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Horas INT NOT NULL,
    ActividadId INT FOREIGN KEY REFERENCES Actividades(Id)
);

-- Insertar algunos registros de prueba en la tabla de Tiempos
INSERT INTO Tiempos (Fecha, Horas, ActividadId) VALUES ('2022-01-01', 4, 1);
INSERT INTO Tiempos (Fecha, Horas, ActividadId) VALUES ('2022-01-02', 2, 2);
INSERT INTO Tiempos (Fecha, Horas, ActividadId) VALUES ('2022-01-03', 8, 3);
