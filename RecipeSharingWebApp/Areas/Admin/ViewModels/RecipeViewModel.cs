using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Areas.User.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.ViewModels
{
    public class RecipeViewModel
    {
        [Required(ErrorMessage = "Please enter a post title")]
        [MinLength(3, ErrorMessage = "Post title must be at least 3 characters long")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter a post Description")]
        [MinLength(10, ErrorMessage = "Post Description must be at least 10 characters long")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter a Recipe Instruction")]
        [MinLength(10, ErrorMessage = "Recipe Instruction must be at least 10 characters long")]
        public string? Instruction { get; set; }

        [Required(ErrorMessage = "Please enter a Time needs")]
        [MinLength(2, ErrorMessage = "Post Description must be at least 2 characters long")]
        public string? TimeSpan { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public string? CategoryId { get; set; }
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public IFormFile? CoverImage { get; set; }
        
        public bool? IsFeatured { get; set; }

        public IEnumerable<Favorite> Favorites {  get; set; } = new List<Favorite>();
    }
}
