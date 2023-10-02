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
    public class FriendsListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FriendsListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FriendsList
        [HttpGet]
        public async Task<IActionResult> GetFriends()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var friends = await _context.FriendsList
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .ToListAsync();

            
            return Ok(friends);
        }

        // POST: api/FriendsList/{friendId}
        [HttpPost("{friendId}")]
        public async Task<IActionResult> SendFriendRequest(string friendId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create a new friend request
            var friendRequest = new FriendsList
            {
                User1Id = userId,
                User2Id = friendId,
                Status = 'P' // 'P' for pending
            };

            _context.FriendsList.Add(friendRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFriends), new { id = friendRequest.Id }, friendRequest);
        }

        // PUT: api/FriendsList/{requestId}/accept
        [HttpPut("{requestId}/accept")]
        public async Task<IActionResult> AcceptFriendRequest(int requestId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var friendRequest = await _context.FriendsList.FindAsync(requestId);

            friendRequest.Status = 'A'; // 'A' for accepted
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/FriendsList/{requestId}
        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteFriendRequest(int requestId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var friendRequest = await _context.FriendsList.FindAsync(requestId);

            _context.FriendsList.Remove(friendRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
