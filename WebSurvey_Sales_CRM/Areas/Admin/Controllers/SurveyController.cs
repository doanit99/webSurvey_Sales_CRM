using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyController : Controller
    {
        public readonly ISurvey _surveyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SurveyController(ISurvey surveyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _surveyRepository = surveyRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        //Get all data in table Employee
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
               
                var data = await _surveyRepository.GetAllDataEmployee();
                return View(data);
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
