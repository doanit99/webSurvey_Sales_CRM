using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Service
{
    public class SurveyService : ISurvey
    {
        private readonly ApplicationDbContext _context;

        public SurveyService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all data in table employee
        public async Task<IEnumerable<Employee>> GetAllDataEmployee()
        {
            try 
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }


        //Detail employee
        [HttpGet]
        public async Task<IEnumerable<Employee>> DetailEmployee(int id)
        {
            try
            {

                return await _context.Employees.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //Delete employee
        [HttpPost]
        public async Task<IEnumerable<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var data = await _context.Employees.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<Employee>();
                }
                _context.Employees.Remove(data);
                _context.SaveChanges();
                return _context.Employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //Get all data in table enterprise
        public async Task<IEnumerable<Enterprise>> GetAllDataEnterprise()
        {
            try
            {
                return await _context.Enterprises.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
