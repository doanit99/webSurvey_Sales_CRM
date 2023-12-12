using Humanizer;
using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Models;
using X.PagedList;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public readonly IUser _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUser userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;

        }
       
        //Get all data in user
        public async Task<IActionResult> Index(int? page)
        {
            if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
            {
                return Redirect("/");
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var data = await _userRepository.GetUsers();

            var pagedList = data.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        //View Grant permissions
        [HttpGet]
        public async Task<IActionResult> Permissions(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _userRepository.Permissions(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Grant permissions to users
        [HttpPost]
        public async Task<IActionResult> Permissions(User updatedUser)
        { 
            try
            {
              
                await _userRepository.GrantPermissions(updatedUser);

                return Redirect("/admin/user");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        //View Delete
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Session.GetInt32("idUser") == null)
                {
                    return Redirect("/");
                }
                var data = await _userRepository.GetDeleteUser(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete one row data in User

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);

                return Redirect("/admin/user");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

    }
}
