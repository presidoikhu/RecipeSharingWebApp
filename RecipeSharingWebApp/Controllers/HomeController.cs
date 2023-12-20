using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Areas.Admin.Services;
using RecipesSharingWebApp.Areas.Admin.ViewModels;
using RecipesSharingWebApp.Data;
using RecipesSharingWebApp.Helpers;
using RecipesSharingWebApp.Services;
using RecipesSharingWebApp.ViewModels;
using System.Security.Claims;
using System.Security.Principal;

namespace RecipesSharingPlatform.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;
        private readonly UtilityService _utilityService;
        private readonly IRecipeService _recipeService; 

        public HomeController(ApplicationDbContext dbContext, UtilityService utilityService, IRecipeService recipeService)

        {
           
            _dbContext = dbContext;
            _utilityService = utilityService;
            _recipeService = recipeService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var recipes = _dbContext.Recipes;
            var r = recipes.ToList().Take(3);
            var recipe = new RecipeMainViewModel
            {
                Recipes = r,
            };
            return View(recipe);
        }

        public IActionResult about()
        {
            return View();
        }




        public IActionResult create()
        {
            return View();
        }


        public IActionResult details(string id)
        {
            var rcipe = _dbContext.Recipes;
            var recipe = rcipe.FirstOrDefault(x => x.Id == id);            
            return View(recipe);
        }

        


        public IActionResult contact()
        {
            return View();
        }


        
        public IActionResult recipes()
        {
            var recipes = _dbContext.Recipes;
            var rec = new RecipeMainViewModel { Recipes = recipes };
            return View(rec);
        }
        public IActionResult Favorites(string id)
        {
            var fav = _dbContext.Favorites;
            var userFav = fav.Where(x => x.UserId == id).ToList();
            return View(userFav);
        }



        public async Task<IActionResult> AddRecipe()
        {
            var categories = _dbContext.Categories;

            var model = new RecipeViewModel
            {
                Categories = categories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var coverImageUrl = "";

                if (model.CoverImage != null)
                {
                    coverImageUrl = await _userService.UploadImage(model.CoverImage);
                }

                var recipe = new Recipe
                {
                    Title = _utilityService.SanitizeHtml(model.Title),
                    Description = _utilityService.SanitizeHtml(model.Description),
                    Instruction = _utilityService.SanitizeHtml(model.Instruction),
                    TimeSpan = _utilityService.SanitizeHtml(model.TimeSpan),
                    CategoryId = model.CategoryId,
                    UserId = model.UserId,
                    CoverImageUrl = coverImageUrl,
                    IsFeatured = model.IsFeatured

                };

                await _dbContext.Recipes.AddAsync(recipe);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("index", "home", new { Area = "" });
            }
            return View();
        }


    


        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var recipes = _dbContext.Recipes.Where(r => r.Title.Contains(searchString)).ToList();

            var viewModel = new RecipeMainViewModel
            {
                SearchString = searchString,
                Results = recipes
            };

            return View(viewModel); 
        }

       


    }
}

