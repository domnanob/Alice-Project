using System.ComponentModel.DataAnnotations;

namespace AliceProject.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required twice")]
        public string? PasswordAgain { get; set; }
    }
}
