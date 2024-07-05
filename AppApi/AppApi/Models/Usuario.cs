using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppApi.Models
{
    public class Usuario
    {
        [Key]
        [JsonPropertyName("idusuario")]
        public int Idusuario { get; set; }

        [Required]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

        [Required]
        [JsonPropertyName("correo")]
        public string Correo { get; set; } = null!;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
