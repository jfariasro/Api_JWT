using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppApi.Models
{
    public class Empleado
    {
        [Key]
        [JsonPropertyName("idempleado")]
        public int Idempleado { get; set; }

        [Required]
        [JsonPropertyName("razonsocial")]
        public string Razonsocial { get; set; } = null!;

        [Required]
        [JsonPropertyName("idtipo")]
        public Tipo? Tipo { get; set; }

        [Required]
        [JsonPropertyName("edad")]
        public int Edad { get; set; }

        [Required]
        [JsonPropertyName("salario")]
        public decimal Salario { get; set; }
    }
}
