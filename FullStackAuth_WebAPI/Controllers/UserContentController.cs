using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserContent
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retrieve all user-generated content
                var userContents = _context.UserContents.ToList();
                return Ok(userContents);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/UserContent/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Retrieve user-generated content by ID
                var userContent = _context.UserContents.FirstOrDefault(uc => uc.Id == id);

                if (userContent == null)
                {
                    return NotFound();
                }

                return Ok(userContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/UserContent
        [HttpPost]
        public IActionResult Post([FromBody] UserContent userContent)
        {
            try
            {
                // Add user-generated content to the database
                _context.UserContents.Add(userContent);
                _context.SaveChanges();

                return CreatedAtAction("Get", new { id = userContent.Id }, userContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/UserContent/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserContent updatedUserContent)
        {
            try
            {
                // Find existing user-generated content by ID
                var existingUserContent = _context.UserContents.FirstOrDefault(uc => uc.Id == id);

                if (existingUserContent == null)
                {
                    return NotFound();
                }

                // Update the properties of the existing content
                existingUserContent.Title = updatedUserContent.Title;
                existingUserContent.ContentText = updatedUserContent.ContentText;

                // Save changes to the database
                _context.SaveChanges();

                return Ok(existingUserContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/UserContent/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find existing user-generated content by ID
                var userContent = _context.UserContents.FirstOrDefault(uc => uc.Id == id);

                if (userContent == null)
                {
                    return NotFound();
                }

                // Remove the content from the database
                _context.UserContents.Remove(userContent);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
  

