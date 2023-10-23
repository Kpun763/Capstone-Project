using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/gallery")]
    [ApiController]

    public class GalleryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Gallery galleryData)
        {
            if (galleryData == null)
            {
                return BadRequest("WatchList data is invalid.");
            }

            _context.Galleries.Add(galleryData);
            _context.SaveChanges();

            // Return a 201 Created response with the newly created WatchList and its location.
            return Ok(galleryData);
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

        // PUT api/<GalleryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GalleryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
