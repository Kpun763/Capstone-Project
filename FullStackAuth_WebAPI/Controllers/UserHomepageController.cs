using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserHomepageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserHomepageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserHomepage
        [HttpGet]
        public async Task<IActionResult> GetUserHomepageContent()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Retrieve user's homepage content
                var userHomepage = await _context.UserHomepages
                    .Include(uh => uh.BlogPosts) // Assuming you have a navigation property for blog posts
                    .Include(uh => uh.Reviews) // Assuming you have a navigation property for reviews
                    .Include(uh => uh.Gallery) // Assuming you have a navigation property for the gallery
                    .FirstOrDefaultAsync(uh => uh.UserId == userId);

                if (userHomepage == null)
                {
                    return NotFound("User homepage not found.");
                }

                return Ok(userHomepage);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/UserHomepage
        [HttpPost]
        public async Task<IActionResult> AddUserHomepageContent([FromBody] UserHomepage userHomepage)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Check if the user already has a homepage (you may have different logic here)
                var existingHomepage = await _context.UserHomepages.FirstOrDefaultAsync(uh => uh.UserId == userId);

                if (existingHomepage != null)
                {
                    return Conflict("User homepage already exists.");
                }

                // Set the user ID
                userHomepage.UserId = userId;

                // Perform any additional validation or business logic here

                // Save the user homepage
                _context.UserHomepages.Add(userHomepage);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUserHomepageContent), new { id = userHomepage.Id }, userHomepage);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
