using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Data;
using RecipesSharingWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RecipesSharingWebApp.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecipeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task DeleteRecipe(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var recipe = _dbContext.Recipes.FirstOrDefault(p => p.Id == id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
            }
        }

        public async Task<IList<Recipe>> GetAllRecipes()
        {
            var recipes = _dbContext.Recipes.Include(p => p.Category).Include(p => p.User).ToList();
            return recipes;
        }

        public async Task<Recipe> GetRecipeById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Recipes.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
         
            _dbContext.Recipes.Update(recipe);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task FavoriteRecipe(Recipe recipe)
        {

            
            await _dbContext.SaveChangesAsync();

        }
    }
}
