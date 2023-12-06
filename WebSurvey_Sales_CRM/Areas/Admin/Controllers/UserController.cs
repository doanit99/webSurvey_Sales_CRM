using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public readonly IUser _userRepository;
        public UserController(IUser userRepository)
        {
            _userRepository= userRepository;
        }
        //Get all data in user
        public IActionResult Index()
        {
            var data = _userRepository.GetUsers();
            return View(data);
        }
    }
}
