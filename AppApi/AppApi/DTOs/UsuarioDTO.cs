using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppApi.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        [JsonPropertyName("correo")]
        public string Correo { get; set; } = null!;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
