using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> Permission(int userId, int newRolesId);
    }
}
