using SenaiInLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarEstudio();

        void Cadastrar(EstudioDomain novoEstudio);

        void Atualizar(int id,EstudioDomain Estudio);

        void Deletar(int id);

        void BuscarPorId(int id);
    }
}
