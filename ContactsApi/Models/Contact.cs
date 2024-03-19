using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactsApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proporcione un nombre para el contacto")]
        public string Name { get; set; }    
        public string? Email { get; set; }
        [Required(ErrorMessage = "proporcione un numero de telefono")]
        public string Phone { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
