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
        public async Task<IActionResult> IndexRoles()
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
        public async Task<IActionResult> IndexRoles(RolesUser rolesUser)
        {
            try
            {
                await _newOptionRepository.AddNameRoles(rolesUser);
                return await IndexRoles();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //View Delete
        [HttpGet]
        public async Task<IActionResult> DeleteRoles(int id)
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

        [HttpPost, ActionName("DeleteRoles")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedRoles(int id)
        {
            try
            {
                await _newOptionRepository.DeleteNameRoles(id);

                return Redirect("/admin/newoption/indexroles");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }


        //Get all data in table Source
        [HttpGet]
        public async Task<IActionResult> IndexSource()
        {
            try
            {
                var data = await _newOptionRepository.GetSource();
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
        public async Task<IActionResult> IndexSource(Source source)
        {
            try
            {
                await _newOptionRepository.AddNameSource(source);
                return await IndexSource();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }

        //View Delete
        [HttpGet]
        public async Task<IActionResult> DeleteSource(int id)
        {
            try
            {
                var data = await _newOptionRepository.GetDeleteNameSource(id);
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
        //Delete one row data in Roles User

        [HttpPost, ActionName("DeleteSource")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSource(int id)
        {
            try
            {
                await _newOptionRepository.DeleteNameSource(id);

                return Redirect("/admin/newoption/indexsource");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return View();
            }
        }
    }
}
