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
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private IEquipamentoRepository _equipamentoRepository { get; set; }

        public EquipamentosController()
        {
            _equipamentoRepository = new EquipamentoRepository();
        }

        /// <summary>
        /// lista todos os equipamentos
        /// </summary>
        /// <returns>retorna a lista de todos os equipamentos</returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_equipamentoRepository.List());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// cria um novo equipamento
        /// </summary>
        /// <param name="novoEquipamento">informações do novo equipamento que será criado</param>

        [HttpPost]

        public IActionResult Post(Equipamento novoEquipamento)
        {
            try
            {
                _equipamentoRepository.Create(novoEquipamento);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// atualiza um determinado equipamento
        /// </summary>
        /// <param name="equipamentoAtualizado">informações do equipamnto que será atualizado</param>
        /// <param name="id">id do equipamento que será passado</param>

        [HttpPut("{id}")]
        
        public IActionResult Put(int id, Equipamento equipamentoAtualizado)
        {
            try
            {
                _equipamentoRepository.Update(id, equipamentoAtualizado);
                        
                return StatusCode(204);

            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// apaga um equimanto
        /// </summary>
        /// <param name="id">id que será passado</param>

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _equipamentoRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}

