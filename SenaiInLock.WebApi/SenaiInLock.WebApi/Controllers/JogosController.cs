using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiInLock.WebApi.Domain;
using SenaiInLock.WebApi.Interfaces;
using SenaiInLock.WebApi.Repository;

namespace SenaiInLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.ListarJogos());
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {

            _jogoRepository.Cadastrar(novoJogo);


            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            JogosDomain filmeBuscado = _jogoRepository.BuscarPorId(id);


            if (filmeBuscado != null)
            {

                _jogoRepository.Deletar(id);


                return Ok($"O filme {id} foi deletado com sucesso!");
            }


            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                return Ok(jogoBuscado);
            }

            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }



    }
}