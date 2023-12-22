using RecipesSharingWebApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.Models
{
    public class Comment : BaseEntity
    {
        
        public string? CommentBody { get; set; }
        public string? UserId { get; set; }
        
        public string? RecipeId { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public string? CommentTitle { get;  set; }
    }
}
