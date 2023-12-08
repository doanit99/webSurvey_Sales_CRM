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
        //index delete
        [HttpGet]
        public async Task<IEnumerable<RolesUser>> GetDeleteNameRoles(int id)
        {
            try
            {

                return await _context.RolesUsers.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //delete
        [HttpPost]
        public async Task<IEnumerable<RolesUser>> DeleteNameRoles(int id)
        {
            try
            {
                var data = await _context.RolesUsers.FindAsync(id);
                _context.RolesUsers.Remove(data);
                _context.SaveChanges();
                return _context.RolesUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }





    }
}
