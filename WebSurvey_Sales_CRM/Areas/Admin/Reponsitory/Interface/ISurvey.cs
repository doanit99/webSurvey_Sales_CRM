using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface ISurvey
    {
        Task<IEnumerable<Employee>> GetAllDataEmployee();
        Task<IEnumerable<Enterprise>> GetAllDataEnterprise();
    }
}
