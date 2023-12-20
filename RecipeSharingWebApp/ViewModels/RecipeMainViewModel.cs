using RecipesSharingWebApp.Areas.Admin.Models;

namespace RecipesSharingWebApp.ViewModels
{
    public class RecipeMainViewModel
    {
        public RecipeMainViewModel()
        {
            Recipes = new List<Recipe>();
        }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? RecipeDate { get; set; }
        public string? Category { get; set; }
        public string? Instruction { get; set; }
        public string? TimeSpan {  get; set; }
        public string? RecipeId { get; set; }

        public bool? IsFavorite {  get; set; }

        public IEnumerable<Recipe> Recipes { get; set;} = new List<Recipe>();
       
        public string? SearchString {  get; set; }

        public List<Recipe> Results { get; set; } = new List<Recipe>();



    }
}
