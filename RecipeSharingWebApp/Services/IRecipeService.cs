using Microsoft.Extensions.Hosting;
using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.ViewModels;

namespace RecipesSharingWebApp.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeMainViewModel>> GetAllRecipes(int pageNumber, int pageSize = 25);
        Task<IEnumerable<RecipeMainViewModel>> GetRecentRecipes(int numOfRecipes = 4);
        Task<IEnumerable<RecipeMainViewModel>> GetHeroSliderRecipes(int numOfRecipes = 4);
        Task<IEnumerable<RecipeMainViewModel>> GetRecipesByCategoryName(string categoryName, int numOfRecipes = 7);
        Task<RecipeMainViewModel> GetRecipeById(string id);
        Task<Recipe> CreateRecipe(Recipe recipe);
        public  Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(string id);

        Task<IEnumerable<RecipeMainViewModel>> GetCategory(string categoryName, int numOfRecipes = 7);


    }
}
