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
values ('GTA San Andreas', 'mate velhas a vontade, não é crime', 5.90,'26-10-2004', 1),
	   ('Overwatch', 'im already tracer', 59.90, '27-10-2015', 2)