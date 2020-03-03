using SenaiInLock.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarUsuario();

        void Cadastrar(UsuarioDomain novoUsuario);

        void Deletar(int id);

        UsuarioDomain BuscarPorId (int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
