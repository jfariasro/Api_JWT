using AppApi.Context;
using AppApi.DTOs;
using AppApi.Models;
using AppApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppApiContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string?> Login(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Correo != null && usuarioDTO.Password != null)
            {
                var obj = await _context.Usuario.SingleOrDefaultAsync(u => u.Correo == usuarioDTO.Correo
                && usuarioDTO.Password == u.Password
                );

                if (obj != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Idusuario", obj.Idusuario.ToString()),
                        new Claim("Nombreusuario", obj.Nombre),
                        new Claim("Correo", obj.Correo)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            var obj = await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }
    }
}
