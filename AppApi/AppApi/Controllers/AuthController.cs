using AppApi.DTOs;
using AppApi.Models;
using AppApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Inicio")]
        public async Task<string> Inicio([FromBody] UsuarioDTO usuarioDTO)
        {
            var result = await _service.Login(usuarioDTO);
            return result;
        }

        [HttpPost()]
        [Route("Registro")]
        public async Task<Usuario> Registrar([FromBody] Usuario usuario)
        {
            var user = await _service.RegistrarUsuario(usuario);
            return user;
        }
    }
}
