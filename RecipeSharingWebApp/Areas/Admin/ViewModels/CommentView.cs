namespace RecipeSharingWebApp.Areas.Admin.ViewModels
{
    public class CommentView
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CommentBody { get; set; }
        public string CommentTitle { get; set; }
        public string UserId { get; set; }
        public string RecipeId { get; set; }
    }
}
