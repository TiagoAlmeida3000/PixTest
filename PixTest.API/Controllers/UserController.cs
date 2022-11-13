using Microsoft.AspNetCore.Mvc;
using PixTest.Application.DTOs;
using PixTest.Application.Interfaces;
using System.Threading.Tasks;

namespace PixTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {        
            return Ok(await _userService.PostUser(userDTO));
        }

        [HttpGet("ConsultarCliente/{id}")]
        public async Task<ActionResult> Details(int id)
        {
             return Ok(await _userService.UserDetails(id));     
        }

    }
}
