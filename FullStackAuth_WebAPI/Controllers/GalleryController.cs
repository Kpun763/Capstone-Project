using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/gallery")]
    [ApiController]

    public class GalleryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
       

        // GET: api/<GalleryController>
        [HttpGet]
        public IActionResult GetAllGalleries()
        {
            try
            {
                var galleries = _context.Galleries.ToList();
                return Ok(galleries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<GalleryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlogController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromForm] GalleryDTO formData)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }


                var gallery = new Gallery
                {
                    UserId = userId,
                    ImageUrls = new List<ImageUrl>(),
                };

                // Handle image uploads and save their URLs

                if (formData.Images != null)
                {
                    foreach (var imageFile in formData.Images)
                    {
                        string imageUrl = await SaveImage(imageFile); // Implement the SaveImage method to save the image and return its URL
                        var imageUrlEntity = new ImageUrl { Url = imageUrl, GalleryId = gallery.Id };
                        gallery.ImageUrls.Add(imageUrlEntity); // Add imageUrlEntity to the list of ImageUrls
                    }
                }

                gallery.UserId = userId;

                _context.Galleries.Add(gallery);
                _context.SaveChanges();



                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<GalleryController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var gallery = _context.Galleries.Find(id);

                if (gallery == null)
                {
                    return NotFound();
                }

                var userId = User.FindFirstValue("id");


                if (userId == gallery.UserId)
                {
                    _context.Galleries.Remove(gallery);
                    _context.SaveChanges();
                    return Ok();
                }
                return Unauthorized();


            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {


            if (imageFile == null || string.IsNullOrEmpty(imageFile.FileName))
            {

                return "Image file is missing or invalid.";
            }

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imageFile.FileName);

            if (string.IsNullOrEmpty(fileNameWithoutExtension))
            {

                return "Image file name is missing or invalid.";
            }

            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }
    }
}
