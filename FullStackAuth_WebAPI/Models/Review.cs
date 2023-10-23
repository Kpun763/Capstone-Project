using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int AnimeId { get; set; }

        [MaxLength(500)] // Set an appropriate maximum length for the review text
        public string Text { get; set; }

        public double Rating { get; set; }

        public DateTime ReviewDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
