using Microsoft.EntityFrameworkCore;
using WebSurvey_Sales_CRM.Models;

namespace WebSurvey_Sales_CRM.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Enterprise> Enterprises { get; set; }
		public DbSet<RolesUser> RolesUsers { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
