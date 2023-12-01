using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Reponsitory.Interface
{
    public interface IEnterprise
    {
        Task<IEnumerable<Enterprise>> StoreInformationEnterprise(Enterprise enterprise);
    }
}
