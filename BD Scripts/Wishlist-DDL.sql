CREATE DATABASE Wishlist;
GO

USE Wishlist;
GO

CREATE TABLE Desejos(
	idDesejo INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
	nomeDesejo VARCHAR(200)
);
GO

CREATE TABLE Usuarios(
	idUsuario INT PRIMARY KEY IDENTITY,
	nomeUsuario VARCHAR(200),
	email VARCHAR(200),
	senha VARCHAR(50)
);
GO