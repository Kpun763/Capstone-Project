using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace FullStackAuth_WebAPI.Models
{
    public class Notifications
    {
        [Key]
        public int Id { get; set; }

        public bool IsRead { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
