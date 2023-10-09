using FullStackAuth_WebAPI.Configuration;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackAuth_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<ImageUpload> Image { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Reviews { get; set; }
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
                .HasMany(u => u.ViewedAnimeList)
                .WithOne(vl => vl.User)
                .HasForeignKey(vl => vl.UserId);

            modelBuilder.Entity<Friend>().HasKey(f => f.Id);
            modelBuilder.Entity<Friend>().HasIndex(f => new { f.User1Id, f.User2Id }).IsUnique();
            modelBuilder.Entity<Friend>().HasOne(f => f.User1).WithMany().HasForeignKey(f => f.User1Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Friend>().HasOne(f => f.User2).WithMany().HasForeignKey(f => f.User2Id).OnDelete(DeleteBehavior.Cascade);

  
        }
    }
}
