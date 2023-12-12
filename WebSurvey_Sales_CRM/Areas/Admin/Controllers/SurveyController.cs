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

/*--------------------------------------------- Employee ----------------------------------------------*/
        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                int pageSize = 10;
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
                var userModel = _employeeRepository.GetUser();

                var viewModel = new
                {
                    EmployeeModel = data,
                    SourceModel = sourceModel,
                    TeamModel = teamModel,
                    UserModel = userModel,
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
                var data = await _surveyRepository.DetailEmployee(id);
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

        //View Approve Employee
        [HttpGet]
        public async Task<IActionResult> ApproveEmployee(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _surveyRepository.DetailEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Approve Employee
        [HttpPost, ActionName("ApproveEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmedEmployee(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                var data = await _surveyRepository.ApproveEmployee(id);

                return Redirect("/admin/survey");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

/*--------------------------------------------- Enterprise ----------------------------------------------*/
        //Get all data in table Enterprise
        [HttpGet]
        public async Task<IActionResult> IndexEnterprise(int? page)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                int pageSize = 1;
                int pageNumber = page ?? 1;

                var data = await _surveyRepository.GetAllDataEnterprise();

                var pagedList = data.ToPagedList(pageNumber, pageSize);

                return View(pagedList);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }

        }
        //Detail table Enterprise
        [HttpGet]
        public async Task<IActionResult> DetailEnterprise(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                var data = await _surveyRepository.DetailEnterprise(id);
                var sourceModel = _employeeRepository.GetSource();
                var teamModel = _employeeRepository.GetTeam();
                var userModel = _employeeRepository.GetUser();

                var viewModel = new
                {
                    EnterpriseModel = data,
                    SourceModel = sourceModel,
                    TeamModel = teamModel,
                    UserModel = userModel,
                };

                return View(viewModel);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        //View Delete Enterprise
        [HttpGet]
        public async Task<IActionResult> DeleteEnterprise(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _surveyRepository.DetailEnterprise(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete one row data in Enterprise

        [HttpPost, ActionName("DeleteEnterprise")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedEnterprise(int id)
        {
            try
            {
                await _surveyRepository.DeleteEnterprise(id);

                return Redirect("/admin/survey/IndexEnterprise");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        //View Approve Enterprise
        [HttpGet]
        public async Task<IActionResult> ApproveEnterprise(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _surveyRepository.DetailEnterprise(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Approve Enterprise
        [HttpPost, ActionName("ApproveEnterprise")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmedEnterprise(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }

                var data = await _surveyRepository.ApproveEnterprise(id);

                return Redirect("/admin/survey/IndexEnterprise");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
    }
}
