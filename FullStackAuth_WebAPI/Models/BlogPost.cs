using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Foreign key to link the blog post to a user
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }
    }

    public class BlogPostDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}