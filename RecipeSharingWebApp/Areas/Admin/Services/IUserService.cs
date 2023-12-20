using RecipesSharingWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RecipesSharingWebApp.Areas.Admin.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(ApplicationUser user, string password, string role = "User");
        Task<bool> LoginUser(string email, string password, bool rememberMe);
        Task LogoutUser();

        Task<string> UploadImage(IFormFile file);
        Task<string> GetCurrentUserId(ClaimsPrincipal principal);
    }
}
