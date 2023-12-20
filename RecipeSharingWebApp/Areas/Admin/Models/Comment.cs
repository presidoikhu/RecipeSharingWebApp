using RecipesSharingWebApp.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.Models
{
    public class Comment : BaseEntity
    {
        public string? CommentBody { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public string? RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
