using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppApi.Models
{
    public class Tipo
    {
        [Key]
        [JsonPropertyName("idtipo")]
        public int Idtipo { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(500)]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = null!;
    }
}
