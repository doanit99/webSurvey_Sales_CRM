using Microsoft.AspNetCore.Http.HttpResults;
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
            _context = context;
        }
/*-------------------------------------------------- Roles --------------------------------------------------*/
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
                if (rolesUser == null)
                {
                    return Enumerable.Empty<RolesUser>();
                }

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
        //find row data by id 
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
        //delete name roles
        [HttpPost]
        public async Task<IEnumerable<RolesUser>> DeleteNameRoles(int id)
        {
            try
            {
                var data = await _context.RolesUsers.FindAsync(id);
                if(data == null)
                {
                    return Enumerable.Empty<RolesUser>();
                }    
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

/*-------------------------------------------------- Source --------------------------------------------------*/
        //Get all name Source in Source
        [HttpGet]
        public async Task<IEnumerable<Source>> GetSource()
        {
            try
            {
                return await _context.Sources.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }
        //Add name roles in RolesUser
        [HttpPost]
        public async Task<IEnumerable<Source>> AddNameSource(Source source)
        {
            try
            {
                if (source == null)
                {
                    return Enumerable.Empty<Source>();
                }

                await _context.Sources.AddAsync(source);
                await _context.SaveChangesAsync();
                return _context.Sources;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
        //find row data by id 
        [HttpGet]
        public async Task<IEnumerable<Source>> GetDeleteNameSource(int id)
        {
            try
            {
                return await _context.Sources.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }
        //delete name roles
        [HttpPost]
        public async Task<IEnumerable<Source>> DeleteNameSource(int id)
        {
            try
            {
                var data = await _context.Sources.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<Source>();
                }
                _context.Sources.Remove(data);
                _context.SaveChanges();
                return _context.Sources;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
