using RecipesSharingWebApp.Areas.Admin.Models;

namespace RecipesSharingWebApp.Areas.Admin.Models
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            Comments = new List<Comment>();
        }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? TimeSpan { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
       
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public bool? IsFeatured { get; set; }

        public bool IsFavorite { get; set; }

        public string? Instruction {  get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List <Category> ();
    }
}
