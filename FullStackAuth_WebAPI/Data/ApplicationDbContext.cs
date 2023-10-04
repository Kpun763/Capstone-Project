using FullStackAuth_WebAPI.Configuration;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<FriendsList> FriendsList { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<UserContent> UserContents { get; set; }
        public DbSet<UserHomepage> UserHomepages { get; set; }
        public DbSet<ViewedList> ViewedLists { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public ApplicationDbContext(DbContextOptions options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
          .HasMany(u => u.ViewedAnimeList) // One user has many viewed anime entries
          .WithOne(vl => vl.User) // Each viewed anime entry belongs to one user
          .HasForeignKey(vl => vl.UserId);


            modelBuilder.ApplyConfiguration(new RolesConfiguration());


        }
    }
}
