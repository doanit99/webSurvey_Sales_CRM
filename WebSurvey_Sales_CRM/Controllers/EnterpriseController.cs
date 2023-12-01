using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Controllers
{
    public class EnterpriseController : Controller
    {
        private readonly IEnterprise _enterpriseRepository;
        public EnterpriseController(IEnterprise enterpriseRepository)
        {
             this._enterpriseRepository = enterpriseRepository;
        }
        public IActionResult IndexEnterprise()
        {
            return View();
        }

        //Function add one data row
        [HttpPost]
        public async Task<IActionResult> StoreInformationEnterprise(Enterprise enterprise)
        {
            try
            {
                var data = await _enterpriseRepository.StoreInformationEnterprise(enterprise);
                return RedirectToAction("IndexEnterprise");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }
        }
    }
}
