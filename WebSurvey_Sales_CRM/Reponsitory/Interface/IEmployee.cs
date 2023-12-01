using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Reponsitory.Interface
{
    public interface IEmployee
    {
        //Function store information employee
        Task<IEnumerable<Employee>> StoreInformationEmployee(Employee employee);
    }
}
