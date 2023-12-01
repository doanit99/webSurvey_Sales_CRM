using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSurvey_Sales_CRM.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(100)")]
		public string DisplayName { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(250)")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(250)")]
		public string Password { get; set; }
        [Required(ErrorMessage = "This field is not empty..")]
        [Column(TypeName = "nvarchar(100)")]
        public string TypeUser { get; set; }
        public int? Roles { get; set; }
		public ICollection<Employee> Employees { get; set; }
		public ICollection<Enterprise> Enterprises { get; set; }
	}
}
