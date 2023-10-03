using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        public int AnimeId { get; set; }

        public string Text { get; set; }

        public double Rating { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
