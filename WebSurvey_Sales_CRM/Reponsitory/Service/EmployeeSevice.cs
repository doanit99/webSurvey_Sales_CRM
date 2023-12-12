using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Reponsitory.Service
{
    public class EmployeeSevice : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeSevice(ApplicationDbContext context)
        {
            this._context = context;
        }
        //
        public async Task<IEnumerable<Employee>> StoreInformationEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return _context.Employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }

        //Get all data in table Source
        public IEnumerable<Source> GetSource()
        {
            try 
            {
                return  _context.Sources.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
            

        }

        //Get all data in table Team
        public IEnumerable<Team> GetTeam()
        {
            try
            {
                return _context.Teams.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }

        //Get all data in table User
        public IEnumerable<User> GetUser()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }


        }


    }
}
