using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.technos.webApi.Domains;
using senai.technos.webApi.Interfaces;
using senai.technos.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.technos.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private ISalaRepository _salaRepository { get; set; }

        public SalasController()
        {
            _salaRepository = new SalaRepository();
        }

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">Objeto com as informações da nova sala</param>
        /// <returns>Status code 201</returns>
        [HttpPost]
        public IActionResult Post (Sala novaSala)
        {
            _salaRepository.Create(novaSala);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todas as salas existentes
        /// </summary>
        /// <returns>Uma lista de salas</returns>
        [HttpGet]
        public IActionResult Read ()
        {
            try
            {
                return Ok(_salaRepository.Read());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id,Sala salaAtualizada)
        {
            try
            {
                _salaRepository.Update(id, salaAtualizada);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salaRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
