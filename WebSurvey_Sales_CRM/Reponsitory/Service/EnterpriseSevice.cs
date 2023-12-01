using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Models;
using WebSurvey_Sales_CRM.Reponsitory.Interface;

namespace WebSurvey_Sales_CRM.Reponsitory.Service
{
    public class EnterpriseSevice : IEnterprise
    {
        private readonly ApplicationDbContext _context;
        public EnterpriseSevice(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Enterprise>> StoreInformationEnterprise(Enterprise enterprise)
        {
            try
            {
                _context.Enterprises.Add(enterprise);
                await _context.SaveChangesAsync();
                return _context.Enterprises;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }

        }

    }
}
