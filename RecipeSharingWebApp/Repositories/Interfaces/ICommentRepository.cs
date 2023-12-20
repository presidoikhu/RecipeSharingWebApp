using RecipesSharingWebApp.Areas.Admin.Models;

namespace CodebitsBlog.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllComments();
        Task<Comment> GetCommentById(string id);
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment);
        Task DeleteComment(string id);
    }
}
