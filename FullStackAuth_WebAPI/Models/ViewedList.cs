using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class ViewedList
    {
        [Key]
        public int Id { get; set; }

        public int AnimeId { get; set; }

        public string Text { get; set; }

        public bool WasViewed { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
