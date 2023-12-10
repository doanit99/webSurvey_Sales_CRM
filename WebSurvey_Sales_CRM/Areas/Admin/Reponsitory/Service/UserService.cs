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

        //find row data by id 
        [HttpGet]
        public async Task<IEnumerable<User>> Permissions(int id)
        {
            try
            {

                return await _context.Users.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
        //Grant permissions to users
        [HttpPost]
        public async Task<IEnumerable<User>> GrantPermissions(User updatedUser)
        {
            try
            {
                var data = await _context.Users.FindAsync(updatedUser.Id);
                if (data == null)
                {
                    return Enumerable.Empty<User>();
                }
                data.Roles = updatedUser.Roles;
                await _context.SaveChangesAsync();
                return _context.Users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //find row data by id 
        [HttpGet]
        public async Task<IEnumerable<User>> GetDeleteUser(int id)
        {
            try
            {
                return await _context.Users.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
        //delete user
        [HttpPost]
        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            try
            {
                var data = await _context.Users.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<User>();
                }
                _context.Users.Remove(data);
                _context.SaveChanges();
                return _context.Users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
