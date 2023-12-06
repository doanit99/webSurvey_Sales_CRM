using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Service
{
    public class UserService : IUser
    {
        public readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get all data in table user
        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //Grant permissions to users
        [HttpPatch]
        public async Task<IEnumerable<User>> Permission(int userId, int newRolesId)
        {
            try
            {
                var userToUpdate = await _context.Users.FindAsync(userId);

                if (userToUpdate != null)
                {
                    userToUpdate.Roles = newRolesId;
                    await _context.SaveChangesAsync();
                    return _context.Users;
                }

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
