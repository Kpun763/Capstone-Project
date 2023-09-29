using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContentController : ControllerBase
    {
        // GET: api/UserContent
        [HttpGet]
        [Authorize]
        public IActionResult GetUserContent()
        {
            try
            {
                // Retrieve user's content based on their ID
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Retrieve and return user's content (blog posts, reviews, art, etc.)
                // You might want to use a service to handle this logic
                var userContent = _userContentService.GetUserContent(userId);

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
        [Authorize]
        public IActionResult CreateUserContent([FromBody] UserContentDto userContentDto)
        {
            try
            {
                // Retrieve user's ID from the authentication token
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Map the DTO to your UserContent entity
                var userContent = _mapper.Map<UserContent>(userContentDto);

                // Set the user's ID
                userContent.UserId = userId;

                // Perform any additional validation or business logic here

                // Save the user's content
                _userContentService.CreateUserContent(userContent);

                return CreatedAtAction("GetUserContent", new { id = userContent.Id }, userContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
}
