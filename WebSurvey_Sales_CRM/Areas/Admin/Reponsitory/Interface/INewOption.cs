using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface INewOption
    {
        Task<IEnumerable<RolesUser>> AddNameRoles(RolesUser rolesUser);
        Task<IEnumerable<RolesUser>> GetRoles();
    }
}
