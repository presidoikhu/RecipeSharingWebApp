using Microsoft.AspNetCore.Identity;

namespace RecipesSharingWebApp.Areas.Admin.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            Recipes = new List<Recipe>();
            Comments = new List<Comment>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public IdentityRole? UserRole { get; set; }
        public string? UserRoleId { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
