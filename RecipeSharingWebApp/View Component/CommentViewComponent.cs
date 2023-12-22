using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeSharingWebApp.Areas.Admin.ViewModels;
using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Data;
using RecipesSharingWebApp.Helpers;
using RecipesSharingWebApp.Services;
using System.Collections.Specialized;

namespace RecipeSharingWebApp.View_Component
{
    [ViewComponent(Name = "Comment")]
    public class CommentViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public CommentViewComponent(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;

        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);

            var recipeComments = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
            var model = new CommentView
            {
                Id = id,
                Title = recipeComments.Title,
                UserId = loggedInUser.Id
            };

            return View(model);
        }
    }
}
