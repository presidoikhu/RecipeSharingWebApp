using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Repositories.Interfaces;
using RecipesSharingWebApp.Services;
using RecipesSharingWebApp.ViewModels;

namespace RecipeSharingWebApp.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            return await _recipeRepository.CreateRecipe(recipe);
        }

        public async Task DeleteRecipe(string id)
        {
            await _recipeRepository.DeleteRecipe(id);
        }

        public async Task<IEnumerable<RecipeMainViewModel>> GetAllRecipes(int pageNumber, int pageSize = 25)
        {
            var recipe = await _recipeRepository.GetAllRecipes();
            return recipe.OrderByDescending(x => x.CreatedOn).Select(recipe => new RecipeMainViewModel
            {
                RecipeId = recipe.Id,
                Title = recipe.Title,

                Description = recipe.Description,
                Category = recipe.Category.Name,
                CoverImageUrl = recipe.CoverImageUrl,
                TimeSpan = recipe.TimeSpan,
                RecipeDate = recipe.CreatedOn.ToString(),
                Instruction = recipe.Instruction.Substring(0, 60)
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public Task<IEnumerable<RecipeMainViewModel>> GetCategory(string categoryName, int numOfRecipes = 7)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecipeMainViewModel>> GetHeroSliderRecipes(int size = 4)
        {
            var post = await _recipeRepository.GetAllRecipes();

            return post.Where(x => x.IsFeatured == true).Take(size).Select(y => new RecipeMainViewModel
            {

                RecipeId = y.Id,
                Title = y.Title,

                Description = y.Description,
                Category = y.Category.Name,
                CoverImageUrl = y.CoverImageUrl,

                RecipeDate = y.CreatedOn.ToString(),
                Instruction = y.Instruction
            }).ToList();
        }

        public Task<RecipeMainViewModel> GetRecipeById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecipeMainViewModel>> GetRecipesByCategoryName(string category, int numOfRecipes = 7)
        {
            var post = await _recipeRepository.GetAllRecipes();
            return post.Where(x => x.Category.Name.ToLower() == category.ToLower()).Take(numOfRecipes).Select(y => new RecipeMainViewModel
            {
                RecipeId = y.Id,
                Title = y.Title,

                Description = y.Description,
                Category = y.Category.Name,
                CoverImageUrl = y.CoverImageUrl,

                RecipeDate = y.CreatedOn.ToString(),
                Instruction = y.Instruction.Substring(0, 60)
            }).ToList();
        }

        public Task<IEnumerable<RecipeMainViewModel>> GetRecentRecipe(int size = 4)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeMainViewModel>> GetRecentRecipes(int numOfPosts = 4)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            await _recipeRepository.UpdateRecipe(recipe);

        }

    }
}
