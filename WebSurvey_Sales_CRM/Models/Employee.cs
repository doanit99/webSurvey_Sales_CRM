using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSurvey_Sales_CRM.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Column(TypeName = "nvarchar(100)")]
		public string Name { get; set; }
		public int Phone { get; set; }
		[Column(TypeName = "nvarchar(250)")]
		public string Email { get; set; }
		[Column(TypeName = "nvarchar(500)")]
		public string Address { get; set; }
		public int SourceCode { get; set; }
		public int TeamCode { get; set; }
		public int Status { get; set; }
		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

  
    }
}
