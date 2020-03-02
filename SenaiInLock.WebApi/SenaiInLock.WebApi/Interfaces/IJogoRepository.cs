using SenaiInLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogosDomain> ListarJogos();

        void Cadastrar (JogosDomain novoJogo);

        void Atualizar (JogosDomain jogo);

        void Deletar (int id);

        void BuscarPorId (int id);
    }
}
