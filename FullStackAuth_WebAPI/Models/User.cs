using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ViewedList> ViewedAnimeList { get; set; }
        public ICollection<ImageUpload> Gallery { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
        public string FriendId { get; set; }
        public User Friend { get; set; } 
    }
}
