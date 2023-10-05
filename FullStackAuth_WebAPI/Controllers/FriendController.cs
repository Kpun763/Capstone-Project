using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/friend")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FriendController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public async Task<IActionResult> GetFriends()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var friends = await _context.Friends
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .ToListAsync();

            
            return Ok(friends);
        }

        // POST: api/Friends/{friendId}
        [HttpPost("{friendId}")]
        public IActionResult SendFriendRequest([FromForm] SendInRequest data, string friendId)
        {
            try {
                string userId = User.FindFirstValue("id");

                // Create a new friend request
                var friendRequest = new Friend
                {
                    User1Id = userId,
                    User2Id = friendId,
                    Status = 'P' // 
                };
                friendRequest.User1Id = userId;
                _context.Friends.Add(friendRequest);
                _context.SaveChanges();

                return Ok(friendRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Handle any exceptions.
            }

        }

        // PUT: api/Friends/{requestId}/accept
        [HttpPut("{requestId}/accept")]
        public IActionResult AcceptFriendRequest(int requestId)
        {
            var userId = User.FindFirstValue("id");

            var friendRequest = _context.Friends.Find(requestId);

            friendRequest.Status = 'A'; // 'A' for accepted
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Friends/{requestId}
        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteFriendRequest(int requestId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var friendRequest = await _context.Friends.FindAsync(requestId);

            _context.Friends.Remove(friendRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
