using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Insert a valid e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage ="Insert a valid phone number.")]
        public string Phone { get; set; }
    }
}
