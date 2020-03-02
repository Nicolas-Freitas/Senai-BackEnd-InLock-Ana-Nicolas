select * from Usuario

select * from Estudio

select * from Jogos

select IdJogo, NomeJogo, Estudio.EstudioNome,Preco, DataLanc, Estudio.IdEstudio from Jogos
inner join Estudio on Jogos.IdJogo = Estudio.IdEstudio;

select IdUsuario, Email, Senha, TipoUsuario.Titulo from Usuario
inner join TipoUsuario on Usuario.IdUsuario = TipoUsuario.IdTipoUsuario
where Email like 'anaotaria@gmail.com';

select IdJogo, NomeJogo, Estudio.EstudioNome,Preco, DataLanc, Estudio.IdEstudio from Jogos
inner join Estudio on Jogos.IdJogo = Estudio.IdEstudio
where IdJogo like 2;

select * from Estudio
where IdEstudio like 1;