using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Data;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashboard _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IHttpContextAccessor httpContextAccessor, IDashboard dashboardRepository)
        {
            
            _httpContextAccessor = httpContextAccessor;
            _dashboardRepository = dashboardRepository;
        }
        public IActionResult Index()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
            {
                return Redirect("/");
            }

            // Get the total survey count
            int surveyCount = _dashboardRepository.GetSurveyCount();
            ViewBag.SurveyCount = surveyCount;

            // Get the survey count conducted today
            int surveyCountToday = _dashboardRepository.GetSurveyCountToday();
            ViewBag.SurveyCountToday = surveyCountToday;

            // Get the total survey enterprise count
            int surveyEnterpriseCount = _dashboardRepository.GetEnterpriseCount();
            ViewBag.SurveyEnterpriseCount = surveyEnterpriseCount;

            // Get the survey count enterprise conducted today
            int surveyEnterpriseCountToday = _dashboardRepository.GetEnterpriseCountToday();
            ViewBag.SurveyEnterpriseCountToday = surveyEnterpriseCountToday;

            return View();
        }
    }
}
