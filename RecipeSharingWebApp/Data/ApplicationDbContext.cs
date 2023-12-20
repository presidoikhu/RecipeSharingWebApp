using RecipesSharingWebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingWebApp.Areas.Admin.Models;

namespace RecipesSharingWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }, new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            });

            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    FirstName = "James",
                    LastName = "Bond",
                    Email = "james@gmail.com",
                    NormalizedEmail = "JAMES@GMAIL.COM",
                    Id = "1",
                    UserName = "james@gmail.com",
                    NormalizedUserName = "JAMES@GMAIL.COM",
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "James@123"),
                    ProfilePictureUrl = "",
                    UserRoleId = "1",
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });
        }
    }
}
