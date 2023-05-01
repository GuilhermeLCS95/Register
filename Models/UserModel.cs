using Register.Enums;
using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Insert a valid e-mail.")]
        public string Email { get; set; }
        public ProfileEnum Profile { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
