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
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IEnumerable<UsuarioDomain> Get()
        {

            return _usuarioRepository.ListarUsuario();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoEstudio)
        {

            _usuarioRepository.Cadastrar(novoEstudio);


            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario encontrado");
            }

            return Ok(usuarioBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            _usuarioRepository.Deletar(id);


            return Ok("Estúdio deletado");
        }
    }
}