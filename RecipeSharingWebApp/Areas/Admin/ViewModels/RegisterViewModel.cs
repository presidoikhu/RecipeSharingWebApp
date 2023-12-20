using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
        public string? UserRole { get; set; }
        public IFormFile? UserProfilePicture { get; set; }
    }
}
