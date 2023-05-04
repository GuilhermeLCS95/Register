using Register.Enums;
using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class UserNoPasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Insert a valid e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Profile is required.")]
        public ProfileEnum? Profile { get; set; }

    }
}
