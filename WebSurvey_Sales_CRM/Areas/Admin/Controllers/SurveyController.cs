using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyController : Controller
    {
        public readonly ISurvey _surveyRepository;
        public SurveyController(ISurvey surveyRepository)
        {
             this._surveyRepository = surveyRepository;
        }
        //Get all data in table Employee
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
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
