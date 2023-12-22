using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Areas.Admin.Services;
using RecipesSharingWebApp.Areas.Admin.ViewModels;
using RecipesSharingWebApp.Data;
using RecipesSharingWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesSharingWebApp.ViewModels;
using RecipesSharingWebApp.Services;
using System.Security.Claims;
using RecipeSharingWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using RecipeSharingWebApp.Areas.Admin.ViewModels;

namespace RecipesSharingWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
	public class DashboardController : Controller
	{
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;
        private readonly UtilityService _utilityService;
        private readonly IRecipeService _recipeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IUserService userService,
            ApplicationDbContext dbContext,
            UtilityService utilityService,IRecipeService recipeService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _dbContext = dbContext;
            _utilityService = utilityService;
            _recipeService = recipeService;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
		{           
			return View();
		}

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
           ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
           if (ModelState.IsValid)
            {
                var returnUrl = model.ReturnUrl ?? Url.Content("/admin/dashboard");

                var result = await _userService.LoginUser(model.Username, model.Password, model.RememberMe);

               if (result)
                {
                    //return LocalRedirect(returnUrl);
                    return RedirectToAction("LandingPage", "home", new {Area = ""});
                }
               else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
           return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutUser();
            return RedirectToAction("Login", "Dashboard");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profilePictureUrl = await _userService.UploadImage(model.UserProfilePicture);

                var applicationUser = new ApplicationUser
                {
                    Email = model.EmailAddress,
                    UserName = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName  = model.LastName,
                    ProfilePictureUrl = profilePictureUrl ?? "" 
                };

                var  result = await _userService.RegisterUser(applicationUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Dashboard");
                } 

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Recipe(AdminRecipeViewModel model)
        {
           model.Recipes = _dbContext.Recipes;
            return View(model);
        }

     

        public async Task<IActionResult> AddRecipe()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            var model = new RecipeViewModel
            {
               Categories = categories,
                UserId = await _userService.GetCurrentUserId(User)
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

               return RedirectToAction("Index", "Home", new {Area = ""});
            }
            return View();
        }

        //public async Task<IActionResult> Error()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Category", "Dashboard");
            }
            return View(model);
        }

        public IActionResult Comment()
        {
            var comments = _dbContext.Comments.ToList();
            return View(comments);

        }
        public async Task<IActionResult> Profile()

        {
            return View();
        }
        public async Task<IActionResult> Category(CategoryViewModel model)
        {
            model.Categories = _dbContext.Categories;
            return View(model);


        }

        public async Task<IActionResult> EditProfile()

        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users()

        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUsers()
        {
            return RedirectToAction("Register");
        }

        public async Task<IActionResult> DeleteRecipe(Recipe recipe)
        {
            return View(recipe);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            var recipe = await _dbContext.Recipes.FindAsync(id);

            if (recipe == null)
            {
               return RedirectToAction("Recipe", "Dashboard");
            }

            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Recipe", "Dashboard");
        }

        public async Task<IActionResult> EditRecipe(string id)
        {
            var recipe = _dbContext.Recipes.Find(id);
            return View(recipe);
        }

         [HttpPost]
        public async Task<IActionResult> EditRecipe(Recipe model)
        {
            if (ModelState.IsValid)
            { 
                await _recipeService.UpdateRecipe(model);
                 

                return RedirectToAction("Recipe", "Dashboard");
            }
            return View();
        }


        public async Task<IActionResult> Favorite()
        {
            return View();
        }


        public async Task<IActionResult> Button_click(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var model = new Favorite
            {
                RecipeId = id,
                UserId = loggedInUser.Id
            };
            var existingFavorite = _dbContext.Favorites.FirstOrDefault(x => x.UserId == model.UserId && x.RecipeId == model.RecipeId);
            if (existingFavorite != null)
            {
                _dbContext.Favorites.Remove(existingFavorite);
            }
            else
            {
                var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
                model.Id = Guid.NewGuid().ToString();
                model.RecipeTitle = recipe.Title;
                _dbContext.Favorites.Add(model);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("index", "home", new { Area = "" });
        }




    }

}



    

