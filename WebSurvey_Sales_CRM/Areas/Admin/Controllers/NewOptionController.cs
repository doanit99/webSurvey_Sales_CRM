using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewOptionController : Controller
    {
        public readonly INewOption _newOptionRepository;
        public NewOptionController(INewOption newOptionRepository)
        {
            _newOptionRepository = newOptionRepository;
        }
        //Get all data in table Roles User
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await _newOptionRepository.GetRoles();
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        
        //Add one row data in Roles User
        [HttpPost]
        
        public async Task<IActionResult> Index(RolesUser rolesUser)
        {
            try
            {
                await _newOptionRepository.AddNameRoles(rolesUser);
                return await Index();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _newOptionRepository.GetDeleteNameRoles(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete one row data in Roles User

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _newOptionRepository.DeleteNameRoles(id);

                return Redirect("/admin/newoption");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }



    }
}
