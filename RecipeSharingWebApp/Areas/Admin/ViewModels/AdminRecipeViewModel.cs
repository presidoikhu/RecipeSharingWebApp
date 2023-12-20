using RecipesSharingWebApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.ViewModels
{
    public class AdminRecipeViewModel
    {
       

      
        public IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>();
        
    }
}
