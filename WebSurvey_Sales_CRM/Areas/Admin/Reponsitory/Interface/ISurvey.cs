using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface ISurvey
    {
        Task<IEnumerable<Employee>> ApproveEmployee(int id);
        Task<IEnumerable<Enterprise>> ApproveEnterprise(int id);
        Task<IEnumerable<Employee>> DeleteEmployee(int id);
        Task<IEnumerable<Enterprise>> DeleteEnterprise(int id);
        Task<IEnumerable<Employee>> DetailEmployee(int id);
        Task<IEnumerable<Enterprise>> DetailEnterprise(int id);
        Task<IEnumerable<Employee>> GetAllDataEmployee();
        Task<IEnumerable<Enterprise>> GetAllDataEnterprise();
    }
}
