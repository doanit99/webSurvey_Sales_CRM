using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Service
{
    public class NewOptionService : INewOption
    {
        public readonly ApplicationDbContext _context;
        public NewOptionService(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get all name roles in RolesUser
        [HttpGet]
        public async Task<IEnumerable<RolesUser>> GetRoles()
        {
            try
            {
                return await _context.RolesUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }
        //Add name roles in RolesUser
        [HttpPost]
        public async Task<IEnumerable<RolesUser>> AddNameRoles(RolesUser rolesUser)
        {
            try
            {
                await _context.RolesUsers.AddAsync(rolesUser);
                await _context.SaveChangesAsync();
                return _context.RolesUsers;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
