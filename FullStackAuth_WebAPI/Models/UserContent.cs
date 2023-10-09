using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class UserContent
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<ViewedList> ViewedLists { get; set; }
        public ICollection<ImageUpload> Gallery { get; set; }

        public ICollection<Friend> FriendsAsUser1 { get; set; }
        public ICollection<Friend> FriendsAsUser2 { get; set; }
    }
}
