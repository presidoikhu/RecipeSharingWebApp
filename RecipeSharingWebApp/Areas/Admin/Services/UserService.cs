using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RecipesSharingWebApp.Areas.Admin.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UtilityService _utilityService;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            UtilityService utilityService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _utilityService = utilityService;
        }

        public Task<string> GetCurrentUserId(ClaimsPrincipal principal)
        {
            var userId = _userManager.GetUserId(principal);
            return Task.FromResult(userId);
        }

        public async Task<bool> LoginUser(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                   return false;
            }

            var username = user.UserName;
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password, string role = "User")
        {
            user.Id = Guid.NewGuid().ToString();
            user.UserRoleId = "2";

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                return result;
            } 
            return result;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);

            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension != ".jpeg" && fileExtension != ".jpg" && fileExtension != ".gif" && fileExtension != ".png" && fileExtension != ".Avif")
            {
                return string.Empty;
            }

            var profileImagesPath = _utilityService.GetProfileImagesRootPath();

            var uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yymmssfff")}{fileExtension}";

            var filePath = Path.Combine(profileImagesPath, uniqueFileName);
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }
    }

}
