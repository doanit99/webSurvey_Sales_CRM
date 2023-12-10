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
            _accountRepository = accountRepository;
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
               
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    TempData["ErrorMessage"] = "Vui lòng nhập đầy đủ thông tin đăng nhập.";
                }
                var data = await _accountRepository.LoginAsync(userName, password);
                if (data != null && data.TypeUser == "Doanh nghiệp")
                {
                    return RedirectToAction("IndexEnterprise", "Enterprise");
                }
                else if (data != null && data.TypeUser == "Nhân viên")
                {
                    return RedirectToAction("Index", "Employee");
                }
                TempData["ErrorMessage"] = "Tài khoản hoặc mật khẩu không chính xác.";
                return View();
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
