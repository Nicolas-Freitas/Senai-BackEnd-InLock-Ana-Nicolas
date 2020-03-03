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
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }


        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IEnumerable<EstudioDomain> Get()
        {
            
            return _estudioRepository.ListarEstudio();
        }

          
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            
            _estudioRepository.Cadastrar(novoEstudio);

          
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado");
            }

            return Ok(estudioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {

                return NotFound
                    (
                        new
                        {
                            mensagem = "Estúdio não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            
            _estudioRepository.Deletar(id);

            
            return Ok("Estúdio deletado");
        }
    }
}