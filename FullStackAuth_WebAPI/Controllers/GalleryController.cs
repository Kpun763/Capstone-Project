using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/gallery")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: api/<GalleryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<GalleryController>
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("Image file is missing or empty.");
            }

            // Handle image upload logic, save it to a location, and update the user's gallery with the image information.

            // Return a success response.
            
            return Ok("Image uploaded successfully.");
        }


        // DELETE api/<GalleryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

      
    }
}
