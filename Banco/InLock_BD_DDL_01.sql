create database InLock;
go

use  InLock;

create table TipoUsuario(
IdTipoUsuario int primary key identity,
Titulo varchar(200)
);
go

create table Usuario(
IdUsuario int primary key identity,
Email varchar (200),
Senha varchar(200),
IdTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario)
);
go 

create table Estudio(
IdEstudio int primary key identity,
EstudioNome varchar(200)
)

create table Jogos(
IdJogo  int primary key identity,
NomeJogo varchar(200),
Descricao varchar(200),
Preco float,
DataLanc date, 
IdEstudio int foreign key references Estudio(IdEstudio)
);
go 