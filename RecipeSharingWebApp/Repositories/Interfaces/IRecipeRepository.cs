using RecipesSharingWebApp.Areas.Admin.Models;

namespace RecipesSharingWebApp.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IList<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(string id);
        Task<Recipe> CreateRecipe(Recipe recipe);
        public  Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(string id);
    }
}
