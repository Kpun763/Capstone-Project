using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStackAuth_WebAPI.Services
{
    public class UserContentService
    {
        private readonly ApplicationDbContext _context;

        public UserContentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a new user content
        public UserContent Create(UserContent userContent)
        {
            _context.UserContents.Add(userContent);
            _context.SaveChanges();
            return userContent;
        }

        // Retrieve user content by ID
        public UserContent GetById(int id)
        {
            return _context.UserContents.FirstOrDefault(uc => uc.Id == id);
        }

        // Retrieve user content for a specific user by user ID
        public List<UserContent> GetUserContentByUserId(string userId)
        {
            return _context.UserContents.Where(uc => uc.UserId == userId).ToList();
        }

        // Update user content
        public UserContent Update(UserContent updatedUserContent)
        {
            var existingUserContent = GetById(updatedUserContent.Id);

            if (existingUserContent == null)
            {
                throw new InvalidOperationException("User content not found");
            }

            // Update properties of the existing user content
            existingUserContent.Title = updatedUserContent.Title;
            existingUserContent.ContentText = updatedUserContent.ContentText;

            _context.SaveChanges();
            return existingUserContent;
        }

        // Delete user content by ID
        public void Delete(int id)
        {
            var userContent = GetById(id);

            if (userContent != null)
            {
                _context.UserContents.Remove(userContent);
                _context.SaveChanges();
            }
        }
    }
}
