using RecipesSharingWebApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Please enter a category name")]
        [MinLength(3, ErrorMessage = "Category name must be at least 3 characters long")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a category description")]
        [MinLength(3, ErrorMessage = "Category description must be at least 3 characters long")]
        public string? Description { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
