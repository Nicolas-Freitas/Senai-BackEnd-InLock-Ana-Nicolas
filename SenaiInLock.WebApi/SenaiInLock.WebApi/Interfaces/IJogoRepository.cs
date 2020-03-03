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
    

        void Deletar (int id);

        JogosDomain BuscarPorId (int id);
    }
}
