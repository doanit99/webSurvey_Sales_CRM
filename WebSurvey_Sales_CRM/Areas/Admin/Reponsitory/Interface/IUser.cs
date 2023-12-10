using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> DeleteUser(int id);
        Task<IEnumerable<User>> GetDeleteUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GrantPermissions(User updatedUser);
        Task<IEnumerable<User>> Permissions(int id);
    }
}
