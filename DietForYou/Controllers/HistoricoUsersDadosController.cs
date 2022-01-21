using DietForYou.Models;
using DietForYou.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietForYou.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoUsersDadosController : ControllerBase
    {

        private IHistoricoUsersDadosService _historicoDadosService;

        public HistoricoUsersDadosController(IHistoricoUsersDadosService historicoDadosService)
        {
            _historicoDadosService = historicoDadosService;
        }

        [HttpGet("{id:int}", Name = "GetHistoricoUserDados")]
        public async Task<ActionResult<HistoricoUserDados>> GetHistoricoUserDados(int id)
        {
            try
            {
                var users = await _historicoDadosService.GetHistoricoUserDados(id);
                if (users == null)
                {
                    return NotFound($"Não existe usuário com id = {id}");
                }

                return Ok(users);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }


        [HttpPost]
        public async Task<ActionResult> InsertHistoricoUserDados(HistoricoUsersDados historicoUserDados)
        {
            try 
            { 

                await _historicoDadosService.CalculoTmb(historicoUserDados);

                return CreatedAtRoute(nameof(GetHistoricoUserDados), new { id = historicoUserDados.IdHistoricoUsersDados }, historicoUserDados);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

    }
}
