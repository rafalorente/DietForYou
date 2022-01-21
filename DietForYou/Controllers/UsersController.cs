using DietForYou.Data;
using DietForYou.Models;
using DietForYou.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DietForYou.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Users>>> GetUsers()
        {
            try
            {
                var users = await _usersService.GetUsers();
                return Ok(users);
            }
            catch 
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("UsersPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Users>>> GetUsersByNome([FromQuery] string nome)
        {
            try
            {
                var users = await _usersService.GetUsersByNome(nome);

                if (users == null)
                {
                    return NotFound($"Não existem usuários com o critério");
                }

                return Ok(users);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name ="GetUsers")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            try
            {
                var users = await _usersService.GetUsers(id);
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
        public async Task<ActionResult> CreateUser(Users user)
        {
            try
            {
                await _usersService.CreateUsers(user);

                return CreatedAtRoute(nameof(GetUsers), new { id = user.idUsuario }, user);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditUsers(int id, [FromBody] Users user)
        {
            try
            {
                if (user.idUsuario == id)
                {
                    await _usersService.UpdateUsers(user);
                    return Ok($"O usuário com o id = {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados Inválidos");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            try
            {
                var user = await _usersService.GetUsers(id);
                if (user != null)
                {
                    await _usersService.DeleteUsers(user);
                    return Ok($"O usuário com o id = {id} foi excluído com sucesso!");

                }
                else
                {
                    return NotFound($"O usuário com o id = {id} não foi encontrado!");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

    }
}
