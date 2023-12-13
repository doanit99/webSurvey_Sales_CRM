namespace WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface
{
    public interface IDashboard
    {
        int GetEnterpriseCount();
        int GetEnterpriseCountToday();
        int GetSurveyCount();
        int GetSurveyCountToday();
    }
}
