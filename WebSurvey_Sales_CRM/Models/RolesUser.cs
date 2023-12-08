using System.ComponentModel.DataAnnotations;
namespace WebSurvey_Sales_CRM.Models
{
	public class RolesUser
	{
		public int Id { get; set; }
        [Required(ErrorMessage = "This field is not empty..")]
        public string NameRolesUser { get; set; }
	}
}
