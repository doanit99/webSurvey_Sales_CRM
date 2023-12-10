using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Data;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IHttpContextAccessor httpContextAccessor)
        {
            
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            if(_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
            {
                return Redirect("/");
            }
            return View();


        }
    }
}
