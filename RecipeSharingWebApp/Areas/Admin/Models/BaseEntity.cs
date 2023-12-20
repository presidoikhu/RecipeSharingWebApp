using System.ComponentModel.DataAnnotations;

namespace RecipesSharingWebApp.Areas.Admin.Models
{
    public class BaseEntity
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
