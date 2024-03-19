using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "se necesita el nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "proporcione una contraseña")]
        public string Password { get; set; }

        public ICollection<Contact>? Contacts { get; set;}
    }
}
