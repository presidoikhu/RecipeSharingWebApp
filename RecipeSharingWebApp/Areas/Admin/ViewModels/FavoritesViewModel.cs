namespace RecipesSharingWebApp.Areas.User.ViewModels
{
    public class FavoritesViewModel
    {
        public List<Favorite>? Favorites { get; set; }
    }

    public class Favorite
    {
        public string? Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
