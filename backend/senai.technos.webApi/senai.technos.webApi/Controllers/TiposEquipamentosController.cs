using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class TiposEquipamentosController : ControllerBase
    {
        private ITipoEquipamentoRepository _tipoequipamentoRepository { get; set; }

        public TiposEquipamentosController()
        {
            _tipoequipamentoRepository = new TipoEquipamentoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de equipamentos existentes
        /// </summary>
        /// <returns>Uma lista de tipos de equipamentos</returns>
        [HttpGet]
        public IActionResult Read()
        {
            try
            {
                return Ok(_tipoequipamentoRepository.Read());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
