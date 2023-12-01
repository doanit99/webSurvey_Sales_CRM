using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IAccount accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        //Register view
        public IActionResult Register()
        {
            return View();
        }

        //Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var data = await _accountRepository.Register(user);
                
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }
        }
        //Login view
        public IActionResult Login()
        {
            return View();
        }

        //Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {
            
            try
            {
                var data = await _accountRepository.LoginAsync(userName, password);
                if (data.TypeUser == "Doanh nghiệp")
                {
                    return RedirectToAction("IndexEnterprise", "Enterprise");
                }
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }

        }
        //Logout
        public ActionResult Logout()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
