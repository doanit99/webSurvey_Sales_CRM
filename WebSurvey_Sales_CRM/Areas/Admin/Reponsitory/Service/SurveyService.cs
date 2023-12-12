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
/*--------------------------------------------- Employee ----------------------------------------------*/
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

        //Approve Employee
        [HttpPost]
        public async Task<IEnumerable<Employee>> ApproveEmployee(int id)
        {
            try
            {
                var data = await _context.Employees.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<Employee>();
                }
                data.Status = 2;
                _context.SaveChanges();
                return _context.Employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

/*--------------------------------------------- Enterprise ----------------------------------------------*/
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

        //Detail Enterprise
        [HttpGet]
        public async Task<IEnumerable<Enterprise>> DetailEnterprise(int id)
        {
            try
            {

                return await _context.Enterprises.Where(r => r.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //Delete Enterprise
        [HttpPost]
        public async Task<IEnumerable<Enterprise>> DeleteEnterprise(int id)
        {
            try
            {
                var data = await _context.Enterprises.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<Enterprise>();
                }
                _context.Enterprises.Remove(data);
                _context.SaveChanges();
                return _context.Enterprises;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        //Approve Enterprise
        [HttpPost]
        public async Task<IEnumerable<Enterprise>> ApproveEnterprise(int id)
        {
            try
            {
                var data = await _context.Enterprises.FindAsync(id);
                if (data == null)
                {
                    return Enumerable.Empty<Enterprise>();
                }
                data.Status = 2;
                _context.SaveChanges();
                return _context.Enterprises;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

    }
}
