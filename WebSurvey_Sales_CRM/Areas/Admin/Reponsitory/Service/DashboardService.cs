using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Data;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Service
{
    public class DashboardService : IDashboard
    {
        public readonly ApplicationDbContext _context;
        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Count survey employee
        public int GetSurveyCount()
        {
            return _context.Employees.Count();
        }
        //Count survey employee today
        public int GetSurveyCountToday()
        {
            DateTime today = DateTime.Today;

            return _context.Employees.Count(s => s.CreatedAt.Date == today);

        }

        //Count survey enterprise
        public int GetEnterpriseCount()
        {
            return _context.Enterprises.Count();
        }
        //Count survey Enterprise today
        public int GetEnterpriseCountToday()
        {
            DateTime today = DateTime.Today;

            return _context.Enterprises.Count(s => s.CreatedAt.Date == today);

        }
    }
}
