using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Reponsitory.Interface;
using X.PagedList;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyController : Controller
    {
        public readonly ISurvey _surveyRepository;
        private readonly IEmployee _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SurveyController(ISurvey surveyRepository, IHttpContextAccessor httpContextAccessor, IEmployee employeeRepository)
        {
            _surveyRepository = surveyRepository;
            _httpContextAccessor = httpContextAccessor;
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                int pageSize = 1;
                int pageNumber = page ?? 1;

                var data = await _surveyRepository.GetAllDataEmployee();

                var pagedList = data.ToPagedList(pageNumber, pageSize);

                return View(pagedList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }


        //Detail table Employee
        [HttpGet]
        public async Task<IActionResult> DetailEmployee(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                var data = await _surveyRepository.DetailEmployee(id);
                var sourceModel = _employeeRepository.GetSource();
                var teamModel = _employeeRepository.GetTeam();

                var viewModel = new
                {
                    EmployeeModel = data,
                    SourceModel = sourceModel,
                    TeamModel = teamModel
                };

                return View(viewModel);
               
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        //View Delete Employee
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _surveyRepository.DeleteEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete one row data in Employee

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedEmployee(int id)
        {
            try
            {
                await _surveyRepository.DeleteEmployee(id);

                return Redirect("/admin/survey");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }


        //Get all data in table Enterprise
        [HttpGet]
        public async Task<IActionResult> IndexEnterprise()
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                var data = await _surveyRepository.GetAllDataEnterprise();
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }

        }

    }
}
