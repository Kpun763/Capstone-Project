using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using FullStackAuth_WebAPI.Contracts;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        public UserController(IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }



        [HttpPost("profile")]
        [Authorize] // Requires authentication to create a user profile
        public IActionResult CreateUserProfile([FromBody] UserProfileDTO userProfileDto)
        {
            try
            {
                // Get the authenticated user's ID
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Map the DTO to your UserProfile entity
                var userProfile = _mapper.Map<UserProfile>(userProfileDto);

                // Set the user ID
                userProfile.UserId = userId;

                // Perform any additional validation or business logic here

                // Save the user profile
                _profileService.CreateUserProfile(userProfile);

                return CreatedAtAction("GetUserProfile", new { id = userProfile.Id }, userProfile);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
