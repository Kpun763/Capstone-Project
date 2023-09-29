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

        [ForeignKey("Reviews")]
        public int ReviewId { get; set; }
        public Reviews Reviews { get; set; }

        [ForeignKey("ViewedList")]
        public int ViewedListId { get; set; }
        public ViewedList ViewedList { get; set; }

        [ForeignKey("Gallery")]
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        [ForeignKey("FriendsList")]
        public int FriendsListId { get; set; }
        public FriendsList FriendsList { get; set; }
    }
}
