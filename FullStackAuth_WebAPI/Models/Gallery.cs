using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }

        public ICollection<ImageUrl> ImageUrls { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }

    public class GalleryDTO
    {
        public List<IFormFile> Images { get; set; }

    }
    public class ImageUrl
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int GalleryId { get; set; }

    }
}
