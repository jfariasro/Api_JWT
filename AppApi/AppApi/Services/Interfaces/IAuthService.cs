using AppApi.DTOs;
using AppApi.Models;

namespace AppApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegistrarUsuario(Usuario usuario);

        Task<string> Login(UsuarioDTO usuarioDTO);
    }
}
