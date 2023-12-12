using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Controllers
{
    public class EnterpriseController : Controller
    {
        private readonly IEnterprise _enterpriseRepository;
        private readonly IEmployee _employeeRepository;

        public EnterpriseController(IEnterprise enterpriseRepository, IEmployee employeeRepository)
        {
            this._enterpriseRepository = enterpriseRepository;
            _employeeRepository = employeeRepository;
        }
        public IActionResult IndexEnterprise()
        {
            var vietnamAddresses = new List<string>
            {
            "Hà Nội",
            "Hồ Chí Minh",
            "Đà Nẵng",
            "Hải Phòng",
            "Cần Thơ",
            "An Giang",
            "Bà Rịa - Vũng Tàu",
            "Bắc Giang",
            "Bạc Liêu",
            "Bắc Ninh",
            "Bến Tre",
            "Bình Định",
            "Bình Dương",
            "Bình Phước",
            "Bình Thuận",
            "Cà Mau",
            "Cao Bằng",
            "Đắk Lắk",
            "Đắk Nông",
            "Điện Biên",
            "Đồng Nai",
            "Đồng Tháp",
            "Gia Lai",
            "Hà Giang",
            "Hà Nam",
            "Hà Tĩnh",
            "Hải Dương",
            "Hậu Giang",
            "Hòa Bình",
            "Hưng Yên",
            "Khánh Hòa",
            "Kiên Giang",
            "Kon Tum",
            "Lai Châu",
            "Lâm Đồng",
            "Lạng Sơn",
            "Lào Cai",
            "Long An",
            "Nam Định",
            "Nghệ An",
            "Ninh Bình",
            "Ninh Thuận",
            "Phú Thọ",
            "Quảng Bình",
            "Quảng Nam",
            "Quảng Ngãi",
            "Quảng Ninh",
            "Quảng Trị",
            "Sóc Trăng",
            "Sơn La",
            "Tây Ninh",
            "Thái Bình",
            "Thái Nguyên",
            "Thanh Hóa",
            "Thừa Thiên Huế",
            "Tiền Giang",
            "Trà Vinh",
            "Tuyên Quang ",
            "Vĩnh Long",
            "Vĩnh Phúc",
            "Yên Bái",


            };

            var sourceModel = _employeeRepository.GetSource();
            var teamModel = _employeeRepository.GetTeam();

            var viewModel = new
            {
                VietnamAddresses = vietnamAddresses,
                SourceModel = sourceModel,
                TeamModel = teamModel
            };

            return View(viewModel);
        }

        //Function add one data row
        [HttpPost]
        public async Task<IActionResult> StoreInformationEnterprise(Enterprise enterprise)
        {
            try
            {
                var data = await _enterpriseRepository.StoreInformationEnterprise(enterprise);
                return RedirectToAction("Notification");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View();
            }
        }

        //Index successful notification
        public IActionResult Notification()
        {
            return View();
        }
    }
}
