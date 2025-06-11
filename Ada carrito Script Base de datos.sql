CREATE DATABASE ADAcarrito

USE ADAcarrito;
GO

CREATE TABLE Usuarios(
Id INT PRIMARY KEY IDENTITY(1,1),
NombreCompleto NVARCHAR(100)NOT NULL,
Direccion NVARCHAR(150),
Telefono NVARCHAR(20),
Login NVARCHAR(50)NOT NULL UNIQUE,
Identificacion NVARCHAR(30) NOT NULL UNIQUE,
Contraseña NVARCHAR(225) NOT NULL,
Rol smallint not null
);
GO

CREATE TABLE Productos(
Id INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(100)NOT NULL,
CantidadDisponible INT NOT NULL,
Descripcion NVARCHAR(255)
);
GO

CREATE TABLE Transacciones (
Id INT PRIMARY KEY IDENTITY(1,1),
UsuarioId INT NOT NULL,
ProductoId INT NOT NULL,
CantidadComprada INT NOT NULL,
FechaCompra DATETIME NOT NULL DEFAULT GETDATE()
);
GO


INSERT INTO Productos (Nombre, CantidadDisponible, Descripcion)
VALUES 
('Arroz Diana 1kg', 20, 'Arroz blanco de excelente calidad'),
('Cepillo de dientes', 50, 'Cepillo para adultos de cerdas suaves'),
('Galletas Festival', 30, 'Paquete de galletas sabor fresa');
