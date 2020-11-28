--CREATE DATABASE Restaurantes

USE [Restaurantes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Utilizador(
	ID_Utilizador							INTEGER				NOT NULL		IDENTITY(1,1),
	Email									NVARCHAR(100)		NOT NULL,
	EmailConfirmado							BIT					NOT NULL,
	Username								NVARCHAR(100)		NOT NULL,
	_Password								NVARCHAR(100)		NOT NULL,
	Endereco_Morada							NVARCHAR(50)		NOT NULL,
	Endereco_CodigoPostal					NVARCHAR(8)			NOT NULL,
	Endereco_Localidade						NVARCHAR(30)		NOT NULL,
	CHECK(Endereco_CodigoPostal LIKE '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]'),

	PRIMARY KEY(ID_Utilizador),


);




CREATE TABLE Bloqueio(
		
	ID_Bloqueio						INTEGER			NOT NULL			IDENTITY(1,1),
	ID_Utilizador					INTEGER			NOT NULL,
	Motivo							NVARCHAR(500)	NOT NULL,

	PRIMARY KEY(ID_Bloqueio, ID_Utilizador),
	FOREIGN KEY(ID_Utilizador) REFERENCES Utilizador(ID_Utilizador),

	
);


CREATE TABLE Palavras_Chave(
	ID_Palavras_Chave				INTEGER			NOT NULL			IDENTITY(1,1),
	ID_Utilizador					INTEGER			NOT NULL,
	Palavra							NVARCHAR(150)	NOT NULL,
	


	PRIMARY KEY(ID_Palavras_Chave, ID_Utilizador),
	FOREIGN KEY(ID_Utilizador) REFERENCES Utilizador(ID_Utilizador),
	

);


CREATE TABLE Clientes(
		
	ID_Cliente						INTEGER			NOT NULL,
	Nome							NVARCHAR(100)	NOT NULL,
	Apelido							NVARCHAR(20)		NOT NULL,

	PRIMARY KEY(ID_Cliente),
	FOREIGN KEY(ID_Cliente) REFERENCES Utilizador(ID_Utilizador),


	
);

CREATE TABLE Administrador(
		
	ID_Admin						INTEGER			NOT NULL,
	Nome							NVARCHAR(100)	NOT NULL,
	Apelido							NVARCHAR(20)		NOT NULL,

	PRIMARY KEY(ID_Admin),
	FOREIGN KEY(ID_Admin) REFERENCES Utilizador(ID_Utilizador),
	
);

CREATE TABLE Restaurante(
		
	ID_Restaurante						INTEGER			NOT NULL,
	Nome_Restaurante					NVARCHAR(100)	NOT NULL,
	Telefone							NVARCHAR(20)		NOT NULL,
	Foto								NVARCHAR(500)	NOT NULL,
	Status_Restaurante					BIT				NOT NULL,
	Tipo_Servico						NVARCHAR(40)		NOT NULL,
	Dia_De_Descanso						NVARCHAR(20)		NOT NULL,

	

	PRIMARY KEY(ID_Restaurante),
	FOREIGN KEY(ID_Restaurante) REFERENCES Utilizador(ID_Utilizador),



	
);

CREATE TABLE Horario(
	ID_Horario						INTEGER			NOT NULL			IDENTITY(1,1),
	ID_Restaurante					INTEGER			NOT NULL,
	Dia_Semana						INTEGER			NOT NULL,
	Hora_De_Entrada					TIME			NOT NULL,
	Hora_De_Saida					TIME            NOT NULL,


	PRIMARY KEY(ID_Horario, ID_Restaurante),
	FOREIGN KEY(ID_Restaurante) REFERENCES Restaurante(ID_Restaurante),
	

);



CREATE TABLE Prato(

	ID_Prato							INTEGER					NOT NULL	IDENTITY(1,1),
	Tipo_Prato							NVARCHAR(40)				NOT NULL,
	Descricao_Default					NVARCHAR(300)            NOT NULL,
	Foto_Default						NVARCHAR(500)			NOT NULL,

	PRIMARY KEY(ID_Prato),
	

);

CREATE TABLE Guardar_Cliente_Prato_Favorito(

	ID_Cliente_Prato_Favorito			INTEGER					NOT NULL	IDENTITY(1,1),
	ID_Cliente							INTEGER					NOT NULL,
	ID_Prato							INTEGER					NOT NULL,
	

	PRIMARY KEY(ID_Cliente_Prato_Favorito,ID_Cliente, ID_Prato),
	FOREIGN KEY(ID_Cliente) REFERENCES Clientes(ID_Cliente),
	FOREIGN KEY(ID_Prato) REFERENCES Prato(ID_Prato),
	
);

CREATE TABLE Guardar_Cliente_Restaurante_Favorito(

	ID_Cliente_Restaurante_Favorito		INTEGER					NOT NULL	IDENTITY(1,1),
	ID_Cliente							INTEGER					NOT NULL,
	ID_Restaurante						INTEGER					NOT NULL,
	

	PRIMARY KEY(ID_Cliente_Restaurante_Favorito,ID_Cliente, ID_Restaurante),
	FOREIGN KEY(ID_Cliente) REFERENCES Clientes(ID_Cliente),
	FOREIGN KEY(ID_Restaurante) REFERENCES Restaurante(ID_Restaurante),
	
);

CREATE TABLE Agendar_Prato(
	ID_Agendamento					INTEGER			NOT NULL	IDENTITY(1,1),
	Data_Marcacao					DATETIME		NOT NULL 	DEFAULT GETDATE(),
	Data_Do_Agendamento				DATETIME		NOT NULL 	DEFAULT GETDATE(),
	ID_Restaurante					INTEGER			NOT NULL,
	ID_Prato						INTEGER			NOT NULL,
	Descricao_Extra					NVARCHAR(300)    NOT NULL,
	Foto_Extra						NVARCHAR(500)	NOT NULL,
	Preco							INTEGER			NOT NULL,
	Destaque						BIT				NOT NULL	DEFAULT 0,
	
	
	PRIMARY KEY(ID_Agendamento, Data_Marcacao, Data_Do_Agendamento,ID_Restaurante,	ID_Prato),
	FOREIGN KEY(ID_Restaurante) REFERENCES Restaurante(ID_Restaurante),
	FOREIGN KEY(ID_Prato) REFERENCES Prato(ID_Prato),

	
);


