using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public int TypeID { get; set; }


    }
}
