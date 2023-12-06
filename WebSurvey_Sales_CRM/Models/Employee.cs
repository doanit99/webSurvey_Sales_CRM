using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSurvey_Sales_CRM.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(100)")]
		public string Name { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		public int Phone { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(250)")]
		public string Email { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		[Column(TypeName = "nvarchar(500)")]
		public string Address { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		public string SourceCode { get; set; }
		[Required(ErrorMessage = "This field is not empty..")]
		public string TeamCode { get; set; }
		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

  
    }
}
