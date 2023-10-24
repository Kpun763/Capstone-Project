using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/blogpost")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogPostController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/<BlogPostController>
        [HttpGet("posts")]
        public IActionResult GetBlogPosts()
        {
            try
            {
                // Retrieve all the blog posts from your data source (e.g., database)
                var blogPosts = _context.BlogPosts.ToList(); // Adjust this query based on your data storage mechanism

                return Ok(blogPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlogController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromForm] BlogPostDTO formData)
        {
            try
            {
                string userId = User.FindFirstValue("id");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                var blog = new BlogPost 
                {
                    Title = formData.Title,
                    Content = formData.Content,
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                   


                };
  
                blog.UserId = userId;

                _context.BlogPosts.Add(blog);
                _context.SaveChanges();

 

                return StatusCode(201, blog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
