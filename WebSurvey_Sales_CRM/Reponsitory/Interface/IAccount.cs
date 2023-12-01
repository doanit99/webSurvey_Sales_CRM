using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Reponsitory.Interface
{
    public interface IAccount
    {
        Task<User> LoginAsync(string userName, string password);
        Task<IEnumerable<User>> Register(User user);
    }
}
