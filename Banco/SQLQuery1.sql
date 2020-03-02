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


insert into TipoUsuario(Titulo)
values ('Administrador'),
	   ('Usuario')

insert into Usuario(Email, Senha, IdTipoUsuario)
values ('anaotaria@gmail.com', 'ana123', 1),
	   ('nicolasbobao@gmail.com', 'nicolas123', 2)

insert into Estudio(EstudioNome)
values ('Rockstar'),
	   ('Blizzard')

insert into Jogos(NomeJogo, Descricao, Preco,DataLanc , IdEstudio)
values ('GTA San Andreas', 'mate velhas a vontade, n�o � crime', 5.90,'26-10-2004', 1),
	   ('Overwatch', 'im already tracer', 59.90, '27-10-2015', 2)


select * from Jogos