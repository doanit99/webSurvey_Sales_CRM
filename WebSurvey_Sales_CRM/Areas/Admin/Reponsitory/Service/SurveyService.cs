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
