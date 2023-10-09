using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        

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
