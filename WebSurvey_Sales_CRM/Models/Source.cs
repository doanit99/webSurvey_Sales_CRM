using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSurvey_Sales_CRM.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        public int SourceCode { get; set; }
    }
}
