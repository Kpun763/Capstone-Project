using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public char Status { get; set; }

        [ForeignKey("User")]
        public string User1Id { get; set; }
        public User User1 { get; set; }

        [ForeignKey("User")]
        public string User2Id { get; set; }
        public User User2 { get; set; }
       
    }

    public class SendInRequest
    {
        public string User1Id { get; set; }
        public string User2Id { get; set; }

        public char Status { get; set; }
    }
}
