using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeRepository;
        public EmployeeController(IEmployee employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Function add one data row
        [HttpPost]
        public async Task<IActionResult> StoreInformationEmployee(Employee employee)
        {
            try
            {
                var data = await _employeeRepository.StoreInformationEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }
        }

    }
}
