namespace RecipeSharingWebApp.Areas.Admin.Models
{
    public class Favorite
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }

        public string? RecipeId {  get; set; }

        public string? RecipeTitle { get; set;}

    }
}
