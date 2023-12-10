using Microsoft.AspNetCore.Mvc;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface INewOption
    {
        //Roles
        Task<IEnumerable<RolesUser>> AddNameRoles(RolesUser rolesUser);
        Task<IEnumerable<RolesUser>> DeleteNameRoles(int roleId);
        Task<IEnumerable<RolesUser>> GetDeleteNameRoles(int id);
        Task<IEnumerable<RolesUser>> GetRoles();

        //Source
        Task<IEnumerable<Source>> AddNameSource(Source source);
        Task<IEnumerable<Source>> DeleteNameSource(int id);
        Task<IEnumerable<Source>> GetDeleteNameSource(int id);
        Task<IEnumerable<Source>> GetSource();
        Task<IEnumerable<Team>> GetTeam();
        Task<IEnumerable<Team>> AddNameTeam(Team team);
        Task<IEnumerable<Team>> GetDeleteNameTeam(int id);
        Task<IEnumerable<Team>> DeleteNameTeam(int id);
    }
}
