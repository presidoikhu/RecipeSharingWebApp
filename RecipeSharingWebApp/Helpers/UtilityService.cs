using Ganss.Xss;

namespace RecipesSharingWebApp.Helpers
{
    public class UtilityService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UtilityService> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UtilityService(IConfiguration configuration, 
            ILogger<UtilityService> logger,
            IWebHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public string GetProfileImagesRootPath(bool operationType = true)
        {
            var imagesPath = _configuration.GetValue<string>("ProfileImagesFolder");

            if (string.IsNullOrEmpty(imagesPath))
            {
                imagesPath = "profile-images";
            }

            var wwwRootPath = _hostEnvironment.WebRootPath;

            var profileImagesPath = Path.Combine(wwwRootPath, imagesPath);

            if (!Directory.Exists(profileImagesPath))
            {
                Directory.CreateDirectory(profileImagesPath);
            }

            return operationType ? profileImagesPath : "/" + imagesPath;
        }

        public string SanitizeHtml(string content)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(content);
        }
    }
}
