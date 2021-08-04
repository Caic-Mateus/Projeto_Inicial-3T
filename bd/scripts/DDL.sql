---DDL---
CREATE DATABASE TechnoGear;
GO
USE TechnoGear
--------------------------

CREATE TABLE TipoEquipamento
(
		idTipoEquipamento INT PRIMARY KEY IDENTITY,
		NomeEquipamento VARCHAR(150)NOT NULL
);

---------------------------
CREATE TABLE Usuario
(
		idUsuario INT PRIMARY KEY IDENTITY,
		Nome VARCHAR(150),
		Email VARCHAR (150) NOT NULL,
		Senha VARCHAR (150)NOT NULL
);

---------------------------
CREATE TABLE Sala
(
		idSala INT PRIMARY KEY IDENTITY,
		Andar INT NOT NULL,
		Nome VARCHAR(150) NOT NULL,
		Metragem INT NOT NULL
);

--------------------------
CREATE TABLE Equipamento
(
		idEquipamento INT PRIMARY KEY IDENTITY,
		idTipoEquipamento INT FOREIGN KEY REFERENCES TipoEquipamento(idTipoEquipamento),
		idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
		idSala INT FOREIGN KEY REFERENCES Sala(idSala),
		Marca VARCHAR(150) NOT NULL,
		NumeroSerie INT NOT NULL,
		NumeroPatrimonio INT NOT NULL,
		Situacao BIT NOT NULL,
		Descricao VARCHAR(150) NOT NULL


);
---------------------------------
CREATE TABLE Relacao
(
		idRelacao INT PRIMARY KEY IDENTITY,
		idEquipamento INT FOREIGN KEY REFERENCES Equipamento(idEquipamento),
		idSala INT FOREIGN KEY REFERENCES Sala(idSala),
		DataEntrada DATE NOT NULL,
		DataSaida DATE NOT NULL
);

