using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class UserHomepage
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int UserContentId { get; set; }
        public UserContent UserContent { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Image> Gallery { get; set; } = new List<Image>();
    }
}

